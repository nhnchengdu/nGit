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
using Git.Repository;
using Nhn.Git.Core.Properties;

namespace Git.UI
{
    public partial class FormPush : CGitAsynchFomr
    {
        CGitManager _objGitMgr = null;
        private string _szLocalBranch;
        private string _szWorkingdir;
        private bool _bIsUpLoaded;

        public Dictionary<string, string> m_mapAllRemotes; //<remote, fetch/push>
        public string[] m_RemoteBranchArray;
        public string m_szTrackingRemote;
        public string m_szTrackingRemoteBranch;

        //image
        private ImageList GitImageList;


        #region Asynchron information from updating remote repository
        override protected void CallBackGitProcessExit(object sender, int code)
        {
            //
            if (code == 0)
            {
                _bIsUpLoaded = true;
                m_txOperRes.ForeColor = Color.Green;
                m_txOperRes.AppendText("--------- Push local branch to Remote repository Successfully ---------" + Environment.NewLine);

            }
            else
            {
                m_txOperRes.ForeColor = Color.Red;
                m_txOperRes.AppendText("------------ Push local branch to Remote repository failed ------------" + Environment.NewLine);
            }

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event -= ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event -= ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event -= ProcessErrorData;
            _bIsRegGitEvent = false;
            m_barOperProgress.Value = 100;

            m_btnRun.Enabled = true;
            m_btnCancel.Enabled = true;
            m_btnStop.Enabled = false;
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


        #region help inner function
        public FormPush(CGitManager objGitMgr, string szWorkingdir, string LocalBranch)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szWorkingdir = CHelpFuntions.GetValidWorkingDir(szWorkingdir);
            _szLocalBranch=LocalBranch;
            _bIsUpLoaded = false;
        }
        private void PushBranch()
        {
            m_txOperRes.AppendText("Start Push branch to Remote Repository.....");
            m_txOperRes.AppendText(Environment.NewLine);

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
            _bIsRegGitEvent = true;

            string szRemoteSimpleBranch = m_cobRemoteBranchLists.Text.Replace(m_cobRemoteRepoLists.Text + "/", string.Empty);

            if (m_checkForcePush.Checked == true)
            {
                if (false == _objGitMgr._objGitMgrCore.Commit2SpecBranch(m_cobRemoteRepoLists.Text, _szLocalBranch, szRemoteSimpleBranch, true, _szWorkingdir))
                {
                    m_btnRun.Enabled = true;
                    m_btnCancel.Enabled = true;
                    m_btnStop.Enabled = false;
                }
            }
            else
            {
                if (false == _objGitMgr._objGitMgrCore.Commit2SpecBranch(m_cobRemoteRepoLists.Text, _szLocalBranch, szRemoteSimpleBranch, false, _szWorkingdir))
                {
                    m_btnRun.Enabled = true;
                    m_btnCancel.Enabled = true;
                    m_btnStop.Enabled = false;
                }
            }


        }
        private void ShowPushContent()
        {
            //initialize
            m_lvBranchCommit.Items.Clear();
            m_lvChangeFiles.Items.Clear();
            string szLocalBr = _szLocalBranch;
            string szRemoteBr = m_cobRemoteBranchLists.Text;
            string szLocalBrSHA = _objGitMgr._objGitMgrCore.GetHashIDFrom(szLocalBr, _szWorkingdir);
            string szRemoteBrSHA = _objGitMgr._objGitMgrCore.GetHashIDFrom(szRemoteBr, _szWorkingdir);
            if (string.IsNullOrEmpty(szRemoteBrSHA) || string.IsNullOrEmpty(szLocalBrSHA))
            {
                return;
            }

            //show related information
            CommiteInfoItemSimple oRemoteBrInfo;
            CommiteInfoItemSimple olocalBrInfo;

            oRemoteBrInfo = _objGitMgr._objGitMgrCore.GetSpecCommitItem(szRemoteBrSHA, _szWorkingdir)[szRemoteBrSHA];
            olocalBrInfo = _objGitMgr._objGitMgrCore.GetSpecCommitItem(szLocalBrSHA, _szWorkingdir)[szLocalBrSHA];



            //there's not any change;
            if (szLocalBrSHA.Equals(szRemoteBrSHA))
            {
                ListViewItem ReItem;
                ReItem = new ListViewItem(szRemoteBrSHA.Substring(0, 6), 4);
                ReItem.BackColor = Color.Purple;

                ReItem.Tag = szRemoteBrSHA;
                ReItem.ToolTipText = "Base Point";
                ReItem.SubItems.Add(olocalBrInfo.szCommitMessage);
                ReItem.SubItems.Add(olocalBrInfo.szAutrhorName);
                ReItem.SubItems.Add(olocalBrInfo.szCommitDate);
                m_lvBranchCommit.Items.Add(ReItem);
                return;
            }

            //local and remote branches are from different ancestor commits.
            string szBaseSHA = _objGitMgr._objGitMgrCore.GetLastAncestorCommit(szLocalBrSHA, szRemoteBrSHA, _szWorkingdir);
            if (string.IsNullOrEmpty(szBaseSHA)) //error
            {
                m_lvBranchCommit.Items.Clear();
                return;
            }
            
            //local branch is child from remote branch
            if (szBaseSHA.Equals(szRemoteBrSHA))
            {
                m_lvBranchCommit.Items.Clear();
                Dictionary<string, CommiteInfoItemSimple> ExcludeItems;
                ExcludeItems = _objGitMgr._objGitMgrCore.GetExcludeItmsFromFathrer(szBaseSHA, szLocalBr, _szWorkingdir);
                foreach (string szItem in ExcludeItems.Keys)
                {
                    ListViewItem item;
                    item = new ListViewItem(szItem.Substring(0, 6), 0);
                    item.BackColor = Color.PaleGreen;

                    item.Tag = szItem;
                    item.ToolTipText = "Local Working";
                    item.SubItems.Add(ExcludeItems[szItem].szCommitMessage);
                    item.SubItems.Add(ExcludeItems[szItem].szAutrhorName);
                    item.SubItems.Add(ExcludeItems[szItem].szCommitDate);
                    m_lvBranchCommit.Items.Add(item);
                }
            }
            //local branch is father of remote branch
            else if (szBaseSHA.Equals(szLocalBrSHA))
            {
                m_lvBranchCommit.Items.Clear();
                Dictionary<string, CommiteInfoItemSimple> ExcludeItems;
                ExcludeItems = _objGitMgr._objGitMgrCore.GetExcludeItmsFromFathrer(szBaseSHA, szRemoteBrSHA, _szWorkingdir);
                foreach (string szItem in ExcludeItems.Keys)
                {
                    ListViewItem item;
                    item = new ListViewItem(szItem.Substring(0, 6), 0);
                    item.BackColor = Color.OrangeRed;

                    item.Tag = szItem;
                    item.ToolTipText = "Remote Working";
                    item.SubItems.Add(ExcludeItems[szItem].szCommitMessage);
                    item.SubItems.Add(ExcludeItems[szItem].szAutrhorName);
                    item.SubItems.Add(ExcludeItems[szItem].szCommitDate);
                    m_lvBranchCommit.Items.Add(item);
                }
            }
            //two divided branches from same father            
            else 
            {
                m_lvBranchCommit.Items.Clear();
                Dictionary<string, CommiteInfoItemSimple> ExcludeItems;
                ExcludeItems = _objGitMgr._objGitMgrCore.GetExcludeItmsFromFathrer(szBaseSHA, szLocalBr, _szWorkingdir);
                foreach (string szItem in ExcludeItems.Keys)
                {
                    ListViewItem item;
                    item = new ListViewItem(szItem.Substring(0, 6), 0);
                    item.BackColor = Color.PaleGreen;

                    item.Tag = szItem;
                    item.ToolTipText = "Local Working";
                    item.SubItems.Add(ExcludeItems[szItem].szCommitMessage);
                    item.SubItems.Add(ExcludeItems[szItem].szAutrhorName);
                    item.SubItems.Add(ExcludeItems[szItem].szCommitDate);
                    m_lvBranchCommit.Items.Add(item);
                }


                ExcludeItems.Clear();
                ExcludeItems = _objGitMgr._objGitMgrCore.GetExcludeItmsFromFathrer(szBaseSHA, szRemoteBrSHA, _szWorkingdir);
                foreach (string szItem in ExcludeItems.Keys)
                {
                    ListViewItem item;
                    item = new ListViewItem(szItem.Substring(0, 6), 0);
                    item.BackColor = Color.OrangeRed;

                    item.Tag = szItem;
                    item.ToolTipText = "Remote Working";
                    item.SubItems.Add(ExcludeItems[szItem].szCommitMessage);
                    item.SubItems.Add(ExcludeItems[szItem].szAutrhorName);
                    item.SubItems.Add(ExcludeItems[szItem].szCommitDate);
                    m_lvBranchCommit.Items.Add(item);
                }

            }

            //Add base ancestor commit
            CommiteInfoItemSimple sBaseContent;
            sBaseContent = _objGitMgr._objGitMgrCore.GetSpecCommitItem(szBaseSHA, _szWorkingdir)[szBaseSHA];
            ListViewItem BaseItem;
            BaseItem = new ListViewItem(szBaseSHA.Substring(0, 6), 4);
            BaseItem.BackColor = Color.Purple;

            BaseItem.Tag = szBaseSHA;
            BaseItem.SubItems.Add(sBaseContent.szCommitMessage);
            BaseItem.SubItems.Add(sBaseContent.szAutrhorName);
            BaseItem.SubItems.Add(sBaseContent.szCommitDate);
            m_lvBranchCommit.Items.Add(BaseItem);
        }
        private void LoadImage()
        {
            GitImageList = new ImageList(); 
            GitImageList.TransparentColor = System.Drawing.Color.White;
            GitImageList.ImageSize = new System.Drawing.Size(10, 13);

            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Father)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Child)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Tag)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Branch1)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_A)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_C)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_D)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_M)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_R)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_T)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_U)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_X)));
            m_lvChangeFiles.SmallImageList = GitImageList;
        }
        private void UpdateFileChanged(string szSHA)
        {
            if(string.IsNullOrEmpty(szSHA))
            {
                m_lvChangeFiles.Items.Clear();
                return;
            }
            string[] ChangeList = _objGitMgr._objGitMgrCore.GetCommitChange(szSHA, szSHA + @"^1", _szWorkingdir);
            
            //there's no change
            if (ChangeList == null)
            {
                m_lvChangeFiles.Items.Clear();
                return;
            }

            int i = 0;
            m_lvChangeFiles.Items.Clear();
            foreach (string szChangeItem in ChangeList)
            {
                ListViewItem item;
                string[] ResArray = szChangeItem.Split(new[] { '\r', '\n', '\t','\0' }, StringSplitOptions.RemoveEmptyEntries);
                if (szChangeItem.StartsWith("A"))
                {
                    item = new ListViewItem(ResArray[1], 4);
                }
                else if (szChangeItem.StartsWith("C"))
                {
                    item = new ListViewItem(ResArray[1], 5);
                }
                else if (szChangeItem.StartsWith("D"))
                {
                    item = new ListViewItem(ResArray[1], 6);
                }
                else if (szChangeItem.StartsWith("M"))
                {
                    item = new ListViewItem(ResArray[1], 7);
                }
                else if (szChangeItem.StartsWith("R"))
                {
                    item = new ListViewItem(ResArray[1], 8);
                    item = new ListViewItem(ResArray[1] + "-->" + ResArray[2], 8);
                }
                else if (szChangeItem.StartsWith("T"))
                {
                    item = new ListViewItem(ResArray[1], 9);
                }
                else if (szChangeItem.StartsWith("U"))
                {
                    item = new ListViewItem(ResArray[1], 10);
                }
                else
                {
                    item = new ListViewItem(szChangeItem, 11);
                }
                item.Tag = szChangeItem;

                if ((i++ % 2) == 1)
                    item.BackColor = Color.AliceBlue;
                else
                    item.BackColor = Color.AntiqueWhite;

                item.ToolTipText = item.Text;
                m_lvChangeFiles.Items.Add(item);
            }
            if (m_lvChangeFiles.Items.Count > 0)
            {
                m_lvChangeFiles.Focus();
                m_lvChangeFiles.Items[0].Focused = true;
                m_lvChangeFiles.Items[0].Selected = true;
                m_lvChangeFiles.EnsureVisible(0);
            }

        }
        #endregion

        #region window event function 1
        private void m_btnStop_Click(object sender, EventArgs e)
        {
            m_barOperProgress.Value = 0;
            _objGitMgr._objGitMgrCore.KillProcess();
            m_txOperRes.AppendText("The Clone operation is being canceling.......... ");
            m_txOperRes.AppendText(Environment.NewLine);
            m_btnStop.Enabled = false;
        }
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsUpLoaded)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void m_btnRun_Click(object sender, EventArgs e)
        {
            m_barOperProgress.Value = 0;
            m_txOperRes.Clear();
            if (string.IsNullOrEmpty(_szLocalBranch)
                || string.IsNullOrEmpty(m_cobRemoteBranchLists.Text) || string.IsNullOrEmpty(m_cobRemoteRepoLists.Text))
                return;

            m_btnRun.Enabled = false;
            m_btnCancel.Enabled = false;
            m_btnStop.Enabled = true;
            PushBranch();
        }
        #endregion  

        #region window event function 2
        private void FormPush_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_szWorkingdir))
                return;
            if (string.IsNullOrEmpty(_szLocalBranch))
                return;

            LoadImage();
            m_lvBranchCommit.Items.Clear();
            m_lvChangeFiles.Items.Clear();
            m_txLocalBranch.Text = _szLocalBranch;

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
            if (string.IsNullOrEmpty(m_cobRemoteRepoLists.Text)
                || m_mapAllRemotes.ContainsKey(m_cobRemoteRepoLists.Text) == false)
            {
                return;
            }

            m_txPullURL.Text = m_mapAllRemotes[m_cobRemoteRepoLists.Text];

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

            if (string.IsNullOrEmpty(m_szTrackingRemoteBranch))
                m_picShowTracking.Visible = false;

            //ready for external tools for resolve conflicts   
            if (m_barOperProgress.Style != ProgressBarStyle.Blocks)
                m_barOperProgress.Style = ProgressBarStyle.Blocks;
            m_barOperProgress.Value = 0;
        }
        private void m_cobRemoteBranchLists_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_szTrackingRemoteBranch))
            {
                m_picShowTracking.Visible = false;
            }
            else if (string.IsNullOrEmpty(m_cobRemoteBranchLists.Text))
            {
                m_picShowTracking.Visible = false;
                m_btnRun.Enabled = false;

            }
            else if (m_szTrackingRemoteBranch != m_cobRemoteBranchLists.Text)
            {
                m_picShowTracking.Visible = false;
                m_btnRun.Enabled = true;
            }
            else
            {
                m_picShowTracking.Visible = true;
                m_btnRun.Enabled = true;
            }

            if (m_cobRemoteBranchLists.Items.Count == 0 || m_cobRemoteBranchLists.Items.Contains(m_cobRemoteBranchLists.Text) == false)
            {
                m_lvBranchCommit.Items.Clear();
                m_lvChangeFiles.Items.Clear();
                return;
            }
            else
                ShowPushContent();
        }
        private void m_cobRemoteBranchLists_TextUpdate(object sender, EventArgs e)
        {

        }
        private void m_cobRemoteRepoLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_RemoteBranchArray != null && m_RemoteBranchArray.Length > 0)
            {
                m_cobRemoteBranchLists.Text = null;
                m_cobRemoteBranchLists.Items.Clear();
                foreach (string szTmp in m_RemoteBranchArray)
                {
                    if (szTmp.Contains(m_szTrackingRemote+@"/"))
                        m_cobRemoteBranchLists.Items.Add(szTmp);
                    else
                        continue;
                }
            }
            //m_cobRemoteBranchLists.Text = m_szTrackingRemoteBranch;
            m_txPullURL.Text = m_mapAllRemotes[m_cobRemoteRepoLists.Text];
        }
        private void m_lvBranchCommit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_lvBranchCommit.SelectedItems.Count == 1)
            {
                string szSHA = m_lvBranchCommit.SelectedItems[0].Tag.ToString();
                UpdateFileChanged(szSHA);

            }

        }
        #endregion   

        private void m_btnStop_Click_1(object sender, EventArgs e)
        {

        }



    }
}
