namespace Git.UI
{
    partial class FormInitRepo
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
            this.m_chkPersonal = new System.Windows.Forms.RadioButton();
            this.m_btnInit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_chkCentral = new System.Windows.Forms.RadioButton();
            this.m_btnBrowse = new System.Windows.Forms.Button();
            this.m_Directory = new System.Windows.Forms.ComboBox();
            this.m_rbSelecteDir = new System.Windows.Forms.RadioButton();
            this.m_rbSolutionDir = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_chkPersonal
            // 
            this.m_chkPersonal.AutoSize = true;
            this.m_chkPersonal.Checked = true;
            this.m_chkPersonal.Location = new System.Drawing.Point(6, 19);
            this.m_chkPersonal.Name = "m_chkPersonal";
            this.m_chkPersonal.Size = new System.Drawing.Size(137, 16);
            this.m_chkPersonal.TabIndex = 0;
            this.m_chkPersonal.TabStop = true;
            this.m_chkPersonal.Text = "Personal repository";
            this.m_chkPersonal.UseVisualStyleBackColor = true;
            // 
            // m_btnInit
            // 
            this.m_btnInit.Location = new System.Drawing.Point(405, 132);
            this.m_btnInit.Name = "m_btnInit";
            this.m_btnInit.Size = new System.Drawing.Size(79, 32);
            this.m_btnInit.TabIndex = 9;
            this.m_btnInit.Text = "Initialize";
            this.m_btnInit.UseVisualStyleBackColor = true;
            this.m_btnInit.Click += new System.EventHandler(this.Init_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_chkCentral);
            this.groupBox1.Controls.Add(this.m_chkPersonal);
            this.groupBox1.Location = new System.Drawing.Point(11, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 64);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Repository type";
            // 
            // m_chkCentral
            // 
            this.m_chkCentral.AutoSize = true;
            this.m_chkCentral.Location = new System.Drawing.Point(6, 42);
            this.m_chkCentral.Name = "m_chkCentral";
            this.m_chkCentral.Size = new System.Drawing.Size(365, 16);
            this.m_chkCentral.TabIndex = 1;
            this.m_chkCentral.Text = "Central repository, no working dir  (--bare --shared=all)";
            this.m_chkCentral.UseVisualStyleBackColor = true;
            // 
            // m_btnBrowse
            // 
            this.m_btnBrowse.Location = new System.Drawing.Point(405, 71);
            this.m_btnBrowse.Name = "m_btnBrowse";
            this.m_btnBrowse.Size = new System.Drawing.Size(79, 28);
            this.m_btnBrowse.TabIndex = 7;
            this.m_btnBrowse.Text = "Browse";
            this.m_btnBrowse.UseVisualStyleBackColor = true;
            this.m_btnBrowse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // m_Directory
            // 
            this.m_Directory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_Directory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.m_Directory.FormattingEnabled = true;
            this.m_Directory.Location = new System.Drawing.Point(15, 64);
            this.m_Directory.Name = "m_Directory";
            this.m_Directory.Size = new System.Drawing.Size(368, 20);
            this.m_Directory.TabIndex = 6;
            // 
            // m_rbSelecteDir
            // 
            this.m_rbSelecteDir.AutoSize = true;
            this.m_rbSelecteDir.Location = new System.Drawing.Point(6, 42);
            this.m_rbSelecteDir.Name = "m_rbSelecteDir";
            this.m_rbSelecteDir.Size = new System.Drawing.Size(179, 16);
            this.m_rbSelecteDir.TabIndex = 10;
            this.m_rbSelecteDir.TabStop = true;
            this.m_rbSelecteDir.Text = "Select a Target Directory ";
            this.m_rbSelecteDir.UseVisualStyleBackColor = true;
            this.m_rbSelecteDir.CheckedChanged += new System.EventHandler(this.rbSelecteDir_CheckedChanged);
            // 
            // m_rbSolutionDir
            // 
            this.m_rbSolutionDir.AutoSize = true;
            this.m_rbSolutionDir.Checked = true;
            this.m_rbSolutionDir.Location = new System.Drawing.Point(6, 20);
            this.m_rbSolutionDir.Name = "m_rbSolutionDir";
            this.m_rbSolutionDir.Size = new System.Drawing.Size(179, 16);
            this.m_rbSolutionDir.TabIndex = 10;
            this.m_rbSolutionDir.TabStop = true;
            this.m_rbSolutionDir.Text = "Current Solution Directory";
            this.m_rbSolutionDir.UseVisualStyleBackColor = true;
            this.m_rbSolutionDir.CheckedChanged += new System.EventHandler(this.rbSolutionDir_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.m_rbSolutionDir);
            this.groupBox2.Controls.Add(this.m_rbSelecteDir);
            this.groupBox2.Controls.Add(this.m_Directory);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(11, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 96);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reopository Directory";
            // 
            // FormInitRepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 182);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_btnInit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInitRepo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Repository";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormInitRepo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton m_chkPersonal;
        private System.Windows.Forms.Button m_btnInit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton m_chkCentral;
        private System.Windows.Forms.Button m_btnBrowse;
        private System.Windows.Forms.ComboBox m_Directory;
        private System.Windows.Forms.RadioButton m_rbSelecteDir;
        private System.Windows.Forms.RadioButton m_rbSolutionDir;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}