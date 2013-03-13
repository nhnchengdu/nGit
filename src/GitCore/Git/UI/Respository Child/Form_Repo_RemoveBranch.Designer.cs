namespace Git.UI
{
    partial class Form_Repo_RemoveBranch
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
            this.m_cobBranchLists = new System.Windows.Forms.ComboBox();
            this.m_txSelectedSHA = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txDate = new System.Windows.Forms.TextBox();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.m_labWarning2 = new System.Windows.Forms.Label();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.m_labWarning1 = new System.Windows.Forms.Label();
            this.m_txAuthor = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_checkDelUnMerge = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txMsg = new System.Windows.Forms.TextBox();
            this.m_picWarning = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picWarning)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cobBranchLists
            // 
            this.m_cobBranchLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobBranchLists.FormattingEnabled = true;
            this.m_cobBranchLists.Items.AddRange(new object[] {
            "Master",
            "New Branch -1"});
            this.m_cobBranchLists.Location = new System.Drawing.Point(85, 20);
            this.m_cobBranchLists.Name = "m_cobBranchLists";
            this.m_cobBranchLists.Size = new System.Drawing.Size(197, 20);
            this.m_cobBranchLists.TabIndex = 48;
            this.m_cobBranchLists.TextChanged += new System.EventHandler(this.m_cobBranchLists_TextChanged);
            // 
            // m_txSelectedSHA
            // 
            this.m_txSelectedSHA.AcceptsTab = true;
            this.m_txSelectedSHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSelectedSHA.Enabled = false;
            this.m_txSelectedSHA.Location = new System.Drawing.Point(33, 17);
            this.m_txSelectedSHA.Multiline = true;
            this.m_txSelectedSHA.Name = "m_txSelectedSHA";
            this.m_txSelectedSHA.Size = new System.Drawing.Size(249, 16);
            this.m_txSelectedSHA.TabIndex = 64;
            this.m_txSelectedSHA.Text = "00000000000000000000000000000000000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 77;
            this.label7.Text = "Operation Resutl";
            // 
            // m_txDate
            // 
            this.m_txDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txDate.Enabled = false;
            this.m_txDate.Location = new System.Drawing.Point(45, 59);
            this.m_txDate.Multiline = true;
            this.m_txDate.Name = "m_txDate";
            this.m_txDate.Size = new System.Drawing.Size(237, 16);
            this.m_txDate.TabIndex = 65;
            this.m_txDate.Text = "2012-04-05";
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(473, 169);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 79;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "SHA:";
            // 
            // m_labWarning2
            // 
            this.m_labWarning2.AutoSize = true;
            this.m_labWarning2.ForeColor = System.Drawing.Color.Red;
            this.m_labWarning2.Location = new System.Drawing.Point(41, 25);
            this.m_labWarning2.Name = "m_labWarning2";
            this.m_labWarning2.Size = new System.Drawing.Size(197, 12);
            this.m_labWarning2.TabIndex = 75;
            this.m_labWarning2.Text = "And some commits maybe be losed.";
            this.m_labWarning2.Visible = false;
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(3, 167);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(454, 66);
            this.m_txOperRes.TabIndex = 78;
            // 
            // m_labWarning1
            // 
            this.m_labWarning1.AutoSize = true;
            this.m_labWarning1.ForeColor = System.Drawing.Color.Red;
            this.m_labWarning1.Location = new System.Drawing.Point(41, 9);
            this.m_labWarning1.Name = "m_labWarning1";
            this.m_labWarning1.Size = new System.Drawing.Size(197, 12);
            this.m_labWarning1.TabIndex = 75;
            this.m_labWarning1.Text = "Warning: It\'s a danger operation";
            this.m_labWarning1.Visible = false;
            // 
            // m_txAuthor
            // 
            this.m_txAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txAuthor.Enabled = false;
            this.m_txAuthor.Location = new System.Drawing.Point(54, 38);
            this.m_txAuthor.Multiline = true;
            this.m_txAuthor.Name = "m_txAuthor";
            this.m_txAuthor.Size = new System.Drawing.Size(228, 16);
            this.m_txAuthor.TabIndex = 66;
            this.m_txAuthor.Text = "fengzheng";
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(473, 200);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 80;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_checkDelUnMerge
            // 
            this.m_checkDelUnMerge.AutoSize = true;
            this.m_checkDelUnMerge.Location = new System.Drawing.Point(6, -1);
            this.m_checkDelUnMerge.Name = "m_checkDelUnMerge";
            this.m_checkDelUnMerge.Size = new System.Drawing.Size(180, 16);
            this.m_checkDelUnMerge.TabIndex = 58;
            this.m_checkDelUnMerge.Text = "Delete the UnMerged Branch";
            this.m_checkDelUnMerge.UseVisualStyleBackColor = true;
            this.m_checkDelUnMerge.CheckedChanged += new System.EventHandler(this.m_checkDelUnMerge_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_txSelectedSHA);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.m_txMsg);
            this.groupBox2.Controls.Add(this.m_txAuthor);
            this.groupBox2.Controls.Add(this.m_txDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(3, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 82);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target Commit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 63;
            this.label1.Text = "Data:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 61;
            this.label5.Text = "Author:";
            // 
            // m_txMsg
            // 
            this.m_txMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txMsg.Enabled = false;
            this.m_txMsg.Location = new System.Drawing.Point(288, 17);
            this.m_txMsg.Multiline = true;
            this.m_txMsg.Name = "m_txMsg";
            this.m_txMsg.Size = new System.Drawing.Size(263, 58);
            this.m_txMsg.TabIndex = 63;
            this.m_txMsg.Text = "this commit is for test...........................";
            // 
            // m_picWarning
            // 
            this.m_picWarning.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_picWarning.Location = new System.Drawing.Point(6, 10);
            this.m_picWarning.Name = "m_picWarning";
            this.m_picWarning.Size = new System.Drawing.Size(31, 29);
            this.m_picWarning.TabIndex = 4;
            this.m_picWarning.TabStop = false;
            this.m_picWarning.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "Branch Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_cobBranchLists);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.m_checkDelUnMerge);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 55);
            this.groupBox3.TabIndex = 75;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_picWarning);
            this.groupBox4.Controls.Add(this.m_labWarning2);
            this.groupBox4.Controls.Add(this.m_labWarning1);
            this.groupBox4.Location = new System.Drawing.Point(288, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(263, 44);
            this.groupBox4.TabIndex = 76;
            this.groupBox4.TabStop = false;
            // 
            // Form_Repo_RemoveBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 237);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form_Repo_RemoveBranch";
            this.Text = "Remove Branch";
            this.Load += new System.EventHandler(this.Form_Repo_RemoveBranch_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picWarning)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox m_cobBranchLists;
        private System.Windows.Forms.TextBox m_txSelectedSHA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_txDate;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label m_labWarning2;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.Label m_labWarning1;
        private System.Windows.Forms.TextBox m_txAuthor;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.CheckBox m_checkDelUnMerge;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_txMsg;
        private System.Windows.Forms.PictureBox m_picWarning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}