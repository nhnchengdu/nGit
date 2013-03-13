namespace Git.UI
{
    partial class CLocalOperCotrol
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_rtxworkingChange = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_rtxIndexChange = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_clbStashList = new System.Windows.Forms.CheckedListBox();
            this.m_contextMenuStash = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_MIM_SaveProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_RestoreProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_Restore2NewBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_RemoveProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_ClearProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.m_lbStagedFile = new System.Windows.Forms.CheckedListBox();
            this.m_contextMenuStaged = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_MIM_Commit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_Discard = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.m_lbUnstagFile = new System.Windows.Forms.CheckedListBox();
            this.m_contextMenuUnstaged = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_MIM_AddToAttract = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_AddAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_Ignore = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txCurrenBranch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_btnCurrentRepository = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_contextMenuStash.SuspendLayout();
            this.m_contextMenuStaged.SuspendLayout();
            this.m_contextMenuUnstaged.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(6, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Progress List";
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 17);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_rtxworkingChange);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_rtxIndexChange);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(428, 513);
            this.splitContainer1.SplitterDistance = 243;
            this.splitContainer1.TabIndex = 6;
            // 
            // m_rtxworkingChange
            // 
            this.m_rtxworkingChange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rtxworkingChange.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.m_rtxworkingChange.ForeColor = System.Drawing.Color.MediumBlue;
            this.m_rtxworkingChange.Location = new System.Drawing.Point(0, 14);
            this.m_rtxworkingChange.Name = "m_rtxworkingChange";
            this.m_rtxworkingChange.Size = new System.Drawing.Size(428, 226);
            this.m_rtxworkingChange.TabIndex = 1;
            this.m_rtxworkingChange.Text = "selected file content";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Local Change";
            // 
            // m_rtxIndexChange
            // 
            this.m_rtxIndexChange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rtxIndexChange.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.m_rtxIndexChange.Location = new System.Drawing.Point(3, 17);
            this.m_rtxIndexChange.Name = "m_rtxIndexChange";
            this.m_rtxIndexChange.Size = new System.Drawing.Size(422, 246);
            this.m_rtxIndexChange.TabIndex = 1;
            this.m_rtxIndexChange.Text = "File change contentntent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Index Change";
            // 
            // m_clbStashList
            // 
            this.m_clbStashList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_clbStashList.ContextMenuStrip = this.m_contextMenuStash;
            this.m_clbStashList.FormattingEnabled = true;
            this.m_clbStashList.Location = new System.Drawing.Point(6, 224);
            this.m_clbStashList.Name = "m_clbStashList";
            this.m_clbStashList.Size = new System.Drawing.Size(442, 116);
            this.m_clbStashList.TabIndex = 66;
            // 
            // m_contextMenuStash
            // 
            this.m_contextMenuStash.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MIM_SaveProgress,
            this.m_MIM_RestoreProgress,
            this.m_MIM_Restore2NewBranch,
            this.toolStripSeparator1,
            this.m_MIM_RemoveProgress,
            this.m_MIM_ClearProgress});
            this.m_contextMenuStash.Name = "m_contextMenuStash";
            this.m_contextMenuStash.Size = new System.Drawing.Size(236, 120);
            // 
            // m_MIM_SaveProgress
            // 
            this.m_MIM_SaveProgress.Name = "m_MIM_SaveProgress";
            this.m_MIM_SaveProgress.Size = new System.Drawing.Size(235, 22);
            this.m_MIM_SaveProgress.Text = "Save current progress..";
            this.m_MIM_SaveProgress.Click += new System.EventHandler(this.m_MIM_SaveProgress_Click);
            // 
            // m_MIM_RestoreProgress
            // 
            this.m_MIM_RestoreProgress.Name = "m_MIM_RestoreProgress";
            this.m_MIM_RestoreProgress.Size = new System.Drawing.Size(235, 22);
            this.m_MIM_RestoreProgress.Text = "Restore to current branch...";
            this.m_MIM_RestoreProgress.Click += new System.EventHandler(this.m_MIM_RestoreProgress_Click);
            // 
            // m_MIM_Restore2NewBranch
            // 
            this.m_MIM_Restore2NewBranch.Name = "m_MIM_Restore2NewBranch";
            this.m_MIM_Restore2NewBranch.Size = new System.Drawing.Size(235, 22);
            this.m_MIM_Restore2NewBranch.Text = "Restore to new branch...";
            this.m_MIM_Restore2NewBranch.Click += new System.EventHandler(this.m_MIM_Restore2NewBranch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // m_MIM_RemoveProgress
            // 
            this.m_MIM_RemoveProgress.Name = "m_MIM_RemoveProgress";
            this.m_MIM_RemoveProgress.Size = new System.Drawing.Size(235, 22);
            this.m_MIM_RemoveProgress.Text = "Remove progress";
            this.m_MIM_RemoveProgress.Click += new System.EventHandler(this.m_MIM_RemoveProgress_Click);
            // 
            // m_MIM_ClearProgress
            // 
            this.m_MIM_ClearProgress.Name = "m_MIM_ClearProgress";
            this.m_MIM_ClearProgress.Size = new System.Drawing.Size(235, 22);
            this.m_MIM_ClearProgress.Text = "Clear all progress";
            this.m_MIM_ClearProgress.Click += new System.EventHandler(this.m_MIM_ClearProgress_Click);
            // 
            // m_lbStagedFile
            // 
            this.m_lbStagedFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lbStagedFile.ContextMenuStrip = this.m_contextMenuStaged;
            this.m_lbStagedFile.FormattingEnabled = true;
            this.m_lbStagedFile.HorizontalScrollbar = true;
            this.m_lbStagedFile.Items.AddRange(new object[] {
            "File 1",
            "File 2"});
            this.m_lbStagedFile.Location = new System.Drawing.Point(6, 365);
            this.m_lbStagedFile.Name = "m_lbStagedFile";
            this.m_lbStagedFile.Size = new System.Drawing.Size(442, 164);
            this.m_lbStagedFile.TabIndex = 0;
            this.m_lbStagedFile.SelectedIndexChanged += new System.EventHandler(this.m_lbStagedFile_SelectedIndexChanged);
            // 
            // m_contextMenuStaged
            // 
            this.m_contextMenuStaged.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MIM_Commit,
            this.m_MIM_Discard,
            this.m_MIM_Remove});
            this.m_contextMenuStaged.Name = "m_contextMenuStaged";
            this.m_contextMenuStaged.Size = new System.Drawing.Size(174, 92);
            this.m_contextMenuStaged.Text = "Commit";
            this.m_contextMenuStaged.Opening += new System.ComponentModel.CancelEventHandler(this.m_contextMenuStaged_Opening);
            // 
            // m_MIM_Commit
            // 
            this.m_MIM_Commit.Name = "m_MIM_Commit";
            this.m_MIM_Commit.Size = new System.Drawing.Size(173, 22);
            this.m_MIM_Commit.Text = "Commit All";
            this.m_MIM_Commit.Click += new System.EventHandler(this.m_MIM_Commit_Click);
            // 
            // m_MIM_Discard
            // 
            this.m_MIM_Discard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_MIM_Discard.Name = "m_MIM_Discard";
            this.m_MIM_Discard.Size = new System.Drawing.Size(173, 22);
            this.m_MIM_Discard.Text = "Discard Selected";
            this.m_MIM_Discard.Click += new System.EventHandler(this.m_MIM_Discard_Click);
            // 
            // m_MIM_Remove
            // 
            this.m_MIM_Remove.Name = "m_MIM_Remove";
            this.m_MIM_Remove.Size = new System.Drawing.Size(173, 22);
            this.m_MIM_Remove.Text = "Discard All";
            this.m_MIM_Remove.Click += new System.EventHandler(this.m_MIM_Remove_Click);
            // 
            // m_lbUnstagFile
            // 
            this.m_lbUnstagFile.ContextMenuStrip = this.m_contextMenuUnstaged;
            this.m_lbUnstagFile.FormattingEnabled = true;
            this.m_lbUnstagFile.HorizontalScrollbar = true;
            this.m_lbUnstagFile.Items.AddRange(new object[] {
            "File 1",
            "File 2"});
            this.m_lbUnstagFile.Location = new System.Drawing.Point(6, 33);
            this.m_lbUnstagFile.Name = "m_lbUnstagFile";
            this.m_lbUnstagFile.Size = new System.Drawing.Size(442, 164);
            this.m_lbUnstagFile.TabIndex = 0;
            this.m_lbUnstagFile.SelectedIndexChanged += new System.EventHandler(this.m_lbUnstagFile_SelectedIndexChanged);
            // 
            // m_contextMenuUnstaged
            // 
            this.m_contextMenuUnstaged.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MIM_AddToAttract,
            this.m_MIM_AddAll,
            this.toolStripSeparator2,
            this.m_MIM_Ignore});
            this.m_contextMenuUnstaged.Name = "m_contextMenuUnstaged";
            this.m_contextMenuUnstaged.Size = new System.Drawing.Size(119, 76);
            this.m_contextMenuUnstaged.Opening += new System.ComponentModel.CancelEventHandler(this.m_contextMenuUnstaged_Opening);
            // 
            // m_MIM_AddToAttract
            // 
            this.m_MIM_AddToAttract.Name = "m_MIM_AddToAttract";
            this.m_MIM_AddToAttract.Size = new System.Drawing.Size(152, 22);
            this.m_MIM_AddToAttract.Text = "Add";
            this.m_MIM_AddToAttract.Click += new System.EventHandler(this.m_MIM_AddToAttract_Click);
            // 
            // m_MIM_AddAll
            // 
            this.m_MIM_AddAll.Name = "m_MIM_AddAll";
            this.m_MIM_AddAll.Size = new System.Drawing.Size(152, 22);
            this.m_MIM_AddAll.Text = "Add All";
            this.m_MIM_AddAll.Click += new System.EventHandler(this.m_MIM_AddAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // m_MIM_Ignore
            // 
            this.m_MIM_Ignore.Name = "m_MIM_Ignore";
            this.m_MIM_Ignore.Size = new System.Drawing.Size(152, 22);
            this.m_MIM_Ignore.Text = "Ignore";
            this.m_MIM_Ignore.Click += new System.EventHandler(this.m_MIM_Ignore_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(6, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "Wait Committing";
            this.label6.UseMnemonic = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Wait Adding";
            // 
            // m_txCurrenBranch
            // 
            this.m_txCurrenBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txCurrenBranch.BackColor = System.Drawing.Color.Gainsboro;
            this.m_txCurrenBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txCurrenBranch.Enabled = false;
            this.m_txCurrenBranch.Location = new System.Drawing.Point(740, 11);
            this.m_txCurrenBranch.Multiline = true;
            this.m_txCurrenBranch.Name = "m_txCurrenBranch";
            this.m_txCurrenBranch.Size = new System.Drawing.Size(162, 17);
            this.m_txCurrenBranch.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(681, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "*Branch:";
            // 
            // m_btnCurrentRepository
            // 
            this.m_btnCurrentRepository.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCurrentRepository.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnCurrentRepository.Location = new System.Drawing.Point(294, 10);
            this.m_btnCurrentRepository.Name = "m_btnCurrentRepository";
            this.m_btnCurrentRepository.Size = new System.Drawing.Size(336, 21);
            this.m_btnCurrentRepository.TabIndex = 91;
            this.m_btnCurrentRepository.Text = "Current Repository";
            this.m_btnCurrentRepository.UseVisualStyleBackColor = true;
            this.m_btnCurrentRepository.Click += new System.EventHandler(this.m_btnCurrentRepository_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.m_clbStashList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_lbStagedFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_lbUnstagFile);
            this.groupBox1.Location = new System.Drawing.Point(5, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 537);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Location = new System.Drawing.Point(467, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 538);
            this.groupBox2.TabIndex = 93;
            this.groupBox2.TabStop = false;
            // 
            // CLocalOperCotrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_btnCurrentRepository);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_txCurrenBranch);
            this.Controls.Add(this.label8);
            this.Name = "CLocalOperCotrol";
            this.Size = new System.Drawing.Size(910, 576);
            this.Load += new System.EventHandler(this.CLocalOperCotrol_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.m_contextMenuStash.ResumeLayout(false);
            this.m_contextMenuStaged.ResumeLayout(false);
            this.m_contextMenuUnstaged.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox m_rtxworkingChange;
        private System.Windows.Forms.CheckedListBox m_lbUnstagFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox m_lbStagedFile;
        private System.Windows.Forms.ContextMenuStrip m_contextMenuStash;
        private System.Windows.Forms.ContextMenuStrip m_contextMenuStaged;
        private System.Windows.Forms.ContextMenuStrip m_contextMenuUnstaged;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_SaveProgress;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_RestoreProgress;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_Restore2NewBranch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_RemoveProgress;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_ClearProgress;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_AddToAttract;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_Ignore;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_Commit;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_Discard;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_Remove;
        private System.Windows.Forms.TextBox m_txCurrenBranch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox m_rtxIndexChange;
        private System.Windows.Forms.CheckedListBox m_clbStashList;
        private System.Windows.Forms.Button m_btnCurrentRepository;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_AddAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;


    }
}
