using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
namespace Git.Core.Commands
{
    public static class CGitCmdRebase
    {
        public static string Rebase(string szBranchTo, string szBranchFrom, out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szBranchTo) || string.IsNullOrEmpty(szBranchFrom))
            {
                iReturnCode = -1;
                return string.Empty;
            }

            string szExecuteCmd = string.Format("rebase {0} {1}", szBranchTo, szBranchFrom);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            return szInfo;
        }

        public static string ContinueRebase(out int iReturnCode)
        {
            string szExecuteCmd = string.Format("rebase --continue");
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            return szInfo;
        }

        public static string AbortRebase(out int iReturnCode)
        {
            string szExecuteCmd = string.Format("rebase --abort");
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            return szInfo;
        }
        public static string SkiptRebase(out int iReturnCode)
        {
            string szExecuteCmd = string.Format("rebase --skip");
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            return szInfo;
        }
    }
}
