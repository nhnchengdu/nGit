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
    public partial class Form_Remote_AddTracking : Form
    {

        private CRemoteControl m_Parent;
        private string _szWorkingdir;
        private bool _bIsRemoveRemoteRepo;
        CGitManager _objGitMgr = null;
        private string _szTargetRemoteRepo;
        private string _szTargetRemoteBranch;

        public Form_Remote_AddTracking(CRemoteControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRemoteControl;
            _objGitMgr = m_Parent.m_objGitMgr;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsRemoveRemoteRepo = false;
            _szTargetRemoteRepo = string.Empty;
            _szTargetRemoteBranch = string.Empty;
        }

        #region help inner function
        public void InitTarget(string szRemoteName, string szRemoteBranch)
        {
            _szTargetRemoteRepo = szRemoteName;
            _szTargetRemoteBranch = szRemoteBranch;
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
            if (_bIsRemoveRemoteRepo)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void Form_Remote_AddTracking_Load(object sender, EventArgs e)
        {
            m_txRemotName.Text = _szTargetRemoteRepo;
            m_txRemtoBranch.Text = _szTargetRemoteBranch;
            m_txNewBranch.Clear();
            m_cobExistBranchList.Items.Clear();
            
            //find all local branch without tracking
            foreach(string szItm in m_Parent.m_oRemoteInfo.m_mapLocalBranch.Keys)
            {
               
                if (false==m_Parent.m_oRemoteInfo.m_mapAllTracking.ContainsKey(szItm))
                {
                    m_cobExistBranchList.Items.Add(szItm);
                }
            }
            if (m_cobExistBranchList.Items.Count > 0)
            {
                m_cobExistBranchList.Text = m_cobExistBranchList.Items[0].ToString();
            }  
        }
        private void m_rdoCreateNew_CheckedChanged(object sender, EventArgs e)
        {
            if(m_rdoCreateNew.Checked==true)
            {
                m_txNewBranch.Enabled = true;
                m_cobExistBranchList.Enabled = false;
            }
            else
            {
                m_txNewBranch.Enabled = false;
                m_cobExistBranchList.Enabled = true;
            }
        }

        private void m_btnRun_Click(object sender, EventArgs e)
        {            
            if (m_rdoCreateNew.Checked == true)
            {
                string szNewBranch = m_txNewBranch.Text;
                if (ValidateRemoteRepoName(szNewBranch) == false)
                    return;

                string szRes = m_Parent.m_objGitMgr._objGitMgrCore.CreateTrackingBranch(_szTargetRemoteBranch, szNewBranch, _szWorkingdir);
                if (szRes.StartsWith(@"Successful"))
                {
                    m_txOperRes.ForeColor = Color.Green;
                    _bIsRemoveRemoteRepo = true;
                }
                else
                {
                    m_txOperRes.ForeColor = Color.Red;
                }
                m_txOperRes.AppendText(szRes + Environment.NewLine);

            }
            else
            {
                string szLocalBranch = m_cobExistBranchList.Text;
                if (string.IsNullOrEmpty(szLocalBranch))
                    return;
                string szSHAChild = m_Parent.m_objGitMgr._objGitMgrCore.GetHashIDFrom(szLocalBranch, _szWorkingdir);
                string szSHA2Father = m_Parent.m_objGitMgr._objGitMgrCore.GetHashIDFrom(_szTargetRemoteBranch, _szWorkingdir);
                if (string.IsNullOrEmpty(szSHAChild) || string.IsNullOrEmpty(szSHA2Father))
                    return;

                if (_objGitMgr._objGitMgrCore.IsHeritFrom(szSHAChild,szSHA2Father,_szWorkingdir))
                {
                    string szRes = m_Parent.m_objGitMgr._objGitMgrCore.SetTrackingConfig(_szTargetRemoteBranch,szLocalBranch,_szTargetRemoteRepo, _szWorkingdir);                       
                    if (szRes.StartsWith(@"Successful"))
                    {
                        m_txOperRes.ForeColor = Color.Green;
                        _bIsRemoveRemoteRepo = true; 
                    }
                    else
                    {
                        m_txOperRes.ForeColor = Color.Red;
                    }
                    m_txOperRes.AppendText(szRes + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show(this, "Error:The local branch is from a different ancestor, it can't be tracked", "Invalid");
                    return;
                }
            }
        }
        #endregion






    }
}
