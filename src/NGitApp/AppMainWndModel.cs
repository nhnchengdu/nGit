using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Git.Manager;
using Git.Core.Helper;
using System.IO;

namespace NGitApp
{
    public class AppMainWndModel:CGitManager
    {
        private static AppMainWndModel _objGitMgr = null;
        private AppMainWndModel()
        {

        
        }        
        public static AppMainWndModel GetInstence()
        {
            if (_objGitMgr == null)
            {
                _objGitMgr = new AppMainWndModel();
            }
            return _objGitMgr;
        }



        #region Git Function
        //return value is current working branch.
        public bool IsValidRepo(string szPath)
        {
            if (string.IsNullOrEmpty(szPath))
                return false;
            if (Directory.Exists(szPath)==false)
                return false;
            string szRepo = CHelpFuntions.GetValidWorkingDir(szPath);
            if (string.IsNullOrEmpty(szRepo))
                return false;
            else
                return true;        
        }

        public string GetCurrentBranch(string szPath)
        {
            string szRepo=CHelpFuntions.GetValidWorkingDir(szPath);
            if (string.IsNullOrEmpty(szRepo))
            {
                return null;
            }
            else
            {

                string[]  BranchArray = _objGitMgrCore.GetBranch(false, szRepo);
                if(BranchArray!=null && BranchArray.Length>0) 
                {
                    string szCurrentBranch=BranchArray[0];
                    if (string.IsNullOrEmpty(szCurrentBranch))
                    {
                        return null;
                    }
                    else
                    {
                        return szCurrentBranch;
                    }
                }                
            }   
            return null;
        }
        public bool IsRebaseUnMerge(string szPath)
        {
            string szRepo = CHelpFuntions.GetValidWorkingDir(szPath);
            if (string.IsNullOrEmpty(szRepo))
            {
                return false;
            }
            else
            {
                int nMergeTypebIsUnmerge =CHelpFuntions.IsAnyRebaseOrMergeInfo(szRepo);
                bool bIsUnmerge = _objGitMgrCore.IsAnyUnMergeFile(szRepo);
                
                if (bIsUnmerge == true || nMergeTypebIsUnmerge != 0)
                    return true;
                else
                    return false;  
            }

        }
        public void GitSwitchBranch(string szCurOperationPath)
        {
            string szRepo = CHelpFuntions.GetValidWorkingDir(szCurOperationPath);
            if (string.IsNullOrEmpty(szRepo))
                return ;
            SwitchBranch(szCurOperationPath);
        }

        public void GitIgnore(string szCurOperationPath)
        {
            Ignore(szCurOperationPath);
        }
        public void GitStash(string szCurOperationPath)
        {
            Stash(szCurOperationPath);
        }
        public void GitStage(string szCurOperationPath)
        {
            AddFiles(szCurOperationPath, null);
        }
        public void GitUnStage(string szCurOperationPath)
        {
            UnStageFiles(szCurOperationPath, null);
        }
        public void GitCommit(string szCurOperationPath)
        {
            Commit(szCurOperationPath, null);
        }
        public void GitRevert(string szCurOperationPath)
        {
            List<string> FileList = new List<string>();
            FileList.Clear();
            Discard(szCurOperationPath, FileList);
        }
        public void GitPush(string szCurOperationPath, string szCurBranch)
        {
            string szRepo = CHelpFuntions.GetValidWorkingDir(szCurOperationPath);
            if (string.IsNullOrEmpty(szRepo))
                return;
            PushCurrentBranch(szCurOperationPath, szCurBranch);
        }
        public void GitFetch(string szCurOperationPath, string szCurBranch)
        {
            string szRepo = CHelpFuntions.GetValidWorkingDir(szCurOperationPath);
            if (string.IsNullOrEmpty(szRepo))
                return;
            FetchFromRemote(szCurOperationPath, szCurBranch);
        }
        public void GitSync(string szCurOperationPath, string szCurBranch)
        {
            string szRepo = CHelpFuntions.GetValidWorkingDir(szCurOperationPath);
            if (string.IsNullOrEmpty(szRepo))
                return;
            PullCurrentBranch(szCurOperationPath, szCurBranch);
        }
        public void GitConflict(string szCurOperationPath, string szCurBranch)
        {
            string szRepo = CHelpFuntions.GetValidWorkingDir(szCurOperationPath);
            if (string.IsNullOrEmpty(szRepo))
                return;
            ResolveConflicts(szRepo,szCurBranch);
        }

        public void GitGraph(string szCurOperationPath, string szCurBranch)
        {
            string szRepo = CHelpFuntions.GetValidWorkingDir(szCurOperationPath);
            if (string.IsNullOrEmpty(szRepo))
                return;
            Gitk(szRepo);
        }

        #endregion


    }
}
