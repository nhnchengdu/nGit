using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;

namespace Git.Core.Commands
{
    // 'commit' command must be used after the 'rm', the operation can affect to respository really
    public static class CGitCmdRm
    {
        //just rm index
        public static string DeleteFiles(List<String> FileList,bool bJustIndex)
        {
            string szResult = null;
            String szExecuteCmd = null;
            foreach (string szItem in FileList)
            {
                string szRefPath = CHelpFuntions.GetRelativeFilePath(CGitSourceConfig.m_szWorkingDir, szItem);
                if (szRefPath.Equals(string.Empty))
                    continue;
                szExecuteCmd = szExecuteCmd + " \"" + szRefPath.Replace("\\", "/") + "\"";
            }
            if (szExecuteCmd != null)
            {
                if (bJustIndex)
                    szExecuteCmd = @"rm -f --cached  --" + szExecuteCmd;
                else
                    szExecuteCmd = @"rm -f --" + szExecuteCmd;
            }
            else
            {
                return null;
            }

            szResult = Run(szExecuteCmd);
            return szResult;
        }

        private static string Run(string szCmd)
        {
            int iReturnCode = -1;
            string szResult = null;

            szResult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd(szCmd, out iReturnCode);
            if (szResult != null && iReturnCode != 0)
            {
                szResult = ParseOperaResult(szResult, iReturnCode);
            }
            else if (iReturnCode == 0)
            {
                szResult = null;
            }
            return szResult;        
        }

        private static string ParseOperaResult(string szResult, int iReturnCode)
        {
            return szResult;

        }

    }
}
