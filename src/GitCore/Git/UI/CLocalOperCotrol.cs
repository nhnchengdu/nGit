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



namespace Git.UI
{
    public partial class CLocalOperCotrol : CGitAsynchControl
    {
        private List<string> UnStageedFiles;
        private List<string> StageedFiles;

        public CLocalOperCotrol()
        {
            InitializeComponent();
        }

        private void CLocalOperCotrol_Load(object sender, EventArgs e)
        {
            m_lbStagedFile.Items.Clear();
            m_lbUnstagFile.Items.Clear();
            if(string.IsNullOrEmpty(_szWorkingDir))
            {
                return;
            }     
            if(!_objGitMgr._objGitMgrCore.IsValidGitWorkingDir(_szWorkingDir))
            {
                return;
            }
            m_btnCurrentRepository.Text = _szWorkingDir;  
            RefreshDataAndGUI();      
        }
        private void RefreshDataAndGUI()
        {
            // List<string> GetAllWorkingAreaChange(string szSolutionName)
            m_clbStashList.Items.Clear();
            m_lbStagedFile.Items.Clear();
            m_lbUnstagFile.Items.Clear();
            m_rtxworkingChange.Clear();
            m_rtxIndexChange.Clear();
     
            string[] szBranches=_objGitMgr._objGitMgrCore.GetBranch(false,_szWorkingDir);
            if(szBranches!=null && szBranches.Length>0)
            {
                m_txCurrenBranch.Text = szBranches[0];
            }
            else
            {
                m_txCurrenBranch.Clear();
            }


            UnStageedFiles = _objGitMgr._objGitMgrCore.GetAllWorkingAreaChange(_szWorkingDir);
            StageedFiles = _objGitMgr._objGitMgrCore.GetAllIndexChange(_szWorkingDir);
            string[] ProcessList = _objGitMgr._objGitMgrCore.ProcessGetList(_szWorkingDir);
            string[] UntrackedFiles = _objGitMgr._objGitMgrCore.GetAllUntracked(_szWorkingDir);



            if (ProcessList != null && ProcessList.Length > 0)
            {
                m_clbStashList.Items.AddRange(ProcessList);
            }
            if (UntrackedFiles != null && UntrackedFiles.Length>0)
            {
                foreach (string szItem in UntrackedFiles)
                {
                    m_lbUnstagFile.Items.Add("( ) " + szItem);
                }
            }
            if (UnStageedFiles != null && UnStageedFiles.Count > 0)
            {
                foreach (string szItem in UnStageedFiles)
                {
                    m_lbUnstagFile.Items.Add(szItem);
                }
            }

            if (StageedFiles != null && StageedFiles.Count > 0)
            {
                foreach (string szItem in StageedFiles)
                {
                    m_lbStagedFile.Items.Add(szItem);
                }
            }

        }

        #region Context Menu Event function List========================================================================
        private void m_MIM_SaveProgress_Click(object sender, EventArgs e)
        {
            try
            {
                new FormStash(_szWorkingDir, _objGitMgr).ShowDialog(this);
            }
            catch
            {
            }
            RefreshDataAndGUI();
        }

        private void m_MIM_RestoreProgress_Click(object sender, EventArgs e)
        {
            try
            {
                new FormStash(_szWorkingDir, _objGitMgr).ShowDialog(this);
            }
            catch
            {
            }
            RefreshDataAndGUI();
        }

        private void m_MIM_Restore2NewBranch_Click(object sender, EventArgs e)
        {
            //Form_Local_BranchOnProgress form = new Form_Local_BranchOnProgress();
            //form.ShowDialog();
            try
            {
                new FormStash(_szWorkingDir, _objGitMgr).ShowDialog(this);
            }
            catch
            {
            }
            RefreshDataAndGUI();
        }

        private void m_MIM_RemoveProgress_Click(object sender, EventArgs e)
        {
            try
            {
                new FormStash(_szWorkingDir, _objGitMgr).ShowDialog(this);
            }
            catch
            {
            }
            RefreshDataAndGUI();
        }

        private void m_MIM_ClearProgress_Click(object sender, EventArgs e)
        {
            try
            {
                new FormStash(_szWorkingDir, _objGitMgr).ShowDialog(this);
            }
            catch
            {
            }
            RefreshDataAndGUI();
        }
        #endregion
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

