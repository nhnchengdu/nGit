using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;
using System.Diagnostics;

namespace Git.Core.Commands
{
    public static class CGitCmdClone
    {
        
        public static Process runAsynch(string szRepositoryUrl, string szWorkingDir,DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            if (string.IsNullOrEmpty(szWorkingDir)||string.IsNullOrEmpty(szRepositoryUrl))
            {
                return null ;
            }
            string szArgument=GetArgument(szRepositoryUrl,szWorkingDir,null,0);

           return CGitSourceConfig.m_objGitSrcModule.RunGitCmdAsynch(szArgument,AppHandleOutput,AppHandleError,AppHandleAbort);

        }

        private static string GetArgument (string szRepositoryUrl, string szWorkingDir,string szBranch,int iDepth)
        {
            StringBuilder szExecuteCmd=new StringBuilder();
            szExecuteCmd.Append("clone -v --progress ");

            if (!string.IsNullOrEmpty(szBranch))
                szExecuteCmd.Append(" --branch " + szBranch);
            if (iDepth>0)
                szExecuteCmd.Append(" --depth " + iDepth.ToString());

            szExecuteCmd.Append(string.Format(" \"{0}\"", szRepositoryUrl.Trim().Replace("\\", "/")));
            szExecuteCmd.Append(string.Format(" \"{0}\"", szWorkingDir.Trim().Replace("\\", "/")+"/"));

            return szExecuteCmd.ToString();
        }

        public static string ParseOperaResult(string szResult, out int iProgress, out int nrefer)
        {
            iProgress = 0;

            if (szResult.StartsWith("Fatal"))
            {
                iProgress = -1;
                nrefer = -1;
                szResult = "Fatal Error";
            }
            else if (szResult.StartsWith("POST git-upload-pack"))
            {
                nrefer = -1;
                iProgress = 4;                
            }
            else if (szResult.StartsWith("remote: Counting objects"))
            {
                nrefer = -1;
                iProgress = 8;                
            }
            else if (szResult.Contains("%") && szResult.StartsWith("remote: Compressing objects"))
            {
                int index = szResult.IndexOf('%');
                int progressValue;
                nrefer = -1;
                if (index > 4 && int.TryParse(szResult.Substring(index - 3, 3), out progressValue))
                {
                    nrefer = progressValue;
                    iProgress = 10 + progressValue / 5;
                    szResult = "remote: Compressing objects.....";
                }
                    
            }
            else if (szResult.Contains("%") && szResult.StartsWith("Receiving objects"))
            {
                int index = szResult.IndexOf('%');
                int progressValue;
                nrefer = -1;
                if (index > 4 && int.TryParse(szResult.Substring(index - 3, 3), out progressValue))
                {
                    nrefer = progressValue;
                    iProgress = 30 + progressValue / 2;
                    szResult = "Resolving deltas.....";
                }
            }
            else if (szResult.Contains("%") && szResult.StartsWith("Resolving deltas"))
            {
                int index = szResult.IndexOf('%');
                int progressValue;
                nrefer = -1;
                if (index > 4 && int.TryParse(szResult.Substring(index - 3, 3), out progressValue))
                {
                    nrefer = progressValue;
                    iProgress = 80 + progressValue / 5;
                    szResult = "Receiving objects.....";
                }
            }
            else
            {
                nrefer = -1;
                iProgress =200;
            }
            return szResult;
        }
    }
}
