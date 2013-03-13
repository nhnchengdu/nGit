using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Git.UI
{
    public partial class Form_Repo_Filter : Form
    {
        private CRepositoryControl m_Pareent;
        public Form_Repo_Filter(CRepositoryControl Pareent)
        {
            InitializeComponent();
            m_Pareent = Pareent as CRepositoryControl;
           
        }

        private void Form_Repo_Filter_Load(object sender, EventArgs e)
        {
            m_cobBranchList.m_IsMultiSelect=true;
            m_cobBranchList.InitControl();
            foreach (string szKey in m_Pareent.m_oGitRepository.m_mapLocalBranch.Keys)
            {
                m_cobBranchList.Items.Add(szKey);
            }
            foreach (string szKey in m_Pareent.m_oGitRepository.m_mapRemoteBranch.Keys)
            {
                m_cobBranchList.Items.Add(szKey);
            }


            //whether change the Struct type into Class, I'm not assure  --by Tom
            if(m_Pareent.m_oShowContent.bIsSetFilter==false)
            {
                m_checkAuthor.Checked = false;
                m_checkBr.Checked = false;
                m_checkDate.Checked = false;
                m_checkMsg.Checked = false;
                m_cobBranchList.Enabled = false;
                m_txAuthor.Text = null;
                m_txAuthor.Enabled = false;
                m_txMessage.Enabled = false;
                m_dateEnd.Enabled = false;
                m_dateStart.Enabled = false;
                
            }
            else
            {           
                if(string.IsNullOrEmpty(m_Pareent.m_oShowContent.szBranch))
                {
                    m_checkBr.Checked = false;
                     m_cobBranchList.Enabled = false;
                    m_cobBranchList.Text=null;
                }
                else
                {
                    m_checkBr.Checked = true;
                    m_cobBranchList.Enabled = true;
                    m_cobBranchList.Text = m_Pareent.m_oShowContent.szBranch;
                }


                if (string.IsNullOrEmpty(m_Pareent.m_oShowContent.szAuthor))
                {
                    m_checkAuthor.Checked = false;
                    m_txAuthor.Text = null;
                }
                else
                {
                    m_checkAuthor.Checked = true;
                    m_txAuthor.Text = m_Pareent.m_oShowContent.szAuthor;
                }


                if (string.IsNullOrEmpty(m_Pareent.m_oShowContent.szMSg))
                {
                    m_checkMsg.Checked = false;
                    m_txMessage.Text = null;
                }
                else
                {
                    m_checkMsg.Checked = true;
                    m_txMessage.Text = m_Pareent.m_oShowContent.szMSg;
                }


                if (string.IsNullOrEmpty(m_Pareent.m_oShowContent.szDdateStart)
                        || string.IsNullOrEmpty(m_Pareent.m_oShowContent.szDdateEnd))
                {
                    m_checkDate.Checked = false;
                }
                else
                {
                    m_checkDate.Checked = true;
                    m_txMessage.Text = m_Pareent.m_oShowContent.szMSg;
                    m_dateStart.Value=Convert.ToDateTime(m_Pareent.m_oShowContent.szDdateStart);
                    m_dateEnd.Value = Convert.ToDateTime(m_Pareent.m_oShowContent.szDdateEnd);
                }
            }

        }
        private void m_checkBr_CheckedChanged(object sender, EventArgs e)
        {
            if(m_checkBr.Checked==true)
                m_cobBranchList.Enabled=true;
            else
                m_cobBranchList.Enabled=false;
        }

        private void m_checkMsg_CheckedChanged(object sender, EventArgs e)
        {
            if (m_checkMsg.Checked == true)
                m_txMessage.Enabled = true;
            else
                m_txMessage.Enabled = false;
        }

        private void m_checAuthor_CheckedChanged(object sender, EventArgs e)
        {
            if (m_checkAuthor.Checked == true)
                m_txAuthor.Enabled = true;
            else
                m_txAuthor.Enabled = false;
        }

        private void m_checDate_CheckedChanged(object sender, EventArgs e)
        {
            if (m_checkDate.Checked == true)
            {
                m_dateEnd.Enabled = true;
                m_dateStart.Enabled = true;
            }
            else
            {
                m_dateEnd.Enabled = false;
                m_dateStart.Enabled = false;
            }
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {           
            //string sz=m_dateEnd.Value.ToLongDateString();
            //string sy = m_dateEnd.Value.ToLongTimeString();
            //string st = m_dateEnd.Value.ToShortDateString();
            //string sj = m_dateEnd.Value.ToShortTimeString();
            //string sf = m_dateEnd.Value.ToString();
            m_Pareent.m_oShowContent.bIsSetFilter=false;            
            if(m_checkBr.Checked ==true&&!(string.IsNullOrEmpty(m_cobBranchList.Text)))
            {
                m_Pareent.m_oShowContent.bIsSetFilter=true;
                m_Pareent.m_oShowContent.szBranch=m_cobBranchList.Text;            
            }
            else
            {
                m_Pareent.m_oShowContent.szBranch = null;
            }

            if(m_checkAuthor.Checked ==true&&!(string.IsNullOrEmpty(m_txAuthor.Text)))
            {
                m_Pareent.m_oShowContent.bIsSetFilter=true;
                m_Pareent.m_oShowContent.szAuthor=m_txAuthor.Text;            
            }
            else
            {
                m_Pareent.m_oShowContent.szAuthor = null;
            }

            if (m_checkMsg.Checked == true && !(string.IsNullOrEmpty(m_txMessage.Text)))
            {
                m_Pareent.m_oShowContent.bIsSetFilter = true;
                m_Pareent.m_oShowContent.szMSg = m_txMessage.Text;
            }
            else
            {
                m_Pareent.m_oShowContent.szMSg = null;
            }

            if (m_checkDate.Checked == true)
            {
                m_Pareent.m_oShowContent.bIsSetFilter = true;
                m_Pareent.m_oShowContent.szDdateStart = m_dateStart.Value.ToString("yyyy-MM-dd");
                m_Pareent.m_oShowContent.szDdateEnd = m_dateEnd.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                m_Pareent.m_oShowContent.szDdateStart = null;
                m_Pareent.m_oShowContent.szDdateEnd = null;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
