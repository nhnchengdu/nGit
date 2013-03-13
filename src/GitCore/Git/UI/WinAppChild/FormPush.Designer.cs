namespace Git.UI
{
    partial class FormPush
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPush));
            this.m_txLocalBranch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cobRemoteRepoLists = new System.Windows.Forms.ComboBox();
            this.m_cobRemoteBranchLists = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_picShowTracking = new System.Windows.Forms.PictureBox();
            this.m_checkForcePush = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txPullURL = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_btnStop = new System.Windows.Forms.Button();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_barOperProgress = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lvBranchCommit = new System.Windows.Forms.ListView();
            this.SHA = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_lvChangeFiles = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picShowTracking)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txLocalBranch
            // 
            this.m_txLocalBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txLocalBranch.Enabled = false;
            this.m_txLocalBranch.Location = new System.Drawing.Point(142, 13);
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
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 114;
            this.label9.Text = "Source Local Branch:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 111;
            this.label2.Text = "Target Remote Branch:";
            // 
            // m_cobRemoteRepoLists
            // 
            this.m_cobRemoteRepoLists.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_cobRemoteRepoLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobRemoteRepoLists.FormattingEnabled = true;
            this.m_cobRemoteRepoLists.Location = new System.Drawing.Point(142, 41);
            this.m_cobRemoteRepoLists.Name = "m_cobRemoteRepoLists";
            this.m_cobRemoteRepoLists.Size = new System.Drawing.Size(128, 20);
            this.m_cobRemoteRepoLists.TabIndex = 119;
            this.m_cobRemoteRepoLists.SelectedIndexChanged += new System.EventHandler(this.m_cobRemoteRepoLists_SelectedIndexChanged);
            // 
            // m_cobRemoteBranchLists
            // 
            this.m_cobRemoteBranchLists.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_cobRemoteBranchLists.FormattingEnabled = true;
            this.m_cobRemoteBranchLists.Location = new System.Drawing.Point(276, 41);
            this.m_cobRemoteBranchLists.Name = "m_cobRemoteBranchLists";
            this.m_cobRemoteBranchLists.Size = new System.Drawing.Size(280, 20);
            this.m_cobRemoteBranchLists.TabIndex = 119;
            this.m_cobRemoteBranchLists.TextUpdate += new System.EventHandler(this.m_cobRemoteBranchLists_TextUpdate);
            this.m_cobRemoteBranchLists.TextChanged += new System.EventHandler(this.m_cobRemoteBranchLists_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_picShowTracking);
            this.groupBox2.Controls.Add(this.m_cobRemoteBranchLists);
            this.groupBox2.Controls.Add(this.m_checkForcePush);
            this.groupBox2.Controls.Add(this.m_cobRemoteRepoLists);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.m_txLocalBranch);
            this.groupBox2.Location = new System.Drawing.Point(4, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 72);
            this.groupBox2.TabIndex = 120;
            this.groupBox2.TabStop = false;
            // 
            // m_picShowTracking
            // 
            this.m_picShowTracking.Image = ((System.Drawing.Image)(resources.GetObject("m_picShowTracking.Image")));
            this.m_picShowTracking.InitialImage = ((System.Drawing.Image)(resources.GetObject("m_picShowTracking.InitialImage")));
            this.m_picShowTracking.Location = new System.Drawing.Point(562, 42);
            this.m_picShowTracking.Name = "m_picShowTracking";
            this.m_picShowTracking.Size = new System.Drawing.Size(30, 19);
            this.m_picShowTracking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picShowTracking.TabIndex = 120;
            this.m_picShowTracking.TabStop = false;
            this.m_picShowTracking.Visible = false;
            // 
            // m_checkForcePush
            // 
            this.m_checkForcePush.AutoSize = true;
            this.m_checkForcePush.Location = new System.Drawing.Point(319, 16);
            this.m_checkForcePush.Name = "m_checkForcePush";
            this.m_checkForcePush.Size = new System.Drawing.Size(186, 16);
            this.m_checkForcePush.TabIndex = 126;
            this.m_checkForcePush.Text = "Force Cover(Very Dangerous)";
            this.m_checkForcePush.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 111;
            this.label1.Text = "Push The Branch To:";
            // 
            // m_txPullURL
            // 
            this.m_txPullURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txPullURL.Enabled = false;
            this.m_txPullURL.Location = new System.Drawing.Point(140, 13);
            this.m_txPullURL.Name = "m_txPullURL";
            this.m_txPullURL.Size = new System.Drawing.Size(450, 21);
            this.m_txPullURL.TabIndex = 114;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_txPullURL);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(605, 40);
            this.groupBox3.TabIndex = 121;
            this.groupBox3.TabStop = false;
            // 
            // m_btnStop
            // 
            this.m_btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnStop.Location = new System.Drawing.Point(515, 73);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(75, 25);
            this.m_btnStop.TabIndex = 124;
            this.m_btnStop.Text = "Stop";
            this.m_btnStop.UseVisualStyleBackColor = true;
            this.m_btnStop.Click += new System.EventHandler(this.m_btnStop_Click);
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(515, 29);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 123;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(6, 16);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(497, 129);
            this.m_txOperRes.TabIndex = 116;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(515, 119);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 125;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_barOperProgress
            // 
            this.m_barOperProgress.Location = new System.Drawing.Point(6, 147);
            this.m_barOperProgress.Name = "m_barOperProgress";
            this.m_barOperProgress.Size = new System.Drawing.Size(498, 10);
            this.m_barOperProgress.TabIndex = 117;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_barOperProgress);
            this.groupBox1.Controls.Add(this.m_txOperRes);
            this.groupBox1.Controls.Add(this.m_btnRun);
            this.groupBox1.Controls.Add(this.m_btnCancel);
            this.groupBox1.Controls.Add(this.m_btnStop);
            this.groupBox1.Location = new System.Drawing.Point(6, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 164);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation Result";
            // 
            // m_lvBranchCommit
            // 
            this.m_lvBranchCommit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lvBranchCommit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lvBranchCommit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SHA,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_lvBranchCommit.FullRowSelect = true;
            this.m_lvBranchCommit.GridLines = true;
            this.m_lvBranchCommit.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lvBranchCommit.Location = new System.Drawing.Point(6, 117);
            this.m_lvBranchCommit.MultiSelect = false;
            this.m_lvBranchCommit.Name = "m_lvBranchCommit";
            this.m_lvBranchCommit.Size = new System.Drawing.Size(385, 193);
            this.m_lvBranchCommit.TabIndex = 127;
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
            this.columnHeader1.Width = 204;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Author";
            this.columnHeader2.Width = 62;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.Width = 55;
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
            this.m_lvChangeFiles.Location = new System.Drawing.Point(393, 118);
            this.m_lvChangeFiles.MultiSelect = false;
            this.m_lvChangeFiles.Name = "m_lvChangeFiles";
            this.m_lvChangeFiles.ShowItemToolTips = true;
            this.m_lvChangeFiles.Size = new System.Drawing.Size(218, 192);
            this.m_lvChangeFiles.TabIndex = 128;
            this.m_lvChangeFiles.UseCompatibleStateImageBehavior = false;
            this.m_lvChangeFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Change Files";
            this.columnHeader4.Width = 215;
            // 
            // FormPush
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(614, 482);
            this.Controls.Add(this.m_lvChangeFiles);
            this.Controls.Add(this.m_lvBranchCommit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPush";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Push Branch";
            this.Load += new System.EventHandler(this.FormPush_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picShowTracking)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox m_txLocalBranch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.ComboBox m_cobRemoteRepoLists;
        private System.Windows.Forms.ComboBox m_cobRemoteBranchLists;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox m_picShowTracking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txPullURL;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox m_checkForcePush;
        private System.Windows.Forms.Button m_btnStop;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.ProgressBar m_barOperProgress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView m_lvBranchCommit;
        private System.Windows.Forms.ColumnHeader SHA;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView m_lvChangeFiles;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}