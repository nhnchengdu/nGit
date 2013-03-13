using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
namespace Git.Core.Commands
{
    public static class CGitCmdReset
    {

        //get local branch
        public static string Reset2SpecCommit(string szTargetCommit,int nType, out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szTargetCommit))
            {
                iReturnCode = 0;
                return null;
            }

            string szExeCmd;
            if (nType == 0)  //all
            {
                szExeCmd = string.Format("reset --hard  -q {0}", szTargetCommit);
            }
            else if(nType == 1) //index and head
            {
                szExeCmd = string.Format("reset --mixed  -q {0}", szTargetCommit);
            }
            else if (nType == 2)//head
            {
                szExeCmd = string.Format("reset --soft  -q {0}", szTargetCommit);
            }
            else //index
            {
                szExeCmd = string.Format("reset -q {0} -- .", szTargetCommit);
            }
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (String.IsNullOrEmpty(szInfo)||szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return szInfo;
            return null;
        }

        public static bool ResetIndex(List<string> FileList, out int iReturnCode)
        {

            string szExeCmd=string.Empty; 
            if (FileList == null || FileList.Count==0)
            {
                szExeCmd= string.Format("reset --mixed");
            }
            else
            {
                szExeCmd = string.Format("reset  -- ");
                foreach (string szItme in FileList)
                {
                    szExeCmd = string.Format("{0}\"{1}\" ", szExeCmd, szItme);
                }
            }
            
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (iReturnCode != 0)
                return false;
            return true;
        }



    }
}
