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
    public partial class TestForm3 : Form
    {

        CGitManager _objGitMgr = null;
        string _szSolutionName = null;

        public TestForm3(string szSolutionName, CGitManager objGitMgr)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szSolutionName = szSolutionName;

            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            this.m_RemoteControl.InitGitEnv(szWorkingDir, _objGitMgr);
        }
        


        /*
        private void m_MenuItemAddTracking_Click(object sender, EventArgs e)
        {
            Form_Remote_AddTracking form = new Form_Remote_AddTracking();
            form.ShowDialog();
        }

        private void m_MenuItemRemoveTracking_Click(object sender, EventArgs e)
        {
            Form_Remote_RemoveTracking form = new Form_Remote_RemoveTracking();
            form.ShowDialog();
        }

        private void m_MenuItemDeleteRemoteBranch_Click(object sender, EventArgs e)
        {
            Form_Remote_DelRemoteBranch form = new Form_Remote_DelRemoteBranch();
            form.ShowDialog();
        }

        private void m_MenuItemPull_Click(object sender, EventArgs e)
        {
            Form_Remote_PullBranch form = new Form_Remote_PullBranch();
            form.ShowDialog();
        }

        private void m_MenuItemPush_Click(object sender, EventArgs e)
        {
            Form_Remote_PushlBranch form = new Form_Remote_PushlBranch();
            form.ShowDialog();
        }

        private void m_MenuItemSync_Click(object sender, EventArgs e)
        {
            Form_Remote_SynchBranch form = new Form_Remote_SynchBranch();
            form.ShowDialog();
        }

        private void m_MenuItemFetch_Click(object sender, EventArgs e)
        {
            Form_Remote_Fetch form = new Form_Remote_Fetch();
            form.ShowDialog();
        }

        private void m_MenuItemUploadBracnh_Click(object sender, EventArgs e)
        {
            Form_Remote_UpLoadBranch form = new Form_Remote_UpLoadBranch();
            form.ShowDialog();
        }

        private void m_MenuItemUploadTag_Click(object sender, EventArgs e)
        {
            Form_Remote_UploadTag form = new Form_Remote_UploadTag();
            form.ShowDialog();
        }

        private void m_MenuItemRegisterRemote_Click(object sender, EventArgs e)
        {
            Form_Remote_AddRemote form = new Form_Remote_AddRemote();
            form.ShowDialog();
        }

        private void m_MenuItemRemoveRemote_Click(object sender, EventArgs e)
        {
            Form_Remote_RemoveRemote form = new Form_Remote_RemoveRemote();
            form.ShowDialog();
        }

        private void m_MenuItemRenameRemote_Click(object sender, EventArgs e)
        {
            Form_Remote_RenameRemote form = new Form_Remote_RenameRemote();
            form.ShowDialog();
        }

        private void m_MenuItemEditRemote_Click(object sender, EventArgs e)
        {
            Form_Remote_EditRemote form = new Form_Remote_EditRemote();
            form.ShowDialog();
        }*/

    }
}
