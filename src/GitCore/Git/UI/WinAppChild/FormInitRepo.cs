using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Git.Manager;
using Git.Core.Helper;
using Git.Core.SourceApp;

namespace Git.UI
{
    public partial class FormInitRepo : Form
    {
        private string _szSelectedRepoDir=null;
        private string _szSolutionRepoDir=null;
        CGitManager _objGitMgr = null;

        public FormInitRepo(string szRepoDir, CGitManager objGitMgr)
        {
            InitializeComponent();
            _szSolutionRepoDir = szRepoDir;
            _objGitMgr = objGitMgr;

            if(null==szRepoDir)
            {
                m_rbSolutionDir.Enabled = false;
                m_rbSolutionDir.Checked = false;
                m_rbSelecteDir. Checked  = true;

                m_btnBrowse.Enabled = true;
                m_Directory.Enabled = true;                 

            }
            else
            {
                m_rbSolutionDir.Enabled = true;
                m_rbSolutionDir.Checked = true;
                m_rbSelecteDir.Checked = false;
                m_btnBrowse.Enabled = false;
                m_Directory.Enabled = false;     
            }

           // if (!Settings.Module.ValidWorkingDir())
           //     Directory.Text = Settings.WorkingDir;
        }



        private void Browse_Click(object sender, EventArgs e)
        {
            var browseDialog = new FolderBrowserDialog();

            if (browseDialog.ShowDialog(this) == DialogResult.OK)
                m_Directory.Text = browseDialog.SelectedPath;
            _szSolutionRepoDir = m_Directory.Text;

        }

        private void Init_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_Directory.Text) && string.IsNullOrEmpty(_szSolutionRepoDir))
                return;

            string szValidDir = CHelpFuntions.GetValidWorkingDir(m_Directory.Text);
            if (false == string.IsNullOrEmpty(szValidDir))
            {
                MessageBox.Show(this, "The Selected Directory has been in a Local git Repository!", "Error");
                return;
            }

            string szTargetsz;
            if(m_rbSolutionDir.Checked == true)
                szTargetsz=_szSolutionRepoDir;
            else
                szTargetsz=m_Directory.Text;

            if (!System.IO.Directory.Exists(szTargetsz))
                System.IO.Directory.CreateDirectory(szTargetsz);

            if (szTargetsz != null)
            { 
                int iCode;
                string szReult= _objGitMgr._objGitMgrCore.InitRepository(szTargetsz, m_chkCentral.Checked, out iCode);
                if(iCode==0)
                {
                    MessageBox.Show(this, szReult, "Initialize Repository");
                    CGitSourceConfig.SetTargetUrlRegValue(szTargetsz,false);
                    InitGUI();
                }
                else
                {
                    MessageBox.Show(this, "Error: Initialize Repository failed.", "Initialize Repository"); 
                }            
            }

            //Repositories.AddMostRecentRepository(Directory.Text);
            Close();
            

        }

        private void Directory_DropDown(object sender, EventArgs e)
        {
            //

        }

        private void rbSelecteDir_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rbSelecteDir.Checked == false)
            {
                m_btnBrowse.Enabled = false;
                m_Directory.Enabled = false;
            }
            else
            {
                m_btnBrowse.Enabled = true;
                m_Directory.Enabled = true;
            }
        }

        private void FormInitRepo_Load(object sender, EventArgs e)
        {
            InitGUI();
        }
        private void InitGUI()
        {
            m_Directory.Items.Clear();
            List<string> DirList = CGitSourceConfig.GetTargetUrlRegValue(false);
            if (DirList != null && DirList.Count > 0)
            {
                foreach (string szItm in DirList)
                {
                    m_Directory.Items.Add(szItm);
                }
            }

            if (m_rbSolutionDir.Enabled == true)
            {
                m_Directory.Text = _szSolutionRepoDir;
            }
        }

        private void rbSolutionDir_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rbSolutionDir.Enabled == true)
            {
                m_Directory.Text = _szSolutionRepoDir;
            }
        }


    }
}
