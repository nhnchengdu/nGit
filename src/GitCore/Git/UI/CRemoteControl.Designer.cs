namespace Git.UI
{
    partial class CRemoteControl
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
            System.Windows.Forms.ToolStripMenuItem m_MIM_RegisterRemote;
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node0");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node2");
            this.m_contextMenuBranch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_MIM_Pull = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_Push = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_Sync = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_MergeChildTree = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_AddSubModule = new System.Windows.Forms.ToolStripMenuItem();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_contextMenuRemoteRepo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_MIM_Fetch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_UploadBracnh = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_UploadTag = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_DeleteRemoteBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_RemoveRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_RenameRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_EditRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MIM_AddLocalTracking = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MIM_RemoveLocalTracking = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_tvLocalBranch = new System.Windows.Forms.TreeView();
            this.m_tvRemoteRepo = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txRemoteSHA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txRemoteAuthor = new System.Windows.Forms.TextBox();
            this.m_txRemoteLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_txSelSHA = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txSelAuthor = new System.Windows.Forms.TextBox();
            this.m_txSelLog = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_lvChangeFiles = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_txTrackingInfo = new System.Windows.Forms.RichTextBox();
            this.m_lvBranchCommit = new System.Windows.Forms.ListView();
            this.SHA = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_btnRefreshRemote = new System.Windows.Forms.Button();
            this.m_txCurrenBranch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnCurrentRepository = new System.Windows.Forms.Button();
            this.m_BackGround = new System.ComponentModel.BackgroundWorker();
            m_MIM_RegisterRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.m_contextMenuBranch.SuspendLayout();
            this.m_contextMenuRemoteRepo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_MIM_RegisterRemote
            // 
            m_MIM_RegisterRemote.Name = "m_MIM_RegisterRemote";
            m_MIM_RegisterRemote.Size = new System.Drawing.Size(240, 22);
            m_MIM_RegisterRemote.Text = "Register Remote Repository";
            m_MIM_RegisterRemote.Click += new System.EventHandler(this.m_MIM_RegisterRemote_Click);
            // 
            // m_contextMenuBranch
            // 
            this.m_contextMenuBranch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MIM_Pull,
            this.m_MIM_Push,
            this.m_MIM_Sync,
            this.toolStripSeparator4,
            this.m_MIM_Import});
            this.m_contextMenuBranch.Name = "m_contextMenuBranch";
            this.m_contextMenuBranch.Size = new System.Drawing.Size(161, 98);
            this.m_contextMenuBranch.Opening += new System.ComponentModel.CancelEventHandler(this.m_contextMenuBranch_Opening);
            // 
            // m_MIM_Pull
            // 
            this.m_MIM_Pull.Name = "m_MIM_Pull";
            this.m_MIM_Pull.Size = new System.Drawing.Size(160, 22);
            this.m_MIM_Pull.Text = "Pull Branch";
            this.m_MIM_Pull.Click += new System.EventHandler(this.m_MIM_Pull_Click);
            // 
            // m_MIM_Push
            // 
            this.m_MIM_Push.Name = "m_MIM_Push";
            this.m_MIM_Push.Size = new System.Drawing.Size(160, 22);
            this.m_MIM_Push.Text = "Push Branch";
            this.m_MIM_Push.Click += new System.EventHandler(this.m_MIM_Push_Click);
            // 
            // m_MIM_Sync
            // 
            this.m_MIM_Sync.Name = "m_MIM_Sync";
            this.m_MIM_Sync.Size = new System.Drawing.Size(160, 22);
            this.m_MIM_Sync.Text = "Synch Branch";
            this.m_MIM_Sync.Click += new System.EventHandler(this.m_MIM_Sync_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // m_MIM_Import
            // 
            this.m_MIM_Import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MIM_MergeChildTree,
            this.m_MIM_AddSubModule});
            this.m_MIM_Import.Enabled = false;
            this.m_MIM_Import.Name = "m_MIM_Import";
            this.m_MIM_Import.Size = new System.Drawing.Size(160, 22);
            this.m_MIM_Import.Text = "Import Project";
            // 
            // m_MIM_MergeChildTree
            // 
            this.m_MIM_MergeChildTree.Name = "m_MIM_MergeChildTree";
            this.m_MIM_MergeChildTree.Size = new System.Drawing.Size(178, 22);
            this.m_MIM_MergeChildTree.Text = "Merge Child Tree";
            this.m_MIM_MergeChildTree.Click += new System.EventHandler(this.m_MIM_MergeChildTree_Click);
            // 
            // m_MIM_AddSubModule
            // 
            this.m_MIM_AddSubModule.Name = "m_MIM_AddSubModule";
            this.m_MIM_AddSubModule.Size = new System.Drawing.Size(178, 22);
            this.m_MIM_AddSubModule.Text = "Add Sub-Module";
            this.m_MIM_AddSubModule.Click += new System.EventHandler(this.m_MIM_AddSubModule_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(8, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 14);
            this.label10.TabIndex = 6;
            this.label10.Text = "Local Branch";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(584, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 14);
            this.label11.TabIndex = 6;
            this.label11.Text = "Remote Repositroy";
            // 
            // m_contextMenuRemoteRepo
            // 
            this.m_contextMenuRemoteRepo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MIM_Fetch,
            this.toolStripSeparator1,
            this.m_MIM_UploadBracnh,
            this.m_MIM_UploadTag,
            this.m_MIM_DeleteRemoteBranch,
            this.toolStripSeparator2,
            m_MIM_RegisterRemote,
            this.m_MIM_RemoveRemote,
            this.m_MIM_RenameRemote,
            this.m_MIM_EditRemote,
            this.toolStripSeparator3,
            this.m_MIM_AddLocalTracking,
            this.m_MIM_RemoveLocalTracking});
            this.m_contextMenuRemoteRepo.Name = "m_contextMenuRemoteRepo";
            this.m_contextMenuRemoteRepo.Size = new System.Drawing.Size(241, 242);
            // 
            // m_MIM_Fetch
            // 
            this.m_MIM_Fetch.Name = "m_MIM_Fetch";
            this.m_MIM_Fetch.Size = new System.Drawing.Size(240, 22);
            this.m_MIM_Fetch.Text = "Update Remote Repository";
            this.m_MIM_Fetch.Click += new System.EventHandler(this.m_MIM_Fetch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(237, 6);
            // 
            // m_MIM_UploadBracnh
            // 
            this.m_MIM_UploadBracnh.Name = "m_MIM_UploadBracnh";
            this.m_MIM_UploadBracnh.Size = new System.Drawing.Size(240, 22);
            this.m_MIM_UploadBracnh.Text = "UpLoad Branch";
            this.m_MIM_UploadBracnh.Click += new System.EventHandler(this.m_MIM_UploadBracnh_Click);
            // 
            // m_MIM_UploadTag
            // 
            this.m_MIM_UploadTag.Name = "m_MIM_UploadTag";
            this.m_MIM_UploadTag.Size = new System.Drawing.Size(240, 22);
            this.m_MIM_UploadTag.Text = "Upload Tag";
            this.m_MIM_UploadTag.Click += new System.EventHandler(this.m_MIM_UploadTag_Click);
            // 
            // m_MIM_DeleteRemoteBranch
            // 
            this.m_MIM_DeleteRemoteBranch.Name = "m_MIM_DeleteRemoteBranch";
            this.m_MIM_DeleteRemoteBranch.Size = new System.Drawing.Size(240, 22);
            this.m_MIM_DeleteRemoteBranch.Text = "Delete Remote Branch";
            this.m_MIM_DeleteRemoteBranch.Click += new System.EventHandler(this.m_MIM_DeleteRemoteBranch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(237, 6);
            // 
            // m_MIM_RemoveRemote
            // 
            this.m_MIM_RemoveRemote.Name = "m_MIM_RemoveRemote";
            this.m_MIM_RemoveRemote.Size = new System.Drawing.Size(240, 22);
            this.m_MIM_RemoveRemote.Text = "Remove Remote Repository";
            this.m_MIM_RemoveRemote.Click += new System.EventHandler(this.m_MIM_RemoveRemote_Click);
            // 
            // m_MIM_RenameRemote
            // 
            this.m_MIM_RenameRemote.Name = "m_MIM_RenameRemote";
            this.m_MIM_RenameRemote.Size = new System.Drawing.Size(240, 22);
            this.m_MIM_RenameRemote.Text = "Rename Remote Repository";
            this.m_MIM_RenameRemote.Click += new System.EventHandler(this.m_MIM_RenameRemote_Click);
            // 
            // m_MIM_EditRemote
            // 
            this.m_MIM_EditRemote.Name = "m_MIM_EditRemote";
            this.m_MIM_EditRemote.Size = new System.Drawing.Size(240, 22);
            this.m_MIM_EditRemote.Text = "Edit Remote Repository ";
            this.m_MIM_EditRemote.Click += new System.EventHandler(this.m_MIM_EditRemote_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(237, 6);
            // 
            // m_MIM_AddLocalTracking
            // 
            this.m_MIM_AddLocalTracking.Name = "m_MIM_AddLocalTracking";
            this.m_MIM_AddLocalTracking.Size = new System.Drawing.Size(240, 22);
            this.m_MIM_AddLocalTracking.Text = "Add Local Tracking";
            this.m_MIM_AddLocalTracking.Click += new System.EventHandler(this.m_MIM_AddLocalTracking_Click);
            // 
            // m_MIM_RemoveLocalTracking
            // 
            this.m_MIM_RemoveLocalTracking.Name = "m_MIM_RemoveLocalTracking";
            this.m_MIM_RemoveLocalTracking.Size = new System.Drawing.Size(240, 22);
            this.m_MIM_RemoveLocalTracking.Text = "Remove Local Tracking";
            this.m_MIM_RemoveLocalTracking.Click += new System.EventHandler(this.m_MIM_RemoveLocalTracking_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.m_tvLocalBranch);
            this.groupBox2.Controls.Add(this.m_tvRemoteRepo);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(7, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 240);
            this.groupBox2.TabIndex = 82;
            this.groupBox2.TabStop = false;
            // 
            // m_tvLocalBranch
            // 
            this.m_tvLocalBranch.ContextMenuStrip = this.m_contextMenuBranch;
            this.m_tvLocalBranch.Location = new System.Drawing.Point(8, 30);
            this.m_tvLocalBranch.Name = "m_tvLocalBranch";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Node1";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Node2";
            this.m_tvLocalBranch.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.m_tvLocalBranch.ShowNodeToolTips = true;
            this.m_tvLocalBranch.Size = new System.Drawing.Size(258, 204);
            this.m_tvLocalBranch.TabIndex = 81;
            this.m_tvLocalBranch.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvLocalBranch_AfterSelect);
            // 
            // m_tvRemoteRepo
            // 
            this.m_tvRemoteRepo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tvRemoteRepo.ContextMenuStrip = this.m_contextMenuRemoteRepo;
            this.m_tvRemoteRepo.Location = new System.Drawing.Point(584, 30);
            this.m_tvRemoteRepo.Name = "m_tvRemoteRepo";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Node0";
            treeNode5.Name = "Node1";
            treeNode5.Text = "Node1";
            treeNode6.Name = "Node2";
            treeNode6.Text = "Node2";
            this.m_tvRemoteRepo.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.m_tvRemoteRepo.Size = new System.Drawing.Size(258, 204);
            this.m_tvRemoteRepo.TabIndex = 81;
            this.m_tvRemoteRepo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_tvRemoteRepo_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txRemoteSHA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_txRemoteAuthor);
            this.groupBox1.Controls.Add(this.m_txRemoteLog);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(275, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // m_txRemoteSHA
            // 
            this.m_txRemoteSHA.AcceptsTab = true;
            this.m_txRemoteSHA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txRemoteSHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txRemoteSHA.Enabled = false;
            this.m_txRemoteSHA.Location = new System.Drawing.Point(50, 11);
            this.m_txRemoteSHA.Multiline = true;
            this.m_txRemoteSHA.Name = "m_txRemoteSHA";
            this.m_txRemoteSHA.Size = new System.Drawing.Size(248, 16);
            this.m_txRemoteSHA.TabIndex = 8;
            this.m_txRemoteSHA.Text = "00000000000000000000000000000000000";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Remote:";
            // 
            // m_txRemoteAuthor
            // 
            this.m_txRemoteAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txRemoteAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txRemoteAuthor.Enabled = false;
            this.m_txRemoteAuthor.Location = new System.Drawing.Point(52, 28);
            this.m_txRemoteAuthor.Multiline = true;
            this.m_txRemoteAuthor.Name = "m_txRemoteAuthor";
            this.m_txRemoteAuthor.Size = new System.Drawing.Size(245, 16);
            this.m_txRemoteAuthor.TabIndex = 11;
            // 
            // m_txRemoteLog
            // 
            this.m_txRemoteLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txRemoteLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txRemoteLog.Enabled = false;
            this.m_txRemoteLog.Location = new System.Drawing.Point(8, 48);
            this.m_txRemoteLog.Multiline = true;
            this.m_txRemoteLog.Name = "m_txRemoteLog";
            this.m_txRemoteLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_txRemoteLog.Size = new System.Drawing.Size(290, 47);
            this.m_txRemoteLog.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Author:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_txSelSHA);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.m_txSelAuthor);
            this.groupBox4.Controls.Add(this.m_txSelLog);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(275, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(303, 103);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // m_txSelSHA
            // 
            this.m_txSelSHA.AcceptsTab = true;
            this.m_txSelSHA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txSelSHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSelSHA.Enabled = false;
            this.m_txSelSHA.Location = new System.Drawing.Point(47, 11);
            this.m_txSelSHA.Multiline = true;
            this.m_txSelSHA.Name = "m_txSelSHA";
            this.m_txSelSHA.Size = new System.Drawing.Size(250, 16);
            this.m_txSelSHA.TabIndex = 8;
            this.m_txSelSHA.Text = "00000000000000000000000000000000000";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 6;
            this.label15.Text = "Local:";
            // 
            // m_txSelAuthor
            // 
            this.m_txSelAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txSelAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSelAuthor.Enabled = false;
            this.m_txSelAuthor.Location = new System.Drawing.Point(52, 28);
            this.m_txSelAuthor.Multiline = true;
            this.m_txSelAuthor.Name = "m_txSelAuthor";
            this.m_txSelAuthor.Size = new System.Drawing.Size(245, 16);
            this.m_txSelAuthor.TabIndex = 11;
            // 
            // m_txSelLog
            // 
            this.m_txSelLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txSelLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSelLog.Enabled = false;
            this.m_txSelLog.Location = new System.Drawing.Point(8, 48);
            this.m_txSelLog.Multiline = true;
            this.m_txSelLog.Name = "m_txSelLog";
            this.m_txSelLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_txSelLog.Size = new System.Drawing.Size(290, 47);
            this.m_txSelLog.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Author:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.m_lvChangeFiles);
            this.groupBox3.Controls.Add(this.m_txTrackingInfo);
            this.groupBox3.Controls.Add(this.m_lvBranchCommit);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(7, 264);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(849, 303);
            this.groupBox3.TabIndex = 83;
            this.groupBox3.TabStop = false;
            // 
            // m_lvChangeFiles
            // 
            this.m_lvChangeFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lvChangeFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lvChangeFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.m_lvChangeFiles.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_lvChangeFiles.FullRowSelect = true;
            this.m_lvChangeFiles.GridLines = true;
            this.m_lvChangeFiles.Location = new System.Drawing.Point(480, 32);
            this.m_lvChangeFiles.MultiSelect = false;
            this.m_lvChangeFiles.Name = "m_lvChangeFiles";
            this.m_lvChangeFiles.ShowItemToolTips = true;
            this.m_lvChangeFiles.Size = new System.Drawing.Size(362, 265);
            this.m_lvChangeFiles.TabIndex = 129;
            this.m_lvChangeFiles.UseCompatibleStateImageBehavior = false;
            this.m_lvChangeFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Change Files";
            this.columnHeader4.Width = 358;
            // 
            // m_txTrackingInfo
            // 
            this.m_txTrackingInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.m_txTrackingInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.m_txTrackingInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txTrackingInfo.ForeColor = System.Drawing.Color.Navy;
            this.m_txTrackingInfo.Location = new System.Drawing.Point(480, 163);
            this.m_txTrackingInfo.Name = "m_txTrackingInfo";
            this.m_txTrackingInfo.Size = new System.Drawing.Size(100, 134);
            this.m_txTrackingInfo.TabIndex = 85;
            this.m_txTrackingInfo.Text = "";
            this.m_txTrackingInfo.Visible = false;
            // 
            // m_lvBranchCommit
            // 
            this.m_lvBranchCommit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lvBranchCommit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SHA,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_lvBranchCommit.FullRowSelect = true;
            this.m_lvBranchCommit.GridLines = true;
            this.m_lvBranchCommit.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lvBranchCommit.Location = new System.Drawing.Point(8, 32);
            this.m_lvBranchCommit.MultiSelect = false;
            this.m_lvBranchCommit.Name = "m_lvBranchCommit";
            this.m_lvBranchCommit.Size = new System.Drawing.Size(466, 265);
            this.m_lvBranchCommit.TabIndex = 84;
            this.m_lvBranchCommit.UseCompatibleStateImageBehavior = false;
            this.m_lvBranchCommit.View = System.Windows.Forms.View.Details;
            this.m_lvBranchCommit.SelectedIndexChanged += new System.EventHandler(this.m_lvBranchCommit_SelectedIndexChanged);
            // 
            // SHA
            // 
            this.SHA.Text = "SHA";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Commit";
            this.columnHeader1.Width = 233;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Author";
            this.columnHeader2.Width = 83;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.Width = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Change Commits";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(480, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 14);
            this.label9.TabIndex = 6;
            this.label9.Text = "Tracking Information";
            this.label9.Visible = false;
            // 
            // m_btnRefreshRemote
            // 
            this.m_btnRefreshRemote.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.m_btnRefreshRemote.Enabled = false;
            this.m_btnRefreshRemote.Location = new System.Drawing.Point(9, 8);
            this.m_btnRefreshRemote.Name = "m_btnRefreshRemote";
            this.m_btnRefreshRemote.Size = new System.Drawing.Size(185, 18);
            this.m_btnRefreshRemote.TabIndex = 87;
            this.m_btnRefreshRemote.Text = "Refresh Remote Information";
            this.m_btnRefreshRemote.UseVisualStyleBackColor = false;
            // 
            // m_txCurrenBranch
            // 
            this.m_txCurrenBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txCurrenBranch.BackColor = System.Drawing.Color.Gainsboro;
            this.m_txCurrenBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txCurrenBranch.Enabled = false;
            this.m_txCurrenBranch.Location = new System.Drawing.Point(694, 8);
            this.m_txCurrenBranch.Multiline = true;
            this.m_txCurrenBranch.Name = "m_txCurrenBranch";
            this.m_txCurrenBranch.Size = new System.Drawing.Size(162, 17);
            this.m_txCurrenBranch.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 88;
            this.label2.Text = "*Branch:";
            // 
            // m_btnCurrentRepository
            // 
            this.m_btnCurrentRepository.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCurrentRepository.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnCurrentRepository.Location = new System.Drawing.Point(274, 5);
            this.m_btnCurrentRepository.Name = "m_btnCurrentRepository";
            this.m_btnCurrentRepository.Size = new System.Drawing.Size(314, 21);
            this.m_btnCurrentRepository.TabIndex = 90;
            this.m_btnCurrentRepository.Text = "Current Repository";
            this.m_btnCurrentRepository.UseVisualStyleBackColor = true;
            this.m_btnCurrentRepository.Click += new System.EventHandler(this.m_btnCurrentRepository_Click);
            // 
            // m_BackGround
            // 
            this.m_BackGround.WorkerReportsProgress = true;
            this.m_BackGround.WorkerSupportsCancellation = true;
            this.m_BackGround.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_BackGround_DoWork);
            this.m_BackGround.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_BackGround_RunWorkerCompleted);
            // 
            // CRemoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.m_btnCurrentRepository);
            this.Controls.Add(this.m_txCurrenBranch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_btnRefreshRemote);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "CRemoteControl";
            this.Size = new System.Drawing.Size(860, 576);
            this.Load += new System.EventHandler(this.CRemoteControl_Load);
            this.m_contextMenuBranch.ResumeLayout(false);
            this.m_contextMenuRemoteRepo.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView m_lvBranchCommit;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip m_contextMenuBranch;
        private System.Windows.Forms.ContextMenuStrip m_contextMenuRemoteRepo;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_Pull;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_Push;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_Sync;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_UploadBracnh;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_UploadTag;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_Fetch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_RemoveRemote;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_RenameRemote;
        private System.Windows.Forms.Button m_btnRefreshRemote;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_EditRemote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_Import;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_MergeChildTree;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_AddSubModule;
        private System.Windows.Forms.TextBox m_txCurrenBranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txSelLog;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox m_txSelAuthor;
        private System.Windows.Forms.Button m_btnCurrentRepository;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox m_txSelSHA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox m_txRemoteSHA;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox m_txRemoteAuthor;
        private System.Windows.Forms.TextBox m_txRemoteLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView m_tvLocalBranch;
        private System.Windows.Forms.TreeView m_tvRemoteRepo;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_DeleteRemoteBranch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_AddLocalTracking;
        private System.Windows.Forms.ToolStripMenuItem m_MIM_RemoveLocalTracking;
        private System.Windows.Forms.ColumnHeader SHA;
        private System.Windows.Forms.RichTextBox m_txTrackingInfo;
        private System.ComponentModel.BackgroundWorker m_BackGround;
        private System.Windows.Forms.ListView m_lvChangeFiles;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
