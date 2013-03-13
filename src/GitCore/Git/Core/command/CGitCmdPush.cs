using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using System.Diagnostics;

namespace Git.Core.Commands
{
    public static class CGitCmdPush
    {
        //asynch operation
        public static Process UpLoadBranchAsynch(string szRemoteRepoName, string szBranch,DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            if (string.IsNullOrEmpty(szRemoteRepoName) || string.IsNullOrEmpty(szBranch))
            {
                return null;
            }
            string szExeCmd = string.Format("push {0} {1}", szRemoteRepoName, szBranch);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmdAsynch(szExeCmd, AppHandleOutput, AppHandleError, AppHandleAbort);
        }

        //asynch operation
        public static Process RemoveBranch(string szRemoteRepoName, string szBranch, DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            if (string.IsNullOrEmpty(szRemoteRepoName) || string.IsNullOrEmpty(szBranch))
            {
                return null;
            }
            string szExeCmd = string.Format("push {0} :{1}", szRemoteRepoName, szBranch);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmdAsynch(szExeCmd, AppHandleOutput, AppHandleError, AppHandleAbort);
        }

        //asynch operation
        public static Process Commit2SpecBranch(string szRemoteRepoName, string szLocalBranch,string szRemoteBranch,bool bIsFoece,DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            if (string.IsNullOrEmpty(szRemoteRepoName) || string.IsNullOrEmpty(szLocalBranch) || string.IsNullOrEmpty(szRemoteBranch))
            {
                return null;
            }
            
            string szExeCmd =string.Empty;
            if (bIsFoece==false)
                szExeCmd= string.Format("push  -v --progress {0} {1}:{2}", szRemoteRepoName, szLocalBranch,szRemoteBranch);
            else
                szExeCmd = string.Format("push  -v --progress --force {0} {1}:{2}", szRemoteRepoName, szLocalBranch, szRemoteBranch);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmdAsynch(szExeCmd, AppHandleOutput, AppHandleError, AppHandleAbort);
        }
        public static int ParseOperaResult(string szResult)
        {
            int iProgress = 0;
            if(string.IsNullOrEmpty(szResult))
                return iProgress;

            if (szResult.Contains("%"))
            {
                int index = szResult.IndexOf('%');
                int progressValue;
                if (index > 4 && int.TryParse(szResult.Substring(index - 3, 3), out progressValue))
                {
                    iProgress = progressValue;
                }
            }
            return iProgress;
        }

    }
}
