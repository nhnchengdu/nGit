using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using System.Diagnostics;


namespace Git.Core.Commands
{
    public static class CGitCmdLsFiles
    {
        public static bool IsAnyUnMergeFile(out int iReturnCode)
        {
            String szExecuteCmd = string.Format("ls-files -u");
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            if (iReturnCode == 0&&string.IsNullOrEmpty(szInfo)==false)
                return true;
            else
                return false;
        }

    }
}
