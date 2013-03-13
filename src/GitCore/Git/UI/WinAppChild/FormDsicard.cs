using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Git.Manager;
using Git.Core.Commands;
using Git.Core.Helper;

namespace Git.UI
{
    public partial class FormDsicard : Form
    {
        CGitManager _objGitMgr = null;
        string _szSolutionName = null;
        Hashtable _hashAllFiles= null;
        List<string> _lstAllFiles = null;
        bool bUsShortFileName = false;
        string _szWorkingDir = string.Empty;
        private List<string> UnStageedFiles;
        private List<string> StageedFiles;


        public FormDsicard(string szSolutionName, List<string> FileList, CGitManager objGitMgr)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szSolutionName = szSolutionName;
            _lstAllFiles = FileList;

            _hashAllFiles = new Hashtable();
            foreach (string szItem in FileList)
            {
                FileSccStatus status = _objGitMgr.GetFileStatus(szItem);
                if (status==FileSccStatus.ST_NEW_STAGED||status==FileSccStatus.ST_STAGE_MODIFIED)
                {
                    _hashAllFiles.Add(szItem,"Index");
                }
                else if(status==FileSccStatus.ST_CHECKIN_MODIFIED)
                {
                    _hashAllFiles.Add(szItem,"Repos");
                }
                else if (status==FileSccStatus.ST_MODIFY_STAGED_MODIFY||status==FileSccStatus.ST_MODIFY_STAGED)
                {
                    _hashAllFiles.Add(szItem, "Both");
                }                            
                else
                {
                    continue;
                }
            }
            if (_hashAllFiles.Count <= 0)
                bUsShortFileName = true;


        }


