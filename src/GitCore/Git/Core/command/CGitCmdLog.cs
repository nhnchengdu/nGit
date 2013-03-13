using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;
using System.Diagnostics;
using System.Threading;

namespace Git.Core.Commands
{
    public static class CGitCmdLog
    {
        public static string run(out int iReturnCode)
        {
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmd("log", out iReturnCode);

        }
        

        public static string[] GetHistoryforSpecFile(string szfileName,out int iReturnCode)
        {
            string szArgument = string.Format("log --all --full-history --simplify-by-decoration --format=\"%H\" -- {0}", szfileName);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szArgument, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return ParseFileHistory(szInfo);

        }
        public static string[] GetChangeCommitforSpecFile(string szfileName, out int iReturnCode)
        {
            string szArgument = string.Format("log --all --full-history  --format=\"%H\" -- \"{0}\"", szfileName);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szArgument, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return ParseFileHistory(szInfo);
        }
        public static Dictionary<string, int> GetFollowforSpecFile(string szfileName, out int iReturnCode)
        {
            string szArgument = string.Format("log --name-only --follow --all --format=\"%n\" -- \"{0}\"", szfileName);
            string szInfo = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szArgument, out iReturnCode);
            if (szInfo.Trim().StartsWith("fatal") || szInfo.Trim().StartsWith("error:") || iReturnCode != 0)
                return null;
            return ParseFollowHistory(szInfo);
        }
        private static string[] ParseFileHistory(string szInfo)
        {
            if (string.IsNullOrEmpty(szInfo))
                return null;
            string[] ResArray = szInfo.Split(new[] { '\r', '\n', '\0' }, StringSplitOptions.RemoveEmptyEntries);
            return ResArray;
        }
        private static Dictionary<string, int> ParseFollowHistory(string szInfo)
        {
            if (string.IsNullOrEmpty(szInfo))
                return null;
            string[] ResArray = szInfo.Split(new[] { '\r', '\n', '\0' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> tempDic = new Dictionary<string, int>();
            for (int i = 0; i < ResArray.Length; i++)
            {
                if (tempDic.ContainsKey(ResArray[i]) == false)
                    tempDic.Add(ResArray[i], 0);
            }
            return tempDic;
        }



        public static Process GetAllCommitesAsynch(DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            string szArgument = @"log -z  --pretty=format:";
            szArgument = szArgument + @"((__VALID_ITEM_0__))"; //@"((__VALID_COMMIT_ITEM__))";
            szArgument += @"%H((__VALID_ITEM_1__))" //@"%H((__VALID_HASH_ITEM__))"                
                       + @"%P((__VALID_ITEM_2__))" //@"%P((__VALID_PARENT_ITEM__))"
                       + @"%T((__VALID_ITEM_3__))"//@"%T((__VALID_TREE_ITEM__))"
                       + @"%aN((__VALID_ITEM_4__))" //@"%aN((__VALID_AUTHOR_NAME_ITEM__))"
                       + @"%aE((__VALID_ITEM_5__))" //@"%aE((__VALID_AUTHOR_EMAIL_ITEM__))"
                       + @"%ai((__VALID_ITEM_6__))" //@"%ai((__VALID_AUTHOR_DATE_ITEM__))"
                       + @"%cN((__VALID_ITEM_7__))" //@"%cN((__VALID_COMMITTER_NAME_ITEM__))"
                       + @"%ci((__VALID_ITEM_8__))" // @"%ci((__VALID_COMMITTER_DATE_ITEM__))"
                       + @"%e((__VALID_ITEM_9__))" // @"%e((__VALID_COMMITTER_ENCODE_ITEM__))"
                       + @"%s((__VALID_ITEM_10__))" // @"%s((__VALID_COMMITTE_MESSAGE_ITEM__))"
                       + @"%n";
            szArgument=szArgument+ @" --date-order --all --boundary";
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmdAsynch(szArgument, AppHandleOutput, AppHandleError, AppHandleAbort);
        }
        public static string[] ParseAllCommites(string szResultItem)
        {
            if (string.IsNullOrEmpty(szResultItem))
                return null;

            szResultItem = szResultItem.Trim(new char[] { '\0', '\r', '\n' });

            if (!szResultItem.StartsWith(@"((__VALID_ITEM_0__))"))
                return null;

            string[] arrayinfo= new string[10];
            arrayinfo.Initialize();
            for(int i=0;i<10;i++)
            {
                string szStarSymb=string.Format("((__VALID_ITEM_{0}__))",i);
                string szEndSymb=string.Format("((__VALID_ITEM_{0}__))",i+1);
                int nStarPos = szResultItem.IndexOf(szStarSymb) + szStarSymb.Length;
                int nLen = szResultItem.IndexOf(szEndSymb) - nStarPos;
           
               arrayinfo[i]=szResultItem.Substring(nStarPos,nLen);
            }
            return arrayinfo;

        }


        public static Thread GetAllCommitsBySybcThread(DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            string szArgument = @"log -z  --pretty=format:";
            szArgument = szArgument + @"((__VALID_ITEM_0__))"; //@"((__VALID_COMMIT_ITEM__))";
            szArgument += @"%H((__VALID_ITEM_1__))" //@"%H((__VALID_HASH_ITEM__))"                
                       + @"%P((__VALID_ITEM_2__))" //@"%P((__VALID_PARENT_ITEM__))"
                       + @"%T((__VALID_ITEM_3__))"//@"%T((__VALID_TREE_ITEM__))"
                       + @"%aN((__VALID_ITEM_4__))" //@"%aN((__VALID_AUTHOR_NAME_ITEM__))"
                       + @"%aE((__VALID_ITEM_5__))" //@"%aE((__VALID_AUTHOR_EMAIL_ITEM__))"
                       + @"%ai((__VALID_ITEM_6__))" //@"%ai((__VALID_AUTHOR_DATE_ITEM__))"
                       + @"%cN((__VALID_ITEM_7__))" //@"%cN((__VALID_COMMITTER_NAME_ITEM__))"
                       + @"%ci((__VALID_ITEM_8__))" // @"%ci((__VALID_COMMITTER_DATE_ITEM__))"
                       + @"%e((__VALID_ITEM_9__))" // @"%e((__VALID_COMMITTER_ENCODE_ITEM__))"
                       + @"%s((__VALID_ITEM_10__))" // @"%s((__VALID_COMMITTE_MESSAGE_ITEM__))"
                       + @"%n";
            szArgument = szArgument + @" --date-order --all --boundary";
            return CGitSourceConfig.m_objGitSrcModule.RunGitCmdByThread(szArgument, AppHandleOutput, AppHandleError, AppHandleAbort);

        }

                        
               


    }
}
