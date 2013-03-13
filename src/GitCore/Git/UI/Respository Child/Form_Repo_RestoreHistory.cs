using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Git.UI
{
    public partial class Form_Repo_RestoreHistory : Form
    {

        private CRepositoryControl m_Parent;
        private string _szTargetBranch;
        private string _szWorkingdir;
        private bool _bIsRestore;

        public Form_Repo_RestoreHistory(CRepositoryControl Parent)
        {
            InitializeComponent();
            m_Parent = Parent as CRepositoryControl;
            _szTargetBranch = string.Empty;
            _szWorkingdir = m_Parent.m_szWorkingDir;
            _bIsRestore = false;      
        }

        private void Form_Repo_RestoreHistory_Load(object sender, EventArgs e)
        {
            m_txCurrenBranch.Text = m_Parent.m_oGitRepository.m_CurentBranch;
            m_cobBranchLists.Items.Clear();

            foreach (string szBranch in m_Parent.m_oGitRepository.m_mapLocalBranch.Keys)
            {
                if (string.IsNullOrEmpty(szBranch))
                    continue;
                m_cobBranchLists.Items.Add(szBranch);
            }

            if (m_cobBranchLists.Items.Count > 0)
            {
                m_cobBranchLists.Text = m_txCurrenBranch.Text;
            }
        }

        private void m_cobBranchLists_TextChanged(object sender, EventArgs e)
        {
            m_lvReflog.Items.Clear();
            if (m_Parent.m_oGitRepository.m_mapLocalBranch.ContainsKey(m_cobBranchLists.Text))
            {
                string[] szResArray = m_Parent.m_objGitMgr._objGitMgrCore.GetReflogList(m_cobBranchLists.Text, _szWorkingdir);
                if (szResArray == null || szResArray.Length <= 0)
                {
                    return;
                }

                for(int i=0;i<szResArray.Length;i++)
                {
                    string szItme = szResArray[i];
                    string[] temArray = szItme.Split(new[] { '\t', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if(temArray.Length>=4)
                    {

                        ListViewItem item = new ListViewItem(temArray[0], 0);
                        item.Tag = temArray[0];
                        if ((i % 2) == 1)
                            item.BackColor = Color.AliceBlue;
                        else
                            item.BackColor = Color.AntiqueWhite;

                        item.SubItems.Add(temArray[1]);
                        item.SubItems.Add(temArray[2]);
                        string szTmp = temArray[3];
                        for (int n = 4; n < temArray.Length;n++ )
                        {
                            szTmp = szTmp + " " + temArray[n];
                        }
                        item.SubItems.Add(szTmp);
                        m_lvReflog.Items.Add(item);
                    }
                }
            }

        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsRestore)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void m_btnRun_Click(object sender, EventArgs e)
        {
            if (m_lvReflog.SelectedItems.Count<=0)
            {
                MessageBox.Show(this, "Please select a commit which you will restore ", "Warning");
                return;
            }
            m_txOperRes.Clear();
            
            if(false==m_cobBranchLists.Text.Equals(m_txCurrenBranch.Text))
            {
                string szPrompt = string.Format("Current branch will be switch to <{0}>, will you continue?", m_cobBranchLists.Text);
                var result = MessageBox.Show(this, szPrompt, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string szTmpRes = m_Parent.m_objGitMgr._objGitMgrCore.SwitchBranchTo(m_cobBranchLists.Text, _szWorkingdir);
                    if (szTmpRes.StartsWith(@"Failed"))
                    {
                        MessageBox.Show(this, "Operation failed when switching branch. ", "Warning");
                        return;
                    }
                    m_txCurrenBranch.Text = m_cobBranchLists.Text;
                }
                else
                {
                    return;
                }
            }

            string szTargetSHA = m_lvReflog.SelectedItems[0].Tag.ToString();
            string szRes = string.Empty;
            if (m_rdbAll.Checked == true)
            {
                szRes = m_Parent.m_objGitMgr._objGitMgrCore.Reset2SpecCommit(szTargetSHA, 0, _szWorkingdir);
            }
            else if (m_rdbHead.Checked == true)
            {
                szRes = m_Parent.m_objGitMgr._objGitMgrCore.Reset2SpecCommit(szTargetSHA, 2, _szWorkingdir);
            }
            else if (m_rdbIndAndHead.Checked == true)
            {
                szRes = m_Parent.m_objGitMgr._objGitMgrCore.Reset2SpecCommit(szTargetSHA, 1, _szWorkingdir);
            }
            if (szRes.StartsWith(@"Successful"))
            {
                _bIsRestore = true;
            }

            if (szRes.StartsWith(@"Successful"))
            {
                m_txOperRes.ForeColor = Color.Green;
            }
            else if (szRes.StartsWith(@"Failed"))
            {
                m_txOperRes.ForeColor = Color.Red;
            }
            m_txOperRes.Text = szRes;   

        }

    }
}
