
/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Globalization;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Git.Manager;
using Git.Core.SourceApp;
using Git.Core.Helper;

using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Reflection;
using System.IO;

using IServiceProvider = System.IServiceProvider;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace Nhn.Git.SourceControl.Provider
{
    /// <summary>
    /// Summary description for SccProviderToolWindowControl.
    /// </summary>
    public class SccProviderToolWindowControl : System.Windows.Forms.UserControl
    {
        private Label label1;
        private PropertyGrid propertyGrid1;
        private SccProviderProperty m_oInforProperty;

        private CGitManager _objGitMgr = null;
        private string _szSolutionName = null;


        public SccProviderToolWindowControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            m_oInforProperty = new SccProviderProperty();
        }
        /// <summary> 
        /// Let this control process the mnemonics.
        /// </summary>
        protected override bool ProcessDialogChar(char charCode)
        {
              // If we're the top-level form or control, we need to do the mnemonic handling
              if (charCode != ' ' && ProcessMnemonic(charCode))
              {
                    return true;
              }
              return base.ProcessDialogChar(charCode);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SccProviderToolWindowControl));
            this.label1 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.AllowDrop = true;
            resources.ApplyResources(this.propertyGrid1, "propertyGrid1");
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.UseCompatibleTextRendering = true;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // SccProviderToolWindowControl
            // 
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.label1);
            this.Name = "SccProviderToolWindowControl";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.SccProviderToolWindowControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        #region Event function
        private void SccProviderToolWindowControl_Load(object sender, EventArgs e)
        {
            this.propertyGrid1.SelectedObject = m_oInforProperty;
        }
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {                              

            if (null != e.ChangedItem)
            {
                string szItemName = e.ChangedItem.PropertyDescriptor.Name;
                if (szItemName.Equals(@"GitApplication"))
                {
                    CGitSourceConfig.SetGitExRegValue(m_oInforProperty.GitApplication);
                    Initialize(null);
                }
                else if (szItemName.Equals(@"MergeTool"))
                {
                    string szNameTar = Path.GetFileNameWithoutExtension(m_oInforProperty.MergeTool);

                    string szConfigItem=string.Empty;
                    if(string.IsNullOrEmpty(szNameTar))
                    {
                        szConfigItem=string.Format("--unset merge.tool");
                    }
                    else
                    {
                        string szUnixFileName = szNameTar.Replace("\\", "/");
                        szConfigItem = string.Format("merge.tool \"{0}\"", szUnixFileName);
                    }

                    _objGitMgr._objGitMgrCore.SetGlobalConfigInfo(szConfigItem, null);


                                        
                    if(false==string.IsNullOrEmpty(szNameTar))
                    {
                        string szUnixFileName=m_oInforProperty.MergeTool.Replace("\\", "/");
                        szConfigItem = string.Format("mergetool.{0}.path \"{1}\"",szNameTar,szUnixFileName );
                        _objGitMgr._objGitMgrCore.SetGlobalConfigInfo(szConfigItem, null);
                    }
                    //Initialize(null);

                }
                else if (szItemName.Equals(@"CompareTool"))
                {

                    string szNameTar = Path.GetFileNameWithoutExtension(m_oInforProperty.CompareTool);

                    string szConfigItem=string.Empty;
                    if(string.IsNullOrEmpty(szNameTar))
                    {
                        szConfigItem=string.Format("--unset diff.guitool");
                    }
                    else
                    {
                        string szUnixFileName = szNameTar.Replace("\\", "/");
                        szConfigItem = string.Format("diff.guitool \"{0}\"", szUnixFileName);
                    }
                    
                    _objGitMgr._objGitMgrCore.SetGlobalConfigInfo(szConfigItem, null);

                                       
                    if(false==string.IsNullOrEmpty(szNameTar))
                    {
                        string szUnixFileName = m_oInforProperty.CompareTool.Replace("\\", "/");
                        szConfigItem = string.Format("difftool.{0}.path \"{1}\"", szNameTar, szUnixFileName);
                        _objGitMgr._objGitMgrCore.SetGlobalConfigInfo(szConfigItem, null);

                        
                        string szContent = "\\\"" + szUnixFileName + "\\\" \\\"$LOCAL\\\" \\\"$REMOTE\\\"";
                        szConfigItem = string.Format("difftool.{0}.cmd \"{1}\"", szNameTar, szContent);
                        _objGitMgr._objGitMgrCore.SetGlobalConfigInfo(szConfigItem, null);
                    }
                   // Initialize(null);
                }
                else if (szItemName.Equals(@"SSHPath"))
                {

                }
                else if (szItemName.Equals(@"SSH"))
                {
                    if (m_oInforProperty.SSH == SccProviderProperty.SshType.TYPE_OTHER || m_oInforProperty.SSH == SccProviderProperty.SshType.TYPE_PUTTY)
                    {
                        SetPropertyVisibility(m_oInforProperty, "SSHPath", true);
                    }
                    else
                    {
                        SetPropertyVisibility(m_oInforProperty, "SSHPath", false);
                    }


                }
                else if (szItemName.Equals(@"UserName"))
                {
                    string szConfigItem=string.Empty;
                    if(string.IsNullOrEmpty(m_oInforProperty.UserName))
                    {
                        szConfigItem=string.Format("--unset user.name");
                    }
                    else
                    {
                        szConfigItem = string.Format("user.name \"{0}\"", m_oInforProperty.UserName);
                    }
                    _objGitMgr._objGitMgrCore.SetConfigInfo(szConfigItem, null);
                }
                else if (szItemName.Equals(@"UserEmail"))
                {
                    string szConfigItem = string.Empty;
                    if (string.IsNullOrEmpty(m_oInforProperty.UserEmail))
                    {
                        szConfigItem = string.Format("--unset user.email");
                    }
                    else
                    {
                        szConfigItem = string.Format("user.email \"{0}\"", m_oInforProperty.UserEmail);
                    }
                     _objGitMgr._objGitMgrCore.SetConfigInfo(szConfigItem, null);

                }
                else
                {
                    return;
                }
                propertyGrid1.Refresh();


            }


        }        
        #endregion

        #region Implementation function
        private void SetPropertyVisibility(object obj, string propertyName, bool visible)
        {
            Type type = typeof(BrowsableAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField("browsable", BindingFlags.Instance | BindingFlags.NonPublic);
            fld.SetValue(attrs[type], visible);
        }
        private void SetPropertyReadOnly(object obj, string propertyName, bool readOnly)
        {
            Type type = typeof(System.ComponentModel.ReadOnlyAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField("isReadOnly", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance);
            fld.SetValue(attrs[type], readOnly);
        }
        public void Initialize(CGitManager objGitMgr)
        {
            if (_objGitMgr == null)
                _objGitMgr = objGitMgr;

            if (_objGitMgr != null)
            {
                m_oInforProperty.GitApplication = CGitSourceConfig.GetGitExRegValue();
                m_oInforProperty.GitInfomation = _objGitMgr._objGitMgrCore.GetVersion();
                m_oInforProperty.UserName = _objGitMgr._objGitMgrCore.GetConfigInfo("user.name", null);
                m_oInforProperty.UserEmail = _objGitMgr._objGitMgrCore.GetConfigInfo("user.email", null);

                string szMergeTool = objGitMgr._objGitMgrCore.GetConfigInfo("merge.tool", null);
                if (string.IsNullOrEmpty(szMergeTool) == false)
                {
                    string szMereItem = string.Format("mergetool.{0}.path", szMergeTool);
                    m_oInforProperty.MergeTool = _objGitMgr._objGitMgrCore.GetConfigInfo(szMereItem, null);
                }

                string szDiffTool = objGitMgr._objGitMgrCore.GetConfigInfo("diff.guitool", null);
                if (string.IsNullOrEmpty(szDiffTool) == false)
                {
                    string szDiffItem = string.Format("difftool.{0}.path", szDiffTool);
                    m_oInforProperty.CompareTool = _objGitMgr._objGitMgrCore.GetConfigInfo(szDiffItem, null);
                }
                propertyGrid1.Refresh();
            }
        }
        public void CheckConfig(string szSolutionDir)
        {
            if(string.IsNullOrEmpty(szSolutionDir)==false)
                _szSolutionName = szSolutionDir;

            string szWorkingDir=m_oInforProperty.RepositoryPath = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            if (string.IsNullOrEmpty(szWorkingDir) == false)
            {
                string[] szBRArray = _objGitMgr._objGitMgrCore.GetBranch(false, szWorkingDir);
                if(szBRArray.Length>0)
                {
                    m_oInforProperty.WorkingBranch = szBRArray[0];
                }
            }
            
            if (_objGitMgr != null)
            {
                m_oInforProperty.UserName = _objGitMgr._objGitMgrCore.GetConfigInfo("user.name", null);
                m_oInforProperty.UserEmail = _objGitMgr._objGitMgrCore.GetConfigInfo("user.email", null);

                if (string.IsNullOrEmpty(m_oInforProperty.GitApplication))
                {
                    MessageBox.Show(this, @"Please set the git execution application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(m_oInforProperty.UserName) || string.IsNullOrEmpty(m_oInforProperty.UserEmail))
                {
                    MessageBox.Show(this, @"Please set the user and email. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(m_oInforProperty.CompareTool) || string.IsNullOrEmpty(m_oInforProperty.MergeTool))
                {
                    MessageBox.Show(this, @"Please config the merge and compare tool.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            propertyGrid1.Refresh();
        }
        #endregion



    }
}
