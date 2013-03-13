using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Collections;
using Nhn.Git.Core;
using Git.Repository;

using System.Diagnostics;
using System.Threading;
using Git.Core.Helper;
using Nhn.Git.Core.Properties;



namespace Git.UI
{
    public partial class CRemoteControl : CGitAsynchControl
    {
        //remote information object
        public CGitRemoteInfo m_oRemoteInfo;
        private ImageList GitImageList; //main
        private ImageList GitImageList2; //commit info
        /// <summary>
        /// initialize constructor
        /// </summary>
        public CRemoteControl()
        {
            InitializeComponent();
            m_oRemoteInfo = new CGitRemoteInfo();
        }

        /// <summary>
        /// this function will be called when dialog is loaded first
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CRemoteControl_Load(object sender, EventArgs e)
        {
            m_tvLocalBranch.Nodes.Clear();
            m_tvRemoteRepo.Nodes.Clear();
            m_lvChangeFiles.Items.Clear();
            //Load image from resource
            LoadImage();
            //m_BackGround.RunWorkerAsync(100);


            //tell whether the working dir is valid
            if (string.IsNullOrEmpty(_szWorkingDir))
            {
                m_oRemoteInfo.m_szWorkingDir = null;
                m_oRemoteInfo.m_bIsValid = false;
                return;
            }

            //tell whether the working dir is valid for git
            if (!_objGitMgr._objGitMgrCore.IsValidGitWorkingDir(_szWorkingDir))
            {
                m_oRemoteInfo.m_szWorkingDir = _szWorkingDir;
                m_oRemoteInfo.m_bIsValid = false;
                return;
            }

            //load information and show it.
            AysncRunLocalOpera3(InitializeAndShow);

            //data initizlize
            m_oRemoteInfo.m_szWorkingDir = _szWorkingDir;
            m_oRemoteInfo.m_bIsValid = true;


        }
        
        private void InitializeAndShow()
        {
            //load all remote information and related information form Git repository
            LoadAllData();

            //Refresh GUI according to remote information
            RefreshGUI();

            //close waiting dialog
            HideWaiting();
        }

        #region Load Data========================================================================================

        /// <summary>
        /// load all remote information and related information form Git repository
        /// </summary>
        private void LoadAllData()
        {
            //get all branch including remote and local
            GetALLBranches();
            //get all tags
            GetALLTags();
            //get all remote repository and related information
            GetAllRemoteRepo();
            //get all tracking information
            GetTrackingInfo();
        }

        /// <summary>
        /// get all branch including remote and local
        /// </summary>        
        private void GetALLBranches()
        {
            //initialize
            string[] BranchArray;
            string szHashId = null;
            m_oRemoteInfo.m_mapLocalBranch.Clear();
            m_oRemoteInfo.m_mapRemoteBranch.Clear();


            //load local branch
            BranchArray = _objGitMgr._objGitMgrCore.GetBranch(false, _szWorkingDir);
            if (BranchArray != null && BranchArray.Length > 0)
            {
                //initialize local branch storage
                m_oRemoteInfo.m_CurentBranch = BranchArray[0];

                //first node, current branch
                if (!string.IsNullOrEmpty(BranchArray[0]))
                {
                    szHashId = _objGitMgr._objGitMgrCore.GetHashIDFrom(BranchArray[0], _szWorkingDir);
                    m_oRemoteInfo.m_mapLocalBranch.Add(BranchArray[0], szHashId);

                }

                //other local branch 
                for (int i = 1; i < BranchArray.Length; i++)
                {
                    szHashId = _objGitMgr._objGitMgrCore.GetHashIDFrom(BranchArray[i], _szWorkingDir);
                    m_oRemoteInfo.m_mapLocalBranch.Add(BranchArray[i], szHashId);
                }
            }


            //load remote branch
            string[] RemoteBranchArray;
            RemoteBranchArray = _objGitMgr._objGitMgrCore.GetBranch(true, _szWorkingDir);
            if (RemoteBranchArray != null && RemoteBranchArray.Length > 0)
            {
                for (int i = 0; i < RemoteBranchArray.Length; i++)
                {
                    szHashId = _objGitMgr._objGitMgrCore.GetHashIDFrom(RemoteBranchArray[i], _szWorkingDir);
                    m_oRemoteInfo.m_mapRemoteBranch.Add(RemoteBranchArray[i], szHashId);
                }
            }
        }

        /// <summary>
        /// get all tags
        /// </summary>
        private void GetALLTags()
        {
            string[] TagArray = _objGitMgr._objGitMgrCore.GetTag(_szWorkingDir);
            m_oRemoteInfo.m_mapTag.Clear();

            string szHashId = null;
            if (TagArray != null && TagArray.Length > 0)
            {
                for (int i = 0; i < TagArray.Length; i++)
                {
                    szHashId = _objGitMgr._objGitMgrCore.GetHashIDFrom(TagArray[i], _szWorkingDir);
                    m_oRemoteInfo.m_mapTag.Add(TagArray[i], szHashId);
                }
            }
        }

