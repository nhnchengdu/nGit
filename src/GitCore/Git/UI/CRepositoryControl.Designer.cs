namespace Git.UI
{
    partial class CRepositoryControl
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
            this.m_lvCommitsInfo = new Git.UI.CCommitsListView();
            this.m_columReversion = new System.Windows.Forms.ColumnHeader();
            this.m_columnLocalBranch = new System.Windows.Forms.ColumnHeader();
            this.m_columnCommit = new System.Windows.Forms.ColumnHeader();
            this.m_columnAuthor = new System.Windows.Forms.ColumnHeader();
            this.m_columnDate = new System.Windows.Forms.ColumnHeader();
            this.m_contextMenu_Commit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_MIM_CheckOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_AddBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_RemoveBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_SwitchBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_AddTag = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_RemoveTag = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_MergeTo = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_RebaseTo = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_CherryPick = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_Revert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_ResetCommit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_RestoreHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.m_txSearch = new System.Windows.Forms.TextBox();
            this.m_btnCurrentRepository = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_rtxFileContent = new System.Windows.Forms.RichTextBox();
            this.m_MIM_FileHisotry2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_lbParentRefer = new Git.UI.CIconList();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_lbRelatedCommits = new Git.UI.CIconList();
            this.m_MIM_FileHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_ExternalCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.m_contextMenu_File = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_rtxChangeContent = new System.Windows.Forms.RichTextBox();
            this.m_lvChangeFiles = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_tabInfo = new System.Windows.Forms.TabControl();
            this.m_pageMessage = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txLogMessage = new System.Windows.Forms.TextBox();
            this.m_txDate = new System.Windows.Forms.TextBox();
            this.m_txSelectedSHA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txAuthor = new System.Windows.Forms.TextBox();
            this.m_pageTree = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_tvFileTree = new Git.UI.CSystemTreeView();
            this.m_contextMenu_Tree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_MIM_ExportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tabFileHistoy = new System.Windows.Forms.TabPage();
            this.m_rtxHistoryLog = new System.Windows.Forms.RichTextBox();
            this.m_lvHistoryCommitInfo = new Git.UI.CCommitsListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_contextMenu_History = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_MIM_HistoryGrep = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_HistorySaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_HistoryCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tvHistoryFileTree = new Git.UI.CSystemTreeView();
            this.m_btnFilter = new System.Windows.Forms.Button();
            this.m_txCurrenBranch = new System.Windows.Forms.TextBox();
            this.m_btnSearch = new System.Windows.Forms.Button();
            this.m_btnSwitchBr = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_contextMenu_Commit.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.m_contextMenu_File.SuspendLayout();
            this.m_tabInfo.SuspendLayout();
            this.m_pageMessage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_pageTree.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_contextMenu_Tree.SuspendLayout();
            this.m_tabFileHistoy.SuspendLayout();
            this.m_contextMenu_History.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lvCommitsInfo
            // 
            this.m_lvCommitsInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_lvCommitsInfo.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.m_lvCommitsInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lvCommitsInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_columReversion,
            this.m_columnLocalBranch,
            this.m_columnCommit,
            this.m_columnAuthor,
            this.m_columnDate});
            this.m_lvCommitsInfo.ContextMenuStrip = this.m_contextMenu_Commit;
            this.m_lvCommitsInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_lvCommitsInfo.FullRowSelect = true;
            this.m_lvCommitsInfo.GridLines = true;
            this.m_lvCommitsInfo.HideSelection = false;
            this.m_lvCommitsInfo.Location = new System.Drawing.Point(11, 35);
            this.m_lvCommitsInfo.m_emOprType = Git.UI.CCommitsListView.OperationTyPe.UNKNOWN;
            this.m_lvCommitsInfo.m_nOldSelectedValue = -1;
            this.m_lvCommitsInfo.m_szSourceFile = "";
            this.m_lvCommitsInfo.m_szSourceSHA = "";
            this.m_lvCommitsInfo.m_szTargetFile = "";
            this.m_lvCommitsInfo.m_szTargetSHA = "";
            this.m_lvCommitsInfo.MultiSelect = false;
            this.m_lvCommitsInfo.Name = "m_lvCommitsInfo";
            this.m_lvCommitsInfo.ShowItemToolTips = true;
            this.m_lvCommitsInfo.Size = new System.Drawing.Size(862, 260);
            this.m_lvCommitsInfo.TabIndex = 14;
            this.m_lvCommitsInfo.UseCompatibleStateImageBehavior = false;
            this.m_lvCommitsInfo.View = System.Windows.Forms.View.Details;
            this.m_lvCommitsInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_lvCommitsInfo_MouseDoubleClick);
            this.m_lvCommitsInfo.SelectedIndexChanged += new System.EventHandler(this.m_lvCommitsInfo_SelectedIndexChanged);
            this.m_lvCommitsInfo.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvCommitsInfo_SelectedIndexChanged);
            // 
            // m_columReversion
            // 
            this.m_columReversion.Text = "Reversion";
            this.m_columReversion.Width = 217;
            // 
            // m_columnLocalBranch
            // 
            this.m_columnLocalBranch.Text = "Branch";
            this.m_columnLocalBranch.Width = 80;
            // 
            // m_columnCommit
            // 
            this.m_columnCommit.Text = "Commit";
            this.m_columnCommit.Width = 292;
            // 
            // m_columnAuthor
            // 
            this.m_columnAuthor.Text = "Author";
            this.m_columnAuthor.Width = 122;
            // 
            // m_columnDate
            // 
            this.m_columnDate.Text = "Date";
            this.m_columnDate.Width = 147;
            // 
            // m_contextMenu_Commit
            // 
            this.m_contextMenu_Commit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MIM_CheckOut,
            this.toolStripSeparator1,
            this.m_MIM_AddBranch,
            this.m_MIM_RemoveBranch,
            this.m_MIM_SwitchBranch,
            this.toolStripSeparator2,
            this.m_MIM_AddTag,
            this.m_MIM_RemoveTag,
            this.toolStripSeparator3,
            this.m_MIM_MergeTo,
            this.m_MIM_RebaseTo,
            this.m_MIM_CherryPick,
            this.m_MIM_Revert,
            this.toolStripSeparator4,
            this.m_MIM_ResetCommit,
            this.m_MIM_RestoreHistory});
            this.m_contextMenu_Commit.Name = "m_contextMenu_Commit";
            this.m_contextMenu_Commit.Size = new System.Drawing.Size(168, 292);
            this.m_contextMenu_Commit.Opened += new System.EventHandler(this.m_contextMenu_Commit_Opened);
            // 
            // m_MIM_CheckOut
            // 
            this.m_MIM_CheckOut.Name = "m_MIM_CheckOut";
            this.m_MIM_CheckOut.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_CheckOut.Text = "Check Out";
            this.m_MIM_CheckOut.Click += new System.EventHandler(this.m_MIM_CheckOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // m_MIM_AddBranch
            // 
            this.m_MIM_AddBranch.Name = "m_MIM_AddBranch";
            this.m_MIM_AddBranch.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_AddBranch.Text = "Add Branch";
            this.m_MIM_AddBranch.Click += new System.EventHandler(this.m_MIM_AddBranch_Click);
            // 
            // m_MIM_RemoveBranch
            // 
            this.m_MIM_RemoveBranch.Name = "m_MIM_RemoveBranch";
            this.m_MIM_RemoveBranch.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_RemoveBranch.Text = "Remove Branch";
            this.m_MIM_RemoveBranch.Click += new System.EventHandler(this.m_MIM_RemoveBranch_Click);
            // 
            // m_MIM_SwitchBranch
            // 
            this.m_MIM_SwitchBranch.Name = "m_MIM_SwitchBranch";
            this.m_MIM_SwitchBranch.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_SwitchBranch.Text = "Switch Branch";
            this.m_MIM_SwitchBranch.Click += new System.EventHandler(this.m_MIM_SwitchBranch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // m_MIM_AddTag
            // 
            this.m_MIM_AddTag.Name = "m_MIM_AddTag";
            this.m_MIM_AddTag.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_AddTag.Text = "Add Tag";
            this.m_MIM_AddTag.Click += new System.EventHandler(this.m_MIM_AddTag_Click);
            // 
            // m_MIM_RemoveTag
            // 
            this.m_MIM_RemoveTag.Name = "m_MIM_RemoveTag";
            this.m_MIM_RemoveTag.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_RemoveTag.Text = "Remove Tag";
            this.m_MIM_RemoveTag.Click += new System.EventHandler(this.m_MIM_RemoveTag_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // m_MIM_MergeTo
            // 
            this.m_MIM_MergeTo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.m_MIM_MergeTo.Name = "m_MIM_MergeTo";
            this.m_MIM_MergeTo.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_MergeTo.Text = "Merge to...";
            this.m_MIM_MergeTo.Click += new System.EventHandler(this.m_MIM_MergeTo_Click);
            // 
            // m_MIM_RebaseTo
            // 
            this.m_MIM_RebaseTo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.m_MIM_RebaseTo.Name = "m_MIM_RebaseTo";
            this.m_MIM_RebaseTo.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_RebaseTo.Text = "Rebase to...";
            this.m_MIM_RebaseTo.Click += new System.EventHandler(this.m_MIM_RebaseTo_Click);
            // 
            // m_MIM_CherryPick
            // 
            this.m_MIM_CherryPick.Enabled = false;
            this.m_MIM_CherryPick.Name = "m_MIM_CherryPick";
            this.m_MIM_CherryPick.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_CherryPick.Text = "Cherry Pick to...";
            this.m_MIM_CherryPick.Click += new System.EventHandler(this.m_MIM_CherryPick_Click);
            // 
            // m_MIM_Revert
            // 
            this.m_MIM_Revert.Enabled = false;
            this.m_MIM_Revert.Name = "m_MIM_Revert";
            this.m_MIM_Revert.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_Revert.Text = "Revert...";
            this.m_MIM_Revert.Click += new System.EventHandler(this.m_MIM_Revert_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(164, 6);
            // 
            // m_MIM_ResetCommit
            // 
            this.m_MIM_ResetCommit.Name = "m_MIM_ResetCommit";
            this.m_MIM_ResetCommit.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_ResetCommit.Text = "Reset Commit";
            this.m_MIM_ResetCommit.Click += new System.EventHandler(this.m_MIM_ResetCommit_Click);
            // 
            // m_MIM_RestoreHistory
            // 
            this.m_MIM_RestoreHistory.Name = "m_MIM_RestoreHistory";
            this.m_MIM_RestoreHistory.Size = new System.Drawing.Size(167, 22);
            this.m_MIM_RestoreHistory.Text = "Restore History";
            this.m_MIM_RestoreHistory.Click += new System.EventHandler(this.m_MIM_RestoreHistory_Click);
            // 
            // m_txSearch
            // 
            this.m_txSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSearch.Location = new System.Drawing.Point(723, 16);
            this.m_txSearch.Multiline = true;
            this.m_txSearch.Name = "m_txSearch";
            this.m_txSearch.Size = new System.Drawing.Size(152, 17);
            this.m_txSearch.TabIndex = 11;
            this.m_txSearch.Text = "      Search ";
            // 
            // m_btnCurrentRepository
            // 
            this.m_btnCurrentRepository.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCurrentRepository.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnCurrentRepository.Location = new System.Drawing.Point(286, 12);
            this.m_btnCurrentRepository.Name = "m_btnCurrentRepository";
            this.m_btnCurrentRepository.Size = new System.Drawing.Size(314, 21);
            this.m_btnCurrentRepository.TabIndex = 15;
            this.m_btnCurrentRepository.Text = "Current Repository";
            this.m_btnCurrentRepository.UseVisualStyleBackColor = true;
            this.m_btnCurrentRepository.Click += new System.EventHandler(this.m_btnCurrentRepository_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "*Branch:";
            // 
            // m_rtxFileContent
            // 
            this.m_rtxFileContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rtxFileContent.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.m_rtxFileContent.ForeColor = System.Drawing.Color.Navy;
            this.m_rtxFileContent.Location = new System.Drawing.Point(5, 8);
            this.m_rtxFileContent.Name = "m_rtxFileContent";
            this.m_rtxFileContent.Size = new System.Drawing.Size(558, 257);
            this.m_rtxFileContent.TabIndex = 0;
            this.m_rtxFileContent.Text = "Selected file content";
            // 
            // m_MIM_FileHisotry2
            // 
            this.m_MIM_FileHisotry2.Name = "m_MIM_FileHisotry2";
            this.m_MIM_FileHisotry2.Size = new System.Drawing.Size(140, 22);
            this.m_MIM_FileHisotry2.Text = "File History";
            this.m_MIM_FileHisotry2.Click += new System.EventHandler(this.m_MIM_FileHisotry2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.m_lbParentRefer);
            this.groupBox3.Location = new System.Drawing.Point(662, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 99);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Included Reference";
            // 
            // m_lbParentRefer
            // 
            this.m_lbParentRefer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lbParentRefer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.m_lbParentRefer.FormattingEnabled = true;
            this.m_lbParentRefer.ImageList = null;
            this.m_lbParentRefer.ItemHeight = 12;
            this.m_lbParentRefer.Location = new System.Drawing.Point(4, 10);
            this.m_lbParentRefer.Name = "m_lbParentRefer";
            this.m_lbParentRefer.Size = new System.Drawing.Size(186, 76);
            this.m_lbParentRefer.TabIndex = 0;
            this.m_lbParentRefer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_lbParentRefer_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lbRelatedCommits);
            this.groupBox2.Location = new System.Drawing.Point(303, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 92);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Related Commits";
            // 
            // m_lbRelatedCommits
            // 
            this.m_lbRelatedCommits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lbRelatedCommits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.m_lbRelatedCommits.FormattingEnabled = true;
            this.m_lbRelatedCommits.ImageList = null;
            this.m_lbRelatedCommits.ItemHeight = 12;
            this.m_lbRelatedCommits.Location = new System.Drawing.Point(6, 11);
            this.m_lbRelatedCommits.Name = "m_lbRelatedCommits";
            this.m_lbRelatedCommits.Size = new System.Drawing.Size(338, 76);
            this.m_lbRelatedCommits.TabIndex = 0;
            this.m_lbRelatedCommits.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_lbRelatedCommits_MouseDoubleClick);
            // 
            // m_MIM_FileHistory
            // 
            this.m_MIM_FileHistory.Name = "m_MIM_FileHistory";
            this.m_MIM_FileHistory.Size = new System.Drawing.Size(211, 22);
            this.m_MIM_FileHistory.Text = "File History";
            this.m_MIM_FileHistory.Click += new System.EventHandler(this.m_MIM_FileHistory_Click);
            // 
            // m_MIM_ExternalCompare
            // 
            this.m_MIM_ExternalCompare.Name = "m_MIM_ExternalCompare";
            this.m_MIM_ExternalCompare.Size = new System.Drawing.Size(211, 22);
            this.m_MIM_ExternalCompare.Text = "Enternal Tool Compare";
            this.m_MIM_ExternalCompare.Click += new System.EventHandler(this.m_MIM_ExternalCompare_Click);
            // 
            // m_contextMenu_File
            // 
            this.m_contextMenu_File.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MIM_ExternalCompare,
            this.m_MIM_FileHistory});
            this.m_contextMenu_File.Name = "m_contextMenu_File";
            this.m_contextMenu_File.Size = new System.Drawing.Size(212, 48);
            this.m_contextMenu_File.Opening += new System.ComponentModel.CancelEventHandler(this.m_contextMenu_File_Opening);
            // 
            // m_rtxChangeContent
            // 
            this.m_rtxChangeContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rtxChangeContent.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.m_rtxChangeContent.ForeColor = System.Drawing.Color.Navy;
            this.m_rtxChangeContent.Location = new System.Drawing.Point(3, 3);
            this.m_rtxChangeContent.Name = "m_rtxChangeContent";
            this.m_rtxChangeContent.Size = new System.Drawing.Size(546, 156);
            this.m_rtxChangeContent.TabIndex = 7;
            this.m_rtxChangeContent.Text = "show change of selected file";
            // 
            // m_lvChangeFiles
            // 
            this.m_lvChangeFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lvChangeFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.m_lvChangeFiles.ContextMenuStrip = this.m_contextMenu_File;
            this.m_lvChangeFiles.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_lvChangeFiles.FullRowSelect = true;
            this.m_lvChangeFiles.GridLines = true;
            this.m_lvChangeFiles.Location = new System.Drawing.Point(3, 3);
            this.m_lvChangeFiles.MultiSelect = false;
            this.m_lvChangeFiles.Name = "m_lvChangeFiles";
            this.m_lvChangeFiles.ShowItemToolTips = true;
            this.m_lvChangeFiles.Size = new System.Drawing.Size(287, 156);
            this.m_lvChangeFiles.TabIndex = 6;
            this.m_lvChangeFiles.UseCompatibleStateImageBehavior = false;
            this.m_lvChangeFiles.View = System.Windows.Forms.View.Details;
            this.m_lvChangeFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_lvChangeFiles_MouseDoubleClick);
            this.m_lvChangeFiles.SelectedIndexChanged += new System.EventHandler(this.m_lvChangeFiles_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Change Files";
            this.columnHeader4.Width = 283;
            // 
            // m_tabInfo
            // 
            this.m_tabInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabInfo.Controls.Add(this.m_pageMessage);
            this.m_tabInfo.Controls.Add(this.m_pageTree);
            this.m_tabInfo.Controls.Add(this.m_tabFileHistoy);
            this.m_tabInfo.Location = new System.Drawing.Point(11, 301);
            this.m_tabInfo.Name = "m_tabInfo";
            this.m_tabInfo.SelectedIndex = 0;
            this.m_tabInfo.Size = new System.Drawing.Size(868, 299);
            this.m_tabInfo.TabIndex = 13;
            // 
            // m_pageMessage
            // 
            this.m_pageMessage.Controls.Add(this.splitContainer2);
            this.m_pageMessage.Controls.Add(this.groupBox3);
            this.m_pageMessage.Controls.Add(this.groupBox2);
            this.m_pageMessage.Controls.Add(this.label5);
            this.m_pageMessage.Controls.Add(this.label4);
            this.m_pageMessage.Controls.Add(this.m_txLogMessage);
            this.m_pageMessage.Controls.Add(this.m_txDate);
            this.m_pageMessage.Controls.Add(this.m_txSelectedSHA);
            this.m_pageMessage.Controls.Add(this.label3);
            this.m_pageMessage.Controls.Add(this.label2);
            this.m_pageMessage.Controls.Add(this.groupBox1);
            this.m_pageMessage.Location = new System.Drawing.Point(4, 22);
            this.m_pageMessage.Name = "m_pageMessage";
            this.m_pageMessage.Padding = new System.Windows.Forms.Padding(3);
            this.m_pageMessage.Size = new System.Drawing.Size(860, 273);
            this.m_pageMessage.TabIndex = 0;
            this.m_pageMessage.Text = "Message";
            this.m_pageMessage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Message:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Data:";
            // 
            // m_txLogMessage
            // 
            this.m_txLogMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txLogMessage.Location = new System.Drawing.Point(67, 73);
            this.m_txLogMessage.Multiline = true;
            this.m_txLogMessage.Name = "m_txLogMessage";
            this.m_txLogMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_txLogMessage.Size = new System.Drawing.Size(221, 18);
            this.m_txLogMessage.TabIndex = 3;
            // 
            // m_txDate
            // 
            this.m_txDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txDate.Enabled = false;
            this.m_txDate.Location = new System.Drawing.Point(51, 55);
            this.m_txDate.Multiline = true;
            this.m_txDate.Name = "m_txDate";
            this.m_txDate.Size = new System.Drawing.Size(237, 16);
            this.m_txDate.TabIndex = 3;
            // 
            // m_txSelectedSHA
            // 
            this.m_txSelectedSHA.AcceptsTab = true;
            this.m_txSelectedSHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSelectedSHA.Enabled = false;
            this.m_txSelectedSHA.Location = new System.Drawing.Point(39, 19);
            this.m_txSelectedSHA.Multiline = true;
            this.m_txSelectedSHA.Name = "m_txSelectedSHA";
            this.m_txSelectedSHA.Size = new System.Drawing.Size(249, 16);
            this.m_txSelectedSHA.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Author:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "SHA:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txAuthor);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 92);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Property";
            // 
            // m_txAuthor
            // 
            this.m_txAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txAuthor.Enabled = false;
            this.m_txAuthor.Location = new System.Drawing.Point(54, 31);
            this.m_txAuthor.Multiline = true;
            this.m_txAuthor.Name = "m_txAuthor";
            this.m_txAuthor.Size = new System.Drawing.Size(228, 16);
            this.m_txAuthor.TabIndex = 3;
            // 
            // m_pageTree
            // 
            this.m_pageTree.Controls.Add(this.splitContainer1);
            this.m_pageTree.Location = new System.Drawing.Point(4, 22);
            this.m_pageTree.Name = "m_pageTree";
            this.m_pageTree.Padding = new System.Windows.Forms.Padding(3);
            this.m_pageTree.Size = new System.Drawing.Size(860, 273);
            this.m_pageTree.TabIndex = 1;
            this.m_pageTree.Text = "Tree";
            this.m_pageTree.UseVisualStyleBackColor = true;
            this.m_pageTree.Enter += new System.EventHandler(this.m_pageTree_Enter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_tvFileTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_rtxFileContent);
            this.splitContainer1.Size = new System.Drawing.Size(854, 267);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_tvFileTree
            // 
            this.m_tvFileTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tvFileTree.ContextMenuStrip = this.m_contextMenu_Tree;
            this.m_tvFileTree.ImageIndex = 0;
            this.m_tvFileTree.Location = new System.Drawing.Point(4, 6);
            this.m_tvFileTree.Name = "m_tvFileTree";
            this.m_tvFileTree.SelectedImageIndex = 0;
            this.m_tvFileTree.ShowNodeToolTips = true;
            this.m_tvFileTree.Size = new System.Drawing.Size(277, 260);
            this.m_tvFileTree.TabIndex = 0;
            this.m_tvFileTree.DoubleClick += new System.EventHandler(this.m_tvFileTree_DoubleClick);
            this.m_tvFileTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvFileTree_AfterSelect);
            // 
            // m_contextMenu_Tree
            // 
            this.m_contextMenu_Tree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MIM_ExportFile,
            this.m_MIM_FileHisotry2});
            this.m_contextMenu_Tree.Name = "m_contextMenu_Tree";
            this.m_contextMenu_Tree.Size = new System.Drawing.Size(141, 48);
            this.m_contextMenu_Tree.Opening += new System.ComponentModel.CancelEventHandler(this.m_contextMenu_Tree_Opening);
            // 
            // m_MIM_ExportFile
            // 
            this.m_MIM_ExportFile.Name = "m_MIM_ExportFile";
            this.m_MIM_ExportFile.Size = new System.Drawing.Size(140, 22);
            this.m_MIM_ExportFile.Text = "Save As";
            this.m_MIM_ExportFile.Click += new System.EventHandler(this.m_MIM_ExportFile_Click);
            // 
            // m_tabFileHistoy
            // 
            this.m_tabFileHistoy.Controls.Add(this.m_rtxHistoryLog);
            this.m_tabFileHistoy.Controls.Add(this.m_lvHistoryCommitInfo);
            this.m_tabFileHistoy.Controls.Add(this.m_tvHistoryFileTree);
            this.m_tabFileHistoy.Location = new System.Drawing.Point(4, 22);
            this.m_tabFileHistoy.Name = "m_tabFileHistoy";
            this.m_tabFileHistoy.Size = new System.Drawing.Size(860, 266);
            this.m_tabFileHistoy.TabIndex = 2;
            this.m_tabFileHistoy.Text = "File History";
            this.m_tabFileHistoy.UseVisualStyleBackColor = true;
            this.m_tabFileHistoy.Enter += new System.EventHandler(this.m_tabFileHistoy_Enter);
            // 
            // m_rtxHistoryLog
            // 
            this.m_rtxHistoryLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rtxHistoryLog.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.m_rtxHistoryLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_rtxHistoryLog.Location = new System.Drawing.Point(309, 186);
            this.m_rtxHistoryLog.Name = "m_rtxHistoryLog";
            this.m_rtxHistoryLog.Size = new System.Drawing.Size(548, 72);
            this.m_rtxHistoryLog.TabIndex = 17;
            this.m_rtxHistoryLog.Text = "";
            // 
            // m_lvHistoryCommitInfo
            // 
            this.m_lvHistoryCommitInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_lvHistoryCommitInfo.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.m_lvHistoryCommitInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lvHistoryCommitInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_lvHistoryCommitInfo.ContextMenuStrip = this.m_contextMenu_History;
            this.m_lvHistoryCommitInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_lvHistoryCommitInfo.FullRowSelect = true;
            this.m_lvHistoryCommitInfo.GridLines = true;
            this.m_lvHistoryCommitInfo.HideSelection = false;
            this.m_lvHistoryCommitInfo.Location = new System.Drawing.Point(309, 5);
            this.m_lvHistoryCommitInfo.m_emOprType = Git.UI.CCommitsListView.OperationTyPe.UNKNOWN;
            this.m_lvHistoryCommitInfo.m_nOldSelectedValue = -1;
            this.m_lvHistoryCommitInfo.m_szSourceFile = "";
            this.m_lvHistoryCommitInfo.m_szSourceSHA = "";
            this.m_lvHistoryCommitInfo.m_szTargetFile = "";
            this.m_lvHistoryCommitInfo.m_szTargetSHA = "";
            this.m_lvHistoryCommitInfo.MultiSelect = false;
            this.m_lvHistoryCommitInfo.Name = "m_lvHistoryCommitInfo";
            this.m_lvHistoryCommitInfo.Size = new System.Drawing.Size(548, 175);
            this.m_lvHistoryCommitInfo.TabIndex = 16;
            this.m_lvHistoryCommitInfo.UseCompatibleStateImageBehavior = false;
            this.m_lvHistoryCommitInfo.View = System.Windows.Forms.View.Details;
            this.m_lvHistoryCommitInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_lvHistoryCommitInfo_MouseDoubleClick);
            this.m_lvHistoryCommitInfo.SelectedIndexChanged += new System.EventHandler(this.m_lvHistoryCommitInfo_SelectedIndexChanged);
            this.m_lvHistoryCommitInfo.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.m_lvHistoryCommitInfo_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Commit";
            this.columnHeader1.Width = 239;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Author";
            this.columnHeader2.Width = 171;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data";
            this.columnHeader3.Width = 134;
            // 
            // m_contextMenu_History
            // 
            this.m_contextMenu_History.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MIM_HistoryGrep,
            this.toolStripSeparator5,
            this.m_MIM_HistorySaveAs,
            this.toolStripSeparator6,
            this.m_MIM_HistoryCompare});
            this.m_contextMenu_History.Name = "m_contextMenu";
            this.m_contextMenu_History.Size = new System.Drawing.Size(181, 82);
            this.m_contextMenu_History.Opening += new System.ComponentModel.CancelEventHandler(this.m_contextMenu_History_Opening);
            // 
            // m_MIM_HistoryGrep
            // 
            this.m_MIM_HistoryGrep.Name = "m_MIM_HistoryGrep";
            this.m_MIM_HistoryGrep.Size = new System.Drawing.Size(180, 22);
            this.m_MIM_HistoryGrep.Text = "Grep";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // m_MIM_HistorySaveAs
            // 
            this.m_MIM_HistorySaveAs.Name = "m_MIM_HistorySaveAs";
            this.m_MIM_HistorySaveAs.Size = new System.Drawing.Size(180, 22);
            this.m_MIM_HistorySaveAs.Text = "Save As";
            this.m_MIM_HistorySaveAs.Click += new System.EventHandler(this.m_MIM_HistorySaveAs_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
            // 
            // m_MIM_HistoryCompare
            // 
            this.m_MIM_HistoryCompare.Name = "m_MIM_HistoryCompare";
            this.m_MIM_HistoryCompare.Size = new System.Drawing.Size(180, 22);
            this.m_MIM_HistoryCompare.Text = "External Compare";
            this.m_MIM_HistoryCompare.Click += new System.EventHandler(this.m_MIM_HistoryCompare_Click);
            // 
            // m_tvHistoryFileTree
            // 
            this.m_tvHistoryFileTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_tvHistoryFileTree.ContextMenuStrip = this.m_contextMenu_Tree;
            this.m_tvHistoryFileTree.ImageIndex = 0;
            this.m_tvHistoryFileTree.Location = new System.Drawing.Point(3, 5);
            this.m_tvHistoryFileTree.Name = "m_tvHistoryFileTree";
            this.m_tvHistoryFileTree.SelectedImageIndex = 0;
            this.m_tvHistoryFileTree.ShowNodeToolTips = true;
            this.m_tvHistoryFileTree.Size = new System.Drawing.Size(300, 253);
            this.m_tvHistoryFileTree.TabIndex = 1;
            this.m_tvHistoryFileTree.DoubleClick += new System.EventHandler(this.m_tvHistoryFileTree_DoubleClick);
            this.m_tvHistoryFileTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvHistoryFileTree_AfterSelect);
            // 
            // m_btnFilter
            // 
            this.m_btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnFilter.Location = new System.Drawing.Point(600, 11);
            this.m_btnFilter.Name = "m_btnFilter";
            this.m_btnFilter.Size = new System.Drawing.Size(54, 23);
            this.m_btnFilter.TabIndex = 16;
            this.m_btnFilter.Text = "filter";
            this.m_btnFilter.UseVisualStyleBackColor = true;
            this.m_btnFilter.Click += new System.EventHandler(this.m_btnFilter_Click);
            // 
            // m_txCurrenBranch
            // 
            this.m_txCurrenBranch.BackColor = System.Drawing.Color.Gainsboro;
            this.m_txCurrenBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txCurrenBranch.Enabled = false;
            this.m_txCurrenBranch.Location = new System.Drawing.Point(66, 16);
            this.m_txCurrenBranch.Multiline = true;
            this.m_txCurrenBranch.Name = "m_txCurrenBranch";
            this.m_txCurrenBranch.Size = new System.Drawing.Size(162, 17);
            this.m_txCurrenBranch.TabIndex = 11;
            // 
            // m_btnSearch
            // 
            this.m_btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnSearch.Location = new System.Drawing.Point(850, 16);
            this.m_btnSearch.Name = "m_btnSearch";
            this.m_btnSearch.Size = new System.Drawing.Size(24, 16);
            this.m_btnSearch.TabIndex = 15;
            this.m_btnSearch.UseVisualStyleBackColor = true;
            this.m_btnSearch.Click += new System.EventHandler(this.m_btnSearch_Click);
            // 
            // m_btnSwitchBr
            // 
            this.m_btnSwitchBr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnSwitchBr.Location = new System.Drawing.Point(203, 16);
            this.m_btnSwitchBr.Name = "m_btnSwitchBr";
            this.m_btnSwitchBr.Size = new System.Drawing.Size(24, 16);
            this.m_btnSwitchBr.TabIndex = 15;
            this.m_btnSwitchBr.UseVisualStyleBackColor = true;
            this.m_btnSwitchBr.Click += new System.EventHandler(this.m_btnSwitch_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(6, 105);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.m_lvChangeFiles);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_rtxChangeContent);
            this.splitContainer2.Size = new System.Drawing.Size(849, 162);
            this.splitContainer2.SplitterDistance = 293;
            this.splitContainer2.TabIndex = 8;
            // 
            // CRepositoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_btnSearch);
            this.Controls.Add(this.m_lvCommitsInfo);
            this.Controls.Add(this.m_btnSwitchBr);
            this.Controls.Add(this.m_tabInfo);
            this.Controls.Add(this.m_btnFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnCurrentRepository);
            this.Controls.Add(this.m_txSearch);
            this.Controls.Add(this.m_txCurrenBranch);
            this.Name = "CRepositoryControl";
            this.Size = new System.Drawing.Size(884, 603);
            this.Load += new System.EventHandler(this.CRepositoryControl_Load);
            this.m_contextMenu_Commit.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.m_contextMenu_File.ResumeLayout(false);
            this.m_tabInfo.ResumeLayout(false);
            this.m_pageMessage.ResumeLayout(false);
            this.m_pageMessage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_pageTree.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.m_contextMenu_Tree.ResumeLayout(false);
            this.m_tabFileHistoy.ResumeLayout(false);
            this.m_contextMenu_History.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCommitsListView m_lvCommitsInfo;
        private System.Windows.Forms.ColumnHeader m_columReversion;
        private System.Windows.Forms.ColumnHeader m_columnCommit;
        private System.Windows.Forms.ColumnHeader m_columnAuthor;
        private System.Windows.Forms.ColumnHeader m_columnDate;
        private System.Windows.Forms.ContextMenuStrip m_contextMenu_Commit;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_CheckOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_AddBranch;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_RemoveBranch;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_SwitchBranch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_AddTag;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_RemoveTag;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_MergeTo;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_RebaseTo;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_CherryPick;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_Revert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_ResetCommit;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_RestoreHistory;
        private System.Windows.Forms.TextBox m_txSearch;
        private System.Windows.Forms.Button m_btnCurrentRepository;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox m_rtxFileContent;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_FileHisotry2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Git.UI.CIconList m_lbParentRefer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_FileHistory;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_ExternalCompare;
        private System.Windows.Forms.ContextMenuStrip m_contextMenu_File;
        private System.Windows.Forms.RichTextBox m_rtxChangeContent;
        private System.Windows.Forms.ListView m_lvChangeFiles;
        private System.Windows.Forms.TabControl m_tabInfo;
        private System.Windows.Forms.TabPage m_pageMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txLogMessage;
        private System.Windows.Forms.TextBox m_txDate;
        private System.Windows.Forms.TextBox m_txAuthor;
        private System.Windows.Forms.TextBox m_txSelectedSHA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage m_pageTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CSystemTreeView m_tvFileTree;
        private System.Windows.Forms.ContextMenuStrip m_contextMenu_Tree;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_ExportFile;
        private System.Windows.Forms.Button m_btnFilter;
        private System.Windows.Forms.TextBox m_txCurrenBranch;
        private System.Windows.Forms.Button m_btnSearch;
        private CIconList m_lbRelatedCommits;
        private System.Windows.Forms.Button m_btnSwitchBr;
        private System.Windows.Forms.TabPage m_tabFileHistoy;
        private CSystemTreeView m_tvHistoryFileTree;
        private CCommitsListView m_lvHistoryCommitInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip m_contextMenu_History;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_HistoryGrep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_HistorySaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_HistoryCompare;
        private System.Windows.Forms.RichTextBox m_rtxHistoryLog;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader m_columnLocalBranch;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}
