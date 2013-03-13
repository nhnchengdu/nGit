using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Git.UI
{
    public partial class Form_Repo_RemoveTag : Form
    {
               
        private CRepositoryControl m_Parent;
        private string _szTargetSHA;
        private string _szWorkingdir;
        private bool _bIsDeleteTag;
        public Form_Repo_RemoveTag(CRepositoryControl Pareent)
        {
            InitializeComponent();
            m_Parent = Pareent as CRepositoryControl;
            _szTargetSHA = string.Empty;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsDeleteTag = false;
           
        }

        private void Form_Repo_RemoveTag_Load(object sender, EventArgs e)
        {
            m_cbTagLists.Items.Clear();
            foreach(string szTag in m_Parent.m_oGitRepository.m_mapTag.Keys)
            {
                if (string.IsNullOrEmpty(szTag))
                    continue;
                m_cbTagLists.Items.Add(szTag);
            }
            if (m_cbTagLists.Items.Count>0)
            {
                m_cbTagLists.Text = m_cbTagLists.Items[0].ToString();
            }
            else
            {
                m_cbTagLists.Text =string.Empty;
                m_txSelectedSHA.Text = string.Empty;
                m_txAuthor.Text = string.Empty;
                m_txDate.Text = string.Empty;
                m_txMsg.Text = string.Empty;
            }

        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsDeleteTag)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void m_btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_cbTagLists.Text))
            {
                return;
            }

            string szRes = m_Parent.m_objGitMgr._objGitMgrCore.DeleteTag(m_cbTagLists.Text, _szWorkingdir);
            if (szRes.StartsWith(@"Successful"))
            {
                m_txOperRes.ForeColor = Color.Green;
                _bIsDeleteTag = true;

                if( m_cbTagLists.Items.Contains(m_cbTagLists.Text))
                {
                    m_cbTagLists.Items.Remove(m_cbTagLists.Text);
                    m_cbTagLists.Text = string.Empty;
                }

                if( m_cbTagLists.Items.Count>0)
                {
                    m_cbTagLists.Text = m_cbTagLists.Items[0].ToString();
                }
            }
            else if (szRes.StartsWith(@"Failed"))
            {
                m_txOperRes.ForeColor = Color.Red;
            }
            m_txOperRes.Text = szRes; 
        }

        private void m_cbTagLists_TextChanged(object sender, EventArgs e)
        {
            if (m_Parent.m_oGitRepository.m_mapTag.ContainsKey(m_cbTagLists.Text))
            {
                string szSHA = m_Parent.m_oGitRepository.m_mapTag[m_cbTagLists.Text];
                if (m_Parent.m_oGitRepository.m_mapAllCommites.ContainsKey(szSHA))
                {
                    m_txSelectedSHA.Text = m_Parent.m_oGitRepository.m_mapAllCommites[szSHA].szSelfSHA;
                    m_txAuthor.Text = m_Parent.m_oGitRepository.m_mapAllCommites[szSHA].szAutrhorName;
                    m_txDate.Text = m_Parent.m_oGitRepository.m_mapAllCommites[szSHA].szAutrhorDate;
                    m_txMsg.Text = m_Parent.m_oGitRepository.m_mapAllCommites[szSHA].szCommitMessage;
                }
            }
        }





    }
}
