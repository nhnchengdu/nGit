using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;

namespace Git.Core.Commands
{
    public static class CGitCmdCommit
    {
        public static string CommitALLStaged(string Message)
        {
            int iReturnCode = -1;
            string szResult = null;

            string szExeCmd = string.Format("commit -m \"{0} \"", Message);
            szResult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (szResult != null && iReturnCode!=0)
            {
                szResult = ParseOperaResult(szResult, iReturnCode);
            }
            else if (iReturnCode == 0)
            {
                szResult = null;
            }
            return szResult;
        }

        public static string CommitALLChanged(string Message)
        {
            int iReturnCode = -1;
            string szResult = null;

            szResult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("commit -a -m " + Message, out iReturnCode);
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


        public static string CommitSelected(List<String> FileList,string Message)
        {
            int iReturnCode = -1;
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
                szExecuteCmd = @"commit" + szExecuteCmd;
                szExecuteCmd = szExecuteCmd + " -m " + "\"" + Message+ "\"";
            }
            else
            {
                return null;
            }

            szResult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
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
