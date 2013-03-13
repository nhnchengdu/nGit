namespace Git.UI
{
    partial class FormConflict
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConflict));
            this.m_txLocalBranch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_ExportFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_UseMineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_UseTheirMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_cobRemoteRepoLists = new System.Windows.Forms.ComboBox();
            this.m_cobRemoteBranchLists = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_picShowTracking = new System.Windows.Forms.PictureBox();
            this.m_UseCurrentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_contextMenuConflict.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picShowTracking)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txLocalBranch
            // 
            this.m_txLocalBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txLocalBranch.Enabled = false;
            this.m_txLocalBranch.Location = new System.Drawing.Point(144, 13);
            this.m_txLocalBranch.Name = "m_txLocalBranch";
            this.m_txLocalBranch.Size = new System.Drawing.Size(128, 21);
            this.m_txLocalBranch.TabIndex = 110;
            this.m_txLocalBranch.Text = "master";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 12);
            this.label9.TabIndex = 114;
            this.label9.Text = "Current Local Branch:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 111;
            this.label2.Text = "Tracking Remote Branch:";
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancel.Location = new System.Drawing.Point(426, 324);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 117;
            this.m_btnCancel.Text = "Exit";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
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
            this.m_lvConflict.Location = new System.Drawing.Point(6, 81);
            this.m_lvConflict.MultiSelect = false;
            this.m_lvConflict.Name = "m_lvConflict";
            this.m_lvConflict.Size = new System.Drawing.Size(517, 237);
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
            this.m_ContinueRebaseMenuItem,
            this.toolStripSeparator3,
            this.m_ExportFilesMenuItem,
            this.toolStripSeparator4,
            this.m_UseMineMenuItem,
            this.m_UseTheirMenuItem,
            this.m_UseCurrentMenuItem});
            this.m_contextMenuConflict.Name = "contextMenuStrip1";
            this.m_contextMenuConflict.Size = new System.Drawing.Size(244, 270);
            this.m_contextMenuConflict.Opening += new System.ComponentModel.CancelEventHandler(this.m_contextMenuConflict_Opening);
            // 
            // m_ManualResolveMenuItem
            // 
            this.m_ManualResolveMenuItem.Name = "m_ManualResolveMenuItem";
            this.m_ManualResolveMenuItem.Size = new System.Drawing.Size(243, 22);
            this.m_ManualResolveMenuItem.Text = "Manual Resolve Conflict";
            this.m_ManualResolveMenuItem.Click += new System.EventHandler(this.m_ManualResolveMenuItem_Click);
            // 
            // m_MergeToolMenuItem
            // 
            this.m_MergeToolMenuItem.Name = "m_MergeToolMenuItem";
            this.m_MergeToolMenuItem.Size = new System.Drawing.Size(243, 22);
            this.m_MergeToolMenuItem.Text = "3-Way Reslove Conflict";
            this.m_MergeToolMenuItem.Click += new System.EventHandler(this.m_MergeToolMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(240, 6);
            // 
            // m_RmConflictMenuItem
            // 
            this.m_RmConflictMenuItem.Name = "m_RmConflictMenuItem";
            this.m_RmConflictMenuItem.Size = new System.Drawing.Size(243, 22);
            this.m_RmConflictMenuItem.Text = "Remove File";
            this.m_RmConflictMenuItem.Click += new System.EventHandler(this.m_RmConflictMenuItem_Click);
            // 
            // m_AddConflictMenuItem
            // 
            this.m_AddConflictMenuItem.Name = "m_AddConflictMenuItem";
            this.m_AddConflictMenuItem.Size = new System.Drawing.Size(243, 22);
            this.m_AddConflictMenuItem.Text = "Add file";
            this.m_AddConflictMenuItem.Click += new System.EventHandler(this.m_AddConflictMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(240, 6);
            // 
            // m_CommitResolveMenuItem
            // 
            this.m_CommitResolveMenuItem.Name = "m_CommitResolveMenuItem";
            this.m_CommitResolveMenuItem.Size = new System.Drawing.Size(243, 22);
            this.m_CommitResolveMenuItem.Text = "Commit Resolve";
            this.m_CommitResolveMenuItem.Click += new System.EventHandler(this.m_CommitResolveMenuItem_Click);
            // 
            // m_ContinueRebaseMenuItem
            // 
            this.m_ContinueRebaseMenuItem.Name = "m_ContinueRebaseMenuItem";
            this.m_ContinueRebaseMenuItem.Size = new System.Drawing.Size(243, 22);
            this.m_ContinueRebaseMenuItem.Text = "Rebase Continue";
            this.m_ContinueRebaseMenuItem.Click += new System.EventHandler(this.m_ContinueRebaseMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(240, 6);
            // 
            // m_ExportFilesMenuItem
            // 
            this.m_ExportFilesMenuItem.Name = "m_ExportFilesMenuItem";
            this.m_ExportFilesMenuItem.Size = new System.Drawing.Size(243, 22);
            this.m_ExportFilesMenuItem.Text = "Export Conflict files";
            this.m_ExportFilesMenuItem.Click += new System.EventHandler(this.m_ExportFilesMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(240, 6);
            // 
            // m_UseMineMenuItem
            // 
            this.m_UseMineMenuItem.Name = "m_UseMineMenuItem";
            this.m_UseMineMenuItem.Size = new System.Drawing.Size(243, 22);
            this.m_UseMineMenuItem.Text = "Use Mine to Solve Conflict";
            this.m_UseMineMenuItem.Click += new System.EventHandler(this.m_UseMineMenuItem_Click);
            // 
            // m_UseTheirMenuItem
            // 
            this.m_UseTheirMenuItem.Name = "m_UseTheirMenuItem";
            this.m_UseTheirMenuItem.Size = new System.Drawing.Size(243, 22);
            this.m_UseTheirMenuItem.Text = "Use Theirs to Solve Conflict";
            this.m_UseTheirMenuItem.Click += new System.EventHandler(this.m_UseTheirMenuItem_Click);
            // 
            // m_cobRemoteRepoLists
            // 
            this.m_cobRemoteRepoLists.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_cobRemoteRepoLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobRemoteRepoLists.Enabled = false;
            this.m_cobRemoteRepoLists.FormattingEnabled = true;
            this.m_cobRemoteRepoLists.Location = new System.Drawing.Point(144, 41);
            this.m_cobRemoteRepoLists.Name = "m_cobRemoteRepoLists";
            this.m_cobRemoteRepoLists.Size = new System.Drawing.Size(128, 20);
            this.m_cobRemoteRepoLists.TabIndex = 119;
            // 
            // m_cobRemoteBranchLists
            // 
            this.m_cobRemoteBranchLists.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_cobRemoteBranchLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobRemoteBranchLists.Enabled = false;
            this.m_cobRemoteBranchLists.FormattingEnabled = true;
            this.m_cobRemoteBranchLists.Location = new System.Drawing.Point(277, 41);
            this.m_cobRemoteBranchLists.Name = "m_cobRemoteBranchLists";
            this.m_cobRemoteBranchLists.Size = new System.Drawing.Size(201, 20);
            this.m_cobRemoteBranchLists.TabIndex = 119;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_picShowTracking);
            this.groupBox2.Controls.Add(this.m_cobRemoteBranchLists);
            this.groupBox2.Controls.Add(this.m_cobRemoteRepoLists);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.m_txLocalBranch);
            this.groupBox2.Location = new System.Drawing.Point(4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(519, 72);
            this.groupBox2.TabIndex = 120;
            this.groupBox2.TabStop = false;
            // 
            // m_picShowTracking
            // 
            this.m_picShowTracking.Image = ((System.Drawing.Image)(resources.GetObject("m_picShowTracking.Image")));
            this.m_picShowTracking.InitialImage = ((System.Drawing.Image)(resources.GetObject("m_picShowTracking.InitialImage")));
            this.m_picShowTracking.Location = new System.Drawing.Point(484, 41);
            this.m_picShowTracking.Name = "m_picShowTracking";
            this.m_picShowTracking.Size = new System.Drawing.Size(30, 19);
            this.m_picShowTracking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picShowTracking.TabIndex = 120;
            this.m_picShowTracking.TabStop = false;
            this.m_picShowTracking.Visible = false;
            // 
            // m_UseCurrentMenuItem
            // 
            this.m_UseCurrentMenuItem.Name = "m_UseCurrentMenuItem";
            this.m_UseCurrentMenuItem.Size = new System.Drawing.Size(243, 22);
            this.m_UseCurrentMenuItem.Text = "Use Current to Solve Conflict";
            this.m_UseCurrentMenuItem.Click += new System.EventHandler(this.m_UseCurrentMenuItem_Click);
            // 
            // FormConflict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 352);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_lvConflict);
            this.Controls.Add(this.m_btnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConflict";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resolve Conflicts";
            this.Load += new System.EventHandler(this.FormConflictl_Load);
            this.m_contextMenuConflict.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picShowTracking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox m_txLocalBranch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.ComboBox m_cobRemoteRepoLists;
        private System.Windows.Forms.ComboBox m_cobRemoteBranchLists;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox m_picShowTracking;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem m_ExportFilesMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem m_UseMineMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_UseTheirMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_UseCurrentMenuItem;
    }
}