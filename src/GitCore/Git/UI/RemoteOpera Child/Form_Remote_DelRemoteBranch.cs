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
    public partial class Form_Remote_DelRemoteBranch : CGitAsynchFomr
    {
        private CRemoteControl m_Parent;
        private string _szWorkingdir;
        private bool _bIsUpLoaded;
        CGitManager _objGitMgr = null;
        private string _szTargetRemoteRepo;
        private string _szSelectedBranch;



        #region Asynchron information from updating remote repository
        override protected void CallBackGitProcessExit(object sender, int code)
        {
            //
            if (code == 0)
            {
                _bIsUpLoaded = true;
                m_txOperRes.ForeColor = Color.Green;
                m_txOperRes.AppendText("--------- Delete branch from Remote repository Successfully ---------" + Environment.NewLine);

            }
            else
            {
                m_txOperRes.ForeColor = Color.Red;
                m_txOperRes.AppendText("------------ Delete branch from Remote repository failed ------------" + Environment.NewLine);
            }

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event -= ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event -= ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event -= ProcessErrorData;
            _bIsRegGitEvent = false;

            m_btnRun.Enabled = true;
            m_btnCancel.Enabled = true;
            m_cobRemoteBranchLists.Enabled = true;
            m_btnStop.Enabled = false;
        }
        override protected void CallBackGitProcessReceiveData(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
                return;
            m_txOperRes.AppendText(e.Data + Environment.NewLine);

        }
        override protected void CallBackGitProcessErrorData(object sender, DataReceivedEventArgs e)
        {
            //some useful information is gotten by errror input stream,so strange. example:progress
            CallBackGitProcessReceiveData(sender, e);
        }
        #endregion
               
        #region help inner function
        public void InitTarget(string szRemoteName)
        {
            _szTargetRemoteRepo = szRemoteName;
        }
        public Form_Remote_DelRemoteBranch(CRemoteControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRemoteControl;
            _objGitMgr = m_Parent.m_objGitMgr;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsUpLoaded = false;
            _szTargetRemoteRepo = string.Empty;
        }
        private void DelRemoteBranch()
        {
            m_txOperRes.AppendText("Start delete the branch from Remote Repository.....");
            m_txOperRes.AppendText(Environment.NewLine);

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
            _bIsRegGitEvent = true;


            string szRemotBranch=string.Empty;
            int nPos = _szSelectedBranch.IndexOf("/");
            if (nPos < 0)
            {
                m_btnRun.Enabled = true;
                m_btnCancel.Enabled = true;
                m_btnStop.Enabled = false;
                m_cobRemoteBranchLists.Enabled = true;
                return;
            }
            szRemotBranch = _szSelectedBranch.Substring(nPos + 1, _szSelectedBranch.Length - nPos - 1);


            if (false == _objGitMgr._objGitMgrCore.RemoveBranchFromRemoteRepo(_szTargetRemoteRepo, szRemotBranch, _szWorkingdir))
            {
                m_btnRun.Enabled = true;
                m_btnCancel.Enabled = true;
                m_btnStop.Enabled = false;
                m_cobRemoteBranchLists.Enabled = true;
            }
        }
        #endregion       
         


        #region window event function
        private void m_cobRemoteBranchLists_TextChanged(object sender, EventArgs e)
        {
            _szSelectedBranch = m_cobRemoteBranchLists.Text;
        }
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsUpLoaded)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void m_btnStop_Click(object sender, EventArgs e)
        {
            _objGitMgr._objGitMgrCore.KillProcess();
            m_txOperRes.AppendText("The Delete operation is being canceling.......... ");
            m_txOperRes.AppendText(Environment.NewLine);
            m_btnStop.Enabled = false;
        }
        private void Form_Remote_DelRemoteBranch_Load(object sender, EventArgs e)
        {
            m_txRemoteRepo.Text = _szTargetRemoteRepo;
            m_cobRemoteBranchLists.Text = string.Empty;
            m_cobRemoteBranchLists.Items.Clear();

            //find all local branch without tracking
            foreach (string szItm in m_Parent.m_oRemoteInfo.m_mapRemoteBranch.Keys)
            {
                if (szItm.StartsWith(_szTargetRemoteRepo+"/"))
                {
                    m_cobRemoteBranchLists.Items.Add(szItm);
                }                    
            }
            if (m_cobRemoteBranchLists.Items.Count > 0)
            {
                m_cobRemoteBranchLists.Text = m_cobRemoteBranchLists.Items[0].ToString();
            }  
        }
        private void m_btnRun_Click(object sender, EventArgs e)
        {
            m_txOperRes.Clear();
            if (string.IsNullOrEmpty(_szSelectedBranch) || string.IsNullOrEmpty(_szTargetRemoteRepo))
            {
                return;
            }

            m_btnRun.Enabled = false;
            m_btnCancel.Enabled = false;
            m_btnStop.Enabled = true;
            m_cobRemoteBranchLists.Enabled = false;
            DelRemoteBranch();
        }
        #endregion

    }
}
