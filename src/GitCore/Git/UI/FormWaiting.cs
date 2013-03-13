using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nhn.Git.Core;
using Nhn.Git.Core.Properties;

namespace Git.UI
{
    public partial class FormWaiting : Form
    {
        public FormWaiting()
        {
            InitializeComponent();
        }

        private void FormWaiting_Load(object sender, EventArgs e)
        {
            //m_WaittingPic.Image = ButtonImageList;
            m_WaittingPic.Image=((System.Drawing.Image)(Resources.waiting));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
