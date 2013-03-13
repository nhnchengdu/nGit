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


namespace Git.UI
{
    public enum ProcessStatus
    {
        PROCESS_START = 80,
        PROCESS_PULL = 81, 
        PROCESS_MERGE = 82, 
        PROCESS_REBASE = 83, 
        ASYNC_NONE = 122
    }


    public partial class Form_Remote_PullBranch : CGitAsynchFomr
    {
        private CRemoteControl m_Parent;
        private string _szWorkingdir;
        private bool _bIsPulled;
        CGitManager _objGitMgr = null;
        private string _szTargetRemoteRepo;
        private string _szLocalBranch;
        private string _szRemoteBranch;
        private string _szRemoteURL;
        private string _szOldLocalSHA;
        //External tool notify the windows the operation has been finished
        public EventHandler ResolveProcessAbort;
        protected readonly SynchronizationContext syncResolveContext;
        Dictionary<string, string> mapFileInfo = new Dictionary<string, string>();

        private string _szOriginBranch;
        private bool _bIsStashed;
        private bool _bIsSwitchBranch;
        private ProcessStatus _OperStatus;

        #region Asynchron information from updating remote repository
        override protected void CallBackGitProcessExit(object sender, int code)
        {
            _objGitMgr._objGitMgrCore.Async_DataReceived_Event -= ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event -= ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event -= ProcessErrorData;
            _bIsRegGitEvent = false;
            m_barOperProgress.Value = 100;

            if (code == 0)//successful
            {
                _bIsPulled = true;
                m_txOperRes.ForeColor = Color.Green;
                m_txOperRes.AppendText("--------- Pull Remote repository to local branch Successfully ---------" + Environment.NewLine);

                //pop current process
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

                _OperStatus = ProcessStatus.PROCESS_START;
                m_btnRun.Enabled = true;
                m_btnCancel.Enabled = true;
                m_btnStop.Enabled = false;
                m_checkRebaseMode.Enabled = true;

                //show which file has been merged
                ShowSuccessCommitChange(); 

            }
            else
            {      
                //can't implement the merge operation, deal with conflict
                if (m_Parent.m_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir))
                {
                    m_txOperRes.ForeColor = Color.Red;
                    m_txOperRes.AppendText("------------ Pull Remote repository to local branch failed ------------" + Environment.NewLine);
                    ShowConflict();
                }
                else //failed
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

                    m_txOperRes.ForeColor = Color.Red;
                    m_txOperRes.AppendText("------------ Pull Remote repository to local branch failed ------------" + Environment.NewLine);

                    _OperStatus = ProcessStatus.PROCESS_START;
                    m_lvConflict.Items.Clear();
                    m_btnRun.Enabled = true;
                    m_btnCancel.Enabled = true;
                    m_btnStop.Enabled = false;
                    m_checkRebaseMode.Enabled = true;
                }
            }


        }
        override protected void CallBackGitProcessReceiveData(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
                return;
            m_txOperRes.AppendText(e.Data + Environment.NewLine);

            int iProgress = _objGitMgr._objGitMgrCore.ParsePushResult(e.Data);
            if (iProgress > m_barOperProgress.Value)
            {
                m_barOperProgress.Value = Math.Min(100, iProgress);
            }
        }
        override protected void CallBackGitProcessErrorData(object sender, DataReceivedEventArgs e)
        {
            //some useful information is gotten by error input stream,so strange. example:progress
            CallBackGitProcessReceiveData(sender, e);
        }
        #endregion

        #region window event function
        private void m_btnStop_Click(object sender, EventArgs e)
        {
            m_barOperProgress.Value = 0;
            _objGitMgr._objGitMgrCore.KillProcess();
            m_txOperRes.AppendText("The Clone operation is being canceling.......... ");
            m_txOperRes.AppendText(Environment.NewLine);

            m_btnRun.Enabled = true;
            m_btnCancel.Enabled = true;
            m_btnStop.Enabled = false;
            m_checkRebaseMode.Enabled = true;
        }
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsPulled)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void Form_Remote_PullBranch_Load(object sender, EventArgs e)
        {
            m_txLocalBranch.Text = _szLocalBranch;
            m_txPushURL.Text = _szRemoteURL;
            m_txRemoteName.Text = _szTargetRemoteRepo;
            m_txRemoteBranch.Text = _szRemoteBranch;
            m_lvConflict.Items.Clear();
            _OperStatus = ProcessStatus.PROCESS_START;

            if (m_barOperProgress.Style != ProgressBarStyle.Blocks)
                m_barOperProgress.Style = ProgressBarStyle.Blocks;
            m_barOperProgress.Value = 0;
        }
        private void m_btnRun_Click(object sender, EventArgs e)
        {
            m_barOperProgress.Value = 0;
            m_txOperRes.Clear();
            m_lvConflict.Items.Clear();
            if (string.IsNullOrEmpty(_szLocalBranch) || string.IsNullOrEmpty(_szRemoteURL)
                || string.IsNullOrEmpty(_szTargetRemoteRepo) || string.IsNullOrEmpty(_szRemoteBranch))
                return;

            m_btnRun.Enabled = false;
            m_btnCancel.Enabled = false;
            m_btnStop.Enabled = true;
            m_checkRebaseMode.Enabled = false;
            PullBranch();
        }
        #endregion   
    
        #region help inner function
        public void InitTarget(string szRemoteBranch,string szLocalBranch)
        {
            _szRemoteBranch = szRemoteBranch;
            _szLocalBranch = szLocalBranch;
            _szOldLocalSHA = m_Parent.m_objGitMgr._objGitMgrCore.GetHashIDFrom(_szLocalBranch, _szWorkingdir);
            //find all local branch without tracking
            foreach (string szItm in m_Parent.m_oRemoteInfo.m_mapAllRemotes.Keys)
            {
                if (_szRemoteBranch.StartsWith(szItm+"/"))
                {
                    _szTargetRemoteRepo = szItm;
                    if (m_Parent.m_oRemoteInfo.m_mapAllRemotes.ContainsKey(szItm))
                    {
                        string szURL = m_Parent.m_oRemoteInfo.m_mapAllRemotes[szItm];
                        string[] ResArray = szURL.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (ResArray.Length >= 2)
                        {
                            //_szRemoteURL = ResArray[0].Substring(7, ResArray[0].Length - 7);
                            _szRemoteURL = ResArray[1].Substring(6, ResArray[1].Length - 6);
                        }
                    }
                    break;
                }
            }

        }
        public Form_Remote_PullBranch(CRemoteControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRemoteControl;
            _objGitMgr = m_Parent.m_objGitMgr;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsPulled = false;

            _szTargetRemoteRepo = string.Empty;
            _szRemoteBranch = string.Empty;
            _szLocalBranch = string.Empty;
            _szRemoteURL = string.Empty;

            _bIsStashed = false;
            _bIsSwitchBranch = false;
            _szOriginBranch = Parent.m_oRemoteInfo.m_CurentBranch;

            ResolveProcessAbort = new EventHandler(ManualResolveProcessExit);
            syncResolveContext = SynchronizationContext.Current;
        }
        private void PullBranch()
        {
            _OperStatus = ProcessStatus.PROCESS_PULL;
            

            string szResInfo = string.Empty;
            //save current process
            if (m_Parent.m_objGitMgr._objGitMgrCore.ProcessSaveOnlyTracked(_szWorkingdir,out szResInfo))
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
            if (_szLocalBranch.Equals(_szOriginBranch) == false)
            {
                string szReturn = m_Parent.m_objGitMgr._objGitMgrCore.SwitchBranchTo(_szLocalBranch, _szWorkingdir);
                if (szReturn.StartsWith(@"Successful"))
                {
                    _bIsSwitchBranch = true;
                    m_txOperRes.AppendText(@"Successful:Switch Current Working Branch" + Environment.NewLine);
                }
            }




            m_txOperRes.AppendText("Start Pull branch from Remote Repository.....");
            m_txOperRes.AppendText(Environment.NewLine);

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
            _bIsRegGitEvent = true;

            string szRemoteSimpleBranch = _szRemoteBranch.Replace(_szTargetRemoteRepo + "/", string.Empty);

            bool bIsOk;
            if (m_checkRebaseMode.Checked == true)
            {
                bIsOk = _objGitMgr._objGitMgrCore.PullBranchAsynch(_szTargetRemoteRepo, szRemoteSimpleBranch, true, _szWorkingdir);

            }
            else
            {
                bIsOk=_objGitMgr._objGitMgrCore.PullBranchAsynch(_szTargetRemoteRepo, szRemoteSimpleBranch, false, _szWorkingdir);
            }
            if (false ==bIsOk )
            {
                _OperStatus = ProcessStatus.PROCESS_START;
                m_btnRun.Enabled = true;
                m_btnCancel.Enabled = true;
                m_btnStop.Enabled = false;
                m_checkRebaseMode.Enabled = true;

                //pop current process
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
            }   
        }
        #endregion
              
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
        //(step 4)
        private void AfterResolve()
        {
            //Give a choice to select whether all merge should be committed
            if (m_Parent.m_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false)
            {
                MessageBoxIcon icon = MessageBoxIcon.Question;
                var result = MessageBox.Show(this, @"All Conflicts have been resolved, will you commit them into repository?", "Warning", MessageBoxButtons.YesNo, icon);

                if (result == DialogResult.Yes)
                {
                    if(m_checkRebaseMode.Checked==false)
                    {
                        m_Parent.m_objGitMgr._objGitMgrCore.CommitAllStaged("Pull from Remote Repository", _szWorkingdir);
                        m_txOperRes.AppendText(@"Successful:Commit all resolved conflicts" + Environment.NewLine);
                    }
                    else
                    {
                        string szInfo = m_Parent.m_objGitMgr._objGitMgrCore.ContinueRebase(_szWorkingdir);
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

                
                _OperStatus = ProcessStatus.PROCESS_START;
                m_btnRun.Enabled = true;
                m_btnCancel.Enabled = true;
                m_btnStop.Enabled = false;
                m_checkRebaseMode.Enabled = true;

                //show which file has been merged
                ShowSuccessCommitChange();
            }
        }
        //GUI(step 1)
        private void ShowConflict()
        {

            if (m_checkRebaseMode.Checked == false)
            {
                _OperStatus = ProcessStatus.PROCESS_MERGE;
            }
            else
            {
                _OperStatus = ProcessStatus.PROCESS_REBASE;
            }

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
        //GUI(step 5)
        private void ShowSuccessCommitChange()
        {
            string szOldTargeSHA = _szOldLocalSHA;
            string szNewTargetSHA = m_Parent.m_objGitMgr._objGitMgrCore.GetHashIDFrom(_szRemoteBranch, _szWorkingdir);
            if (string.IsNullOrEmpty(szNewTargetSHA))
                return;
            if (szOldTargeSHA.Equals(szNewTargetSHA))
            {
                //this result is from fast-forward or update, no new commit
                return;
            }


            //update merge list
            string[] ChangeList = m_Parent.m_objGitMgr._objGitMgrCore.GetCommitChange(szOldTargeSHA, szNewTargetSHA, _szWorkingdir);
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
                return;
            }

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

            if(m_checkRebaseMode.Checked==false)            
            {
                m_contextMenuConflict.Items[6].Visible = true;
                m_contextMenuConflict.Items[7].Visible = false;
                //Give a choice to select whether all merge should be committed
                if (m_Parent.m_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false && _bIsSwitchBranch == true)
                {
                    m_contextMenuConflict.Items[6].Enabled = false;
                }
                else
                {
                    if (m_lvConflict.Items.Count > 0)
                        m_contextMenuConflict.Items[6].Enabled = true;
                    else
                        m_contextMenuConflict.Items[6].Enabled = false;
                }
            }
            else
            {
                m_contextMenuConflict.Items[6].Visible = false;
                m_contextMenuConflict.Items[7].Visible = true;
                //Give a choice to select whether all merge should be committed
                if (m_Parent.m_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false && _bIsSwitchBranch == true)
                {
                    m_contextMenuConflict.Items[7].Enabled = false;
                }
                else
                {
                    if (m_lvConflict.Items.Count > 0)
                        m_contextMenuConflict.Items[7].Enabled = true;
                    else
                        m_contextMenuConflict.Items[7].Enabled = false;
                }
            }
            
        }
        private void m_ContinueRebaseMenuItem_Click(object sender, EventArgs e)
        {
            //Give a choice to select whether all merge should be committed
            if (m_Parent.m_objGitMgr._objGitMgrCore.IsAnyUnMergeFile(_szWorkingdir) == false)
            {
                AfterResolve();
            }
            else
            {
                MessageBoxIcon icon = MessageBoxIcon.Question;
                MessageBox.Show(this, @"There's conflict exist, you can't commit the Merge", "Warning", MessageBoxButtons.OK, icon);
            }
        }
        #endregion



 





    }
}