        /// <summary>
        /// get all remote repository and related information
        /// </summary>
        private void GetAllRemoteRepo()
        {
            m_oRemoteInfo.m_mapAllRemotes.Clear();
            if (null == _objGitMgr._objGitMgrCore.GetAllRemoteRepo(_szWorkingDir))
            {
                m_oRemoteInfo.m_mapAllRemotes.Clear();
            }
            else
            {
                m_oRemoteInfo.m_mapAllRemotes = _objGitMgr._objGitMgrCore.GetAllRemoteRepo(_szWorkingDir);
                //这儿可能有内存泄露， 应该copy过去
            }

        }

        /// <summary>
        /// get all tracking information
        /// </summary>
        private void GetTrackingInfo()
        {            
            //this is ignored now, maybe it will be added later.
            if (m_oRemoteInfo.m_mapAllTracking != null)
            {
                m_oRemoteInfo.m_mapAllTracking.Clear();
                m_oRemoteInfo.m_mapAllTracking = _objGitMgr._objGitMgrCore.GetAllTracking(m_oRemoteInfo.m_mapLocalBranch, _szWorkingDir);
            }
        }
        #endregion

        #region GUI Shown========================================================================================

        /// <summary>
        /// load image resouce
        /// </summary>
        private void LoadImage()
        {
            //main
            GitImageList = new ImageList();
            GitImageList.TransparentColor = System.Drawing.Color.White;
            GitImageList.ImageSize = new System.Drawing.Size(14, 14);
            //GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Branch)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Branch1)));
            //GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_T)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Tracking)));
            //GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_X)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Repo)));
            //GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_U)));
            GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_URL1)));
            //GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_R)));
            //GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Repo)));
            //GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Tracking)));
            //GitImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Branch1)));
            m_tvLocalBranch.ImageList = GitImageList;
            m_tvRemoteRepo.ImageList = GitImageList;
            m_lvBranchCommit.SmallImageList = GitImageList;



            //commit info
            GitImageList2 = new ImageList();
            GitImageList2.TransparentColor = System.Drawing.Color.White;
            GitImageList2.ImageSize = new System.Drawing.Size(10, 13);

            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Father)));
            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Child)));
            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Tag)));
            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Branch1)));
            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_A)));
            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_C)));
            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_D)));
            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_M)));
            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_R)));
            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_T)));
            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_U)));
            GitImageList2.Images.Add(((System.Drawing.Image)(Resources.Icon_Change_X)));
            m_lvChangeFiles.SmallImageList = GitImageList2;
        }

        private void UpdateFileChanged(string szSHA)
        {
            if (string.IsNullOrEmpty(szSHA))
            {
                m_lvChangeFiles.Items.Clear();
                return;
            }
            string[] ChangeList = _objGitMgr._objGitMgrCore.GetCommitChange(szSHA, szSHA + @"^1", m_oRemoteInfo.m_szWorkingDir);

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
                string[] ResArray = szChangeItem.Split(new[] { '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
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

        /// <summary>
        /// Refresh GUI according to remote information
        /// </summary>
        private void RefreshGUI()
        {
            m_lvBranchCommit.Items.Clear();
            m_txTrackingInfo.Text = string.Empty;
            m_txSelSHA.Clear();
            m_txSelAuthor.Clear();
            m_txSelLog.Clear();
            m_txRemoteSHA.Clear();
            m_txRemoteAuthor.Clear();
            m_txRemoteLog.Clear();

            RefreshLocalbranchTree();
            RefreshRemoteRepoTree();
            RefreshRelatedInfoShow();
            RefreshCommitList();
            RefreshChangeInfoList();

        }

        /// <summary>
        /// Refresh Local branch Tree and it's tracking information
        /// Bind Remote repository to the local branch, the remote repository will have same branch
        /// </summary>
        private void RefreshLocalbranchTree()
        {
            m_tvLocalBranch.Nodes.Clear();

            //load branch information
            foreach (string szKey in m_oRemoteInfo.m_mapLocalBranch.Keys)
            {
                if (string.IsNullOrEmpty(szKey))
                    return;

                TreeNode tmpNdoe = new TreeNode(szKey);
                tmpNdoe.Tag = "B";  //this node is a local branch
                tmpNdoe.ImageIndex = 0;
                tmpNdoe.SelectedImageIndex = 0;
                m_tvLocalBranch.Nodes.Add(tmpNdoe);
            }


            //load tracking remote repository
            foreach (TreeNode node in m_tvLocalBranch.Nodes)
            {
                string szBranch = node.Text;
                if (m_oRemoteInfo.m_mapAllTracking.ContainsKey(szBranch))
                {
                    string szRemoteInfo = m_oRemoteInfo.m_mapAllTracking[szBranch];
                    TreeNode tmpNdoe = new TreeNode(szRemoteInfo);
                    tmpNdoe.Tag = "T";  //this node is a Tracking repository
                    int nPos=szRemoteInfo.LastIndexOf(" (");
                    if(nPos>=0)
                        szRemoteInfo.Substring(0,nPos);
                    if(m_oRemoteInfo.m_mapAllRemotes.ContainsKey(szRemoteInfo))
                        tmpNdoe.ToolTipText = m_oRemoteInfo.m_mapAllRemotes[szRemoteInfo];
                    tmpNdoe.ImageIndex = 1;
                    tmpNdoe.SelectedImageIndex = 1;
                    tmpNdoe.ForeColor = Color.Blue;
                    node.Nodes.Add(tmpNdoe);
                }

            }


            //load other repository which has same branch with related local branch
            foreach (TreeNode node in m_tvLocalBranch.Nodes)
            {
                TreeNode dirNdoe = new TreeNode("Other Remote Repository");
                dirNdoe.Tag = "D";
                dirNdoe.ImageIndex = 2;
                dirNdoe.SelectedImageIndex = 2;
                node.Nodes.Add(dirNdoe);
                

                string szBranch = node.Text;
                foreach (string szRemoteBr in m_oRemoteInfo.m_mapRemoteBranch.Keys)
                {
                    if (_objGitMgr._objGitMgrCore.IsFromSameAncestor(szBranch, szRemoteBr,_szWorkingDir))
                    {
                        TreeNode tmpNdoe = new TreeNode(szRemoteBr);
                        tmpNdoe.Tag = "O";
                        int nPos = szRemoteBr.LastIndexOf("/");
                        if (nPos >= 0)
                        {
                            string szRemoteInfo = szRemoteBr.Substring(0, nPos);
                            if (m_oRemoteInfo.m_mapAllRemotes.ContainsKey(szRemoteInfo))
                            {
                                tmpNdoe.ToolTipText = m_oRemoteInfo.m_mapAllRemotes[szRemoteInfo];
                            }
                        }
                        tmpNdoe.ImageIndex = 0;
                        tmpNdoe.SelectedImageIndex = 0;
                        dirNdoe.Nodes.Add(tmpNdoe);
                    }
                }
                dirNdoe.Collapse();
                node.Expand();
            }
            //m_tvLocalBranch.ExpandAll();

        }

        private void RefreshRemoteRepoTree()
        {

            m_tvRemoteRepo.Nodes.Clear();

            //load branch information
            foreach (string szKey in m_oRemoteInfo.m_mapAllRemotes.Keys)
            {
                if (string.IsNullOrEmpty(szKey))
                    return;

                TreeNode tmpNdoe = new TreeNode(szKey);
                tmpNdoe.Tag = "R";  //this node is a local branch
                tmpNdoe.ImageIndex = 2;
                tmpNdoe.SelectedImageIndex = 2;
                m_tvRemoteRepo.Nodes.Add(tmpNdoe);
            }


            //load URL
            foreach (TreeNode node in m_tvRemoteRepo.Nodes)
            {
                string szRemote = node.Text;

                string szURL = m_oRemoteInfo.m_mapAllRemotes[szRemote];
                string[] ResArray = szURL.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < ResArray.Length; i++)
                {
                    TreeNode tmpNdoe = new TreeNode(ResArray[i]);
                    tmpNdoe.Tag = string.Format("U-{0}", i);  //this node is a URL
                    tmpNdoe.ImageIndex = 3;
                    tmpNdoe.SelectedImageIndex = 3;
                    tmpNdoe.ForeColor = Color.Blue;
                    node.Nodes.Add(tmpNdoe);
                }
            }

            //load Remote Branch
            foreach (TreeNode node in m_tvRemoteRepo.Nodes)
            {
                string szRemote = node.Text;
                foreach (string szRemoteBr in m_oRemoteInfo.m_mapRemoteBranch.Keys)
                {
                    if (szRemoteBr.StartsWith(szRemote + "/"))
                    {
                        TreeNode tmpNdoe = new TreeNode(szRemoteBr);
                        tmpNdoe.Tag = "B";  //this node is a not a Tracking repository but it can be pushed
                        tmpNdoe.ImageIndex = 0;
                        tmpNdoe.SelectedImageIndex = 0;
                        node.Nodes.Add(tmpNdoe);
                    }

                }
            }
            m_tvRemoteRepo.ExpandAll();

        }

        private void RefreshRelatedInfoShow()
        {
            m_btnCurrentRepository.Text = _szWorkingDir;
            m_txCurrenBranch.Text = m_oRemoteInfo.m_CurentBranch;


        }

        private void DecoreateIR()
        {
            if (m_txTrackingInfo.Lines.Length <= 0)
                return;


            int[] PositionList = new int[m_txTrackingInfo.Lines.Length];
            PositionList[0] = 0;
            for (int i = 1; i < m_txTrackingInfo.Lines.Length; i++)
            {
                PositionList[i] = PositionList[i - 1] + m_txTrackingInfo.Lines[i - 1].Length + 1;

                if (i > 3)
                {
                    if (m_txTrackingInfo.Lines[i].StartsWith("+"))
                    {
                        m_txTrackingInfo.Select(PositionList[i], m_txTrackingInfo.Lines[i].Length);
                        m_txTrackingInfo.SelectionBackColor = Color.Fuchsia;
                    }
                    else if (m_txTrackingInfo.Lines[i].StartsWith("-"))
                    {
                        m_txTrackingInfo.Select(PositionList[i], m_txTrackingInfo.Lines[i].Length);
                        m_txTrackingInfo.SelectionBackColor = Color.Gray;
                    }
                }
            }
        }

        private void RefreshCommitList()
        {


        }

        private void RefreshChangeInfoList()
        {


        }
        #endregion

        #region Evetn Function========================================================================================
        private void m_lvBranchCommit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_lvBranchCommit.SelectedItems.Count == 1)
            {
                string szSHA = m_lvBranchCommit.SelectedItems[0].Tag.ToString();
                UpdateFileChanged(szSHA);

            }
        }
        private void m_btnCurrentRepository_Click(object sender, EventArgs e)
        {
            var browseDialog = new FolderBrowserDialog();
            Button button = sender as Button;

            if (browseDialog.ShowDialog(this) == DialogResult.OK)
            {
                string szSelectPath = browseDialog.SelectedPath + "\\";
                //working repository isn't changed
                if (szSelectPath.Equals(button.Text))
                {
                    return;
                }


                //tell whether the working dir is valid for git
                if (!_objGitMgr._objGitMgrCore.IsValidGitWorkingDir(szSelectPath))
                {
                    MessageBox.Show(this, "Error: You have selected a invalid repository, please change it.", "Invalid Repository");
                    return;
                }

                //tell whether the working dir is valid for git
                _szWorkingDir = szSelectPath;
                button.Text = szSelectPath;

                //load information and show it.
                AysncRunLocalOpera3(InitializeAndShow);

                //
                m_oRemoteInfo.m_szWorkingDir = _szWorkingDir;
                m_oRemoteInfo.m_bIsValid = true;
            }
        }
        #endregion

        #region Context Menu Function========================================================================================
        private void m_MIM_Pull_Click(object sender, EventArgs e)
        {
            if(m_tvLocalBranch.SelectedNode==null || m_tvLocalBranch.Nodes.Count<=0)
            {
                return;
            }

            string szTag = m_tvLocalBranch.SelectedNode.Tag.ToString();
            if (szTag.Equals("T") == false && szTag.Equals("O") == false)
            {
                MessageBox.Show(this, "Error: You must select a valid remote branch, please change it.", "Invalid Repository");
                return;
            }

            try
            {
                //InitTarget
                Form_Remote_PullBranch PullBrDlg = new Form_Remote_PullBranch(this);
                string szLocalBr = string.Empty;
                string szRemoteBr = string.Empty;
                GetLocalBranchNodeInfo(out szLocalBr, out szRemoteBr);
                PullBrDlg.InitTarget(szRemoteBr, szLocalBr);
                if (DialogResult.OK == PullBrDlg.ShowDialog(this))
                {
                    LoadAllData();
                    RefreshGUI();
                    m_oRemoteInfo.m_bIsValid = true;
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;  
        }

        //
        private void m_MIM_Push_Click(object sender, EventArgs e)
        {
            if (m_tvLocalBranch.SelectedNode == null || m_tvLocalBranch.Nodes.Count <= 0)
            {
                return;
            }

            string szTag=m_tvLocalBranch.SelectedNode.Tag.ToString();
            if (szTag.Equals("T") == false && szTag.Equals("O") == false)
            {
                MessageBox.Show(this, "Error: You must select a valid remote branch, please change it.", "Invalid Repository");
                return;
            }

            try
            {
                //InitTarget
                Form_Remote_PushlBranch PushBrDlg = new Form_Remote_PushlBranch(this);
                string szLocalBr = string.Empty;
                string szRemoteBr = string.Empty;
                GetLocalBranchNodeInfo(out szLocalBr, out szRemoteBr);
                PushBrDlg.InitTarget(szRemoteBr, szLocalBr);                
                if (DialogResult.OK == PushBrDlg.ShowDialog(this))
                {
                    LoadAllData();
                    RefreshGUI();
                    m_oRemoteInfo.m_bIsValid = true;
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;  
        }

        private void m_MIM_Sync_Click(object sender, EventArgs e)
        {
            if (m_tvLocalBranch.SelectedNode == null || m_tvLocalBranch.Nodes.Count <= 0)
            {
                return;
            }

            try
            {
                Form_Remote_SynchBranch FilterDlg = new Form_Remote_SynchBranch();
                if (DialogResult.OK == FilterDlg.ShowDialog(this))
                {
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_MIM_MergeChildTree_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Remote_MergeChildTree FilterDlg = new Form_Remote_MergeChildTree();
                if (DialogResult.OK == FilterDlg.ShowDialog(this))
                {
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_MIM_AddSubModule_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Remote_AddSubModule FilterDlg = new Form_Remote_AddSubModule();
                if (DialogResult.OK == FilterDlg.ShowDialog(this))
                {
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        //
        private void m_MIM_Fetch_Click(object sender, EventArgs e)
        {
            if (m_tvRemoteRepo.SelectedNode == null || m_tvRemoteRepo.Nodes.Count <= 0)
            {
                return;
            }
            if(m_tvRemoteRepo.SelectedNode.Level>0)
            {
                MessageBox.Show(this, "Error: You must select a valid remote repository, please change it.", "Invalid Repository");
                return;
            }

            string szName= m_tvRemoteRepo.SelectedNode.Text;
            if(string.IsNullOrEmpty(szName))
            {
                return;
            }

            try
            {                
                //InitTarget
                Form_Remote_Fetch FetchRemoteDlg = new Form_Remote_Fetch(this);
                FetchRemoteDlg.InitTarget(szName);
                if (DialogResult.OK == FetchRemoteDlg.ShowDialog(this))
                {

                    //load all remote information and related information form Git repository
                    LoadAllData();

                    //Refresh GUI according to remote information
                    RefreshGUI();

                    //mark the valid sign
                    m_oRemoteInfo.m_bIsValid = true;
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        //
        private void m_MIM_UploadBracnh_Click(object sender, EventArgs e)
        {
            if (m_tvRemoteRepo.SelectedNode == null || m_tvRemoteRepo.Nodes.Count <= 0)
            {
                return;
            }
            if (m_tvRemoteRepo.SelectedNode.Level > 0)
            {
                MessageBox.Show(this, "Error: You must select a valid remote repository, please change it.", "Invalid Repository");
                return;
            }

            string szName = m_tvRemoteRepo.SelectedNode.Text;
            if (string.IsNullOrEmpty(szName))
            {
                return;
            }

            try
            {
                //InitTarget
                Form_Remote_UpLoadBranch UpdLoadBrDlg = new Form_Remote_UpLoadBranch(this);
                UpdLoadBrDlg.InitTarget(szName);
                if (DialogResult.OK == UpdLoadBrDlg.ShowDialog(this))
                {

                    //load all remote information and related information form Git repository
                    LoadAllData();

                    //Refresh GUI according to remote information
                    RefreshGUI();

                    //mark the valid sign
                    m_oRemoteInfo.m_bIsValid = true;
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;

        }
        //
        private void m_MIM_UploadTag_Click(object sender, EventArgs e)
        {
            if (m_tvRemoteRepo.SelectedNode == null || m_tvRemoteRepo.Nodes.Count <= 0)
            {
                return;
            }
            if (m_tvRemoteRepo.SelectedNode.Level > 0)
            {
                MessageBox.Show(this, "Error: You must select a valid remote repository, please change it.", "Invalid Repository");
                return;
            }

            string szName = m_tvRemoteRepo.SelectedNode.Text;
            if (string.IsNullOrEmpty(szName))
            {
                return;
            }

            try
            {
                //InitTarget
                Form_Remote_UploadTag UpdLoadTagrDlg = new Form_Remote_UploadTag(this);
                UpdLoadTagrDlg.InitTarget(szName);
                if (DialogResult.OK == UpdLoadTagrDlg.ShowDialog(this))
                {

                    //load all remote information and related information form Git repository
                    LoadAllData();

                    //Refresh GUI according to remote information
                    RefreshGUI();

                    //mark the valid sign
                    m_oRemoteInfo.m_bIsValid = true;
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;


        }
        //
        private void m_MIM_DeleteRemoteBranch_Click(object sender, EventArgs e)
        {
            if (m_tvRemoteRepo.SelectedNode == null || m_tvRemoteRepo.Nodes.Count <= 0)
            {
                return;
            }
            if (m_tvRemoteRepo.SelectedNode.Level > 0)
            {
                MessageBox.Show(this, "Error: You must select a valid remote repository, please change it.", "Invalid Repository");
                return;
            }

            string szName = m_tvRemoteRepo.SelectedNode.Text;
            if (string.IsNullOrEmpty(szName))
            {
                return;
            }

            try
            {
                //InitTarget
                Form_Remote_DelRemoteBranch DelRemoteBranchDlg = new Form_Remote_DelRemoteBranch(this);
                DelRemoteBranchDlg.InitTarget(szName);
                if (DialogResult.OK == DelRemoteBranchDlg.ShowDialog(this))
                {

                    //load all remote information and related information form Git repository
                    LoadAllData();

                    //Refresh GUI according to remote information
                    RefreshGUI();

                    //mark the valid sign
                    m_oRemoteInfo.m_bIsValid = true;
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
      
        }

        //
        private void m_MIM_RegisterRemote_Click(object sender, EventArgs e)
        {
            //if (m_tvRemoteRepo.SelectedNode == null || m_tvRemoteRepo.Nodes.Count <= 0)
            //{
            //    return;
           // }
            try
            {
                Form_Remote_AddRemote AddRemoteDlg = new Form_Remote_AddRemote(this);
                if (DialogResult.OK == AddRemoteDlg.ShowDialog(this))
                {

                    //load all remote information and related information form Git repository
                    LoadAllData();

                    //Refresh GUI according to remote information
                    RefreshGUI();

                    //mark the valid sign
                    m_oRemoteInfo.m_bIsValid = true;
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }
        //
        private void m_MIM_RemoveRemote_Click(object sender, EventArgs e)
        {
            if (m_tvRemoteRepo.SelectedNode == null || m_tvRemoteRepo.Nodes.Count <= 0)
            {
                return;
            }
            if (m_tvRemoteRepo.SelectedNode.Level > 0)
            {
                MessageBox.Show(this, "Error: You must select a valid remote repository, please change it.", "Invalid Repository");
                return;
            }

            string szName = m_tvRemoteRepo.SelectedNode.Text;
            if (string.IsNullOrEmpty(szName))
            {
                return;
            }

            try
            {
                //InitTarget
                Form_Remote_RemoveRemote RemovehRemoteDlg = new Form_Remote_RemoveRemote(this);
                RemovehRemoteDlg.InitTarget(szName);
                if (DialogResult.OK == RemovehRemoteDlg.ShowDialog(this))
                {

                    //load all remote information and related information form Git repository
                    LoadAllData();

                    //Refresh GUI according to remote information
                    RefreshGUI();

                    //mark the valid sign
                    m_oRemoteInfo.m_bIsValid = true;
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        //
        private void m_MIM_RenameRemote_Click(object sender, EventArgs e)
        {
            if (m_tvRemoteRepo.SelectedNode == null || m_tvRemoteRepo.Nodes.Count <= 0)
            {
                return;
            }
            if (m_tvRemoteRepo.SelectedNode.Level > 0)
            {
                MessageBox.Show(this, "Error: You must select a valid remote repository, please change it.", "Invalid Repository");
                return;
            }

            string szName = m_tvRemoteRepo.SelectedNode.Text;
            if (string.IsNullOrEmpty(szName))
            {
                return;
            }

            try
            {
                //InitTarget
                Form_Remote_RenameRemote RemovehRemoteDlg = new Form_Remote_RenameRemote(this);
                RemovehRemoteDlg.InitTarget(szName);
                if (DialogResult.OK == RemovehRemoteDlg.ShowDialog(this))
                {

                    //load all remote information and related information form Git repository
                    LoadAllData();

                    //Refresh GUI according to remote information
                    RefreshGUI();

                    //mark the valid sign
                    m_oRemoteInfo.m_bIsValid = true;
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;

        }

        //
        private void m_MIM_EditRemote_Click(object sender, EventArgs e)
        {
            if (m_tvRemoteRepo.SelectedNode == null || m_tvRemoteRepo.Nodes.Count <= 0)
            {
                return;
            }
            if (m_tvRemoteRepo.SelectedNode.Level > 0)
            {
                MessageBox.Show(this, "Error: You must select a valid remote repository, please retry.", "Invalid Repository");
                return;
            }

            string szName = m_tvRemoteRepo.SelectedNode.Text;
            if (string.IsNullOrEmpty(szName))
            {
                return;
            }

            try
            {
                //InitTarget
                Form_Remote_EditRemote EditRemoteDlg = new Form_Remote_EditRemote(this);
                EditRemoteDlg.InitTarget(szName);
                if (DialogResult.OK == EditRemoteDlg.ShowDialog(this))
                {

                    //load all remote information and related information form Git repository
                    LoadAllData();

                    //Refresh GUI according to remote information
                    RefreshGUI();

                    //mark the valid sign
                    m_oRemoteInfo.m_bIsValid = true;
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
  
        }

        //
        private void m_MIM_AddLocalTracking_Click(object sender, EventArgs e)
        {
            if (m_tvRemoteRepo.SelectedNode == null || m_tvRemoteRepo.Nodes.Count <= 0)
            {
                return;
            }
            if(false==m_tvRemoteRepo.SelectedNode.Tag.ToString().Equals("B"))
            {
                MessageBox.Show(this, "Error: You must select a valid remote branch, please retry.", "Invalid remote branch");
                return;
            }

            string szRemoteBranch = m_tvRemoteRepo.SelectedNode.Text;
            string szRemoteRepo = m_tvRemoteRepo.SelectedNode.Parent.Text;
            if (string.IsNullOrEmpty(szRemoteBranch) || string.IsNullOrEmpty(szRemoteRepo))
            {
                return;
            }

            try
            {
                //InitTarget
                Form_Remote_AddTracking AddTrackingDlg = new Form_Remote_AddTracking(this);
                AddTrackingDlg.InitTarget(szRemoteRepo, szRemoteBranch);
                if (DialogResult.OK == AddTrackingDlg.ShowDialog(this))
                {

                    //load all remote information and related information form Git repository
                    LoadAllData();

                    //Refresh GUI according to remote information
                    RefreshGUI();

                    //mark the valid sign
                    m_oRemoteInfo.m_bIsValid = true;
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;

        }

        private void m_MIM_RemoveLocalTracking_Click(object sender, EventArgs e)
        {
            if (m_tvRemoteRepo.SelectedNode == null || m_tvRemoteRepo.Nodes.Count <= 0)
            {
                return;
            }
            try
            {
                Form_Remote_RemoveTracking FilterDlg = new Form_Remote_RemoveTracking();
                if (DialogResult.OK == FilterDlg.ShowDialog(this))
                {
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        #endregion

        private void ShowBranchChangeInfo()
        {
            string szLocalBr = string.Empty;
            string szRemoteBr = string.Empty;
            GetLocalBranchNodeInfo(out szLocalBr, out szRemoteBr);
            string szLocalBrSHA = _objGitMgr._objGitMgrCore.GetHashIDFrom(szLocalBr, _szWorkingDir);
            string szRemoteBrSHA = _objGitMgr._objGitMgrCore.GetHashIDFrom(szRemoteBr, _szWorkingDir);
            if (string.IsNullOrEmpty(szRemoteBrSHA) || string.IsNullOrEmpty(szLocalBrSHA))
            {
                Trace.Assert(false);
                HideWaiting();
                return;
            }

            //shwo related information
            CommiteInfoItemSimple oRemoteBrInfo;
            CommiteInfoItemSimple olocalBrInfo;
            if (false == string.IsNullOrEmpty(szRemoteBrSHA))
            {
                oRemoteBrInfo = _objGitMgr._objGitMgrCore.GetSpecCommitItem(szRemoteBrSHA, _szWorkingDir)[szRemoteBrSHA];
                m_txRemoteSHA.Text = oRemoteBrInfo.szSelfSHA;
                m_txRemoteAuthor.Text = oRemoteBrInfo.szAutrhorName;
                m_txRemoteLog.Text = oRemoteBrInfo.szCommitMessage;
            }
            if (false == string.IsNullOrEmpty(szLocalBrSHA))
            {
                olocalBrInfo = _objGitMgr._objGitMgrCore.GetSpecCommitItem(szLocalBrSHA, _szWorkingDir)[szLocalBrSHA];
                m_txSelSHA.Text = olocalBrInfo.szSelfSHA;
                m_txSelAuthor.Text = olocalBrInfo.szAutrhorName;
                m_txSelLog.Text = olocalBrInfo.szCommitMessage;
            }


            //there's no change;
            if (szLocalBrSHA.Equals(szRemoteBrSHA))
            {
                m_txTrackingInfo.Text = @"No Change";

                /*
                CommiteInfoItemSimple sLocalContent;
                sLocalContent = _objGitMgr._objGitMgrCore.GetSpecCommitItem(szLocalBrSHA, _szWorkingDir)[szLocalBrSHA];
                ListViewItem ReItem1;
                ReItem1 = new ListViewItem(szLocalBrSHA.Substring(0, 6), 4);
                ReItem1.BackColor = Color.PaleGreen;

                ReItem1.Tag = szLocalBrSHA;
                ReItem1.SubItems.Add(sLocalContent.szCommitMessage);
                ReItem1.SubItems.Add(sLocalContent.szAutrhorName);
                ReItem1.SubItems.Add(sLocalContent.szCommitDate);
                m_lvBranchCommit.Items.Add(ReItem1);
                */

                CommiteInfoItemSimple sRemoteContent;
                sRemoteContent = _objGitMgr._objGitMgrCore.GetSpecCommitItem(szRemoteBrSHA, _szWorkingDir)[szRemoteBrSHA];
                ListViewItem ReItem;
                ReItem = new ListViewItem(szRemoteBrSHA.Substring(0, 6), 4);
                ReItem.BackColor = Color.Purple;

                ReItem.Tag = szRemoteBrSHA;
                ReItem.ToolTipText = "Base Point";
                ReItem.SubItems.Add(sRemoteContent.szCommitMessage);
                ReItem.SubItems.Add(sRemoteContent.szAutrhorName);
                ReItem.SubItems.Add(sRemoteContent.szCommitDate);
                m_lvBranchCommit.Items.Add(ReItem);
                HideWaiting();
                return;
            }


            //show change in rich text box
            m_txTrackingInfo.Clear();
            
            ///
            //it's ignored now, maybe it will be added later
            //m_txTrackingInfo.AppendText(_objGitMgr._objGitMgrCore.GetCommitDifferInfo(szRemoteBrSHA, szLocalBrSHA, _szWorkingDir));
            //DecoreateIR();

            string szBaseSHA = _objGitMgr._objGitMgrCore.GetLastAncestorCommit(szLocalBrSHA, szRemoteBrSHA, _szWorkingDir);
            if (string.IsNullOrEmpty(szBaseSHA)) //error
            {
                m_lvBranchCommit.Items.Clear();
                HideWaiting();
                return;
            }
            else if (szBaseSHA.Equals(szRemoteBrSHA))//local branch is child from remote branch
            {
                m_lvBranchCommit.Items.Clear();
                Dictionary<string, CommiteInfoItemSimple> ExcludeItems;
                ExcludeItems = _objGitMgr._objGitMgrCore.GetExcludeItmsFromFathrer(szBaseSHA, szLocalBr, _szWorkingDir);
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
            else if (szBaseSHA.Equals(szLocalBrSHA))//local branch is father of remote branch
            {
                m_lvBranchCommit.Items.Clear();
                Dictionary<string, CommiteInfoItemSimple> ExcludeItems;
                ExcludeItems = _objGitMgr._objGitMgrCore.GetExcludeItmsFromFathrer(szBaseSHA, szRemoteBrSHA, _szWorkingDir);
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
            else //two divided branches from same father
            {
                m_lvBranchCommit.Items.Clear();
                Dictionary<string, CommiteInfoItemSimple> ExcludeItems;
                ExcludeItems = _objGitMgr._objGitMgrCore.GetExcludeItmsFromFathrer(szBaseSHA, szLocalBr, _szWorkingDir);
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
                ExcludeItems = _objGitMgr._objGitMgrCore.GetExcludeItmsFromFathrer(szBaseSHA, szRemoteBrSHA, _szWorkingDir);
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
            HideWaiting();
            CommiteInfoItemSimple sBaseContent;
            sBaseContent = _objGitMgr._objGitMgrCore.GetSpecCommitItem(szBaseSHA, _szWorkingDir)[szBaseSHA];
            ListViewItem BaseItem;
            BaseItem = new ListViewItem(szBaseSHA.Substring(0, 6), 4);
            BaseItem.BackColor = Color.Purple;

            BaseItem.Tag = szBaseSHA;
            BaseItem.SubItems.Add(sBaseContent.szCommitMessage);
            BaseItem.SubItems.Add(sBaseContent.szAutrhorName);
            BaseItem.SubItems.Add(sBaseContent.szCommitDate);
            m_lvBranchCommit.Items.Add(BaseItem);
        }
        private void m_tvLocalBranch_AfterSelect(object sender, TreeViewEventArgs e)
        {
            m_lvBranchCommit.Items.Clear();
            m_txTrackingInfo.Text = string.Empty;
            m_txSelSHA.Clear();
            m_txSelAuthor.Clear();
            m_txSelLog.Clear();
            m_txRemoteSHA.Clear();
            m_txRemoteAuthor.Clear();
            m_txRemoteLog.Clear();

            if (m_tvLocalBranch.SelectedNode.Tag == null)
                return;

            if (m_tvLocalBranch.SelectedNode.Tag.ToString().StartsWith("B"))
            {
                string szLocalBr = m_tvLocalBranch.SelectedNode.Text;
                string szLocalBrSHA = _objGitMgr._objGitMgrCore.GetHashIDFrom(szLocalBr, _szWorkingDir);

                CommiteInfoItemSimple olocalBrInfo;
                olocalBrInfo = _objGitMgr._objGitMgrCore.GetSpecCommitItem(szLocalBrSHA, _szWorkingDir)[szLocalBrSHA];

                m_txSelSHA.Text = olocalBrInfo.szSelfSHA;
                m_txSelAuthor.Text = olocalBrInfo.szAutrhorName;
                m_txSelLog.Text = olocalBrInfo.szCommitMessage;

                m_txRemoteSHA.Clear();
                m_txRemoteAuthor.Clear();
                m_txRemoteLog.Clear();
            }
            else if (m_tvLocalBranch.SelectedNode.Tag.ToString().StartsWith("T") || m_tvLocalBranch.SelectedNode.Tag.ToString().StartsWith("O"))
            {
                AysncRunLocalOpera(ShowBranchChangeInfo);
            }
        }
        private void GetLocalBranchNodeInfo(out string szLocalBranch, out string szRemoteBranch)
        {
            string szLocalBr ;
            string szRemoteBr ;
            if(m_tvLocalBranch.SelectedNode.Tag.ToString().StartsWith("T"))
            {
                szLocalBr = m_tvLocalBranch.SelectedNode.Parent.Text;
                string szRemoteInfo = m_tvLocalBranch.SelectedNode.Text;
                int nPos = szRemoteInfo.LastIndexOf(" (");
                if (nPos >= 0)
                    szRemoteInfo = szRemoteInfo.Substring(0, nPos);
                szRemoteBr = szRemoteInfo + "/" + CHelpFuntions.GetBracketContent(m_tvLocalBranch.SelectedNode.Text);
            }
            else
            {
                szLocalBr = m_tvLocalBranch.SelectedNode.Parent.Parent.Text;
                szRemoteBr = m_tvLocalBranch.SelectedNode.Text;
            }

            szLocalBranch = szLocalBr;
            szRemoteBranch = szRemoteBr;
        }
        private void m_tvRemoteRepo_MouseClick(object sender, MouseEventArgs e)
        {

        }

        //==============================================================================================test
        private void m_BackGround_DoWork(object sender, DoWorkEventArgs e)
        {
            //tell whether the working dir is valid
            if (string.IsNullOrEmpty(_szWorkingDir))
            {
                m_oRemoteInfo.m_szWorkingDir = null;
                m_oRemoteInfo.m_bIsValid = false;
                return;
            }

            //tell whether the working dir is valid for git
            if (!_objGitMgr._objGitMgrCore.IsValidGitWorkingDir(_szWorkingDir))
            {
                m_oRemoteInfo.m_szWorkingDir = _szWorkingDir;
                m_oRemoteInfo.m_bIsValid = false;
                return;
            }

            //load all remote information and related information form Git repository
            LoadAllData();

            //Refresh GUI according to remote information
            RefreshGUI();

            //
            m_oRemoteInfo.m_szWorkingDir = _szWorkingDir;
            m_oRemoteInfo.m_bIsValid = true;
        }
        private void m_BackGround_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        private void m_contextMenuBranch_Opening(object sender, CancelEventArgs e)
        {
            if (m_tvLocalBranch.Nodes.Count <= 0 || m_tvLocalBranch.SelectedNode == null)
            {
                m_contextMenuBranch.Enabled = false;
            }
            else
            {
                m_contextMenuBranch.Enabled = true;
            }
        }
        /////


    }
}

