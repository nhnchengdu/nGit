using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Git.Core.SourceApp;
using Git.Manager;
using Git.Core.Helper;

namespace Git.UI
{
    public partial class TestForm : Form
    {

        CGitManager _objGitMgr = null;
        string _szSolutionName = null;

        public TestForm(string szSolutionName, CGitManager objGitMgr)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szSolutionName = szSolutionName;

            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            this.m_RepositoryControl.InitGitEnv(szWorkingDir, _objGitMgr);
 
        }

        /*
        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Repo_CheckOut form = new Form_Repo_CheckOut();
            form.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form_Repo_AddBranch form = new Form_Repo_AddBranch();
            form.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form_Repo_RemoveBranch form = new Form_Repo_RemoveBranch();
            form.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form_Repo_SwitchBranch form = new Form_Repo_SwitchBranch();
            form.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Form_Repo_AddTag form = new Form_Repo_AddTag();
            form.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Form_Repo_RemoveTag form = new Form_Repo_RemoveTag();
            form.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Form_Repo_MergeTo form = new Form_Repo_MergeTo();
            form.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Form_Repo_MergeTo form = new Form_Repo_MergeTo();
            form.ShowDialog();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Form_Repo_Reset form = new Form_Repo_Reset();
            form.ShowDialog();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Form_Repo_RestoreHistory form = new Form_Repo_RestoreHistory();
            form.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FileHistory form = new FileHistory();
            form.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileHistory form = new FileHistory();
            form.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FileHistory form = new FileHistory();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Repo_Filter form = new Form_Repo_Filter();
            form.ShowDialog();
        }
         */
    }
}
