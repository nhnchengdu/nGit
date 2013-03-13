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
    public partial class Form_Remote_UpLoadBranch : CGitAsynchFomr
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
                m_txOperRes.AppendText("--------- UpLoad local branch to Remote repository Successfully ---------" + Environment.NewLine);

            }
            else
            {
                m_txOperRes.ForeColor = Color.Red;
                m_txOperRes.AppendText("------------ UpLoad local branch to Remote repository failed ------------" + Environment.NewLine);
            }

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event -= ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event -= ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event -= ProcessErrorData;
            _bIsRegGitEvent = false;

            m_btnRun.Enabled = true;
            m_btnCancel.Enabled = true;
            m_cobExistBranchList.Enabled = true;
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
        public Form_Remote_UpLoadBranch(CRemoteControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRemoteControl;
            _objGitMgr = m_Parent.m_objGitMgr;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsUpLoaded = false;
            _szTargetRemoteRepo = string.Empty;
        }
        private void UpLoadBranch()
        {
            m_txOperRes.AppendText("Start Upload branch to Remote Repository.....");
            m_txOperRes.AppendText(Environment.NewLine);

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
            _bIsRegGitEvent = true;
            if (false == _objGitMgr._objGitMgrCore.UpLoadBranch2RemoteRepo(_szTargetRemoteRepo,_szSelectedBranch, _szWorkingdir))
            {
                m_btnRun.Enabled = true;
                m_btnCancel.Enabled = true;
                m_btnStop.Enabled = false;
                m_cobExistBranchList.Enabled = true;
            }
        }
        #endregion



        #region window event function
        private void m_btnRun_Click(object sender, EventArgs e)
        {
            m_txOperRes.Clear();
            if (string.IsNullOrEmpty(_szSelectedBranch) || string.IsNullOrEmpty(_szTargetRemoteRepo))
                return;
            foreach (string szItm in m_Parent.m_oRemoteInfo.m_mapRemoteBranch.Keys)
            {
                if(szItm.Contains(_szTargetRemoteRepo+"/")&&szItm.Contains("/"+ _szSelectedBranch))
                {
                    MessageBox.Show(this, "Warning: the branch has been exist in remote repository.", "Warning");
                    return;
                }
            }

            m_btnRun.Enabled = false;
            m_btnCancel.Enabled = false;
            m_btnStop.Enabled = true;
            m_cobExistBranchList.Enabled = false;
            UpLoadBranch();
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
            if (_bIsUpLoaded)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void Form_Remote_UpLoadBranch_Load(object sender, EventArgs e)
        {
            m_txRemoteRepo.Text = _szTargetRemoteRepo;
            m_cobExistBranchList.Text = string.Empty;
            m_cobExistBranchList.Items.Clear();

            //find all local branch without tracking
            foreach (string szItm in m_Parent.m_oRemoteInfo.m_mapLocalBranch.Keys)
            {

                if (false == m_Parent.m_oRemoteInfo.m_mapAllTracking.ContainsKey(szItm))
                {
                    m_cobExistBranchList.Items.Add(szItm);
                }
            }
            if (m_cobExistBranchList.Items.Count > 0)
            {
                m_cobExistBranchList.Text = m_cobExistBranchList.Items[0].ToString();
            }  

        }
        private void m_cobExistBranchList_TextChanged(object sender, EventArgs e)
        {
            _szSelectedBranch = m_cobExistBranchList.Text;
        }
        #endregion

    }
}
