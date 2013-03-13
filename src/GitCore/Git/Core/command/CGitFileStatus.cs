using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using Git.Core.Helper;
using Git.Repository;
using System.Text.RegularExpressions;
using System.IO;

namespace Git.Core.Commands
{
    public enum FileSccStatus : int
    {
        ST_NULL=94,
        ST_NOT_CONTROLLED,
        ST_NEW_CHECKIN,
        ST_NEW_STAGED,
        ST_MODIFY_STAGED,
        ST_MODIFY_STAGED_MODIFY,
        ST_CHECKIN_MODIFIED,
        ST_STAGE_MODIFIED,
        ST_IGNORED,
        ST_INVALID_REPO,

        ST_DELETE,
        ST_RENMAE,
        ST_CONFLICT,
        ST_UNMERGE,
    }
    public struct StatusItem
    {
        public FileSccStatus status;
        public string szFileName;
        public string szAdditionalFile; //now it's just for "R" status,maybe for "D" or "U"
    }


    public static class CGitFileStatus
    {
        public static string[] GetAllUntrackedAndIgnored()
        {
            //query all tracked file status;
            string szReult = string.Empty;
            int iReturnCode = -1;
            szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("ls-files -o", out iReturnCode);
            if (string.IsNullOrEmpty(szReult) || iReturnCode != 0)
                return null;
            else
            {
                string[] ResArray = szReult.Split(new[] { '\r', '\n', '\0' }, StringSplitOptions.RemoveEmptyEntries);
                return ResArray;
            }
        }

