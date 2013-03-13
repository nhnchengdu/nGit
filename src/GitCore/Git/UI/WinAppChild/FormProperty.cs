using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;
using System.IO;
using Git.Core.Helper;
using Git.Core.SourceApp;
using Git.Manager;
using Git.UI;



namespace GitCore.Git.UI
{
    


    public partial class FormProperty : Form
    {

        private SccProviderProperty m_oInforProperty;
        private CGitManager _objGitMgr = null;
        private string _szSolutionName = null;

        public FormProperty(CGitManager objGitMgr, string szTargetDir)
        {
            InitializeComponent();
            m_oInforProperty = new SccProviderProperty();

            _szSolutionName = szTargetDir;
            _objGitMgr = objGitMgr;
        }

        private void FormProperty_Load(object sender, EventArgs e)
        {
            this.propertyGrid1.SelectedObject = m_oInforProperty;
            try
            {
                Initialize();
                CheckConfig(_szSolutionName);
            }
            catch 
            {
            	
            }
            
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (null != e.ChangedItem)
            {
                string szItemName = e.ChangedItem.PropertyDescriptor.Name;
                if (szItemName.Equals(@"GitApplication"))
                {
                    CGitSourceConfig.SetGitExRegValue(m_oInforProperty.GitApplication);
                    Initialize();
                }
                else if (szItemName.Equals(@"MergeTool"))
                {
                    string szNameTar = Path.GetFileNameWithoutExtension(m_oInforProperty.MergeTool);

                    string szConfigItem = string.Empty;
                    if (string.IsNullOrEmpty(szNameTar))
                    {
                        szConfigItem = string.Format("--unset merge.tool");
                    }
                    else
                    {
                        string szUnixFileName = szNameTar.Replace("\\", "/");
                        szConfigItem = string.Format("merge.tool \"{0}\"", szUnixFileName);
                    }

                    _objGitMgr._objGitMgrCore.SetGlobalConfigInfo(szConfigItem, null);



                    if (false == string.IsNullOrEmpty(szNameTar))
                    {
                        string szUnixFileName = m_oInforProperty.MergeTool.Replace("\\", "/");
                        szConfigItem = string.Format("mergetool.{0}.path \"{1}\"", szNameTar, szUnixFileName);
                        _objGitMgr._objGitMgrCore.SetGlobalConfigInfo(szConfigItem, null);
                    }
                    //Initialize(null);

                }
                else if (szItemName.Equals(@"CompareTool"))
                {

                    string szNameTar = Path.GetFileNameWithoutExtension(m_oInforProperty.CompareTool);

                    string szConfigItem = string.Empty;
                    if (string.IsNullOrEmpty(szNameTar))
                    {
                        szConfigItem = string.Format("--unset diff.guitool");
                    }
                    else
                    {
                        string szUnixFileName = szNameTar.Replace("\\", "/");
                        szConfigItem = string.Format("diff.guitool \"{0}\"", szUnixFileName);
                    }

                    _objGitMgr._objGitMgrCore.SetGlobalConfigInfo(szConfigItem, null);


                    if (false == string.IsNullOrEmpty(szNameTar))
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
                    string szConfigItem = string.Empty;
                    if (string.IsNullOrEmpty(m_oInforProperty.UserName))
                    {
                        szConfigItem = string.Format("--unset user.name");
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
        public void Initialize()
        {
            if (_objGitMgr != null)
            {
                m_oInforProperty.GitApplication = CGitSourceConfig.GetGitExRegValue();
                m_oInforProperty.GitInfomation = _objGitMgr._objGitMgrCore.GetVersion();
                m_oInforProperty.UserName = _objGitMgr._objGitMgrCore.GetConfigInfo("user.name", null);
                m_oInforProperty.UserEmail = _objGitMgr._objGitMgrCore.GetConfigInfo("user.email", null);

                string szMergeTool = _objGitMgr._objGitMgrCore.GetConfigInfo("merge.tool", null);
                if (string.IsNullOrEmpty(szMergeTool) == false)
                {
                    string szMereItem = string.Format("mergetool.{0}.path", szMergeTool);
                    m_oInforProperty.MergeTool = _objGitMgr._objGitMgrCore.GetConfigInfo(szMereItem, null);
                }

                string szDiffTool = _objGitMgr._objGitMgrCore.GetConfigInfo("diff.guitool", null);
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
            if (string.IsNullOrEmpty(szSolutionDir) == false)
                _szSolutionName = szSolutionDir;

            string szWorkingDir = m_oInforProperty.RepositoryPath = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            if (string.IsNullOrEmpty(szWorkingDir) == false)
            {
                string[] szBRArray = _objGitMgr._objGitMgrCore.GetBranch(false, szWorkingDir);
                if (szBRArray.Length > 0)
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

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            string szItemName = e.NewSelection.PropertyDescriptor.Name;
            if (szItemName.Equals(@"SSH"))
            {
                m_btnSSHConfig.Visible = true;
            }
            else
            {
                m_btnSSHConfig.Visible = false;
            }
        }

        private void m_btnSSHConfig_Click(object sender, EventArgs e)
        {
            if (_objGitMgr == null)
                return;
            new FormSshProperty(_objGitMgr, null, null).ShowDialog(this);     
        }
  
    }
}
