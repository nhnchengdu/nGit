using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;

namespace Git.Core.Commands
{
    public static class CGitCmdAdd
    {
        public static string run(String szTargetFile)
        {
            if(szTargetFile==null)
            {
                return szTargetFile;
            }

            int iReturnCode = -1;
            string szResult = null;
            string szRefPath = CHelpFuntions.GetRelativeFilePath(CGitSourceConfig.m_szWorkingDir, szTargetFile);
            if (szRefPath.Equals(string.Empty))
            {
                return "File:" + szTargetFile + ", is not in a valid work tree";
            }

            szResult=CGitSourceConfig.m_objGitSrcModule.RunGitCmd("add "+ szRefPath, out iReturnCode);
            if (szResult != null && iReturnCode!=0)
            {
                szResult = ParseOperaResult(szResult, iReturnCode);
            }
            else if (iReturnCode == 0)
            {
                szResult = null;
            }

            return szResult;
        }

        public static bool run(string[] FileList)    //FileList is valid short path
        {
            if (FileList == null || FileList.Length <= 0)
                return false;

            String szExecuteCmd = "add --ignore-errors --all"; 
            foreach (string szItem in FileList)
            {
                szExecuteCmd = string.Format("{0} \"{1}\"", szExecuteCmd,szItem);
            }
            int iReturnCode = -1;            
            CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szExecuteCmd, out iReturnCode);
            if (iReturnCode != 0)
                return false;
            else
                return true;
        }

        private static string ParseOperaResult(string szResult, int iReturnCode)
        {
            return szResult;

            /*
                git add -A stages All
                git add . stages new and modified, without deleted
                git add -u stages modified and deleted, without new

                git add \*.txt   add dir and sub_dir
                git add  *.txt  add curent dir only
                git add--ignore-errors 
           
            */
        }
    }
}
