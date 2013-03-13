using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Git.UI
{
    public partial class Form_Repo_CheckOut : Form
    {
        private CRepositoryControl m_Parent;
        private string _szTargetSHA;
        private string _szWorkingdir;
        public void InitTarget(string szSHA)
        {
            _szTargetSHA = szSHA;
        }

        public Form_Repo_CheckOut(CRepositoryControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRepositoryControl;
            _szTargetSHA = string.Empty;
            _szWorkingdir = m_Parent.m_szWorkingDir;           
        }

        private void Form_Repo_CheckOut_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_szTargetSHA))
                return;

            if (m_Parent.m_oGitRepository.m_mapAllCommites.ContainsKey(_szTargetSHA))
            {
                m_txSelectedSHA.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szSelfSHA;
                m_txAuthor.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szAutrhorName;
                m_txDate.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szAutrhorDate;
                m_txMsg.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szCommitMessage;
                m_rtxDifference.Text = string.Empty;


                string[] ChangeList = m_Parent.m_objGitMgr._objGitMgrCore.GetCommitChange(_szTargetSHA, null, _szWorkingdir);
                if(ChangeList!=null && (ChangeList.Length>0))
                {
                    for (int i = 0; i < ChangeList.Length; i++)
                    {
                        m_rtxDifference.AppendText(ChangeList[i]+Environment.NewLine);
                    }
                }

            }
        }

        private void m_btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_szTargetSHA))
                return;

            string szRes = m_Parent.m_objGitMgr._objGitMgrCore.CheckOutWholeCommit(_szTargetSHA,_szWorkingdir);
            if (szRes.StartsWith(@"Successful"))
            {
                m_txOperRes.ForeColor = Color.Green;
            }
            else if (szRes.StartsWith(@"Failed"))
            {
                m_txOperRes.ForeColor = Color.Red;
            }
            m_txOperRes.Text = szRes;   
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
