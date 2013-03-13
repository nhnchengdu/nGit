using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Git.UI
{


    public class CCommitsListView:ListView
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref int value, int ignore);

        public enum OperationTyPe
        {
            UNKNOWN = 0,
            MERGE,
            REBASE,
            COMPARE
        };

        private OperationTyPe _emOprType;
        private string _szSourceSHA;
        private string _szSourceFile;
        private string _szTargetSHA;
        private string _szTargetFile;
        public ListViewItem m_itmPreveHover;
        private int _nOldSelectedValue = -1;

        private ListViewItem _itmSourceOper;
        private Color _itmSourceColor;

        public CCommitsListView()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            int value = 2;
            SystemParametersInfo(0x67, value, ref value, 0);
            ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.m_lvCommitsInfo_ItemMouseHover);
            MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_lvCommitsInfo_MouseClick);

            _emOprType =OperationTyPe.UNKNOWN;
            _szSourceSHA = string.Empty;
            _szTargetSHA = string.Empty;
            _szSourceFile = string.Empty;
            _szTargetFile = string.Empty;
            m_itmPreveHover = new ListViewItem();
        }

        public OperationTyPe m_emOprType
        {
            get { return _emOprType; }
            set 
            {
                _emOprType = value; 
                if(_emOprType==OperationTyPe.UNKNOWN)
                {
                    _szSourceSHA = string.Empty;
                    _szTargetSHA = string.Empty;
                    _szSourceFile = string.Empty;
                    _szTargetFile = string.Empty;

                    this.Cursor=System.Windows.Forms.Cursors.Arrow;
                    ContextMenuStrip.Enabled = true;

                    if (_itmSourceOper != null)
                    {
                        _itmSourceOper.BackColor = _itmSourceColor;
                        _itmSourceOper = null;
                    }

                }
                else
                {
                    this.Cursor = System.Windows.Forms.Cursors.NoMove2D;
                    ContextMenuStrip.Enabled = false;
                    if (m_itmPreveHover != null)
                    {
                        _itmSourceOper = m_itmPreveHover;
                        _itmSourceColor = _itmSourceOper.BackColor;
                        _itmSourceOper.BackColor = Color.LightGreen;
                    }
                    


                }
            }
        }

        public string m_szSourceSHA
        {
            get { return _szSourceSHA; }
            set
            {
                _szSourceSHA = value;
            }
        }

        public string m_szTargetSHA
        {
            get { return _szTargetSHA; }
            set
            {
                _szTargetSHA = value;
            }
        }

        public string m_szSourceFile
        {
            get { return _szSourceFile; }
            set
            {
                _szSourceFile = value;
            }
        }

        public string m_szTargetFile
        {
            get { return _szTargetFile; }
            set
            {
                _szTargetFile = value;
            }
        }
        public int m_nOldSelectedValue
        {
            get { return _nOldSelectedValue; }
            set
            {
                _nOldSelectedValue = value;
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                m_emOprType = OperationTyPe.UNKNOWN;
            }
            base.OnKeyDown(e);
        }

        private void m_lvCommitsInfo_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            e.Item.ForeColor = Color.BlueViolet;
            m_itmPreveHover.ForeColor = Color.Black;
            m_itmPreveHover = e.Item;
        }

        private void m_lvCommitsInfo_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem CurItem=this.GetItemAt(e.X, e.Y);
            if (CurItem != null)
                CurItem.Focused = true;
        }
    }
}
