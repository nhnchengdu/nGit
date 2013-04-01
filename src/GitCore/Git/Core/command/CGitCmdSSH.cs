using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Git.Core.SourceApp;
using System.Diagnostics;

namespace Git.Core.Commands
{
    class CGitCmdSSH
    {
        //get local branch
        public static string CreateSSHKey(string szComInfo)
        {
           // string szExeCmd = string.Format("-t rsa -C \"{0}\" -N \"@nhn.com\" -P \"@nhn.com\" -f \"{1}\"", szComInfo, szComInfo);
            string szExeCmd = string.Format("-t rsa -C \"{0}\" -N \"\" -P \"\" -f \"{1}\\id_rsa\"", szComInfo, szComInfo);     

            int iReturnCode = 1;
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunCommonCmd(@"ssh-keygen", szExeCmd, out iReturnCode);
            if (String.IsNullOrEmpty(szInfo) || szInfo.Contains("failed") || iReturnCode != 0)
                return null;
            return szInfo;
        }

        public static Process CheckSshKey(string szSSHURL, DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            szSSHURL=szSSHURL.TrimEnd(':');
            string szPort = null;
            string szUrl = szSSHURL;

            int nPos = szSSHURL.LastIndexOf(":");
            if (nPos >= 0)
            {
                szPort = szSSHURL.Substring(nPos + 1, szSSHURL.Length - nPos - 1);
                szUrl = szSSHURL.Substring(0, nPos );
            }

            string szExeArgument;
            if(string.IsNullOrEmpty(szPort.Trim()))
            {
                szExeArgument = string.Format("-T \"{0}\"", szUrl); ;
            }
            else
            {
                szExeArgument = string.Format("-T -p {0} \"{1}\"", szPort, szUrl); ;        
            }
            string.Format("-T -p 29418 username@git.platform.nhncorp.cn \"{0}\"", szSSHURL);
            return CGitSourceConfig.m_objGitSrcModule.RunCommonCmdAsynch(@"ssh", szExeArgument, AppHandleOutput, AppHandleError, AppHandleAbort);
        }


    }
}

