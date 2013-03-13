using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Git.UI
{
    public partial class Form_Repo_SwitchBranch : Form
    {
        private CRepositoryControl m_Parent;
        private string _szTargetBranch;
        private string _szWorkingdir;
        private string _szCurrentBranch;
        private bool _bIsDeleteBranch;
        public Form_Repo_SwitchBranch(CRepositoryControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRepositoryControl;
            _szTargetBranch = string.Empty;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsDeleteBranch = false;
        }

        public void InitTarget(string szTargetBrName,string szSrcBrName)
        {
            _szTargetBranch = szTargetBrName;
            _szCurrentBranch=szSrcBrName;
        }

        private void Form_Repo_SwitchBranch_Load(object sender, EventArgs e)
        {
            m_txCurBranch.Text = _szCurrentBranch;
            m_cobBranchLists.Items.Clear();

            foreach (string szBranch in m_Parent.m_oGitRepository.m_mapLocalBranch.Keys)
            {
                if (string.IsNullOrEmpty(szBranch))
                    continue;
                m_cobBranchLists.Items.Add(szBranch);
            }

            if (m_cobBranchLists.Items.Count > 0)
            {
                m_cobBranchLists.Text = _szTargetBranch;
            }
            else
            {
                m_cobBranchLists.Text = string.Empty;
                m_txSelectedSHA.Text = string.Empty;
                m_txAuthor.Text = string.Empty;
                m_txDate.Text = string.Empty;
                m_txMsg.Text = string.Empty;
            }
        }

        private void m_cobBranchLists_TextChanged(object sender, EventArgs e)
        {
            if (m_Parent.m_oGitRepository.m_mapLocalBranch.ContainsKey(m_cobBranchLists.Text))
            {
                string szSHA = m_Parent.m_oGitRepository.m_mapLocalBranch[m_cobBranchLists.Text];
                if (m_Parent.m_oGitRepository.m_mapAllCommites.ContainsKey(szSHA))
                {
                    m_txSelectedSHA.Text = m_Parent.m_oGitRepository.m_mapAllCommites[szSHA].szSelfSHA;
                    m_txAuthor.Text = m_Parent.m_oGitRepository.m_mapAllCommites[szSHA].szAutrhorName;
                    m_txDate.Text = m_Parent.m_oGitRepository.m_mapAllCommites[szSHA].szAutrhorDate;
                    m_txMsg.Text = m_Parent.m_oGitRepository.m_mapAllCommites[szSHA].szCommitMessage;
                }
            }
            else
            {
                m_txSelectedSHA.Text = string.Empty;
                m_txAuthor.Text = string.Empty; ;
                m_txDate.Text = string.Empty; ;
                m_txMsg.Text = string.Empty; 
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
            if (m_cobBranchLists.Text.Equals(m_Parent.m_oGitRepository.m_CurentBranch))
            {
                return;
            }

            string szRes = m_Parent.m_objGitMgr._objGitMgrCore.SwitchBranchTo(m_cobBranchLists.Text, _szWorkingdir);
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
