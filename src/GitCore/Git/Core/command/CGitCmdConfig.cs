using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using System.Diagnostics;

namespace Git.Core.Commands
{
    public static class CGitCmdConfig
    {
        public static Dictionary<string, string> GetAllTracking(Dictionary<string, string> localbranchList)
        {
            if (localbranchList.Count < 0)
            {
                return null;
            }

            Dictionary<string, string> mapAllTracking = new Dictionary<string, string>();
            int iReturnCode = -1;
            string szResult = null;
            string szResult2 = null;
            string szExecuteCmd = null;
            foreach(string szTmp in localbranchList.Keys)
            {
                if (string.IsNullOrEmpty(szTmp))
                {
                    continue;
                }

                szExecuteCmd = string.Format("config branch.\"{0}\".remote", szTmp);
                szResult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
                if (szResult.Trim().StartsWith("fatal:") ||
                    szResult.Trim().StartsWith("error:") || string.IsNullOrEmpty(szResult.Trim()) || iReturnCode != 0)
                {
                    continue;
                }

                szExecuteCmd = string.Format("config branch.\"{0}\".merge", szTmp);
                szResult2 = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
                if (szResult2.Trim().StartsWith("fatal:") ||
                    szResult2.Trim().StartsWith("error:") || string.IsNullOrEmpty(szResult2.Trim()) || iReturnCode != 0)
                {
                    continue;
                }

                int nPos = szResult2.LastIndexOf("/");
                if (nPos < 0)
                {
                    continue;
                }
                szResult2 = szResult2.Substring(nPos + 1, szResult2.Length - nPos - 1);
                string szContent = szResult.Trim('\n') + " (" + szResult2.Trim('\n') + ")";
                mapAllTracking.Add(szTmp, szContent);
            }
            return mapAllTracking;
        }
        public static string GetSingleTracking(string szBranchName)
        {
            if (string.IsNullOrEmpty(szBranchName))
            {
                return null;
            }

            int iReturnCode = -1;
            string szResult = null;
            string szResult2 = null;
            string szExecuteCmd = null;
            string szTmp = szBranchName;


            szExecuteCmd = string.Format("config branch.\"{0}\".remote", szTmp);
            szResult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            if (szResult.Trim().StartsWith("fatal:") ||
                szResult.Trim().StartsWith("error:") || string.IsNullOrEmpty(szResult.Trim()) || iReturnCode != 0)
            {
                return null;
            }

            szExecuteCmd = string.Format("config branch.\"{0}\".merge", szTmp);
            szResult2 = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            if (szResult2.Trim().StartsWith("fatal:") ||
                szResult2.Trim().StartsWith("error:") || string.IsNullOrEmpty(szResult2.Trim()) || iReturnCode != 0)
            {
                return null;
            }

            int nPos = szResult2.LastIndexOf("/");
            if (nPos < 0)
            {
                return null;
            }
            szResult2 = szResult2.Substring(nPos + 1, szResult2.Length - nPos - 1);
            string szContent = szResult.Trim('\n') + @"/"+ szResult2.Trim('\n');
            return szContent;
        }
        public static string SetParameters(string szPara, out int iReturnCode)
        {
            string szExeCmd = string.Format("config {0}", szPara);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return szInfo;
            else
                return string.Empty;
        }
        public static string SetGlobalParameters(string szPara, out int iReturnCode)
        {
            string szExeCmd = string.Format("config --global {0}", szPara);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return szInfo;
            else
                return string.Empty;
        }

        public static string GetValue(string szPara, out int iReturnCode)
        {
            string szExeCmd = string.Format("config {0}", szPara);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExeCmd, out iReturnCode);
            if (string.IsNullOrEmpty(szInfo)||szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return string.Empty;
            else
                return szInfo.Trim('\n');
        }
    }
}
