using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using System.Diagnostics;

namespace Git.Core.Commands
{
    public static class CGitCmdPull
    {
        //asynch operation       
        public static Process PullBranchAsynch(string szRemoteRepoName,string szRemoteBranch,bool bIsRebaseMode,DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            if (string.IsNullOrEmpty(szRemoteRepoName) || string.IsNullOrEmpty(szRemoteBranch))
            {
                return null;
            }
            
            string szExeCmd =string.Empty;
            if (bIsRebaseMode == false)
                szExeCmd= string.Format("pull  -v --progress {0} {1}", szRemoteRepoName,szRemoteBranch);
            else
                szExeCmd = string.Format("pull  -v --progress --rebase  {0} {1}", szRemoteRepoName, szRemoteBranch);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmdAsynch(szExeCmd, AppHandleOutput, AppHandleError, AppHandleAbort);
        }

    }
}
