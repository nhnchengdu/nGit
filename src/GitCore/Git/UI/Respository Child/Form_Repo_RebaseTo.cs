using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

using System.Threading;
using System.IO;

namespace Git.UI
{
    public partial class Form_Repo_RebaseTo : Form
    {
        //External tool notify the windows the operation has been finished
        public EventHandler ProcessAbort;
        protected readonly SynchronizationContext syncContext;
        Dictionary<string, string> mapFileInfo = new Dictionary<string, string>();


        private CRepositoryControl m_Parent;
        private string _szTargetBranch;
        private string _szTargetSHA;
        private string _szSourceSHA;
        private string _szSourceBranch;
        private string _szWorkingdir;
        private bool _bIsRebased;

        private string _szOriginBranch;
        private bool _bIsStashed;
        private bool _bIsSwitchBranch;

        #region resovle conflict
        private void ManualResolveProcessExit(object sender, EventArgs e)
        {
            SendOrPostCallback AppCallback = p =>
            {
                AfterManualResolve(sender, e);
            };
            syncContext.Send(AppCallback, this);

        }
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

                        m_Parent.m_objGitMgr._objGitMgrCore.AddFile(szReFileName, _szWorkingdir);
                        mapFileInfo.Remove(szReFileName);
                        //resolve conflict successfully
                        ShowConflict();
                        m_txOperRes.AppendText(@"Successful:Add conflicts: " + szReFileName + Environment.NewLine);
                    }

