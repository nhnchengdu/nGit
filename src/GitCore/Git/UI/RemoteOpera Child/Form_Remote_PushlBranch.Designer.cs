namespace Git.UI
{
    partial class Form_Remote_PushlBranch
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
            this.m_checkForcePush = new System.Windows.Forms.CheckBox();
            this.m_txLocalBranch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txPushURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txRemoteBranch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txRemoteName = new System.Windows.Forms.TextBox();
            this.m_btnStop = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_barOperProgress = new System.Windows.Forms.ProgressBar();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_checkForcePush
            // 
            this.m_checkForcePush.AutoSize = true;
            this.m_checkForcePush.Location = new System.Drawing.Point(11, 354);
            this.m_checkForcePush.Name = "m_checkForcePush";
            this.m_checkForcePush.Size = new System.Drawing.Size(186, 16);
            this.m_checkForcePush.TabIndex = 90;
            this.m_checkForcePush.Text = "Force Cover(Very Dangerous)";
            this.m_checkForcePush.UseVisualStyleBackColor = true;
            // 
            // m_txLocalBranch
            // 
            this.m_txLocalBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txLocalBranch.Enabled = false;
            this.m_txLocalBranch.Location = new System.Drawing.Point(14, 24);
            this.m_txLocalBranch.Name = "m_txLocalBranch";
            this.m_txLocalBranch.Size = new System.Drawing.Size(469, 21);
            this.m_txLocalBranch.TabIndex = 82;
            this.m_txLocalBranch.Text = "master";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 89;
            this.label9.Text = "Local Branch:";
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(246, 349);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 86;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.m_txPushURL);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.m_txRemoteBranch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_txRemoteName);
            this.groupBox2.Location = new System.Drawing.Point(6, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 102);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 113;
            this.label3.Text = "Target Remote URL";
            // 
            // m_txPushURL
            // 
            this.m_txPushURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txPushURL.Enabled = false;
            this.m_txPushURL.Location = new System.Drawing.Point(7, 72);
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
            this.m_txRemoteBranch.Location = new System.Drawing.Point(191, 27);
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
            this.m_txRemoteName.Location = new System.Drawing.Point(7, 27);
            this.m_txRemoteName.Name = "m_txRemoteName";
            this.m_txRemoteName.Size = new System.Drawing.Size(162, 21);
            this.m_txRemoteName.TabIndex = 112;
            this.m_txRemoteName.Text = "New Remote";
            // 
            // m_btnStop
            // 
            this.m_btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnStop.Location = new System.Drawing.Point(327, 349);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(75, 25);
            this.m_btnStop.TabIndex = 87;
            this.m_btnStop.Text = "Stop";
            this.m_btnStop.UseVisualStyleBackColor = true;
            this.m_btnStop.Click += new System.EventHandler(this.m_btnStop_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(408, 349);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 88;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 79;
            this.label8.Text = "Message:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 80;
            this.label7.Text = "Data:";
            // 
            // textBox8
            // 
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Location = new System.Drawing.Point(64, 112);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(469, 14);
            this.textBox8.TabIndex = 81;
            this.textBox8.Text = "this commit is for test...........................";
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Location = new System.Drawing.Point(45, 97);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(222, 14);
            this.textBox7.TabIndex = 83;
            this.textBox7.Text = "2012-04-05";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 78;
            this.label6.Text = "Author:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_barOperProgress);
            this.groupBox1.Controls.Add(this.m_txOperRes);
            this.groupBox1.Location = new System.Drawing.Point(6, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 191);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation Result";
            // 
            // m_barOperProgress
            // 
            this.m_barOperProgress.Location = new System.Drawing.Point(8, 166);
            this.m_barOperProgress.Name = "m_barOperProgress";
            this.m_barOperProgress.Size = new System.Drawing.Size(468, 15);
            this.m_barOperProgress.TabIndex = 117;
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(8, 17);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(468, 148);
            this.m_txOperRes.TabIndex = 116;
            // 
            // Form_Remote_PushlBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 377);
            this.Controls.Add(this.m_checkForcePush);
            this.Controls.Add(this.m_txLocalBranch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Remote_PushlBranch";
            this.Text = "Push Selected Branch";
            this.Load += new System.EventHandler(this.Form_Remote_PushlBranch_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox m_checkForcePush;
        private System.Windows.Forms.TextBox m_txLocalBranch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button m_btnStop;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txRemoteBranch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txRemoteName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txPushURL;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.ProgressBar m_barOperProgress;

    }
}