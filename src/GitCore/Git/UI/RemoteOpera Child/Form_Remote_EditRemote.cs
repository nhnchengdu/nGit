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
    public partial class Form_Remote_EditRemote : CGitAsynchFomr
    {
        private CRemoteControl m_Parent;
        private string _szWorkingdir;
        private bool _bIsEditRemoteRepo;
        CGitManager _objGitMgr = null;
        private string _szTargetRemoteRepo;
        private string _szOldFetchURL;
        private string _szOldPushURL;
        public Form_Remote_EditRemote(CRemoteControl ParentDlg)
        {
            InitializeComponent();
            m_Parent = ParentDlg as CRemoteControl;
            _objGitMgr = m_Parent.m_objGitMgr;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsEditRemoteRepo = false;
            _szTargetRemoteRepo = string.Empty;
            _szOldFetchURL= string.Empty;
            _szOldPushURL= string.Empty;
        }

        #region Asynchron information from updating remote repository
        override protected void CallBackGitProcessExit(object sender, int code)
        {
            //
            if (code == 0)
            {
                _bIsEditRemoteRepo = true;
                m_txOperRes.ForeColor = Color.Green;
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
            m_cobRemoteRepoLists.Enabled = true;
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

        #region help inner function
        public void InitTarget(string szRemoteName)
        {
            _szTargetRemoteRepo = szRemoteName;
        }
        private void UpdateRemote()
        {
            m_txOperRes.AppendText("Start Update Remote Repository.....");
            m_txOperRes.AppendText(Environment.NewLine);

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
            _bIsRegGitEvent = true;
            if (false == _objGitMgr._objGitMgrCore.UpdateRemote(m_cobRemoteRepoLists.Text, _szWorkingdir))
            {
                m_btnRun.Enabled = true;
                m_btnCancel.Enabled = true;
                m_cobRemoteRepoLists.Enabled = true;
                m_txFetchURL.Enabled = true;
                m_txPushURL.Enabled = true;
                m_btnStop.Enabled = false;
            }
        }
        #endregion

        #region window event function       
        private void Form_Remote_EditRemote_Load(object sender, EventArgs e)
        {
            m_cobRemoteRepoLists.Items.Clear();
            m_txFetchURL.Clear();
            m_txPushURL.Clear();

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
        
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsEditRemoteRepo)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void m_cobRemoteRepoLists_TextChanged(object sender, EventArgs e)
        {
            _szTargetRemoteRepo = m_cobRemoteRepoLists.Text;

            //show url information
            if (m_Parent.m_oRemoteInfo.m_mapAllRemotes.ContainsKey(_szTargetRemoteRepo))
            {
                string szURL = m_Parent.m_oRemoteInfo.m_mapAllRemotes[_szTargetRemoteRepo];
                string[] ResArray = szURL.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (ResArray.Length >= 2)
                {
                    m_txFetchURL.Text = ResArray[0].Substring(7, ResArray[0].Length - 7);
                    m_txPushURL.Text = ResArray[1].Substring(6, ResArray[1].Length - 6);

                    _szOldFetchURL = m_txFetchURL.Text;
                    _szOldPushURL = m_txPushURL.Text;
                }
            }
        }
        private void m_btnRun_Click(object sender, EventArgs e)
        {
            m_txOperRes.Clear();
            if (string.IsNullOrEmpty(m_txFetchURL.Text))
            {
                MessageBox.Show(this, "Fetch URL can't be empty,please change it.", "Warning");
                return;
            }
            if (string.IsNullOrEmpty(m_txPushURL.Text))
            {
                m_txPushURL.Text = m_txFetchURL.Text;
            }
            if (_szOldFetchURL.Equals(m_txFetchURL.Text) && _szOldPushURL.Equals(m_txPushURL.Text))
            {
                return;
            }

            string szRes = m_Parent.m_objGitMgr._objGitMgrCore.SetRemoteURL(_szTargetRemoteRepo, m_txFetchURL.Text, m_txPushURL.Text, _szWorkingdir);
            if (szRes.StartsWith(@"Successful"))
            {
                m_txOperRes.ForeColor = Color.Green;
                _bIsEditRemoteRepo = true;
                string szUrlInfo = string.Format("(fetch){0}\t(push){1}", m_txFetchURL.Text, m_txPushURL.Text);
                m_Parent.m_oRemoteInfo.m_mapAllRemotes[_szTargetRemoteRepo] = szUrlInfo;
            }
            else
            {
                m_txOperRes.ForeColor = Color.Red;
            }
            m_txOperRes.AppendText(szRes + Environment.NewLine);

            //update the new remote repo information
            m_btnRun.Enabled = false;
            m_btnCancel.Enabled = false;
            m_cobRemoteRepoLists.Enabled = false;
            m_txFetchURL.Enabled = false;
            m_txPushURL.Enabled = false;
            m_btnStop.Enabled = true;
            UpdateRemote();


        }
        #endregion

        private void m_btnStop_Click(object sender, EventArgs e)
        {
            _objGitMgr._objGitMgrCore.KillProcess();
            m_txOperRes.AppendText("The Clone operation is being canceling.......... ");
            m_txOperRes.AppendText(Environment.NewLine);
            m_btnStop.Enabled = false;
        }



        
    }
}
