using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;

namespace Git.Core.Commands
{
    public static class CGitCmdUnStage
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

            szResult=CGitSourceConfig.m_objGitSrcModule.RunGitCmd("reset HEAD "+ szRefPath, out iReturnCode);
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
        private static string ParseOperaResult(string szResult, int iReturnCode)
        {
            return szResult;
        }
    }
}
