using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Git.Manager;

namespace Git.UI
{
    public partial class FormCommit : Form
    {
        CGitManager _objGitMgr = null;
        string _szSolutionName = null;
        List<string> _FileList = null;

        public FormCommit(string szSolutionName, List<string> FileList, CGitManager objGitMgr)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szSolutionName = szSolutionName;
            _FileList = FileList;
            if (FileList == null || FileList.Count<=0)
            {
                if(_objGitMgr!=null && string.IsNullOrEmpty(szSolutionName)==false)
                {
                    _FileList = _objGitMgr._objGitMgrCore.GetAllIndexChange(szSolutionName);
                }
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            //if (_FileList == null || _FileList.Count == 0)
            //    _objGitMgr._objGitMgrCore.CommitAllStaged(m_txMessage.Text, _szSolutionName);
            //else
            //    _objGitMgr._objGitMgrCore.CommitSelectedStaged(m_txMessage.Text, _szSolutionName, _FileList);            
            //Close();

            if (m_clbFileList.Items.Count <= 0)
                return;

            _objGitMgr._objGitMgrCore.CommitAllStaged(m_txMessage.Text, _szSolutionName);

            if (_objGitMgr != null && string.IsNullOrEmpty(_szSolutionName) == false)
            {
                _FileList = _objGitMgr._objGitMgrCore.GetAllIndexChange(_szSolutionName);
            }

            m_clbFileList.Items.Clear();
            foreach (string szItme in _FileList)
            {
                int nIndex = m_clbFileList.Items.Add(szItme);
                if (nIndex >= 0)
                {
                    m_clbFileList.SetItemChecked(nIndex, true);
                }
            }
        }

        private void FormCommit_Load(object sender, EventArgs e)
        {
            m_clbFileList.Items.Clear();
            foreach (string szItme in _FileList)
            {
                int nIndex=m_clbFileList.Items.Add(szItme);
                if(nIndex>=0)
                {
                    m_clbFileList.SetItemChecked(nIndex, true);
                }
            }
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }




    }


}