using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Git.Core.SourceApp;
using Git.Manager;
using Git.Core.Helper;

namespace Git.UI
{
    public partial class FormAdd : Form
    {
        private List<string> UnStageedFiles;
        private CGitManager _objGitMgr = null;
        private string _szSolutionName = null;
        private string _szWorkingDir = null;
        private List<string> _SelectedFileList;
        private bool _bIsOperSuccess;

        public FormAdd(string szSolutionName, List<string> FileList,CGitManager objGitMgr)
        {
            InitializeComponent();            
            _objGitMgr = objGitMgr;
            _szSolutionName = szSolutionName;
            _SelectedFileList = FileList;
            _bIsOperSuccess = false;
            _szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            RefreshDataAndGUI();
        }

        private void RefreshDataAndGUI()
        {
            m_lbUnstagFile.Items.Clear();

            UnStageedFiles = _objGitMgr._objGitMgrCore.GetAllWorkingAreaChange(_szWorkingDir);
            string[] UntrackedFiles = _objGitMgr._objGitMgrCore.GetAllUntracked(_szWorkingDir);

            if (UntrackedFiles != null && UntrackedFiles.Length > 0)
            {
                foreach (string szItem in UntrackedFiles)
                {
                    m_lbUnstagFile.Items.Add("(A) " + szItem);
                }
            }
            if (UnStageedFiles != null && UnStageedFiles.Count > 0)
            {
                foreach (string szItem in UnStageedFiles)
                {
                    m_lbUnstagFile.Items.Add(szItem);
                }
            }

            if (_SelectedFileList == null)
                return;

            foreach (string szItm1 in _SelectedFileList)
            {
                string szShortName = CHelpFuntions.GetShortFileName(_szWorkingDir, szItm1);
                szShortName = szShortName.Replace("\\", "/");

                for (int i = 0; i < m_lbUnstagFile.Items.Count; i++)
                {
                    string szGitName = m_lbUnstagFile.Items[i].ToString();
                    szGitName = szGitName.Substring(4, szGitName.Length - 4);

                    if (szGitName.Equals(szShortName))
                    {
                        m_lbUnstagFile.SetItemChecked(i, true);
                        break;
                    }
                }
            }
            _SelectedFileList = null;
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsOperSuccess)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_btnAddAll_Click(object sender, EventArgs e)
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
                _bIsOperSuccess = true;
                MessageBox.Show(this, "Successful: add all files into Index area", "Success");
                
            }
            else
            {
                MessageBox.Show(this, "Failed: add all files into Index area", "Failed");
            }
            RefreshDataAndGUI();
        }

        private void m_btnAddSelected_Click(object sender, EventArgs e)
        {
            if (m_lbUnstagFile.Items.Count <= 0)
                return;
            int nCheckedNum = m_lbUnstagFile.CheckedItems.Count;
            if (nCheckedNum <= 0)
                return;

            string[] FileList = new string[nCheckedNum];
            for (int i = 0; i < nCheckedNum; i++)
            {
                string szItm = m_lbUnstagFile.CheckedItems[i].ToString();
                szItm = szItm.Substring(4, szItm.Length - 4);
                FileList[i] = szItm;
            }
            if (_objGitMgr._objGitMgrCore.AddFiles(FileList, _szWorkingDir))
            {
                _bIsOperSuccess = true;
                MessageBox.Show(this, "Successful: add selected files into Index area", "Success");
            }
            else
            {
                MessageBox.Show(this, "Failed: add selected files into Index area", "Failed");
            }
            RefreshDataAndGUI();
        }
    }

}
