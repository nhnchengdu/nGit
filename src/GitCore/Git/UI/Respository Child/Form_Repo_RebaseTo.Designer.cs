namespace Git.UI
{
    partial class Form_Repo_RebaseTo
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txSrcSHA = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cobSrcBranchLists = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txSrcMsg = new System.Windows.Forms.TextBox();
            this.m_txSrcAuthor = new System.Windows.Forms.TextBox();
            this.m_txSrcDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lvConflict = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_contextMenuConflict = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_ManualResolveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MergeToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_RmConflictMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_AddConflictMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_CommitResolveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.m_cobBranchLists = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txSelectedSHA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txMsg = new System.Windows.Forms.TextBox();
            this.m_txAuthor = new System.Windows.Forms.TextBox();
            this.m_txDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.m_contextMenuConflict.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 63;
            this.label1.Text = "Message:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 63;
            this.label6.Text = "Data:";
            // 
            // m_txSrcSHA
            // 
            this.m_txSrcSHA.AcceptsTab = true;
            this.m_txSrcSHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSrcSHA.Enabled = false;
            this.m_txSrcSHA.Location = new System.Drawing.Point(33, 15);
            this.m_txSrcSHA.Multiline = true;
            this.m_txSrcSHA.Name = "m_txSrcSHA";
            this.m_txSrcSHA.Size = new System.Drawing.Size(261, 16);
            this.m_txSrcSHA.TabIndex = 64;
            this.m_txSrcSHA.Text = "00000000000000000000000000000000000";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_cobSrcBranchLists);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.m_txSrcSHA);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.m_txSrcMsg);
            this.groupBox2.Controls.Add(this.m_txSrcAuthor);
            this.groupBox2.Controls.Add(this.m_txSrcDate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(10, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 151);
            this.groupBox2.TabIndex = 113;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "From";
            // 
            // m_cobSrcBranchLists
            // 
            this.m_cobSrcBranchLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobSrcBranchLists.FormattingEnabled = true;
            this.m_cobSrcBranchLists.Items.AddRange(new object[] {
            "Master",
            "New Branch -1"});
            this.m_cobSrcBranchLists.Location = new System.Drawing.Point(101, 122);
            this.m_cobSrcBranchLists.Name = "m_cobSrcBranchLists";
            this.m_cobSrcBranchLists.Size = new System.Drawing.Size(193, 20);
            this.m_cobSrcBranchLists.TabIndex = 67;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 63;
            this.label10.Text = "Related Branch";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 61;
            this.label7.Text = "Author:";
            // 
            // m_txSrcMsg
            // 
            this.m_txSrcMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSrcMsg.Enabled = false;
            this.m_txSrcMsg.Location = new System.Drawing.Point(59, 79);
            this.m_txSrcMsg.Multiline = true;
            this.m_txSrcMsg.Name = "m_txSrcMsg";
            this.m_txSrcMsg.Size = new System.Drawing.Size(235, 37);
            this.m_txSrcMsg.TabIndex = 63;
            // 
            // m_txSrcAuthor
            // 
            this.m_txSrcAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSrcAuthor.Enabled = false;
            this.m_txSrcAuthor.Location = new System.Drawing.Point(54, 36);
            this.m_txSrcAuthor.Multiline = true;
            this.m_txSrcAuthor.Name = "m_txSrcAuthor";
            this.m_txSrcAuthor.Size = new System.Drawing.Size(240, 16);
            this.m_txSrcAuthor.TabIndex = 66;
            // 
            // m_txSrcDate
            // 
            this.m_txSrcDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSrcDate.Enabled = false;
            this.m_txSrcDate.Location = new System.Drawing.Point(45, 57);
            this.m_txSrcDate.Multiline = true;
            this.m_txSrcDate.Name = "m_txSrcDate";
            this.m_txSrcDate.Size = new System.Drawing.Size(249, 16);
            this.m_txSrcDate.TabIndex = 65;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 62;
            this.label8.Text = "SHA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 63;
            this.label2.Text = "Related Branch";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 63;
            this.label4.Text = "Data:";
            // 
            // m_lvConflict
            // 
            this.m_lvConflict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lvConflict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lvConflict.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.m_lvConflict.ContextMenuStrip = this.m_contextMenuConflict;
            this.m_lvConflict.FullRowSelect = true;
            this.m_lvConflict.GridLines = true;
            this.m_lvConflict.Location = new System.Drawing.Point(10, 265);
            this.m_lvConflict.MultiSelect = false;
            this.m_lvConflict.Name = "m_lvConflict";
            this.m_lvConflict.Size = new System.Drawing.Size(606, 124);
            this.m_lvConflict.TabIndex = 109;
            this.m_lvConflict.UseCompatibleStateImageBehavior = false;
            this.m_lvConflict.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Conflict Type";
            this.columnHeader1.Width = 121;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "FileName";
            this.columnHeader2.Width = 315;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Information";
            this.columnHeader3.Width = 105;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            // 
            // m_contextMenuConflict
            // 
            this.m_contextMenuConflict.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ManualResolveMenuItem,
            this.m_MergeToolMenuItem,
            this.toolStripSeparator1,
            this.m_RmConflictMenuItem,
            this.m_AddConflictMenuItem,
            this.toolStripSeparator2,
            this.m_CommitResolveMenuItem});
            this.m_contextMenuConflict.Name = "contextMenuStrip1";
            this.m_contextMenuConflict.Size = new System.Drawing.Size(216, 126);
            this.m_contextMenuConflict.Opening += new System.ComponentModel.CancelEventHandler(this.m_contextMenuConflict_Opening);
            // 
            // m_ManualResolveMenuItem
            // 
            this.m_ManualResolveMenuItem.Name = "m_ManualResolveMenuItem";
            this.m_ManualResolveMenuItem.Size = new System.Drawing.Size(215, 22);
            this.m_ManualResolveMenuItem.Text = "Manual Resolve Conflict";
            this.m_ManualResolveMenuItem.Click += new System.EventHandler(this.m_ManualResolveMenuItem_Click);
            // 
            // m_MergeToolMenuItem
            // 
            this.m_MergeToolMenuItem.Name = "m_MergeToolMenuItem";
            this.m_MergeToolMenuItem.Size = new System.Drawing.Size(215, 22);
            this.m_MergeToolMenuItem.Text = "3-Way Reslove Conflict";
            this.m_MergeToolMenuItem.Click += new System.EventHandler(this.m_MergeToolMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // m_RmConflictMenuItem
            // 
            this.m_RmConflictMenuItem.Name = "m_RmConflictMenuItem";
            this.m_RmConflictMenuItem.Size = new System.Drawing.Size(215, 22);
            this.m_RmConflictMenuItem.Text = "Remove File";
            this.m_RmConflictMenuItem.Click += new System.EventHandler(this.m_RmConflictMenuItem_Click);
            // 
            // m_AddConflictMenuItem
            // 
            this.m_AddConflictMenuItem.Name = "m_AddConflictMenuItem";
            this.m_AddConflictMenuItem.Size = new System.Drawing.Size(215, 22);
            this.m_AddConflictMenuItem.Text = "Add file";
            this.m_AddConflictMenuItem.Click += new System.EventHandler(this.m_AddConflictMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // m_CommitResolveMenuItem
            // 
            this.m_CommitResolveMenuItem.Name = "m_CommitResolveMenuItem";
            this.m_CommitResolveMenuItem.Size = new System.Drawing.Size(215, 22);
            this.m_CommitResolveMenuItem.Text = "Rebase Continue";
            this.m_CommitResolveMenuItem.Click += new System.EventHandler(this.m_CommitResolveMenuItem_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 114;
            this.label9.Text = "Operation Resutl";
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(10, 175);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(517, 84);
            this.m_txOperRes.TabIndex = 115;
            // 
            // m_cobBranchLists
            // 
            this.m_cobBranchLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobBranchLists.FormattingEnabled = true;
            this.m_cobBranchLists.Items.AddRange(new object[] {
            "Master",
            "New Branch -1"});
            this.m_cobBranchLists.Location = new System.Drawing.Point(101, 122);
            this.m_cobBranchLists.Name = "m_cobBranchLists";
            this.m_cobBranchLists.Size = new System.Drawing.Size(193, 20);
            this.m_cobBranchLists.TabIndex = 67;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cobBranchLists);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_txSelectedSHA);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_txMsg);
            this.groupBox1.Controls.Add(this.m_txAuthor);
            this.groupBox1.Controls.Add(this.m_txDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(316, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 151);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "To";
            // 
            // m_txSelectedSHA
            // 
            this.m_txSelectedSHA.AcceptsTab = true;
            this.m_txSelectedSHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSelectedSHA.Enabled = false;
            this.m_txSelectedSHA.Location = new System.Drawing.Point(33, 15);
            this.m_txSelectedSHA.Multiline = true;
            this.m_txSelectedSHA.Name = "m_txSelectedSHA";
            this.m_txSelectedSHA.Size = new System.Drawing.Size(261, 16);
            this.m_txSelectedSHA.TabIndex = 64;
            this.m_txSelectedSHA.Text = "00000000000000000000000000000000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 61;
            this.label3.Text = "Author:";
            // 
            // m_txMsg
            // 
            this.m_txMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txMsg.Enabled = false;
            this.m_txMsg.Location = new System.Drawing.Point(59, 79);
            this.m_txMsg.Multiline = true;
            this.m_txMsg.Name = "m_txMsg";
            this.m_txMsg.Size = new System.Drawing.Size(235, 37);
            this.m_txMsg.TabIndex = 63;
            // 
            // m_txAuthor
            // 
            this.m_txAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txAuthor.Enabled = false;
            this.m_txAuthor.Location = new System.Drawing.Point(54, 36);
            this.m_txAuthor.Multiline = true;
            this.m_txAuthor.Name = "m_txAuthor";
            this.m_txAuthor.Size = new System.Drawing.Size(240, 16);
            this.m_txAuthor.TabIndex = 66;
            // 
            // m_txDate
            // 
            this.m_txDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txDate.Enabled = false;
            this.m_txDate.Location = new System.Drawing.Point(45, 57);
            this.m_txDate.Multiline = true;
            this.m_txDate.Name = "m_txDate";
            this.m_txDate.Size = new System.Drawing.Size(249, 16);
            this.m_txDate.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 62;
            this.label5.Text = "SHA:";
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnRun.Location = new System.Drawing.Point(533, 188);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 110;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancel.Location = new System.Drawing.Point(533, 224);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 111;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // Form_Repo_RebaseTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 393);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_lvConflict);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.m_btnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Repo_RebaseTo";
            this.Text = "Rebase To";
            this.Load += new System.EventHandler(this.Form_Repo_RebaseTo_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.m_contextMenuConflict.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox m_txSrcSHA;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox m_cobSrcBranchLists;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_txSrcMsg;
        private System.Windows.Forms.TextBox m_txSrcAuthor;
        private System.Windows.Forms.TextBox m_txSrcDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView m_lvConflict;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip m_contextMenuConflict;
        private System.Windows.Forms.ToolStripMenuItem m_ManualResolveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_MergeToolMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_RmConflictMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_AddConflictMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem m_CommitResolveMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.ComboBox m_cobBranchLists;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox m_txSelectedSHA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txMsg;
        private System.Windows.Forms.TextBox m_txAuthor;
        private System.Windows.Forms.TextBox m_txDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.Button m_btnCancel;
    }
}