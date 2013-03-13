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
    public partial class FormUnstage : Form
    {
        private List<string> StageedFiles;
        private CGitManager _objGitMgr = null;
        private string _szSolutionName = null;
        private string _szWorkingDir = null;
        private List<string> _SelectedFileList;
        private bool _bIsOperSuccess;

        public FormUnstage(string szSolutionName, List<string> FileList, CGitManager objGitMgr)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szSolutionName = szSolutionName;
            _SelectedFileList = FileList;
            _bIsOperSuccess = false;
            _szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
        }
        private void FormUnstage_Load(object sender, EventArgs e)
        {
            RefreshDataAndGUI();
        }

        private void RefreshDataAndGUI()
        {
            m_lbStagedFile.Items.Clear();
            StageedFiles = _objGitMgr._objGitMgrCore.GetAllIndexChange(_szWorkingDir);
            if (StageedFiles != null && StageedFiles.Count > 0)
            {
                foreach (string szItem in StageedFiles)
                {
                    m_lbStagedFile.Items.Add(szItem);
                }
            }

            if (_SelectedFileList == null)
                return;
            foreach (string szItm in _SelectedFileList)
            {
                string szShortName = CHelpFuntions.GetShortFileName(_szWorkingDir, szItm);
                szShortName = szShortName.Replace("\\", "/");

                for (int i = 0; i < m_lbStagedFile.Items.Count; i++)
                {
                    string szGitName = m_lbStagedFile.Items[i].ToString();
                    szGitName = szGitName.Substring(4, szGitName.Length - 4);

                    if (szGitName.Equals(szShortName))
                    {
                        m_lbStagedFile.SetItemChecked(i, true);
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

        private void m_btnDelAll_Click(object sender, EventArgs e)
        {
            if (m_lbStagedFile.Items.Count <= 0)
                return;

            if (_objGitMgr._objGitMgrCore.ResetIndex(null, _szWorkingDir))
            {
                _bIsOperSuccess = true;
                MessageBox.Show(this, "Successful: Restore all files from Index area", "Success");
            }
            else
            {
                MessageBox.Show(this, "Failed: Restore all files from Index area", "Fail");
            }
            RefreshDataAndGUI();
        }

        private void m_btnDelSelected_Click(object sender, EventArgs e)
        {
            if (m_lbStagedFile.Items.Count <= 0)
                return;

            int nCheckedNum = m_lbStagedFile.CheckedItems.Count;
            if (nCheckedNum <= 0)
                return;

            List<string> SelectedFileList = new List<string>();
            for (int i = 0; i < nCheckedNum; i++)
            {
                string szItm = m_lbStagedFile.CheckedItems[i].ToString();
                szItm = szItm.Substring(4, szItm.Length - 4);
                SelectedFileList.Add(szItm);
            }

            if (_objGitMgr._objGitMgrCore.ResetIndex(SelectedFileList, _szWorkingDir))
            {
                _bIsOperSuccess = true;
                MessageBox.Show(this, "Successful: Restore selected files from Index area", "Success");
            }
            else
            {
                MessageBox.Show(this, "Failed: Restore selected files from Index area", "Fail");                
            }
            RefreshDataAndGUI();
        }


    }
}
