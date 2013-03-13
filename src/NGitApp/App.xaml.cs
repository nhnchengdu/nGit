using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Microsoft.VisualBasic.ApplicationServices;

namespace NGitApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        App()
        {
            //System.Threading.Mutex mutex = new System.Threading.Mutex(true, "NhnGitClientAndGerritClient", out bIsSington);
            //if (bIsSington)
            //{
            //    mutex.ReleaseMutex();
            //}
            //else
            //{
            //    Application.Current.Shutdown(-1);
            //};
        }

        public class NewEntryPoint
        {
            [STAThread]
            public static void Main(string[] args)
            {
                SingleInstanceManager SingleInsctancMgr = new SingleInstanceManager();
                SingleInsctancMgr.Run(args);
            }
        }

        public class SingleInstanceManager : WindowsFormsApplicationBase
        {
            SingleInstanceApplication app;

            public SingleInstanceManager()
            {
                this.IsSingleInstance = true;
            }

            protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
            {
                // First time app is launched
                base.OnStartup(e);
                app = new SingleInstanceApplication();
                app.Run();
    
                return false;
            }

            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
            {
                // Subsequent launches
                base.OnStartupNextInstance(eventArgs);
                app.Activate(eventArgs);
            }
        }

        public class SingleInstanceApplication : Application
        {
            private AppMainWnd mainWnd;
            protected override void OnStartup(System.Windows.StartupEventArgs e)
            {
                base.OnStartup(e);
                // Create and show the application's main window

                mainWnd = new AppMainWnd();
                mainWnd.Show();
                Activate(e);
            }

            public void Activate(StartupNextInstanceEventArgs eventArgs )
            {
                // Reactivate application's main window
                this.MainWindow.Show();
                this.MainWindow.Activate();   
                if (eventArgs.CommandLine.Count>0)
                {
                    string szTargetPaht =eventArgs.CommandLine[0];
                    mainWnd.SwitchPath(szTargetPaht);
                }

            }
            public void Activate(System.Windows.StartupEventArgs e)
            {
                // Reactivate application's main window
                this.MainWindow.Show();                
                if (e.Args.Length > 0)
                {
                    string szTargetPaht = e.Args[0];
                    mainWnd.SwitchPath(szTargetPaht);
                }
            }

        }

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //     //if (e.Args.Length == 1)


        //    //System.Threading.Mutex mutex = new System.Threading.Mutex(true, "NhnGitClientAndGerritClient", out bIsSington);
        //    //if (bIsSington)
        //    //{
        //    //    mutex.ReleaseMutex();
        //    //}
        //    //else
        //    //{
        //    //    Application.Current.Shutdown(11);
        //    //};
        //}        

    }
}
