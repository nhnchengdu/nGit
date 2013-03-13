using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Git.UI
{
    class CCheckComboBox: ComboBox
    {
        CheckedListBox lst = new CheckedListBox();
        TextBox _Content = new TextBox();
        public CCheckComboBox()
        {
            InitializeComponent();
        }

        private bool _IsMultiSelect = false;
        public bool m_IsMultiSelect
        {
            get { return _IsMultiSelect; }
            set
            {
                _IsMultiSelect = value;
                if (_IsMultiSelect)
                {
                    this.DrawMode = DrawMode.OwnerDrawFixed;//只有设置这个属性为OwnerDrawFixed才可能让重画起作用
                    this.IntegralHeight = false;
                    this.DoubleBuffered = true;
                    this.DroppedDown = false;
                    this.DropDownHeight = 1;
                    this.DropDownStyle = ComboBoxStyle.DropDownList;
                    lst.CheckOnClick = false;
                    lst.ItemCheck += new ItemCheckEventHandler(lst_ItemCheck);
                    this.ItemCheck += new ItemCheckEventHandler(lst_ItemCheck);
                    lst.BorderStyle = BorderStyle.Fixed3D;
                    lst.Visible = false;
                }
                else
                {
                    this.DrawMode = DrawMode.Normal;//只有设置这个属性为OwnerDrawFixed才可能让重画起作用
                    this.IntegralHeight = true;
                    this.DoubleBuffered = true;
                    this.DroppedDown = true;
                    this.DropDownHeight = 106;
                }
            }
        }

        public event ItemCheckEventHandler ItemCheck;
        Dictionary<int, string> Values = new Dictionary<int, string>();

        private void lst_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (Values.ContainsKey(e.Index))
                {
                    return;
                }
                Values.Add(e.Index, lst.Items[e.Index].ToString());
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                if (Values.ContainsKey(e.Index))
                {
                    Values.Remove(e.Index);
                }
            }      
      
             
            string szContentShown = "";
            foreach (KeyValuePair<int, string> m in Values)
            {
                szContentShown = szContentShown + m.Value + ";";
            }
            base.Text=szContentShown;
            _Content.Text = szContentShown;
            
        }

        #region override
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (m_IsMultiSelect)
            {
                this.DroppedDown = false;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (m_IsMultiSelect)
            {
                this.DroppedDown = false;
                lst.Focus();
            }
        }
        protected override void OnDropDown(EventArgs e)
        {
            if (m_IsMultiSelect)
            {
                lst.Visible = !lst.Visible;
                lst.ItemHeight = this.ItemHeight;
                lst.BorderStyle = BorderStyle.FixedSingle;
                lst.Size = new Size(this.DropDownWidth, this.ItemHeight * (this.MaxDropDownItems - 1) - (int)this.ItemHeight / 2);
                lst.Location = new Point(this.Left, this.Top + this.ItemHeight + 6);

                lst.BeginUpdate();
                lst.Items.Clear();
                for(int i=0;i< Items.Count;i++)
                {
                   string szItm= Items[i].ToString();
                   lst.Items.Add(szItm, false);
                }
                foreach (int szKey in Values.Keys)
                {
                    lst.SetItemChecked(szKey, true);
                }

                /*
                if (this.DataSource != null)
                {
                    lst.DisplayMember = this.DisplayMember;
                    lst.ValueMember = this.ValueMember;
                    lst.DataSource = this.DataSource;
                }*/
                lst.EndUpdate();
                if (!this.TopLevelControl.Controls.Contains(lst))
                {
                    this.TopLevelControl.Controls.Add(lst);
                    //lst.CreateControl();
                    lst.BringToFront();           
                }
            }
        }
        public override string Text
        {
            get
            {
                return _Content.Text;
            }
            set
            {
                base.Text = value;
                _Content.Text = value;
                if (!string.IsNullOrEmpty(value))
                {
                    string[] ResArray = value.Split(new[] { ';', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int n = 0; n < ResArray.Length; n++)
                    {
                        for (int i = 0; i < this.Items.Count; i++)
                        {

                            if (ResArray[n].Equals(Items[i].ToString()))
                            {
                                Values.Add(i, ResArray[n]);
                                break;                            
                            }
                        } 
                    }                
                }
            }
        }


        #endregion


        public void InitControl()
        {
            if ((this.TopLevelControl != null) && (!this.TopLevelControl.Controls.Contains(_Content)))
            {
                this.TopLevelControl.Controls.Add(_Content);
                _Content.BorderStyle = BorderStyle.FixedSingle;
                _Content.Multiline = true;
                _Content.Size = new Size(this.Width - 19, this.Height-3);
                _Content.Location = new Point(this.Left+1, this.Top+1);
                _Content.ForeColor = Color.Blue;
                _Content.BringToFront();
                _Content.Visible = true;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CCheckComboBox
            // 
            this.EnabledChanged += new System.EventHandler(this.CCheckComboBox_EnabledChanged);
            this.ResumeLayout(false);

        }

        private void CCheckComboBox_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == true)
                _Content.Enabled = true;
            else
                _Content.Enabled = false;
        }
    }


}
