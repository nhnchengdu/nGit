namespace Git.UI
{
    partial class Form_Remote_RemoveRemote
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
            this.label2 = new System.Windows.Forms.Label();
            this.m_txFetchURL = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_lbRemotBranchList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txPushURL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_cobRemoteRepoLists = new System.Windows.Forms.ComboBox();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "Fetch URL";
            // 
            // m_txFetchURL
            // 
            this.m_txFetchURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txFetchURL.Enabled = false;
            this.m_txFetchURL.Location = new System.Drawing.Point(4, 34);
            this.m_txFetchURL.Name = "m_txFetchURL";
            this.m_txFetchURL.Size = new System.Drawing.Size(273, 21);
            this.m_txFetchURL.TabIndex = 110;
            this.m_txFetchURL.Text = "git://xxxxxxxxxxxxxxxx";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lbRemotBranchList);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.m_txPushURL);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.m_txFetchURL);
            this.groupBox2.Location = new System.Drawing.Point(8, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 108);
            this.groupBox2.TabIndex = 119;
            this.groupBox2.TabStop = false;
            // 
            // m_lbRemotBranchList
            // 
            this.m_lbRemotBranchList.FormattingEnabled = true;
            this.m_lbRemotBranchList.ItemHeight = 12;
            this.m_lbRemotBranchList.Location = new System.Drawing.Point(283, 32);
            this.m_lbRemotBranchList.Name = "m_lbRemotBranchList";
            this.m_lbRemotBranchList.Size = new System.Drawing.Size(222, 64);
            this.m_lbRemotBranchList.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 77;
            this.label3.Text = "Push URL";
            // 
            // m_txPushURL
            // 
            this.m_txPushURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txPushURL.Enabled = false;
            this.m_txPushURL.Location = new System.Drawing.Point(4, 75);
            this.m_txPushURL.Name = "m_txPushURL";
            this.m_txPushURL.Size = new System.Drawing.Size(273, 21);
            this.m_txPushURL.TabIndex = 110;
            this.m_txPushURL.Text = "git://xxxxxxxxxxxxxxxx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 77;
            this.label4.Text = "Branch List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 77;
            this.label1.Text = "Choose Remote Repository";
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Location = new System.Drawing.Point(40, 134);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(222, 14);
            this.textBox7.TabIndex = 117;
            this.textBox7.Text = "2012-04-05";
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(433, 207);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 121;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(433, 176);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 120;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // m_cobRemoteRepoLists
            // 
            this.m_cobRemoteRepoLists.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_cobRemoteRepoLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobRemoteRepoLists.FormattingEnabled = true;
            this.m_cobRemoteRepoLists.Items.AddRange(new object[] {
            "Master",
            "New Branch -1"});
            this.m_cobRemoteRepoLists.Location = new System.Drawing.Point(12, 24);
            this.m_cobRemoteRepoLists.Name = "m_cobRemoteRepoLists";
            this.m_cobRemoteRepoLists.Size = new System.Drawing.Size(273, 20);
            this.m_cobRemoteRepoLists.TabIndex = 122;
            this.m_cobRemoteRepoLists.TextChanged += new System.EventHandler(this.m_cobRemoteRepoLists_TextChanged);
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(8, 175);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(415, 61);
            this.m_txOperRes.TabIndex = 123;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 124;
            this.label7.Text = "Operation Resutl";
            // 
            // Form_Remote_RemoveRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 238);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.m_cobRemoteRepoLists);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnRun);
            this.Name = "Form_Remote_RemoveRemote";
            this.Text = "Remove Remote";
            this.Load += new System.EventHandler(this.Form_Remote_RemoveRemote_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txFetchURL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txPushURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox m_lbRemotBranchList;
        private System.Windows.Forms.ComboBox m_cobRemoteRepoLists;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.Label label7;
    }
}