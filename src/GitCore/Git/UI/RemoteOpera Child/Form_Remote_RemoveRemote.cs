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
    public partial class Form_Remote_RemoveRemote : Form
    {
        private CRemoteControl m_Parent;
        private string _szWorkingdir;
        private bool _bIsRemoveRemoteRepo;
        CGitManager _objGitMgr = null;
        private string _szTargetRemoteRepo;

        public Form_Remote_RemoveRemote(CRemoteControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRemoteControl;
            _objGitMgr = m_Parent.m_objGitMgr;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsRemoveRemoteRepo = false;
            _szTargetRemoteRepo = string.Empty;
        }


        #region help inner function
        public void InitTarget(string szRemoteName)
        {
            _szTargetRemoteRepo = szRemoteName;
        }
        #endregion

        #region window event function
        private void m_btnRun_Click(object sender, EventArgs e)
        {
     
            if (string.IsNullOrEmpty(_szTargetRemoteRepo))
                return;

            string szRes = m_Parent.m_objGitMgr._objGitMgrCore.RemoveRemote(_szTargetRemoteRepo, _szWorkingdir);                       
            if (szRes.StartsWith(@"Successful"))
            {
                m_txOperRes.ForeColor = Color.Green;
                _bIsRemoveRemoteRepo = true;

               if(m_cobRemoteRepoLists.Items.Contains(_szTargetRemoteRepo))
               {
                   m_cobRemoteRepoLists.Items.Remove(_szTargetRemoteRepo);
                   if(m_cobRemoteRepoLists.Items.Count> 0)
                   {
                       m_cobRemoteRepoLists.Text=m_cobRemoteRepoLists.Items[0].ToString();
                       _szTargetRemoteRepo= m_cobRemoteRepoLists.Text;
                   }
               }

            }
            else 
            {
                m_txOperRes.ForeColor = Color.Red;
            }
            m_txOperRes.AppendText(szRes + Environment.NewLine);





        }
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsRemoveRemoteRepo)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void m_cobRemoteRepoLists_TextChanged(object sender, EventArgs e)
        {
            _szTargetRemoteRepo = m_cobRemoteRepoLists.Text;
           
            //initialize shown
            m_txFetchURL.Clear();
            m_txPushURL.Clear();
            m_lbRemotBranchList.Items.Clear();

            //show url information
            if(m_Parent.m_oRemoteInfo.m_mapAllRemotes.ContainsKey(_szTargetRemoteRepo))
            {
                string szURL =m_Parent.m_oRemoteInfo.m_mapAllRemotes[_szTargetRemoteRepo];           
                string[] ResArray = szURL.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if(ResArray.Length>=2)
                {
                    m_txFetchURL.Text = ResArray[0];
                    m_txPushURL.Text = ResArray[1];
                }
            }

            //show remote branch information
            foreach (string szRemoteBr in m_Parent.m_oRemoteInfo.m_mapRemoteBranch.Keys)
            {
                if (szRemoteBr.StartsWith(_szTargetRemoteRepo + "/"))
                {
                    m_lbRemotBranchList.Items.Add(szRemoteBr);
                }
            }
             

        }
        private void Form_Remote_RemoveRemote_Load(object sender, EventArgs e)
        {
            m_lbRemotBranchList.Items.Clear();
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
        #endregion



    }
}
