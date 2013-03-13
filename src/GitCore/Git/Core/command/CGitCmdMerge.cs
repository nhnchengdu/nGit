using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
namespace Git.Core.Commands
{
    public static class CGitCmdMerge
    {
        public static string Merge(string szMsg,string szSource,out int iReturnCode)
        {
            if(string.IsNullOrEmpty(szSource))
            {
                iReturnCode=-1;
                return string.Empty;
            }

            string szExecuteCmd = string.Format("merge --commit --ff --progress -m\"{0}\" {1}" ,szMsg ,szSource);  
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            return szInfo;
        }

    }
}
