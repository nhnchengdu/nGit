namespace Git.UI
{
    partial class FormAdd
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
            this.m_lbUnstagFile = new System.Windows.Forms.CheckedListBox();
            this.m_btnAddAll = new System.Windows.Forms.Button();
            this.m_btnAddSelected = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_lbUnstagFile
            // 
            this.m_lbUnstagFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lbUnstagFile.FormattingEnabled = true;
            this.m_lbUnstagFile.HorizontalScrollbar = true;
            this.m_lbUnstagFile.Items.AddRange(new object[] {
            "File 1",
            "File 2"});
            this.m_lbUnstagFile.Location = new System.Drawing.Point(8, 6);
            this.m_lbUnstagFile.Name = "m_lbUnstagFile";
            this.m_lbUnstagFile.Size = new System.Drawing.Size(360, 324);
            this.m_lbUnstagFile.TabIndex = 5;
            // 
            // m_btnAddAll
            // 
            this.m_btnAddAll.Location = new System.Drawing.Point(377, 256);
            this.m_btnAddAll.Name = "m_btnAddAll";
            this.m_btnAddAll.Size = new System.Drawing.Size(90, 27);
            this.m_btnAddAll.TabIndex = 6;
            this.m_btnAddAll.Text = "Add All";
            this.m_btnAddAll.UseVisualStyleBackColor = true;
            this.m_btnAddAll.Click += new System.EventHandler(this.m_btnAddAll_Click);
            // 
            // m_btnAddSelected
            // 
            this.m_btnAddSelected.Location = new System.Drawing.Point(377, 296);
            this.m_btnAddSelected.Name = "m_btnAddSelected";
            this.m_btnAddSelected.Size = new System.Drawing.Size(90, 27);
            this.m_btnAddSelected.TabIndex = 6;
            this.m_btnAddSelected.Text = "Add Selected";
            this.m_btnAddSelected.UseVisualStyleBackColor = true;
            this.m_btnAddSelected.Click += new System.EventHandler(this.m_btnAddSelected_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Location = new System.Drawing.Point(377, 216);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(90, 27);
            this.m_btnCancel.TabIndex = 6;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 335);
            this.Controls.Add(this.m_btnAddSelected);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnAddAll);
            this.Controls.Add(this.m_lbUnstagFile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Files";
            this.Load += new System.EventHandler(this.FormAdd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox m_lbUnstagFile;
        private System.Windows.Forms.Button m_btnAddAll;
        private System.Windows.Forms.Button m_btnAddSelected;
        private System.Windows.Forms.Button m_btnCancel;

    }
}