        #region GUI Evnent functions
        private void m_btnDiscard_Click(object sender, EventArgs e)
        {
            List<string> SelFileList=new List<string>();
            for (int i = 0; i < m_clbFilelist.CheckedItems.Count; i++)
            {
                string szShortFileName = m_clbFilelist.CheckedItems[i].ToString();
                SelFileList.Add(szShortFileName);
            }
            //if (bUsShortFileName == false)
            //    SelFileList = GetSelectedFiles();
            //else
            //    SelFileList = _lstAllFiles;


            if (SelFileList.Count == 0 || _szSolutionName.Equals(string.Empty))
            {
                return;
            }

            try
            {
                if (this.m_radioToRepositroy.Checked == true)
                {
                    _objGitMgr._objGitMgrCore.Discard(_szSolutionName, SelFileList, true);
                }
                else
                {
                    _objGitMgr._objGitMgrCore.Discard(_szSolutionName, SelFileList, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshDataAndGUI();
            //Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FormDsicard_Load(object sender, EventArgs e)
        {
            m_clbFilelist.Items.Clear();
            _szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            if (string.IsNullOrEmpty(_szWorkingDir))
                return;
            RefreshDataAndGUI();
        }
        private void m_radioToRepositroy_CheckedChanged(object sender, EventArgs e)
        {
            m_clbFilelist.Items.Clear();
            UnStageedFiles = _objGitMgr._objGitMgrCore.GetAllWorkingAreaChange(_szWorkingDir);
            StageedFiles = _objGitMgr._objGitMgrCore.GetAllIndexChange(_szWorkingDir);

            if (UnStageedFiles != null && UnStageedFiles.Count > 0)
            {
                foreach (string szItem in UnStageedFiles)
                {
                    string szFileName = szItem.Substring(4);
                    m_clbFilelist.Items.Add(szFileName);
                }
            }
            if (StageedFiles != null && StageedFiles.Count > 0)
            {
                foreach (string szItem in StageedFiles)
                {
                    string szFileName = szItem.Substring(4);
                    if (m_clbFilelist.Items.Contains(szFileName) == false)
                    {
                        m_clbFilelist.Items.Add(szFileName);
                    }
                }
            }

            foreach (string szItme in _lstAllFiles)
            {
                string szShortFilePath = CHelpFuntions.GetShortFileName(_szWorkingDir, szItme);
                if (string.IsNullOrEmpty(szShortFilePath))
                    continue;

                int nIdx = m_clbFilelist.Items.IndexOf(szShortFilePath);
                if (nIdx >= 0)
                {
                    m_clbFilelist.SetItemChecked(nIdx, true);
                }
            }
        }
        private void m_radioToStaged_CheckedChanged(object sender, EventArgs e)
        {
            m_clbFilelist.Items.Clear();
            StageedFiles = _objGitMgr._objGitMgrCore.GetAllIndexChange(_szWorkingDir);
            if (StageedFiles != null && StageedFiles.Count > 0)
            {
                foreach (string szItem in StageedFiles)
                {
                    string szFileName = szItem.Substring(4);
                    m_clbFilelist.Items.Add(szFileName);
                }
            }

            foreach (string szItme in _lstAllFiles)
            {
                string szShortFilePath = CHelpFuntions.GetShortFileName(_szWorkingDir, szItme);
                if (string.IsNullOrEmpty(szShortFilePath))
                    continue;

                int nIdx = m_clbFilelist.Items.IndexOf(szShortFilePath);
                if (nIdx >= 0)
                {
                    m_clbFilelist.SetItemChecked(nIdx, true);
                }
            }
        }

        #endregion

        #region GUI Show Functions
        private void RefreshDataAndGUI()
        {
            string[] szBranches = _objGitMgr._objGitMgrCore.GetBranch(false, _szWorkingDir);
            if (szBranches != null && szBranches.Length > 0)
            {
                m_txCurrenBranch.Text = szBranches[0];
            }
            else
            {
                m_txCurrenBranch.Clear();
            }



            //add initialzie file lists
            m_clbFilelist.Items.Clear();
            UnStageedFiles = _objGitMgr._objGitMgrCore.GetAllWorkingAreaChange(_szWorkingDir);
            StageedFiles = _objGitMgr._objGitMgrCore.GetAllIndexChange(_szWorkingDir);

            if (UnStageedFiles != null && UnStageedFiles.Count > 0)
            {
                foreach (string szItem in UnStageedFiles)
                {
                    string szFileName = szItem.Substring(4);
                    m_clbFilelist.Items.Add(szFileName);
                }
            }
            if (StageedFiles != null && StageedFiles.Count > 0)
            {
                foreach (string szItem in StageedFiles)
                {
                    string szFileName = szItem.Substring(4);
                    if (m_clbFilelist.Items.Contains(szFileName) == false)
                    {
                        m_clbFilelist.Items.Add(szFileName);
                    }
                }
            }

            //checked selected files
            foreach (string szItme in _lstAllFiles)
            {
                string szShortFilePath = CHelpFuntions.GetShortFileName(_szWorkingDir, szItme);
                if (string.IsNullOrEmpty(szShortFilePath))
                    continue;
                
                int nIdx = m_clbFilelist.Items.IndexOf(szShortFilePath);
                if (nIdx >= 0)
                {
                    m_clbFilelist.SetItemChecked(nIdx, true);
                }
            }

        }
        #endregion


        #region Git Operation Help Functions
        //Get selected item from checklist,code need to be modified later       --by fengzheng
        private List<string> GetSelectedFiles()
        {
            List<string> FileList = new List<string>();

            foreach (DictionaryEntry item in _hashAllFiles)
            {
                if (m_radioToRepositroy.Checked == true && (item.Value.Equals("Repos")|| item.Value.Equals("Both")))
                {
                    FileList.Add(item.Key as string);
                }
                else if (m_radioToRepositroy.Checked == false && (item.Value.Equals("Index")|| item.Value.Equals("Both")))
                {
                    FileList.Add(item.Key as string);
                }
                else
                    continue;
            }
            return FileList;
        }
        #endregion
        private void m_btnRevertAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < m_clbFilelist.CheckedItems.Count; i++)
            {
                if (m_clbFilelist.Items.Count <= 0)
                    return;
                try
                {
                    if (this.m_radioToRepositroy.Checked == true)
                    {
                        _objGitMgr._objGitMgrCore.DiscardAll(_szSolutionName,true);
                    }
                    else
                    {
                        _objGitMgr._objGitMgrCore.DiscardAll(_szSolutionName,false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshDataAndGUI();
            }
        }

    }
}
