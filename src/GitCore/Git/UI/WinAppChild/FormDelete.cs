using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Git.Manager;
using Git.Core.Commands;
using System.Windows; 
namespace Git.UI
{
    public partial class FormDelete : Form
    {
        CGitManager _objGitMgr = null;
        string _szSolutionName = null;
        Hashtable _hashAllFiles = null;
        List<string> _lstAllFiles = null;

        public FormDelete(string szSolutionName, List<string> FileList, CGitManager objGitMgr)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szSolutionName = szSolutionName;
            _lstAllFiles = FileList;
            _hashAllFiles = new Hashtable();
            foreach (string szItem in FileList)
            {        
                
                FileSccStatus status = _objGitMgr.GetFileStatus(szItem);
                if (status == FileSccStatus.ST_NOT_CONTROLLED||status == FileSccStatus.ST_IGNORED)
                {
                    _hashAllFiles.Add(szItem, "Untracked");
                }
                else if (status == FileSccStatus.ST_RENMAE||status == FileSccStatus.ST_CONFLICT)
                {
                    _hashAllFiles.Add(szItem, "Unkonown");    //this satus need to decide later      --by fengzheng
                }
                else if (status == FileSccStatus.ST_DELETE||status == FileSccStatus.ST_NULL)
                {
                    continue;
                }
                else
                {
                   _hashAllFiles.Add(szItem, "Tracked");
                }
            }
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            List<string> SelTrackedFileList = GetSelecteTrackeddFiles("Tracked");
            List<string> SelTrackedUnFileList = GetSelecteTrackeddFiles("Untracked");
            if ((SelTrackedFileList.Count == 0 && SelTrackedUnFileList.Count == 0)||_szSolutionName.Equals(string.Empty))
            {
                return;
            }

            try
            {
                //delete untracked files
                if (SelTrackedUnFileList.Count > 0)
                {
                    if (this.m_radioDeleteWorkingTree.Checked == true)
                    {
                        DeleteLocalFiles(SelTrackedFileList);
                    }
                    
                }

                //delete tracked files
                if (SelTrackedFileList.Count > 0)
                {
                    if (this.m_radioDeleteWorkingTree.Checked == true)
                    {
                        _objGitMgr._objGitMgrCore.Delete(_szSolutionName, SelTrackedFileList, false);
                    }
                    else
                    {
                        _objGitMgr._objGitMgrCore.Delete(_szSolutionName, SelTrackedFileList, true);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();

        }


        //Get selected item from checklist,code need to be modified later       --by fengzheng
        private List<string> GetSelecteTrackeddFiles(string szType)
        {
            List<string> FileList = new List<string>();

            foreach (DictionaryEntry item in _hashAllFiles)
            {
                if (item.Value.Equals(szType))
                {
                    FileList.Add(item.Key as string);
                }
            }
            return FileList;
        }
        
        //use win API to delete local files
        private void DeleteLocalFiles(List<string> FileList)
        {
            foreach (string szItem in FileList)
            {
                File.Delete(szItem);
            }    
        
        }

        private void FormDelete_Load(object sender, EventArgs e)
        {
            m_clbFilelist.Items.Clear();
            foreach (string szItme in _lstAllFiles)
            {
                int nIndex = m_clbFilelist.Items.Add(szItme);
                if (nIndex >= 0)
                {
                    m_clbFilelist.SetItemChecked(nIndex, true);
                }
            }
        }
    }
}
