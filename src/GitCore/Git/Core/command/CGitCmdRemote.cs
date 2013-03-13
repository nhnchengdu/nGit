using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using System.Diagnostics;

namespace Git.Core.Commands
{
    public static class CGitCmdRemote
    {
        public static string RemvoeRedundantBr(string szRemoteName,out int iReturnCode)
        {
            string szExeCmd = string.Format("remote prune {0}", szRemoteName);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
        }

        //asynch operation
        public static Process UpdateAsynch(string szRemoteRepoName,DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            if (string.IsNullOrEmpty(szRemoteRepoName))
            {
                return null;
            }
            string szExeCmd = string.Format("remote update \"{0}\"", szRemoteRepoName);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmdAsynch(szExeCmd, AppHandleOutput, AppHandleError, AppHandleAbort);

        }




        public static string Rename(string szRemoteName, string szNewName,out int iReturnCode)
        {
            string szExeCmd = string.Format("remote rename \"{0}\" \"{1}\"", szRemoteName,szNewName);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return szInfo;
            else
                return string.Empty;
        }

        public static string RemoveRemote(string szRemoteName, out int iReturnCode)
        {
            string szExeCmd = string.Format("remote rm \"{0}\"", szRemoteName);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return szInfo;
            else
                return string.Empty;
        }

        public static string AddRemote(string szRemoteName, string szRemoteURL,out int iReturnCode)
        {
            string szExeCmd = string.Format("remote add \"{0}\" {1}", szRemoteName, szRemoteURL);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return szInfo;
            else
                return string.Empty;
        }

        public static string SetRemote(string szRemoteName, string szRemoteURL, bool bIsPush,out int iReturnCode)
        {
            string szExeCmd = string.Empty;
            if(bIsPush==true)
                szExeCmd = string.Format("remote set-url --push \"{0}\" {1}", szRemoteName, szRemoteURL);
            else
                szExeCmd = string.Format("remote set-url \"{0}\" {1}", szRemoteName, szRemoteURL);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return szInfo;
            else
                return string.Empty;
        }

        public static string GetAllRemote()
        {

            int iReturnCode = -1;
            string szResult = null;
            szResult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("remote -v", out iReturnCode);
            if (szResult.Trim().StartsWith("fatal:") || szResult.Trim().StartsWith("error:") || iReturnCode != 0)
                    return null;
            return szResult;
        }

        public static Dictionary<string, string> ParesAllRemote(string szInfo)
        {
            if (string.IsNullOrEmpty(szInfo))
            {
                return null;
            }

            Dictionary<string, string> mapAllRemotes = new Dictionary<string, string>();

            string[] ResArray = szInfo.Split(new[] { '\r', '\n','\0'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ResArray.Length; i++)
            {
                string[] ItemArray1 = ResArray[i].Split(new[] { '\t', ' '}, StringSplitOptions.RemoveEmptyEntries);
                string[] ItemArray2 = ResArray[++i].Split(new[] { '\t', ' '}, StringSplitOptions.RemoveEmptyEntries);
                if (ItemArray1[0].Equals(ItemArray2[0]) && ItemArray1.Length == 3 && ItemArray2.Length == 3)
                {
                    string szTmp = ItemArray1[2] + ItemArray1[1];
                    szTmp += "\t" + ItemArray2[2] + ItemArray2[1];
                    if (!mapAllRemotes.ContainsKey(ItemArray1[0]))
                    {
                        mapAllRemotes.Add(ItemArray1[0], szTmp);
                    }
                }
            }
            return mapAllRemotes;
        }



    }
}
