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
using Git.Core.Helper;

namespace Git.UI
{
    public partial class FormFetch : CGitAsynchFomr
    {
        private string _szWorkingdir;
        private bool _bIsRetchRemoteRepo;
        private string _szLocalBranch;
        private Dictionary<string, string> m_mapAllRemotes; //<remote, fetch/push>
        CGitManager _objGitMgr = null;
        
        #region help inner function
        public FormFetch(CGitManager objGitMgr, string szWorkingdir, string LocalBranch)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szWorkingdir = CHelpFuntions.GetValidWorkingDir(szWorkingdir); ;
            _bIsRetchRemoteRepo = false;
        }
        private void UpdateRemote()
        {
            if (string.IsNullOrEmpty(m_cobRemoteRepoLists.Text))
                return;

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
                m_btnStop.Enabled = false;
            }

        }
        #endregion

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
                string szRmRes = _objGitMgr._objGitMgrCore.RemvoeRedundantBr(m_cobRemoteRepoLists.Text, _szWorkingdir);
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
            //some useful information is gotten by error input stream,so strange. example:progress
            CallBackGitProcessReceiveData(sender, e);
        }
        #endregion
    
        #region window event function
        private void Form_Remote_Fetch_Load(object sender, EventArgs e)
        {
            m_cobRemoteRepoLists.Items.Clear();
            if (string.IsNullOrEmpty(_szWorkingdir))
                return;

            //Get git information
            m_mapAllRemotes = _objGitMgr._objGitMgrCore.GetAllRemoteRepo(_szWorkingdir);
            if (m_mapAllRemotes != null && m_mapAllRemotes.Count>0)
            {
                foreach (string szTmp in m_mapAllRemotes.Keys)
                {
                    m_cobRemoteRepoLists.Items.Add(szTmp);
                }              
            }
 
            if(m_cobRemoteRepoLists.Items.Count>0)
                m_cobRemoteRepoLists.Text=m_cobRemoteRepoLists.Items[0].ToString();
            else                
                m_cobRemoteRepoLists.Text=string.Empty;
  
        }
        private void m_btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_cobRemoteRepoLists.Text))
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
        #endregion




    }
}