        public static string[] GetAllUntracked()
        {
            //query all tracked file status;
            string szReult = string.Empty;
            int iReturnCode = -1;
            szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("ls-files -z -o --exclude-standard", out iReturnCode);
            if (string.IsNullOrEmpty(szReult) || iReturnCode != 0)
                return null;
            else
            {
                string[] ResArray = szReult.Split(new[] { '\r', '\n', '\0' }, StringSplitOptions.RemoveEmptyEntries);
                return ResArray;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="szFilePath"></param>
        /// <param name="iReturnCode"></param>
        /// <returns></returns>
        /// 
        public static FileSccStatus GetFileStatus(String szFilePath, out int iReturnCode)
        {
            string szRefPath = string.Empty;
            string szReult = string.Empty; ;
            FileSccStatus status = FileSccStatus.ST_NULL;

            szRefPath = CHelpFuntions.GetRelativeFilePath(CGitSourceConfig.m_szWorkingDir, szFilePath);
            if (string.IsNullOrEmpty(szRefPath))
            {
                iReturnCode = -1;
                return FileSccStatus.ST_NULL;

            }

            //query untracked file status;
            szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("ls-files -o " + "\"" + szRefPath + "\"", out iReturnCode).Trim(new char[] { '\n', '\r' });
            if (string.IsNullOrEmpty(szReult)==false && iReturnCode == 0)
            {
                iReturnCode = 0;
                status = FileSccStatus.ST_NOT_CONTROLLED;

                //query ignored file status                
                szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("ls-files -o --exclude-standard " + szRefPath, out iReturnCode).Trim(new char[] { '\n', '\r' });
                //if (string.IsNullOrEmpty(szReult) == false && iReturnCode == 0)
                //{
                //    iReturnCode = 0;
                //    status = FileSccStatus.ST_IGNORED;
                //}

                if (string.IsNullOrEmpty(szReult) && iReturnCode == 0)
                {
                    iReturnCode = 0;
                    status = FileSccStatus.ST_IGNORED;
                }


                if(status == FileSccStatus.ST_NOT_CONTROLLED &&status==FileSccStatus.ST_IGNORED&& false==Directory.Exists(szFilePath))
                    return status;
            }

            //query all tracked file status;

            szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("status -z --porcelain --untracked-files=no -- " + "\"" + szRefPath + "\"", out iReturnCode);
            if (string.IsNullOrEmpty(szReult) == false && iReturnCode == 0)
            {
                foreach (StatusItem item in ParseOperaResult(szReult))
                {
                    iReturnCode = 0;
                    status = item.status;
                    return status;
                }
            }
            szReult = string.Empty;
            szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("log " + "\"" + szRefPath + "\"", out iReturnCode);
            if (szReult.StartsWith(@"commit") && iReturnCode == 0)
            {
                iReturnCode = 0;
                return FileSccStatus.ST_NEW_CHECKIN;
            }
            else
            {
                return status;
            }
        }


        public static FileSccStatus GetFileStatus2(String szFilePath, out int iReturnCode)
        {
            string szRefPath = string.Empty;
            string szReult = string.Empty; ;
            FileSccStatus status=FileSccStatus.ST_NULL;

            szRefPath = CHelpFuntions.GetRelativeFilePath(CGitSourceConfig.m_szWorkingDir ,szFilePath);
            if (string.IsNullOrEmpty(szRefPath))
            {
                iReturnCode = -1;
                return FileSccStatus.ST_NULL;            
            
            }
           
            //query untracked file status;
            szReult=CGitSourceConfig.m_objGitSrcModule.RunGitCmd("ls-files -o "+ "\""+szRefPath+"\"",out iReturnCode).Trim(new char[] { '\n', '\r' });            
            if (string.Equals(szRefPath, szReult.Replace('/', '\\')) && iReturnCode == 0)
            {
                iReturnCode = 0;
                status=FileSccStatus.ST_NOT_CONTROLLED;

                //query ignored file status           =====according to test, it's error and use next stepe to replace it.
                ////szReult=CGitSourceConfig.m_objGitSrcModule.RunGitCmd("ls-files -io --exclude-per-directory "+szRefPath,out iReturnCode).Trim(new char[] { '\n', '\r' });
                //szReult=CGitSourceConfig.m_objGitSrcModule.RunGitCmd("ls-files -io --exclude-standard "+szRefPath,out iReturnCode).Trim(new char[] { '\n', '\r' });
                //if (string.Equals(szRefPath, szReult.Replace('/', '\\')) && iReturnCode == 0)
                //{
                //    iReturnCode = 0;
                //    status = FileSccStatus.ST_IGNORED;
                //}


                //szReult=CGitSourceConfig.m_objGitSrcModule.RunGitCmd("ls-files -io --exclude-per-directory "+szRefPath,out iReturnCode).Trim(new char[] { '\n', '\r' });
                szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("ls-files -o --exclude-standard " + szRefPath, out iReturnCode).Trim(new char[] { '\n', '\r' });
                if (string.IsNullOrEmpty(szReult) && iReturnCode == 0)
                {
                    iReturnCode = 0;
                    status = FileSccStatus.ST_IGNORED;
                }
                return status;
            }

            //query all tracked file status;
            szReult = string.Empty;
            szReult=CGitSourceConfig.m_objGitSrcModule.RunGitCmd("status -z --porcelain --untracked-files=no",out iReturnCode);
            if (szReult != string.Empty && iReturnCode == 0)
            {
                foreach(StatusItem item in ParseOperaResult(szReult))
                {
                    if(string.Equals(szRefPath,item.szFileName.Replace('/','\\')))
                    {
                        iReturnCode = 0;
                        status=item.status;
                        return status;
                    }    
                }
            }
            szReult = string.Empty;
            szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("log " + "\"" + szRefPath + "\"", out iReturnCode);
            if (szReult.StartsWith(@"commit") && iReturnCode == 0)
            {
                iReturnCode = 0;
                return FileSccStatus.ST_NEW_CHECKIN;
            }
            else
            {
                iReturnCode = -1;
                return FileSccStatus.ST_NULL;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="szFilePath"></param>
        /// <param name="iReturnCode"></param>
        /// <returns></returns>
        public static FileSccStatus GetFileStatus_IgnoresSubModule(String szFilePath, out int iReturnCode)
        {                       
            //StringBuilder stringBuilder = new StringBuilder("status --porcelain -z");

            //switch(untrackedFiles)
            //{
            //    case UntrackedFilesMode.Default:
            //        stringBuilder.Append(" --untracked-files");
            //        break;
            //    case UntrackedFilesMode.No:
            //        stringBuilder.Append(" --untracked-files=no");
            //        break;
            //    case UntrackedFilesMode.Normal:
            //        stringBuilder.Append(" --untracked-files=normal");
            //        break;
            //    case UntrackedFilesMode.All:
            //        stringBuilder.Append(" --untracked-files=all");
            //        break;
            iReturnCode = 0;
            return FileSccStatus.ST_NULL;
        }

        public static List<StatusItem> GetAllStagedFiles()
        {
            //query all tracked file status;
            string szReult = string.Empty;
            int iReturnCode = -1;
            List<StatusItem> StagedFileList;
            szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("status -z --porcelain --untracked-files=no", out iReturnCode);
            if (iReturnCode == 0)
            {
                StagedFileList=GetStagedResult(szReult);
            }
            else
            {
                StagedFileList = null;
            }

            return StagedFileList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szResult"></param>
        /// <returns></returns>
        private static List<StatusItem> GetStagedResult(string szResult)
        {
            var listContractedItem = new List<StatusItem>();
            if (string.IsNullOrEmpty(szResult))
                return listContractedItem;

            foreach (StatusItem item in ParseOperaResult(szResult))
            {
                if(item.status == FileSccStatus.ST_NEW_STAGED
                        ||item.status == FileSccStatus.ST_MODIFY_STAGED
                        ||item.status == FileSccStatus.ST_DELETE
                        ||item.status == FileSccStatus.ST_RENMAE
                        ||item.status == FileSccStatus.ST_CONFLICT                    
                    )
                {
                    listContractedItem.Add(item);               
                }
            }
            if (listContractedItem.Count == 0)
                return null;
            return listContractedItem;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="szResult"></param>
        /// <returns></returns>
        private static List<StatusItem> ParseOperaResult(string szResult)
        {
            var listContractedItem = new List<StatusItem>();
            if (string.IsNullOrEmpty(szResult))
                return listContractedItem;


            //remove warning
            var nl = new char[] { '\n', '\r' };
            string szAllInfoStatus = szResult.Trim(nl);
            int ilastWaringPos = szAllInfoStatus.LastIndexOfAny(nl);
            if (ilastWaringPos > 0)
            {
                int ind = szAllInfoStatus.LastIndexOf('\0');
                if (ind < ilastWaringPos)
                {
                    //Remove Warning at end if it exist;
                    ilastWaringPos = szAllInfoStatus.IndexOfAny(nl, ind >= 0 ? ind : 0);
                    szAllInfoStatus = szAllInfoStatus.Substring(0, ilastWaringPos).Trim(nl);
                }
                else
                {
                    //Remove Warning at beginning if it exist;
                    szAllInfoStatus = szAllInfoStatus.Substring(ilastWaringPos).Trim(nl);
                }
            }

            //analyze every item;
            var AllInfoItems = szAllInfoStatus.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            for(int n=0; n<AllInfoItems.Length; n++)
            {
                string tempItemInfo=AllInfoItems[n];
                if (string.IsNullOrEmpty(tempItemInfo))
                    continue;

                string szRawStatus = null, szFileName = null;
                int iSplitIndex = tempItemInfo.IndexOfAny(new char[] {'\0', '\t', ' '},2);
                if (iSplitIndex>0)
                {
                    szRawStatus = tempItemInfo.Substring(0, iSplitIndex);
                    szFileName = tempItemInfo.Substring(iSplitIndex+1);

                    if (szRawStatus == null || szFileName == null)
                    {
                        continue;
                    }
                }

                StatusItem tpStatusItem=new StatusItem();//here just implement a value initialization, no heeep memory alloc.
                tpStatusItem.szFileName = szFileName.Trim(new char[] { '\"'});
                tpStatusItem.status = ParseRawStatusInfo(szRawStatus);
                if (tpStatusItem.status == FileSccStatus.ST_NULL)
                    continue;
                if (tpStatusItem.status == FileSccStatus.ST_RENMAE)
                {
                    //just treat "R" as  new stage
                    //add followed file into current item, because they are a group
                    tpStatusItem.status = FileSccStatus.ST_NEW_STAGED;
                    tpStatusItem.szAdditionalFile = AllInfoItems[n+1];
                    ++n;                
                }
                listContractedItem.Add(tpStatusItem);
           
            }
            return listContractedItem;
        }

        /// <summary>
        /// parse result "status -z --porcelain --untracked-files=no"
        /// </summary>
        /// <param name="szRawInfo"></param>
        /// <returns></returns>
        private static FileSccStatus ParseRawStatusInfo(string szRawInfo)
        {
            char x = szRawInfo[0];//index
            char y = szRawInfo.Length > 1 ? szRawInfo[1] : ' ';//work tree
            FileSccStatus status;
            if (szRawInfo.Equals("DD") || szRawInfo.Equals("AA") || szRawInfo.Equals("UU"))
            {
                //unmerge and conflict
                status = FileSccStatus.ST_CONFLICT;            
            }
            else if(szRawInfo.Contains("U"))
            {
                //unmerge
                status = FileSccStatus.ST_UNMERGE;            
            }


            else if(char.IsWhiteSpace(x) && y.Equals('M'))
            {
                status = FileSccStatus.ST_CHECKIN_MODIFIED;            
            }
            else if ( x.Equals('A') && y.Equals('M'))
            {
                status = FileSccStatus.ST_STAGE_MODIFIED;           
            }
            else if (x.Equals('M') && !y.Equals('M'))
            {
                status = FileSccStatus.ST_MODIFY_STAGED;
            }
            else if (x.Equals('M')&&y.Equals('M'))
            {
                status = FileSccStatus.ST_MODIFY_STAGED_MODIFY;
            }

            else if (x.Equals('A') && char.IsWhiteSpace(y))
            {
                status = FileSccStatus.ST_NEW_STAGED;
            }
            else if (x.Equals('R'))
            {
                status = FileSccStatus.ST_RENMAE;
            }
            else if (x.Equals('D'))
            {
                status = FileSccStatus.ST_DELETE;
            }
            else if (x.Equals('C'))
            {
                status = FileSccStatus.ST_NEW_STAGED;
            }
            else
            {
                status = FileSccStatus.ST_NULL;
            }
            return status;

            //X          Y     Meaning
            //-------------------------------------------------
            //          [MD]   not updated
            //M        [ MD]   updated in index
            //A        [ MD]   added to index
            //D         [ M]   deleted from index
            //R        [ MD]   renamed in index
            //C        [ MD]   copied in index
            //[MARC]           index and work tree matches
            //[ MARC]     M    work tree changed since index
            //[ MARC]     D    deleted in work tree
            //-------------------------------------------------
            //D           D    unmerged, both deleted
            //A           U    unmerged, added by us
            //U           D    unmerged, deleted by them
            //U           A    unmerged, added by them
            //D           U    unmerged, deleted by us
            //A           A    unmerged, both added
            //U           U    unmerged, both modified
            //-------------------------------------------------
            //?           ?    untracked
            //!           !    ignored
            //-------------------------------------------------
        }


        /// <summary>
        /// parse result "status -z --porcelain --untracked-files=no"
        /// </summary>
        /// <param name="szRawInfo"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetConflictAndMerged()
        {
            //query all tracked file status;
            string szReult = string.Empty;
            int iReturnCode = -1;
            Dictionary<string, string> mapConflictFiles;
            szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("status -z --porcelain  --untracked-files=no", out iReturnCode);
            if (iReturnCode == 0)
            {
                mapConflictFiles = ParseConflictAndUmergeRes(szReult);
            }
            else
            {
                mapConflictFiles = null;
            }

            return mapConflictFiles;
        }
        public static Dictionary<string, string> ParseConflictAndUmergeRes(string szResult)
        {
            var mapConflictFiles = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(szResult))
                return mapConflictFiles;


            //remove warning
            var nl = new char[] { '\n', '\r' };
            string szAllInfoStatus = szResult.Trim(nl);
            int ilastWaringPos = szAllInfoStatus.LastIndexOfAny(nl);
            if (ilastWaringPos > 0)
            {
                int ind = szAllInfoStatus.LastIndexOf('\0');
                if (ind < ilastWaringPos)
                {
                    //Remove Warning at end if it exist;
                    ilastWaringPos = szAllInfoStatus.IndexOfAny(nl, ind >= 0 ? ind : 0);
                    szAllInfoStatus = szAllInfoStatus.Substring(0, ilastWaringPos).Trim(nl);
                }
                else
                {
                    //Remove Warning at beginning if it exist;
                    szAllInfoStatus = szAllInfoStatus.Substring(ilastWaringPos).Trim(nl);
                }
            }


            ////{0,x}， 0 will cause error,avoiding it.
            ////string szRegex = "\\s{1,}\\d{1,5}\\)\\s+.{0,}\n";
            //string szRegex = @"([AU]{2}|DD|R\s|M\s)\s(.+)";
            ////string szRegex = "\\s{1,}\\d{1,5}){1,}*\\n";
            //Regex r = new Regex(szRegex); 
            //MatchCollection mc = r.Matches(szResult); 
            //if (mc.Count <= 0)
            //    return mapConflictFiles;

            //for (int i = 0; i < mc.Count; i++)
            //{
            //    string szpp = mc[i].Value;
            //    string szStatus = szpp.Substring(0, 2);
            //    string szName = szpp.Substring(3,szpp.Length-3);
            //    mapConflictFiles.Add(szName, szStatus);                
            //}


            var AllInfoItems = szAllInfoStatus.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            for (int n = 0; n < AllInfoItems.Length; n++)
            {
                string tempItemInfo = AllInfoItems[n];
                if (string.IsNullOrEmpty(tempItemInfo))
                    continue;

                string szNull;
                string szRawStatus = null, szFileName = null;
                int iSplitIndex = tempItemInfo.IndexOfAny(new char[] { '\0', '\t', ' ' }, 2);
                if (iSplitIndex > 0)
                {
                    szRawStatus = tempItemInfo.Substring(0, iSplitIndex);
                    szFileName = tempItemInfo.Substring(iSplitIndex + 1);

                    if (szRawStatus == null || szFileName == null)
                    {
                        continue;
                    }
                    else if (IsIndexChangeAndUnMerge(szRawStatus, out szNull))
                    {
                        mapConflictFiles.Add(szFileName, szRawStatus);
                    }
                }
            }
            return mapConflictFiles;
        }


        /// <summary>
        /// parse result "status -z --porcelain --untracked-files=no"
        /// </summary>
        /// <param name="szRawInfo"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetConflict()
        {
            //query all tracked file status;
            string szReult = string.Empty;
            int iReturnCode = -1;
            Dictionary<string, string> mapConflictFiles;
            szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("status -z --porcelain  --untracked-files=no", out iReturnCode);
            if (iReturnCode == 0)
            {
                mapConflictFiles = ParseConflictRes(szReult);
            }
            else
            {
                mapConflictFiles = null;
            }

            return mapConflictFiles;
        }
        public static Dictionary<string, string> ParseConflictRes(string szResult)
        {
            var mapConflictFiles = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(szResult))
                return mapConflictFiles;


            //remove warning
            var nl = new char[] { '\n', '\r' };
            string szAllInfoStatus = szResult.Trim(nl);
            int ilastWaringPos = szAllInfoStatus.LastIndexOfAny(nl);
            if (ilastWaringPos > 0)
            {
                int ind = szAllInfoStatus.LastIndexOf('\0');
                if (ind < ilastWaringPos)
                {
                    //Remove Warning at end if it exist;
                    ilastWaringPos = szAllInfoStatus.IndexOfAny(nl, ind >= 0 ? ind : 0);
                    szAllInfoStatus = szAllInfoStatus.Substring(0, ilastWaringPos).Trim(nl);
                }
                else
                {
                    //Remove Warning at beginning if it exist;
                    szAllInfoStatus = szAllInfoStatus.Substring(ilastWaringPos).Trim(nl);
                }
            }


            ////{0,x}， 0 will cause error,avoiding it.
            ////string szRegex = "\\s{1,}\\d{1,5}\\)\\s+.{0,}\n";
            //string szRegex = @"([AU]{2}|DD|R\s|M\s)\s(.+)";
            ////string szRegex = "\\s{1,}\\d{1,5}){1,}*\\n";
            //Regex r = new Regex(szRegex); 
            //MatchCollection mc = r.Matches(szResult); 
            //if (mc.Count <= 0)
            //    return mapConflictFiles;

            //for (int i = 0; i < mc.Count; i++)
            //{
            //    string szpp = mc[i].Value;
            //    string szStatus = szpp.Substring(0, 2);
            //    string szName = szpp.Substring(3,szpp.Length-3);
            //    mapConflictFiles.Add(szName, szStatus);                
            //}


            var AllInfoItems = szAllInfoStatus.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            for (int n = 0; n < AllInfoItems.Length; n++)
            {
                string tempItemInfo = AllInfoItems[n];
                if (string.IsNullOrEmpty(tempItemInfo))
                    continue;

                string szRawStatus = null, szFileName = null;
                int iSplitIndex = tempItemInfo.IndexOfAny(new char[] { '\0', '\t', ' ' }, 2);
                if (iSplitIndex > 0)
                {
                    szRawStatus = tempItemInfo.Substring(0, iSplitIndex);
                    szFileName = tempItemInfo.Substring(iSplitIndex + 1);

                    if (szRawStatus == null || szFileName == null)
                    {
                        continue;
                    }
                    else if (szRawStatus.Equals("DD") || szRawStatus.Equals("AA") || szRawStatus.Contains("U"))
                    {
                        mapConflictFiles.Add(szFileName, szRawStatus);
                    }
                }
            }
            return mapConflictFiles;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="szResult"></param>
        /// <returns></returns>
        public static List<string> GetAllWorkingAreaChange()
        {
            //query all tracked file status;
            string szReult = string.Empty;
            int iReturnCode = -1;
            List<string> ChangeFileList;
            szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("status -z --porcelain --untracked-files=no", out iReturnCode);
            if (iReturnCode == 0)
            {
                ChangeFileList = GetLocalChangeFiles(szReult);
            }
            else
            {
                ChangeFileList = null;
            }
            return ChangeFileList;
        }
        private static List<string> GetLocalChangeFiles(string szResult)
        {
            var listContractedItem = new List<string>();
            if (string.IsNullOrEmpty(szResult))
                return listContractedItem;


            //remove warning
            var nl = new char[] { '\n', '\r' };
            string szAllInfoStatus = szResult.Trim(nl);
            int ilastWaringPos = szAllInfoStatus.LastIndexOfAny(nl);
            if (ilastWaringPos > 0)
            {
                int ind = szAllInfoStatus.LastIndexOf('\0');
                if (ind < ilastWaringPos)
                {
                    //Remove Warning at end if it exist;
                    ilastWaringPos = szAllInfoStatus.IndexOfAny(nl, ind >= 0 ? ind : 0);
                    szAllInfoStatus = szAllInfoStatus.Substring(0, ilastWaringPos).Trim(nl);
                }
                else
                {
                    //Remove Warning at beginning if it exist;
                    szAllInfoStatus = szAllInfoStatus.Substring(ilastWaringPos).Trim(nl);
                }
            }

            //analyze every item;
            var AllInfoItems = szAllInfoStatus.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            for (int n = 0; n < AllInfoItems.Length; n++)
            {
                string tempItemInfo = AllInfoItems[n];
                if (string.IsNullOrEmpty(tempItemInfo))
                    continue;

                string szRawStatus = null, szFileName = null;
                int iSplitIndex = tempItemInfo.IndexOfAny(new char[] { '\0', '\t', ' ' }, 2);
                if (iSplitIndex > 0)
                {
                    szRawStatus = tempItemInfo.Substring(0, iSplitIndex);
                    szFileName = tempItemInfo.Substring(iSplitIndex + 1);
                }
                if (string.IsNullOrEmpty(szRawStatus) || string.IsNullOrEmpty(szFileName) || szRawStatus.Length>2)
                {
                    continue;
                }
               

                StatusItem tpStatusItem = new StatusItem();//here just implement a value initialization, no heeep memory alloc.
                tpStatusItem.szFileName = szFileName.Trim(new char[] { '\"' });
                string szHead = string.Empty;
                if (IsWorkingArealChange(szRawStatus,out szHead))
                {
                    listContractedItem.Add(szHead + szFileName);
                }
            }
            return listContractedItem;
        }
        private static bool IsWorkingArealChange(string szRawInfo,out string szRestrun)
        {
            if(szRawInfo.Contains(@"U")||szRawInfo.Equals(@"DD")||szRawInfo.Equals(@"AA"))
            {
                szRestrun = null;
                return false;
            }

            char x = szRawInfo[0];//index
            char y = szRawInfo.Length > 1 ? szRawInfo[1] : ' ';//work tree
            bool bIsOk=true;
            if (y.Equals('M'))
            {
                szRestrun="(M) ";
            }
            else if ( y.Equals('D'))
            {
               szRestrun="(D) ";
            }
            else
            {
                szRestrun=null;
                bIsOk=false;
            }
            return bIsOk;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="szResult"></param>
        /// <returns></returns>            
        public static List<string> GetAllIndexChange()
        {
            //query all tracked file status;
            string szReult = string.Empty;
            int iReturnCode = -1;
            List<string> ChangeFileList;
            szReult = CGitSourceConfig.m_objGitSrcModule.RunGitCmd("status -z --porcelain --untracked-files=no", out iReturnCode);
            if (iReturnCode == 0)
            {
                ChangeFileList = GetIndexChangeFiles(szReult);
            }
            else
            {
                ChangeFileList = null;
            }
            return ChangeFileList;
        }
        private static List<string> GetIndexChangeFiles(string szResult)
        {
            var listContractedItem = new List<string>();
            if (string.IsNullOrEmpty(szResult))
                return listContractedItem;


            //remove warning
            var nl = new char[] { '\n', '\r' };
            string szAllInfoStatus = szResult.Trim(nl);
            int ilastWaringPos = szAllInfoStatus.LastIndexOfAny(nl);
            if (ilastWaringPos > 0)
            {
                int ind = szAllInfoStatus.LastIndexOf('\0');
                if (ind < ilastWaringPos)
                {
                    //Remove Warning at end if it exist;
                    ilastWaringPos = szAllInfoStatus.IndexOfAny(nl, ind >= 0 ? ind : 0);
                    szAllInfoStatus = szAllInfoStatus.Substring(0, ilastWaringPos).Trim(nl);
                }
                else
                {
                    //Remove Warning at beginning if it exist;
                    szAllInfoStatus = szAllInfoStatus.Substring(ilastWaringPos).Trim(nl);
                }
            }

            //analyze every item;
            var AllInfoItems = szAllInfoStatus.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            for (int n = 0; n < AllInfoItems.Length; n++)
            {
                string tempItemInfo = AllInfoItems[n];
                if (string.IsNullOrEmpty(tempItemInfo))
                    continue;

                string szRawStatus = null, szFileName = null;
                int iSplitIndex = tempItemInfo.IndexOfAny(new char[] { '\0', '\t', ' ' }, 2);
                if (iSplitIndex > 0)
                {
                    szRawStatus = tempItemInfo.Substring(0, iSplitIndex);
                    szFileName = tempItemInfo.Substring(iSplitIndex + 1);
                }
                if (string.IsNullOrEmpty(szRawStatus) || string.IsNullOrEmpty(szFileName) || szRawStatus.Length > 2)
                {
                    continue;
                }
                StatusItem tpStatusItem = new StatusItem();//here just implement a value initialization, no heeep memory alloc.
                tpStatusItem.szFileName = szFileName.Trim(new char[] { '\"' });
                string szHead = string.Empty;
                if (IsIndexChange(szRawStatus, out szHead))
                {
                    listContractedItem.Add(szHead + szFileName);
                }
            }
            return listContractedItem;
        }
        private static bool IsIndexChangeAndUnMerge(string szRawInfo, out string szRestrun)
        {
            if (szRawInfo.Contains(@"U") || szRawInfo.Equals(@"DD") || szRawInfo.Equals(@"AA"))
            {
                szRestrun ="(U) ";
                return true;
            }

            char x = szRawInfo[0];//index
            char y = szRawInfo.Length > 1 ? szRawInfo[1] : ' ';//work tree
            bool bIsOk = true;
            if (szRawInfo.Contains(@"U") || szRawInfo.Equals(@"DD") || szRawInfo.Equals(@"AA"))
            {
                szRestrun = null;
                return false;
            }
            if (x.Equals('M'))
            {
                szRestrun = "(M) ";
            }
            else if (x.Equals('D'))
            {
                szRestrun = "(D) ";
            }
            else if (x.Equals('A'))
            {
                szRestrun = "(A) ";
            }
            else if (x.Equals('R'))
            {
                szRestrun = "(R) ";
            }
            else if (x.Equals('C'))
            {
                szRestrun = "(C) ";
            }
            else
            {
                szRestrun = null;
                bIsOk = false;
            }
            return bIsOk;
        }
        private static bool IsIndexChange(string szRawInfo, out string szRestrun)
        {
            if (szRawInfo.Contains(@"U") || szRawInfo.Equals(@"DD") || szRawInfo.Equals(@"AA"))
            {
                szRestrun = null;
                return false;
            }

            char x = szRawInfo[0];//index
            char y = szRawInfo.Length > 1 ? szRawInfo[1] : ' ';//work tree
            bool bIsOk = true;
            if (x.Equals('M'))
            {
                szRestrun = "(M) ";
            }
            else if (x.Equals('D'))
            {
                szRestrun = "(D) ";
            }
            else if (x.Equals('A'))
            {
                szRestrun = "(A) ";
            }
            else if (x.Equals('R'))
            {
                szRestrun = "(R) ";
            }
            else if (x.Equals('C'))
            {
                szRestrun = "(C) ";
            }
            else
            {
                szRestrun = null;
                bIsOk = false;
            }
            return bIsOk;
        }


            //X          Y     Meaning
            //-------------------------------------------------
            //          [MD]   not updated
            //M        [ MD]   updated in index
            //A        [ MD]   added to index
            //D         [ M]   deleted from index
            //R        [ MD]   renamed in index
            //C        [ MD]   copied in index
            //[MARC]           index and work tree matches
            //[ MARC]     M    work tree changed since index
            //[ MARC]     D    deleted in work tree
            //-------------------------------------------------
            //D           D    unmerged, both deleted
            //A           U    unmerged, added by us
            //U           D    unmerged, deleted by them
            //U           A    unmerged, added by them
            //D           U    unmerged, deleted by us
            //A           A    unmerged, both added
            //U           U    unmerged, both modified
            //-------------------------------------------------
            //?           ?    untracked
            //!           !    ignored
            //-------------------------------------------------

    }
}
