using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Git.Core.Commands
{
    public static class CGitCmdMergeBase
    {
        public static string GetLastAncestor(string szCommitFrom, string szCommitTo)
        {
            if (string.IsNullOrEmpty(szCommitFrom) || string.IsNullOrEmpty(szCommitTo))
            {
                return string.Empty;
            }

            int iReturnCode = 0;
            String szExecuteCmd = string.Format("merge-base {0} {1}", szCommitFrom, szCommitTo);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            if (string.IsNullOrEmpty(szInfo) || szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return string.Empty;

            string szRegex = @"[0-9a-f]{40}";
            Regex r = new Regex(szRegex); 
            Match mc = r.Match(szInfo); 

            if (mc != null && mc.Success == true)
            {
                return mc.Value.Trim();
            }
            else
            {
                return string.Empty;
            }
        }  
    }
}
