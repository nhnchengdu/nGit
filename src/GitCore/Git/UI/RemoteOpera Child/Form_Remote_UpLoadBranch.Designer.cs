namespace Git.UI
{
    partial class Form_Remote_UpLoadBranch
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
            this.m_cobExistBranchList = new System.Windows.Forms.ComboBox();
            this.m_txRemoteRepo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.m_btnStop = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_cobExistBranchList);
            this.groupBox2.Controls.Add(this.m_txRemoteRepo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 93);
            this.groupBox2.TabIndex = 129;
            this.groupBox2.TabStop = false;
            // 
            // m_cobExistBranchList
            // 
            this.m_cobExistBranchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobExistBranchList.FormattingEnabled = true;
            this.m_cobExistBranchList.Items.AddRange(new object[] {
            "Master",
            "New Branch -1"});
            this.m_cobExistBranchList.Location = new System.Drawing.Point(8, 62);
            this.m_cobExistBranchList.Name = "m_cobExistBranchList";
            this.m_cobExistBranchList.Size = new System.Drawing.Size(417, 20);
            this.m_cobExistBranchList.TabIndex = 133;
            this.m_cobExistBranchList.TextChanged += new System.EventHandler(this.m_cobExistBranchList_TextChanged);
            // 
            // m_txRemoteRepo
            // 
            this.m_txRemoteRepo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txRemoteRepo.Enabled = false;
            this.m_txRemoteRepo.Location = new System.Drawing.Point(9, 23);
            this.m_txRemoteRepo.Name = "m_txRemoteRepo";
            this.m_txRemoteRepo.Size = new System.Drawing.Size(174, 21);
            this.m_txRemoteRepo.TabIndex = 96;
            this.m_txRemoteRepo.Text = "Origin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "Remote Reposistory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 77;
            this.label1.Text = "Select a New Branch";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 138;
            this.label7.Text = "Operation Resutl";
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(3, 112);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(345, 114);
            this.m_txOperRes.TabIndex = 139;
            // 
            // m_btnStop
            // 
            this.m_btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnStop.Enabled = false;
            this.m_btnStop.Location = new System.Drawing.Point(356, 160);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(75, 25);
            this.m_btnStop.TabIndex = 142;
            this.m_btnStop.Text = "Stop";
            this.m_btnStop.UseVisualStyleBackColor = true;
            this.m_btnStop.Click += new System.EventHandler(this.m_btnStop_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(355, 197);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 141;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(356, 120);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 140;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // Form_Remote_UpLoadBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 233);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form_Remote_UpLoadBranch";
            this.Text = "UpLoad Branch";
            this.Load += new System.EventHandler(this.Form_Remote_UpLoadBranch_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox m_txRemoteRepo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cobExistBranchList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.Button m_btnStop;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnRun;

    }
}