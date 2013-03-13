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
    public class CIconList : ListBox
    {
        private ImageList _myImageList;
        public ImageList ImageList
        {
            get { return _myImageList; }
            set { _myImageList = value; }
        }
        public CIconList()
        {
            // Set owner draw mode
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }
        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            CListBoxItem item;
            Rectangle bounds = e.Bounds;
            Size imageSize = Size.Empty;
            if(_myImageList!=null)
                imageSize = _myImageList.ImageSize;

            if(Items.Count<=0)
            {
                base.OnDrawItem(e);
                return;
            }
            
            try
            {
                item = (CListBoxItem)Items[e.Index];
                if (item.ImageIndex != -1)
                {
                    ImageList.Draw(e.Graphics, bounds.Left, bounds.Top, item.ImageIndex);
                    e.Graphics.DrawString(item.Text, e.Font, new SolidBrush(e.ForeColor),
                    bounds.Left + imageSize.Width, bounds.Top);
                }
                else
                {
                    e.Graphics.DrawString(item.Text, e.Font, new SolidBrush(e.ForeColor), bounds.Left,
                    bounds.Top);
                }
            }
            catch
            {
                if (e.Index != -1)
                {
                    e.Graphics.DrawString(Items[e.Index].ToString(), e.Font,
                    new SolidBrush(e.ForeColor), bounds.Left, bounds.Top);
                }
                else
                {
                    e.Graphics.DrawString(Text, e.Font, new SolidBrush(e.ForeColor), bounds.Left,
                    bounds.Top);
                }
            }
            base.OnDrawItem(e);
        }
    }//End of GListBox class



    public class CListBoxItem
    {
        private string _myText;
        private int _myImageIndex;
        // properties
        public string Text
        {
            get { return _myText; }
            set { _myText = value; }
        }
        public int ImageIndex
        {
            get { return _myImageIndex; }
            set { _myImageIndex = value; }
        }
        //constructor
        public CListBoxItem(string text, int index)
        {
            _myText = text;
            _myImageIndex = index;
        }
        public CListBoxItem(string text) : this(text, -1) { }
        public CListBoxItem() : this("") { }
        public override string ToString()
        {
            return _myText;
        }
    }//End of GListBoxItem class
}
