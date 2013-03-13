using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Git.Core.Helper;
using System.IO;
using Git.Core.SourceApp;
using Git.Manager;
using System.Text.RegularExpressions;

namespace Git.UI
{

    public partial class FormStash : Form
    {
        CGitManager _objGitMgr = null;
        string _szSolutionName = null;

        public FormStash(string szSolutionName, CGitManager objGitMgr)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szSolutionName = szSolutionName;
            //string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            //string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            //string[] szResArray = _objGitMgr._objGitMgrCore.GetAllSUntrackedFiles(szWorkingDir);
        }

        private void FormStash_Load(object sender, EventArgs e)
        {
            m_clbStashList.Items.Clear();
            
            System.DateTime currentTime=new System.DateTime();
            currentTime=System.DateTime.Now;

            string szStashMsg="Save Time:";
            szStashMsg = szStashMsg + DateTime.Now.ToString() + Environment.NewLine + "Save Log:";
            m_txCommitMsg.Text = szStashMsg;


            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            string[] szList = _objGitMgr._objGitMgrCore.ProcessGetList(szWorkingDir);
            if(szList!=null&&szList.Length>0)
            {
                m_clbStashList.Items.AddRange(szList);
            }
        }

        private void RefreshGUI()
        {
            m_clbStashList.Items.Clear();
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            string[] szList = _objGitMgr._objGitMgrCore.ProcessGetList(szWorkingDir);
            if (szList != null && szList.Length > 0)
            {
                m_clbStashList.Items.AddRange(szList);
            }
            m_btnSave.Enabled = false;
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            m_txSHowInfo.Clear();
            if(string.IsNullOrEmpty(m_txCommitMsg.Text))
            {
                return;
            }

            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            bool bIsResOK = false;

            string szResInfo = string.Empty;
            if(m_checkKeepClean.Checked==false)
            {
                bIsResOK = _objGitMgr._objGitMgrCore.ProcessSaveWithUnTracked(szWorkingDir, false, m_txCommitMsg.Text, out szResInfo);
            }
            else
            {
                bIsResOK = _objGitMgr._objGitMgrCore.ProcessSaveWithUnTracked(szWorkingDir, true, m_txCommitMsg.Text, out szResInfo);
            }

            if (bIsResOK == false)
            {
                m_txSHowInfo.Text = szResInfo;
                MessageBox.Show(this, "Failed: Save the Current Process", "Warning");
                
            }
            else
            {
                m_txSHowInfo.Text = szResInfo;
                MessageBox.Show(this, "Successful: Save the Current Process", "Success");
            }
            RefreshGUI();
        }

        private void m_clbStashList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue==CheckState.Checked)
            {
                for(int i=0;i<m_clbStashList.CheckedIndices.Count;i++)
                {
                    m_clbStashList.SetItemChecked(m_clbStashList.CheckedIndices[i], false);       
                }
            }
        }

        private void m_btnClean_Click(object sender, EventArgs e)
        {
            m_txSHowInfo.Clear();
            if (m_clbStashList.Items.Count <= 0)
                return;

            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            _objGitMgr._objGitMgrCore.ProcessClear(szWorkingDir);
            RefreshGUI();
        }

        private void m_btnRestore_Click(object sender, EventArgs e)
        {
            m_txSHowInfo.Clear();
            if(m_clbStashList.CheckedIndices.Count<=0) 
            {
                return;
            }

            int nIndex = m_clbStashList.CheckedIndices[0];
            bool bIsResOK = false;
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);

                       
            string szResInfo = string.Empty;
            bIsResOK = _objGitMgr._objGitMgrCore.ProcessApply(nIndex,szWorkingDir, out szResInfo);
            if(bIsResOK==false)
            {
                m_txSHowInfo.Text = szResInfo;
                MessageBox.Show(this, "Failed: Restore the selected Process", "Error");
            }
            else
            {
                m_txSHowInfo.Text = szResInfo;
                MessageBox.Show(this, "Successful: Restore the selected Process", "Success");
            }
           
        }

        private void m_clbStashList_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_txSHowInfo.Clear();

            if (m_clbStashList.SelectedItems.Count <= 0)
            {
                return;
            }

            int nIndex = m_clbStashList.SelectedIndex;

            m_txSHowInfo.Text = m_clbStashList.Items[nIndex].ToString();
        }

        private void m_btnReset_Click(object sender, EventArgs e)
        {
            m_txSHowInfo.Clear();
            MessageBoxIcon icon = MessageBoxIcon.Question;
            var result = MessageBox.Show(this, "This Operation Maybe will lose some untracked files, will you continue?", "Warning", MessageBoxButtons.YesNo, icon);
            if (result == DialogResult.No)
            {
                return;
            }

            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            string  szRes=_objGitMgr._objGitMgrCore.Reset2SpecCommit("HEAD", 0, szWorkingDir);
            if (szRes.StartsWith(@"Successful"))
            {
                //MessageBox.Show(this, "Successful: Clean the current working area and index area", "Success");
            }
            else
            {
                MessageBox.Show(this, "Failed:Clean the current working area and index area", "Error");
                return;
            }


            bool bIsOk = _objGitMgr._objGitMgrCore.CleanWithForce(szWorkingDir);
            if (bIsOk)
            {
                MessageBox.Show(this, "Successful: Clean the current working area and index area", "Success");
            }
            else
            {
                MessageBox.Show(this, "Failed:Clean the current working area and index area", "Error");
            }

        }
    }
}
