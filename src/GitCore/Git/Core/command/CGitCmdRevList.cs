using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using System.Text.RegularExpressions;

namespace Git.Core.Commands
{
    public static class  CGitCmdRevList
    {
        //get local branch
        public static string IsHeritFrom(string sztarget,string szfrom,out int iReturnCode)
        { 
            string szExcuteCmd=string.Format("rev-list -1 ^{0} {1}",sztarget,szfrom);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExcuteCmd, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") 
                                                  || szInfo.Trim().StartsWith("usage:")|| iReturnCode !=0)
            {
                return "Error";
            }
            return szInfo;
        }

        public static string GetExcludeItemsFromCommon(string sztarget, string szfrom, out int iReturnCode)
        {
            string szArgument = string.Format("rev-list {0}...{1} -z --pretty=format:",sztarget,szfrom);
            szArgument = szArgument + @"((__VALID_ITEM_0__))"; //@"((__VALID_COMMIT_ITEM__))";
            szArgument += @"%H((__VALID_ITEM_1__))" //@"%H((__VALID_HASH_ITEM__))"                
                       + @"%T((__VALID_ITEM_2__))"//@"%T((__VALID_TREE_ITEM__))"
                       + @"%aN((__VALID_ITEM_3__))" //@"%aN((__VALID_AUTHOR_NAME_ITEM__))"
                       + @"%ai((__VALID_ITEM_4__))" //@"%ai((__VALID_AUTHOR_DATE_ITEM__))"
                       + @"%s((__VALID_ITEM_5__))" // @"%s((__VALID_COMMITTE_MESSAGE_ITEM__))"
                       + @"%n";

            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szArgument, out iReturnCode);

            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:")
                                      || szInfo.Trim().StartsWith("usage:") || iReturnCode != 0)
            {
                return null;
            }
            return szInfo;
        }


        public static string GetExcludeItmsFromFathrer(string szFather, string szChild, out int iReturnCode)
        {
            string szArgument = string.Format("rev-list ^{0} {1} -z --pretty=format:", szFather, szChild);
            szArgument = szArgument + @"((__VALID_ITEM_0__))"; //@"((__VALID_COMMIT_ITEM__))";
            szArgument += @"%H((__VALID_ITEM_1__))" //@"%H((__VALID_HASH_ITEM__))"                
                       + @"%T((__VALID_ITEM_2__))"//@"%T((__VALID_TREE_ITEM__))"
                       + @"%aN((__VALID_ITEM_3__))" //@"%aN((__VALID_AUTHOR_NAME_ITEM__))"
                       + @"%ai((__VALID_ITEM_4__))" //@"%ai((__VALID_AUTHOR_DATE_ITEM__))"
                       + @"%s((__VALID_ITEM_5__))" // @"%s((__VALID_COMMITTE_MESSAGE_ITEM__))"
                       + @"%n";

            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szArgument, out iReturnCode);

            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:")
                                      || szInfo.Trim().StartsWith("usage:") || iReturnCode != 0)
            {
                return null;
            }
            return szInfo;
        }


        public static string GetSpecCommitItem(string szRef, out int iReturnCode)
        {
            string szArgument = string.Format("rev-list {0}^! -z --pretty=format:", szRef);
            szArgument = szArgument + @"((__VALID_ITEM_0__))"; //@"((__VALID_COMMIT_ITEM__))";
            szArgument += @"%H((__VALID_ITEM_1__))" //@"%H((__VALID_HASH_ITEM__))"                
                       + @"%T((__VALID_ITEM_2__))"//@"%T((__VALID_TREE_ITEM__))"
                       + @"%aN((__VALID_ITEM_3__))" //@"%aN((__VALID_AUTHOR_NAME_ITEM__))"
                       + @"%ai((__VALID_ITEM_4__))" //@"%ai((__VALID_AUTHOR_DATE_ITEM__))"
                       + @"%s((__VALID_ITEM_5__))" // @"%s((__VALID_COMMITTE_MESSAGE_ITEM__))"
                       + @"%n";

            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szArgument, out iReturnCode);

            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:")
                                      || szInfo.Trim().StartsWith("usage:") || iReturnCode != 0)
            {
                return null;
            }
            return szInfo;
        }

        public static string[] ParseExcludeItems(string szResultItem)
        {
            if (string.IsNullOrEmpty(szResultItem))
                return null;

            szResultItem = szResultItem.Trim(new char[] { '\0', '\r', '\n' });

            if (!szResultItem.StartsWith(@"((__VALID_ITEM_0__))"))
                return null;

            string[] arrayinfo = new string[5];
            arrayinfo.Initialize();
            for (int i = 0; i < 5; i++)
            {
                string szStarSymb = string.Format("((__VALID_ITEM_{0}__))", i);
                string szEndSymb = string.Format("((__VALID_ITEM_{0}__))", i + 1);
                int nStarPos = szResultItem.IndexOf(szStarSymb) + szStarSymb.Length;
                int nLen = szResultItem.IndexOf(szEndSymb) - nStarPos;

                arrayinfo[i] = szResultItem.Substring(nStarPos, nLen);
            }
            return arrayinfo;
        }


        public static string GetFilterCommits(string szFilterCondition, out int iReturnCode)
        {
            string szArgument = string.Format("rev-list {0} --date-order", szFilterCondition);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szArgument, out iReturnCode);

            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:")
                                      || szInfo.Trim().StartsWith("usage:") || iReturnCode != 0)
            {
                return null;
            }
            return szInfo;
        }

        public static string GetOneFilterCommits(string szFilterCondition, out int iReturnCode)
        {
            string szArgument = string.Format("rev-list -1 {0} --date-order", szFilterCondition);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szArgument, out iReturnCode);

            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:")
                                      || szInfo.Trim().StartsWith("usage:") || iReturnCode != 0)
            {
                return null;
            }
            return szInfo;
        }

        public static MatchCollection ParseFilterItems(string szResult)
        {
            if (string.IsNullOrEmpty(szResult))
                return null;

            //{0,x}， 0 will cause error,avoiding it.
            //string szRegex = "\\s{1,}\\d{1,5}\\)\\s+.{0,}\n";
            string szRegex = @"[0-9a-f]{40}";
            //string szRegex = "\\s{1,}\\d{1,5}){1,}*\\n";
            Regex r = new Regex(szRegex); // 定义一个Regex对象实例
            MatchCollection mc = r.Matches(szResult); // 在字符串中匹配
            if (mc.Count <= 0)
                return null;
            return mc;

        }
    }
}
