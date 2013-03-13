namespace Git.UI
{
    public partial class FormClone
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabClone = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_btnWorkingChoose = new System.Windows.Forms.Button();
            this.m_cbGitWorkingDir = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_btnGitChoose = new System.Windows.Forms.Button();
            this.m_cbLocalGitDirectory = new System.Windows.Forms.ComboBox();
            this.m_cbReomoteGitUrl = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_checkLocalGit = new System.Windows.Forms.RadioButton();
            this.m_checkRemoteGit = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_cbSvnWorkingDir = new System.Windows.Forms.ComboBox();
            this.m_cbSvnUrl = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_btnSvnChoose = new System.Windows.Forms.Button();
            this.m_edPassword = new System.Windows.Forms.TextBox();
            this.m_edLoginUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_edrShowCloneInfo = new System.Windows.Forms.TextBox();
            this.m_btnStop = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnClone = new System.Windows.Forms.Button();
            this.labCloneInfo = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabClone.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 456);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(377, 15);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 0;
            // 
            // tabClone
            // 
            this.tabClone.Controls.Add(this.tabPage1);
            this.tabClone.Controls.Add(this.tabPage2);
            this.tabClone.Location = new System.Drawing.Point(2, 6);
            this.tabClone.Name = "tabClone";
            this.tabClone.SelectedIndex = 0;
            this.tabClone.Size = new System.Drawing.Size(613, 223);
            this.tabClone.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(605, 197);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Git Repository";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.m_btnWorkingChoose);
            this.groupBox2.Controls.Add(this.m_cbGitWorkingDir);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 62);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // m_btnWorkingChoose
            // 
            this.m_btnWorkingChoose.Location = new System.Drawing.Point(501, 32);
            this.m_btnWorkingChoose.Name = "m_btnWorkingChoose";
            this.m_btnWorkingChoose.Size = new System.Drawing.Size(78, 20);
            this.m_btnWorkingChoose.TabIndex = 8;
            this.m_btnWorkingChoose.Text = "Choose..";
            this.m_btnWorkingChoose.UseVisualStyleBackColor = true;
            this.m_btnWorkingChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // m_cbGitWorkingDir
            // 
            this.m_cbGitWorkingDir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_cbGitWorkingDir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.m_cbGitWorkingDir.FormattingEnabled = true;
            this.m_cbGitWorkingDir.Location = new System.Drawing.Point(126, 32);
            this.m_cbGitWorkingDir.Name = "m_cbGitWorkingDir";
            this.m_cbGitWorkingDir.Size = new System.Drawing.Size(368, 20);
            this.m_cbGitWorkingDir.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Git Working Directory";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.m_btnGitChoose);
            this.groupBox1.Controls.Add(this.m_cbLocalGitDirectory);
            this.groupBox1.Controls.Add(this.m_cbReomoteGitUrl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_checkLocalGit);
            this.groupBox1.Controls.Add(this.m_checkRemoteGit);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 119);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // m_btnGitChoose
            // 
            this.m_btnGitChoose.Location = new System.Drawing.Point(501, 88);
            this.m_btnGitChoose.Name = "m_btnGitChoose";
            this.m_btnGitChoose.Size = new System.Drawing.Size(78, 20);
            this.m_btnGitChoose.TabIndex = 8;
            this.m_btnGitChoose.Text = "Choose..";
            this.m_btnGitChoose.UseVisualStyleBackColor = true;
            this.m_btnGitChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // m_cbLocalGitDirectory
            // 
            this.m_cbLocalGitDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_cbLocalGitDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.m_cbLocalGitDirectory.Enabled = false;
            this.m_cbLocalGitDirectory.FormattingEnabled = true;
            this.m_cbLocalGitDirectory.Location = new System.Drawing.Point(128, 88);
            this.m_cbLocalGitDirectory.Name = "m_cbLocalGitDirectory";
            this.m_cbLocalGitDirectory.Size = new System.Drawing.Size(367, 20);
            this.m_cbLocalGitDirectory.TabIndex = 7;
            // 
            // m_cbReomoteGitUrl
            // 
            this.m_cbReomoteGitUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_cbReomoteGitUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.m_cbReomoteGitUrl.FormattingEnabled = true;
            this.m_cbReomoteGitUrl.Items.AddRange(new object[] {
            "https://github.com/yysun/Git-Source-Control-Provider"});
            this.m_cbReomoteGitUrl.Location = new System.Drawing.Point(128, 40);
            this.m_cbReomoteGitUrl.Name = "m_cbReomoteGitUrl";
            this.m_cbReomoteGitUrl.Size = new System.Drawing.Size(367, 20);
            this.m_cbReomoteGitUrl.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Local Directory:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Repository URL:";
            // 
            // m_checkLocalGit
            // 
            this.m_checkLocalGit.AutoSize = true;
            this.m_checkLocalGit.Location = new System.Drawing.Point(10, 67);
            this.m_checkLocalGit.Name = "m_checkLocalGit";
            this.m_checkLocalGit.Size = new System.Drawing.Size(143, 16);
            this.m_checkLocalGit.TabIndex = 0;
            this.m_checkLocalGit.Text = "Local Git Repository";
            this.m_checkLocalGit.UseVisualStyleBackColor = true;
            // 
            // m_checkRemoteGit
            // 
            this.m_checkRemoteGit.AutoSize = true;
            this.m_checkRemoteGit.Checked = true;
            this.m_checkRemoteGit.Location = new System.Drawing.Point(10, 14);
            this.m_checkRemoteGit.Name = "m_checkRemoteGit";
            this.m_checkRemoteGit.Size = new System.Drawing.Size(149, 16);
            this.m_checkRemoteGit.TabIndex = 0;
            this.m_checkRemoteGit.TabStop = true;
            this.m_checkRemoteGit.Text = "Remote Git Repository";
            this.m_checkRemoteGit.UseVisualStyleBackColor = true;
            this.m_checkRemoteGit.CheckedChanged += new System.EventHandler(this.m_checkRemoteGit_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.m_edPassword);
            this.tabPage2.Controls.Add(this.m_edLoginUser);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(605, 197);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SVN Repostitory";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.m_cbSvnWorkingDir);
            this.groupBox3.Controls.Add(this.m_cbSvnUrl);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.m_btnSvnChoose);
            this.groupBox3.Location = new System.Drawing.Point(10, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(590, 106);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // m_cbSvnWorkingDir
            // 
            this.m_cbSvnWorkingDir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_cbSvnWorkingDir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.m_cbSvnWorkingDir.FormattingEnabled = true;
            this.m_cbSvnWorkingDir.Items.AddRange(new object[] {
            "D:\\Git project\\nGit"});
            this.m_cbSvnWorkingDir.Location = new System.Drawing.Point(134, 66);
            this.m_cbSvnWorkingDir.Name = "m_cbSvnWorkingDir";
            this.m_cbSvnWorkingDir.Size = new System.Drawing.Size(367, 20);
            this.m_cbSvnWorkingDir.TabIndex = 13;
            // 
            // m_cbSvnUrl
            // 
            this.m_cbSvnUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_cbSvnUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.m_cbSvnUrl.FormattingEnabled = true;
            this.m_cbSvnUrl.Items.AddRange(new object[] {
            "http://CN15208-D-1/svn/fengzhengtest",
            "http://svn.bds.nhncorp.com/toolbar/toolbar_firefox/trunk/"});
            this.m_cbSvnUrl.Location = new System.Drawing.Point(134, 18);
            this.m_cbSvnUrl.Name = "m_cbSvnUrl";
            this.m_cbSvnUrl.Size = new System.Drawing.Size(367, 20);
            this.m_cbSvnUrl.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(27, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Local Directory:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "SVN Repository URL:";
            // 
            // m_btnSvnChoose
            // 
            this.m_btnSvnChoose.Location = new System.Drawing.Point(506, 65);
            this.m_btnSvnChoose.Name = "m_btnSvnChoose";
            this.m_btnSvnChoose.Size = new System.Drawing.Size(78, 20);
            this.m_btnSvnChoose.TabIndex = 15;
            this.m_btnSvnChoose.Text = "Choose..";
            this.m_btnSvnChoose.UseVisualStyleBackColor = true;
            this.m_btnSvnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // m_edPassword
            // 
            this.m_edPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_edPassword.Location = new System.Drawing.Point(148, 162);
            this.m_edPassword.Name = "m_edPassword";
            this.m_edPassword.Size = new System.Drawing.Size(366, 21);
            this.m_edPassword.TabIndex = 18;
            this.m_edPassword.Text = "15120";
            this.m_edPassword.UseSystemPasswordChar = true;
            // 
            // m_edLoginUser
            // 
            this.m_edLoginUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_edLoginUser.Location = new System.Drawing.Point(148, 122);
            this.m_edLoginUser.Name = "m_edLoginUser";
            this.m_edLoginUser.Size = new System.Drawing.Size(366, 21);
            this.m_edLoginUser.TabIndex = 18;
            this.m_edLoginUser.Text = "CN15120";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(47, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "Login Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(53, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "Login Account:";
            // 
            // m_edrShowCloneInfo
            // 
            this.m_edrShowCloneInfo.BackColor = System.Drawing.SystemColors.Info;
            this.m_edrShowCloneInfo.Location = new System.Drawing.Point(5, 256);
            this.m_edrShowCloneInfo.Multiline = true;
            this.m_edrShowCloneInfo.Name = "m_edrShowCloneInfo";
            this.m_edrShowCloneInfo.ReadOnly = true;
            this.m_edrShowCloneInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_edrShowCloneInfo.Size = new System.Drawing.Size(606, 184);
            this.m_edrShowCloneInfo.TabIndex = 2;
            // 
            // m_btnStop
            // 
            this.m_btnStop.Enabled = false;
            this.m_btnStop.Location = new System.Drawing.Point(386, 446);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(72, 27);
            this.m_btnStop.TabIndex = 3;
            this.m_btnStop.Text = "Stop";
            this.m_btnStop.UseVisualStyleBackColor = true;
            this.m_btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Location = new System.Drawing.Point(464, 446);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(72, 27);
            this.m_btnCancel.TabIndex = 3;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // m_btnClone
            // 
            this.m_btnClone.Location = new System.Drawing.Point(542, 446);
            this.m_btnClone.Name = "m_btnClone";
            this.m_btnClone.Size = new System.Drawing.Size(72, 27);
            this.m_btnClone.TabIndex = 3;
            this.m_btnClone.Text = "Clone";
            this.m_btnClone.UseVisualStyleBackColor = true;
            this.m_btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // labCloneInfo
            // 
            this.labCloneInfo.AutoSize = true;
            this.labCloneInfo.Location = new System.Drawing.Point(7, 441);
            this.labCloneInfo.Name = "labCloneInfo";
            this.labCloneInfo.Size = new System.Drawing.Size(107, 12);
            this.labCloneInfo.TabIndex = 4;
            this.labCloneInfo.Text = "Clone Information";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(221, 233);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(174, 16);
            this.checkBox1.TabIndex = 80;
            this.checkBox1.Text = "Update All Sub_module too";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 476);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labCloneInfo);
            this.Controls.Add(this.m_btnClone);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.m_edrShowCloneInfo);
            this.Controls.Add(this.tabClone);
            this.Controls.Add(this.progressBar);
            this.Name = "FormClone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clone Repository";
            this.Load += new System.EventHandler(this.FormClone_Load);
            this.tabClone.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TabControl tabClone;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox m_edrShowCloneInfo;
        private System.Windows.Forms.Button m_btnStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button m_btnGitChoose;
        private System.Windows.Forms.ComboBox m_cbLocalGitDirectory;
        private System.Windows.Forms.ComboBox m_cbReomoteGitUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton m_checkLocalGit;
        private System.Windows.Forms.RadioButton m_checkRemoteGit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button m_btnWorkingChoose;
        private System.Windows.Forms.ComboBox m_cbGitWorkingDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button m_btnSvnChoose;
        private System.Windows.Forms.TextBox m_edPassword;
        private System.Windows.Forms.TextBox m_edLoginUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnClone;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox m_cbSvnWorkingDir;
        private System.Windows.Forms.ComboBox m_cbSvnUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labCloneInfo;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}