using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;
using System.Diagnostics;

namespace Git.Core.Commands
{
    public static class CGitCmdSvn
    {
        
        public static Process CloneAsynch(string szRepositoryUrl, string szWorkingDir, string szUser,DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            if (string.IsNullOrEmpty(szWorkingDir)||string.IsNullOrEmpty(szRepositoryUrl))
            {
                return null ;
            }
            string szArgument = GetArgument(szRepositoryUrl, szWorkingDir, szUser, 0);

           return CGitSourceConfig.m_objGitSrcModule.RunGitCmdAsynch(szArgument,AppHandleOutput,AppHandleError,AppHandleAbort);

        }

        private static string GetArgument (string szRepositoryUrl, string szWorkingDir,string szUser,int iDepth)
        {
            StringBuilder szExecuteCmd=new StringBuilder();
            szExecuteCmd.Append("svn clone ");

            if (!string.IsNullOrEmpty(szUser))
                szExecuteCmd.Append(" --username " + szUser);

            szExecuteCmd.Append(string.Format(" \"{0}\"", szRepositoryUrl.Trim().Replace("\\", "/")));
            szExecuteCmd.Append(string.Format(" \"{0}\"", szWorkingDir.Trim().Replace("\\", "/")+"/"));
            return szExecuteCmd.ToString();
        }


        public static void ParseOperaResult(string szResult, int nrefer)
        {



        }
    }
}
