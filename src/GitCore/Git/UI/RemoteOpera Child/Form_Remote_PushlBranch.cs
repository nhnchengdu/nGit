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
    public partial class Form_Remote_PushlBranch : CGitAsynchFomr
    {    
        private CRemoteControl m_Parent;
        private string _szWorkingdir;
        private bool _bIsUpLoaded;
        CGitManager _objGitMgr = null;
        private string _szTargetRemoteRepo;
        private string _szLocalBranch;        
        private string _szRemoteBranch;   
        private string _szRemoteURL;

        #region Asynchron information from updating remote repository
        override protected void CallBackGitProcessExit(object sender, int code)
        {
            //
            if (code == 0)
            {
                _bIsUpLoaded = true;
                m_txOperRes.ForeColor = Color.Green;
                m_txOperRes.AppendText("--------- Push local branch to Remote repository Successfully ---------" + Environment.NewLine);

            }
            else
            {
                m_txOperRes.ForeColor = Color.Red;
                m_txOperRes.AppendText("------------ Push local branch to Remote repository failed ------------" + Environment.NewLine);
            }

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event -= ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event -= ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event -= ProcessErrorData;
            _bIsRegGitEvent = false;
            m_barOperProgress.Value = 100;

            m_btnRun.Enabled = true;
            m_btnCancel.Enabled = true;
            m_btnStop.Enabled = false;
        }
        override protected void CallBackGitProcessReceiveData(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
                return;
            m_txOperRes.AppendText(e.Data + Environment.NewLine);

            int iProgress = _objGitMgr._objGitMgrCore.ParsePushResult(e.Data);
            if (iProgress > m_barOperProgress.Value)
            {
                m_barOperProgress.Value = Math.Min(100, iProgress);
            }
        }
        override protected void CallBackGitProcessErrorData(object sender, DataReceivedEventArgs e)
        {
            //some useful information is gotten by error input stream,so strange. example:progress
            CallBackGitProcessReceiveData(sender, e);
        }
        #endregion

        #region help inner function
        public void InitTarget(string szRemoteBranch,string szLocalBranch)
        {
            _szRemoteBranch = szRemoteBranch;
            _szLocalBranch = szLocalBranch;

            //find all local branch without tracking
            foreach (string szItm in m_Parent.m_oRemoteInfo.m_mapAllRemotes.Keys)
            {
                if (_szRemoteBranch.StartsWith(szItm+"/"))
                {
                    _szTargetRemoteRepo = szItm;
                    if (m_Parent.m_oRemoteInfo.m_mapAllRemotes.ContainsKey(szItm))
                    {
                        string szURL = m_Parent.m_oRemoteInfo.m_mapAllRemotes[szItm];
                        string[] ResArray = szURL.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (ResArray.Length >= 2)
                        {
                            //_szRemoteURL = ResArray[0].Substring(7, ResArray[0].Length - 7);
                            _szRemoteURL = ResArray[1].Substring(6, ResArray[1].Length - 6);
                        }
                    }
                    break;
                }
            }

        }
        public Form_Remote_PushlBranch(CRemoteControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRemoteControl;
            _objGitMgr = m_Parent.m_objGitMgr;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsUpLoaded = false;

            _szTargetRemoteRepo = string.Empty;
            _szRemoteBranch = string.Empty;
            _szLocalBranch = string.Empty;
            _szRemoteURL = string.Empty;
        }
        private void PushBranch()
        {
            m_txOperRes.AppendText("Start Push branch to Remote Repository.....");
            m_txOperRes.AppendText(Environment.NewLine);

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
            _bIsRegGitEvent = true;

            string szRemoteSimpleBranch = _szRemoteBranch.Replace(_szTargetRemoteRepo + "/", string.Empty);

            if (m_checkForcePush.Checked==true)
            {
                if (false == _objGitMgr._objGitMgrCore.Commit2SpecBranch(_szTargetRemoteRepo, _szLocalBranch, szRemoteSimpleBranch,true, _szWorkingdir))
                {
                    m_btnRun.Enabled = true;
                    m_btnCancel.Enabled = true;
                    m_btnStop.Enabled = false;
                }
            }
            else
            {
                if (false == _objGitMgr._objGitMgrCore.Commit2SpecBranch(_szTargetRemoteRepo, _szLocalBranch, szRemoteSimpleBranch,false, _szWorkingdir))
                {
                    m_btnRun.Enabled = true;
                    m_btnCancel.Enabled = true;
                    m_btnStop.Enabled = false;
                }
            }
           

        }
        #endregion

        


        #region window event function
        private void Form_Remote_PushlBranch_Load(object sender, EventArgs e)
        {
            m_txLocalBranch.Text = _szLocalBranch;
            m_txPushURL.Text = _szRemoteURL;
            m_txRemoteName.Text = _szTargetRemoteRepo;
            m_txRemoteBranch.Text = _szRemoteBranch;


            if (m_barOperProgress.Style != ProgressBarStyle.Blocks)
                m_barOperProgress.Style = ProgressBarStyle.Blocks;
            m_barOperProgress.Value = 0;
        }
        private void m_btnStop_Click(object sender, EventArgs e)
        {
            m_barOperProgress.Value = 0;
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
        private void m_btnRun_Click(object sender, EventArgs e)
        {
            m_barOperProgress.Value = 0;
            m_txOperRes.Clear();
            if (string.IsNullOrEmpty(_szLocalBranch) || string.IsNullOrEmpty(_szRemoteURL)
                || string.IsNullOrEmpty(_szTargetRemoteRepo) || string.IsNullOrEmpty(_szRemoteBranch))
                return;

            m_btnRun.Enabled = false;
            m_btnCancel.Enabled = false;
            m_btnStop.Enabled = true;
            PushBranch();
        }      

      
        #endregion




    }
}
