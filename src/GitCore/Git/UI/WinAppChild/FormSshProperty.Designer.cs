namespace Git.UI
{
    partial class FormSshProperty
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
            this.m_btnStop = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.m_btnCreateKey = new System.Windows.Forms.Button();
            this.m_txRemoteRepo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_btnCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txUsrName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnOpenKey = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnStop
            // 
            this.m_btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnStop.Enabled = false;
            this.m_btnStop.Location = new System.Drawing.Point(379, 143);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(47, 25);
            this.m_btnStop.TabIndex = 148;
            this.m_btnStop.Text = "Stop";
            this.m_btnStop.UseVisualStyleBackColor = true;
            this.m_btnStop.Click += new System.EventHandler(this.m_btnStop_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(379, 189);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(47, 25);
            this.m_btnCancel.TabIndex = 147;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 144;
            this.label7.Text = "Operation Resutl";
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(12, 130);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(365, 98);
            this.m_txOperRes.TabIndex = 145;
            // 
            // m_btnCreateKey
            // 
            this.m_btnCreateKey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCreateKey.Location = new System.Drawing.Point(250, 19);
            this.m_btnCreateKey.Name = "m_btnCreateKey";
            this.m_btnCreateKey.Size = new System.Drawing.Size(75, 25);
            this.m_btnCreateKey.TabIndex = 146;
            this.m_btnCreateKey.Text = "Create";
            this.m_btnCreateKey.UseVisualStyleBackColor = true;
            this.m_btnCreateKey.Click += new System.EventHandler(this.m_btnCreateKey_Click);
            // 
            // m_txRemoteRepo
            // 
            this.m_txRemoteRepo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txRemoteRepo.Location = new System.Drawing.Point(9, 23);
            this.m_txRemoteRepo.Name = "m_txRemoteRepo";
            this.m_txRemoteRepo.Size = new System.Drawing.Size(323, 21);
            this.m_txRemoteRepo.TabIndex = 96;
            this.m_txRemoteRepo.Text = "username@git.platform.nhncorp.cn:29418";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_txRemoteRepo);
            this.groupBox2.Controls.Add(this.m_btnCheck);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 51);
            this.groupBox2.TabIndex = 143;
            this.groupBox2.TabStop = false;
            // 
            // m_btnCheck
            // 
            this.m_btnCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCheck.Location = new System.Drawing.Point(338, 21);
            this.m_btnCheck.Name = "m_btnCheck";
            this.m_btnCheck.Size = new System.Drawing.Size(76, 25);
            this.m_btnCheck.TabIndex = 148;
            this.m_btnCheck.Text = "Check";
            this.m_btnCheck.UseVisualStyleBackColor = true;
            this.m_btnCheck.Click += new System.EventHandler(this.m_btnCheck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "Check SSH Key";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txUsrName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_btnOpenKey);
            this.groupBox1.Controls.Add(this.m_btnCreateKey);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 51);
            this.groupBox1.TabIndex = 149;
            this.groupBox1.TabStop = false;
            // 
            // m_txUsrName
            // 
            this.m_txUsrName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txUsrName.Location = new System.Drawing.Point(9, 23);
            this.m_txUsrName.Name = "m_txUsrName";
            this.m_txUsrName.Size = new System.Drawing.Size(235, 21);
            this.m_txUsrName.TabIndex = 96;
            this.m_txUsrName.Text = "User@nhn.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 77;
            this.label1.Text = "Create SSH Key";
            // 
            // m_btnOpenKey
            // 
            this.m_btnOpenKey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnOpenKey.Location = new System.Drawing.Point(325, 19);
            this.m_btnOpenKey.Name = "m_btnOpenKey";
            this.m_btnOpenKey.Size = new System.Drawing.Size(40, 25);
            this.m_btnOpenKey.TabIndex = 147;
            this.m_btnOpenKey.Text = "Open";
            this.m_btnOpenKey.UseVisualStyleBackColor = true;
            this.m_btnOpenKey.Click += new System.EventHandler(this.m_btnOpenKey_Click);
            // 
            // FormSshProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 233);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSshProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSH Configuration";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btnStop;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.Button m_btnCreateKey;
        private System.Windows.Forms.TextBox m_txRemoteRepo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox m_txUsrName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_btnCheck;
        private System.Windows.Forms.Button m_btnOpenKey;
    }
}