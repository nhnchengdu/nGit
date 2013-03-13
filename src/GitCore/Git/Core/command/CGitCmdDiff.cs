using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;

namespace Git.Core.Commands
{
    /// <summary>
    /// this command will include all diff operation
    /// 1.git diff
    /// 2.git diff-tree
    /// 3.git diff-files
    /// 4.git diff-index
    /// </summary>
    public static class CGitCmdDiff
    {
        public static string GetFileChangeFromTree(string szTarget, string szSource, string szFileNameout,out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szTarget) || string.IsNullOrEmpty(szFileNameout))
            {
                iReturnCode = 0;
                return string.Empty;
            }

            string szExcuteCmd = string.Format("diff-tree -M -C -r --name-status {0} {1}", szSource, szTarget);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExcuteCmd, out iReturnCode);
            if (string.IsNullOrEmpty(szInfo)||iReturnCode != 0)
                return string.Empty;

            string[] ResArray = szInfo.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ResArray.Length; i++)
            {
                string szItm = ResArray[i].Trim();
                if(szItm.Contains(szFileNameout))
                {
                    return szItm;
                }
            }
            return string.Empty;
        }


        //difference
        public static string GetTreeDifference(string szTarget ,string szSource,out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szTarget) )
            {
                iReturnCode = 0;
                return null;
            }

            //if szSource is not empty, compare two commits
            //if szSource is not empty, compare the specific commit and working tree
            string szExcuteCmd;
            if(string.IsNullOrEmpty(szSource))
                szExcuteCmd = string.Format("diff-tree -M -C -r -z --name-status {0}", szTarget);
            else
                szExcuteCmd = string.Format("diff-tree -M -C -r -z --name-status {0} {1}",szSource,szTarget);

            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExcuteCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:")
                                                  || szInfo.Trim().StartsWith("usage:") || iReturnCode != 0)
            {
                return null;
            }
            return szInfo;
        }
        public static string[] ParseTreeDiff(string szResult)
        {
            if (string.IsNullOrEmpty(szResult))
                return null;

            string[] ResArray = szResult.Split(new[] {'\0' }, StringSplitOptions.RemoveEmptyEntries);
            string szAllItems=string.Empty;
            for (int i = 0; i < ResArray.Length; i++)
            {
                 string szTmp = ResArray[i];
                if(string.IsNullOrEmpty(szTmp)==false&&szTmp.StartsWith(@"R"))
                {
                    szAllItems = szAllItems + ResArray[i] + "\t" + ResArray[i + 1] + "\t" + ResArray[i + 2] + "\0";
                    i = i + 2;                
                }
                else if(string.IsNullOrEmpty(szTmp)==false&&i<ResArray.Length)
                {
                    szAllItems = szAllItems + ResArray[i] + "\t" + ResArray[i + 1] + "\0";
                    i = i + 1;
                }
            }

            if (string.IsNullOrEmpty(szAllItems))
                return null;
            ResArray = szAllItems.Split(new[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            return ResArray;
        }

        public static string GetFileContentChange(string szTarget, string szSource, string szFile, out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szTarget) || string.IsNullOrEmpty(szSource) || string.IsNullOrEmpty(szFile))
            {
                iReturnCode = 0;
                return null;
            }

            string szExcuteCmd = string.Format("diff --unified=3 -M -C {0} {1} -- \"{2}\"", szSource, szTarget,szFile);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExcuteCmd, out iReturnCode);
            
        }

        public static string GetCommitDifferInfo(string szFather, string szChild,out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szFather) || string.IsNullOrEmpty(szFather))
            {
                iReturnCode = 0;
                return null;
            }

            string szExcuteCmd = string.Format("diff -M -C {0} {1} ", szFather, szChild);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExcuteCmd, out iReturnCode);

        }

        //compare file between working area and repository
        public static string CompareFile_WR(string szFile, out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szFile))
            {
                iReturnCode = 0;
                return null;
            }

            string szExcuteCmd = string.Format("diff --unified=3 -M -C HEAD -- \"{0}\"", szFile);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExcuteCmd, out iReturnCode);

        }

        //compare file between Index area and repository
        public static string CompareFile_IR(string szFile, out int iReturnCode)
        {
            if (string.IsNullOrEmpty(szFile))
            {
                iReturnCode = 0;
                return null;
            }

            string szExcuteCmd = string.Format("diff --unified=3 -M -C --cached -- \"{0}\"", szFile);
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExcuteCmd, out iReturnCode);

        }

    }
}
