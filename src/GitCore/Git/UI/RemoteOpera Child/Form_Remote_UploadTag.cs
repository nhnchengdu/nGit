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

       public partial class Form_Remote_UploadTag : CGitAsynchFomr
        {
            private CRemoteControl m_Parent;
            private string _szWorkingdir;
            private bool _bIsUpLoaded;
            CGitManager _objGitMgr = null;
            private string _szTargetRemoteRepo;
            private string _szSelectedTag;
            #region Asynchron information from updating remote repository
            override protected void CallBackGitProcessExit(object sender, int code)
            {
                //
                if (code == 0)
                {
                    _bIsUpLoaded = true;
                    m_txOperRes.ForeColor = Color.Green;
                    m_txOperRes.AppendText("--------- UpLoad Tag to Remote repository Successfully ---------" + Environment.NewLine);

                }
                else
                {
                    m_txOperRes.ForeColor = Color.Red;
                    m_txOperRes.AppendText("------------ UpLoad Tag to Remote repository failed ------------" + Environment.NewLine);
                }

                _objGitMgr._objGitMgrCore.Async_DataReceived_Event -= ProcessReceiveData;
                _objGitMgr._objGitMgrCore.Async_Exited_Event -= ProcessAbort;
                _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event -= ProcessErrorData;
                _bIsRegGitEvent = false;

                m_btnRun.Enabled = true;
                m_btnCancel.Enabled = true;
                m_cobExistTagList.Enabled = true;
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
            public Form_Remote_UploadTag(CRemoteControl Parent)
            {
                InitializeComponent();
                m_Parent = Parent as CRemoteControl;
                _objGitMgr = m_Parent.m_objGitMgr;
                _szWorkingdir = m_Parent.m_szWorkingDir;
                _bIsUpLoaded = false;
                _szTargetRemoteRepo = string.Empty;
            }
            private void UpLoadTag()
            {
                m_txOperRes.AppendText("Start Upload branch to Remote Repository.....");
                m_txOperRes.AppendText(Environment.NewLine);

                _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
                _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
                _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
                _bIsRegGitEvent = true;
                if (false == _objGitMgr._objGitMgrCore.UpLoadBranch2RemoteRepo(_szTargetRemoteRepo, _szSelectedTag, _szWorkingdir))
                {
                    m_btnRun.Enabled = true;
                    m_btnCancel.Enabled = true;
                    m_btnStop.Enabled = false;
                    m_cobExistTagList.Enabled = true;
                }
            }
            #endregion



            #region window event function
            private void m_btnRun_Click_1(object sender, EventArgs e)
            {
                m_txOperRes.Clear();
                if (string.IsNullOrEmpty(_szSelectedTag) || string.IsNullOrEmpty(_szTargetRemoteRepo))
                    return;

                m_btnRun.Enabled = false;
                m_btnCancel.Enabled = false;
                m_btnStop.Enabled = true;
                m_cobExistTagList.Enabled = false;
                UpLoadTag();
            }

            private void m_btnStop_Click_1(object sender, EventArgs e)
            {
                _objGitMgr._objGitMgrCore.KillProcess();
                m_txOperRes.AppendText("The Clone operation is being canceling.......... ");
                m_txOperRes.AppendText(Environment.NewLine);
                m_btnStop.Enabled = false;
            }
            private void m_btnCancel_Click_1(object sender, EventArgs e)
            {
                if (_bIsUpLoaded)
                    this.DialogResult = DialogResult.OK;
                this.Close();
            }
            private void Form_Remote_UploadTag_Load(object sender, EventArgs e)
            {
                m_cobExistTagList.Text = string.Empty;
                m_cobExistTagList.Items.Clear();

                //find all local branch without tracking
                foreach (string szItm in m_Parent.m_oRemoteInfo.m_mapTag.Keys)
                {
                    m_cobExistTagList.Items.Add(szItm);

                }
                if (m_cobExistTagList.Items.Count > 0)
                {
                    m_cobExistTagList.Text = m_cobExistTagList.Items[0].ToString();
                }

            }
            private void m_cobExistTagList_TextChanged(object sender, EventArgs e)
            {
                _szSelectedTag = m_cobExistTagList.Text;
            }
            #endregion
        }

}
