using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using Git.Manager;
using System.IO;
using Git.Core.Helper;

namespace Git.UI
{
    public partial class FormConflict : Form
    {
        CGitManager _objGitMgr = null;
        private string _szLocalBranch;
        private string _szWorkingdir;
        private bool _bIsPulled;
        private string _szOldLocalSHA;
        int _nMergeType = 0;

        public Dictionary<string, string> m_mapAllRemotes; //<remote, fetch/push>
        public string[] m_RemoteBranchArray;
        public string m_szTrackingRemote;
        public string m_szTrackingRemoteBranch;



        #region help inner function
        public FormConflict(CGitManager objGitMgr, string szWorkingdir, string LocalBranch)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szWorkingdir = CHelpFuntions.GetValidWorkingDir(szWorkingdir);
            _szLocalBranch=LocalBranch;
            _bIsPulled = false;
            _szOriginBranch = LocalBranch;

            ResolveProcessAbort = new EventHandler(ManualResolveProcessExit);
            syncResolveContext = SynchronizationContext.Current;
        }
        private void FormConflictl_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_szWorkingdir))
                return;
            //if (string.IsNullOrEmpty(_szLocalBranch))
            //    return;
            m_txLocalBranch.Text = _szLocalBranch;
            _nMergeType = CHelpFuntions.IsAnyRebaseOrMergeInfo(_szWorkingdir);


            //Get git information
            m_mapAllRemotes = _objGitMgr._objGitMgrCore.GetAllRemoteRepo(_szWorkingdir);
            m_RemoteBranchArray = _objGitMgr._objGitMgrCore.GetBranch(true, _szWorkingdir);
            if (m_mapAllRemotes == null || m_RemoteBranchArray == null)
                return;

            string szInfo = _objGitMgr._objGitMgrCore.GetSingleTracking(_szLocalBranch, _szWorkingdir);
            if(false==string.IsNullOrEmpty(szInfo))
            {
                string[] ResArray = szInfo.Split(new[] { '\r', '\n', ' ','/' },StringSplitOptions.RemoveEmptyEntries);
                m_szTrackingRemote=ResArray[0];
                m_szTrackingRemoteBranch = szInfo;            
            }

            //update UI
            if (m_RemoteBranchArray != null && m_RemoteBranchArray.Length>0)
            {
                m_cobRemoteRepoLists.Items.Clear();
                foreach (string szTmp in m_mapAllRemotes.Keys)
                {
                    m_cobRemoteRepoLists.Items.Add(szTmp);
                }  
            }
            m_cobRemoteRepoLists.Text = m_szTrackingRemote;


            if (m_RemoteBranchArray != null && m_RemoteBranchArray.Length > 0)
            {
                m_cobRemoteBranchLists.Items.Clear();
                foreach (string szTmp in m_RemoteBranchArray)
                {
                    if (szTmp.Contains(m_szTrackingRemote+@"/"))
                        m_cobRemoteBranchLists.Items.Add(szTmp);
                    else
                        continue;
                }
            }
            m_cobRemoteBranchLists.Text = m_szTrackingRemoteBranch;

            //save original information
            _szOldLocalSHA = _objGitMgr._objGitMgrCore.GetHashIDFrom(_szLocalBranch, _szWorkingdir);
            if (string.IsNullOrEmpty(m_szTrackingRemoteBranch))
                m_picShowTracking.Visible = false;

            //ready for external tools for resolve conflicts
            m_lvConflict.Items.Clear();
            if (_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir))
            {
                ShowConflict();
            }
            else 
            {
                  if(_nMergeType!=0)
                      ShowConflict();
                  else
                      m_lvConflict.Items.Clear();
            }

        }
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsPulled)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool GetConflictType()
        {
            return false;        
        }
        #endregion
        

        //External tool notify the windows the operation has been finished
        public EventHandler ResolveProcessAbort;
        protected readonly SynchronizationContext syncResolveContext;
        Dictionary<string, string> mapFileInfo = new Dictionary<string, string>();

        private string _szOriginBranch;
        private ProcessStatus _OperStatus;


        #region resolve confilict function   
        //(step 2)
        private void ManualResolveProcessExit(object sender, EventArgs e)
        {
            SendOrPostCallback AppCallback = p =>
            {
                AfterManualResolve(sender, e);
            };
            syncResolveContext.Send(AppCallback, this);

        }
        //(step 3)
        private void AfterManualResolve(object sender, EventArgs e)
        {
            foreach (string szReFileName in mapFileInfo.Keys)
            {

                FileInfo info = new FileInfo(_szWorkingdir + szReFileName);
                if (false == mapFileInfo[szReFileName].Equals(info.LastWriteTime.ToString()))
                {
                    //file has been changed,require add it to index
                    string szContent = string.Format("{0} has been changed.\nAre you sure that you will add your resolve result into index area?", szReFileName);
                    MessageBoxIcon icon = MessageBoxIcon.Question;
                    var result = MessageBox.Show(this, szContent, "Warning", MessageBoxButtons.YesNo, icon);

                    //resolve conflict successfully
                    if (result == DialogResult.Yes)
                    {

                        _objGitMgr._objGitMgrCore.AddFile(szReFileName, _szWorkingdir);
                        mapFileInfo.Remove(szReFileName);
                        //resolve conflict successfully
                        ShowConflict();
                    }

                    break;
                }
            }
            AfterResolve();
        }
        //(step 4)
        private void AfterResolve()
        {
            //Give a choice to select whether all merge should be committed
            if (_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false)
            {
                MessageBoxIcon icon = MessageBoxIcon.Question;
                var result = MessageBox.Show(this, @"All Conflicts have been resolved, will you commit them into repository?", "Warning", MessageBoxButtons.YesNo, icon);

                if (result == DialogResult.Yes)
                {
                    if(_nMergeType==1)
                    {
                        _objGitMgr._objGitMgrCore.CommitAllStaged("Pull from Remote Repository", _szWorkingdir);
                    }
                    else if(_nMergeType==2)
                    {
                        string szInfo = _objGitMgr._objGitMgrCore.ContinueRebase(_szWorkingdir);
                        if (szInfo.StartsWith(@"Result"))
                        {
                            
                        }
                        else
                        {
                            
                            if (_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir))
                            {
                                ShowConflict();
                            }
                            else
                            {
                                MessageBox.Show(this, @"Rebase continue failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }

                //show which file has been merged
                ShowSuccessCommitChange();
            }
        }
        //GUI(step 1)
        private void ShowConflict()
        {
            _nMergeType = CHelpFuntions.IsAnyRebaseOrMergeInfo(_szWorkingdir);
            if (_nMergeType ==1)
            {
                _OperStatus = ProcessStatus.PROCESS_MERGE;
            }
            else if(_nMergeType ==2)
            {
                _OperStatus = ProcessStatus.PROCESS_REBASE;
            }
            else
            {
                _OperStatus = ProcessStatus.PROCESS_START;
            }

            Dictionary<string, string> mapConflicts;
            mapConflicts = _objGitMgr._objGitMgrCore.GetConflict(_szWorkingdir);
            if (mapConflicts == null || mapConflicts.Count <= 0)
            {                
                if (_nMergeType == 0)
                    return;

                mapConflicts = _objGitMgr._objGitMgrCore.GetConflictAndMerged(_szWorkingdir);
                if (mapConflicts == null || mapConflicts.Count <= 0)
                {                    
                    return;
                }
            }

            //update conflict list
            m_lvConflict.Items.Clear();
            foreach (string szfileName in mapConflicts.Keys)
            {
                string szType = mapConflicts[szfileName];
                ListViewItem item = new ListViewItem(szType, 0);

                if(szType.Equals("UU"))
                {
                    item.Tag = szType;
                    item.BackColor = Color.LightSalmon;
                }
                else if (szType.Equals("DD") || szType.Equals("AA") || szType.Contains("U"))
                {
                    item.Tag = szType;
                    item.BackColor = Color.LightPink;
                }
                else
                {
                    item.Tag = szType; ;
                    item.BackColor = Color.LightBlue;
                }
                item.SubItems.Add(szfileName);

                item.SubItems.Add(@"Index");
                m_lvConflict.Items.Add(item);
            }

        }
        //GUI(step 5)
        private void ShowSuccessCommitChange()
        {
            if(_nMergeType==2)
            {
                MessageBoxIcon icon = MessageBoxIcon.Information;
                MessageBox.Show(this, @"The Rebase Merge has been completed successfully.", "Successful", MessageBoxButtons.OK, icon);
                m_lvConflict.Items.Clear();
                _nMergeType=0;
                return;            
            }
            else if(_nMergeType==1)
            {
                MessageBoxIcon icon = MessageBoxIcon.Information;
                MessageBox.Show(this, @"The Pull Merge has been completed successfully.", "Successful", MessageBoxButtons.OK, icon);
                m_lvConflict.Items.Clear();
                _nMergeType = 0;
            }

            string szOldTargeSHA = _szOldLocalSHA;
            string szNewTargetSHA = _objGitMgr._objGitMgrCore.GetHashIDFrom(m_cobRemoteBranchLists.Text, _szWorkingdir);
            if (string.IsNullOrEmpty(szNewTargetSHA) || string.IsNullOrEmpty(szOldTargeSHA))
                return;
            if (szOldTargeSHA.Equals(szNewTargetSHA))
            {
                //this result is from fast-forward or update, no new commit
                return;
            }


            //update merge list
            string[] ChangeList = _objGitMgr._objGitMgrCore.GetCommitChange(szOldTargeSHA, szNewTargetSHA, _szWorkingdir);
            //first node, there's no change
            if (ChangeList == null)
            {
                m_lvConflict.Items.Clear();
                return;
            }

            m_lvConflict.Items.Clear();
            foreach (string szChangeItem in ChangeList)
            {
                string[] ResArray = szChangeItem.Split(new[] { '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                ListViewItem item = new ListViewItem(ResArray[0], 0);
                item.Tag = szChangeItem;
                item.BackColor = Color.AliceBlue;

                if (szChangeItem.StartsWith("R"))
                {
                    item.SubItems.Add(ResArray[1] + "-->" + ResArray[2]);
                }
                else
                {
                    item.SubItems.Add(ResArray[1]);
                }
                item.SubItems.Add(@"Committed");
                m_lvConflict.Items.Add(item);
            }
 
        }
        #endregion

        #region Menu Item function    
        private void m_MergeToolMenuItem_Click(object sender, EventArgs e)
        {
            //if (m_lvConflict.FocusedItem != null)
            if (m_lvConflict.FocusedItem != null)
            {
                string szFileName = m_lvConflict.FocusedItem.SubItems[1].Text;
                string szRes = _objGitMgr._objGitMgrCore.MergeOneFile(szFileName, _szWorkingdir);
                if (string.IsNullOrEmpty(szRes))
                {
                    //resolve conflict successfully
                    ShowConflict();
                }
            }
            //AfterResolve();
        }
        private void m_RmConflictMenuItem_Click(object sender, EventArgs e)
        {
            if (m_lvConflict.FocusedItem != null &&
                (m_lvConflict.FocusedItem.Tag.ToString().Contains("D") || m_lvConflict.FocusedItem.Tag.ToString().Contains("A")))
            {
                string szFileName = m_lvConflict.FocusedItem.SubItems[1].Text;

                List<string> lstFiles = new List<string>();
                if (false == string.IsNullOrEmpty(szFileName))
                    lstFiles.Add(szFileName);

                _objGitMgr._objGitMgrCore.Delete(_szWorkingdir, lstFiles, false);
                //resolve conflict successfully
                ShowConflict();
            }
            //AfterResolve();
        }
        private void m_AddConflictMenuItem_Click(object sender, EventArgs e)
        {
            if (m_lvConflict.FocusedItem != null &&
                (m_lvConflict.FocusedItem.Tag.ToString().Contains("D") || m_lvConflict.FocusedItem.Tag.ToString().Contains("A")))
            {
                string szFileName = m_lvConflict.FocusedItem.SubItems[1].Text;
                _objGitMgr._objGitMgrCore.AddFile(szFileName, _szWorkingdir);
                //resolve conflict successfully
                ShowConflict();
            }
            //AfterResolve();
        }
        private void m_ManualResolveMenuItem_Click(object sender, EventArgs e)
        {
            string szFileName = string.Empty;
            if (m_lvConflict.FocusedItem != null)
            {
                szFileName = m_lvConflict.FocusedItem.SubItems[1].Text;
            }
            if (string.IsNullOrEmpty(szFileName))
                return;

            //save file info for detecting file change
            mapFileInfo.Clear();
            foreach (ListViewItem Item in m_lvConflict.Items)
            {
                if (Item.Tag.ToString().Equals("UU") || Item.Tag.ToString().Equals("AA"))
                {
                    FileInfo info = new FileInfo(_szWorkingdir + Item.SubItems[1].Text);
                    mapFileInfo.Add(Item.SubItems[1].Text, info.LastWriteTime.ToString());
                }

            }


            //call external tools
            try
            {
                //process used to execute external commands
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.UseShellExecute = true;
                //startInfo.ErrorDialog = false;
                startInfo.FileName = szFileName;
                startInfo.WorkingDirectory = _szWorkingdir;
                //startInfo.LoadUserProfile = true;

                Process process = new Process();
                process.StartInfo = startInfo;
                //var process = Process.Start(startInfo);
                process.EnableRaisingEvents = true;
                process.Exited += ResolveProcessAbort;
                process.Start();
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }        
        private void m_CommitResolveMenuItem_Click(object sender, EventArgs e)
        {
            //Give a choice to select whether all merge should be committed
            if (_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false)
            {
                AfterResolve();
            }
            else
            {
                MessageBoxIcon icon = MessageBoxIcon.Question;
                MessageBox.Show(this, @"There's no conflict exist, you can't commit the Merge", "Warning", MessageBoxButtons.OK, icon);
            }
        }
        private void m_lvConflict_MouseClick(object sender, MouseEventArgs e)
        {
            m_lvConflict.GetItemAt(e.X, e.Y);
        }
        private void m_contextMenuConflict_Opening(object sender, CancelEventArgs e)
        {
            if(_OperStatus == ProcessStatus.PROCESS_START)
            {
                m_contextMenuConflict.Items[0].Enabled = false;
                m_contextMenuConflict.Items[1].Enabled = false;
                m_contextMenuConflict.Items[3].Enabled = false;
                m_contextMenuConflict.Items[4].Enabled = false;
                m_contextMenuConflict.Items[6].Enabled = false;
                m_contextMenuConflict.Items[7].Enabled = false;
                m_contextMenuConflict.Items[9].Enabled = false;
                return;
            }

            if (m_lvConflict.FocusedItem != null)
            {
                if (m_lvConflict.FocusedItem.Tag.ToString().Contains("DD") )
                {
                    //same
                    m_contextMenuConflict.Items[0].Enabled = false;
                    m_contextMenuConflict.Items[1].Enabled = false;
                    m_contextMenuConflict.Items[3].Enabled = true;
                    m_contextMenuConflict.Items[4].Enabled = false;
                    m_contextMenuConflict.Items[9].Enabled = true;
                    m_contextMenuConflict.Items[11].Enabled = true;
                    m_contextMenuConflict.Items[12].Enabled = true;
                    m_contextMenuConflict.Items[13].Enabled = true;
                }
                else if (m_lvConflict.FocusedItem.Tag.ToString().Contains("UU")|| m_lvConflict.FocusedItem.Tag.ToString().Contains("AA"))
                {
                    m_contextMenuConflict.Items[0].Enabled = true;
                    m_contextMenuConflict.Items[1].Enabled = true;
                    m_contextMenuConflict.Items[3].Enabled = false;
                    m_contextMenuConflict.Items[4].Enabled = false;
                    m_contextMenuConflict.Items[9].Enabled = true;
                    m_contextMenuConflict.Items[11].Enabled = true;
                    m_contextMenuConflict.Items[12].Enabled = true;
                    m_contextMenuConflict.Items[13].Enabled = true;
                }
                else if (m_lvConflict.FocusedItem.Tag.ToString().Contains("U"))
                {
                    //same
                    m_contextMenuConflict.Items[0].Enabled = false;
                    m_contextMenuConflict.Items[1].Enabled = false;
                    m_contextMenuConflict.Items[3].Enabled = true;
                    m_contextMenuConflict.Items[4].Enabled = true;
                    m_contextMenuConflict.Items[9].Enabled = true;
                    m_contextMenuConflict.Items[11].Enabled = true;
                    m_contextMenuConflict.Items[12].Enabled = true;
                    m_contextMenuConflict.Items[13].Enabled = true;
                }
                else
                {
                    m_contextMenuConflict.Items[0].Enabled = false;
                    m_contextMenuConflict.Items[1].Enabled = false;
                    m_contextMenuConflict.Items[3].Enabled = false;
                    m_contextMenuConflict.Items[4].Enabled = false;
                    m_contextMenuConflict.Items[9].Enabled = false;
                    m_contextMenuConflict.Items[11].Enabled = false;
                    m_contextMenuConflict.Items[12].Enabled = false;
                    m_contextMenuConflict.Items[13].Enabled = false;
                }
            }
            else
            {
                m_contextMenuConflict.Items[0].Enabled = false;
                m_contextMenuConflict.Items[1].Enabled = false;
                m_contextMenuConflict.Items[3].Enabled = false;
                m_contextMenuConflict.Items[4].Enabled = false;
                m_contextMenuConflict.Items[9].Enabled = false;
                m_contextMenuConflict.Items[11].Enabled = false;
                m_contextMenuConflict.Items[12].Enabled = false;
                m_contextMenuConflict.Items[13].Enabled = false;
            }

            if (_nMergeType == 1)            
            {
                m_contextMenuConflict.Items[6].Visible = false;
                m_contextMenuConflict.Items[7].Visible = false;
                m_contextMenuConflict.Items[8].Visible = false;
                //Give a choice to select whether all merge should be committed
                if (_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false && m_lvConflict.Items.Count > 1)
                {
                    m_contextMenuConflict.Items[6].Visible = true;
                    m_contextMenuConflict.Items[8].Visible = true;
                }
                else
                {
                    m_contextMenuConflict.Items[8].Visible = false;
                    m_contextMenuConflict.Items[6].Visible = false;
                }
            }
            else  if(_nMergeType == 2)//TODO...........................................
            {
                m_contextMenuConflict.Items[6].Visible = false;
                m_contextMenuConflict.Items[7].Visible = false;
                m_contextMenuConflict.Items[8].Visible = false;
                //Give a choice to select whether all merge should be committed
                if (_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false && m_lvConflict.Items.Count>1)
                {
                    m_contextMenuConflict.Items[7].Visible = true;
                    m_contextMenuConflict.Items[8].Visible = true;
                }
                else
                {
                    m_contextMenuConflict.Items[7].Visible = false;
                    m_contextMenuConflict.Items[8].Visible = false;
                }
            }
            else if (_nMergeType == 0)
            {
                m_contextMenuConflict.Items[6].Visible = false;
                m_contextMenuConflict.Items[7].Visible = false;
                m_contextMenuConflict.Items[8].Visible = false;
            }
            
        }
        private void m_ContinueRebaseMenuItem_Click(object sender, EventArgs e)
        {
            //Give a choice to select whether all merge should be committed
            if (_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false)
            {
                AfterResolve();
            }
            else
            {
                MessageBoxIcon icon = MessageBoxIcon.Question;
                MessageBox.Show(this, @"There's no conflict exist, you can't commit the Merge", "Warning", MessageBoxButtons.OK, icon);
            }
        }
        private void m_ExportFilesMenuItem_Click(object sender, EventArgs e)
        {
            var browseDialog = new FolderBrowserDialog();
            Button button = sender as Button;
            string szFileName = m_lvConflict.FocusedItem.SubItems[1].Text;  

            if (browseDialog.ShowDialog(this) == DialogResult.OK)
            {
                string szFolderPath= browseDialog.SelectedPath;
                ExportConflictFiles(szFolderPath, szFileName);               
            }

        } 
        private void ExportConflictFiles(string szFolderPath,string szTargetFile)
        {
            _objGitMgr._objGitMgrCore.SaveFileAs(":1:" + "\"" + szTargetFile + "\"", szFolderPath + @"\" + szTargetFile + ".father", _szWorkingdir);
            _objGitMgr._objGitMgrCore.SaveFileAs(":3:" + "\"" + szTargetFile + "\"", szFolderPath + @"\" + szTargetFile + ".other", _szWorkingdir);
            _objGitMgr._objGitMgrCore.SaveFileAs(":2:" + "\"" + szTargetFile + "\"", szFolderPath + @"\" + szTargetFile + ".self", _szWorkingdir);

            MessageBox.Show(this, "File has been saved successfully.", null);

        }
        private void m_UseMineMenuItem_Click(object sender, EventArgs e)
        {
            string szFileName = m_lvConflict.FocusedItem.SubItems[1].Text;  
            bool bIsSuccess= _objGitMgr._objGitMgrCore.CheckOutUnmergeFile(true,szFileName,_szWorkingdir);
            if(bIsSuccess==false)
            {
                MessageBox.Show(this, "Check Out Mine Source File Failed", null);
                ShowConflict();
                return;
            }

            _objGitMgr._objGitMgrCore.AddFile(szFileName, _szWorkingdir);
            //resolve conflict successfully
            ShowConflict();
        }
        private void m_UseTheirMenuItem_Click(object sender, EventArgs e)
        {
            string szFileName = m_lvConflict.FocusedItem.SubItems[1].Text;
            bool bIsSuccess = _objGitMgr._objGitMgrCore.CheckOutUnmergeFile(false, szFileName, _szWorkingdir);
            if (bIsSuccess == false)
            {
                MessageBox.Show(this, "Check Out Their Source File Failed", null);
                ShowConflict();
                return;
            }
            _objGitMgr._objGitMgrCore.AddFile(szFileName, _szWorkingdir);
            //resolve conflict successfully
            ShowConflict();
        }       
        private void m_UseCurrentMenuItem_Click(object sender, EventArgs e)
        {
            if (m_lvConflict.FocusedItem != null )
            {
                string szFileName = m_lvConflict.FocusedItem.SubItems[1].Text;
                _objGitMgr._objGitMgrCore.AddFile(szFileName, _szWorkingdir);
                //resolve conflict successfully
                ShowConflict();
            }
        }
        #endregion





    }
}
