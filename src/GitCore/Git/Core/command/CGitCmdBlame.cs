using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;

namespace Git.Core.Commands
{
    public static class CGitCmdBlame
    {
        public static string GetDetails(String szTargetFile,string szCommitSHA)
        {
            if (string.IsNullOrEmpty(szTargetFile))
            {
                return null;
            }

            string szExcuteCmd;
            if(string.IsNullOrEmpty(szCommitSHA))
                szExcuteCmd= string.Format("blame  -- \"{0}\"", szTargetFile);
            else                  
                szExcuteCmd= string.Format("blame {0} -- \"{1}\"", szCommitSHA, szTargetFile);

            int iReturnCode = -1;
            string szInfo = null;
            szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExcuteCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return szInfo;            
        }

        public static string[] ParesBlameDetail(string szInfo)
        {
            return null;
            /*
            if (string.IsNullOrEmpty(szInfo))
            {
                return null;
            }


            string[] ResArray = szInfo.Split(new[] { '\r', '\n', '\0' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ResArray.Length; i++)
            {
                if (ResArray[i].Length == 40 && ResArray[i].IndexOf("warning") < 0) // a warning will be caused when tag and branch is same
                {
                    return ResArray[i].ToString();
                }
            }
            return null;
             
             */
        }



    }
}
