using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using Git.Core.Helper;
using System.IO;

namespace Git.Core.SourceApp
{
    public static class CGitSourceConfig
    {
        public static Encoding m_SystemEncoding;
        public static string m_szGitSourceCmd;
        public static string m_szGitBinDir;
        public static string m_szCustomHomeDir;
        public static bool m_szUserHomeDir;

        public static CGitSourceLog m_objGitLog = null;
        public static CGitSourceModule m_objGitSrcModule = null;

        public static Encoding m_LogOutputEncoding
        {
            get
            {
                Encoding result = new UTF8Encoding(false);
                return result;
            }
        }
        public static string m_szWorkingDir
        {
            get
            {
                return m_objGitSrcModule.m_szWorkingDir;
            }
            set
            {
                m_objGitSrcModule.m_szWorkingDir = value;
               // if (WorkingDirChanged != null)
               // {
               //     WorkingDirChanged(old, _module.WorkingDir, _module.GetGitDirectory());
               // }
            }
        }

        //initialize git setting  from register
        public static bool InitSetting(CGitSourceModule GitSrcModule,CGitSourceLog GitLog)
        {
            m_szGitSourceCmd = GetGitExRegValue();
            if (false==File.Exists(m_szGitSourceCmd))
                return false;

            m_szGitBinDir = CHelpFuntions.GetDirFromFile(m_szGitSourceCmd);
            m_szCustomHomeDir="";
            m_szUserHomeDir = true;

            if (GitSrcModule != null&&GitLog != null)
            {
                m_objGitLog = GitLog;
                m_objGitSrcModule = GitSrcModule;            
            }
            else
            {
                return false;
            }

            return true;
        }

        //
        public static string GetGitExRegValue()
        {
            //@"c:\Program Files\Git\bin\git.exe"; 
            string szGitExePath = string.Empty;
            string szGitLocation = @"Software\nGitScc";
            string szItem = @"GitExeCmd";
            bool bIsOk = false;
            szGitExePath=CRegistryFunction.GetRegistryValue(Registry.CurrentUser, szGitLocation, szItem, out bIsOk);
            if (string.IsNullOrEmpty(szGitExePath) || bIsOk == false)
            {
                string szSearchGitLocation = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Git_is1";
                string szSearcszItem = @"InstallLocation";
                bIsOk = false;
                szGitExePath=CRegistryFunction.GetRegistryValue(Registry.LocalMachine, szSearchGitLocation, szSearcszItem, out bIsOk);
                if (false==string.IsNullOrEmpty(szGitExePath) || bIsOk == true)
                {
                    szGitExePath=string.Format("{0}bin\\git.exe",szGitExePath);
                    CRegistryFunction.SetRegistryValue(Registry.CurrentUser,szGitLocation,szItem,szGitExePath);

                }
                else
                {
                    szGitExePath=string.Empty;
                }
            }
            return szGitExePath;
        }

        public static bool SetGitExRegValue(string szKeyValue)
        {
            //return true;
            //@"c:\Program Files\Git\bin\git.exe"; 
            string szGitExePath = string.Empty;
            string szGitLocation = @"Software\nGitScc";
            string szItem = @"GitExeCmd";
            bool bIsOk = CRegistryFunction.SetRegistryValue(Registry.CurrentUser, szGitLocation, szItem, szKeyValue);
            return bIsOk;

        }

        public static void SetupSystemEncoding(CGitSourceModule Module)
        {
            //check whether GitExtensions works with standard msysgit or msysgit-unicode
            String controlStr = "ą";
            int exitCode;
            String s = Module.RunGitCmd(controlStr, out exitCode, null, Encoding.UTF8);
            if (s != null && s.IndexOf(controlStr) != -1)
                m_SystemEncoding = Encoding.UTF8;
            else
                m_SystemEncoding = Encoding.Default;

        }

        
        public static List<string> GetTargetUrlRegValue(bool bIsRemote)
        {
            List<string> UrlList= new List<string>(); 
            string szGitLocation; 
            if(bIsRemote)
                szGitLocation = @"Software\nGitScc\TargetURL";
            else
                szGitLocation = @"Software\nGitScc\LocalDir";
           
            for(int i=0;i<15;i++)
            { 
                string szItem = @"URL-"+i;
                bool bIsOk = false;
                string szUrl = CRegistryFunction.GetRegistryValue(Registry.CurrentUser, szGitLocation, szItem, out bIsOk);
                if (string.IsNullOrEmpty(szUrl) || bIsOk == false)
                {
                    continue;
                }
                else
                {
                    UrlList.Add(szUrl);
                }
            }
            return UrlList;
        }

        public static bool SetTargetUrlRegValue(string szKeyValue, bool bIsRemote)
        {                       
            string szGitLocation ; 
            string szItem=string.Empty;
            if (bIsRemote)
                szGitLocation = @"Software\nGitScc\TargetURL";
            else
                szGitLocation = @"Software\nGitScc\LocalDir";

            for(int i=0;i<15;i++)
            { 
                szItem = @"URL-"+i;
                bool bIsOk = false;
                string szUrl = CRegistryFunction.GetRegistryValue(Registry.CurrentUser, szGitLocation, szItem, out bIsOk);
                if (string.IsNullOrEmpty(szUrl) || bIsOk == false)
                {
                    return CRegistryFunction.SetRegistryValue(Registry.CurrentUser, szGitLocation, szItem, szKeyValue);
                }
                else if(szUrl.Contains(szKeyValue))
                {
                    return true;                    
                }
                else
                {
                    continue;   
                }
            }
                        
                        
            for(int i=1;i<15;i++)
            { 
                szItem = @"URL-"+i;
                bool bIsOk = false;
                string szUrl = CRegistryFunction.GetRegistryValue(Registry.CurrentUser, szGitLocation, szItem, out bIsOk);
                if (string.IsNullOrEmpty(szUrl) || bIsOk == false)
                {
                    continue;
                }
                else
                {
                    CRegistryFunction.SetRegistryValue(Registry.CurrentUser, szGitLocation, @"URL-"+(i-1), szUrl);             
                }
            }
            return CRegistryFunction.SetRegistryValue(Registry.CurrentUser, szGitLocation, szItem, szKeyValue);
        }



    }
}
