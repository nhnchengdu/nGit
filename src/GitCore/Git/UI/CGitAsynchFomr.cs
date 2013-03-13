using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
//using System.Linq;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Git.UI
{
    
    public delegate void ExitProcessHandler(object sender, int code);
    //public delegate void ProcessReceiveData(object sender, DataReceivedEventArgs e);
    
    public class CGitAsynchFomr:Form
    {
        public DataReceivedEventHandler ProcessErrorData;
        public DataReceivedEventHandler ProcessReceiveData;
        public ExitProcessHandler ProcessAbort;
        protected readonly SynchronizationContext syncContext;
        protected bool _bIsRegGitEvent = false; 

        public CGitAsynchFomr()
        {
            syncContext = SynchronizationContext.Current;
            ProcessReceiveData = new DataReceivedEventHandler(GitProcessReceiveData);
            ProcessAbort = new ExitProcessHandler(GitProcessExit);
            ProcessErrorData = new DataReceivedEventHandler(GitProcessErrorData);
        }


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

    }
}
