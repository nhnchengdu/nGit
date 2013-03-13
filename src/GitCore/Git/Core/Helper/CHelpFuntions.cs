using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;



namespace Git.Core.Helper
{
    public static class CHelpFuntions
    {
        public static string GetBracketContent(string szInfo)
        {
            if (string.IsNullOrEmpty(szInfo))
                return "";

            string szRegex = @"\((.*)\)";
            Regex r = new Regex(szRegex); 
            Match mc = r.Match(szInfo); 

            if (mc != null && mc.Success == true)
            {
                string szReturn=string.Empty;
                //foreach(string name in r.GetGroupNames())
               // {
                    szReturn = mc.Groups[1].Value;
                    //break; ;
               // }
                return szReturn;
            }
            else
            {
                return string.Empty;
            }
        }


        public static string GetFileExtension(string fileName)
        {
            if (fileName.Contains(".") && fileName.LastIndexOf(".") < fileName.Length)
                return fileName.Substring(fileName.LastIndexOf('.') + 1);

            return null;
        }

        public static string GetDirFromFile(string FilePath)
        {
            if (string.IsNullOrEmpty(FilePath))
                return "";

            string szDir = FilePath;
            if (szDir.LastIndexOfAny(new[] { '\\' }) > 0)
            {
                szDir = szDir.Substring(0, szDir.LastIndexOfAny(new[] { '\\' }));
            }
            return szDir;
        }

        public static string GetValidWorkingDir(string FilePath)
        {
            if (string.IsNullOrEmpty(FilePath))
                return string.Empty;

            string szDir = FilePath.TrimEnd('\\') + "\\";
            while (szDir.LastIndexOfAny(new[] { '\\' }) > 0)
            {
                szDir = szDir.Substring(0, szDir.LastIndexOfAny(new[] { '\\' }));

                if (IsValidWorkingDir(szDir))
                    return szDir + "\\";
            }
            return string.Empty;      
        }

        public static bool IsValidWorkingDir(string TargeDir)
        {
            if (string.IsNullOrEmpty(TargeDir))
                return false;

            string szDir = TargeDir.TrimEnd('\\')+'\\' ;
            if (Directory.Exists(szDir +".git")
                && Directory.Exists(szDir + @".git\info") 
                && Directory.Exists(szDir + @".git\objects")
                && Directory.Exists(szDir + @".git\refs") )
            {
                return true;
            }
            else
            {
                return false;            
            }
        }

        public static bool IsValidWorkingDir_Old(string TargeDir)
        {
            if (string.IsNullOrEmpty(TargeDir))
                return false;

            string szDir = TargeDir.TrimEnd('\\'); ;
            if (Directory.Exists(szDir + "\\" + ".git") || File.Exists(szDir + "\\" + ".git"))
            {
                return true;
            }

            return !TargeDir.Contains(".git") &&
                   Directory.Exists(TargeDir + "\\" + "info") &&
                   Directory.Exists(TargeDir + "\\" + "objects") &&
                   Directory.Exists(TargeDir + "\\" + "refs");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WorkingDir"></param>
        /// <returns>0-None, 1-Merge, 2-Rebase</returns>
        public static int  IsAnyRebaseOrMergeInfo(string WorkingDir)
        {
            if (string.IsNullOrEmpty(WorkingDir))
                return 0;

            string szDir = WorkingDir.TrimEnd('\\') + '\\';
            if (Directory.Exists(szDir + ".git")
                && File.Exists(szDir + @".git\rebase-apply\original-commit")
                && File.Exists(szDir + @".git\rebase-apply\next")
                && File.Exists(szDir + @".git\rebase-apply\last"))
            {
                return 2;
            }

            if (Directory.Exists(szDir + ".git")
                && File.Exists(szDir + @".git\MERGE_HEAD"))
            {
                return 1;
            }            
            return 0;
        }

        public static string GetRelativeFilePath(string WorkingDir,string FilePath)
        {
            if (WorkingDir == null || FilePath == WorkingDir)
            {
                return string.Empty;            
            }

            if (FilePath.Contains(WorkingDir)==false)
            {
                return FilePath;
            }

            if (FilePath.Substring(0, 2).ToUpper() == WorkingDir.Substring(0, 2).ToUpper() &&
                                                    FilePath.Substring(2).Contains(WorkingDir.Substring(2)))
            {
                string szTmp=FilePath.Remove(0,WorkingDir.Length);
                szTmp.TrimStart('\\');
                return szTmp;                              
            }
            return string.Empty;  
        }

        public static string GetShortFileName(string szlongWorkingDir, string szLongFilePath)
        {
            if (szlongWorkingDir == null || szLongFilePath == szlongWorkingDir)
            {                
                return string.Empty;
            }

            if (szLongFilePath.StartsWith(szlongWorkingDir) == true)
            {
                string szTmp = szLongFilePath.Substring(szlongWorkingDir.Length, szLongFilePath.Length - szlongWorkingDir.Length);
                szTmp.TrimStart('\\');
                return szTmp;
            }

            if (szLongFilePath.Substring(0, 2).ToUpper() == szlongWorkingDir.Substring(0, 2).ToUpper() &&
                                        szLongFilePath.Substring(2).Contains(szlongWorkingDir.Substring(2)))
            {
                string szTmp = szLongFilePath.Remove(0, szlongWorkingDir.Length);
                szTmp.TrimStart('\\');
                return szTmp;
            }
            return string.Empty;
        }

        public static string GetDefaultHomeDir()
        {
            if (RunningOnWindows())
            {
                return WindowsDefaultHomeDir;
            }
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

        private static string WindowsDefaultHomeDir
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOMEDRIVE")))
                {
                    string homePath = Environment.GetEnvironmentVariable("HOMEDRIVE");
                    homePath += Environment.GetEnvironmentVariable("HOMEPATH");
                    return homePath;
                }
                return Environment.GetEnvironmentVariable("USERPROFILE");
            }
        }

        private static bool RunningOnWindows()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    return true;
                default:
                    return false;
            }
        }

        public static byte[] ReadByteFromStream(Stream stream)
        {
            if (!stream.CanRead)
            {
                return null;
            }
            int commonLen = 0;
            List<byte[]> list = new List<byte[]>();
            byte[] buffer = new byte[4096];
            int len;
            while ((len = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                byte[] newbuff = new byte[len];
                Array.Copy(buffer, newbuff, len);
                commonLen += len;
                list.Add(newbuff);
            }
            buffer = new byte[commonLen];
            commonLen = 0;
            for (int i = 0; i < list.Count; i++)
            {
                Array.Copy(list[i], 0, buffer, commonLen, list[i].Length);
                commonLen += list[i].Length;
            }
            return buffer;
        }

        public static bool IsBinaryFileAccordingToContent(byte[] content)
        {
            //Check for binary file.
            if (content != null && content.Length > 0)
            {
                int nullCount = 0;
                foreach (char c in content)
                {
                    if (c == '\0')
                        nullCount++;
                    if (nullCount > 5) break;
                }

                if (nullCount > 5)
                    return true;
            }

            return false;
        }

        public static bool IsBinaryFileAccordingToContent(string content)
        {
            //Check for binary file.
            if (!string.IsNullOrEmpty(content))
            {
                int nullCount = 0;
                foreach (char c in content)
                {
                    if (c == '\0')
                        nullCount++;
                    if (nullCount > 5) break;
                }

                if (nullCount > 5)
                    return true;
            }

            return false;
        }
    }
}
