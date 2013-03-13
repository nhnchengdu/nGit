using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;

namespace Git.Core.Commands
{
    public static class CGitCmdMergeTool
    {

        //get local branch
        public static string MergeOneFile(string szFielName,out int iReturnCode)
        {
            string szExeCmd = string.Format("mergetool -y \"{0}\"",szFielName);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (iReturnCode == 0)
                return null;
            return szInfo;
        }
    }
}
