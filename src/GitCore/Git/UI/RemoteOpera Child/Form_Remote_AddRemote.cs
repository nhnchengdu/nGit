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
    public partial class Form_Remote_AddRemote : CGitAsynchFomr
    {

        private CRemoteControl m_Parent;
        private string _szWorkingdir;
        private bool _bIsAddRemoteRepo;
        CGitManager _objGitMgr = null;

        #region Asynchron information from updating remote repository
        override protected void CallBackGitProcessExit(object sender, int code)
        {
            //
            if (code == 0)
            {
                _bIsAddRemoteRepo = true;
                m_txOperRes.ForeColor = Color.Green;                
                m_txOperRes.AppendText("--------- Updating Remote repository Successfully ---------"+Environment.NewLine);

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
            m_txRemoteName.Enabled = true;
            m_txFetchURL.Enabled = true;
            m_txPushURL.Enabled = true;
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

        #region window event function
        public Form_Remote_AddRemote(CRemoteControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRemoteControl;
            _objGitMgr=m_Parent.m_objGitMgr;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsAddRemoteRepo = false;
        }
        private void m_btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txRemoteName.Text) || string.IsNullOrEmpty(m_txFetchURL.Text))
                return;
            if (ValidateRemoteRepoName(m_txRemoteName.Text) == false)
                return;

            //add new remote repository
            string szRes = m_Parent.m_objGitMgr._objGitMgrCore.AddRemote(m_txRemoteName.Text, m_txFetchURL.Text, m_txPushURL.Text, _szWorkingdir);                       
            if (szRes.StartsWith(@"Successful"))
            {
                m_txOperRes.ForeColor = Color.Green;
                _bIsAddRemoteRepo = true;
            }
            else 
            {
                m_txOperRes.ForeColor = Color.Red;
            }
            m_txOperRes.AppendText(szRes + Environment.NewLine);


            //update the new remote repo information
            m_btnRun.Enabled = false;
            m_btnCancel.Enabled = false;
            m_txRemoteName.Enabled = false;
            m_txFetchURL.Enabled = false;
            m_txPushURL.Enabled = false;
            m_btnStop.Enabled = true;
            UpdateRemote();
            
        }         
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsAddRemoteRepo)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void m_btnStop_Click(object sender, EventArgs e)
        {
            _objGitMgr._objGitMgrCore.KillProcess();
            m_txOperRes.AppendText("The Clone operation is being canceling.......... ");
            m_txOperRes.AppendText(Environment.NewLine);
            m_btnStop.Enabled = false;
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
            if(false==_objGitMgr._objGitMgrCore.UpdateRemote(m_txRemoteName.Text, _szWorkingdir))
            {
                m_btnRun.Enabled = true;
                m_btnCancel.Enabled = true;
                m_txRemoteName.Enabled = true;
                m_txFetchURL.Enabled = true;
                m_txPushURL.Enabled = true;
                m_btnStop.Enabled = false;
            }
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




    }
}
