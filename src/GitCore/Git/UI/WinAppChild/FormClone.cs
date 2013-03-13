using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Git.Manager;
using System.Diagnostics;
using System.Threading;
using Git.Core.Helper;
using Git.Core.SourceApp;
//////////////////////////////////////////////////////////////////////////
//followed need to be added later
//1.putty/plink
//2.input stream function
//3.ssh
//////////////////////////////////////////////////////////////////////////
namespace Git.UI
{
    public partial class FormClone : CGitAsynchFomr
    {
        CGitManager _objGitMgr = null;
        private bool _bIsExecSvnOperation=false;
        private string _szLocalDir = null;
        public FormClone(CGitManager objGitMgr)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
        }

        public FormClone(CGitManager objGitMgr,string szLocalDir)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szLocalDir = szLocalDir;
        }


        override protected void CallBackGitProcessExit(object sender, int code)
        {
            //
            if (code == 0)
            {
                m_edrShowCloneInfo.AppendText("--------- Clone Operation is Completed Successfully ---------");
                this.labCloneInfo.Text = "Clone Successfully";
                progressBar.Value =100;                
            }
            else
            {
                m_edrShowCloneInfo.AppendText("------------------ Clone Operation is failed -----------------");
                this.labCloneInfo.Text = "Clone failed";
            }
            
            if (_bIsRegGitEvent == true)
            {
                _objGitMgr._objGitMgrCore.Async_DataReceived_Event -= ProcessReceiveData;
                _objGitMgr._objGitMgrCore.Async_Exited_Event -= ProcessAbort;
                _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event -= ProcessErrorData;
                _bIsRegGitEvent = false;
            }

            m_btnClone.Enabled = true;
            m_btnStop.Enabled = false;
            m_btnCancel.Enabled = true;
            InitGUI();
            
        }
        override protected void CallBackGitProcessReceiveData(object sender, DataReceivedEventArgs e)
        {            
            //test and test, ignore it
            int id = Thread.CurrentThread.ManagedThreadId;
            Trace.WriteLine("Main thread: " + id);
            if (string.IsNullOrEmpty(e.Data))
                return;



            if (_bIsExecSvnOperation == true)
            {
                m_edrShowCloneInfo.AppendText("\n" + e.Data);
                m_edrShowCloneInfo.AppendText(Environment.NewLine);

                //only when first login, the prompt message will shown
                //git will store the authentication information by itself
                if (e.Data.StartsWith("Authentication realm:"))
                {
                    _objGitMgr._objGitMgrCore.InputProcessArgu();
                
                }
                return;            
            }

            int iRefer=-1;
            int iProgress=-1;
            string szProgrssInfor=null;
            szProgrssInfor = _objGitMgr._objGitMgrCore.ParseCloneResult(e.Data, out iProgress, out iRefer);
            if (iProgress >= 0 && iProgress <= 100)
            {
                if (iProgress == 10||iProgress == 30||iProgress == 80||iProgress == 100)
                {
                    if (iRefer ==0)
                    {                       
                        m_edrShowCloneInfo.AppendText("\n" + szProgrssInfor);
                        m_edrShowCloneInfo.AppendText(Environment.NewLine);
                    }
                    else if(iRefer ==100)
                    {
                        m_edrShowCloneInfo.AppendText("\nOk.");
                        m_edrShowCloneInfo.AppendText(Environment.NewLine);
                    }
                }
                else if(iProgress<10)
                {
                    m_edrShowCloneInfo.AppendText("\n" + szProgrssInfor);
                    m_edrShowCloneInfo.AppendText(Environment.NewLine);
                }

                this.labCloneInfo.Text = e.Data;
                progressBar.Enabled = true;
                progressBar.Value = Math.Min(100, iProgress);
            }
            else if(iProgress < 0)
            {

                m_edrShowCloneInfo.AppendText("\n" + e.Data);
                m_edrShowCloneInfo.AppendText(Environment.NewLine);
                this.labCloneInfo.Text = szProgrssInfor;

            }
            else if(iProgress >100)
            {
                m_edrShowCloneInfo.AppendText("\n" + szProgrssInfor);
                m_edrShowCloneInfo.AppendText(Environment.NewLine);
                this.labCloneInfo.Text = szProgrssInfor;
            }
            
        }
        override protected void CallBackGitProcessErrorData(object sender, DataReceivedEventArgs e) 
        {
            //some useful information is gotten by errror input stream,so strange. example:progress
            CallBackGitProcessReceiveData(sender, e);
        }




        //choose working directory from browser dialog
        private void btnChoose_Click(object sender, EventArgs e)
        {
            var browseDialog = new FolderBrowserDialog();
            Button button = sender as Button;

            if (browseDialog.ShowDialog(this) == DialogResult.OK)
            {

                if (button.Name.Equals("m_btnGitChoose"))
                {
                    m_cbLocalGitDirectory.Text = browseDialog.SelectedPath;
                }
                else if (button.Name.Equals("m_btnWorkingChoose"))
                {
                    m_cbGitWorkingDir.Text=browseDialog.SelectedPath;

                }
                else if (button.Name.Equals("m_btnSvnChoose"))               
                {
                    m_cbSvnWorkingDir.Text=browseDialog.SelectedPath;
                }
            }

        }

        //execute the clone operation
        private void btnClone_Click(object sender, EventArgs e)
        {
            int index = tabClone.SelectedIndex;
            if (progressBar.Style != ProgressBarStyle.Blocks)
                progressBar.Style = ProgressBarStyle.Blocks;

            if(index==0)//git repository
            {
                _bIsExecSvnOperation = false;
                if (m_checkRemoteGit.Checked == true)
                {
                    if (string.IsNullOrEmpty(m_cbGitWorkingDir.Text) || string.IsNullOrEmpty(m_cbReomoteGitUrl.Text))
                        return;

                    string szValidDir = CHelpFuntions.GetValidWorkingDir(m_cbGitWorkingDir.Text);
                    if (false == string.IsNullOrEmpty(szValidDir))
                    {
                        MessageBox.Show(this, "The Selected Directory has been in a Local git Repository!", "Error");
                        return;
                    }

                    string szRemoteUrl=m_cbReomoteGitUrl.Text;
                    string szWorkingdir = m_cbGitWorkingDir.Text;
                    if (!System.IO.Directory.Exists(szWorkingdir))
                        System.IO.Directory.CreateDirectory(szWorkingdir);

                    this.labCloneInfo.Text = "Clone Information";
                    m_edrShowCloneInfo.Clear();
                    m_edrShowCloneInfo.AppendText("Start Clone Remote Repository.....");
                    m_edrShowCloneInfo.AppendText(Environment.NewLine);
                    if (_bIsRegGitEvent==false)
                    {
                        _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
                        _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
                        _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
                        _bIsRegGitEvent = true;
                    }
                    _objGitMgr._objGitMgrCore.Clone(szRemoteUrl,szWorkingdir);
                    CGitSourceConfig.SetTargetUrlRegValue(szRemoteUrl, true);
                    CGitSourceConfig.SetTargetUrlRegValue(szWorkingdir, false);

                }
                else
                {

                    if (string.IsNullOrEmpty(m_cbGitWorkingDir.Text) || string.IsNullOrEmpty(m_cbLocalGitDirectory.Text))
                        return;
                    string szValidDir = CHelpFuntions.GetValidWorkingDir(m_cbGitWorkingDir.Text);
                    if (false == string.IsNullOrEmpty(szValidDir))
                    {
                        MessageBox.Show(this, "The Selected Directory has been in a Local git Repository!", "Error");
                        return;
                    }

                    string szRemoteUrl = m_cbLocalGitDirectory.Text;
                    string szWorkingdir = m_cbGitWorkingDir.Text;
                    if (!System.IO.Directory.Exists(szWorkingdir))
                        System.IO.Directory.CreateDirectory(szWorkingdir);

                    this.labCloneInfo.Text = "Clone Information";
                    m_edrShowCloneInfo.Clear();
                    m_edrShowCloneInfo.AppendText("Start Clone Local Repository.....");
                    m_edrShowCloneInfo.AppendText(Environment.NewLine);


                    if (_bIsRegGitEvent == false)
                    {
                        _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
                        _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
                        _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
                        _bIsRegGitEvent = true;
                    }
                    _objGitMgr._objGitMgrCore.Clone(szRemoteUrl, szWorkingdir);
                    CGitSourceConfig.SetTargetUrlRegValue(szRemoteUrl, true);
                    CGitSourceConfig.SetTargetUrlRegValue(szWorkingdir, false);
                }         


            }
            else//svn repository
            {
                _bIsExecSvnOperation = true;
                if (string.IsNullOrEmpty(m_cbSvnWorkingDir.Text) || string.IsNullOrEmpty(m_cbSvnUrl.Text))
                    return;
                string szValidDir = CHelpFuntions.GetValidWorkingDir(m_cbSvnWorkingDir.Text);
                if (false == string.IsNullOrEmpty(szValidDir))
                {
                    MessageBox.Show(this, "The Selected Directory has been in a Local git Repository!", "Error");
                    return;
                }

                string szRemoteUrl = m_cbSvnUrl.Text;
                string szWorkingdir = m_cbSvnWorkingDir.Text;
                if (!System.IO.Directory.Exists(szWorkingdir))
                    System.IO.Directory.CreateDirectory(szWorkingdir);

                this.labCloneInfo.Text = "Clone SVN";
                m_edrShowCloneInfo.Clear();
                m_edrShowCloneInfo.AppendText("Start Clone SVN Repository.....");
                m_edrShowCloneInfo.AppendText(Environment.NewLine);
                this.progressBar.Value = 10;

                if (_bIsRegGitEvent == false)
                {
                    _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
                    _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
                    _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
                    _bIsRegGitEvent = true;
                }
                _objGitMgr._objGitMgrCore.CloneSvn(szRemoteUrl, szWorkingdir, m_edLoginUser.Text,m_edPassword.Text);
                CGitSourceConfig.SetTargetUrlRegValue(szRemoteUrl, true);
                CGitSourceConfig.SetTargetUrlRegValue(szWorkingdir, false);
                progressBar.Enabled = true;
                progressBar.Value = Math.Min(100, 50);

            }

            //GUI show
            m_btnClone.Enabled = false;
            m_btnStop.Enabled = true;
            m_btnCancel.Enabled = false;



        }

        //quit current clone operations
        private void btnStop_Click(object sender, EventArgs e)
        {
            _objGitMgr._objGitMgrCore.KillProcess();
            progressBar.Value = 0;
            m_edrShowCloneInfo.AppendText("The Clone operation is being canceling.......... ");
            m_edrShowCloneInfo.AppendText(Environment.NewLine);

            m_btnStop.Enabled = false;
        }

        //close the dialog and exit
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClone_Load(object sender, EventArgs e)
        {
            InitGUI();
        }
        
        private void InitGUI()
        {
            m_cbReomoteGitUrl.Items.Clear();
            m_cbSvnUrl.Items.Clear();
            m_cbLocalGitDirectory.Items.Clear();
            m_cbGitWorkingDir.Items.Clear();
            m_cbSvnWorkingDir.Items.Clear();

            List<string> RemoteList = CGitSourceConfig.GetTargetUrlRegValue(true);
            if (RemoteList != null && RemoteList.Count > 0)
            {
                foreach (string szItm in RemoteList)
                {
                    m_cbReomoteGitUrl.Items.Add(szItm);
                    m_cbSvnUrl.Items.Add(szItm);
                }
            }

            List<string> DirList = CGitSourceConfig.GetTargetUrlRegValue(false);
            if (DirList != null && DirList.Count > 0)
            {
                foreach (string szItm in DirList)
                {
                    m_cbLocalGitDirectory.Items.Add(szItm);
                    m_cbGitWorkingDir.Items.Add(szItm);
                    m_cbSvnWorkingDir.Items.Add(szItm);
                }
            }

            m_cbGitWorkingDir.Text = this._szLocalDir;
        }

        private void m_checkRemoteGit_CheckedChanged(object sender, EventArgs e)
        {
            if(m_checkRemoteGit.Checked==true)
            {
                m_cbReomoteGitUrl.Enabled = true;
                m_cbLocalGitDirectory.Enabled = false;
                m_btnGitChoose.Enabled = false;
            }
            else
            {
                m_cbReomoteGitUrl.Enabled = false;
                m_cbLocalGitDirectory.Enabled = true;
                m_btnGitChoose.Enabled = true;
            }
        }  
    }
}
