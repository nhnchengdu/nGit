using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Git.Repository;
using Git.Manager;
using System.Diagnostics;
using System.Threading;
using Git.Core.Helper;

using System.Runtime.InteropServices;
using System.Collections;
using System.Text.RegularExpressions;
using Nhn.Git.Core;
using Nhn.Git.Core.Properties;

namespace Git.UI
{
    public partial class CRepositoryControl : CGitAsynchControl
    {
        //The GUI contents shown will be based on the data;
        //it's a child set from m_oGitRepository
        public class CShowContent
        {
            public List<string> SHAList = new List<string>();
            public string szBranch;
            public string szDdateStart;
            public string szDdateEnd;
            public string szAuthor;
            public string szMSg;
            public bool bIsSetFilter;
            public Dictionary<int, Color> mapSearchItms = new Dictionary<int, Color>();
        }
        public CShowContent m_oShowContent;

        //repository object
        public CGitRepository m_oGitRepository;

        //
        public CRepositoryControl()
        {
            InitializeComponent();
            m_oShowContent = new CShowContent();
            m_oShowContent.bIsSetFilter = false;
            //create a repository object
            m_oGitRepository = new CGitRepository();
        }

        //
        private ImageList GitImageList;
        private ImageList ButtonImageList;
        private void CRepositoryControl_Load(object sender, EventArgs e)
        {
            LoadImage();
            //tell whether the working dir is valid
            if (string.IsNullOrEmpty(_szWorkingDir))
            {
                LoadRepository();
            }   
            else
            {
                AysncRunLocalOpera(LoadRepository);
            }
            
            //LoadRepository();
        }

        #region override for asynch git opeatioan===============================================================
        
        //exit process
        override protected void CallBackGitProcessExit(object sender, int code)
        {
            Trace.WriteLine(String.Format("\n--------------------Exit----------------------"));
            if (_bIsRegGitEvent == true)
            {
                _objGitMgr._objGitMgrCore.Async_DataReceived_Event -= ProcessReceiveData;
                _objGitMgr._objGitMgrCore.Async_Exited_Event -= ProcessAbort;
                _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event -= ProcessErrorData;
                _bIsRegGitEvent = false;

                //exchange all commits  temp info with useful info
                m_oGitRepository.UpdateAllCommites();
                if (m_oGitRepository.m_bIsValidCommite == true)
                {
                    RefreshGUI(true);
                }
                else
                {
                    ClearGUI();
                }
            }
            this.Enabled = true;
            HideWaiting();
            if (m_oGitRepository.m_bIsValidCommite == false)
            {
                MessageBox.Show(this, "This Selected Git Repository mabye be destroyed.", "Warning");
            }
            
        }
        
        //receive data
        override protected void CallBackGitProcessReceiveData(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(String.Format("\n--------------------Receive----------------------"));
            if(_objGitMgr._objGitMgrCore.m_enCurrAsyncOperType==AsyncOperaType.ASYNC_GET_ALL_COMMITS)
            {
                string[] ArrayInfo = _objGitMgr._objGitMgrCore.ParseCommtItemInfo(e.Data);
                if (ArrayInfo != null && ArrayInfo.Length == 10)
                {
                    CommiteInfoItem Item = new CommiteInfoItem();
                    Item.szSelfSHA = ArrayInfo[0];
                    Item.szParentSHA = ArrayInfo[1];
                    Item.szTreeSHA = ArrayInfo[2];
                    Item.szAutrhorName = ArrayInfo[3];
                    Item.szAutrhorEmail = ArrayInfo[4];
                    Item.szAutrhorDate = ArrayInfo[5];
                    Item.szCommitName = ArrayInfo[6];
                    Item.szCommitDate = ArrayInfo[7];
                    Item.szCommitEncoding = ArrayInfo[8];
                    Item.szCommitMessage = ArrayInfo[9];
                    m_oGitRepository.m_mapTempAllCommites.Add(ArrayInfo[0], Item);
                }   
            }            
        }
        
        //error occurance
        override protected void CallBackGitProcessErrorData(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(String.Format("\n--------------------Error----------------------"));
            CallBackGitProcessReceiveData(sender, e);
        }
        
        #endregion        

        #region Get repository Information from Git=============================================================
        
        //refresh all data from git repository,1
        public void LoadRepository()
        {
            //tell whether the working dir is valid
            if(string.IsNullOrEmpty(_szWorkingDir))
            {
                m_oGitRepository.m_szWorkingDir=null;
                m_oGitRepository.m_bIsValid=false;
                return;
            }                       

            //tell whether the working dir is valid for git
            if(!_objGitMgr._objGitMgrCore.IsValidGitWorkingDir(_szWorkingDir))
            {
                m_oGitRepository.m_szWorkingDir=null;
                m_oGitRepository.m_bIsValid=false;
                return;
            }
            
            //get all branch including remote and local
            RefreshData();
        }

        //refresh all data from git repository,2
        private void RefreshData()
        {
            //get all branch including remote and local
            GetALLBranches();

            //get all tags i
            GetALLTags();

            //get all commit  
            GetALLCommites();      
        }

        //refresh all data from git repository,2
        private void ClearGUI()
        {
            m_txCurrenBranch.Clear();
            m_txSearch.Clear();
            m_lvCommitsInfo.Items.Clear();
            m_lbRelatedCommits.Items.Clear();
            m_lbParentRefer.Items.Clear();
            m_lvChangeFiles.Items.Clear();
            m_rtxChangeContent.Clear();
            m_txSelectedSHA.Clear();
            m_txAuthor.Clear();
            m_txDate.Clear();
            m_txLogMessage.Clear();
        }

        //get all branch including remote and local
        private void GetALLBranches()
        { 
            //local branch
            string[] BranchArray;
            string szHashId=null;

            m_oGitRepository.m_mapLocalBranch.Clear();
            m_oGitRepository.m_mapRemoteBranch.Clear();

            BranchArray = _objGitMgr._objGitMgrCore.GetBranch(false, _szWorkingDir);
            if(BranchArray!=null && BranchArray.Length>0) 
            {
                //initialize local branch storage
                m_oGitRepository.m_CurentBranch=BranchArray[0];                

                //first node, current branch
                if(!string.IsNullOrEmpty(BranchArray[0]))
                {
                    szHashId= _objGitMgr._objGitMgrCore.GetHashIDFrom(BranchArray[0],_szWorkingDir);
                    m_oGitRepository.m_mapLocalBranch.Add(BranchArray[0],szHashId);                   

                }

                //other branch
                for(int i=1; i<BranchArray.Length;i++)
                {
                    szHashId= _objGitMgr._objGitMgrCore.GetHashIDFrom(BranchArray[i],_szWorkingDir);
                    m_oGitRepository.m_mapLocalBranch.Add(BranchArray[i],szHashId);
                }   
            }


            //Remote branch
            string[] RemoteBranchArray;
            RemoteBranchArray = _objGitMgr._objGitMgrCore.GetBranch(true, _szWorkingDir);
            if (RemoteBranchArray != null && RemoteBranchArray.Length > 0)
            {                
                for (int i = 0; i < RemoteBranchArray.Length; i++)
                {
                    szHashId = _objGitMgr._objGitMgrCore.GetHashIDFrom(RemoteBranchArray[i], _szWorkingDir);
                    m_oGitRepository.m_mapRemoteBranch.Add(RemoteBranchArray[i], szHashId);
                }
            }


        }
           
