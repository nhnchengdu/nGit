namespace Git.UI
{
    partial class Ignore
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
            this.m_rtxContent = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_clbUntrackedFiles = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnAddFiles = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_btnAddTemplate = new System.Windows.Forms.Button();
            this.m_lbFilterFiles = new System.Windows.Forms.ListBox();
            this.m_txTemplate = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnDefault = new System.Windows.Forms.Button();
            this.m_btnApply = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_rtxContent
            // 
            this.m_rtxContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_rtxContent.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.m_rtxContent.ForeColor = System.Drawing.Color.Navy;
            this.m_rtxContent.Location = new System.Drawing.Point(2, 2);
            this.m_rtxContent.Name = "m_rtxContent";
            this.m_rtxContent.Size = new System.Drawing.Size(335, 484);
            this.m_rtxContent.TabIndex = 1;
            this.m_rtxContent.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(343, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(306, 444);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_clbUntrackedFiles);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.m_btnAddFiles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(298, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Files";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // m_clbUntrackedFiles
            // 
            this.m_clbUntrackedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_clbUntrackedFiles.FormattingEnabled = true;
            this.m_clbUntrackedFiles.Location = new System.Drawing.Point(5, 31);
            this.m_clbUntrackedFiles.Name = "m_clbUntrackedFiles";
            this.m_clbUntrackedFiles.Size = new System.Drawing.Size(286, 372);
            this.m_clbUntrackedFiles.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose ignore files";
            // 
            // m_btnAddFiles
            // 
            this.m_btnAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnAddFiles.Location = new System.Drawing.Point(222, 6);
            this.m_btnAddFiles.Name = "m_btnAddFiles";
            this.m_btnAddFiles.Size = new System.Drawing.Size(70, 21);
            this.m_btnAddFiles.TabIndex = 3;
            this.m_btnAddFiles.Text = "Add";
            this.m_btnAddFiles.UseVisualStyleBackColor = true;
            this.m_btnAddFiles.Click += new System.EventHandler(this.m_btnAddFiles_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_btnAddTemplate);
            this.tabPage2.Controls.Add(this.m_lbFilterFiles);
            this.tabPage2.Controls.Add(this.m_txTemplate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(298, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Template";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // m_btnAddTemplate
            // 
            this.m_btnAddTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnAddTemplate.Enabled = false;
            this.m_btnAddTemplate.Location = new System.Drawing.Point(225, 11);
            this.m_btnAddTemplate.Name = "m_btnAddTemplate";
            this.m_btnAddTemplate.Size = new System.Drawing.Size(70, 21);
            this.m_btnAddTemplate.TabIndex = 2;
            this.m_btnAddTemplate.Text = "Add";
            this.m_btnAddTemplate.UseVisualStyleBackColor = true;
            this.m_btnAddTemplate.Click += new System.EventHandler(this.btnAddTemplate_Click);
            // 
            // m_lbFilterFiles
            // 
            this.m_lbFilterFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lbFilterFiles.FormattingEnabled = true;
            this.m_lbFilterFiles.ItemHeight = 12;
            this.m_lbFilterFiles.Location = new System.Drawing.Point(8, 43);
            this.m_lbFilterFiles.Name = "m_lbFilterFiles";
            this.m_lbFilterFiles.Size = new System.Drawing.Size(284, 364);
            this.m_lbFilterFiles.TabIndex = 1;
            // 
            // m_txTemplate
            // 
            this.m_txTemplate.Location = new System.Drawing.Point(8, 12);
            this.m_txTemplate.Name = "m_txTemplate";
            this.m_txTemplate.Size = new System.Drawing.Size(211, 21);
            this.m_txTemplate.TabIndex = 0;
            this.m_txTemplate.TextChanged += new System.EventHandler(this.tbTemplate_TextChanged);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancel.Location = new System.Drawing.Point(355, 452);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(87, 34);
            this.m_btnCancel.TabIndex = 3;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnDefault
            // 
            this.m_btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnDefault.Location = new System.Drawing.Point(458, 452);
            this.m_btnDefault.Name = "m_btnDefault";
            this.m_btnDefault.Size = new System.Drawing.Size(87, 34);
            this.m_btnDefault.TabIndex = 3;
            this.m_btnDefault.Text = "Default";
            this.m_btnDefault.UseVisualStyleBackColor = true;
            this.m_btnDefault.Click += new System.EventHandler(this.m_btnDefault_Click);
            // 
            // m_btnApply
            // 
            this.m_btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnApply.AutoEllipsis = true;
            this.m_btnApply.Location = new System.Drawing.Point(558, 452);
            this.m_btnApply.Name = "m_btnApply";
            this.m_btnApply.Size = new System.Drawing.Size(87, 34);
            this.m_btnApply.TabIndex = 3;
            this.m_btnApply.Text = "Apply";
            this.m_btnApply.UseVisualStyleBackColor = true;
            this.m_btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // Ignore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 492);
            this.Controls.Add(this.m_btnApply);
            this.Controls.Add(this.m_btnDefault);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.m_rtxContent);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ignore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ignore Setting";
            this.Load += new System.EventHandler(this.Ignore_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox m_rtxContent;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button m_btnAddTemplate;
        private System.Windows.Forms.ListBox m_lbFilterFiles;
        private System.Windows.Forms.TextBox m_txTemplate;
        private System.Windows.Forms.CheckedListBox m_clbUntrackedFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_btnAddFiles;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnDefault;
        private System.Windows.Forms.Button m_btnApply;
    }
}