namespace Git.UI
{
    partial class FormUnstage
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
            this.m_lbStagedFile = new System.Windows.Forms.CheckedListBox();
            this.m_btnDelSelected = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnDelAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_lbStagedFile
            // 
            this.m_lbStagedFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lbStagedFile.FormattingEnabled = true;
            this.m_lbStagedFile.HorizontalScrollbar = true;
            this.m_lbStagedFile.Items.AddRange(new object[] {
            "File 1",
            "File 2"});
            this.m_lbStagedFile.Location = new System.Drawing.Point(3, 7);
            this.m_lbStagedFile.Name = "m_lbStagedFile";
            this.m_lbStagedFile.Size = new System.Drawing.Size(360, 308);
            this.m_lbStagedFile.TabIndex = 7;
            // 
            // m_btnDelSelected
            // 
            this.m_btnDelSelected.Location = new System.Drawing.Point(369, 284);
            this.m_btnDelSelected.Name = "m_btnDelSelected";
            this.m_btnDelSelected.Size = new System.Drawing.Size(90, 27);
            this.m_btnDelSelected.TabIndex = 10;
            this.m_btnDelSelected.Text = "UnStage";
            this.m_btnDelSelected.UseVisualStyleBackColor = true;
            this.m_btnDelSelected.Click += new System.EventHandler(this.m_btnDelSelected_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Location = new System.Drawing.Point(369, 204);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(90, 27);
            this.m_btnCancel.TabIndex = 9;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnDelAll
            // 
            this.m_btnDelAll.Location = new System.Drawing.Point(369, 244);
            this.m_btnDelAll.Name = "m_btnDelAll";
            this.m_btnDelAll.Size = new System.Drawing.Size(90, 27);
            this.m_btnDelAll.TabIndex = 8;
            this.m_btnDelAll.Text = "UnStage All";
            this.m_btnDelAll.UseVisualStyleBackColor = true;
            this.m_btnDelAll.Click += new System.EventHandler(this.m_btnDelAll_Click);
            // 
            // FormUnstage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 326);
            this.Controls.Add(this.m_btnDelSelected);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnDelAll);
            this.Controls.Add(this.m_lbStagedFile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUnstage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnStage Files";
            this.Load += new System.EventHandler(this.FormUnstage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox m_lbStagedFile;
        private System.Windows.Forms.Button m_btnDelSelected;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnDelAll;
    }
}