        //get all tags        
        private void GetALLTags()
        {
            string[] TagArray= _objGitMgr._objGitMgrCore.GetTag(_szWorkingDir);
            m_oGitRepository.m_mapTag.Clear();

            string szHashId=null;            
            if(TagArray!=null && TagArray.Length>0) 
            {                
                for (int i = 0; i < TagArray.Length; i++)
                {
                    szHashId = _objGitMgr._objGitMgrCore.GetHashIDFrom(TagArray[i], _szWorkingDir);
                    m_oGitRepository.m_mapTag.Add(TagArray[i], szHashId);
                }   
            }
        }

        //get all commites and related information 
        private void GetALLCommites()
        {
            if (_bIsRegGitEvent == false)
            {
                _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
                _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
                _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
                _bIsRegGitEvent = true;
            }
            m_oGitRepository.m_mapTempAllCommites.Clear();
            //this.Enabled = false;
            _objGitMgr._objGitMgrCore.GetAllCommits(_szWorkingDir);
        }
       private void RefreshReferMap()
       {
           m_oGitRepository.RenewId2Refer();
       }


        #endregion

        #region GUI Shown========================================================================================

        //refresh all GUI  according to repository data
        private void RefreshGUI(bool bIsInitRepo)
        {
            m_btnCurrentRepository.Text = _szWorkingDir;
            m_txCurrenBranch.Text = m_oGitRepository.m_CurentBranch;
            if (bIsInitRepo==true)
            {
                m_oShowContent.bIsSetFilter = false;
                m_oShowContent.SHAList.Clear();
                m_oShowContent.szAuthor = string.Empty;
                m_oShowContent.szBranch = string.Empty;
                m_oShowContent.szDdateEnd = string.Empty;
                m_oShowContent.szDdateStart = string.Empty;
                m_oShowContent.szMSg = string.Empty;
            }

            //get contents which was filtered;
            UpdateShowContent();

            //Refresh m_lvCommitsInfo
            RefreshGUI_CommitsList();

            //Refresh tab page(Message) 
            if (m_lvCommitsInfo.FocusedItem != null)
            {
                RefreshGUI_CommitInfo(m_lvCommitsInfo.FocusedItem.Tag as string);
            }
            else
            {
                RefreshGUI_CommitInfo(null);
            }

            //Refresh tab page(Tree) 
            if (m_lvCommitsInfo.FocusedItem != null)
            {
                RefreshGUI_CommitTree(m_lvCommitsInfo.FocusedItem.Tag as string);
            }
            else
            {
                RefreshGUI_CommitTree(null);
            }

            HideWaiting();
        }             
        
        //this function is still in undong status, finish it later
        private void RefreshGUIforOneCommit(string szSHA)
        {
            //

        }

        //Update the data shown according to filter,mainly for SHAlist which will be shown
        private void UpdateShowContent()
        {
            if (false==m_oShowContent.bIsSetFilter)
            {
                m_oShowContent.SHAList.Clear();
                m_oShowContent.mapSearchItms.Clear();
                m_oShowContent.SHAList.AddRange(m_oGitRepository.m_mapAllCommites.Keys);
            }
            else
            {
                m_oShowContent.SHAList.Clear();
                m_oShowContent.mapSearchItms.Clear();

                //Construct the filter condition for git command--branch match
                string szConidtions=string.Empty;
                if (string.IsNullOrEmpty(m_oShowContent.szBranch))
                {
                    szConidtions = @"--all";
                }
                else
                {
                    string[] szArray=m_oShowContent.szBranch.Split(new[] { ';', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    for(int i=0;i<szArray.Length;i++)
                    {
                        szConidtions = szConidtions + szArray[i];
                    }
                }
                if (string.IsNullOrEmpty(szConidtions))
                    return;

                //Construct the filter condition for git command--date match
                if (false==string.IsNullOrEmpty(m_oShowContent.szDdateStart))
                {
                    szConidtions = string.Format("{0} --since=\"{1}\"", szConidtions, m_oShowContent.szDdateStart);
                }
                if (false == string.IsNullOrEmpty(m_oShowContent.szDdateEnd))
                {
                    szConidtions = string.Format("{0} --until=\"{1}\"", szConidtions, m_oShowContent.szDdateEnd);
                }

                //Construct the filter condition for git command--Message match
                if (false == string.IsNullOrEmpty(m_oShowContent.szMSg))
                {
                    szConidtions = string.Format("{0} --grep=\"{1}\"", szConidtions, m_oShowContent.szMSg);
                }

                //Construct the filter condition for git command--Message match
                if (false == string.IsNullOrEmpty(m_oShowContent.szAuthor))
                {
                    szConidtions = string.Format("{0} --author=\"{1}\\s\"", szConidtions, m_oShowContent.szAuthor);
                }

                MatchCollection mcArray=_objGitMgr._objGitMgrCore.GetFilterCommits(szConidtions, _szWorkingDir);
                if (mcArray == null || mcArray.Count <= 0)
                    return;

                //update the m_oShowContent information
                for (int i = 0; i < mcArray.Count; i++) 
                {
                    string szItem = mcArray[i].Value;
                    m_oShowContent.SHAList.Add(szItem);
                }  
               
            }


        }

        //load image resouce
        private void LoadImage()
        {
            GitImageList = new ImageList();
            ButtonImageList = new ImageList();
            GitImageList.TransparentColor = System.Drawing.Color.White;
            ButtonImageList.TransparentColor = System.Drawing.Color.White;

            //GitImageList.ImageSize = new System.Drawing.Size(7, 16);
            GitImageList.ImageSize = new System.Drawing.Size(10, 13);
            ButtonImageList.ImageSize = new System.Drawing.Size(16, 16);

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

            ButtonImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Button_Search)));
            ButtonImageList.Images.Add(((System.Drawing.Image)(Resources.Icon_Button_Swtich)));
            m_btnSwitchBr.ImageList = ButtonImageList;
            m_btnSearch.ImageList=ButtonImageList;
            m_btnSwitchBr.ImageIndex = 1;
            m_btnSearch.ImageIndex = 0;

            m_lbParentRefer.ImageList = GitImageList;
            m_lbRelatedCommits.ImageList = GitImageList;
            //m_lvChangeFiles.StateImageList = GitImageList;
            m_lvChangeFiles.SmallImageList = GitImageList;
        }

