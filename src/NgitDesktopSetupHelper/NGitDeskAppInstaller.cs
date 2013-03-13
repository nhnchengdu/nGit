using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;


namespace NgitDesktopSetupHelper
{
    [RunInstaller(true)]
    public partial class NGitDeskAppInstaller : Installer
    {
        public NGitDeskAppInstaller()
        {
            InitializeComponent();
        }

        #region help functions
        private void CopyDirectory(string srcDir, string tgtDir)
        {
            DirectoryInfo source = new DirectoryInfo(srcDir);
            DirectoryInfo target = new DirectoryInfo(tgtDir);

            if (target.FullName.StartsWith(source.FullName, StringComparison.CurrentCultureIgnoreCase))
            {
                return;
                throw new Exception("父目录不能拷贝到子目录！");
            }

            if (!source.Exists)
            {
                return;
            }

            if (!target.Exists)
            {
                target.Create();
            }

            FileInfo[] files = source.GetFiles();

            for (int i = 0; i < files.Length; i++)
            {
                File.Copy(files[i].FullName, target.FullName + @"\" + files[i].Name, true);
            }

            DirectoryInfo[] dirs = source.GetDirectories();

            for (int j = 0; j < dirs.Length; j++)
            {
                CopyDirectory(dirs[j].FullName, target.FullName + @"\" + dirs[j].Name);
            }
        }
        private void RunBatCmd(string batPath)
        {
            Process pro = new Process();

            FileInfo file = new FileInfo(batPath);
            pro.StartInfo.WorkingDirectory = file.Directory.FullName;
            pro.StartInfo.FileName = batPath;
            pro.StartInfo.CreateNoWindow = false;
            pro.Start();
            pro.WaitForExit();
        }
        #endregion

        #region override functions
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            string szTargetPath = Environment.GetEnvironmentVariable("CommonProgramFiles") + @"\NgitOverlays";
            string szSourcePath = this.Context.Parameters["targetdir"] + @"\icon";

            try
            {
                if (!Directory.Exists(szTargetPath))
                    Directory.CreateDirectory(szTargetPath);

                //copy shell overlay icon            
                CopyDirectory(szSourcePath, szTargetPath);

                //register shell component
                string szRegCmdFile = this.Context.Parameters["targetdir"] + @"\reg.bat";
                RunBatCmd(szRegCmdFile);

            }
            catch (System.Exception ex)
            {
                string msg = ex.Message;
            }     
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            try
            {
                //unRegister shell component
                string szRegCmdFile = this.Context.Parameters["targetdir"] + @"\unreg.bat";
                if(File.Exists(szRegCmdFile))
                    RunBatCmd(szRegCmdFile);

                string szTargetPath = Environment.GetEnvironmentVariable("CommonProgramFiles") + @"\NgitOverlays";
                if (Directory.Exists(szTargetPath))
                    Directory.Delete(szTargetPath, true);
            }
            catch (System.Exception ex)
            {
                string msg = ex.Message;
            }  
        }
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);
            try
            {
                //unRegister shell component
                string szRegCmdFile = this.Context.Parameters["targetdir"] + @"\unreg.bat";
                if (File.Exists(szRegCmdFile))
                    RunBatCmd(szRegCmdFile);

                string szTargetPath = Environment.GetEnvironmentVariable("CommonProgramFiles") + @"\NgitOverlays";
                if (Directory.Exists(szTargetPath))
                    Directory.Delete(szTargetPath, true);
            }
            catch (System.Exception ex)
            {
                string msg = ex.Message;
            }  
        }


        #endregion
    }
}
