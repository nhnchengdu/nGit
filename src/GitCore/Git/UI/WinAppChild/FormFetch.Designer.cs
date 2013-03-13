namespace Git.UI
{
    partial class FormFetch
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
            this.m_checkIncludSubModule = new System.Windows.Forms.CheckBox();
            this.m_cobRemoteRepoLists = new System.Windows.Forms.ComboBox();
            this.m_btnStop = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 12);
            this.label1.TabIndex = 77;
            this.label1.Text = "Choose Remote Reposistory";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_checkIncludSubModule);
            this.groupBox2.Controls.Add(this.m_cobRemoteRepoLists);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 70);
            this.groupBox2.TabIndex = 117;
            this.groupBox2.TabStop = false;
            // 
            // m_checkIncludSubModule
            // 
            this.m_checkIncludSubModule.AutoSize = true;
            this.m_checkIncludSubModule.Enabled = false;
            this.m_checkIncludSubModule.Location = new System.Drawing.Point(307, 33);
            this.m_checkIncludSubModule.Name = "m_checkIncludSubModule";
            this.m_checkIncludSubModule.Size = new System.Drawing.Size(174, 16);
            this.m_checkIncludSubModule.TabIndex = 79;
            this.m_checkIncludSubModule.Text = "Update All Sub_module too";
            this.m_checkIncludSubModule.UseVisualStyleBackColor = true;
            // 
            // m_cobRemoteRepoLists
            // 
            this.m_cobRemoteRepoLists.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_cobRemoteRepoLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobRemoteRepoLists.FormattingEnabled = true;
            this.m_cobRemoteRepoLists.Location = new System.Drawing.Point(6, 31);
            this.m_cobRemoteRepoLists.Name = "m_cobRemoteRepoLists";
            this.m_cobRemoteRepoLists.Size = new System.Drawing.Size(273, 20);
            this.m_cobRemoteRepoLists.TabIndex = 78;
            // 
            // m_btnStop
            // 
            this.m_btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnStop.Enabled = false;
            this.m_btnStop.Location = new System.Drawing.Point(217, 289);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(75, 25);
            this.m_btnStop.TabIndex = 123;
            this.m_btnStop.Text = "Stop";
            this.m_btnStop.UseVisualStyleBackColor = true;
            this.m_btnStop.Click += new System.EventHandler(this.m_btnStop_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(327, 289);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 122;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 119;
            this.label7.Text = "Operation Resutl";
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(108, 289);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 121;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(3, 90);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(491, 195);
            this.m_txOperRes.TabIndex = 120;
            // 
            // FormFetch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 318);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFetch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fetch All";
            this.Load += new System.EventHandler(this.Form_Remote_Fetch_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox m_checkIncludSubModule;
        private System.Windows.Forms.ComboBox m_cobRemoteRepoLists;
        private System.Windows.Forms.Button m_btnStop;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.TextBox m_txOperRes;

    }
}