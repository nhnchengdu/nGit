using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Git.Core.Commands
{
    public static class CGitCmdLsTree
    {
        public static string GetTreeContent(string szTreeSHA, out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szTreeSHA))
            {
                iReturnCode = 0;
                return null;
            }

            String szExecuteCmd = string.Format("ls-tree --abbrev=8 -z {0}", szTreeSHA);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return szInfo;
        }

        public static Dictionary<string, string> ParesTreeContent(string szInfo)
        {
            if (string.IsNullOrEmpty(szInfo))
            {
                return null;
            }

            Dictionary<string, string> mapFileTree = new Dictionary<string, string>();

            string[] ResArray = szInfo.Split(new[] { '\r', '\n','\0'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ResArray.Length; i++)
            {

                if (string.IsNullOrEmpty(ResArray[i])||ResArray[i].Length<23)
                    continue;

                string szConetent = ResArray[i].Substring(7, 4); //type
                string szSHA = ResArray[i].Substring(12, 8);     //ID
                int nPos=ResArray[i].IndexOf("\t")+1;
                int nLen=ResArray[i].Length-nPos;         
                string szFileName=ResArray[i].Substring(nPos, nLen); //file name
                szConetent += "\t"+szSHA;
                mapFileTree.Add(szFileName, szConetent);
            }
            return mapFileTree;
        }


        public static bool IsFileExist(string szTreeSHA, string szFileName,  out int iReturnCode)
        {                        
            if (string.IsNullOrEmpty(szTreeSHA) || string.IsNullOrEmpty(szFileName))
            {
                iReturnCode = 0;
                return false;
            }

             
            String szExecuteCmd = string.Format("ls-tree -r --name-only {0} -- \"{1}\"", szTreeSHA,szFileName);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            if (string.IsNullOrEmpty(szInfo) || szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return false;
            else if (szInfo.StartsWith(szFileName))
                return true;
            else
                return false;
        }

        public static string GetFileBlobID(string szTreeSHA,string szFileName, out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szTreeSHA) || string.IsNullOrEmpty(szFileName))
            {
                iReturnCode = 0;
                return string.Empty;
            }

            String szExecuteCmd = string.Format("ls-tree -r {0} -- \"{1}\"", szTreeSHA,szFileName);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            if (string.IsNullOrEmpty(szInfo)||szInfo.Trim().StartsWith("fatal:") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return string.Empty;
            
            string szRegex = @"[0-9a-f]{40}";
            //string szRegex = "\\s{1,}\\d{1,5}){1,}*\\n";
            Regex r = new Regex(szRegex); // 定义一个Regex对象实例
            Match mc = r.Match(szInfo); // 在字符串中匹配

            if (mc != null && mc.Success == true)
            {
                return mc.Value;
            }
            else
            {
                return string.Empty;
            }
        }   

    }
}
