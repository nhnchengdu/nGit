using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

using ShellLib;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using System.Windows.Forms;
using Git.Manager;
using Git.Core.Helper;
using Git.Core.Commands;

//using System.IO;

namespace Nhn.Git.Shell.Extention
{
    //singleton
    public class NGitModule : CGitManager
    {
        private static NGitModule _objGitMgr = null;
        private static bool _bIsInitailiezd;
        private NGitModule()
        {
            _bIsInitailiezd = false;
        }

        public static NGitModule GetInstence()
        {
            if (_objGitMgr == null)
            {
                _objGitMgr = new NGitModule();                
            }

            if (_objGitMgr == null)
            {
                return null;
            }

            if(_bIsInitailiezd == false)
            {
                _bIsInitailiezd = _objGitMgr.MgrInitialize(IntPtr.Zero);
                if (_bIsInitailiezd == false)
                {
                    _objGitMgr = null;
                }
            
            }
            return _objGitMgr;
        }

        //function
        public string GetCurrentBranch(string szPath)
        {
            string szRepo = CHelpFuntions.GetValidWorkingDir(szPath);
            if (string.IsNullOrEmpty(szRepo))
            {
                return null;
            }
            else
            {

                string[] BranchArray = _objGitMgrCore.GetBranch(false, szRepo);
                if (BranchArray != null && BranchArray.Length > 0)
                {
                    string szCurrentBranch = BranchArray[0];
                    if (string.IsNullOrEmpty(szCurrentBranch))
                    {
                        return null;
                    }
                    else
                    {
                        return szCurrentBranch;
                    }
                }
            }
            return null;
        }
    }

    [Guid("E7ECE5B0-8414-4fa7-9DE2-E8D8112F1519"), ComVisible(true)]
    public class GitContextMenu : IShellExtInit, IContextMenu, IPersistFile, IExtractIcon, IQueryInfo 
    {
        private const string GUID = "{E7ECE5B0-8414-4fa7-9DE2-E8D8112F1519}";
        private const string KEYNAME = "NgitContextMenu";
        const int S_OK = 0;
        const int S_FALSE = 1;
        private const uint E_NOTIMPL = 0x80004001;
        private const uint QITIPF_DEFAULT = 0;
        protected string szFileName;
        protected long lngFileSize;

        private NGitModule m_NgitMgr = null;
        private string m_szFoderPath = null;
        protected ShellLib.IDataObject m_dataObject = null;
        uint m_hDrop = 0;

        public GitContextMenu()
        {
            m_NgitMgr = NGitModule.GetInstence();

            if (m_NgitMgr == null && m_NgitMgr.MgrInitialize(IntPtr.Zero)==false)
            {
                m_NgitMgr = null;
            }    
        }

        #region ============IShellExtInit============
        int IShellExtInit.Initialize(IntPtr pidlFolder, IntPtr lpdobj, uint hKeyProgID)
        {
            try
            {
                m_dataObject = null;
                if (lpdobj != (IntPtr)0)
                {
                    m_dataObject = (ShellLib.IDataObject)Marshal.GetObjectForIUnknown(lpdobj);
                    FORMATETC fmt = new FORMATETC();
                    fmt.cfFormat = CLIPFORMAT.CF_HDROP;
                    fmt.ptd = 0;
                    fmt.dwAspect = DVASPECT.DVASPECT_CONTENT;
                    fmt.lindex = -1;
                    fmt.tymed = TYMED.TYMED_HGLOBAL;
                    STGMEDIUM medium = new STGMEDIUM();
                    m_dataObject.GetData(ref fmt, ref medium);
                    m_hDrop = medium.hGlobal;
                }

                StringBuilder sbTemp = new StringBuilder(1024);
                if (ShellLib.Helpers.SHGetPathFromIDList(pidlFolder, sbTemp))
                {
                    m_szFoderPath = sbTemp.ToString();
                }
                else
                {
                    m_szFoderPath = null;
                }
            }
            catch (Exception)
            {
                return S_FALSE;
            }
            return S_OK;
        }
        #endregion

