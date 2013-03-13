namespace Git.UI
{
    partial class Form_Remote_EditRemote
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txPushURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txFetchURL = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_cobRemoteRepoLists = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.m_btnStop = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.m_txPushURL);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.m_txFetchURL);
            this.groupBox2.Location = new System.Drawing.Point(6, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 92);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 112;
            this.label3.Text = "Push URL";
            // 
            // m_txPushURL
            // 
            this.m_txPushURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txPushURL.Location = new System.Drawing.Point(7, 62);
            this.m_txPushURL.Name = "m_txPushURL";
            this.m_txPushURL.Size = new System.Drawing.Size(420, 21);
            this.m_txPushURL.TabIndex = 114;
            this.m_txPushURL.Text = "git://xxxxxxxxxxxxxxxx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 111;
            this.label2.Text = "Fetch URL";
            // 
            // m_txFetchURL
            // 
            this.m_txFetchURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txFetchURL.Location = new System.Drawing.Point(7, 25);
            this.m_txFetchURL.Name = "m_txFetchURL";
            this.m_txFetchURL.Size = new System.Drawing.Size(420, 21);
            this.m_txFetchURL.TabIndex = 113;
            this.m_txFetchURL.Text = "git://xxxxxxxxxxxxxxxx";
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(361, 208);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 130;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(361, 149);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 129;
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
            this.m_cobRemoteRepoLists.Location = new System.Drawing.Point(7, 21);
            this.m_cobRemoteRepoLists.Name = "m_cobRemoteRepoLists";
            this.m_cobRemoteRepoLists.Size = new System.Drawing.Size(273, 20);
            this.m_cobRemoteRepoLists.TabIndex = 132;
            this.m_cobRemoteRepoLists.TextChanged += new System.EventHandler(this.m_cobRemoteRepoLists_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 131;
            this.label1.Text = "Choose Remote Repository";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 134;
            this.label7.Text = "Operation Resutl";
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(9, 149);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(346, 94);
            this.m_txOperRes.TabIndex = 133;
            // 
            // m_btnStop
            // 
            this.m_btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnStop.Enabled = false;
            this.m_btnStop.Location = new System.Drawing.Point(361, 177);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(75, 25);
            this.m_btnStop.TabIndex = 135;
            this.m_btnStop.Text = "Stop";
            this.m_btnStop.UseVisualStyleBackColor = true;
            this.m_btnStop.Click += new System.EventHandler(this.m_btnStop_Click);
            // 
            // Form_Remote_EditRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 245);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.m_cobRemoteRepoLists);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form_Remote_EditRemote";
            this.Text = "Edit Remote";
            this.Load += new System.EventHandler(this.Form_Remote_EditRemote_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.ComboBox m_cobRemoteRepoLists;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txPushURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txFetchURL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.Button m_btnStop;

    }
}