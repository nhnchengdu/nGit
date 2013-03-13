using System;
using System.Collections.Generic;
using System.Text;
using Git.UI;
using System.Windows.Forms;
using Git.Core.Commands;
//using Microsoft.VisualStudio.OLE.Interop;
//using Microsoft.VisualStudio.Shell.Interop;
//using Microsoft.VisualStudio;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Git.Core.Helper;
using Git.Core.SourceApp;
using GitCore.Git.UI;


namespace Git.Manager
{
    public class CGitManager :IWin32Window
    {
        public CGitManagerCore  _objGitMgrCore = null;
        public CGitManagerUI    _objGitMgrUI = null;
        public CGitManagerRepo  _objGitMgrRepo = null;
        private IntPtr _hwnd;       
        public IntPtr Handle
        {
            get { return _hwnd; }
        }



        public CGitManager() 
        {
            this._objGitMgrCore = new CGitManagerCore(this);
            this._objGitMgrUI = new CGitManagerUI(this);
            this._objGitMgrRepo = new CGitManagerRepo(this);
        }
        public bool MgrInitialize(IntPtr handle)
        { 
            _hwnd = handle;
            try
            {
                if(false==_objGitMgrCore.Initizlize())
                {
                    throw new Exception("Failed_Initialize_GitMgrCore");
                }
                if (false == _objGitMgrUI.Initizlize())
                {
                    throw new Exception("Failed_Initialize_GitMgrUI");
                }
                if (false == _objGitMgrRepo.Initizlize())
                {
                    throw new Exception("Failed_Initialize_GitMgrRepoe");
                }

            }
            catch
            {
                return false;
            }
            return true;
        }


        #region Git Funtion Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="szTargetDir"></param>
        public void InitializeRepo(string szTargetDir)
        {
            new FormInitRepo(szTargetDir, this).ShowDialog(this);

        }

