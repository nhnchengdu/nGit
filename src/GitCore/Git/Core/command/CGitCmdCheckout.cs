using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;

namespace Git.Core.Commands
{
    public static class CGitCmdCheckout
    {
        public static bool CheckOutUnmergeFile(bool bIsMine, string szFileName)
        {
            string szExeCmd;
            if(bIsMine)
                szExeCmd = string.Format("checkout --ours \"{0}\"", szFileName);
            else
                szExeCmd = string.Format("checkout --theirs \"{0}\"", szFileName);

            int iCode = -1;
            string szRes= CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iCode);
            if (iCode == 0 && string.IsNullOrEmpty(szRes))
                return true;
            else
                return false;
       
        }

        public static string CheckOutWholeCommit(string szSHA, out int iReturnCode)
        {
            string szExeCmd = string.Format("checkout {0} .", szSHA);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);

        }

        public static string SwitchBranchTo(string szTargetBrname, out int iReturnCode)
        {
            string szExeCmd = string.Format("checkout {0}", szTargetBrname);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);

        }

        //create a branch and check out it.
        public static string CreateBrandCheckOut(string szSHA, string szBranchName, out int iReturnCode)
        {
            string szExeCmd = string.Format("checkout -b {0} {1}", szBranchName, szSHA);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
        }


        public static string ToCurrentStage(List<String> FileList)
        {
            string szResult = null;
            String szExecuteCmd = null;
            foreach (string szItem in FileList)
            {
                string szRefPath = CHelpFuntions.GetRelativeFilePath(CGitSourceConfig.m_szWorkingDir, szItem);
                if (szRefPath.Equals(string.Empty))
                    continue;
                szExecuteCmd = szExecuteCmd + " \"" + szRefPath.Replace("\\", "/") + "\"";
            }
            if (szExecuteCmd != null)
            {
                szExecuteCmd = @"checkout  --" + szExecuteCmd;
            }
            else
            {
                return null;
            }

            szResult = Run(szExecuteCmd);
            return szResult;
        }
        public static string ToAllCurrentStage()
        {
            string szResult = null;
            String szExecuteCmd = @"checkout  -- ."; 
            szResult = Run(szExecuteCmd);
            return szResult;
        }
        public static string ToAllCurrentResp()
        {
            string szResult = null;
            String szExecuteCmd = @"checkout HEAD  -- .";
            szResult = Run(szExecuteCmd);
            return szResult;
        }

        public static string ToCurrentResp(List<String> FileList)
        {
            ////////////////////////////////////////////////////////
            //command: git checkout HEAD  -- file_name  
            //equal
            //command: git reset file_Name
            //         git checkout  -- file_name
            ////////////////////////////////////////////////////////

            string szResult = string.Empty;
            String szExecuteCmd = string.Empty;
            foreach (string szItem in FileList)
            {
                string szRefPath = CHelpFuntions.GetRelativeFilePath(CGitSourceConfig.m_szWorkingDir, szItem);
                if (szRefPath.Equals(string.Empty))
                    continue;
                szExecuteCmd = szExecuteCmd + " \"" + szRefPath.Replace("\\", "/") + "\"";
            }
            if (string.IsNullOrEmpty(szExecuteCmd))
            {
                return null;
            }
            else
            {
                szExecuteCmd = @"checkout HEAD --" + szExecuteCmd;                
            }

            szResult = Run(szExecuteCmd);
            return szResult;
        }

        private static string Run(string szCmd)
        {
            int iReturnCode = -1;
            string szResult = null;

            szResult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szCmd, out iReturnCode);
            if (szResult != null && iReturnCode != 0)
            {
                szResult = ParseOperaResult(szResult, iReturnCode);
            }
            else if (iReturnCode == 0)
            {
                szResult = null;
            }
            return szResult;        
        }

        private static string ParseOperaResult(string szResult, int iReturnCode)
        {
            return szResult;

        }

    }
}
