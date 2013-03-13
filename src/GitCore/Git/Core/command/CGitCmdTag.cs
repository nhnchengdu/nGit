using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
namespace Git.Core.Commands
{
    public static class CGitCmdTag
    {
        //get local branch
        public static string ShowTag(out int iReturnCode)
        {
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("tag", out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return szInfo;
        }
        public static string CreateTag(string szSHA, string TagName,out int iReturnCode)
        {
            string szExeCmd = string.Format("tag {0} {1}", TagName, szSHA);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);

        }

        public static string DeleteTag(string TagName, out int iReturnCode)
        {
            string szExeCmd = string.Format("tag -d {0}", TagName);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);

        }
        public static string[] ParseShow(string szResult)
        {
            if (string.IsNullOrEmpty(szResult))
                return null;

            string[] ResArray = szResult.Split(new[] { '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ResArray.Length; i++)
            {
                ResArray[i] = ResArray[i].Trim();
            }
            return ResArray;
        }
    }
}
