using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Commands;
using Git.Core.Helper;
using System.Diagnostics;
using Git.UI;
using System.Threading;
using Git.Repository;
using System.Text.RegularExpressions;
using System.IO;


namespace Git.Manager
{

    public enum AsyncOperaType
    {
        ASYNC_CLONE = 80,
        ASYNC_GET_LOG = 81,
        ASYNC_GET_ALL_COMMITS=82,
        ASYNC_UPDATE_REMOTE=83,
        ASYNC_UPLOAD_BRANCH=84,
        ASYNC_PUSH_BRANCH=85,
        ASYNC_PUSH_PULL=86,
        ASYNC_SSH_CHECK=87,
        ASYNC_NONE = 122
    }

    public enum ParseType
    {
        RETURN_LOCAL_BRANCH= 180,
        RETURN_REMOTE_BRANCH = 181,
        RETURN_NONE = 588
    }
    
    public class CGitManagerCore
    {                
        // The git manager for UI/Repo/Core
        private CGitManager _objGitManager = null;
        private CGitSourceModule _objGitSourceModule = null;
        private CGitSourceLog _objGitLog = null;


        #region process synchronize and initialize part
        string _szInputProcessArgu = null;
        private readonly object _processLock = new object();
        private Process _CurrentProcess=null;
        private AsyncOperaType _CurrentOperaType = AsyncOperaType.ASYNC_NONE;
        public void KillProcess()
        {
            lock (_processLock)
            {
                try
                {
                    if (_CurrentProcess == null)
                        return;

                    if (!_CurrentProcess.HasExited)
                    {
                        _CurrentProcess.Kill();                        
                    }
                 
                }
                catch
                {
                }
                finally
                {
                    _CurrentOperaType = AsyncOperaType.ASYNC_NONE;
                }
            }   
        }
        public void InputProcessArgu()
        {
            lock (_processLock)
            {
                try
                {
                    if (_CurrentProcess == null)
                        return;

                    if (!_CurrentProcess.HasExited)
                    {   
                        for(int a=0;a<8;a++)                            
                        { 
                            Thread.Sleep(500);
                            _CurrentProcess.StandardInput.WriteLine(_szInputProcessArgu);
                        }
                    }

                }
                catch
                {
                }
            }   

        }
        private int OnProcessClose()
        {
            Trace.WriteLine(String.Format("\n--------------------E0----------------------"));
            int iCode = -1;
            Thread.Sleep(500);
            lock (_processLock)
            {
                try
                {     
                    if (_CurrentProcess != null)
                    {
                        _CurrentProcess.CancelErrorRead();
                        _CurrentProcess.CancelOutputRead();
                        iCode =_CurrentProcess.ExitCode;
                        //_CurrentProcess.WaitForExit(1000);
                        _CurrentProcess.Refresh();
                        _CurrentProcess.Close();
                    }
                }
                finally
                {
                    _CurrentProcess = null;
                    _szInputProcessArgu = null;
                    _CurrentOperaType = AsyncOperaType.ASYNC_NONE;
                }
            }
            return iCode;
        }        
        public CGitManagerCore(CGitManager GitManagerObj) 
        {
            this._objGitManager = GitManagerObj;
        }
        #endregion


        #region Git Sync Operation
        public bool Initizlize()
        {
            //
             string szGitSourceCmd= CGitSourceConfig.GetGitExRegValue();
             if (string.IsNullOrEmpty(szGitSourceCmd))
            {
                return false;
            }

            //
            _objGitSourceModule = new CGitSourceModule(null, szGitSourceCmd);
            if (null == _objGitSourceModule)
            {
                return false;
            }

            //
            _objGitLog=new CGitSourceLog();

            //
            if (false == CGitSourceConfig.InitSetting(_objGitSourceModule, _objGitLog))
            {
                return false;            
            }

            
            //
            CGitSourceConfig.SetupSystemEncoding(_objGitSourceModule);

            //

            return true;
        }
        public bool IsValidGitWorkingDir(string szWorkingDir)
        {
            if(string.IsNullOrEmpty(szWorkingDir))
                return false;

            if (!CHelpFuntions.IsValidWorkingDir(szWorkingDir))
                return false;

            //execute a branch command to distinguish the dir
            string szOldWorkingDir = CGitSourceConfig.m_szWorkingDir;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode=0;
            CGitCmdBranch.run(out iReturnCode);
            CGitSourceConfig.m_szWorkingDir = szOldWorkingDir;
            if (iReturnCode != 0)
                return false;
            return true;
        }    
        public string InitRepository(string szWorkingDir,bool bCentralRepo, out int iReturnCode)
        {
            string szOperSult = null;         
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            szOperSult = CGitCmdInitRepo.run(bCentralRepo, out iReturnCode); 
           
            return szOperSult;       
        }
        public string GetVersion()
        {
           // CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitCmd.GetVersion();
        }
        public string CreateSshKey(string szSshDir,string szUsrName)
        {
            CGitSourceConfig.m_szWorkingDir = szSshDir;
            return CGitCmdSSH.CreateSSHKey(szUsrName);
        }
        public FileSccStatus GetFileSccStatus(string szTargetFileName)
        {
            FileSccStatus szOperSult = FileSccStatus.ST_NULL;

            //set working directory in config module
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szTargetFileName);
            if (string.IsNullOrEmpty(szWorkingDir))
            {
                return FileSccStatus.ST_INVALID_REPO;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            
            //query file status
            int iReturnCode;
            szOperSult = CGitFileStatus.GetFileStatus(szTargetFileName, out iReturnCode);
            if (iReturnCode == 0)
                return szOperSult;
            else
                return FileSccStatus.ST_NULL;

        }        
        //use full file name,just used by VS
        public string StageFile(string szTargetFile)
        {
            if (string.IsNullOrEmpty(szTargetFile))
                return null;

            string szOperSult = null;
            //set working directory in config module
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szTargetFile);
            if (szWorkingDir.Equals(string.Empty))
            {
                return "File:"+szTargetFile+"  , is not in a valid work tree";
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            szOperSult = CGitCmdAdd.run(szTargetFile);
            return szOperSult;
        }
        //use short file name,just used by Advanced function
        public string AddFile(string szTargetFile, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szTargetFile))
                return null;

