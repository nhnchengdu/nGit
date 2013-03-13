
/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Git.Manager;

using IServiceProvider = System.IServiceProvider;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace Nhn.Git.SourceControl.Provider
{
    /// <summary>
    /// Summary description for SccProviderToolWindow.
    /// </summary>
    [Guid("C4AC6F91-14BF-4D1B-B67D-DB654BB1B5F7")]
    public class SccProviderToolWindow : ToolWindowPane
    {
        private SccProviderToolWindowControl control;
        CGitManager _objGitMgr = null;
        //string _szSolutionName = null;

        public SccProviderToolWindow() :base(null)
        {
            // set the window title
            this.Caption = Resources.ResourceManager.GetString("ToolWindowCaption");

            // set the CommandID for the window ToolBar
            this.ToolBar = new CommandID(GuidList.guidSccProviderCmdSet, CommandId.imnuToolWindowToolbarMenu);

            // set the icon for the frame
            this.BitmapResourceID = CommandId.ibmpToolWindowsImages;  // bitmap strip resource ID
            this.BitmapIndex = CommandId.iconSccProviderToolWindow;   // index in the bitmap strip

            control = new SccProviderToolWindowControl();
        }

        override public IWin32Window Window
        {
            get
            {
                return (IWin32Window)control;
            }
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.Dispose1"]' />
        /// <devdoc>
        ///     Called when this tool window pane is being disposed.
        /// </devdoc>
        override protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (control != null)
                {
                    try
                    {
                        if (control is IDisposable)
                            control.Dispose();
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.Fail(String.Format("Failed to dispose {0} controls.\n{1}", this.GetType().FullName, e.Message));
                    }
                    control = null;
                } 
                
                IVsWindowFrame windowFrame = (IVsWindowFrame)this.Frame;
                if (windowFrame != null)
                {
                    // Note: don't check for the return code here.
                    windowFrame.CloseFrame((uint)__FRAMECLOSE.FRAMECLOSE_SaveIfDirty);
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This function is only used to "do something noticeable" when the toolbar button is clicked.
        /// It is called from the package.
        /// A typical tool window may not need this function.
        /// 
        /// The current behavior change the background color of the control
        /// </summary>
        public void ToolWindowToolbarCommand()
        {
            if (this.control.BackColor == Color.Coral)
                this.control.BackColor = Color.White;
            else
                this.control.BackColor = Color.Coral;
        }



        public void Initialize(CGitManager objGitMgr)
        {
            _objGitMgr = objGitMgr;
            if(_objGitMgr!=null)
            {
                control.Initialize(_objGitMgr);
            }
        }
        public void ValidConfig(string szSolutionDir)
        {
            if (_objGitMgr != null)
            {
                control.CheckConfig(szSolutionDir);
            }
        }

    }
}
