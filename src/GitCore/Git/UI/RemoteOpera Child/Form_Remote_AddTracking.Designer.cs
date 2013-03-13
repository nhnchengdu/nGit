namespace Git.UI
{
    partial class Form_Remote_AddTracking
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
            this.m_txRemtoBranch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cobExistBranchList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txRemotName = new System.Windows.Forms.TextBox();
            this.m_rdoCreateNew = new System.Windows.Forms.RadioButton();
            this.m_rdoAttachExist = new System.Windows.Forms.RadioButton();
            this.m_txNewBranch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txRemtoBranch
            // 
            this.m_txRemtoBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txRemtoBranch.Location = new System.Drawing.Point(7, 71);
            this.m_txRemtoBranch.Name = "m_txRemtoBranch";
            this.m_txRemtoBranch.Size = new System.Drawing.Size(409, 21);
            this.m_txRemtoBranch.TabIndex = 133;
            this.m_txRemtoBranch.Text = "origin/testbranch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 131;
            this.label1.Text = "Remote Repisitory";
            // 
            // m_cobExistBranchList
            // 
            this.m_cobExistBranchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobExistBranchList.FormattingEnabled = true;
            this.m_cobExistBranchList.Items.AddRange(new object[] {
            "Master",
            "New Branch -1"});
            this.m_cobExistBranchList.Location = new System.Drawing.Point(28, 75);
            this.m_cobExistBranchList.Name = "m_cobExistBranchList";
            this.m_cobExistBranchList.Size = new System.Drawing.Size(388, 20);
            this.m_cobExistBranchList.TabIndex = 132;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 130;
            this.label4.Text = "Remote Tracking Branch";
            // 
            // m_txRemotName
            // 
            this.m_txRemotName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txRemotName.Location = new System.Drawing.Point(8, 32);
            this.m_txRemotName.Name = "m_txRemotName";
            this.m_txRemotName.Size = new System.Drawing.Size(408, 21);
            this.m_txRemotName.TabIndex = 133;
            this.m_txRemotName.Text = "Origin";
            // 
            // m_rdoCreateNew
            // 
            this.m_rdoCreateNew.AutoSize = true;
            this.m_rdoCreateNew.Location = new System.Drawing.Point(8, 13);
            this.m_rdoCreateNew.Name = "m_rdoCreateNew";
            this.m_rdoCreateNew.Size = new System.Drawing.Size(317, 16);
            this.m_rdoCreateNew.TabIndex = 134;
            this.m_rdoCreateNew.Text = "Create a new branch and track remote, then switch";
            this.m_rdoCreateNew.UseVisualStyleBackColor = true;
            this.m_rdoCreateNew.CheckedChanged += new System.EventHandler(this.m_rdoCreateNew_CheckedChanged);
            // 
            // m_rdoAttachExist
            // 
            this.m_rdoAttachExist.AutoSize = true;
            this.m_rdoAttachExist.Checked = true;
            this.m_rdoAttachExist.Location = new System.Drawing.Point(8, 55);
            this.m_rdoAttachExist.Name = "m_rdoAttachExist";
            this.m_rdoAttachExist.Size = new System.Drawing.Size(245, 16);
            this.m_rdoAttachExist.TabIndex = 134;
            this.m_rdoAttachExist.TabStop = true;
            this.m_rdoAttachExist.Text = "Select a exist branch to track remote";
            this.m_rdoAttachExist.UseVisualStyleBackColor = true;
            // 
            // m_txNewBranch
            // 
            this.m_txNewBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txNewBranch.Enabled = false;
            this.m_txNewBranch.Location = new System.Drawing.Point(28, 31);
            this.m_txNewBranch.Name = "m_txNewBranch";
            this.m_txNewBranch.Size = new System.Drawing.Size(388, 21);
            this.m_txNewBranch.TabIndex = 133;
            this.m_txNewBranch.Text = "origin/testbranch";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdoAttachExist);
            this.groupBox1.Controls.Add(this.m_rdoCreateNew);
            this.groupBox1.Controls.Add(this.m_txNewBranch);
            this.groupBox1.Controls.Add(this.m_cobExistBranchList);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(5, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 103);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, -2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 131;
            this.label5.Text = "Tracking";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_txRemotName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_txRemtoBranch);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 100);
            this.groupBox2.TabIndex = 135;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 131;
            this.label3.Text = "Source";
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(350, 290);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 139;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 136;
            this.label7.Text = "Operation Resutl";
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(350, 244);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 138;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(5, 235);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(345, 87);
            this.m_txOperRes.TabIndex = 137;
            // 
            // Form_Remote_AddTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 327);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Remote_AddTracking";
            this.Text = "Add Tracking";
            this.Load += new System.EventHandler(this.Form_Remote_AddTracking_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_txRemtoBranch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cobExistBranchList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txRemotName;
        private System.Windows.Forms.RadioButton m_rdoCreateNew;
        private System.Windows.Forms.RadioButton m_rdoAttachExist;
        private System.Windows.Forms.TextBox m_txNewBranch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.TextBox m_txOperRes;
    }
}