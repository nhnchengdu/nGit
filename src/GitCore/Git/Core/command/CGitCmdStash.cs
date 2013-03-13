using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
namespace Git.Core.Commands
{
    public static class CGitCmdStash
    {

        //get local branch
        public static string SaveWithUnTracked(string szMsg,out int iReturnCode)
        {
            string szExecmd = string.Format("stash save -u  \"{0}\"", szMsg);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return szInfo;
        }
        public static string SaveOnlyTracked(out int iReturnCode)
        {
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("stash", out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return szInfo;
        }
        public static string Pop(out int iReturnCode)
        {
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("stash pop --index", out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return szInfo;
        }

        public static string apply(out int iReturnCode)
        {
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("stash apply --index", out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return szInfo;
        }

        public static string ApplySelected(int nIndex,out int iReturnCode)
        {
            string szExecmd = @"stash apply --index stash@{";
            szExecmd = szExecmd + nIndex.ToString() + @"}";
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return szInfo;
        }

        public static string[] GetLists(out int iReturnCode)
        {
            string szExecmd = string.Format("stash list");
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecmd, out iReturnCode);
            if (string.IsNullOrEmpty(szInfo)||szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            string[] ResArray = szInfo.Split(new[] { '\r', '\n', '\0'}, StringSplitOptions.RemoveEmptyEntries);
            return ResArray;
        }

        public static string Clear( out int iReturnCode)
        {
            string szExecmd = string.Format("stash clear");
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return szInfo;
        }
    }
}
