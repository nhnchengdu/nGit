using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Git.Core.Helper;
using System.IO;
using Git.Core.SourceApp;
using Git.Manager;
using System.Text.RegularExpressions;

namespace Git.UI
{
    public partial class Ignore : Form
    {
        CGitManager _objGitMgr = null;
        string _szSolutionName = null;
        List<string> _IgnoreFileList = null;
        List<string> _UntrackedFileList = null;
        string _szUntrackedFileInfo = string.Empty;
        public Ignore(string szSolutionName, CGitManager objGitMgr)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szSolutionName = szSolutionName;
            _IgnoreFileList = new List<string>() ;
            _UntrackedFileList = new List<string>();

            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(szSolutionName);
            if (szWorkingDir.Equals(string.Empty))
            {
                return;
            }

            string szFilename = szWorkingDir + ".gitignore";
            if (File.Exists(szFilename))
            {
                m_rtxContent.Text = File.ReadAllText(szFilename);
            }
            else
            {
                FileStream myFs = new FileStream(szFilename, FileMode.Create);
                StreamWriter mySw = new StreamWriter(myFs);
                mySw.Write("");
                mySw.Close();
                myFs.Close();
            }

        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            m_rtxContent.GetFirstCharIndexOfCurrentLine();
            m_rtxContent.AppendText("\n" + m_txTemplate.Text);

            bool bIsAdded = false;
            for (int i = 0; i < m_lbFilterFiles.Items.Count; i++)
            {
                if (_IgnoreFileList.Contains(m_lbFilterFiles.Items[i].ToString()))
                {
                    continue;
                }
                m_rtxContent.AppendText(Environment.NewLine + m_lbFilterFiles.Items[i].ToString());
                bIsAdded = true;
            }
            if (bIsAdded == false)
            {
                MessageBox.Show(this, "There's not any new file was selected and added into ignored file list", "Prompt");
            }
            else
            {
                m_rtxContent.ScrollToCaret();
            }

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            string szFilename = szWorkingDir + ".gitignore";
            if (File.Exists(szFilename))
            {                
                File.WriteAllText(szFilename, m_rtxContent.Text);
            }

            Refresh();
        }

        private void tbTemplate_TextChanged(object sender, EventArgs e)
        {
            if (m_txTemplate.TextLength > 0)
                m_btnAddTemplate.Enabled = true;
            else
            {
                m_btnAddTemplate.Enabled = false;
                return;
            }

            if(string.IsNullOrEmpty(_szUntrackedFileInfo))
            {
               return;
            }

            m_lbFilterFiles.Items.Clear();
            string szRegex = m_txTemplate.Text;
            szRegex=szRegex.Replace("*", ".+");
            szRegex =".*"+ szRegex +".*"+ Environment.NewLine;
            //string szRegex = "\\s{1,}\\d{1,5}){1,}*\\n";
            Regex r = new Regex(szRegex);
            MatchCollection mc = r.Matches(_szUntrackedFileInfo); 
            if (mc.Count <= 0)
                return ;

            m_lbFilterFiles.Items.Clear();
            for (int i = 0; i < mc.Count; i++)
            {
                m_lbFilterFiles.Items.Add(mc[i].Value);                               
            }  

        }

        private void m_btnDefault_Click(object sender, EventArgs e)
        {
            string[] szDefaultArray ={ @"#ignore thumbnails created by windows",
                                @"Thumbs.db",
                                @"#Ignore files build by Visual Studio",
                                @"*.obj",
                                @"*.exe",
                                @"*.pdb",
                                @"*.user",
                                @"*.aps",
                                @"*.pch",
                                @"*.vspscc",
                                @"*_i.c",
                                @"*_p.c",
                                @"*.ncb",
                                @"*.suo",
                                @"*.tlb",
                                @"*.tlh",
                                @"*.bak",
                                @"*.cache",
                                @"*.ilk",
                                @"*.log",
                                @"[Bb]in",
                                @"[Dd]ebug*/",
                                @"*.lib",
                                @"*.sbr",
                                @"obj/",
                                @"[Rr]elease*/",
                                @"_ReSharper*/",
                                @"[Tt]est[Rr]esult*"};
            for (int i = 0; i < szDefaultArray.Length; i++)
            {
                m_rtxContent.AppendText(Environment.NewLine + szDefaultArray[i]);
            }
                
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Ignore_Load(object sender, EventArgs e)
        {
            if (_objGitMgr == null)
                return;
            if (string.IsNullOrEmpty(_szSolutionName))
                return;
            Refresh();                
        }

        private void Refresh()
        {
            //get information from git
            m_clbUntrackedFiles.Items.Clear();
            _IgnoreFileList.Clear();
            _UntrackedFileList.Clear();

            string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
            string[] szResArray = _objGitMgr._objGitMgrCore.GetAllUntrackedAndIgnored(szWorkingDir);
            if (szResArray != null && szResArray.Length > 0)
            {
                _IgnoreFileList.AddRange(szResArray);
                foreach (string szItm in _IgnoreFileList)
                {
                    _szUntrackedFileInfo = _szUntrackedFileInfo + szItm + Environment.NewLine;
                }
            }
            else
            {
                return;
            }

            szResArray = _objGitMgr._objGitMgrCore.GetAllUntracked(szWorkingDir);
            if (szResArray != null && szResArray.Length > 0)
            {
                for (int i = 0; i < szResArray.Length; i++)
                {
                    if (_IgnoreFileList.Contains(szResArray[i]))
                    {
                        _IgnoreFileList.Remove(szResArray[i]);
                    }
                }
                _UntrackedFileList.AddRange(szResArray);
            }


            //set GUI
            foreach (string szItem in _UntrackedFileList)
            {
                int nIndex = m_clbUntrackedFiles.Items.Add(szItem);
                m_clbUntrackedFiles.SetItemChecked(nIndex, false);
            }   
            foreach (string szItem in _IgnoreFileList)
            {
                int nIndex = m_clbUntrackedFiles.Items.Add(szItem);
                m_clbUntrackedFiles.SetItemChecked(nIndex, true);
            }
  
        }

        private void m_btnAddFiles_Click(object sender, EventArgs e)
        {
            bool bIsAdded = false;
            for(int i=0; i<m_clbUntrackedFiles.CheckedItems.Count;i++)
            {
                if (_IgnoreFileList.Contains(m_clbUntrackedFiles.CheckedItems[i].ToString()))
                {
                    continue;
                }
                m_rtxContent.AppendText(Environment.NewLine + m_clbUntrackedFiles.CheckedItems[i].ToString());
                bIsAdded=true;
            }
            if(bIsAdded==false)
            {
                MessageBox.Show(this,"There's not any new file was selected and added into ignored file list", "Prompt");
            }
            else
            {
                m_rtxContent.ScrollToCaret();
            }
            
        }
    }
}