        //refresh m_lvCommitsInfo
        private void RefreshGUI_CommitsList()
        {           
            int i = 0;
            m_lvCommitsInfo.Items.Clear();
            foreach (string szItemNaam in m_oShowContent.SHAList)
            {
                ListViewItem item = new ListViewItem(szItemNaam.Substring(0, 8), 0);
                item.Tag = szItemNaam;
                if ((i++ % 2) == 1)
                    item.BackColor = Color.AliceBlue;
                else
                    item.BackColor = Color.AntiqueWhite;
               
                if (m_oGitRepository.m_mapId2LocalBranch.ContainsKey(szItemNaam))
                    item.SubItems.Add(m_oGitRepository.m_mapId2LocalBranch[szItemNaam]);
                else
                    item.SubItems.Add(string.Empty);

                string szToolTip = string.Empty;
                if(m_oGitRepository.m_mapId2Tag.ContainsKey(szItemNaam))
                {
                    szToolTip = string.Format("(Tag:{0})", m_oGitRepository.m_mapId2Tag[szItemNaam]);
                }

                if(m_oGitRepository.m_mapId2RemoteBranch.ContainsKey(szItemNaam))
                {
                    if (string.IsNullOrEmpty(szToolTip))
                    {
                        szToolTip = string.Format("(Remote:{0})", m_oGitRepository.m_mapId2RemoteBranch[szItemNaam]);
                    }
                    else
                    {
                        szToolTip = string.Format("{0}{1}(Remote:{2})", szToolTip, Environment.NewLine, m_oGitRepository.m_mapId2RemoteBranch[szItemNaam]);
                    }
                }
                item.Text = item.Text+" "+szToolTip;
                item.SubItems.Add(m_oGitRepository.m_mapAllCommites[szItemNaam].szCommitMessage);
                item.SubItems.Add(m_oGitRepository.m_mapAllCommites[szItemNaam].szAutrhorName);
                item.SubItems.Add(m_oGitRepository.m_mapAllCommites[szItemNaam].szAutrhorDate);
                m_lvCommitsInfo.Items.Add(item);
            }
            if (m_lvCommitsInfo.Items.Count>0)
            {
                //m_lvCommitsInfo.Focus();
                m_lvCommitsInfo.Items[0].Focused = true;
                //m_lvCommitsInfo.Items[0].Selected = true;
               // m_lvCommitsInfo.FocusedItem = m_lvCommitsInfo.Items[0];
                m_lvCommitsInfo.EnsureVisible(0);    
            }
            
        }

        //refresh tab
        private void RefreshGUI_Tab_AsyncLocal(string szSHA)
        {
            //

            //Refresh tab page(Message) 
            RefreshGUI_CommitInfo(szSHA);

            //
            HideWaiting();
        }

        //refresh tab page(Message) 
        private void RefreshGUI_CommitInfo(string szSHA)
        {
            if(string.IsNullOrEmpty(szSHA))
            {
                m_txSelectedSHA.Text = string.Empty;
                m_txAuthor.Text = string.Empty;
                m_txDate.Text = string.Empty;
                m_txLogMessage.Text = string.Empty;
                m_lbRelatedCommits.Items.Clear();
                return;
            }

            //update related information of commit selected
            m_txSelectedSHA.Text = szSHA;
            m_txAuthor.Text = m_oGitRepository.m_mapAllCommites[szSHA].szAutrhorName + " ---"
                            + m_oGitRepository.m_mapAllCommites[szSHA].szAutrhorEmail;
            m_txDate.Text = m_oGitRepository.m_mapAllCommites[szSHA].szAutrhorDate;
            m_txLogMessage.Text = m_oGitRepository.m_mapAllCommites[szSHA].szCommitMessage;

            //update related commits
            m_lbRelatedCommits.Items.Clear();

            string[] ParentList=m_oGitRepository.m_mapAllCommites[szSHA].szParentSHA.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string szItem in ParentList)
            {
                string szContent = "(" + szItem.Substring(0, 6) + ")" + m_oGitRepository.m_mapAllCommites[szItem].szCommitMessage;               
                m_lbRelatedCommits.Items.Add(new CListBoxItem(szContent, 0));
            }

