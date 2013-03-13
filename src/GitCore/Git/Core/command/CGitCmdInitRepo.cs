using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
namespace Git.Core.Commands
{
    public static class CGitCmdInitRepo
    {
        public static string run(bool bCentralRepo, out int iReturnCode)
        {

            if (bCentralRepo)
            {
                return CGitSourceConfig.m_objGitSrcModule.RunGitCmd("init --bare --shared=all",out iReturnCode);
            }
            //else if (bare)
            //{
            //    return RunGitCmd("init --bare");
            //}
           return CGitSourceConfig.m_objGitSrcModule.RunGitCmd("init",out iReturnCode);
        }

        public static bool ParseOperaResult(string szResult, int iReturnCode)
        {
            return true;

        }
    }
}