                    break;
                }
            }
            AfterResolve();
        }
        private void AfterResolve()
        {
            //Give a choice to select whether all merge should be committed
            if (m_Parent.m_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false)
            {
                MessageBoxIcon icon = MessageBoxIcon.Question;
                var result = MessageBox.Show(this, @"All Conflicts have been resolved, will you commit them into repository?", "Warning", MessageBoxButtons.YesNo, icon);

                if (result == DialogResult.Yes)
                {
 
                    string szInfo= m_Parent.m_objGitMgr._objGitMgrCore.ContinueRebase( _szWorkingdir);
                    if (szInfo.StartsWith(@"Result"))
                    {
                        m_txOperRes.AppendText(@"Successful:Continue rebase after all resolved conflicts" + Environment.NewLine);
                    }
                    else
                    {
                        m_txOperRes.AppendText(@"Failed:Continue rebase after all resolved conflicts" + Environment.NewLine);
                        if (m_Parent.m_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir))
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
                else
                {
                    return;
                }

                if (_bIsSwitchBranch == true)
                {
                    m_Parent.m_objGitMgr._objGitMgrCore.SwitchBranchTo(_szOriginBranch, _szWorkingdir);
                    _bIsSwitchBranch = false;
                    m_txOperRes.AppendText(@"Successful:Restore Current Working branch" + Environment.NewLine);
                }

                if (_bIsStashed == true)
                {
                    m_Parent.m_objGitMgr._objGitMgrCore.ProcessPop(_szWorkingdir);
                    _bIsStashed = false;
                    m_txOperRes.AppendText(@"Successful:Restore Current Working Process" + Environment.NewLine);
                }


                //show which file has been merged
                ShowSuccessCommitChange();
            }
        }
        private void ShowSuccessCommitChange()
        {
            //update merge list
            string[] ChangeList = m_Parent.m_objGitMgr._objGitMgrCore.GetCommitChange(_szTargetBranch, _szSourceBranch, _szWorkingdir);
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
                item.SubItems.Add(@"Commited");
                m_lvConflict.Items.Add(item);
            }

            //append operation result
            m_txOperRes.ForeColor = Color.Green;
            m_txOperRes.AppendText(@"Rebase Successfully");
            m_btnRun.Enabled = true;
            m_btnCancel.Enabled = true;
        }
        private void ShowConflict()
        {
            Dictionary<string, string> mapConflicts;
            mapConflicts = m_Parent.m_objGitMgr._objGitMgrCore.GetConflictAndMerged(_szWorkingdir);
            if (mapConflicts == null || mapConflicts.Count <= 0)
            {
                //Debug.Assert(false);
                return;
            }


            //update conflict list
            m_lvConflict.Items.Clear();
            foreach (string szfileName in mapConflicts.Keys)
            {
                string szType = mapConflicts[szfileName];
                ListViewItem item = new ListViewItem(szType, 0);
                if (szType.Contains("M"))
                {
                    item.Tag = @"M";
                    item.BackColor = Color.AliceBlue;
                }
                else if (szType.Contains("UU"))
                {
                    item.Tag = @"U";
                    item.BackColor = Color.LightPink;
                }
                else if (szType.Contains("D"))
                {
                    item.Tag = @"D";
                    item.BackColor = Color.LightBlue;
                }
                else if (szType.Contains("A"))
                {
                    item.Tag = szType;
                    item.BackColor = Color.LightBlue;
                }
                else
                {
                    item.Tag = @"O";
                    item.BackColor = Color.DarkGray;
                }

                item.SubItems.Add(szfileName);

                item.SubItems.Add(@"Index");
                m_lvConflict.Items.Add(item);
            }

        }
        #endregion
        public Form_Repo_RebaseTo(CRepositoryControl Parent)
        {
            InitializeComponent();
            ProcessAbort = new EventHandler(ManualResolveProcessExit);
            m_Parent = Parent as CRepositoryControl;
            _szTargetSHA = string.Empty;
            _szTargetBranch = string.Empty;
            _szSourceSHA = string.Empty;
            _szSourceBranch=string.Empty;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsRebased = false;
            _bIsStashed = false;
            _bIsSwitchBranch = false;
            _szOriginBranch = Parent.m_oGitRepository.m_CurentBranch;
            syncContext = SynchronizationContext.Current;
        }
        public void InitTarget(string szTargetSHA, string szSourceSHA)
        {
            _szTargetSHA = szTargetSHA;
            _szSourceSHA = szSourceSHA;
        }

        private void Form_Repo_RebaseTo_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_szTargetSHA) || string.IsNullOrEmpty(_szSourceSHA))
                return;

            //initialize the commit information shown
            if (m_Parent.m_oGitRepository.m_mapAllCommites.ContainsKey(_szTargetSHA))
            {
                m_txSelectedSHA.Text = _szTargetSHA;
                m_txAuthor.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szAutrhorName;
                m_txDate.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szAutrhorDate;
                m_txMsg.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szCommitMessage;
            }
            if (m_Parent.m_oGitRepository.m_mapAllCommites.ContainsKey(_szSourceSHA))
            {
                m_txSrcSHA.Text = _szSourceSHA;
                m_txSrcAuthor.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szSourceSHA].szAutrhorName;
                m_txSrcDate.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szSourceSHA].szAutrhorDate;
                m_txSrcMsg.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szSourceSHA].szCommitMessage;
            }

            //initialize the branch list  shown
            m_cobBranchLists.Items.Clear();
            m_cobSrcBranchLists.Items.Clear();
            foreach (string szBranch in m_Parent.m_oGitRepository.m_mapLocalBranch.Keys)
            {
                string szSHA=m_Parent.m_oGitRepository.m_mapLocalBranch[szBranch];
                if (szSHA.Equals(_szTargetSHA))
                {
                    m_cobBranchLists.Items.Add(szBranch);
                }
                else if(szSHA.Equals(_szSourceSHA))
                {
                    m_cobSrcBranchLists.Items.Add(szBranch);
                }
            }
            if(m_cobBranchLists.Items.Count>0)
            {
                m_cobBranchLists.Text = m_cobBranchLists.Items[0].ToString();
            }
            if(m_cobSrcBranchLists.Items.Count>0)
            {
                m_cobSrcBranchLists.Text = m_cobSrcBranchLists.Items[0].ToString();
            }


            //show unresolved conflict
            if (m_Parent.m_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir))
            {
                m_btnRun.Enabled = false; ;
                m_btnCancel.Enabled = false;
                ShowConflict();
            }
            else
            {
                ShowConflict();
            }


        }

        private void m_btnRun_Click(object sender, EventArgs e)
        {
            //tell initialized condition
            if (string.IsNullOrEmpty(m_cobSrcBranchLists.Text))
            {
                MessageBox.Show(this, @"Please select a Source branch.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (string.IsNullOrEmpty(m_cobBranchLists.Text))
            {
                MessageBox.Show(this, @"Please select a target branch.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            _szTargetBranch = m_cobBranchLists.Text;
            _szSourceBranch=m_cobSrcBranchLists.Text;

            if (m_lvConflict.Items.Count>0)
            {
                MessageBoxIcon icon = MessageBoxIcon.Question;
                var result = MessageBox.Show(this, "Some work in index area, will you stash them and continue?", "Warning", MessageBoxButtons.YesNo, icon);
                if (result == DialogResult.No)
                {
                    return;
                }  
            }
                        
            string szResInfo = string.Empty;
            //save current process
            if (m_Parent.m_objGitMgr._objGitMgrCore.ProcessSaveOnlyTracked(_szWorkingdir, out szResInfo))
            {
                _bIsStashed = true;
                m_txOperRes.AppendText(@"Successful:Save Current Working Process" + Environment.NewLine);
            }
            else
            {
                m_txOperRes.AppendText(@"Failed:Save Current Working Process" + Environment.NewLine);
                return;
            }

            //Switch Branch if target branch is not same as current working branch
            if (_szTargetBranch.Equals(_szOriginBranch) == false)
            {
                string szReturn = m_Parent.m_objGitMgr._objGitMgrCore.SwitchBranchTo(_szTargetBranch, _szWorkingdir);
                if (szReturn.StartsWith(@"Successful"))
                {
                    _bIsSwitchBranch = true;
                    m_txOperRes.AppendText(@"Successful:Switch Current Working Branch" + Environment.NewLine);
                }
            }

            //Implement rebase Operation
            string szRs = m_Parent.m_objGitMgr._objGitMgrCore.RebaseBranchTo(m_cobBranchLists.Text, m_cobSrcBranchLists.Text, _szWorkingdir);
            if (szRs.StartsWith(@"Result"))
            {
                m_txOperRes.ForeColor = Color.Green;
                _bIsRebased = true;
                m_txOperRes.AppendText(string.Format("Successful:Reset commit<{0}> to Branch<{1}> ", _szSourceSHA, _szTargetBranch) + Environment.NewLine);
                m_txOperRes.AppendText(szRs + Environment.NewLine);
            }
            else
            {
                m_txOperRes.ForeColor = Color.Red;
                m_txOperRes.AppendText(string.Format("Failed:Reset commit<{0}> to Branch<{1}> ", _szSourceSHA, _szTargetBranch) + Environment.NewLine);
                m_txOperRes.AppendText(szRs + Environment.NewLine);
            }
            m_btnRun.Enabled = false;
            m_btnCancel.Enabled = false;


            //=============================
            //restore the stashed process and working branch
            if (szRs.StartsWith(@"Result"))
            {
                if (_bIsSwitchBranch == true)
                {
                    m_Parent.m_objGitMgr._objGitMgrCore.SwitchBranchTo(_szOriginBranch, _szWorkingdir);
                    _bIsSwitchBranch = false;
                    m_txOperRes.AppendText(@"Successful:Restore Current Working branch" + Environment.NewLine);
                }

                if (_bIsStashed == true)
                {
                    m_Parent.m_objGitMgr._objGitMgrCore.ProcessPop(_szWorkingdir);
                    _bIsStashed = false;
                    m_txOperRes.AppendText(@"Successful:Restore Current Working Process" + Environment.NewLine);
                }
                //show which file has been merged
                ShowSuccessCommitChange();
            }
            else
            {
                //can't implement the merge operation, deal with conflict
                if (m_Parent.m_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir))
                {
                    ShowConflict();
                }
                else
                {
                    //can't implement the merge operation, deal with error 
                    if (_bIsSwitchBranch == true)
                    {
                        m_Parent.m_objGitMgr._objGitMgrCore.SwitchBranchTo(_szOriginBranch, _szWorkingdir);
                        _bIsSwitchBranch = false;
                        m_txOperRes.AppendText(@"Successful:Restore Current Working branch" + Environment.NewLine);
                    }

                    if (_bIsStashed == true)
                    {
                        m_Parent.m_objGitMgr._objGitMgrCore.ProcessPop(_szWorkingdir);
                        _bIsStashed = false;
                        m_txOperRes.AppendText(@"Successful:Restore Current Working Process" + Environment.NewLine);
                    }

                    m_lvConflict.Items.Clear();
                    m_txOperRes.AppendText(@"Reset failed");
                    m_btnRun.Enabled = true;
                    m_btnCancel.Enabled = true;
                }

            }
            //==============================
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsRebased)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void m_contextMenuConflict_Opening(object sender, CancelEventArgs e)
        {
            if (m_lvConflict.FocusedItem != null)
            {
                if (m_lvConflict.FocusedItem.Tag.ToString().Contains("D") || m_lvConflict.FocusedItem.Tag.ToString().Contains("A"))
                {
                    m_contextMenuConflict.Items[0].Enabled = false;
                    m_contextMenuConflict.Items[1].Enabled = false;
                    m_contextMenuConflict.Items[3].Enabled = true;
                    m_contextMenuConflict.Items[4].Enabled = true;
                }
                else if (m_lvConflict.FocusedItem.Tag.ToString().Equals("U"))
                {
                    m_contextMenuConflict.Items[0].Enabled = true;
                    m_contextMenuConflict.Items[1].Enabled = true;
                    m_contextMenuConflict.Items[3].Enabled = false;
                    m_contextMenuConflict.Items[4].Enabled = false;
                }
                else
                {
                    m_contextMenuConflict.Items[0].Enabled = false;
                    m_contextMenuConflict.Items[1].Enabled = false;
                    m_contextMenuConflict.Items[3].Enabled = false;
                    m_contextMenuConflict.Items[4].Enabled = false;
                }
            }
            else
            {
                m_contextMenuConflict.Items[0].Enabled = false;
                m_contextMenuConflict.Items[1].Enabled = false;
                m_contextMenuConflict.Items[3].Enabled = false;
                m_contextMenuConflict.Items[4].Enabled = false;
            }

            //Give a choice to select whether all merge should be committed
            if (m_Parent.m_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false && _bIsSwitchBranch == true)
            {
                m_contextMenuConflict.Items[6].Enabled = false;
            }
            else
            {
                if (m_lvConflict.Items.Count>0)
                    m_contextMenuConflict.Items[6].Enabled = true;
                else
                    m_contextMenuConflict.Items[6].Enabled = false;
            }
        }
        private void m_MergeToolMenuItem_Click(object sender, EventArgs e)
        {
            //Give a choice to select whether all merge should be committed
            //if (m_lvConflict.FocusedItem != null)
            if (m_lvConflict.FocusedItem != null && m_lvConflict.FocusedItem.Tag.ToString().Equals("U"))
            {
                string szFileName = m_lvConflict.FocusedItem.SubItems[1].Text;
                string szRes = m_Parent.m_objGitMgr._objGitMgrCore.MergeOneFile(szFileName, _szWorkingdir);
                if (string.IsNullOrEmpty(szRes))
                {
                    //resolve conflict successfully
                    ShowConflict();
                    m_txOperRes.AppendText(@"Successful:Resolved conflicts: " + szFileName + Environment.NewLine);
                }
            }

            AfterResolve();
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

                m_Parent.m_objGitMgr._objGitMgrCore.Delete(_szWorkingdir, lstFiles, false);
                //resolve conflict successfully
                ShowConflict();
                m_txOperRes.AppendText(@"Successful:Remove conflicts: " + szFileName + Environment.NewLine);
            }

            AfterResolve();
        }
        private void m_AddConflictMenuItem_Click(object sender, EventArgs e)
        {
            if (m_lvConflict.FocusedItem != null &&
                     (m_lvConflict.FocusedItem.Tag.ToString().Contains("D") || m_lvConflict.FocusedItem.Tag.ToString().Contains("A")))
            {
                string szFileName = m_lvConflict.FocusedItem.SubItems[1].Text;
                m_Parent.m_objGitMgr._objGitMgrCore.AddFile(szFileName, _szWorkingdir);
                //resolve conflict successfully
                ShowConflict();
                m_txOperRes.AppendText(@"Successful:Add conflicts: " + szFileName + Environment.NewLine);
            }

            AfterResolve();
        }                       
        private void m_CommitResolveMenuItem_Click(object sender, EventArgs e)
        {
            //Give a choice to select whether all merge should be committed
            if (m_Parent.m_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false)
            {
                AfterResolve();
            }
            else
            {
                MessageBoxIcon icon = MessageBoxIcon.Question;
                MessageBox.Show(this, @"There's conflict exist, you can't continue the rebse operation", "Warning", MessageBoxButtons.OK, icon);
            }
        }
        private void m_ManualResolveMenuItem_Click(object sender, EventArgs e)
        {
            string szFileName = string.Empty;
            if (m_lvConflict.FocusedItem != null && m_lvConflict.FocusedItem.Tag.ToString().Equals("U"))
            {
                szFileName = m_lvConflict.FocusedItem.SubItems[1].Text;
            }
            if (string.IsNullOrEmpty(szFileName))
                return;

            //save file info for detecting file change
            mapFileInfo.Clear();
            foreach (ListViewItem Item in m_lvConflict.Items)
            {
                if (Item.Tag.ToString().Equals("U"))
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
                process.Exited += ProcessAbort;
                process.Start();
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException(ex.ToString());
            }  
        }



       



//function

    }
}