        #region ============IContextMenu=============
        int IContextMenu.QueryContextMenu(HMenu hMenu, uint iMenu, uint idCmdFirst, uint idCmdLast, CMF uFlags)
        {
            //if ((uFlags & (CMF.CMF_VERBSONLY | CMF.CMF_DEFAULTONLY | CMF.CMF_NOVERBS)) == 0 ||
           if ((uFlags & (CMF.CMF_DEFAULTONLY | CMF.CMF_NOVERBS)) == 0 ||  (uFlags & CMF.CMF_EXPLORE) != 0)
            {               
               uint nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
               if (nselected <= 0 && string.IsNullOrEmpty(m_szFoderPath) )
               {
                   CreateMenu_Base(hMenu, iMenu, idCmdFirst, idCmdLast, uFlags);
               }
               else if(false==string.IsNullOrEmpty(m_szFoderPath))  //valid blank right click context menu
               {

                   if (string.IsNullOrEmpty(CHelpFuntions.GetValidWorkingDir(m_szFoderPath)))
                   {
                       CreateMenu_InValidGit(hMenu, iMenu, idCmdFirst, idCmdLast, uFlags);
                   }
                   else
                   {
                       CreateMenu_ValidGit(hMenu, iMenu, idCmdFirst, idCmdLast, uFlags);                   
                   }             
               }
               else if(nselected >1)
               {
                   CreateMenu_Base(hMenu, iMenu, idCmdFirst, idCmdLast, uFlags);
               }               
               else if(nselected ==1)
               {
                   StringBuilder sb = new StringBuilder(1024);
                   ShellLib.Helpers.DragQueryFile(m_hDrop, 0, sb, sb.Capacity + 1);
                   string szDir=sb.ToString();
                   if (Directory.Exists(szDir))
                   {
                       if (string.IsNullOrEmpty(CHelpFuntions.GetValidWorkingDir(szDir)))
                       {
                           CreateMenu_InValidGit(hMenu, iMenu, idCmdFirst, idCmdLast, uFlags);
                       }
                       else
                       {
                           CreateMenu_ValidGit(hMenu, iMenu, idCmdFirst, idCmdLast, uFlags);                   
                       }
                   }
                   else
                   {
                       if (string.IsNullOrEmpty(CHelpFuntions.GetValidWorkingDir(szDir)))
                       {
                           CreateMenu_Base(hMenu, iMenu, idCmdFirst, idCmdLast, uFlags);
                       }
                       else
                       {

                           if (m_NgitMgr != null)
                           {
                               FileSccStatus status = m_NgitMgr.GetFileStatus(szDir);
                               if (status == FileSccStatus.ST_CONFLICT)
                               {
                                   CreateMenu_ConflictFile(hMenu, iMenu, idCmdFirst, idCmdLast, uFlags);
                               }
                               else if (status != FileSccStatus.ST_NOT_CONTROLLED &&
                                         status != FileSccStatus.ST_IGNORED &&
                                         status != FileSccStatus.ST_INVALID_REPO && status != FileSccStatus.ST_NULL)
                               {
                                   CreateMenu_ValidGitFile(hMenu, iMenu, idCmdFirst, idCmdLast, uFlags);
                               }
                               else
                               {
                                   CreateMenu_Base(hMenu, iMenu, idCmdFirst, idCmdLast, uFlags);
                               }
                           }

                       }
                   }             
               }         
            }
            return 8;
        }
        void IContextMenu.GetCommandString(uint idcmd, GCS uflags, uint reserved, IntPtr commandstring, int cchMax)
        {
            string tip = "";

            switch (uflags)
            {
                case GCS.VERB:
                    break;
                case GCS.HELPTEXTW:
                    switch (idcmd)
                    {
                        case 0:
                            tip = "copy name to clipboard";
                            break;
                        case 1:
                            tip = "copy file to clipboard";
                            break;
                        case 2:
                            tip = "access git hub";
                            break;
                        default:
                            break;
                    }
                    if (!string.IsNullOrEmpty(tip))
                    {
                        byte[] data = new byte[cchMax * 2];
                        Encoding.Unicode.GetBytes(tip, 0, tip.Length, data, 0);
                        Marshal.Copy(data, 0, commandstring, data.Length);
                    }
                    break;
            }
        }
        void IContextMenu.InvokeCommand(IntPtr pici)
        {
            if(m_NgitMgr == null)
                return;

            INVOKECOMMANDINFO ici = (INVOKECOMMANDINFO)Marshal.PtrToStructure(pici, typeof(ShellLib.INVOKECOMMANDINFO));
            StringBuilder sb = new StringBuilder(1024);
            StringBuilder sbAll = new StringBuilder();
            uint nselected;

            switch (ici.verb)
            {
                case 0:
                    {
                        nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
                        if (nselected > 0)
                        {
                            ShellLib.Helpers.DragQueryFile(m_hDrop, 0, sb, sb.Capacity + 1);
                            m_NgitMgr.CloneRepository(sb.ToString());
                        }
                        else if (false == string.IsNullOrEmpty(m_szFoderPath))
                        {
                            m_NgitMgr.CloneRepository(m_szFoderPath);
                        }
                        break;
                    }                    
                case 1:
                    {
                        nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
                        if (nselected > 0)
                        {
                            ShellLib.Helpers.DragQueryFile(m_hDrop, 0, sb, sb.Capacity + 1);
                            m_NgitMgr.InitializeRepo(sb.ToString());                         
                        }
                        else if (false == string.IsNullOrEmpty(m_szFoderPath))  
                        {
                            m_NgitMgr.InitializeRepo(m_szFoderPath); 
                        }
                        break;
                    }                    
                    
                case 2:
                    {
                        nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
                        if (nselected > 0)
                        {
                            ShellLib.Helpers.DragQueryFile(m_hDrop, 0, sb, sb.Capacity + 1);
                            string szCurrBranch=m_NgitMgr.GetCurrentBranch(sb.ToString());


                            if (string.IsNullOrEmpty(szCurrBranch))
                                MessageBox.Show("当前库处于头指针分离状态，请先切换到有效工作分支。", "Warnning");
                            else
                                m_NgitMgr.PullCurrentBranch(sb.ToString(), szCurrBranch);
                        }
                        else if (false == string.IsNullOrEmpty(m_szFoderPath))
                        {
                            string szCurrBranch = m_NgitMgr.GetCurrentBranch(m_szFoderPath);


                            if (string.IsNullOrEmpty(szCurrBranch))
                                MessageBox.Show("当前库处于头指针分离状态，请先切换到有效工作分支。", "Warnning");
                            else
                                m_NgitMgr.PullCurrentBranch(m_szFoderPath, szCurrBranch);
                        }
                        break;
                    } 
                case 3:
                    {
                        nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
                        if (nselected > 0)
                        {
                            ShellLib.Helpers.DragQueryFile(m_hDrop, 0, sb, sb.Capacity + 1);
                            m_NgitMgr.LocalOperate(sb.ToString());                     
                        }
                        else if (false == string.IsNullOrEmpty(m_szFoderPath))
                        {
                            m_NgitMgr.LocalOperate(m_szFoderPath);
                        }
                        break;
                    }
                case 4:
                    {
                        nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
                        if (nselected > 0)
                        {
                            ShellLib.Helpers.DragQueryFile(m_hDrop, 0, sb, sb.Capacity + 1);
                            m_NgitMgr.OperateRepository(sb.ToString());                     
                        }
                        else if (false == string.IsNullOrEmpty(m_szFoderPath))
                        {
                            m_NgitMgr.OperateRepository(m_szFoderPath);
                        }
                        break;
                    }
                case 5:
                    {                                              
                        nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
                        if (nselected > 0)
                        {
                            ShellLib.Helpers.DragQueryFile(m_hDrop, 0, sb, sb.Capacity + 1);
                            m_NgitMgr.RemoteOperate(sb.ToString());                     
                        }
                        else if (false == string.IsNullOrEmpty(m_szFoderPath))
                        {
                            m_NgitMgr.RemoteOperate(m_szFoderPath);
                        }
                        break;               
                    }
                case 7:
                    {                        
                        nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
                        if (nselected > 0)
                        {
                            ShellLib.Helpers.DragQueryFile(m_hDrop, 0, sb, sb.Capacity + 1);
                            m_NgitMgr.blame(sb.ToString(), sb.ToString(), "HEAD");                     
                        }
                        break;
                    }
                case 8:
                    {
                        //MessageBox.Show("the function is in design.....", "Warning");
                        //break;
                        nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
                        if (nselected > 0)
                        {
                            ShellLib.Helpers.DragQueryFile(m_hDrop, 0, sb, sb.Capacity + 1);
                            string szCurrBranch = m_NgitMgr.GetCurrentBranch(sb.ToString());
                            m_NgitMgr.ResolveConflicts(sb.ToString(), szCurrBranch);
                        }
                        break;
                    }
                case 6: //Open Main App UI
                    {
                        string szOperPath;
                        nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
                        if (nselected > 0)
                        {
                            ShellLib.Helpers.DragQueryFile(m_hDrop, 0, sb, sb.Capacity + 1);
                            szOperPath=sb.ToString();
                        }
                        else if (false == string.IsNullOrEmpty(m_szFoderPath))
                        {
                            szOperPath=m_szFoderPath;
                        }
                        else
                        {
                            szOperPath = string.Empty;
                        }

                        using (RegistryKey setupKey = Registry.CurrentUser.OpenSubKey(
                            @"Software\nGitScc"))
                        {
                            if (setupKey != null)
                            { 
                                string szInstlldir = setupKey.GetValue("InstllDir") as string;                               
 
                                if(string.IsNullOrEmpty(szInstlldir)==false
                                    && File.Exists(szInstlldir+"NGitApp.exe"))
                                {
                                    string szExeName = szInstlldir + "NGitApp.exe";
                                    Process pro = new Process();

                                    FileInfo file = new FileInfo(szExeName);
                                    pro.StartInfo.WorkingDirectory = file.Directory.FullName;
                                    pro.StartInfo.FileName = szExeName;
                                    pro.StartInfo.CreateNoWindow = false;
                                    pro.StartInfo.Arguments = string.Format("\"{0}\"",szOperPath);
                                    pro.Start();

                                    //proc.StartInfo.FileName = "IExplore.exe";
                                    //proc.StartInfo.Arguments = "http://wenku.baidu.com/view/83575484e53a580216fcfe55.html";
                                    break;
                                }
                            }
                        }
                        break;
                    }        
                default:
                    break;
            }
        }
        #endregion

