using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;

namespace Git.Core.Commands
{
    public static class CGitCmdDiffTool
    {
        public static void CompareOneFile(string szTarget, string szSource, string szFile, out int iReturnCode)
        {
            string szExeCmd = string.Format("difftool -y {0} {1} -- \"{2}\"", szTarget, szSource, szFile);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
        }
    }
}