        /// <summary>
        /// 
        /// </summary>
        public void CloneRepository()
        {
            new FormClone(this).ShowDialog(this);
        }
        public void CloneRepository(string szLocalDir)
        {
            new FormClone(this, szLocalDir).ShowDialog(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="szTargetFileName"></param>
        /// <returns></returns>
        /// 



        /// <summary>
        /// config the property of git
        /// </summary>
        public void ShowPropertyDlg(string szTargetDir)
        {
            new FormProperty(this, szTargetDir).ShowDialog(this);            
        }

        public FileSccStatus GetFileStatus(string szTargetFileName)
        {
            FileSccStatus status = FileSccStatus.ST_NULL;
            try
            {
                status = _objGitMgrCore.GetFileSccStatus(szTargetFileName);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szTargetFileName;

            }
            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szTargetFile"></param>
        /// <returns></returns>
        public string StageFile(string szTargetFile)
        {
            try
            {
                return _objGitMgrCore.StageFile(szTargetFile);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szTargetFile;
                return string.Empty;

            }
        }

        public bool AddFiles(string szSolutionName, List<string> FileList)
        {
            bool bResult = false;
            try
            {
                FormAdd AddDlg = new FormAdd(szSolutionName, FileList, this);
                if (DialogResult.OK == AddDlg.ShowDialog(this))
                {
                    bResult = true;
                }
            }
            catch
            {
                return false;
            }
            return bResult;
        }
        public bool UnStageFiles(string szSolutionName, List<string> FileList)
        {

            bool bResult = false;
            try
            {
                FormUnstage DelDlg = new FormUnstage(szSolutionName, FileList, this);
                if (DialogResult.OK == DelDlg.ShowDialog(this))
                {
                    bResult = true;
                }
            }
            catch
            {
                return false;
            }
            return bResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szTargetFile"></param>
        /// <returns></returns>
        public string UnStageFile(string szTargetFile)
        {
            try
            {
                return _objGitMgrCore.UnStageFile(szTargetFile);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szTargetFile;
                return string.Empty;

            }
        }

        //the two function will be added into UI     --by fengzheng

        /// <summary>
        /// get all items which is in staged status
        /// </summary>
        /// <param name="szSolutionName"></param>
        /// <returns></returns>
        public List<StatusItem> GetAllStagedFiles(string szSolutionName)
        {
            try
            {
                return _objGitMgrCore.GetAllStagedFiles(szSolutionName);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
                return null;
            }
        }

        /// <summary>
        /// Tell whether any item is in staged status
        /// </summary>
        /// <param name="szSolutionName"></param>
        /// <returns></returns>
        public bool IsAnyItemStaged(string szSolutionName)
        {
            try
            {
                var StagedList = _objGitMgrCore.GetAllStagedFiles(szSolutionName);
                if (StagedList == null)
                    return false;
                if (StagedList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szSolutionName"></param>
        /// <param name="FileList"></param>
        public void Commit(string szSolutionName, List<string> FileList)
        {

            try
            {
                new FormCommit(szSolutionName, FileList, this).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szSolutionName"></param>
        /// <param name="FileList"></param>
        public void Discard(string szSolutionName, List<string> FileList)
        {

            try
            {
                new FormDsicard(szSolutionName, FileList, this).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szSolutionName"></param>
        /// <param name="FileList"></param>
        public void Delete(string szSolutionName, List<string> FileList)
        {

            try
            {
                new FormDelete(szSolutionName, FileList, this).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szSolutionName"></param>
        /// <param name="FileList"></param>
        public void Ignore(string szSolutionName)
        {

            try
            {
                new Ignore(szSolutionName, this).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szSolutionName"></param>
        /// <param name="FileList"></param>
        public void Stash(string szSolutionName)
        {

            try
            {
                new FormStash(szSolutionName, this).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szSolutionName"></param>
        public void SwitchBranch(string szSolutionName)
        {

            try
            {
                new FormSwitchBranch(szSolutionName, this).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="szSolutionName"></param>
        public void PullCurrentBranch(string szSolutionName,string szCurrBranch)
        {

            try
            {
                new FormPull( this,szSolutionName,szCurrBranch).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }

       /// <summary>
        /// 
        /// </summary>
        /// <param name="szSolutionName"></param>
        public void ResolveConflicts(string szSolutionName,string szCurrBranch)
        {

            try
            {
                new FormConflict(this, szSolutionName, szCurrBranch).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szSolutionName"></param>
        public void FetchFromRemote(string szSolutionName,string szCurrBranch)
        {

            try
            {
                new FormFetch(this, szSolutionName, szCurrBranch).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szSolutionName"></param>
        public void PushCurrentBranch(string szSolutionName,string szCurrBranch)
        {

            try
            {
                new FormPush( this,szSolutionName,szCurrBranch).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }

        public void Gitk(string szSolutionName)
        {

            //process used to execute external commands
            ProcessStartInfo startInfo = new ProcessStartInfo();
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);

            string szGitSourceCmd = CGitSourceConfig.GetGitExRegValue();
            if (string.IsNullOrEmpty(szGitSourceCmd))
                return;

            CGitSourceHelpler.StartExternalCommand("cmd.exe", "/c \"\"" + szGitSourceCmd.Replace("git.cmd", "gitk.cmd")
                                              .Replace("bin\\git.exe", "cmd\\gitk.cmd")
                                              .Replace("bin/git.exe", "cmd/gitk.cmd") + "\" --branches --tags --remotes\"", szWorkingDir);




        }  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="szSolutionName"></param>
        public void OperateRepository(string szSolutionName)
        {

            try
            {
                new TestForm(szSolutionName, this).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }  

        public void LocalOperate(string szSolutionName)
        {

            try
            {
                new TestForm2(szSolutionName, this).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }  

        public void RemoteOperate(string szSolutionName)
        {

            try
            {
                new TestForm3(szSolutionName, this).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }  

        public void blame(string szSolutionName,string szFile, string szSHA)
        {

            try
            {
                new FormBlame(szFile, szSHA, szSolutionName, this).ShowDialog(this);
            }
            catch
            {
                // TODO: remove catch-all
                string szName = szSolutionName;
            }
            return;
        }  

        #endregion

    }
}
