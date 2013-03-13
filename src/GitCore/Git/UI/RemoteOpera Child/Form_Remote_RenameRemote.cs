using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using Git.Manager;

namespace Git.UI
{
    public partial class Form_Remote_RenameRemote : Form
    {
        private CRemoteControl m_Parent;
        private string _szWorkingdir;
        private bool _bIsRenameRemoteRepo;
        CGitManager _objGitMgr = null;
        private string _szTargetRemoteRepo;

        public Form_Remote_RenameRemote(CRemoteControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRemoteControl;
            _objGitMgr = m_Parent.m_objGitMgr;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsRenameRemoteRepo = false;
            _szTargetRemoteRepo = string.Empty;
        }

        #region help inner function
        public void InitTarget(string szRemoteName)
        {
            _szTargetRemoteRepo = szRemoteName;
        }

        private bool ValidateRemoteRepoName(string szName)
        {
            if (ValidateChars(szName) == false)
            {
                MessageBox.Show(this, "there's illegal character,please check and retry", "Warning");
                return false;
            }

            if (ValidateConflict(szName) == false)
            {
                MessageBox.Show(this, string.Format("Remote repository \"{0}\" has exist, rename it.", szName), "Warning");
                return false;
            }

            if (m_cobRemoteRepoLists.Items.Contains(szName))
            {
                MessageBox.Show(this, string.Format("Remote repository \"{0}\" has same name with other repository, rename it.", szName), "Warning");
                return false;
            }

            return true;
        }
        private bool ValidateChars(string szName)
        {
            string szRegex = @"^[0-9a-zA-Z\-\._\(\)]+$";
            Regex r = new Regex(szRegex);
            if (r.IsMatch(szName))
                return true;
            return false;
            //return true;
        }
        private bool ValidateConflict(string szName)
        {
            if (m_Parent.m_oRemoteInfo.m_mapAllRemotes.ContainsKey(szName))
            {
                return false;
            }
            if (m_Parent.m_oRemoteInfo.m_mapTag.ContainsKey(szName))
            {
                return false;
            }
            return true;
        } 
        #endregion

        #region window event function
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsRenameRemoteRepo)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form_Remote_RenameRemote_Load(object sender, EventArgs e)
        {
            m_cobRemoteRepoLists.Items.Clear();
            foreach (string szRemoteItm in m_Parent.m_oRemoteInfo.m_mapAllRemotes.Keys)
            {
                m_cobRemoteRepoLists.Items.Add(szRemoteItm);
            }
            if (string.IsNullOrEmpty(_szTargetRemoteRepo))
            {
                if (m_cobRemoteRepoLists.Items.Count > 0)
                    m_cobRemoteRepoLists.Text = m_cobRemoteRepoLists.Items[0].ToString();
            }
            else
            {
                m_cobRemoteRepoLists.Text = _szTargetRemoteRepo;
            }
        }
        private void m_cobRemoteRepoLists_TextChanged(object sender, EventArgs e)
        {
            _szTargetRemoteRepo = m_cobRemoteRepoLists.Text;
            m_txNewName.Text = _szTargetRemoteRepo;
        }
        private void m_btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_szTargetRemoteRepo)
                || string.IsNullOrEmpty(m_txNewName.Text) || _szTargetRemoteRepo.Equals(m_txNewName.Text))
            {
                return;
            }

            if (false == ValidateRemoteRepoName(m_txNewName.Text))
            {
                return;
            }


            string szRes = m_Parent.m_objGitMgr._objGitMgrCore.RenameRemoteRepo(_szTargetRemoteRepo, m_txNewName.Text,_szWorkingdir);
            if (szRes.StartsWith(@"Successful"))
            {
                m_txOperRes.ForeColor = Color.Green;
                _bIsRenameRemoteRepo = true;

                if (m_cobRemoteRepoLists.Items.Contains(_szTargetRemoteRepo))
                {
                    m_cobRemoteRepoLists.Items.Remove(_szTargetRemoteRepo);
                    m_cobRemoteRepoLists.Items.Add(m_txNewName.Text);
                    m_cobRemoteRepoLists.Text = m_txNewName.Text;
                }

            }
            else
            {
                m_txOperRes.ForeColor = Color.Red;
            }
            m_txOperRes.AppendText(szRes + Environment.NewLine);




        }

        #endregion
    }
}