                RefreshDataAndGUI();
            }
        }
        private void m_MIM_Ignore_Click(object sender, EventArgs e)
        {
            try
            {
                new Ignore(_szWorkingDir, _objGitMgr).ShowDialog(this);
            }
            catch
            {
               return;
            }
            RefreshDataAndGUI();    
        }
        private void m_MIM_AddToAttract_Click(object sender, EventArgs e)
        {
            if (m_lbUnstagFile.Items.Count <= 0)
                return;
            int nCheckedNum = m_lbUnstagFile.CheckedItems.Count;
            if (nCheckedNum <= 0)
               return;

            string[] FileList = new string[nCheckedNum];
            for(int i=0;i<nCheckedNum;i++)
            {
                string szItm = m_lbUnstagFile.CheckedItems[i].ToString();
                szItm = szItm.Substring(4, szItm.Length - 4);
                FileList[i] = szItm;
            }
            if (_objGitMgr._objGitMgrCore.AddFiles(FileList, _szWorkingDir))
            {
                MessageBox.Show(this, "Successful: add selected files into Index area", "Success");
                RefreshDataAndGUI();
            }
            else
            {
                MessageBox.Show(this, "Failed: add selected files into Index area", "Failed");
            }
        }
        private void m_MIM_AddAll_Click(object sender, EventArgs e)
        {
            if (m_lbUnstagFile.Items.Count <= 0)
                return;

            var result = MessageBox.Show(this, "Maybe some new files will be added into index area, will you continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            string[] FileList = new string[1];
            FileList[0] = ".";

            if (_objGitMgr._objGitMgrCore.AddFiles(FileList, _szWorkingDir))
            {
                MessageBox.Show(this, "Successful: add all files into Index area", "Success");
                RefreshDataAndGUI();
            }
            else
            {
                MessageBox.Show(this, "Failed: add all files into Index area", "Failed");
            }

        }

        private void m_MIM_Commit_Click(object sender, EventArgs e)
        {
            if (StageedFiles == null || StageedFiles.Count <= 0)
                return;

            try
            {
                new FormCommit(_szWorkingDir, StageedFiles, _objGitMgr).ShowDialog(this);
            }
            catch
            {

            }
            RefreshDataAndGUI();
        }

        private void m_MIM_Discard_Click(object sender, EventArgs e)
        {
            if (m_lbStagedFile.Items.Count <= 0)
                return;

            int nCheckedNum = m_lbStagedFile.CheckedItems.Count;
            if(nCheckedNum<=0)
                return;

            List<string> SelectedFileList=new List<string>();
            for (int i = 0; i < nCheckedNum; i++)
            {
                string szItm = m_lbStagedFile.CheckedItems[i].ToString();
                szItm = szItm.Substring(4, szItm.Length - 4);
                SelectedFileList.Add(szItm);
            }

            if (_objGitMgr._objGitMgrCore.ResetIndex(SelectedFileList, _szWorkingDir))
            {
                RefreshDataAndGUI();
            }
            else
            {
                RefreshDataAndGUI();
            }

        }

        private void m_MIM_Remove_Click(object sender, EventArgs e)
        {
            if (m_lbStagedFile.Items.Count <= 0)
                return;

            if (_objGitMgr._objGitMgrCore.ResetIndex(null, _szWorkingDir))
            {
                RefreshDataAndGUI();
            }
            else
            {
                RefreshDataAndGUI();
            }
        }

        private void m_lbUnstagFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_rtxworkingChange.Clear();
            m_rtxIndexChange.Clear();
            if (m_lbUnstagFile.SelectedItem == null)
                return;                

            string szShortFileName = m_lbUnstagFile.SelectedItem.ToString();
            szShortFileName = szShortFileName.Substring(4, szShortFileName.Length - 4);
            if (string.IsNullOrEmpty(szShortFileName))
                return;


            string szRes = _objGitMgr._objGitMgrCore.GetFileChange_WR(szShortFileName, _szWorkingDir);
            m_rtxworkingChange.AppendText(szRes);

            DecoreateWR();

            foreach (object item in m_lbStagedFile.Items)
            {
                string szItemName = item.ToString();
                szItemName = szItemName.Substring(4, szItemName.Length - 4);
                if (szShortFileName.Equals(szItemName))
                {
                    szRes = _objGitMgr._objGitMgrCore.GetFileChange_IR(szShortFileName, _szWorkingDir);
                    m_rtxIndexChange.AppendText(szRes);
                    DecoreateIR();
                    break;
                }
            }
        }
        private void DecoreateWR()
        {
            if (m_rtxworkingChange.Lines.Length <= 0)
                return;

            int[] PositionList = new int[m_rtxworkingChange.Lines.Length];
            PositionList[0] = 0;
            for (int i = 1; i < m_rtxworkingChange.Lines.Length; i++)
            {
                PositionList[i] = PositionList[i - 1] + m_rtxworkingChange.Lines[i - 1].Length + 1;

                if (i > 3)
                {
                    if (m_rtxworkingChange.Lines[i].StartsWith("+"))
                    {
                        m_rtxworkingChange.Select(PositionList[i], m_rtxworkingChange.Lines[i].Length);
                        m_rtxworkingChange.SelectionBackColor = Color.Fuchsia;
                    }
                    else if (m_rtxworkingChange.Lines[i].StartsWith("-"))
                    {
                        m_rtxworkingChange.Select(PositionList[i], m_rtxworkingChange.Lines[i].Length);
                        m_rtxworkingChange.SelectionBackColor = Color.Gray;
                    }
                }
            }
        }


        private void m_lbStagedFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_rtxworkingChange.Clear();
            m_rtxIndexChange.Clear();

            if (m_lbStagedFile.SelectedItem == null)
                return;

            string szShortFileName = m_lbStagedFile.SelectedItem.ToString();
            szShortFileName = szShortFileName.Substring(4, szShortFileName.Length - 4);
            if (string.IsNullOrEmpty(szShortFileName))
                return;


            string szRes = _objGitMgr._objGitMgrCore.GetFileChange_IR(szShortFileName, _szWorkingDir);
            m_rtxIndexChange.AppendText(szRes);
            DecoreateIR();


            foreach (object item in m_lbUnstagFile.Items)
            {
                string szItemName = item.ToString();
                szItemName = szItemName.Substring(4, szItemName.Length - 4);
                if (szShortFileName.Equals(szItemName))
                {
                    szRes = _objGitMgr._objGitMgrCore.GetFileChange_WR(szShortFileName, _szWorkingDir);
                    m_rtxworkingChange.AppendText(szRes);
                    DecoreateWR();
                    break;
                }
            }
        }

        private void DecoreateIR()
        {
            if (m_rtxIndexChange.Lines.Length <= 0)
                return;


            int[] PositionList = new int[m_rtxIndexChange.Lines.Length];
            PositionList[0] = 0;
            for (int i = 1; i < m_rtxIndexChange.Lines.Length; i++)
            {
                PositionList[i] = PositionList[i - 1] + m_rtxIndexChange.Lines[i - 1].Length + 1;

                if (i > 3)
                {
                    if (m_rtxIndexChange.Lines[i].StartsWith("+"))
                    {
                        m_rtxIndexChange.Select(PositionList[i], m_rtxIndexChange.Lines[i].Length);
                        m_rtxIndexChange.SelectionBackColor = Color.Fuchsia;
                    }
                    else if (m_rtxIndexChange.Lines[i].StartsWith("-"))
                    {
                        m_rtxIndexChange.Select(PositionList[i], m_rtxIndexChange.Lines[i].Length);
                        m_rtxIndexChange.SelectionBackColor = Color.Gray;
                    }
                }
            }
        }

        private void m_contextMenuUnstaged_Opening(object sender, CancelEventArgs e)
        {
            if (m_lbUnstagFile.Items.Count <= 0 || m_lbUnstagFile.SelectedItem == null)
            {
                m_contextMenuUnstaged.Enabled = false;
            }
            else
            {
                m_contextMenuUnstaged.Enabled = true;
            }
        }

        private void m_contextMenuStaged_Opening(object sender, CancelEventArgs e)
        {
            if (m_lbStagedFile.Items.Count <= 0 || m_lbStagedFile.SelectedItem == null)
            {
                m_contextMenuStaged.Enabled = false;
            }
            else
            {
                m_contextMenuStaged.Enabled = true;
            }
        }


 
    }
}
