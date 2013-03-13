using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;

namespace Git.Core.Commands
{
    public static class CGitCmdRefLog
    {
        public static string[] GetReflogList(string szBranch, out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szBranch))
            {
                iReturnCode = 0;
                return null;
            }

            String szExecuteCmd = string.Format("reflog show {0}  -20", szBranch);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;

            if (string.IsNullOrEmpty(szInfo))
            {
                return null;
            }

            string[] ResArray = szInfo.Split(new[] { '\r', '\n', '\0'}, StringSplitOptions.RemoveEmptyEntries);
            return ResArray;
        }

    }
}
