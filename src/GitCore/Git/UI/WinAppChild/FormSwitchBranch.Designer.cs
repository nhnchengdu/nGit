namespace Git.UI
{
    partial class FormSwitchBranch
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
            this.label9 = new System.Windows.Forms.Label();
            this.m_picWarning = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_cobBranchLists = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txCurBranch = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_labWarning3 = new System.Windows.Forms.Label();
            this.m_labWarning2 = new System.Windows.Forms.Label();
            this.m_labWarning1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_picWarning)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 60;
            this.label9.Text = "Current Branch:";
            // 
            // m_picWarning
            // 
            this.m_picWarning.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_picWarning.Location = new System.Drawing.Point(352, -12);
            this.m_picWarning.Name = "m_picWarning";
            this.m_picWarning.Size = new System.Drawing.Size(31, 29);
            this.m_picWarning.TabIndex = 4;
            this.m_picWarning.TabStop = false;
            this.m_picWarning.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_picWarning);
            this.groupBox3.Controls.Add(this.m_cobBranchLists);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.m_txCurBranch);
            this.groupBox3.Location = new System.Drawing.Point(5, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 68);
            this.groupBox3.TabIndex = 81;
            this.groupBox3.TabStop = false;
            // 
            // m_cobBranchLists
            // 
            this.m_cobBranchLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobBranchLists.FormattingEnabled = true;
            this.m_cobBranchLists.Items.AddRange(new object[] {
            "Master",
            "New Branch -1"});
            this.m_cobBranchLists.Location = new System.Drawing.Point(102, 39);
            this.m_cobBranchLists.Name = "m_cobBranchLists";
            this.m_cobBranchLists.Size = new System.Drawing.Size(221, 20);
            this.m_cobBranchLists.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "Target Branch:";
            // 
            // m_txCurBranch
            // 
            this.m_txCurBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txCurBranch.Enabled = false;
            this.m_txCurBranch.Location = new System.Drawing.Point(104, 16);
            this.m_txCurBranch.Multiline = true;
            this.m_txCurBranch.Name = "m_txCurBranch";
            this.m_txCurBranch.Size = new System.Drawing.Size(211, 18);
            this.m_txCurBranch.TabIndex = 66;
            this.m_txCurBranch.Text = "fengzheng";
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(468, 127);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 86;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 83;
            this.label7.Text = "Operation Resutl";
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(468, 96);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 85;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(8, 94);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(454, 66);
            this.m_txOperRes.TabIndex = 84;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.m_labWarning3);
            this.groupBox4.Controls.Add(this.m_labWarning2);
            this.groupBox4.Controls.Add(this.m_labWarning1);
            this.groupBox4.Location = new System.Drawing.Point(340, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(210, 68);
            this.groupBox4.TabIndex = 87;
            this.groupBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(6, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 29);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // m_labWarning3
            // 
            this.m_labWarning3.AutoSize = true;
            this.m_labWarning3.ForeColor = System.Drawing.Color.Red;
            this.m_labWarning3.Location = new System.Drawing.Point(6, 42);
            this.m_labWarning3.Name = "m_labWarning3";
            this.m_labWarning3.Size = new System.Drawing.Size(203, 12);
            this.m_labWarning3.TabIndex = 75;
            this.m_labWarning3.Text = "Working Tree and Index Area......";
            // 
            // m_labWarning2
            // 
            this.m_labWarning2.AutoSize = true;
            this.m_labWarning2.ForeColor = System.Drawing.Color.Red;
            this.m_labWarning2.Location = new System.Drawing.Point(41, 25);
            this.m_labWarning2.Name = "m_labWarning2";
            this.m_labWarning2.Size = new System.Drawing.Size(161, 12);
            this.m_labWarning2.TabIndex = 75;
            this.m_labWarning2.Text = "This operation will change";
            // 
            // m_labWarning1
            // 
            this.m_labWarning1.AutoSize = true;
            this.m_labWarning1.ForeColor = System.Drawing.Color.Red;
            this.m_labWarning1.Location = new System.Drawing.Point(41, 9);
            this.m_labWarning1.Name = "m_labWarning1";
            this.m_labWarning1.Size = new System.Drawing.Size(53, 12);
            this.m_labWarning1.TabIndex = 75;
            this.m_labWarning1.Text = "Warning:";
            // 
            // FormSwitchBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 167);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.m_txOperRes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSwitchBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Switch Branch To";
            this.Load += new System.EventHandler(this.Form_Repo_SwitchBranch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_picWarning)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox m_picWarning;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox m_cobBranchLists;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.TextBox m_txCurBranch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label m_labWarning2;
        private System.Windows.Forms.Label m_labWarning1;
        private System.Windows.Forms.Label m_labWarning3;
    }
}