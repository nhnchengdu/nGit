using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
//using System.Linq;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

using Git.Core.SourceApp;
using Git.Manager;
using Git.Core.Helper;
using Git.Repository;


namespace Git.UI
{ 
    //public delegate void ExitProcessHandler(object sender, int code);
    //public delegate void ProcessReceiveData(object sender, DataReceivedEventArgs e);
    
    public class CGitAsynchControl: UserControl
    {


        public DataReceivedEventHandler ProcessErrorData;
        public DataReceivedEventHandler ProcessReceiveData;
        public ExitProcessHandler ProcessAbort;
        protected readonly SynchronizationContext syncContext;
        protected bool _bIsRegGitEvent = false;

        protected string _szWorkingDir = null;
        public string m_szWorkingDir
        {
            get
            {
                return _szWorkingDir;
            }

        }
        protected CGitManager _objGitMgr = null;
        public CGitManager m_objGitMgr
        {
            get
            {
                return _objGitMgr;            
            }
            
        }

        public CGitAsynchControl()
        {  
            //callback initialize
            syncContext = SynchronizationContext.Current;
            ProcessReceiveData = new DataReceivedEventHandler(GitProcessReceiveData);
            ProcessAbort = new ExitProcessHandler(GitProcessExit);
            ProcessErrorData = new DataReceivedEventHandler(GitProcessErrorData);
            m_WaitForm = null;
        }
        public void InitGitEnv(string szWorkingDir, CGitManager objGitMgr )
        {
            _szWorkingDir=szWorkingDir;  
            _objGitMgr=objGitMgr;
        }


        //called back by Git process
        private void GitProcessExit(object sender, int code) 
        {
             SendOrPostCallback AppCallback = p =>
            {
                CallBackGitProcessExit(sender, code);
            };
            syncContext.Send(AppCallback, this);
        
        }
        private void GitProcessReceiveData(object sender, DataReceivedEventArgs e)
        {
            SendOrPostCallback AppCallback = p =>
            {
                CallBackGitProcessReceiveData(sender, e);

            };
            syncContext.Send(AppCallback, this);
        }
        private void GitProcessErrorData(object sender, DataReceivedEventArgs e)
        {
            SendOrPostCallback AppCallback = p =>
            {
                CallBackGitProcessErrorData(sender, e);
            };
            syncContext.Send(AppCallback, this);
        }
        
        //followed function need to be override in subclass
        virtual protected void CallBackGitProcessExit(object sender, int code) { }
        virtual protected void CallBackGitProcessReceiveData(object sender, DataReceivedEventArgs e) { }
        virtual protected void CallBackGitProcessErrorData(object sender, DataReceivedEventArgs e) { }




        #region async local operatiaon========================================================================================

        //==========1
        FormWaiting m_WaitForm;
        public delegate void FlushClient();
        protected void ShowWaiting()
        {
            m_WaitForm = new FormWaiting();
            m_WaitForm.Width = this.ClientSize.Width;
            m_WaitForm.Height = this.ClientSize.Height;
            m_WaitForm.Location = this.ClientRectangle.Location;
            m_WaitForm.Location = this.PointToScreen(this.ClientRectangle.Location);

            //m_WaitForm.ShowDialog(this);    
            //m_WaitForm.BringToFront();
            m_WaitForm.ShowDialog();   
        }

        protected void HideWaiting()
        {
            if (m_WaitForm != null)
            {
                m_WaitForm.Close();
                m_WaitForm = null;
            }
        }          
        private void CrossThreadFlush(object WorkFunc)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            FlushClient WorkingThreadFunc = (FlushClient)WorkFunc;
            FlushClient fc = new FlushClient(WorkingThreadFunc);
            fc.BeginInvoke(null,null);
            //this.BeginInvoke(fc);
        }

        public void AysncRunLocalOpera(FlushClient ThreadFunc)
        {
            Thread thread = new Thread(CrossThreadFlush);
            thread.IsBackground = true;
            thread.Start(ThreadFunc);

            ShowWaiting();
        }


        //==========2
        public delegate void FlushClientWithStringParam(string szPara);
        public class ThreadPara
        {
            public FlushClientWithStringParam ThreadFunc;
            public string szParam;
        }

        private void CrossThreadFlushWithStringPara(object ParaObj)
        {          
            ThreadPara ParaStringObj = (ThreadPara)ParaObj;   
            Control.CheckForIllegalCrossThreadCalls = false;
            FlushClientWithStringParam WorkingThreadFunc = ParaStringObj.ThreadFunc;
            FlushClientWithStringParam fc = new FlushClientWithStringParam(WorkingThreadFunc);
            fc.BeginInvoke(ParaStringObj.szParam,null, null);
            //this.BeginInvoke(fc);
        }

        public void AysncRunLocalOperaWithStringPara(object ParaObj)
        {
            Thread thread = new Thread(CrossThreadFlushWithStringPara);
            thread.IsBackground = true;
            thread.Start(ParaObj);
            ShowWaiting();
        }
        
        //==========3      
        private void CrossThreadFlush2(object WorkFunc)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            FlushClient WorkingThreadFunc = (FlushClient)WorkFunc;
            SendOrPostCallback AppCallback = p =>
            {
                WorkingThreadFunc();
            };
            syncContext.Send(AppCallback, this);
        }
        public void AysncRunLocalOpera2(FlushClient ThreadFunc)
        {
            Thread thread = new Thread(CrossThreadFlush2);
            thread.IsBackground = true;
            thread.Start(ThreadFunc);

            ShowWaiting();
        }

        //=====4
       public delegate void SetTextCallback();
       public void AysncRunLocalOpera3(FlushClient ThreadFunc)
       {
           Thread thread = new Thread(CrossThreadFlush3);
           thread.IsBackground = true;
           thread.Start(ThreadFunc);

           ShowWaiting();
       }
        private void CrossThreadFlush3(object WorkFunc)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            FlushClient WorkingThreadFunc = (FlushClient)WorkFunc;
            FlushClient fc = new FlushClient(WorkingThreadFunc);
            Thread.Sleep(400);  //add it for GIF picture can run.
            SendOrPostCallback AppCallback = p =>
            {
                this.BeginInvoke(fc);
            };
            syncContext.Send(AppCallback, this);
        }

        #endregion
       
    }
}