        #region ============woking function============
        private void CreateMenu_Base(HMenu hMenu, uint iMenu, uint idCmdFirst, uint idCmdLast, CMF uFlags)
        {
            Bitmap bpCopy = Resource1.home;
            //Create Sub-Menu
            HMenu submenu = ShellLib.Helpers.CreatePopupMenu();
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 3), "Working Area");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 4), "Local Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 5), "Remote Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 6), "Main APP");
            Helpers.InsertMenu(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION | MFMENU.MF_POPUP, submenu.handle, "NGit Main");

            //add icon into sub-menu
            //Bitmap bpCopy = Resource1.copy;                
            Helpers.SetMenuItemBitmaps(submenu, 0, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 1, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 2, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 3, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.InsertMenu(hMenu, (int)iMenu + 1, MFMENU.MF_BYPOSITION | MFMENU.MF_SEPARATOR, new IntPtr(idCmdFirst + 0), "NGit Clone");
        }
        private void CreateMenu_InValidGit(HMenu hMenu, uint iMenu, uint idCmdFirst, uint idCmdLast, CMF uFlags)
        {
            Bitmap bpCopy = Resource1.home;
            //add menu items
            Helpers.InsertMenu(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION | MFMENU.MF_STRING, new IntPtr(idCmdFirst + 0), "NGit Clone");
            Helpers.SetMenuItemBitmaps(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.InsertMenu(hMenu, (int)iMenu + 1, MFMENU.MF_BYPOSITION | MFMENU.MF_STRING, new IntPtr(idCmdFirst + 1), "NGit Initialize");
            Helpers.SetMenuItemBitmaps(hMenu, (int)iMenu + 1, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());

            //Create Sub-Menu
            HMenu submenu = ShellLib.Helpers.CreatePopupMenu();
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 3), "Working Area");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 4), "Local Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 5), "Remote Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 6), "Main APP");
            Helpers.InsertMenu(hMenu, (int)iMenu + 2, MFMENU.MF_BYPOSITION | MFMENU.MF_POPUP, submenu.handle, "NGit Main");

            //add icon into sub-menu
            //Bitmap bpCopy = Resource1.copy;                
            Helpers.SetMenuItemBitmaps(submenu, 0, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 1, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 2, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 3, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.InsertMenu(hMenu, (int)iMenu + 3, MFMENU.MF_BYPOSITION | MFMENU.MF_SEPARATOR, new IntPtr(idCmdFirst + 0), "NGit Clone");
        }
        private void CreateMenu_ValidGit(HMenu hMenu, uint iMenu, uint idCmdFirst, uint idCmdLast, CMF uFlags)
        {
            Bitmap bpCopy = Resource1.home;
            //add menu items
            Helpers.InsertMenu(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION | MFMENU.MF_STRING, new IntPtr(idCmdFirst + 2), "NGit Refresh");
            Helpers.SetMenuItemBitmaps(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());


            //Create Sub-Menu
            HMenu submenu = ShellLib.Helpers.CreatePopupMenu();
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 3), "Working Area");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 4), "Local Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 5), "Remote Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 6), "Main APP");
            Helpers.InsertMenu(hMenu, (int)iMenu + 1, MFMENU.MF_BYPOSITION | MFMENU.MF_POPUP, submenu.handle, "NGit Main");

            //add icon into sub-menu
            //Bitmap bpCopy = Resource1.copy;                
            Helpers.SetMenuItemBitmaps(submenu, 0, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 1, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 2, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 3, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.InsertMenu(hMenu, (int)iMenu + 2, MFMENU.MF_BYPOSITION | MFMENU.MF_SEPARATOR, new IntPtr(idCmdFirst + 0), "NGit Clone");
        }
        private void CreateMenu_All(HMenu hMenu, uint iMenu, uint idCmdFirst, uint idCmdLast, CMF uFlags)
        {
            Bitmap bpCopy = Resource1.home;

            //add menu items
            Helpers.InsertMenu(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION | MFMENU.MF_STRING, new IntPtr(idCmdFirst + 0), "NGit Clone");
            Helpers.SetMenuItemBitmaps(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.InsertMenu(hMenu, (int)iMenu + 1, MFMENU.MF_BYPOSITION | MFMENU.MF_STRING, new IntPtr(idCmdFirst + 1), "NGit Initialize");
            Helpers.SetMenuItemBitmaps(hMenu, (int)iMenu + 1, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.InsertMenu(hMenu, (int)iMenu + 2, MFMENU.MF_BYPOSITION | MFMENU.MF_STRING, new IntPtr(idCmdFirst + 2), "NGit Refresh");
            Helpers.SetMenuItemBitmaps(hMenu, (int)iMenu + 2, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());


            //Create Sub-Menu
            HMenu submenu = ShellLib.Helpers.CreatePopupMenu();
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 3), "Working Area");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 4), "Local Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 5), "Remote Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 6), "Main APP");
            Helpers.InsertMenu(hMenu, (int)iMenu + 3, MFMENU.MF_BYPOSITION | MFMENU.MF_POPUP, submenu.handle, "NGit Main");

            //add icon into sub-menu
            //Bitmap bpCopy = Resource1.copy;                
            Helpers.SetMenuItemBitmaps(submenu, 0, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 1, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 2, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 3, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.InsertMenu(hMenu, (int)iMenu + 4, MFMENU.MF_BYPOSITION | MFMENU.MF_SEPARATOR, new IntPtr(idCmdFirst + 0), "NGit line");
        }
        private void CreateMenu_ConflictFile(HMenu hMenu, uint iMenu, uint idCmdFirst, uint idCmdLast, CMF uFlags)
        {
            Bitmap bpCopy = Resource1.home;
            //add menu items
            Helpers.InsertMenu(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION | MFMENU.MF_STRING, new IntPtr(idCmdFirst + 8), "NGit Resolve Conflict");
            Helpers.SetMenuItemBitmaps(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());


            //Create Sub-Menu
            HMenu submenu = ShellLib.Helpers.CreatePopupMenu();
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 3), "Working Area");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 4), "Local Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 5), "Remote Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 6), "Main APP");
            Helpers.InsertMenu(hMenu, (int)iMenu + 1, MFMENU.MF_BYPOSITION | MFMENU.MF_POPUP, submenu.handle, "NGit Main");

            //add icon into sub-menu
            //Bitmap bpCopy = Resource1.copy;                
            Helpers.SetMenuItemBitmaps(submenu, 0, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 1, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 2, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 3, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.InsertMenu(hMenu, (int)iMenu + 2, MFMENU.MF_BYPOSITION | MFMENU.MF_SEPARATOR, new IntPtr(idCmdFirst + 0), "NGit line");
        }
        private void CreateMenu_ValidGitFile(HMenu hMenu, uint iMenu, uint idCmdFirst, uint idCmdLast, CMF uFlags)
        {
            Bitmap bpCopy = Resource1.home;
            //add menu items
            Helpers.InsertMenu(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION | MFMENU.MF_STRING, new IntPtr(idCmdFirst + 7), "NGit Blame History");
 
            Helpers.SetMenuItemBitmaps(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());


            ////add menu items
            //Helpers.InsertMenu(hMenu, (int)iMenu, MFMENU.MF_BYPOSITION | MFMENU.MF_STRING, new IntPtr(idCmdFirst + 7), "NGit Resolve Conflict");
            //Helpers.SetMenuItemBitmaps(hMenu, (int)iMenu+1, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());

            //Create Sub-Menu
            HMenu submenu = ShellLib.Helpers.CreatePopupMenu();
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 3), "Working Area");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 4), "Local Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 5), "Remote Storage");
            Helpers.AppendMenu(submenu, MFMENU.MF_STRING, new IntPtr(idCmdFirst + 6), "Main APP");
            Helpers.InsertMenu(hMenu, (int)iMenu + 2, MFMENU.MF_BYPOSITION | MFMENU.MF_POPUP, submenu.handle, "NGit Main");

            //add icon into sub-menu
            //Bitmap bpCopy = Resource1.copy;                
            Helpers.SetMenuItemBitmaps(submenu, 0, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 1, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 2, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.SetMenuItemBitmaps(submenu, 3, MFMENU.MF_BYPOSITION, bpCopy.GetHbitmap(), bpCopy.GetHbitmap());
            Helpers.InsertMenu(hMenu, (int)iMenu + 3, MFMENU.MF_BYPOSITION | MFMENU.MF_SEPARATOR, new IntPtr(idCmdFirst + 0), "NGit line");
        
        }
        #endregion

        #region ============IQueryInfo============
        public uint GetInfoFlags(out uint dwFlags)
        {
            dwFlags = QITIPF_DEFAULT;

            return S_OK;
        }
        public uint GetInfoTip(uint dwFlags, out IntPtr pszInfoTip)
        {
            StreamReader sr = new StreamReader(szFileName, Encoding.GetEncoding("gb2312"));
            string text = sr.ReadToEnd();
            sr.Close();

            if (text.Length > 256)
            {
                text = text.Substring(0, 256) + "...";
            }

            string tip = "------------- nGit Information -------------\r\n\r\n" + text;
            pszInfoTip = Marshal.StringToCoTaskMemUni(tip);
            return S_OK;
        }
        #endregion

        #region ============IExtractIcon============

        int IExtractIcon.GetIconLocation(ExtractIconOptions uFlags, IntPtr szIconFile, uint cchMax, out int piIndex, out ExtractIconFlags pwFlags)
        {
            piIndex = -1;

            try
            {
                FileInfo f = new FileInfo(szFileName);
                lngFileSize = f.Length;
                pwFlags = ExtractIconFlags.DontCache | ExtractIconFlags.NotFilename;

                return S_OK;
            }
            catch { }

            pwFlags = ExtractIconFlags.None;
            return S_FALSE;
        }

        int IExtractIcon.Extract(string pszFile, uint nIconIndex, out Icon phiconLarge, out Icon phiconSmall, uint nIconSize)
        {
            phiconLarge = null;
            phiconSmall = null;

            try
            {
                if (lngFileSize > 16 * 1024)
                {
                    phiconLarge = Resource1._2;
                    phiconSmall = new Icon(Resource1._2, new Size(16, 16));
                }
                else if (lngFileSize > 0)
                {
                    phiconLarge = Resource1._1;
                    phiconSmall = new Icon(Resource1._1, new Size(16, 16));
                }
                else
                {
                    phiconLarge = Resource1._0;
                    phiconSmall = new Icon(Resource1._0, new Size(16, 16));
                }

                return S_OK;
            }
            catch { }

            return S_FALSE;
        }

        #endregion

        #region ============IPersistFile============
        public uint GetClassID(out Guid pClassID)
        {
            pClassID = new Guid("E7ECE5B0-8414-4fa7-9DE2-E8D8112F1519");

            return E_NOTIMPL;
        }
        public uint Load(string pszFileName, uint dwMode)
        {
            szFileName = pszFileName;

            return S_OK;
        }
        public uint IsDirty()
        {
            return E_NOTIMPL;

        }
        public uint Save(string pszFileName, bool fRemember)
        {
            return E_NOTIMPL;
        }
        public uint SaveCompleted(string pszFileName)
        {
            return E_NOTIMPL;
        }
        public uint GetCurFile(out string ppszFileName)
        {
            ppszFileName = null;

            return E_NOTIMPL;
        }
        #endregion

        #region ============IContextMenu3,Reserve===========
        //int IContextMenu3.HandleMenuMsg(uint uMsg, IntPtr wParam, IntPtr lParam)
        //{
        //    return HandleMenuMsg(uMsg, wParam, lParam, IntPtr.Zero);
        //}

        //int IContextMenu3.HandleMenuMsg2(uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr plResult)
        //{
        //    return HandleMenuMsg(uMsg, wParam, lParam, plResult);
        //}

        //int HandleMenuMsg(uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr plResult)
        //{
        //    switch (uMsg)
        //    {
        //        case Helpers.WM_MEASUREITEM:
        //            break;

        //        case Helpers.WM_DRAWITEM:
        //            DRAWITEMSTRUCT dis = new DRAWITEMSTRUCT();
        //            dis = (DRAWITEMSTRUCT)Marshal.PtrToStructure(lParam, dis.GetType());

        //            Rectangle rect = new Rectangle(dis.rcItem.left, dis.rcItem.top, dis.rcItem.right - dis.rcItem.left, dis.rcItem.bottom - dis.rcItem.top);
        //            DrawItemEventArgs args = new DrawItemEventArgs(Graphics.FromHdc(dis.hDC), new Font("宋体", 9),
        //                rect, dis.itemID, (DrawItemState)dis.itemState);
        //            //OnDrawItem(args);


        //            break;

        //        default:
        //            break;
        //    }

        //    return S_OK;
        //}     
        #endregion

        #region ============Registration============

        [System.Runtime.InteropServices.ComRegisterFunctionAttribute()]
        static void RegisterServer(String str1)
        {
            try
            {
                //注册 DLL
                RegistryKey root;
                RegistryKey rk;
                root = Registry.LocalMachine;
                rk = root.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true);
                rk.SetValue(GUID, KEYNAME);
                rk.Close();
                root.Close();

                //注册文件
                //RegTXT();
                RegAll();
            }
            catch{
            }
        }

        [System.Runtime.InteropServices.ComUnregisterFunctionAttribute()]
        static void UnregisterServer(String str1)
        {
            try
            {
                //注销动态库
                RegistryKey root;
                RegistryKey rk;
                root = Registry.LocalMachine;
                rk = root.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true);
                rk.DeleteValue(GUID);
                rk.Close();
                root.Close();

                //注销文件
                //UnRegTXT();
                UnRegAll();
            }
            catch
            {
            }
        }

        private static void RegAll()
        {
            RegistryKey rk, rk2;
            rk = Registry.ClassesRoot.OpenSubKey(@"*\shellex\ContextMenuHandlers", true);
            rk2 = rk.OpenSubKey(KEYNAME);
            if (rk2 == null)
                rk2 = rk.CreateSubKey(KEYNAME);
            rk2.SetValue("", GUID);
            rk2.Close();
            rk.Close();


            rk = null;
            rk2 = null;
            rk = Registry.ClassesRoot.OpenSubKey(@"Folder\shellex\ContextMenuHandlers", true);
            rk2 = rk.OpenSubKey(GUID);
            if (rk2 == null)
                rk2 = rk.CreateSubKey(KEYNAME);
            rk2.SetValue("", GUID);
            rk2.Close();
            rk.Close();

            rk = Registry.ClassesRoot.OpenSubKey(@"Directory\Background\shellex\ContextMenuHandlers", true);
            rk2 = rk.OpenSubKey(GUID);
            if (rk2 == null)
                rk2 = rk.CreateSubKey(KEYNAME);
            rk2.SetValue("", GUID);
            rk2.Close();
            rk.Close();

            //rk = Registry.ClassesRoot.OpenSubKey(@"Directory\shellex\ContextMenuHandlers", true);
            //rk2 = rk.OpenSubKey(GUID);
            //if (rk2 == null)
            //    rk2 = rk.CreateSubKey(KEYNAME);
            //rk2.SetValue("", GUID);
            //rk2.Close();
            //rk.Close();

        }

        private static void UnRegAll()
        {
            RegistryKey rk;
            rk = Registry.ClassesRoot.OpenSubKey(@"*\shellex\ContextMenuHandlers", true);
            rk.DeleteSubKey(KEYNAME, false);
            rk.Close();

            rk = Registry.ClassesRoot.OpenSubKey(@"Folder\shellex\ContextMenuHandlers", true);
            rk.DeleteSubKey(KEYNAME, false);
            rk.Close();

            rk = Registry.ClassesRoot.OpenSubKey(@"Directory\Background\shellex\ContextMenuHandlers", true);
            rk.DeleteSubKey(KEYNAME, false);
            rk.Close();

            //rk = Registry.ClassesRoot.OpenSubKey(@"Directory\shellex\ContextMenuHandlers", true);
            //rk.DeleteSubKey(KEYNAME, false);
            //rk.Close();

        }

        private static void RegTXT()
        {
            RegistryKey root;
            RegistryKey rk;

            root = Registry.ClassesRoot;
            rk = root.OpenSubKey(".txt");
            string txtclass = (string)rk.GetValue("");
            if (string.IsNullOrEmpty(txtclass))
            {
                txtclass = "TXT";
                rk.SetValue("", txtclass);

            }
            rk.Close();

            rk = root.CreateSubKey(txtclass + "\\shellex\\ContextMenuHandlers\\" + KEYNAME);
            rk.SetValue("", GUID);
            rk.Close();

            rk = root.CreateSubKey(txtclass + "\\shellex\\IconHandler");
            rk.SetValue("", GUID);
            rk.Close();

            rk = root.CreateSubKey(txtclass + "\\shellex\\{00021500-0000-0000-C000-000000000046}");
            rk.SetValue("", GUID);
            rk.Close();
        }

        private static void UnRegTXT()
        {
            RegistryKey root;
            RegistryKey rk;

            root = Registry.ClassesRoot;
            rk = root.OpenSubKey(".txt");
            rk.Close();
            string txtclass = (string)rk.GetValue("");
            if (!string.IsNullOrEmpty(txtclass))
            {
                root.DeleteSubKey(txtclass + "\\shellex\\ContextMenuHandlers\\" + KEYNAME);
                root.DeleteSubKey(txtclass + "\\shellex\\IconHandler");
                root.DeleteSubKey(txtclass + "\\shellex\\{00021500-0000-0000-C000-000000000046}");
            }
        }

        #endregion

        //   "C:\Windows\Microsoft.NET\Framework\v4.0.30319\regasm" "$(TargetPath)" /CodeBase
        //   "C:\Windows\Microsoft.NET\Framework\v4.0.30319\regasm" /unregister "$(TargetPath)" /CodeBase
    }

    [Guid("E7ECE5B0-8100-4fa7-9DE2-E8D8112F1519"), ComVisible(true)]
    public class GitIconOverlayNormal : IShellIconOverlayIdentifier
    {
        private const string GUID = "{E7ECE5B0-8100-4fa7-9DE2-E8D8112F1519}";
        private const string KEYNAME = "0NGitIconOverlayNormal";
        const int S_OK = 0;
        const int S_FALSE = 1;
        const uint ISIOI_ICONFILE = 0x00000001;
        const uint SIOI_ICONINDEX = 0x00000002;


        #region ===========IShellIconOverlayIdentifier=============
        public int IsMemberOf(string path, uint attributes)
        {
            if (CHelpFuntions.IsValidWorkingDir(path)) //test condition, here show everything with icon overlay
                return S_OK;         
            else 
                return S_FALSE;       
        }
        public int GetOverlayInfo(IntPtr iconFileBuffer, int iconFileBufferSize, out int iconIndex, out uint flags)
        {
            string icnFile = Environment.GetEnvironmentVariable("CommonProgramFiles") + @"\NgitOverlays\normal.ico";
            //string icnFile = @"C:\icon\normal.ico";
            //string icnFile = @"/ShellNgitExten;component/icon\normal.ico";
            byte[] bytes = Encoding.Unicode.GetBytes(icnFile);

            //byte[] bytes =Resource1.ResourceManager.GetObject("normal") as byte[];
            //for (int i = 0; i < bytes.Length; i++)
            //{
            //    Marshal.WriteByte(iconFileBuffer, i, bytes[i]);
            //}

            if (bytes.Length + 2 < iconFileBufferSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    Marshal.WriteByte(iconFileBuffer, i, bytes[i]);
                }
                //write the "\0\0"
                Marshal.WriteByte(iconFileBuffer, bytes.Length, 0);
                Marshal.WriteByte(iconFileBuffer, bytes.Length + 1, 0);
            }
            iconIndex = 0;
            flags = ISIOI_ICONFILE | SIOI_ICONINDEX;
            return S_OK;               
        }
        public int GetPriority(out int priority)
        {
            priority = 0;
            return S_OK;   
        }

        #endregion

        #region===========Registration=============

        [System.Runtime.InteropServices.ComRegisterFunctionAttribute()]
        static void RegisterServer(String str1)
        {
            RegistryKey rk =
            Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers\0NGitIconOverlayNormal");
            rk.SetValue(string.Empty, GUID);
            rk.Close();
        }

        [System.Runtime.InteropServices.ComUnregisterFunctionAttribute()]
        static void UnregisterServer(String str1)
        {
            Registry.LocalMachine.DeleteSubKeyTree(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers\0NGitIconOverlayNormal");

        }
        #endregion
    }
        
    [Guid("E7ECE5B0-8200-4fa7-9DE2-E8D8112F1519"), ComVisible(true)]
    public class GitIconOverlayNew : IShellIconOverlayIdentifier
    {
        //ST_IGNORED   ST_INVALID_REPO   ST_NULL
        private const string GUID = "{E7ECE5B0-8200-4fa7-9DE2-E8D8112F1519}";
        private const string KEYNAME = "0NGitIconOverlayNew";
        const int S_OK = 0;
        const int S_FALSE = 1;
        const uint ISIOI_ICONFILE = 0x00000001;
        const uint SIOI_ICONINDEX = 0x00000002;
        private NGitModule m_NgitMgr = null;

        public GitIconOverlayNew()
        {
            m_NgitMgr = NGitModule.GetInstence();
            if (m_NgitMgr == null && m_NgitMgr.MgrInitialize(IntPtr.Zero)==false)
            {
                m_NgitMgr = null;
            }    
        }

        #region ===========IShellIconOverlayIdentifier=============
        public int IsMemberOf(string path, uint attributes)
        {
            if (m_NgitMgr==null)
                return  S_FALSE;

            if (m_NgitMgr.GetFileStatus(path) == FileSccStatus.ST_NOT_CONTROLLED) 
                return S_OK;         
            else 
                return S_FALSE;       
        }
        public int GetOverlayInfo(IntPtr iconFileBuffer, int iconFileBufferSize, out int iconIndex, out uint flags)
        {
            string icnFile = Environment.GetEnvironmentVariable("CommonProgramFiles") + @"\NgitOverlays\new.ico";
            //string icnFile = @"C:\icon\new.ico";
            byte[] bytes = Encoding.Unicode.GetBytes(icnFile);
            if (bytes.Length + 2 < iconFileBufferSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    Marshal.WriteByte(iconFileBuffer, i, bytes[i]);
                }
                //write the "\0\0"
                Marshal.WriteByte(iconFileBuffer, bytes.Length, 0);
                Marshal.WriteByte(iconFileBuffer, bytes.Length + 1, 0);
            }
            iconIndex = 0;
            flags = ISIOI_ICONFILE | ISIOI_ICONFILE;
            return S_OK;               
        }
        public int GetPriority(out int priority)
        {
            priority = 0;
            return S_OK;   
        }
        #endregion

        #region===========Registration=============

        [System.Runtime.InteropServices.ComRegisterFunctionAttribute()]
        static void RegisterServer(String str1)
        {
            RegistryKey rk =
            Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers\0NGitIconOverlayNew");
            rk.SetValue(string.Empty, GUID);
            rk.Close();
        }

        [System.Runtime.InteropServices.ComUnregisterFunctionAttribute()]
        static void UnregisterServer(String str1)
        {
            Registry.LocalMachine.DeleteSubKeyTree(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers\0NGitIconOverlayNew");

        }
        #endregion
    }
        
    [Guid("E7ECE5B0-8300-4fa7-9DE2-E8D8112F1519"), ComVisible(true)]
    public class GitIconOverlayConflict : IShellIconOverlayIdentifier
    {
        //ST_IGNORED   ST_INVALID_REPO   ST_NULL
        private const string GUID = "{E7ECE5B0-8300-4fa7-9DE2-E8D8112F1519}";
        private const string KEYNAME = "0NGitIconOverlayConflict";
        const int S_OK = 0;
        const int S_FALSE = 1;
        const uint ISIOI_ICONFILE = 0x00000001;
        const uint SIOI_ICONINDEX = 0x00000002;
        private NGitModule m_NgitMgr = null;

        public GitIconOverlayConflict()
        {
            m_NgitMgr = NGitModule.GetInstence();
            if (m_NgitMgr == null && m_NgitMgr.MgrInitialize(IntPtr.Zero)==false)
            {
                m_NgitMgr = null;
            }    
        }

        #region ===========IShellIconOverlayIdentifier=============
        public int IsMemberOf(string path, uint attributes)
        {
            if (m_NgitMgr==null)
                return  S_FALSE;

            if (m_NgitMgr.GetFileStatus(path) == FileSccStatus.ST_CONFLICT) 
                return S_OK;         
            else 
                return S_FALSE;       
        }
        public int GetOverlayInfo(IntPtr iconFileBuffer, int iconFileBufferSize, out int iconIndex, out uint flags)
        {
            string icnFile = Environment.GetEnvironmentVariable("CommonProgramFiles") + @"\NgitOverlays\conflict.ico";
            //string icnFile = @"C:\icon\conflict.ico";
            byte[] bytes = Encoding.Unicode.GetBytes(icnFile);
            if (bytes.Length + 2 < iconFileBufferSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    Marshal.WriteByte(iconFileBuffer, i, bytes[i]);
                }
                //write the "\0\0"
                Marshal.WriteByte(iconFileBuffer, bytes.Length, 0);
                Marshal.WriteByte(iconFileBuffer, bytes.Length + 1, 0);
            }
            iconIndex = 0;
            flags = ISIOI_ICONFILE | ISIOI_ICONFILE;
            return S_OK;               
        }
        public int GetPriority(out int priority)
        {
            priority = 0;
            return S_OK;   
        }
        #endregion
        
        #region===========Registration=============
        [System.Runtime.InteropServices.ComRegisterFunctionAttribute()]
        static void RegisterServer(String str1)
        {
            RegistryKey rk =
            Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers\0NGitIconOverlayConflict");
            rk.SetValue(string.Empty, GUID);
            rk.Close();
        }

        [System.Runtime.InteropServices.ComUnregisterFunctionAttribute()]
        static void UnregisterServer(String str1)
        {
            Registry.LocalMachine.DeleteSubKeyTree(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers\0NGitIconOverlayConflict");

        }
        #endregion
    }
    
    [Guid("E7ECE5B0-8400-4fa7-9DE2-E8D8112F1519"), ComVisible(true)]
    public class GitIconOverlayCheckIn : IShellIconOverlayIdentifier
    {
        //ST_IGNORED   ST_INVALID_REPO   ST_NULL
        private const string GUID = "{E7ECE5B0-8400-4fa7-9DE2-E8D8112F1519}";
        private const string KEYNAME = "0NGitIconOverlayCheckIn";
        const int S_OK = 0;
        const int S_FALSE = 1;
        const uint ISIOI_ICONFILE = 0x00000001;
        const uint SIOI_ICONINDEX = 0x00000002;
        private NGitModule m_NgitMgr = null;

        public GitIconOverlayCheckIn()
        {
            m_NgitMgr = NGitModule.GetInstence();
            if (m_NgitMgr == null && m_NgitMgr.MgrInitialize(IntPtr.Zero)==false)
            {
                m_NgitMgr = null;
            }    
        }

        #region ===========IShellIconOverlayIdentifier=============
        public int IsMemberOf(string path, uint attributes)
        {
            if (m_NgitMgr==null)
                return  S_FALSE;

            if (m_NgitMgr.GetFileStatus(path) == FileSccStatus.ST_NEW_CHECKIN) 
                return S_OK;         
            else 
                return S_FALSE;       
        }
        public int GetOverlayInfo(IntPtr iconFileBuffer, int iconFileBufferSize, out int iconIndex, out uint flags)
        {
            string icnFile = Environment.GetEnvironmentVariable("CommonProgramFiles") + @"\NgitOverlays\checkin.ico";
            //string icnFile = @"C:\icon\checkin.ico";
            byte[] bytes = Encoding.Unicode.GetBytes(icnFile);
            if (bytes.Length + 2 < iconFileBufferSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    Marshal.WriteByte(iconFileBuffer, i, bytes[i]);
                }
                //write the "\0\0"
                Marshal.WriteByte(iconFileBuffer, bytes.Length, 0);
                Marshal.WriteByte(iconFileBuffer, bytes.Length + 1, 0);
            }
            iconIndex = 0;
            flags = ISIOI_ICONFILE | ISIOI_ICONFILE;
            return S_OK;               
        }
        public int GetPriority(out int priority)
        {
            priority = 0;
            return S_OK;   
        }

        #endregion

        #region===========Registration=============

        [System.Runtime.InteropServices.ComRegisterFunctionAttribute()]
        static void RegisterServer(String str1)
        {
            RegistryKey rk =
            Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers\0NGitIconOverlayCheckIn");
            rk.SetValue(string.Empty, GUID);
            rk.Close();
        }

        [System.Runtime.InteropServices.ComUnregisterFunctionAttribute()]
        static void UnregisterServer(String str1)
        {
            Registry.LocalMachine.DeleteSubKeyTree(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers\0NGitIconOverlayCheckIn");

        }
        #endregion
    }

    [Guid("E7ECE5B0-8500-4fa7-9DE2-E8D8112F1519"), ComVisible(true)]
    public class GitIconOverlayModify : IShellIconOverlayIdentifier
    {
        //ST_IGNORED   ST_INVALID_REPO   ST_NULL
        private const string GUID = "{E7ECE5B0-8500-4fa7-9DE2-E8D8112F1519}";
        private const string KEYNAME = "0NGitIconOverlayModify";
        const int S_OK = 0;
        const int S_FALSE = 1;
        const uint ISIOI_ICONFILE = 0x00000001;
        const uint SIOI_ICONINDEX = 0x00000002;
        private NGitModule m_NgitMgr = null;

        public GitIconOverlayModify()
        {
            m_NgitMgr = NGitModule.GetInstence();
            if (m_NgitMgr == null && m_NgitMgr.MgrInitialize(IntPtr.Zero)==false)
            {
                m_NgitMgr = null;
            }    
        }

        #region ===========IShellIconOverlayIdentifier=============
        public int IsMemberOf(string path, uint attributes)
        {
            if (m_NgitMgr==null)
                return  S_FALSE;

            FileSccStatus status = m_NgitMgr.GetFileStatus(path);
            if (status != FileSccStatus.ST_NEW_CHECKIN &&
                    status != FileSccStatus.ST_NOT_CONTROLLED &&
                    status != FileSccStatus.ST_CONFLICT &&
                    status != FileSccStatus.ST_IGNORED &&
                    status != FileSccStatus.ST_INVALID_REPO &&
                    status != FileSccStatus.ST_NULL 
                ) 
                return S_OK;         
            else 
                return S_FALSE;       
        }
        public int GetOverlayInfo(IntPtr iconFileBuffer, int iconFileBufferSize, out int iconIndex, out uint flags)
        {
            string icnFile = Environment.GetEnvironmentVariable("CommonProgramFiles") + @"\NgitOverlays\modify.ico";
            //string icnFile = @"C:\icon\modify.ico";
            byte[] bytes = Encoding.Unicode.GetBytes(icnFile);
            if (bytes.Length + 2 < iconFileBufferSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    Marshal.WriteByte(iconFileBuffer, i, bytes[i]);
                }
                //write the "\0\0"
                Marshal.WriteByte(iconFileBuffer, bytes.Length, 0);
                Marshal.WriteByte(iconFileBuffer, bytes.Length + 1, 0);
            }
            iconIndex = 0;
            flags = ISIOI_ICONFILE | ISIOI_ICONFILE;
            return S_OK;               
        }
        public int GetPriority(out int priority)
        {
            priority = 0;
            return S_OK;   
        }

        #endregion

        #region===========Registration=============

        [System.Runtime.InteropServices.ComRegisterFunctionAttribute()]
        static void RegisterServer(String str1)
        {
            RegistryKey rk =
            Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers\0NGitIconOverlayModify");
            rk.SetValue(string.Empty, GUID);
            rk.Close();
        }

        [System.Runtime.InteropServices.ComUnregisterFunctionAttribute()]
        static void UnregisterServer(String str1)
        {
            Registry.LocalMachine.DeleteSubKeyTree(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers\0NGitIconOverlayModify");

        }
        #endregion     
      
    }


}
