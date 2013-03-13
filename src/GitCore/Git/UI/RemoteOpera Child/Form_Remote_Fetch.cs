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
    public partial class Form_Remote_Fetch : CGitAsynchFomr
    {
        private CRemoteControl m_Parent;
        private string _szWorkingdir;
        private bool _bIsRetchRemoteRepo;
        CGitManager _objGitMgr = null;
        private string _szTargetRemoteRepo;

        public Form_Remote_Fetch(CRemoteControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRemoteControl;
            _objGitMgr = m_Parent.m_objGitMgr;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsRetchRemoteRepo = false;
            _szTargetRemoteRepo=string.Empty;
        }

        #region Asynchron information from updating remote repository
        override protected void CallBackGitProcessExit(object sender, int code)
        {
            //
            if (code == 0)
            {
                _bIsRetchRemoteRepo = true;
                m_txOperRes.ForeColor = Color.Green;   
                //m_txOperRes.AppendText("--------- Updating Remote repository Successfully ---------" + Environment.NewLine);

                //remove redundant remote branch
                string szRmRes=_objGitMgr._objGitMgrCore.RemvoeRedundantBr(_szTargetRemoteRepo, _szWorkingdir);
                if(false==string.IsNullOrEmpty(szRmRes))
                    m_txOperRes.AppendText(szRmRes + Environment.NewLine);
                m_txOperRes.AppendText("--------- Updating Remote repository Successfully ---------" + Environment.NewLine);
            }
            else
            {
                m_txOperRes.ForeColor = Color.Red;
                m_txOperRes.AppendText("------------ Updating Remote repository failed ------------" + Environment.NewLine);
            }

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event -= ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event -= ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event -= ProcessErrorData;
            _bIsRegGitEvent = false;

            m_btnRun.Enabled = true;
            m_btnCancel.Enabled = true;
            m_btnStop.Enabled = false;
            m_cobRemoteRepoLists.Enabled = true;
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
    
        #region window event function
        private void Form_Remote_Fetch_Load(object sender, EventArgs e)
        {
            foreach(string szRemoteItm in m_Parent.m_oRemoteInfo.m_mapAllRemotes.Keys)
            {
                m_cobRemoteRepoLists.Items.Add(szRemoteItm);
            }
            if(string.IsNullOrEmpty(_szTargetRemoteRepo))
            {
                if(m_cobRemoteRepoLists.Items.Count>0)
                    m_cobRemoteRepoLists.Text=m_cobRemoteRepoLists.Items[0].ToString();
            }
            else
            {
                m_cobRemoteRepoLists.Text=_szTargetRemoteRepo;
            }
        }
        private void m_btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_szTargetRemoteRepo))
                return;

            //update the new remote repo information
            m_btnRun.Enabled = false;
            m_btnCancel.Enabled = false;
            m_btnStop.Enabled = true;
            m_cobRemoteRepoLists.Enabled = false;
            UpdateRemote();

        }
        private void m_btnStop_Click(object sender, EventArgs e)
        {
            _objGitMgr._objGitMgrCore.KillProcess();
            m_txOperRes.AppendText("The Clone operation is being canceling.......... ");
            m_txOperRes.AppendText(Environment.NewLine);
            m_btnStop.Enabled = false;
        }
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsRetchRemoteRepo)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void m_cobRemoteRepoLists_TextChanged(object sender, EventArgs e)
        {
            _szTargetRemoteRepo = m_cobRemoteRepoLists.Text;
        }
        #endregion

        #region help inner function
        private void UpdateRemote()
        {
            m_txOperRes.AppendText("Start Update Remote Repository.....");
            m_txOperRes.AppendText(Environment.NewLine);

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
            _bIsRegGitEvent = true;
            if (false == _objGitMgr._objGitMgrCore.UpdateRemote(_szTargetRemoteRepo, _szWorkingdir))
            {
                m_btnRun.Enabled = true;
                m_btnCancel.Enabled = true;
                m_cobRemoteRepoLists.Enabled = true;
                m_btnStop.Enabled = false;
            }
           
        }
        public void InitTarget(string szRemoteName)
        {
            _szTargetRemoteRepo = szRemoteName;
        }
        #endregion


    }
}
