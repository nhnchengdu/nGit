namespace Git.UI
{
    partial class Form_Remote_PullBranch
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
            this.m_checkRebaseMode = new System.Windows.Forms.CheckBox();
            this.m_txLocalBranch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txPushURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txRemoteBranch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txRemoteName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_barOperProgress = new System.Windows.Forms.ProgressBar();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_btnStop = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
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
            this.m_ContinueRebaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_contextMenuConflict.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_checkRebaseMode
            // 
            this.m_checkRebaseMode.AutoSize = true;
            this.m_checkRebaseMode.Checked = true;
            this.m_checkRebaseMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_checkRebaseMode.Location = new System.Drawing.Point(12, 300);
            this.m_checkRebaseMode.Name = "m_checkRebaseMode";
            this.m_checkRebaseMode.Size = new System.Drawing.Size(126, 16);
            this.m_checkRebaseMode.TabIndex = 103;
            this.m_checkRebaseMode.Text = "User Rebase Model";
            this.m_checkRebaseMode.UseVisualStyleBackColor = true;
            // 
            // m_txLocalBranch
            // 
            this.m_txLocalBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txLocalBranch.Enabled = false;
            this.m_txLocalBranch.Location = new System.Drawing.Point(12, 17);
            this.m_txLocalBranch.Name = "m_txLocalBranch";
            this.m_txLocalBranch.Size = new System.Drawing.Size(469, 21);
            this.m_txLocalBranch.TabIndex = 110;
            this.m_txLocalBranch.Text = "master";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 114;
            this.label9.Text = "Local Branch:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.m_txPushURL);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.m_txRemoteBranch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_txRemoteName);
            this.groupBox2.Location = new System.Drawing.Point(4, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 92);
            this.groupBox2.TabIndex = 113;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 113;
            this.label3.Text = "Target Remote URL";
            // 
            // m_txPushURL
            // 
            this.m_txPushURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txPushURL.Enabled = false;
            this.m_txPushURL.Location = new System.Drawing.Point(7, 62);
            this.m_txPushURL.Name = "m_txPushURL";
            this.m_txPushURL.Size = new System.Drawing.Size(469, 21);
            this.m_txPushURL.TabIndex = 114;
            this.m_txPushURL.Text = "git://xxxxxxxxxxxxxxxx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 111;
            this.label2.Text = "Target Remote Branch";
            // 
            // m_txRemoteBranch
            // 
            this.m_txRemoteBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txRemoteBranch.Enabled = false;
            this.m_txRemoteBranch.Location = new System.Drawing.Point(191, 24);
            this.m_txRemoteBranch.Multiline = true;
            this.m_txRemoteBranch.Name = "m_txRemoteBranch";
            this.m_txRemoteBranch.Size = new System.Drawing.Size(286, 21);
            this.m_txRemoteBranch.TabIndex = 112;
            this.m_txRemoteBranch.Text = "New Remote";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 111;
            this.label1.Text = "Target Remote Repository";
            // 
            // m_txRemoteName
            // 
            this.m_txRemoteName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txRemoteName.Enabled = false;
            this.m_txRemoteName.Location = new System.Drawing.Point(7, 24);
            this.m_txRemoteName.Multiline = true;
            this.m_txRemoteName.Name = "m_txRemoteName";
            this.m_txRemoteName.Size = new System.Drawing.Size(162, 21);
            this.m_txRemoteName.TabIndex = 112;
            this.m_txRemoteName.Text = "New Remote";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 107;
            this.label8.Text = "Message:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 108;
            this.label7.Text = "Data:";
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Location = new System.Drawing.Point(43, 90);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(222, 14);
            this.textBox7.TabIndex = 111;
            this.textBox7.Text = "2012-04-05";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 106;
            this.label6.Text = "Author:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_barOperProgress);
            this.groupBox1.Controls.Add(this.m_txOperRes);
            this.groupBox1.Location = new System.Drawing.Point(4, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 167);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation Result";
            // 
            // m_barOperProgress
            // 
            this.m_barOperProgress.Location = new System.Drawing.Point(8, 149);
            this.m_barOperProgress.Name = "m_barOperProgress";
            this.m_barOperProgress.Size = new System.Drawing.Size(506, 10);
            this.m_barOperProgress.TabIndex = 117;
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(7, 17);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(507, 132);
            this.m_txOperRes.TabIndex = 116;
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(286, 298);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 115;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // m_btnStop
            // 
            this.m_btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnStop.Location = new System.Drawing.Point(367, 298);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(75, 25);
            this.m_btnStop.TabIndex = 116;
            this.m_btnStop.Text = "Stop";
            this.m_btnStop.UseVisualStyleBackColor = true;
            this.m_btnStop.Click += new System.EventHandler(this.m_btnStop_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(450, 298);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 117;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_lvConflict
            // 
            this.m_lvConflict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lvConflict.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.m_lvConflict.ContextMenuStrip = this.m_contextMenuConflict;
            this.m_lvConflict.FullRowSelect = true;
            this.m_lvConflict.GridLines = true;
            this.m_lvConflict.Location = new System.Drawing.Point(7, 325);
            this.m_lvConflict.MultiSelect = false;
            this.m_lvConflict.Name = "m_lvConflict";
            this.m_lvConflict.Size = new System.Drawing.Size(517, 134);
            this.m_lvConflict.TabIndex = 118;
            this.m_lvConflict.UseCompatibleStateImageBehavior = false;
            this.m_lvConflict.View = System.Windows.Forms.View.Details;
            this.m_lvConflict.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_lvConflict_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Conflict Type";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "FileName";
            this.columnHeader2.Width = 252;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Information";
            this.columnHeader3.Width = 94;
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
            this.m_CommitResolveMenuItem,
            this.m_ContinueRebaseMenuItem});
            this.m_contextMenuConflict.Name = "contextMenuStrip1";
            this.m_contextMenuConflict.Size = new System.Drawing.Size(216, 170);
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
            this.m_CommitResolveMenuItem.Text = "Commit Resolve";
            this.m_CommitResolveMenuItem.Click += new System.EventHandler(this.m_CommitResolveMenuItem_Click);
            // 
            // m_ContinueRebaseMenuItem
            // 
            this.m_ContinueRebaseMenuItem.Name = "m_ContinueRebaseMenuItem";
            this.m_ContinueRebaseMenuItem.Size = new System.Drawing.Size(215, 22);
            this.m_ContinueRebaseMenuItem.Text = "Rebase Continue";
            this.m_ContinueRebaseMenuItem.Click += new System.EventHandler(this.m_ContinueRebaseMenuItem_Click);
            // 
            // Form_Remote_PullBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 462);
            this.Controls.Add(this.m_lvConflict);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_txLocalBranch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_checkRebaseMode);
            this.Name = "Form_Remote_PullBranch";
            this.Text = "Pull Branch";
            this.Load += new System.EventHandler(this.Form_Remote_PullBranch_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_contextMenuConflict.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox m_checkRebaseMode;
        private System.Windows.Forms.TextBox m_txLocalBranch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txPushURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txRemoteBranch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txRemoteName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar m_barOperProgress;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.Button m_btnStop;
        private System.Windows.Forms.Button m_btnCancel;
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
        private System.Windows.Forms.ToolStripMenuItem m_ContinueRebaseMenuItem;
    }
}