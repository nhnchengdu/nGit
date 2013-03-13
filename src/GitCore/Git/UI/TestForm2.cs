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
    public partial class TestForm2 : Form
    {
        CGitManager _objGitMgr = null;
        string _szSolutionName = null;
        public TestForm2(string szSolutionName, CGitManager objGitMgr)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szSolutionName = szSolutionName;

            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            this.m_LocalControl.InitGitEnv(szWorkingDir, _objGitMgr);
        }

    }
}
