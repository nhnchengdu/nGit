namespace Git.UI
{
    partial class FormDsicard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button m_btnDiscard;
            System.Windows.Forms.Button m_btnRevertAll;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_clbFilelist = new System.Windows.Forms.CheckedListBox();
            this.m_radioToRepositroy = new System.Windows.Forms.RadioButton();
            this.m_radioToStaged = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.m_txCurrenBranch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            m_btnDiscard = new System.Windows.Forms.Button();
            m_btnRevertAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnDiscard
            // 
            m_btnDiscard.Location = new System.Drawing.Point(365, 216);
            m_btnDiscard.Name = "m_btnDiscard";
            m_btnDiscard.Size = new System.Drawing.Size(90, 24);
            m_btnDiscard.TabIndex = 2;
            m_btnDiscard.Text = "Restore";
            m_btnDiscard.UseVisualStyleBackColor = true;
            m_btnDiscard.Click += new System.EventHandler(this.m_btnDiscard_Click);
            // 
            // m_btnRevertAll
            // 
            m_btnRevertAll.Location = new System.Drawing.Point(461, 216);
            m_btnRevertAll.Name = "m_btnRevertAll";
            m_btnRevertAll.Size = new System.Drawing.Size(90, 24);
            m_btnRevertAll.TabIndex = 2;
            m_btnRevertAll.Text = "Restore All";
            m_btnRevertAll.UseVisualStyleBackColor = true;
            m_btnRevertAll.Click += new System.EventHandler(this.m_btnRevertAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_clbFilelist);
            this.groupBox1.Controls.Add(this.m_radioToRepositroy);
            this.groupBox1.Controls.Add(this.m_radioToStaged);
            this.groupBox1.Location = new System.Drawing.Point(8, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(413, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 72);
            this.label2.TabIndex = 16;
            this.label2.Text = "Checkout from local\r\nrepo,.\r\nNo effect on local\r\nrepo .\r\nNo effect no current\r\nBr" +
                "anch.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(413, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 36);
            this.label1.TabIndex = 16;
            this.label1.Text = "***Warning***\r\nThis will cause the\r\nlost of current work";
            // 
            // m_clbFilelist
            // 
            this.m_clbFilelist.FormattingEnabled = true;
            this.m_clbFilelist.Location = new System.Drawing.Point(6, 30);
            this.m_clbFilelist.Name = "m_clbFilelist";
            this.m_clbFilelist.Size = new System.Drawing.Size(405, 180);
            this.m_clbFilelist.TabIndex = 1;
            // 
            // m_radioToRepositroy
            // 
            this.m_radioToRepositroy.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_radioToRepositroy.AutoSize = true;
            this.m_radioToRepositroy.Checked = true;
            this.m_radioToRepositroy.Location = new System.Drawing.Point(8, 12);
            this.m_radioToRepositroy.Name = "m_radioToRepositroy";
            this.m_radioToRepositroy.Size = new System.Drawing.Size(143, 16);
            this.m_radioToRepositroy.TabIndex = 0;
            this.m_radioToRepositroy.TabStop = true;
            this.m_radioToRepositroy.Text = "Clean Index And Repo";
            this.m_radioToRepositroy.UseVisualStyleBackColor = true;
            this.m_radioToRepositroy.CheckedChanged += new System.EventHandler(this.m_radioToRepositroy_CheckedChanged);
            // 
            // m_radioToStaged
            // 
            this.m_radioToStaged.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_radioToStaged.AutoSize = true;
            this.m_radioToStaged.Location = new System.Drawing.Point(172, 12);
            this.m_radioToStaged.Name = "m_radioToStaged";
            this.m_radioToStaged.Size = new System.Drawing.Size(131, 16);
            this.m_radioToStaged.TabIndex = 0;
            this.m_radioToStaged.Text = "Restore From Index";
            this.m_radioToStaged.UseVisualStyleBackColor = true;
            this.m_radioToStaged.CheckedChanged += new System.EventHandler(this.m_radioToStaged_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(269, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // m_txCurrenBranch
            // 
            this.m_txCurrenBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txCurrenBranch.BackColor = System.Drawing.Color.Gainsboro;
            this.m_txCurrenBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txCurrenBranch.Enabled = false;
            this.m_txCurrenBranch.Location = new System.Drawing.Point(74, 220);
            this.m_txCurrenBranch.Multiline = true;
            this.m_txCurrenBranch.Name = "m_txCurrenBranch";
            this.m_txCurrenBranch.Size = new System.Drawing.Size(162, 17);
            this.m_txCurrenBranch.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "*Branch:";
            // 
            // FormDsicard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 248);
            this.Controls.Add(this.m_txCurrenBranch);
            this.Controls.Add(this.label8);
            this.Controls.Add(m_btnRevertAll);
            this.Controls.Add(m_btnDiscard);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDsicard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restore";
            this.Load += new System.EventHandler(this.FormDsicard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox m_clbFilelist;
        private System.Windows.Forms.RadioButton m_radioToStaged;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton m_radioToRepositroy;
        private System.Windows.Forms.TextBox m_txCurrenBranch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}