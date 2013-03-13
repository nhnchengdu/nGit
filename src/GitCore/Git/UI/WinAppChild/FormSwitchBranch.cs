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

namespace Git.UI
{
    public partial class FormSwitchBranch : Form
    {
        private string _szTargetBranch;
        private string _szWorkingdir;
        private bool _bIsDeleteBranch;

        CGitManager _objGitMgr = null;
        public FormSwitchBranch(string szSolutionName, CGitManager objGitMgr)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;

            _szTargetBranch = string.Empty;
            _szWorkingdir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
            _bIsDeleteBranch = false;
        }



        private void Form_Repo_SwitchBranch_Load(object sender, EventArgs e)
        {
            string[] BranchArray = _objGitMgr._objGitMgrCore.GetBranch(false, _szWorkingdir);
            if (BranchArray != null && BranchArray.Length > 0)
            {
                //initialize local branch storage
                m_txCurBranch.Text = BranchArray[0];

                m_cobBranchLists.Items.Clear();
                foreach (string szBranch in BranchArray)
                {
                    if (string.IsNullOrEmpty(szBranch))
                        continue;
                    m_cobBranchLists.Items.Add(szBranch);
                }
                m_cobBranchLists.Text = BranchArray[BranchArray.Length-1];

            }
            else
            {
                m_txCurBranch.Clear();
                m_cobBranchLists.Items.Clear();
                m_cobBranchLists.Text = string.Empty;
            }
        }       

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsDeleteBranch)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void m_btnRun_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(m_cobBranchLists.Text))
            {
                return;
            }
            if (m_cobBranchLists.Text.Equals(m_txCurBranch.Text))
            {
                return;
            }

            string szRes = _objGitMgr._objGitMgrCore.SwitchBranchTo(m_cobBranchLists.Text, _szWorkingdir);
            if (szRes.StartsWith(@"Successful"))
            {
                m_txOperRes.ForeColor = Color.Green;
                _bIsDeleteBranch = true;
                if (m_cobBranchLists.Items.Contains(m_cobBranchLists.Text))
                {
                    m_cobBranchLists.Items.Remove(m_cobBranchLists.Text);
                    m_cobBranchLists.Text = string.Empty;
                }

                if (m_cobBranchLists.Items.Count > 0)
                {
                    m_cobBranchLists.Text = m_cobBranchLists.Items[0].ToString();
                }
            }
            else if (szRes.StartsWith(@"Failed"))
            {
                m_txOperRes.ForeColor = Color.Red;
            }
            m_txOperRes.Text = szRes; 

        }
    }
}
