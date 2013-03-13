using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Git.UI
{
    public partial class Form_Repo_AddTag : Form
    {                
        private CRepositoryControl m_Parent;
        private string _szTargetSHA;
        private string _szWorkingdir;
        private bool _bIsCreateTag;
        public Form_Repo_AddTag(CRepositoryControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRepositoryControl;
            _szTargetSHA = string.Empty;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsCreateTag = false;
        }

        public void InitTarget(string szSHA)
        {
            _szTargetSHA = szSHA;
        }

        private void Form_Repo_AddTag_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_szTargetSHA))
                return;

            if (m_Parent.m_oGitRepository.m_mapAllCommites.ContainsKey(_szTargetSHA))
            {
                m_txSelectedSHA.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szSelfSHA;
                m_txAuthor.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szAutrhorName;
                m_txDate.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szAutrhorDate;
                m_txMsg.Text = m_Parent.m_oGitRepository.m_mapAllCommites[_szTargetSHA].szCommitMessage;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szName"></param>
        /// <returns></returns>
        private bool ValidateTagName(string szName)
        {
            if (ValidateChars(szName)==false)
            {
                MessageBox.Show(this, "there's illegal character,please check and retry", "Warning");
                return false;                
            }

            if (ValidateConflict(szName) == false)
            {
                MessageBox.Show(this, string.Format("branch \"{0}\" has exist, it will cause a conflict.", szName),"Warning");
                return false;
            }
            return true;
        }

        private bool ValidateChars(string szName)
        {
            string szRegex = @"^[0-9a-zA-Z\-\._]+$";
            Regex r = new Regex(szRegex);
            if (r.IsMatch(szName))
                return true;            
            return false;
        }

        private bool ValidateConflict(string szName)
        {
            if (m_Parent.m_oGitRepository.m_mapLocalBranch.ContainsKey(szName))
            {
                return false;
            }
            if (m_Parent.m_oGitRepository.m_mapTag.ContainsKey(szName))
            {
                return false;
            }
            return true;
            
        } 
        private void m_btnRun_Click(object sender, EventArgs e)
        {
            if(ValidateTagName(m_txTagName.Text)==false)
                return;

            string szRes = m_Parent.m_objGitMgr._objGitMgrCore.CreateTag(_szTargetSHA, m_txTagName.Text, _szWorkingdir);
            if (szRes.StartsWith(@"Successful"))
            {
                m_txOperRes.ForeColor = Color.Green;
                _bIsCreateTag = true;
            }
            else if (szRes.StartsWith(@"Failed"))
            {
                m_txOperRes.ForeColor = Color.Red;
            }
            m_txOperRes.Text = szRes;   

            
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsCreateTag)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
