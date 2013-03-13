using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Git.UI
{
    public partial class Form_Repo_CherryPickTo : Form
    {

        private CRepositoryControl m_Pareent;
        public Form_Repo_CherryPickTo(CRepositoryControl Pareent)
        {
            InitializeComponent();
            m_Pareent = Pareent as CRepositoryControl;
           
        }
    }
}
