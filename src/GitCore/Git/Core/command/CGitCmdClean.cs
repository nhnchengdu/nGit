using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
namespace Git.Core.Commands
{
    public static class CGitCmdClean
    {

        //get local branch
        public static string CleanWithForce(out int iReturnCode)
        {


            string szExeCmd;
            szExeCmd = string.Format("clean -d -f -q");

            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (String.IsNullOrEmpty(szInfo) || szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return szInfo;
            return null;
        }

    }
}
