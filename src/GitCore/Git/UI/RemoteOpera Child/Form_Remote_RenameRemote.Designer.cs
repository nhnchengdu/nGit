namespace Git.UI
{
    partial class Form_Remote_RenameRemote
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cobRemoteRepoLists = new System.Windows.Forms.ComboBox();
            this.m_txNewName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 123;
            this.label1.Text = "Choose Remote Repisitory";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_cobRemoteRepoLists);
            this.groupBox2.Controls.Add(this.m_txNewName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 100);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            // 
            // m_cobRemoteRepoLists
            // 
            this.m_cobRemoteRepoLists.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_cobRemoteRepoLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobRemoteRepoLists.FormattingEnabled = true;
            this.m_cobRemoteRepoLists.Items.AddRange(new object[] {
            "Master",
            "New Branch -1"});
            this.m_cobRemoteRepoLists.Location = new System.Drawing.Point(6, 28);
            this.m_cobRemoteRepoLists.Name = "m_cobRemoteRepoLists";
            this.m_cobRemoteRepoLists.Size = new System.Drawing.Size(404, 20);
            this.m_cobRemoteRepoLists.TabIndex = 130;
            this.m_cobRemoteRepoLists.TextChanged += new System.EventHandler(this.m_cobRemoteRepoLists_TextChanged);
            // 
            // m_txNewName
            // 
            this.m_txNewName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txNewName.Location = new System.Drawing.Point(6, 68);
            this.m_txNewName.Name = "m_txNewName";
            this.m_txNewName.Size = new System.Drawing.Size(404, 21);
            this.m_txNewName.TabIndex = 129;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 123;
            this.label4.Text = "New Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 129;
            this.label7.Text = "Operation Resutl";
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(8, 120);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(344, 61);
            this.m_txOperRes.TabIndex = 128;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(353, 154);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(59, 25);
            this.m_btnCancel.TabIndex = 127;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(353, 123);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(59, 25);
            this.m_btnRun.TabIndex = 126;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // Form_Remote_RenameRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 188);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form_Remote_RenameRemote";
            this.Text = "Rename Remote";
            this.Load += new System.EventHandler(this.Form_Remote_RenameRemote_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txNewName;
        private System.Windows.Forms.ComboBox m_cobRemoteRepoLists;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnRun;
    }
}