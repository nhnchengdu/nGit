using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Git.UI
{
    public partial class Form_Repo_Reset : Form
    {

        private CRepositoryControl m_Parent;
        private string _szTargetSHA;
        private string _szWorkingdir;
        private bool _bIsReset;
        public void InitTarget(string szSHA)
        {
            _szTargetSHA = szSHA;
        }

        public Form_Repo_Reset(CRepositoryControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRepositoryControl;
            _szTargetSHA = string.Empty;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsReset = false;

        }

        private void Form_Repo_Reset_Load(object sender, EventArgs e)
        {
            if (m_Parent.m_oGitRepository.m_mapAllCommites.ContainsKey(_szTargetSHA))
            {
                m_txSelectedSHA.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szSelfSHA;
                m_txAuthor.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szAutrhorName;
                m_txDate.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szAutrhorDate;
                m_txMsg.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szCommitMessage;

                m_txWarning.Clear();
                m_rdbIndex.Checked = true;

            }
        }

        private void m_btnRun_Click(object sender, EventArgs e)
        { 
            string szRes = string.Empty;
            if (m_rdbAll.Checked == true)
            {
                szRes = m_Parent.m_objGitMgr._objGitMgrCore.Reset2SpecCommit(_szTargetSHA, 0, _szWorkingdir);

                if (szRes.StartsWith(@"Successful"))
                {
                    _bIsReset = true;
                }
            }
            else if (m_rdbHead.Checked == true)
            {
                szRes = m_Parent.m_objGitMgr._objGitMgrCore.Reset2SpecCommit(_szTargetSHA, 2, _szWorkingdir);
                if (szRes.StartsWith(@"Successful"))
                {
                    _bIsReset = true;
                }
            }
            else if (m_rdbIndAndHead.Checked == true)
            {
                szRes = m_Parent.m_objGitMgr._objGitMgrCore.Reset2SpecCommit(_szTargetSHA, 1, _szWorkingdir);
                if (szRes.StartsWith(@"Successful"))
                {
                    _bIsReset = true;
                }
            }
            else
            {
                szRes = m_Parent.m_objGitMgr._objGitMgrCore.Reset2SpecCommit(_szTargetSHA, 3, _szWorkingdir);
            }

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
            if (_bIsReset)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            m_txWarning.Text = string.Empty;
            m_labWarning1.ForeColor = Color.Black;
            m_txWarning.ForeColor=Color.Black;
            //remote branch danger
            if (m_rdbAll.Checked==true||m_rdbHead.Checked==true||m_rdbIndAndHead.Checked==true)
            {
                foreach (string szSHAItem in m_Parent.m_oGitRepository.m_mapRemoteBranch.Keys)
                {
                    if (_szTargetSHA.Equals(m_Parent.m_oGitRepository.m_mapRemoteBranch[szSHAItem]))
                        continue;

                    if (m_Parent.m_objGitMgr._objGitMgrCore.IsHeritFrom(szSHAItem, _szTargetSHA, _szWorkingdir))
                    {
                        m_txWarning.Text = string.Format("{0}Danger:remote branch <{1}> will be lost{2}", m_txWarning.Text, szSHAItem, Environment.NewLine);
                    }
                    m_labWarning1.ForeColor = Color.Red;
                    m_txWarning.ForeColor = Color.Red;
                }
            }

            //the selected Commit is not in the Current branch
            if (m_rdbIndex.Checked==false && false == m_Parent.m_objGitMgr._objGitMgrCore.IsHeritFrom(m_Parent.m_oGitRepository.m_CurentBranch, _szTargetSHA, _szWorkingdir))
            {
                m_txWarning.Text = string.Format("{0}Danger:all Works in current branch <{1}> maybe be lost{2}", m_txWarning.Text, m_Parent.m_oGitRepository.m_CurentBranch, Environment.NewLine);
                m_labWarning1.ForeColor = Color.Red;
                m_txWarning.ForeColor = Color.Red;
            }

            
            if (m_rdbAll.Checked==true)
            {
                m_txWarning.Text = string.Format("{0}Warn:some commits and working tree and index area will be lost{1}", m_txWarning.Text,  Environment.NewLine);
            }
            else if(m_rdbHead.Checked==true)
            {
                m_txWarning.Text = string.Format("{0}Warn:some commits  will be lost{1}", m_txWarning.Text, Environment.NewLine);

            }
            else if(m_rdbIndAndHead.Checked==true)
            {
                m_txWarning.Text = string.Format("{0}Warn:some commits and index area will be lost{1}", m_txWarning.Text, Environment.NewLine);
            
            }
            else
            {
                m_txWarning.Text = string.Format("{0}Warn:index area will be lost{1}", m_txWarning.Text, Environment.NewLine);
            }


        }



    }
}
