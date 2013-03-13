using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;

namespace Git.Core.Commands
{
    public static class CGitCmdRevParse
    {

        public static string GetHashID(string szRefer,out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szRefer))
            {
                iReturnCode = 0;
                return null;
            }
            String szExecuteCmd = @"rev-parse ";
            szExecuteCmd = szExecuteCmd + szRefer;

            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return szInfo;
        }

        public static string ParesSHA(string szInfo)
        {
            if (string.IsNullOrEmpty(szInfo))
            {
                return null;
            }


            string[] ResArray = szInfo.Split(new[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ResArray.Length; i++)
            {
                if (ResArray[i].Length == 40 && ResArray[i].IndexOf("warning") < 0) // a warning will be caused when tag and branch is same
                {
                    return ResArray[i].ToString();
                }
            }
            return null;
        }


    }
}