            string szChild=m_oGitRepository.m_mapAllCommites[szSHA].szChildSHA;
            if(!string.IsNullOrEmpty(szChild))
            {
                string[] ChildList = szChild.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string szItem in ChildList)
                {
                    string szContent = "(" + szItem.Substring(0, 6) + ")" + m_oGitRepository.m_mapAllCommites[szItem].szCommitMessage;
                    m_lbRelatedCommits.Items.Add(new CListBoxItem(szContent, 1));                    
                }
            }


            //update parent reference information
            m_lbParentRefer.Items.Clear();            
            foreach (string szLocalItem in m_oGitRepository.m_mapLocalBranch.Keys)
            {
                if (_objGitMgr._objGitMgrCore.IsHeritFrom(m_oGitRepository.m_mapLocalBranch[szLocalItem], szSHA, _szWorkingDir))
                {
                    m_lbParentRefer.Items.Add(new CListBoxItem(szLocalItem, 3));                
                }
            }

            foreach (string szRemoteItem in m_oGitRepository.m_mapRemoteBranch.Keys)
            {
                if (_objGitMgr._objGitMgrCore.IsHeritFrom(m_oGitRepository.m_mapRemoteBranch[szRemoteItem], szSHA, _szWorkingDir))
                {
                    m_lbParentRefer.Items.Add(new CListBoxItem(szRemoteItem, 3));
                }
            }

            foreach (string szTagItem in m_oGitRepository.m_mapTag.Keys)
            {
                if (_objGitMgr._objGitMgrCore.IsHeritFrom(m_oGitRepository.m_mapTag[szTagItem], szSHA, _szWorkingDir))
                {
                    m_lbParentRefer.Items.Add(new CListBoxItem(szTagItem, 2));
                }
            }


            //update file change content
            //string[] ChangeList = _objGitMgr._objGitMgrCore.GetCommitChange("28fe6", "af70", _szWorkingDir);
            string[] ChangeList = _objGitMgr._objGitMgrCore.GetCommitChange(szSHA, szSHA + @"^1", _szWorkingDir);
            //first node, there's no change
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
                m_lvChangeFiles.FocusedItem = m_lvCommitsInfo.Items[0];
                m_lvChangeFiles.EnsureVisible(0);
            }
            
        }
                
        //refresh tab page(Tree) 
        private void RefreshGUI_CommitTree(string szSHA)
        {
            if (string.IsNullOrEmpty(szSHA))
            {
                m_tvFileTree.Nodes.Clear();
                m_rtxFileContent.Text = string.Empty;
                return;
            }

            m_tvFileTree.Nodes.Clear();
            m_tvFileTree.AddRoot(szSHA);


            Dictionary<string, string> mapTreeContent_objGitMgr = _objGitMgr._objGitMgrCore.GetTreeContent(szSHA, _szWorkingDir);
            if (mapTreeContent_objGitMgr != null && mapTreeContent_objGitMgr.Count <= 0)
                return;
            foreach (string szKey in mapTreeContent_objGitMgr.Keys)
            {
                string[] array = mapTreeContent_objGitMgr[szKey].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (array.Length != 2)
                {
                    Trace.Assert(false);
                    continue;
                }

                if (array[0].StartsWith(@"blob"))
                    m_tvFileTree.Add(m_tvFileTree.Nodes[0], array, szKey, false);
                else if (array[0].StartsWith(@"tree"))
                    m_tvFileTree.Add(m_tvFileTree.Nodes[0], array, szKey, true);
                else
                    continue;
            }
            m_tvFileTree.Nodes[0].Expand();
           
           

        }

        //refresh tab page(Tree) 
        private void RefreshGUI_FileHistory(string szSHA)
        {
            m_tvHistoryFileTree.Nodes.Clear();
            m_lvHistoryCommitInfo.Items.Clear();
            m_rtxHistoryLog.Clear();
            if (string.IsNullOrEmpty(szSHA))
            {
                return;
            }

            string szRoot = string.Format("{0}   --({1})", m_szWorkingDir, szSHA.Substring(0, 8));
            m_tvHistoryFileTree.AddRoot(szRoot);

            Dictionary<string, string> mapTreeContent_objGitMgr = _objGitMgr._objGitMgrCore.GetTreeContent(szSHA, _szWorkingDir);
            if (mapTreeContent_objGitMgr != null && mapTreeContent_objGitMgr.Count <= 0)
                return;
            foreach (string szKey in mapTreeContent_objGitMgr.Keys)
            {
                string[] array = mapTreeContent_objGitMgr[szKey].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (array.Length != 2)
                {
                    Trace.Assert(false);
                    continue;
                }

                if (array[0].StartsWith(@"blob"))
                    m_tvHistoryFileTree.Add(m_tvHistoryFileTree.Nodes[0], array, szKey, false);
                else if (array[0].StartsWith(@"tree"))
                    m_tvHistoryFileTree.Add(m_tvHistoryFileTree.Nodes[0], array, szKey, true);
                else
                    continue;
            }
            m_tvHistoryFileTree.Nodes[0].Expand();     

        }


        //reset focus item and keep it as visual
        private bool ResetCommitList(string szCommit)
        {
            foreach(ListViewItem item in m_lvCommitsInfo.Items)
            {
                if(item.Tag.ToString().StartsWith(szCommit))
                {
                    item.Focused = true;
                    item.Selected = true;                   
                    m_lvCommitsInfo.EnsureVisible(item.Index);
                    return true;
                }
            }
            return false;
        }

        //RefreshGUI(false);
        private void RefreshFilter()
        {
            RefreshGUI(false);
        }
        #endregion

        #region GUI Conrtoel Event function List========================================================================
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
                button.Text= szSelectPath;
                AysncRunLocalOpera(RefreshData);
                //RefreshData();  


            }

        }
        private void m_btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Repo_Filter FilterDlg = new Form_Repo_Filter(this);
                if( DialogResult.OK==FilterDlg.ShowDialog(this))
                {
                    AysncRunLocalOpera(RefreshFilter);         
                   // RefreshGUI(false);
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;

        }
        private void m_lvChangeFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (m_lvChangeFiles.FocusedItem == null)
                return;

           m_rtxChangeContent.Clear();
           string szTmp=m_lvChangeFiles.FocusedItem.Tag.ToString();
            
            //if (!(szTmp.StartsWith("M")||szTmp.StartsWith("A")||szTmp.StartsWith("d")  ))
            if (!(szTmp.StartsWith("M") || szTmp.StartsWith("R") ||szTmp.StartsWith("A") || szTmp.StartsWith("d")))
                return;   
   
            string szRes = _objGitMgr._objGitMgrCore.GetFileChange(m_txSelectedSHA.Text, m_txSelectedSHA.Text+"^", m_lvChangeFiles.FocusedItem.Text, _szWorkingDir);            
            m_rtxChangeContent.AppendText(szRes); 
            
            if(m_rtxChangeContent.Lines.Length<=0)
                return;

            
            int[] PositionList= new int[m_rtxChangeContent.Lines.Length];
            PositionList[0] = 0;
            for(int i=1;i<m_rtxChangeContent.Lines.Length;i++)
            {
                PositionList[i] = PositionList[i - 1] + m_rtxChangeContent.Lines[i - 1].Length+1;

                if(i>3)
                {
                    if (m_rtxChangeContent.Lines[i].StartsWith("+"))
                    {
                        m_rtxChangeContent.Select(PositionList[i], m_rtxChangeContent.Lines[i].Length);
                        m_rtxChangeContent.SelectionBackColor = Color.Fuchsia;
                    }  
                    else if (m_rtxChangeContent.Lines[i].StartsWith("-"))
                    {
                        m_rtxChangeContent.Select(PositionList[i], m_rtxChangeContent.Lines[i].Length);
                        m_rtxChangeContent.SelectionBackColor = Color.Gray;
                    }  
                }    
            }

        }
        private void m_tvFileTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (m_tvFileTree.SelectedNode.Tag == null)
                return;

            string[] ContentArray = (string[])m_tvFileTree.SelectedNode.Tag;
            string szSHA = ContentArray[1];
            if (ContentArray[0].StartsWith(@"blob"))
            {
                m_rtxFileContent.Clear();

                string szRes = _objGitMgr._objGitMgrCore.GetFileContent(ContentArray[1], _szWorkingDir);
                m_rtxFileContent.AppendText(szRes);
            }
        }
        private void m_tvFileTree_DoubleClick(object sender, EventArgs e)
        {
            if (m_tvFileTree.SelectedNode.Tag == null)
                return;

            string[] ContentArray=(string[])m_tvFileTree.SelectedNode.Tag;
            string szSHA = ContentArray[1];
            if(ContentArray[0].StartsWith(@"tree"))
            {
                //the children nodes have been added
                if(m_tvFileTree.SelectedNode.Nodes.Count>0)
                {
                    m_tvFileTree.SelectedNode.Expand();
                }
                else
                {
                    Dictionary<string, string> mapTreeContent_objGitMgr = _objGitMgr._objGitMgrCore.GetTreeContent(szSHA, _szWorkingDir);
                    if (mapTreeContent_objGitMgr != null && mapTreeContent_objGitMgr.Count <= 0)
                        return;
                    foreach (string szKey in mapTreeContent_objGitMgr.Keys)
                    {
                        string[] array = mapTreeContent_objGitMgr[szKey].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (array.Length != 2)
                        {
                            Trace.Assert(false);
                            continue;
                        }

                        if (array[0].StartsWith(@"blob"))
                            m_tvFileTree.Add(m_tvFileTree.SelectedNode, array, szKey, false);
                        else if (array[0].StartsWith(@"tree"))
                            m_tvFileTree.Add(m_tvFileTree.SelectedNode, array, szKey, true);
                        else
                            continue;
                    }
                    m_tvFileTree.SelectedNode.Expand();

                }
            }
        }
        private void lvCommitsInfo_SelectedIndexChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
           if (m_lvCommitsInfo.m_emOprType == CCommitsListView.OperationTyPe.MERGE
               ||m_lvCommitsInfo.m_emOprType == CCommitsListView.OperationTyPe.REBASE
               ||m_lvCommitsInfo.m_emOprType == CCommitsListView.OperationTyPe.COMPARE)
               return;         

            if (e.IsSelected == true)
            {
                //
                if(e.ItemIndex!=m_lvCommitsInfo.m_nOldSelectedValue)
                {
                    m_lvCommitsInfo.m_nOldSelectedValue = e.ItemIndex;
                }
                else
                {
                    return;
                }

                m_tabInfo.SelectedIndex = 0;
                string szSHA = e.Item.Tag.ToString();
                //async local operation  //by fengzheng
                ThreadPara ThreadStringParm = new ThreadPara();
                ThreadStringParm.szParam = szSHA;
                ThreadStringParm.ThreadFunc = RefreshGUI_Tab_AsyncLocal;
                AysncRunLocalOperaWithStringPara(ThreadStringParm);

                //
                m_lvCommitsInfo.EnsureVisible(e.ItemIndex);
            }            
        }
        private void m_lvCommitsInfo_SelectedIndexChanged(object sender, EventArgs e)
        {            
            
            //if(m_lvCommitsInfo.SelectedItems.Count>0)
            //{
            //    string szSHA = m_lvCommitsInfo.SelectedItems[0].Tag.ToString(); 
            //    ThreadPara ThreadStringParm = new ThreadPara();
            //    ThreadStringParm.szParam = szSHA;
            //    ThreadStringParm.ThreadFunc = RefreshGUI_Tab_AsyncLocal;
            //    AysncRunLocalOperaWithStringPara(ThreadStringParm);
            //}
        }


        //private void m_lvCommitsInfo_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if(e.Button==MouseButtons.Left)
        //    {
        //       ListViewItem item= m_lvCommitsInfo.GetItemAt(e.X,e.Y);
        //       if(item!=null&&item.Index>=0&&item.Index<m_lvCommitsInfo.Items.Count)
        //       {
        //           m_tabInfo.SelectedIndex = 0;

        //           string szSHA = item.Tag.ToString(); 
        //           ThreadPara ThreadStringParm = new ThreadPara();
        //           ThreadStringParm.szParam = szSHA;
        //           ThreadStringParm.ThreadFunc = RefreshGUI_Tab_AsyncLocal;
        //           AysncRunLocalOperaWithStringPara(ThreadStringParm);
        //       }
        //    }
        //    base.OnMouseClick(e);
        //}
        private void m_lbRelatedCommits_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string szTmp=m_lbRelatedCommits.SelectedItem.ToString();
            string szSHA = szTmp.Substring(1, 6);

            szSHA = _objGitMgr._objGitMgrCore.GetHashIDFrom(szSHA, _szWorkingDir);
            if (string.IsNullOrEmpty(szSHA))
                return;

            if(false==ResetCommitList(szSHA))
            {
                //Refresh tab page(Message) 
                RefreshGUI_CommitInfo(szSHA);

                //Refresh tab page(Tree) 
                RefreshGUI_CommitTree(szSHA);
            }
        }
        private void m_lbParentRefer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string szTmp = m_lbParentRefer.SelectedItem.ToString();

            string szSHA = _objGitMgr._objGitMgrCore.GetHashIDFrom(szTmp, _szWorkingDir);
            if (string.IsNullOrEmpty(szSHA))
                return;


            if (false == ResetCommitList(szSHA))
            {
                //Refresh tab page(Message) 
                RefreshGUI_CommitInfo(szSHA);

                //Refresh tab page(Tree) 
                RefreshGUI_CommitTree(szSHA);
            }

        }                    
        private void m_btnSearch_Click(object sender, EventArgs e)
        {
            foreach(int idx in m_oShowContent.mapSearchItms.Keys)
            {
                m_lvCommitsInfo.Items[idx].BackColor = m_oShowContent.mapSearchItms[idx];
            }
            m_oShowContent.mapSearchItms.Clear();
            if (string.IsNullOrEmpty(m_txSearch.Text))
            {
                return;
            }


            //Construct the filter condition for searching
            string szConidtions = @"--all";
            szConidtions = string.Format("{0} --grep=\"{1}\"", szConidtions, m_txSearch.Text);
            MatchCollection mcArray = _objGitMgr._objGitMgrCore.GetFilterCommits(szConidtions, _szWorkingDir);
            if (mcArray!=null)
            {
                for (int i = 0; i < mcArray.Count; i++)
                {
                    string szItem = mcArray[i].Value;

                    foreach (ListViewItem Item in m_lvCommitsInfo.Items)
                    {
                        if (Item.Tag.ToString().Contains(mcArray[i].Value))
                        {
                            if (false==m_oShowContent.mapSearchItms.ContainsKey(Item.Index))
                            {
                                m_oShowContent.mapSearchItms.Add(Item.Index,Item.BackColor);
                            }
                            Item.BackColor = Color.LightBlue;
                        }
                    }
                }
            }


            //Construct the filter condition for searching
            szConidtions = @"--all";
            szConidtions = string.Format("{0} --author=\"{1}\"", szConidtions, m_txSearch.Text);
            MatchCollection mcArray2 = _objGitMgr._objGitMgrCore.GetFilterCommits(szConidtions, _szWorkingDir);
            if (mcArray2 != null)
            {
                for (int i = 0; i < mcArray2.Count; i++)
                {
                    string szItem = mcArray2[i].Value;

                    foreach (ListViewItem Item in m_lvCommitsInfo.Items)
                    {
                        if (Item.Tag.ToString().Contains(mcArray2[i].Value))
                        {
                            if (false == m_oShowContent.mapSearchItms.ContainsKey(Item.Index))
                            {
                                m_oShowContent.mapSearchItms.Add(Item.Index, Item.BackColor);
                            }
                            Item.BackColor = Color.LightBlue;
                        }
                    }
                }
            }
 

            //update related tab page shown
            if (m_oShowContent.mapSearchItms.Count > 0)
            {
                foreach (int nId in m_oShowContent.mapSearchItms.Keys)
                {
                    RefreshGUI_CommitInfo(m_lvCommitsInfo.Items[nId].Tag.ToString());
                    RefreshGUI_CommitTree(m_lvCommitsInfo.Items[nId].Tag.ToString());
                    m_lvCommitsInfo.EnsureVisible(m_lvCommitsInfo.Items[nId].Index);
                    break;
                }
            }
            else
            {
                MessageBox.Show(this, "there's no matched commit,please check and retry", "Warning");
                return;
            }

        }
        private void m_btnSwitch_Click(object sender, EventArgs e)
        {
            if (m_oGitRepository.m_bIsValidCommite == false)
                return;

            try
            {
                Form_Repo_SwitchBranch SwitchDlg = new Form_Repo_SwitchBranch(this);
                string szBrName = m_szWorkingDir;

                SwitchDlg.InitTarget(szBrName,m_txCurrenBranch.Text);
                if (DialogResult.OK == SwitchDlg.ShowDialog(this))
                {
                    GetALLBranches();
                    RefreshReferMap();
                    RefreshGUI(false);
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_lvChangeFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (m_lvChangeFiles.FocusedItem == null)
                    return;
                string szTmp = m_lvChangeFiles.FocusedItem.Tag.ToString();
                if (!(szTmp.StartsWith("M") || szTmp.StartsWith("R") || szTmp.StartsWith("A") || szTmp.StartsWith("d")))
                    return;
                _objGitMgr._objGitMgrCore.CompareFileByExteranlTool(m_txSelectedSHA.Text, m_txSelectedSHA.Text + "^", m_lvChangeFiles.FocusedItem.Text, _szWorkingDir);
            }
        }
        private void m_tabFileHistoy_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txSelectedSHA.Text))
                return;
            RefreshGUI_FileHistory(m_txSelectedSHA.Text);
        }
        private void m_pageTree_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txSelectedSHA.Text))
                return;
            RefreshGUI_CommitTree(m_txSelectedSHA.Text);
        }


        //file history
        private void m_tvHistoryFileTree_DoubleClick(object sender, EventArgs e)
        {
            if (m_tvHistoryFileTree.SelectedNode.Tag == null)
                return;

            string[] ContentArray = (string[])m_tvHistoryFileTree.SelectedNode.Tag;
            string szSHA = ContentArray[1];
            if (ContentArray[0].StartsWith(@"tree"))
            {
                //the children nodes have been added
                if (m_tvHistoryFileTree.SelectedNode.Nodes.Count > 0)
                {
                    m_tvHistoryFileTree.SelectedNode.Expand();
                }
                else
                {
                    Dictionary<string, string> mapTreeContent_objGitMgr = _objGitMgr._objGitMgrCore.GetTreeContent(szSHA, _szWorkingDir);
                    if (mapTreeContent_objGitMgr != null && mapTreeContent_objGitMgr.Count <= 0)
                        return;
                    foreach (string szKey in mapTreeContent_objGitMgr.Keys)
                    {
                        string[] array = mapTreeContent_objGitMgr[szKey].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (array.Length != 2)
                        {
                            Trace.Assert(false);
                            continue;
                        }

                        if (array[0].StartsWith(@"blob"))
                            m_tvHistoryFileTree.Add(m_tvHistoryFileTree.SelectedNode, array, szKey, false);
                        else if (array[0].StartsWith(@"tree"))
                            m_tvHistoryFileTree.Add(m_tvHistoryFileTree.SelectedNode, array, szKey, true);
                        else
                            continue;
                    }
                    m_tvHistoryFileTree.SelectedNode.Expand();

                }
            }
        }
        private Dictionary<string, int> _mapFolloweList; 
        private void m_tvHistoryFileTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (m_tvHistoryFileTree.SelectedNode.Tag == null)
                return;

            string[] ContentArray = (string[])m_tvHistoryFileTree.SelectedNode.Tag;
            string szSHA = ContentArray[1];
            string szFileName = m_tvHistoryFileTree.SelectedNode.Text;
            int iLevel = m_tvHistoryFileTree.SelectedNode.Level;

            //get file name
            TreeNode Node=m_tvHistoryFileTree.SelectedNode;
            for (int n = 1; n < iLevel;n++ )
            {
                szFileName = string.Format("{0}/{1}", Node.Parent.Text, szFileName);
                Node = Node.Parent;
            }


            if (ContentArray[0].StartsWith(@"blob") == false)
            {
                return;
            }

            //show full history itmems
            m_lvHistoryCommitInfo.Items.Clear();                
            String[] HistoryList=_objGitMgr._objGitMgrCore.GetHistoryforSpecFile(szFileName, _szWorkingDir);
            if (HistoryList == null || HistoryList.Length<=0)  
            {
                return;
            }

            for (int i = 0; i < HistoryList.Length;i++ )
            {
                ListViewItem item = new ListViewItem(HistoryList[i], 0);
                item.Tag = null;
                if ((i% 2) == 1)
                    item.BackColor = Color.AliceBlue;
                else
                    item.BackColor = Color.AntiqueWhite;
                //item.SubItems.Add(m_oGitRepository.m_mapAllCommites[HistoryList[i]].szCommitMessage);
                item.SubItems.Add(m_oGitRepository.m_mapAllCommites[HistoryList[i]].szAutrhorName);
                item.SubItems.Add(m_oGitRepository.m_mapAllCommites[HistoryList[i]].szAutrhorDate);
                m_lvHistoryCommitInfo.Items.Add(item);
            }



            //show change history items;
            String[] ChangeList = _objGitMgr._objGitMgrCore.GetChangeCommitforSpecFile(szFileName, _szWorkingDir);
            if (ChangeList != null &&ChangeList.Length > 0)
            {
                for (int a = 0; a < m_lvHistoryCommitInfo.Items.Count;a++ )                
                {
                    for (int i = 0; i < ChangeList.Length; i++)
                    {
                        if(ChangeList[i].StartsWith(m_lvHistoryCommitInfo.Items[a].Text))
                        {
                            m_lvHistoryCommitInfo.Items[a].BackColor = Color.OrangeRed;
                            m_lvHistoryCommitInfo.Items[a].Tag = "change";
                            break;
                        }
                    }
                }
            }


            //get follow name history
            _mapFolloweList = _objGitMgr._objGitMgrCore.GetFollowforSpecFile(szFileName, _szWorkingDir);
        }
        private void m_lvHistoryCommitInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void m_lvHistoryCommitInfo_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected == false || _mapFolloweList == null || _mapFolloweList.Count<=0)
            {
                return;
            } 
            string szSHA = e.Item.Text;
            string szCurFileName=string.Empty;
            m_rtxHistoryLog.Clear();
            m_rtxHistoryLog.ForeColor = Color.LimeGreen;


            //show current file name;
            bool bIsExist=false;
            foreach (string azFollowName in _mapFolloweList.Keys)
            {
                if(_objGitMgr._objGitMgrCore.IsFileExist(szSHA,azFollowName,_szWorkingDir))
                {
                    szCurFileName=azFollowName;
                    bIsExist=true;
                    m_rtxHistoryLog.AppendText(string.Format("History Name: {0}",azFollowName)+Environment.NewLine);
                    break;
                }
            }
            if(bIsExist==false)
            {
                m_rtxHistoryLog.AppendText(@"History Name: <Null>(Deleted or Renamed)" + Environment.NewLine);
            }

            //show change information
            if(e.Item.Tag!=null) 
            {
                foreach (string azFollowName in _mapFolloweList.Keys)
                {
                    string szRes = _objGitMgr._objGitMgrCore.GetFileChangeFromTree(szSHA, szSHA + @"^1", azFollowName, _szWorkingDir);
                    if (string.IsNullOrEmpty(szRes))
                        continue;
                    m_rtxHistoryLog.AppendText(szRes + Environment.NewLine);
                    break;
                }            
            }
            m_rtxHistoryLog.AppendText("--------------------------Log Message--------------------------" + Environment.NewLine);

            if (m_oGitRepository.m_mapAllCommites.ContainsKey(e.Item.Text))
            {
                m_rtxHistoryLog.AppendText(m_oGitRepository.m_mapAllCommites[e.Item.Text].szCommitMessage + Environment.NewLine);
            }
                        

            //show content of selected file
            if(string.IsNullOrEmpty(szCurFileName))
                return;
            string szRetrun =_objGitMgr._objGitMgrCore.GetFileContent(szSHA, szCurFileName, _szWorkingDir);
            //if(false==string.IsNullOrEmpty(szRetrun))
            {
                m_rtxHistoryLog.AppendText("--------------------------File Content--------------------------" + Environment.NewLine);
                m_rtxHistoryLog.SelectAll();
                m_rtxHistoryLog.SelectionColor = Color.Fuchsia;
                m_rtxHistoryLog.AppendText(szRetrun);
            } 

        }
        private void m_lvHistoryCommitInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string szTargetSHA = m_lvHistoryCommitInfo.FocusedItem.Text;
            string szSourceSHA = m_lvHistoryCommitInfo.m_szSourceSHA;
            string szSourceFile = m_lvHistoryCommitInfo.m_szSourceFile;


            if (m_lvHistoryCommitInfo.m_emOprType == CCommitsListView.OperationTyPe.COMPARE)
            {
                m_lvHistoryCommitInfo.m_emOprType = CCommitsListView.OperationTyPe.UNKNOWN;
                m_lvHistoryCommitInfo.m_szSourceSHA = string.Empty;
                m_lvHistoryCommitInfo.m_szSourceFile = string.Empty;
                m_lvHistoryCommitInfo.m_szTargetSHA = string.Empty;
                m_lvHistoryCommitInfo.m_szTargetFile = string.Empty;

                _objGitMgr._objGitMgrCore.CompareFileByExteranlTool(szSourceSHA, szTargetSHA, szSourceFile, _szWorkingDir);
            }
        }   
        #endregion



        #region Context Menu Event function List========================================================================

        private void m_MIM_CheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Repo_CheckOut CheckOutDlg = new Form_Repo_CheckOut(this);
                string szSHA = m_lvCommitsInfo.FocusedItem.Tag.ToString();
                CheckOutDlg.InitTarget(szSHA);
                if (DialogResult.OK == CheckOutDlg.ShowDialog(this))
                {
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_MIM_AddBranch_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Repo_AddBranch AddBranchDlg = new Form_Repo_AddBranch(this);
                string szSHA = m_lvCommitsInfo.FocusedItem.Tag.ToString();
                AddBranchDlg.InitTarget(szSHA);
                if (DialogResult.OK == AddBranchDlg.ShowDialog(this))
                {
                    GetALLBranches();
                    RefreshReferMap();
                    RefreshGUI(false);
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_MIM_SwitchBranch_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Repo_SwitchBranch SwitchDlg = new Form_Repo_SwitchBranch(this);
                string szSHA = m_lvCommitsInfo.FocusedItem.Tag.ToString();
                string szBrName = string.Empty;
                foreach (string szItm in m_oGitRepository.m_mapLocalBranch.Keys)
                {                    
                    if(m_oGitRepository.m_mapLocalBranch[szItm].Equals(szSHA))
                    {
                        szBrName = szItm;
                        break;
                    }
                }
                if(string.IsNullOrEmpty(szBrName))
                {
                    MessageBox.Show(this, "This commit is not a branch HEAD", "Warning");
                    return;
                }

                SwitchDlg.InitTarget(szBrName, m_txCurrenBranch.Text);
                if (DialogResult.OK == SwitchDlg.ShowDialog(this))
                {
                    GetALLBranches();
                    RefreshGUI(false);
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_MIM_AddTag_Click(object sender, EventArgs e)
        {
            try
            {
                string szSHA = m_lvCommitsInfo.FocusedItem.Tag.ToString();
                Form_Repo_AddTag AddTagDlg = new Form_Repo_AddTag(this);
                AddTagDlg.InitTarget(szSHA);
                if (DialogResult.OK == AddTagDlg.ShowDialog(this))
                {
                    GetALLTags();
                    RefreshReferMap();
                    RefreshGUI(false);
                    //RefreshGUIforOneCommit(szSHA);
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_MIM_RemoveTag_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Repo_RemoveTag FilterDlg = new Form_Repo_RemoveTag(this);
                if (DialogResult.OK == FilterDlg.ShowDialog(this))
                {
                    GetALLTags();
                    RefreshReferMap();
                    RefreshGUI(false);
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_MIM_RemoveBranch_Click(object sender, EventArgs e)
        {
            try
            {
                //operation is only for local branch, remote branch will be exluded
                Form_Repo_RemoveBranch RemoveBrDlg = new Form_Repo_RemoveBranch(this);
                if (DialogResult.OK == RemoveBrDlg.ShowDialog(this))
                {
                    GetALLBranches();
                    RefreshReferMap();
                    RefreshGUI(false);
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_MIM_MergeTo_Click(object sender, EventArgs e)
        {
            m_lvCommitsInfo.m_emOprType = CCommitsListView.OperationTyPe.MERGE;
            m_lvCommitsInfo.m_szSourceSHA= m_lvCommitsInfo.FocusedItem.Tag.ToString();
            m_lvCommitsInfo.m_szTargetSHA = string.Empty;            
            return;
        }
        private void m_MIM_RebaseTo_Click(object sender, EventArgs e)
        {
            string szSourceBranch = string.Empty;
            string szSourceSHA = m_lvCommitsInfo.FocusedItem.Tag.ToString();
            foreach (string szBranch in m_oGitRepository.m_mapLocalBranch.Keys)
            {
                if (m_oGitRepository.m_mapLocalBranch[szBranch].Equals(szSourceSHA))
                {
                    szSourceBranch = szBranch;
                    break;
                }
            }
            if (string.IsNullOrEmpty(szSourceBranch))
            {
                MessageBox.Show(this, "This Commit is not a Branch Head.", "Warning");
                return;
            }

            m_lvCommitsInfo.m_emOprType = CCommitsListView.OperationTyPe.REBASE;
            m_lvCommitsInfo.m_szSourceSHA = szSourceSHA;
            m_lvCommitsInfo.m_szTargetSHA = string.Empty;
        }

        private void m_lvCommitsInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //tell whether there's a second step operation, then run it
            ExecuteFollowedOper();
        }
        private void ExecuteFollowedOper()
        {                
            string szTargetSHA = m_lvCommitsInfo.FocusedItem.Tag.ToString();
            string szSourceSHA = m_lvCommitsInfo.m_szSourceSHA;
            string szTargetBranch=string.Empty;
            foreach (string szBranch in m_oGitRepository.m_mapLocalBranch.Keys)            
            {
                if(m_oGitRepository.m_mapLocalBranch[szBranch].Equals(szTargetSHA))
                {
                    szTargetBranch = szBranch;
                    break;
                }
            }
            if (string.IsNullOrEmpty(szTargetBranch))
            {
                MessageBox.Show(this, "This Commit is not a Branch Head.", "Warning");
                return ;
            }

            if (m_lvCommitsInfo.m_emOprType == CCommitsListView.OperationTyPe.MERGE)
            {
                m_lvCommitsInfo.m_emOprType = CCommitsListView.OperationTyPe.UNKNOWN;
                m_lvCommitsInfo.m_szSourceSHA = string.Empty;
                m_lvCommitsInfo.m_szTargetSHA = string.Empty;
                
                try
                {
                    Form_Repo_MergeTo MergeDlg = new Form_Repo_MergeTo(this);
                    MergeDlg.InitTarget(szTargetSHA, szSourceSHA, szTargetBranch);
                    if (DialogResult.OK == MergeDlg.ShowDialog(this))
                    {
                        AysncRunLocalOpera(RefreshData);
                        //RefreshData();
                        //RefreshGUI(false);
                    }
                }
                catch
                {
                    Debug.Assert(false);
                }
            }
            else if(m_lvCommitsInfo.m_emOprType == CCommitsListView.OperationTyPe.REBASE)
            {
                m_lvCommitsInfo.m_emOprType = CCommitsListView.OperationTyPe.UNKNOWN;
                m_lvCommitsInfo.m_szSourceSHA = string.Empty;
                m_lvCommitsInfo.m_szTargetSHA = string.Empty;

                try
                {
                    Form_Repo_RebaseTo RebaseDlg = new Form_Repo_RebaseTo(this);
                    RebaseDlg.InitTarget(szTargetSHA, szSourceSHA);
                    if (DialogResult.OK == RebaseDlg.ShowDialog(this))
                    {
                        RefreshData();
                        RefreshGUI(false);
                    }
                }
                catch
                {
                    Debug.Assert(false);
                }
            }
            //
        }

        private void m_MIM_CherryPick_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Repo_CherryPickTo FilterDlg = new Form_Repo_CherryPickTo(this);
                if (DialogResult.OK == FilterDlg.ShowDialog(this))
                {
                    AysncRunLocalOpera(RefreshData);
                    //RefreshData();
                    //RefreshGUI(false);
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_MIM_Revert_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Repo_Revert FilterDlg = new Form_Repo_Revert(this);
                if (DialogResult.OK == FilterDlg.ShowDialog(this))
                {
                    AysncRunLocalOpera(RefreshData);
                    //RefreshData();
                    //RefreshGUI(false);
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_MIM_ResetCommit_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Repo_Reset ResetDlg = new Form_Repo_Reset(this);
                string szSHA = m_lvCommitsInfo.FocusedItem.Tag.ToString();
                ResetDlg.InitTarget(szSHA);
                if (DialogResult.OK == ResetDlg.ShowDialog(this))
                {
                    AysncRunLocalOpera(RefreshData);
                    //RefreshData();
                    //RefreshGUI(false);
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;
        }

        private void m_MIM_RestoreHistory_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Repo_RestoreHistory RestoreDlg = new Form_Repo_RestoreHistory(this);
                //string szSHA = m_lvCommitsInfo.FocusedItem.Tag.ToString();
                //RestoreDlg.InitTarget(szSHA);
                if (DialogResult.OK == RestoreDlg.ShowDialog(this))
                {
                    AysncRunLocalOpera(RefreshData);
                    //RefreshData();
                    //RefreshGUI(false);
                }
            }
            catch
            {
                Debug.Assert(false);
            }
            return;



        }

        private void m_MIM_ExternalCompare_Click(object sender, EventArgs e)
        {
            if (m_lvChangeFiles.FocusedItem == null)
                return;
            string szTmp = m_lvChangeFiles.FocusedItem.Tag.ToString();
            if (!(szTmp.StartsWith("M") || szTmp.StartsWith("R") || szTmp.StartsWith("A") || szTmp.StartsWith("d")))
                return;
            _objGitMgr._objGitMgrCore.CompareFileByExteranlTool(m_txSelectedSHA.Text, m_txSelectedSHA.Text + "^", m_lvChangeFiles.FocusedItem.Text, _szWorkingDir);

        }

        private void m_MIM_FileHistory_Click(object sender, EventArgs e)
        {
            m_tabInfo.SelectTab("m_tabFileHistoy");
            return;
        }

        private void m_MIM_ExportFile_Click(object sender, EventArgs e)
        {
            if (m_tvFileTree.SelectedNode.Tag == null)
                return;

            string[] ContentArray = (string[])m_tvFileTree.SelectedNode.Tag;
            string szBlobSHA = ContentArray[1];
            if (ContentArray[0].StartsWith(@"blob"))
            {
                string szExtention = CHelpFuntions.GetFileExtension(m_tvFileTree.SelectedNode.Text);
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.DefaultExt = szExtention;
                fileDialog.Filter =
                    "Current format (*." + szExtention + ")|*." + szExtention +
                    "|All files (*.*)|*.*";
                fileDialog.FileName = m_tvFileTree.SelectedNode.Text;
                fileDialog.AddExtension = true;
                fileDialog.RestoreDirectory = true;
                fileDialog.InitialDirectory = _szWorkingDir;
                ///fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                if (fileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (_objGitMgr._objGitMgrCore.SaveFileAs(szBlobSHA, fileDialog.FileName,_szWorkingDir))
                    {
                        MessageBox.Show(this, "File has been saved successfully.", null);
                    }
                }
            }
        }

        private void m_MIM_FileHisotry2_Click(object sender, EventArgs e)
        {
            m_tabInfo.SelectTab("m_tabFileHistoy");
            return;
        }

        //menu 2
        private void m_MIM_HistorySaveAs_Click(object sender, EventArgs e)
        {
            string szSHA = m_lvHistoryCommitInfo.FocusedItem.Text;
            string szFileName = string.Empty;
            foreach (string szFollowName in _mapFolloweList.Keys)
            {
                if (_objGitMgr._objGitMgrCore.IsFileExist(szSHA, szFollowName, _szWorkingDir))
                {
                    szFileName = szFollowName;
                    break;
                }
            }
            if (string.IsNullOrEmpty(szFileName) || string.IsNullOrEmpty(szSHA))
            {
                return;
            }

            string szFullName = szFileName.Replace('/','\\');
            szFullName=_szWorkingDir+szFullName;
            string szExtention=CHelpFuntions.GetFileExtension(szFullName);


            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.DefaultExt = szExtention;
            fileDialog.Filter =
                "Current format (*." + szExtention + ")|*." + szExtention +
                "|All files (*.*)|*.*";
            fileDialog.FileName = szFullName;
            fileDialog.AddExtension = true;
            fileDialog.RestoreDirectory = true;
            fileDialog.InitialDirectory = _szWorkingDir;
            ///fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            if (fileDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (_objGitMgr._objGitMgrCore.SaveFileAs(szSHA, fileDialog.FileName, szFileName, _szWorkingDir))
                {
                    MessageBox.Show(this, "File has been saved successfully.", null); 
                }
            }

            return;
        }

        private void m_MIM_HistoryCompare_Click(object sender, EventArgs e)
        {
            string szSHA = m_lvHistoryCommitInfo.FocusedItem.Text;
            string szFileName = string.Empty;
            foreach (string szFollowName in _mapFolloweList.Keys)
            {
                if (_objGitMgr._objGitMgrCore.IsFileExist(szSHA, szFollowName, _szWorkingDir))
                {
                    szFileName = szFollowName;
                    break;
                }
            }
            if (string.IsNullOrEmpty(szFileName) || string.IsNullOrEmpty(szSHA))
            {
                return;
            }

            m_lvHistoryCommitInfo.m_emOprType = CCommitsListView.OperationTyPe.COMPARE;
            m_lvHistoryCommitInfo.m_szSourceSHA = szSHA;
            m_lvHistoryCommitInfo.m_szSourceFile = szFileName;
            m_lvHistoryCommitInfo.m_szTargetSHA = string.Empty;
            m_lvHistoryCommitInfo.m_szTargetFile= string.Empty;
            return;

        }

        //menu 3
        private void m_contextMenu_Commit_Opened(object sender, EventArgs e)
        {
            if (m_lvCommitsInfo.Items.Count <= 0 || m_lvCommitsInfo.FocusedItem == null)
            {
                m_contextMenu_Commit.Enabled = false;
            }
        }

        private void m_contextMenu_File_Opening(object sender, CancelEventArgs e)
        {
            if (m_lvChangeFiles.Items.Count <= 0 || m_lvChangeFiles.FocusedItem == null)
            {
                m_contextMenu_File.Enabled = false;
            }
            else
            {
                m_contextMenu_File.Enabled = true;
            }
        }

        private void m_contextMenu_Tree_Opening(object sender, CancelEventArgs e)
        {
            if (m_tvFileTree.Nodes.Count <= 0 || m_tvFileTree.SelectedNode == null)
            {
                m_contextMenu_Tree.Enabled = false;
            }
            else
            {
                m_contextMenu_Tree.Enabled = true;
            }
        }

        private void m_contextMenu_History_Opening(object sender, CancelEventArgs e)
        {
            if (m_tvHistoryFileTree.Nodes.Count <= 0 || m_tvHistoryFileTree.SelectedNode == null)
            {
                m_contextMenu_History.Enabled = false;
            }
            else
            {
                m_contextMenu_History.Enabled = true;
            }
        }

        #endregion



































    }




}
