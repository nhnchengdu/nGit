using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
namespace Git.Core.Commands
{
    public static class CGitCmdBranch
    {
        public static string run(out int iReturnCode)
        {
            string szInfo= CGitSourceConfig.m_objGitSrcModule.RunGitCmd("branch", out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode<0)
                return null;
            return szInfo;
        }


        //get local branch
        public static string GetLocalBranch(out int iReturnCode)
        {
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("branch", out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode!= 0)
                return null;
            return szInfo;
        }
        public static string[] ParseLocal(string szResult)
        {
            if (string.IsNullOrEmpty(szResult))
                return null;

            string[] ResArray = szResult.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ResArray.Length; i++)
            {
                ResArray[i] = ResArray[i].Trim();
            }

            //first node is current branch, it will be set empty when squash status.
            if (ResArray[0].StartsWith(@"* (no branch)"))
            {
                ResArray[0] = string.Empty;
            }
            else
            {
                bool bIsNoWorkingBr = true;
                for (int i = 0; i < ResArray.Length; i++)
                {
                    if (ResArray[i].StartsWith("* "))
                    {
                        string szCurrBranch = ResArray[i].Substring(2);
                        ResArray[i] = ResArray[0];
                        ResArray[0] = szCurrBranch;
                        bIsNoWorkingBr = false;
                        break;
                    }
                }
                if(bIsNoWorkingBr&&ResArray.Length>0)
                {
                    string[] ResArray2 =new string[ResArray.Length+1];
                    ResArray2[0] = string.Empty;
                    for (int i = 0; i < ResArray.Length; i++)
                    {
                        ResArray2[i+1] = ResArray[i];
                    }
                }
            }


            return ResArray;
        }


        //get remote branch
        public static string GetRemoteBranch(out int iReturnCode)
        {
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("branch -r", out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return szInfo;
        }
        public static string[] ParseRemote(string szResult)
        {
            if (string.IsNullOrEmpty(szResult))
                return null;

            string[] ResArray = szResult.Split(new[] { '\r', '\n', '*' }, StringSplitOptions.RemoveEmptyEntries);

            // Deal with followed status: 'origin/HEAD -> origin/master'
            for (int i = 0; i < ResArray.Length; i++)
            {
                ResArray[i] = ResArray[i].Trim();
                int nPos = ResArray[i].IndexOf(" ->");
                if (nPos >= 0)
                {
                    ResArray[i] = ResArray[i].Substring(0,nPos);
                }
            }
            return ResArray;
        }


        //add branch
        public static string CreateBranch(string szSHA, string szBranchName, out int iReturnCode)
        {
            string szExeCmd = string.Format("branch {0} {1}", szBranchName, szSHA);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);

        }

        public static string DeleteBranch(string szBrName,bool bIsForce, out int iReturnCode)
        {
            string szExeCmd;
            if(bIsForce==true)
            {
                szExeCmd = string.Format("branch -D {0}", szBrName);
            }
            else
            {
                szExeCmd = string.Format("branch -d {0}", szBrName);
            }
            
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);

        }
    }
}
