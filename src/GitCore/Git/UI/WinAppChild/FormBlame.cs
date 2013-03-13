using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Git.Core.Helper;
using Git.Manager;
using Git.Core.Commands;

namespace Git.UI
{
    public partial class FormBlame : Form
    {
        private string _szFile=null;
        private string _szSHA=null;
        CGitManager _objGitMgr = null;
        string _szSolutionName = null;
        public Dictionary<int, string> _mapBlameInfo;

        public FormBlame(String szTargetFile, string szCommitSHA, string szSolutionName, CGitManager objGitMgr)
        {
            InitializeComponent();
            _szFile = szTargetFile;
            _szSHA = szCommitSHA;
            _objGitMgr = objGitMgr;
            _szSolutionName = szSolutionName;
            _mapBlameInfo = new Dictionary<int, string>();
            
        }

        private void FormBlame_Load(object sender, EventArgs e)
        {
            m_rtxContent.m_mOtherRichTextBox = m_rtxHistory;
            try
            {
                string szWorkingDir = CHelpFuntions.GetValidWorkingDir(_szSolutionName);
                string szRes=_objGitMgr._objGitMgrCore.GetBlameDetails(_szFile, _szSHA, szWorkingDir);
                if (!string.IsNullOrEmpty(szRes))
                {
                    m_rtxContent.Clear();
                    m_rtxHistory.Clear();
                    m_rtxContent.AppendText(szRes);
                    //m_rtxHistory.AppendText(szRes);
                    //2025922c (scmyytfz 2012-05-30 10:38:59 +0800 1) fasdfasdfa     

                    string[] ResArray = szRes.Split(new[] { '\r', '\n', '\0'}, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < ResArray.Length; i++)
                    {
                        string szLine = ResArray[i];
                        if(false==string.IsNullOrEmpty(szLine))
                        {
                            szLine = szLine.Substring(10, szLine.Length - 10);
                            szLine = szLine.Substring(0, szLine.IndexOf(" "));
                            m_rtxHistory.AppendText(szLine + Environment.NewLine);
                            _mapBlameInfo.Add(i, ResArray[i]);
                        }

                    }
                    m_rtxContent.ScrollToCaret();
                    m_rtxHistory.ScrollToCaret();
                   
                }
                else
                {
                    m_rtxContent.Clear();
                    m_rtxHistory.Clear();
                    m_rtxContent.AppendText(@"THis file can't be contract...");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           
        }

        private void m_rtxContent_VScroll(object sender, EventArgs e)
        {
           // m_rtxContent.VScroll


        }

        private void m_rtxContent_MouseClick(object sender, MouseEventArgs e)
        {
            Point pt=Point.Empty;
            pt.X = e.X;
            pt.Y = e.Y;
            int nChar = m_rtxContent.GetCharIndexFromPosition(pt);
            int nLine = m_rtxContent.GetLineFromCharIndex(nChar);
            if (_mapBlameInfo.ContainsKey(nLine))
            {
                m_txInfo.Text = _mapBlameInfo[nLine];
            }
        }
    }
}
