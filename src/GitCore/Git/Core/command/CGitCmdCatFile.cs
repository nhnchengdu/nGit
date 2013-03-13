using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;
using System.IO;

namespace Git.Core.Commands
{
    /// <summary>
    /// this command will get file contents from git repository
    /// </summary>
    public static class CGitCmdCatFile
    {      
        public static string GetFileContent(string szSHA,out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szSHA))
            {
                iReturnCode = 0;
                return null;
            }

            string szExcuteCmd = string.Format("cat-file blob {0}", szSHA);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExcuteCmd, out iReturnCode);

        }

        public static Stream GetFileStream(string szBlobSHA)
        {
            if (string.IsNullOrEmpty(szBlobSHA))
            {
                return null;
            }

            string szExcuteCmd = string.Format("cat-file blob {0}", szBlobSHA);
            return CGitSourceConfig.m_objGitSrcModule.RunCmdGetFile(szExcuteCmd); 

        }


    }
}
