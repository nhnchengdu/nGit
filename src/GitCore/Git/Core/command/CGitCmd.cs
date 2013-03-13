using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;

namespace Git.Core.Commands
{
    public static class CGitCmd
    {
        public static string GetVersion()
        {
            string szExcuteCmd = string.Format("--version");
            int iReturnCode = -1;
            string szInfo = null;
            szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExcuteCmd, out iReturnCode);
            if (string.IsNullOrEmpty(szInfo)||szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return string.Empty;
            else
            {
                string[] ResArray = szInfo.Split(new[] { '\r', '\n', '\0', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if(ResArray.Length>0)
                    return ResArray[ResArray.Length-1];
                else
                    return string.Empty;
            }            
        }
    }
}
