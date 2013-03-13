namespace Git.UI
{
    partial class FormCommit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommit));
            this.m_clbFileList = new System.Windows.Forms.CheckedListBox();
            this.m_txMessage = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnCommit = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_clbFileList
            // 
            this.m_clbFileList.FormattingEnabled = true;
            this.m_clbFileList.Location = new System.Drawing.Point(6, 20);
            this.m_clbFileList.Name = "m_clbFileList";
            this.m_clbFileList.Size = new System.Drawing.Size(592, 164);
            this.m_clbFileList.Sorted = true;
            this.m_clbFileList.TabIndex = 0;
            this.m_clbFileList.ThreeDCheckBoxes = true;
            // 
            // m_txMessage
            // 
            this.m_txMessage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_txMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txMessage.Location = new System.Drawing.Point(11, 220);
            this.m_txMessage.Multiline = true;
            this.m_txMessage.Name = "m_txMessage";
            this.m_txMessage.Size = new System.Drawing.Size(591, 82);
            this.m_txMessage.TabIndex = 2;
            this.m_txMessage.Text = "Project:\r\nTaske Id:\r\nChange:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 306);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(156, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Amend foregoing commit";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(18, 328);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(126, 16);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "push after commit";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Commit Message";
            // 
            // m_btnCommit
            // 
            this.m_btnCommit.Location = new System.Drawing.Point(510, 322);
            this.m_btnCommit.Name = "m_btnCommit";
            this.m_btnCommit.Size = new System.Drawing.Size(93, 22);
            this.m_btnCommit.TabIndex = 6;
            this.m_btnCommit.Text = "Commit";
            this.m_btnCommit.UseVisualStyleBackColor = true;
            this.m_btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Location = new System.Drawing.Point(403, 322);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(93, 22);
            this.m_btnCancel.TabIndex = 6;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_clbFileList);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 197);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commit Files";
            // 
            // FormCommit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 350);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnCommit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.m_txMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCommit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCommit";
            this.Load += new System.EventHandler(this.FormCommit_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox m_clbFileList;
        private System.Windows.Forms.TextBox m_txMessage;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_btnCommit;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}