            string szOperSult = null;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            szOperSult = CGitCmdAdd.run(szTargetFile);
            return szOperSult;
        }
        //use short file name,just used by Advanced function
        public bool AddFiles(string[] szTargetFile, string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            bool bRes = CGitCmdAdd.run(szTargetFile);
            return bRes;
        }        
        public string UnStageFile(string szTargetFile)
        {
            string szOperSult = null;
            //set working directory in config module
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szTargetFile);
            if (szWorkingDir.Equals(string.Empty))
            {
                return "File:" + szTargetFile + "  , is not in a valid work tree";
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            szOperSult = CGitCmdUnStage.run(szTargetFile);
            return szOperSult;

        }   
        public string[] GetAllUntrackedAndIgnored(string szSolutionName)
        {
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
            if (szWorkingDir.Equals(string.Empty))
            {
                return null;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitFileStatus.GetAllUntrackedAndIgnored();

        }
        public string[] GetAllUntracked(string szSolutionName)
        {
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
            if (szWorkingDir.Equals(string.Empty))
            {
                return null;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitFileStatus.GetAllUntracked();

        }
        public List<StatusItem> GetAllStagedFiles(string szSolutionName)
         {
             string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
             if (szWorkingDir.Equals(string.Empty))
             {
                 return null;
             }
             CGitSourceConfig.m_szWorkingDir = szWorkingDir;
             return CGitFileStatus.GetAllStagedFiles();

         }
        public List<string> GetAllWorkingAreaChange(string szSolutionName)
         {
             string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
             if (szWorkingDir.Equals(string.Empty))
             {
                 return null;
             }
             CGitSourceConfig.m_szWorkingDir = szWorkingDir;
             return CGitFileStatus.GetAllWorkingAreaChange();

         }
        public List<string> GetAllIndexChange(string szSolutionName)
        {
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
            if (szWorkingDir.Equals(string.Empty))
            {
                return null;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitFileStatus.GetAllIndexChange();

        }
        public void CommitAllStaged(string szMessage, string szSolutionName)
        {
            string szOperSult = null;
            //set working directory in config module
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
            if (szWorkingDir.Equals(string.Empty))
            {
                return ;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            szOperSult = CGitCmdCommit.CommitALLStaged(szMessage);
            if (szOperSult != null)
            {
                //Messageboxc
            }
            return ;
        
        }
        public void CommitSelectedStaged(string szMessage, string szSolutionName, List<string> FileList)
        {
            string szOperSult = null;
            //set working directory in config module
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
            if (szWorkingDir.Equals(string.Empty))
            {
                return ;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
           
            szOperSult =CGitCmdCommit.CommitSelected(FileList, szMessage);
            if (szOperSult != null)
            {
                //Messageboxc
            }
            return;
        }
        public void Discard(string szSolutionName, List<string> FileList,bool bToBranch)
        {
            string szOperSult = null;
            //set working directory in config module
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
            if (szWorkingDir.Equals(string.Empty))
            {
                return;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            if(bToBranch)
            {
                szOperSult = CGitCmdCheckout.ToCurrentResp(FileList);
                if (szOperSult != null)
                {
                    //Messageboxc
                }               
            }
            else
            {
                szOperSult = CGitCmdCheckout.ToCurrentStage(FileList);
                if (szOperSult != null)
                {
                    //Messageboxc
                }     
            }
            return;
        }
        public void DiscardAll(string szSolutionName,bool bToBranch)
        {
            string szOperSult = null;
            //set working directory in config module
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
            if (szWorkingDir.Equals(string.Empty))
            {
                return;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            if (bToBranch)
            {
                szOperSult = CGitCmdCheckout.ToAllCurrentResp();
            }
            else
            {
                szOperSult = CGitCmdCheckout.ToAllCurrentStage();
            }
            return;
        }
        public void Delete(string szSolutionName, List<string> FileList, bool bJustIndex)
        {
            if (FileList.Count <= 0)
                return;

            string szOperSult = null;
            //set working directory in config module
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
            if (szWorkingDir.Equals(string.Empty))
            {
                return;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            szOperSult = CGitCmdRm.DeleteFiles(FileList, bJustIndex);
            if (szOperSult != null)
            {
                //Messageboxc
            }
            return;
        }
        public string[] GetBranch(bool bIsRemote,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szWorkingDir))
                return null;
            

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            string szInfoReturn;
            if (bIsRemote)
            {
                szInfoReturn = CGitCmdBranch.GetRemoteBranch(out iReturnCode);
                if (iReturnCode == 0)
                    return CGitCmdBranch.ParseRemote(szInfoReturn);
                else
                    return null;

            }
            else
            {
                szInfoReturn = CGitCmdBranch.GetLocalBranch(out iReturnCode);
                if (iReturnCode == 0)
                    return CGitCmdBranch.ParseLocal(szInfoReturn);
                else
                    return null;
            }
        }
        public string GetHashIDFrom(string szRefParse, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szWorkingDir))
                return null;

            int iReturnCode = 0;
            string szRes = null;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            szRes = CGitCmdRevParse.GetHashID(szRefParse, out iReturnCode);
            if (iReturnCode == 0 && false == string.IsNullOrEmpty(szRes))
            {
                szRes=szRes.TrimEnd(new char[] { ' ', '\n', '\r' });
            }
            return CGitCmdRevParse.ParesSHA(szRes);

        }
        public string[] GetTag(string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szWorkingDir))
                return null;

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szInfoReturn=null;

            szInfoReturn = CGitCmdTag.ShowTag(out iReturnCode);
            if (iReturnCode == 0)
                return CGitCmdTag.ParseShow(szInfoReturn);
            else
                return null;
        }
        public bool IsHeritFrom(string szChild, string szFather, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szChild) || string.IsNullOrEmpty(szFather))
            {
                Debug.Assert(false);
                return false;            
            }
            if (szChild.Equals(szFather))
                return true;

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szInfoReturn = null;

            szInfoReturn = CGitCmdRevList.IsHeritFrom(szChild, szFather, out iReturnCode);
            if (0 == iReturnCode && string.IsNullOrEmpty(szInfoReturn.Trim()))
                return true;
            else if (0 == iReturnCode && szInfoReturn.Trim().StartsWith("warn"))
                return true;
            else if (0 == iReturnCode && szInfoReturn.Trim().Length >=40)
                return false;
            else
            {
                Debug.Assert(false);
                return false;   
            }        
        }
        public bool IsFromSameAncestor(string szCommitFrom, string szCommitTo, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szCommitFrom) || string.IsNullOrEmpty(szCommitFrom))
            {
                Debug.Assert(false);
                return false;
            }
            if (szCommitFrom.Equals(szCommitTo))
                return true;

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szInfoReturn = null;
            szInfoReturn = CGitCmdMergeBase.GetLastAncestor(szCommitFrom, szCommitTo);
            if (string.IsNullOrEmpty(szInfoReturn))
                return false;
            else if (szInfoReturn.StartsWith("warn"))
                return false;
            else
                return true;
        }
        public string GetLastAncestorCommit(string szCommitFrom, string szCommitTo, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szCommitFrom) || string.IsNullOrEmpty(szCommitFrom))
            {
                Debug.Assert(false);
                return string.Empty;
            }

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szInfoReturn = null;
            szInfoReturn = CGitCmdMergeBase.GetLastAncestor(szCommitFrom, szCommitTo);
            if (string.IsNullOrEmpty(szInfoReturn))
                return string.Empty;
            else if (szInfoReturn.StartsWith("warn"))
                return string.Empty;
            else
                return szInfoReturn;
        }
        public string[] GetCommitChange(string szTarget, string szSource, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szTarget))
            {                
                return null;
            }

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szInfoReturn = null;

            szInfoReturn = CGitCmdDiff.GetTreeDifference(szTarget, szSource, out iReturnCode);
            if (string.IsNullOrEmpty(szInfoReturn))
                return null;
            return CGitCmdDiff.ParseTreeDiff(szInfoReturn);

        }
        public string GetFileChange(string szTarget, string szSource, string szFile,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szTarget) || string.IsNullOrEmpty(szSource) || string.IsNullOrEmpty(szFile))
            {
                return null;
            }

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szInfoReturn = null;

            szInfoReturn = CGitCmdDiff.GetFileContentChange(szTarget, szSource, szFile,out iReturnCode);
            return szInfoReturn;
        }
        public string GetFileChange_IR(string szFile, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szFile))
            {
                return null;
            }

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szInfoReturn = null;

            szInfoReturn = CGitCmdDiff.CompareFile_IR(szFile, out iReturnCode);
            return szInfoReturn;
        }
        public string GetFileChange_WR(string szFile, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szFile))
            {
                return null;
            }

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szInfoReturn = null;

            szInfoReturn = CGitCmdDiff.CompareFile_WR(szFile, out iReturnCode);
            return szInfoReturn;
        }
        public void CompareFileByExteranlTool(string szTarget, string szSource, string szFile, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szTarget) || string.IsNullOrEmpty(szSource) || string.IsNullOrEmpty(szFile))
            {
                return ;
            }

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            CGitCmdDiffTool.CompareOneFile(szTarget, szSource, szFile, out iReturnCode);
        }
        public string GetFileContent(string szSHA, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szSHA) || string.IsNullOrEmpty(szWorkingDir))
            {
                return null;
            }

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szInfoReturn = null;

            szInfoReturn = CGitCmdCatFile.GetFileContent(szSHA, out iReturnCode);
            return szInfoReturn;
        }       
        public Dictionary<string, string> GetTreeContent(string szTreeSHA, string szWorkingDir)
       {
           if (string.IsNullOrEmpty(szTreeSHA) || string.IsNullOrEmpty(szWorkingDir))
           {
               return null;
           }

           int iReturnCode = 0;
           CGitSourceConfig.m_szWorkingDir = szWorkingDir;
           string szInfoReturn = null;

           szInfoReturn = CGitCmdLsTree.GetTreeContent(szTreeSHA,out iReturnCode);

           if (string.IsNullOrEmpty(szInfoReturn))
               return null;
           return CGitCmdLsTree.ParesTreeContent(szInfoReturn);
       }
        public Dictionary<string, string> GetAllRemoteRepo(string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szInfoReturn = null;

            szInfoReturn = CGitCmdRemote.GetAllRemote();

            if (string.IsNullOrEmpty(szInfoReturn))
                return null;
            return CGitCmdRemote.ParesAllRemote(szInfoReturn);
        }
        public string GetSingleTracking (string szBranchName, string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitCmdConfig.GetSingleTracking(szBranchName);    
        }
        public Dictionary<string, string> GetAllTracking(Dictionary<string, string> localbranchList, string szWorkingDir)
        {
            if (localbranchList.Count < 0)
                return null;

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitCmdConfig.GetAllTracking(localbranchList);
        }


        public string GetCommitDifferInfo(string szFather, string szChild, string szWorkingDir)
        {

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            return CGitCmdDiff.GetCommitDifferInfo(szFather, szChild, out iReturnCode);    
             
        }
        public Dictionary<string, CommiteInfoItemSimple> GetSpecCommitItem(string szRef, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szRef))
            {
                return null;
            }

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szRes = CGitCmdRevList.GetSpecCommitItem(szRef,out iReturnCode);
            if (string.IsNullOrEmpty(szRes))
                return null;

            Dictionary<string, CommiteInfoItemSimple> mapReturn = new Dictionary<string, CommiteInfoItemSimple>();
            string[] CommitArray = szRes.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (CommitArray != null && CommitArray.Length > 0)
            {
                for (int i = 0; i < CommitArray.Length; i++)
                {
                    string[] InfoIetm = CGitCmdRevList.ParseExcludeItems(CommitArray[i]);
                    if (InfoIetm != null && InfoIetm.Length > 0)
                    {
                        CommiteInfoItemSimple sItem = new CommiteInfoItemSimple();
                        sItem.szSelfSHA = InfoIetm[0];
                        sItem.szTreeSHA = InfoIetm[1];
                        sItem.szAutrhorName = InfoIetm[2];
                        sItem.szCommitDate = InfoIetm[3];
                        sItem.szCommitMessage = InfoIetm[4];
                        mapReturn.Add(sItem.szSelfSHA, sItem);
                    }
                }
                return mapReturn;
            }
            else
            {
                return null;
            }

        }       
        public Dictionary<string, CommiteInfoItemSimple> GetExcludeItmsFromFathrer(string szFather, string szChild,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szFather) || string.IsNullOrEmpty(szChild))
            {
               return null;
            }

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szRes = CGitCmdRevList.GetExcludeItmsFromFathrer(szFather, szChild, out iReturnCode);   
            if (string.IsNullOrEmpty(szRes))
                return null;

            Dictionary<string, CommiteInfoItemSimple> mapReturn= new Dictionary<string, CommiteInfoItemSimple>();
            string[] CommitArray=szRes.Split(new[] { '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            if (CommitArray != null && CommitArray.Length > 0)
            {
                for(int i=0;i<CommitArray.Length;i++)
                {
                    string[] InfoIetm=CGitCmdRevList.ParseExcludeItems(CommitArray[i]);
                    if (InfoIetm != null && InfoIetm.Length > 0)
                    {
                         CommiteInfoItemSimple sItem= new CommiteInfoItemSimple();
                         sItem.szSelfSHA = InfoIetm[0];
                         sItem.szTreeSHA = InfoIetm[1];
                         sItem.szAutrhorName = InfoIetm[2];
                         sItem.szCommitDate = InfoIetm[3];
                         sItem.szCommitMessage = InfoIetm[4];
                         mapReturn.Add(sItem.szSelfSHA,sItem);
                     }
                }      
                return mapReturn;
            }
            else
            {
                return null;
            }
        }
        public Dictionary<string, CommiteInfoItemSimple> GetExcludeItemsFromCommon(string sztarget, string szfrom,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(sztarget) || string.IsNullOrEmpty(szfrom))
            {
               return null;
            }

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szRes= CGitCmdRevList.GetExcludeItemsFromCommon(sztarget,szfrom,out iReturnCode);   
            if (string.IsNullOrEmpty(szRes))
                return null;

            Dictionary<string, CommiteInfoItemSimple> mapReturn= new Dictionary<string, CommiteInfoItemSimple>();
            string[] CommitArray=szRes.Split(new[] { '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            if (CommitArray != null && CommitArray.Length > 0)
            {
                for(int i=0;i<CommitArray.Length;i++)
                {
                    string[] InfoIetm=CGitCmdRevList.ParseExcludeItems(CommitArray[i]);
                    if (InfoIetm != null && InfoIetm.Length > 0)
                    {
                         CommiteInfoItemSimple sItem= new CommiteInfoItemSimple();
                         sItem.szSelfSHA = InfoIetm[0];
                         sItem.szTreeSHA = InfoIetm[1];
                         sItem.szAutrhorName = InfoIetm[2];
                         sItem.szCommitDate = InfoIetm[3];
                         sItem.szCommitMessage = InfoIetm[4];
                         mapReturn.Add(sItem.szSelfSHA,sItem);
                     }
                }      
                return mapReturn;
            }
            else
            {
                return null;
            }
        }
        public string GetBlameDetails(String szTargetFile,string szCommitSHA,string szWorkingDir)
        {
            string szRefPath = CHelpFuntions.GetRelativeFilePath(CGitSourceConfig.m_szWorkingDir, szTargetFile);
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitCmdBlame.GetDetails(szRefPath, szCommitSHA);   
        }
        public MatchCollection GetFilterCommits(string szFilterCondition,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szFilterCondition))
                return null;

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szRes = CGitCmdRevList.GetFilterCommits(szFilterCondition, out iReturnCode);
            if (string.IsNullOrEmpty(szRes))
                return null;
            return CGitCmdRevList.ParseFilterItems(szRes);  
        }
        public string CreateTag(string szSHA, string TagName, string szWorkingDir)
        {

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szReturn;
            string szRes= CGitCmdTag.CreateTag(szSHA, TagName, out iReturnCode);
                
            if (iReturnCode == 0)
                szReturn = "Successful:Create new Tag" + Environment.NewLine;
            else
                szReturn = "Failed:Create new Tag" + Environment.NewLine;

            if (false == string.IsNullOrEmpty(szRes))
            {
                szReturn = szReturn + szRes;
            }
            return szReturn;  
        }
        public string CreateBranch(string szSHA, string szBranchName, bool bIsCheckOut,string szWorkingDir)
        {

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szReturn;
            string szRes;
            if (bIsCheckOut == false)
                szRes = CGitCmdBranch.CreateBranch(szSHA, szBranchName, out iReturnCode);
            else
                szRes = CGitCmdCheckout.CreateBrandCheckOut(szSHA, szBranchName, out iReturnCode);

            if (iReturnCode == 0)
                szReturn = "Successful:Create new Branch" + Environment.NewLine;
            else
                szReturn = "Failed:Create new Branch" + Environment.NewLine;

            if (false == string.IsNullOrEmpty(szRes))
            {
                szReturn = szReturn + szRes;
            }
            return szReturn;
        }
        public string DeleteTag(string TagName, string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szReturn;
            string szRes = CGitCmdTag.DeleteTag(TagName, out iReturnCode);
            if (iReturnCode == 0)
                szReturn = "Successful:Delete the Selected Tag" + Environment.NewLine;
            else
                szReturn = "Failed:Delete the Selected Tag"+ Environment.NewLine;

            if (false == string.IsNullOrEmpty(szRes))
            {
                szReturn = szReturn + szRes;
            }
            return szReturn;
        }
        public string SwitchBranchTo(string szBranchName, string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szReturn;
            string szRes =CGitCmdCheckout.SwitchBranchTo(szBranchName, out iReturnCode);
            if (iReturnCode == 0)
                szReturn = "Successful:Switch Branch" + Environment.NewLine;
            else
                szReturn = "Failed:Switch Branch" + Environment.NewLine;

            if (false == string.IsNullOrEmpty(szRes))
            {
                szReturn = szReturn + szRes;
            }
            return szReturn;
        }
        public string DeleteBranch(string szBrName, bool bIsForce,string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szReturn;
            string szRes = CGitCmdTag.DeleteTag(szBrName, out iReturnCode);
            if (iReturnCode == 0)
                szReturn = "Successful:Delete the Selected Branch" + Environment.NewLine;
            else
                szReturn = "Failed:Delete  the Selected Branch" + Environment.NewLine;

            if (false == string.IsNullOrEmpty(szRes))
            {
                szReturn = szReturn + szRes;
            }
            return szReturn;
        }
        public string  CheckOutWholeCommit(string szSHA, string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szReturn;
            string szRes = CGitCmdCheckout.CheckOutWholeCommit(szSHA, out iReturnCode);
            if (iReturnCode == 0)
                szReturn = "Successful:Check Out the commit: " + szSHA + Environment.NewLine;
            else
                szReturn = "Failed:Check Out the commit: " + szSHA + Environment.NewLine;

            if (false == string.IsNullOrEmpty(szRes))
            {
                szReturn = szReturn + szRes;
            }
            return szReturn;
        }
        public string MergeBranch(string szMsg,string szSource,string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szReturn;
            string szRes = CGitCmdMerge.Merge(szMsg, szSource, out iReturnCode);
            if (iReturnCode == 0)
                szReturn = "Result: " + Environment.NewLine + szRes + Environment.NewLine;
            else
                szReturn = szRes + Environment.NewLine;

            return szReturn;
        }
        public string RebaseBranchTo(string szBranchTo,string szBranchFrom,string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szReturn;
            string szRes = CGitCmdRebase.Rebase(szBranchTo,szBranchFrom,out iReturnCode);
            if (iReturnCode == 0)
                szReturn = "Result: " + Environment.NewLine + szRes + Environment.NewLine;
            else
                szReturn = szRes + Environment.NewLine;

            return szReturn;
        }
        public bool ProcessSaveWithUnTracked(string szWorkingDir,bool bIsKeepClean,string szMsg,out string szResultInfo)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            szResultInfo=CGitCmdStash.SaveWithUnTracked(szMsg,out iReturnCode);
            if(bIsKeepClean==true)
            {
                if (iReturnCode == 0 && szResultInfo.Contains(@"No local changes"))
                    return false;
                else if (iReturnCode == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (iReturnCode == 0 && szResultInfo.Contains(@"No local changes"))
                    return false;
                else if(iReturnCode == 0)
                {
                    szResultInfo=CGitCmdStash.apply(out iReturnCode);
                    if (iReturnCode == 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            
        }
        public bool ProcessSaveOnlyTracked(string szWorkingDir, out string szResultInfo)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            szResultInfo=CGitCmdStash.SaveOnlyTracked(out iReturnCode);

            if (iReturnCode == 0 && szResultInfo.Contains(@"No local changes"))
                return false;
            else if (iReturnCode == 0)
                return true;
            else
                return false;
        }
        public bool ProcessPop(string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            CGitCmdStash.Pop(out iReturnCode);
            if (iReturnCode == 0)
                return true;
            else
                return false;
        }
        public bool ProcessApply(int nIndex, string szWorkingDir, out string szResultInfo)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            szResultInfo=CGitCmdStash.ApplySelected(nIndex, out iReturnCode);
            if (iReturnCode == 0)
                return true;
            else
                return false;
        }
        public bool CleanWithForce(string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            CGitCmdClean.CleanWithForce(out iReturnCode);
            if (iReturnCode == 0)
                return true;
            else
                return false;
        }
        public bool ProcessClear(string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            CGitCmdStash.Clear(out iReturnCode);
            if (iReturnCode == 0)
                return true;
            else
                return false;
        }
        public string[] ProcessGetList(string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string[] szResList = CGitCmdStash.GetLists(out iReturnCode);
            if (iReturnCode == 0)
                return szResList;
            else
                return null;
        }
        public Dictionary<string, string> GetConflictAndMerged(string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitFileStatus.GetConflictAndMerged();
        }
        public Dictionary<string, string> GetConflict(string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitFileStatus.GetConflict();
        }
        public string MergeOneFile(string szFielName,string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string szRes=CGitCmdMergeTool.MergeOneFile(szFielName,out iReturnCode);
            if (iReturnCode == 0)
                return string.Empty ;
            else
                return szRes;
        }        
        public  bool IsAnyUnMergeFile(string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            return CGitCmdLsFiles.IsAnyUnMergeFile(out iReturnCode);
        }
        public string[] GetHistoryforSpecFile(string szFielName, string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string[] arrRes = CGitCmdLog.GetHistoryforSpecFile(szFielName, out iReturnCode);
            if (iReturnCode!= 0)
                return null;
            else
                return arrRes;
        }
        public string[] GetChangeCommitforSpecFile(string szFielName, string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            string[] arrRes = CGitCmdLog.GetChangeCommitforSpecFile(szFielName, out iReturnCode);
            if (iReturnCode!= 0)
                return null;
            else
                return arrRes;
        }
        public Dictionary<string, int> GetFollowforSpecFile(string szFielName, string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            Dictionary<string, int> arrRes = CGitCmdLog.GetFollowforSpecFile(szFielName, out iReturnCode);
            if (iReturnCode != 0)
                return null;
            else
                return arrRes;
        }
        public bool IsFileExist(string szTreeSHA,string szFileName, string szWorkingDir)
        {
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = 0;
            bool bRes = CGitCmdLsTree.IsFileExist(szTreeSHA, szFileName, out iReturnCode);
            if (iReturnCode != 0)
                return false;
            else
                return bRes;
        }                   
        public string GetFileChangeFromTree(string szTarget, string szSource, string szFileName, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szTarget))
            {                
                return null;
            }

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            string szRes = CGitCmdDiff.GetFileChangeFromTree(szTarget,szSource,szFileName,out iReturnCode);
            if (string.IsNullOrEmpty(szRes))
                return null;
            return szRes;

        }
        public string GetFileContent(string szCommitSHA, string szTargetFile, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szCommitSHA) || string.IsNullOrEmpty(szTargetFile))
            {
                return null;
            }

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szBlobSHA = string.Empty;
            szBlobSHA = CGitCmdLsTree.GetFileBlobID(szCommitSHA, szTargetFile, out iReturnCode);
            if (iReturnCode != 0 || string.IsNullOrEmpty(szBlobSHA))
                return null;

            MemoryStream MemStream = (MemoryStream)CGitCmdCatFile.GetFileStream(szBlobSHA);
            if (MemStream == null)// || MemStream.Length<=0)
                return null;



            byte[] buf = MemStream.ToArray();
            if (!CHelpFuntions.IsBinaryFileAccordingToContent(buf))
            {
                StreamReader reader = new StreamReader(MemStream, Encoding.UTF8);
                String sfileout = reader.ReadToEnd();
                sfileout = sfileout.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
                return sfileout;
            }
            return "Binary File can't been shown.................";
        }
        public bool SaveFileAs(string szCommitSHA, string szSaveFileName, string szTargetFile, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szSaveFileName) || string.IsNullOrEmpty(szCommitSHA) || string.IsNullOrEmpty(szTargetFile))
            {
                return false;
            }

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szBlobSHA = string.Empty;
            szBlobSHA = CGitCmdLsTree.GetFileBlobID(szCommitSHA, szTargetFile, out iReturnCode);
            if (iReturnCode != 0 || string.IsNullOrEmpty(szBlobSHA))
                return false;

            MemoryStream MemStream = (MemoryStream)CGitCmdCatFile.GetFileStream(szBlobSHA);
            if (MemStream == null)// || MemStream.Length<=0)
                return false;



            byte[] buf = MemStream.ToArray();
            
            if (!CHelpFuntions.IsBinaryFileAccordingToContent(buf))
            {
                StreamReader reader = new StreamReader(MemStream,Encoding.UTF8);
                String sfileout = reader.ReadToEnd();
                sfileout = sfileout.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");                
                Encoding objCoding=new UTF8Encoding();
                buf = objCoding.GetBytes(sfileout);
            }

            using (FileStream OutStream = File.Create(szSaveFileName))
            {
                OutStream.Write(buf, 0, buf.Length);
            }
            return true;

        }
        public  bool CheckOutUnmergeFile(bool bIsMine, string szFileName,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szFileName))
                return false;

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitCmdCheckout.CheckOutUnmergeFile(bIsMine,szFileName);    
        }
        public bool SaveFileAs(string szBlobSHA, string szSaveFileName,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szSaveFileName) || string.IsNullOrEmpty(szBlobSHA))
            {
                return false;
            }

 
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            MemoryStream MemStream = (MemoryStream)CGitCmdCatFile.GetFileStream(szBlobSHA);
            if (MemStream == null)// || MemStream.Length<=0)
                return false;

            byte[] buf = MemStream.ToArray();
            if (!CHelpFuntions.IsBinaryFileAccordingToContent(buf))
            {
                StreamReader reader = new StreamReader(MemStream, Encoding.UTF8);
                String sfileout = reader.ReadToEnd();
                sfileout = sfileout.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
                Encoding objCoding = new UTF8Encoding();
                buf = objCoding.GetBytes(sfileout);
            }

            using (FileStream OutStream = File.Create(szSaveFileName))
            {
                OutStream.Write(buf, 0, buf.Length);
            }
            return true;

        }
        public bool ResetIndex(List<string> FileList, string szWorkingDir)
        {
            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitCmdReset.ResetIndex(FileList, out iReturnCode);
        }
        public string Reset2SpecCommit(string szTargetCommit,int nType,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szTargetCommit))
            {
                return string.Empty;
            } 

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            string szRes = CGitCmdReset.Reset2SpecCommit(szTargetCommit, nType, out iReturnCode);

            string szReturn;
            if (iReturnCode == 0)
                szReturn = "Successful:Reset the Commit." + Environment.NewLine;
            else
                szReturn = "Failed:Reset the Commit." + Environment.NewLine;

            if (false == string.IsNullOrEmpty(szRes))
            {
                szReturn = szReturn + szRes;
            }
            return szReturn;  
        }
        public string[] GetReflogList(string szBranch,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szBranch))
            {
                return null;
            } 

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            return CGitCmdRefLog.GetReflogList(szBranch, out iReturnCode);
 
        }
        public string ContinueRebase(string szWorkingDir)
        {

            int iReturnCode = 0;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szRes= CGitCmdRebase.ContinueRebase(out iReturnCode);
            string szReturn = string.Empty;
            if (iReturnCode == 0)
                szReturn = "Result: " + Environment.NewLine + szRes + Environment.NewLine;
            else
                szReturn = szRes + Environment.NewLine;

            return szReturn;
        }
        public string AddRemote(string szRemoteName, string szFetchURL, string szPushURL, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szRemoteName) || string.IsNullOrEmpty(szFetchURL))
            {
                return string.Empty;
            }

            int iReturnCode = -1;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szRes = CGitCmdRemote.AddRemote(szRemoteName, szFetchURL, out iReturnCode);
            if (iReturnCode != 0)
            {
                return "Failed:" + szRes;
            }

            if (szFetchURL.Equals(szPushURL) || string.IsNullOrEmpty(szPushURL))
                return "Successful:Add  a new Remote Repository.";

            szRes = CGitCmdRemote.SetRemote(szRemoteName, szFetchURL,false, out iReturnCode);
            if (iReturnCode != 0)
            {
                return "Failed:" + szRes;
            }

            szRes = CGitCmdRemote.SetRemote(szRemoteName, szPushURL, true, out iReturnCode);
            if (iReturnCode != 0)
            {
                return "Failed:" + szRes;
            }
            return "Successful:Add  a new Remote Repository.";
        }
        public string SetRemoteURL(string szRemoteName, string szFetchURL, string szPushURL, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szRemoteName) || string.IsNullOrEmpty(szFetchURL))
            {
                return "Failed:";
            }

            int iReturnCode = -1;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szRes = CGitCmdRemote.SetRemote(szRemoteName, szFetchURL, false, out iReturnCode);
            if (iReturnCode != 0)
            {
                return "Failed:" + szRes;
            }

            szRes = CGitCmdRemote.SetRemote(szRemoteName, szPushURL, true, out iReturnCode);
            if (iReturnCode != 0)
            {
                return "Failed:" + szRes;
            }
            string szReturn = string.Format("Successful:Update URL of Remote Repository({0}).", szRemoteName);
            return szReturn;
        }
        public string RemoveRemote(string szRemoteName, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szRemoteName))
            {
                return "Failed:";
            }

            int iReturnCode = -1;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szRes = CGitCmdRemote.RemoveRemote(szRemoteName,out iReturnCode);
            if (iReturnCode != 0)
            {
                return "Failed:" + szRes;
            }
            string szReturn=string.Format("Successful:Remove the Remote Repository({0}).",szRemoteName) ;
            return szReturn;
        }
        public string RenameRemoteRepo(string szRemoteName, string szNewName,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szRemoteName) || string.IsNullOrEmpty(szNewName))
            {
                return "Failed:";
            }

            int iReturnCode = -1;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szRes = CGitCmdRemote.Rename(szRemoteName,szNewName, out iReturnCode);
            if (iReturnCode != 0)
            {
                return "Failed:" + szRes;
            }
            string szReturn = string.Format("Successful:Rename the Remote Repository({0} into {1}).", szRemoteName,szNewName);
            return szReturn;
        }                
        public string GetConfigInfo(string szPara, string szWorkingDir)
        {
            int iReturnCode = -1;
            if(string.IsNullOrEmpty(szWorkingDir)==false)
                CGitSourceConfig.m_szWorkingDir = CGitSourceConfig.m_szGitBinDir;

            string szRes=CGitCmdConfig.GetValue(szPara,out iReturnCode);
            if (string.IsNullOrEmpty(szRes) == false)
                szRes=szRes.Replace("/", "\\");
            return szRes;
        }
        public string SetConfigInfo(string szPara, string szWorkingDir)
        {                      
            int iReturnCode = -1;
            if(string.IsNullOrEmpty(szWorkingDir)==false)
                CGitSourceConfig.m_szWorkingDir = CGitSourceConfig.m_szGitBinDir;
            if (string.IsNullOrEmpty(szPara) == false)
                szPara=szPara.Replace("\\", "/");

            return CGitCmdConfig.SetParameters(szPara,out iReturnCode);
        }
        public string SetGlobalConfigInfo(string szPara, string szWorkingDir)
        {
            int iReturnCode = -1;
            if (string.IsNullOrEmpty(szWorkingDir) == false)
                CGitSourceConfig.m_szWorkingDir = CGitSourceConfig.m_szGitBinDir;

            return CGitCmdConfig.SetGlobalParameters(szPara, out iReturnCode);
        }
        public string SetTrackingConfig(string szRemoteBr, string szLocalBr,string szRemoteRepo, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szRemoteBr) || string.IsNullOrEmpty(szLocalBr) ||string.IsNullOrEmpty(szRemoteRepo))
            {
                return "Failed:";
            }

            int iReturnCode = -1;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            string szExeCmd = string.Format("branch.{0}.remote {1}", szLocalBr, szRemoteRepo);
            string szRes = CGitCmdConfig.SetParameters(szExeCmd, out iReturnCode);
            if (iReturnCode != 0)
            {
                return "Failed:" + szRes;
            }

            int nPos = szRemoteBr.LastIndexOf("/");
            if (nPos<0)
            {
                return "Failed:";
            }

            string szTmp = szRemoteBr.Substring(nPos + 1, szRemoteBr.Length - nPos - 1);
            szExeCmd = string.Format("branch.{0}.merge refs/heads/{1}", szLocalBr, szRemoteBr);
            szRes = CGitCmdConfig.SetParameters(szExeCmd, out iReturnCode);
            if (iReturnCode != 0)
            {
                return "Failed:" + szRes;
            }

            string szReturn = string.Format("Successful:Add tracking ({0} into {1}).", szLocalBr, szRemoteBr);
            return szReturn;
        }
        public string CreateTrackingBranch(string szRemoteBr, string szNewBr, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szRemoteBr) || string.IsNullOrEmpty(szNewBr))
            {
                return "Failed:";
            }

            int iReturnCode = -1;
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            string szRes = CGitCmdCheckout.CreateBrandCheckOut(szRemoteBr, szNewBr, out iReturnCode);
            if (iReturnCode != 0)
            {
                return "Failed:" + szRes;
            }
            string szReturn = string.Format("Successful:Create Tracking Branch ({0} into {1}).{2}{3}",szNewBr,szRemoteBr,Environment.NewLine,szRes);
            return szReturn;

        }
        public string RemvoeRedundantBr(string szRemoteRepoName, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szWorkingDir) || string.IsNullOrEmpty(szRemoteRepoName))
            {
                return string.Empty;
            }

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            int iReturnCode = -1;
            return CGitCmdRemote.RemvoeRedundantBr(szRemoteRepoName, out iReturnCode);
        }
        #endregion


        #region Git Async Operation
        //Asynchronize event,external caller will register them.
        public event DataReceivedEventHandler Async_DataReceived_Event;
        public event DataReceivedEventHandler Async_ErrorReceived_Event;
        public event ExitProcessHandler Async_Exited_Event;
        public AsyncOperaType m_enCurrAsyncOperType
        {
            get
            {
                lock (_processLock)
                {
                    return _CurrentOperaType;
                }
            }
        }
        
        //async callback function
        private void Async_Callback_Exited(object sender, EventArgs e)
        {
            int iCode = OnProcessClose();
            Trace.WriteLine(String.Format("\n--------------------E2----------------------"));                
            if (Async_Exited_Event != null)
                Async_Exited_Event(this, iCode);
        }
        private void Async_Callback_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(String.Format("\n--------------------R0----------------------"));
            if (Async_DataReceived_Event != null)
                Async_DataReceived_Event(this, e);
        }
        private void Async_Callback_ErrorReceived(object sender, DataReceivedEventArgs e)
        {

            if (Async_DataReceived_Event != null)
                Async_ErrorReceived_Event(this, e);
        }

        //async clone
        public bool RemoveBranchFromRemoteRepo(string szRemoteRepoName, string szBranch, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szWorkingDir) || string.IsNullOrEmpty(szRemoteRepoName) || string.IsNullOrEmpty(szBranch))
            {
                return false;
            }

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            Process process = CGitCmdPush.RemoveBranch(szRemoteRepoName, szBranch, Async_Callback_DataReceived, Async_Callback_ErrorReceived, Async_Callback_Exited);
            lock (_processLock)
            {
                if (process == null)
                {
                    return false;
                }
                _CurrentProcess = process;
                _CurrentOperaType = AsyncOperaType.ASYNC_UPLOAD_BRANCH;
            }
            return true;
        }
        //async pull
        public bool PullBranchAsynch(string szRemoteRepoName,string szRemoteBranch,bool bIsRebaseMode, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szWorkingDir) || string.IsNullOrEmpty(szRemoteRepoName)|| string.IsNullOrEmpty(szRemoteBranch))
            {
                return false;
            }

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            Process process = CGitCmdPull.PullBranchAsynch(szRemoteRepoName, szRemoteBranch, bIsRebaseMode, Async_Callback_DataReceived, Async_Callback_ErrorReceived, Async_Callback_Exited);
            lock (_processLock)
            {
                if (process == null)
                {
                    return false;
                }
                _CurrentProcess = process;
                _CurrentOperaType = AsyncOperaType.ASYNC_PUSH_PULL;
            }
            return true;
        }        
        //async clone
        public bool Commit2SpecBranch(string szRemoteRepoName, string szLocalBranch,string szRemoteBranch,bool bIsFoece,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szWorkingDir) || string.IsNullOrEmpty(szRemoteRepoName) 
                                             || string.IsNullOrEmpty(szLocalBranch)|| string.IsNullOrEmpty(szRemoteBranch))
            {
                return false;
            }

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            Process process = CGitCmdPush.Commit2SpecBranch(szRemoteRepoName, szLocalBranch, szRemoteBranch, bIsFoece,Async_Callback_DataReceived, Async_Callback_ErrorReceived, Async_Callback_Exited);
            lock (_processLock)
            {
                if (process == null)
                {
                    return false;
                }
                _CurrentProcess = process;
                _CurrentOperaType = AsyncOperaType.ASYNC_PUSH_BRANCH;
            }
            return true;
        }
        //async clone
        public bool UpLoadBranch2RemoteRepo(string szRemoteRepoName, string szBranch,string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szWorkingDir) || string.IsNullOrEmpty(szRemoteRepoName) || string.IsNullOrEmpty(szBranch))
            {
                return false;
            }

            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            Process process = CGitCmdPush.UpLoadBranchAsynch(szRemoteRepoName,szBranch, Async_Callback_DataReceived, Async_Callback_ErrorReceived, Async_Callback_Exited);
            lock (_processLock)
            {
                if (process == null)
                {
                    return false;
                }
                _CurrentProcess = process;
                _CurrentOperaType = AsyncOperaType.ASYNC_UPLOAD_BRANCH;
            }
            return true;
        }
        //async clone
        public bool UpdateRemote(string szRemoteRepoName, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szWorkingDir))
            {
                return false;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            Process process = CGitCmdRemote.UpdateAsynch(szRemoteRepoName, Async_Callback_DataReceived, Async_Callback_ErrorReceived, Async_Callback_Exited);
            lock (_processLock)
            {
                if (process==null)
                {
                    return false;
                }
                _CurrentProcess = process;
                _CurrentOperaType = AsyncOperaType.ASYNC_UPDATE_REMOTE;
            }
            return true;
        }
        //async clone
        public void Clone(string szRepositoryUrl, string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szWorkingDir) || string.IsNullOrEmpty(szRepositoryUrl))
            {
                return;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            Process process=CGitCmdClone.runAsynch(szRepositoryUrl,szWorkingDir,Async_Callback_DataReceived,Async_Callback_ErrorReceived,Async_Callback_Exited);
            lock(_processLock)  
            {
                _CurrentProcess = process;
                _CurrentOperaType = AsyncOperaType.ASYNC_CLONE;
            }
        
        }
        //async svn clone
        public void CloneSvn(string szRepositoryUrl, string szWorkingDir,string szUser,string szPassword)
        {
            if (string.IsNullOrEmpty(szWorkingDir) || string.IsNullOrEmpty(szRepositoryUrl))
            {
                return;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;
            _szInputProcessArgu = szPassword;

            Process process = CGitCmdSvn.CloneAsynch(szRepositoryUrl, szWorkingDir, szUser, Async_Callback_DataReceived, Async_Callback_ErrorReceived, Async_Callback_Exited);
            lock (_processLock)
            {
                _CurrentProcess = process;
                _CurrentOperaType = AsyncOperaType.ASYNC_CLONE;
            }

        }
        //parse the result output of clone operation
        public string ParseCloneResult(string szResult, out int iProgress, out int iRefer)
        {
            return CGitCmdClone.ParseOperaResult(szResult, out iProgress, out iRefer);        
        }
        public int ParsePushResult(string szResult)
        {
            return CGitCmdPush.ParseOperaResult(szResult);
        }
        //async get all commites
        public void GetAllCommits(string szWorkingDir)
        {
            if (string.IsNullOrEmpty(szWorkingDir))
            {
                return;
            }
            CGitSourceConfig.m_szWorkingDir = szWorkingDir;

            Process process = CGitCmdLog.GetAllCommitesAsynch(Async_Callback_DataReceived, Async_Callback_ErrorReceived, Async_Callback_Exited);
            lock (_processLock)
            {
                _CurrentProcess = process;
                _CurrentOperaType = AsyncOperaType.ASYNC_GET_ALL_COMMITS;
            }
        }
        //
        public string[] ParseCommtItemInfo(string szResult)
        {
            return CGitCmdLog.ParseAllCommites(szResult);
        }
        //
        public bool CheckSshKey(string szSshDir, string szURl)
        {
            if (string.IsNullOrEmpty(szURl))
            {
                return false;
            }

            CGitSourceConfig.m_szWorkingDir = szSshDir;
            Process process = CGitCmdSSH.CheckSshKey(szURl, Async_Callback_DataReceived, Async_Callback_ErrorReceived, Async_Callback_Exited);
            lock (_processLock)
            {
                if (process == null)
                {
                    return false;
                }
                _CurrentProcess = process;
                _CurrentOperaType = AsyncOperaType.ASYNC_SSH_CHECK;
            }
            return true;
        }
        #endregion
    }
}
