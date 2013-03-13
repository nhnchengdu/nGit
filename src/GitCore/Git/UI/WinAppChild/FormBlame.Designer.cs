namespace Git.UI
{
    partial class FormBlame
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
            this.m_rtxHistory = new System.Windows.Forms.RichTextBox();
            this.m_txInfo = new System.Windows.Forms.TextBox();
            this.m_rtxContent = new Git.UI.CRichTextBoxEx();
            this.SuspendLayout();
            // 
            // m_rtxHistory
            // 
            this.m_rtxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_rtxHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_rtxHistory.Enabled = false;
            this.m_rtxHistory.Location = new System.Drawing.Point(5, 8);
            this.m_rtxHistory.Name = "m_rtxHistory";
            this.m_rtxHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_rtxHistory.Size = new System.Drawing.Size(241, 358);
            this.m_rtxHistory.TabIndex = 0;
            this.m_rtxHistory.Text = "";
            this.m_rtxHistory.WordWrap = false;
            // 
            // m_txInfo
            // 
            this.m_txInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txInfo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_txInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txInfo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txInfo.ForeColor = System.Drawing.Color.Green;
            this.m_txInfo.Location = new System.Drawing.Point(5, 365);
            this.m_txInfo.Name = "m_txInfo";
            this.m_txInfo.Size = new System.Drawing.Size(725, 23);
            this.m_txInfo.TabIndex = 1;
            // 
            // m_rtxContent
            // 
            this.m_rtxContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rtxContent.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.m_rtxContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_rtxContent.Location = new System.Drawing.Point(82, 8);
            this.m_rtxContent.m_mOtherRichTextBox = null;
            this.m_rtxContent.Name = "m_rtxContent";
            this.m_rtxContent.Size = new System.Drawing.Size(648, 358);
            this.m_rtxContent.TabIndex = 0;
            this.m_rtxContent.Text = "";
            this.m_rtxContent.WordWrap = false;
            this.m_rtxContent.VScroll += new System.EventHandler(this.m_rtxContent_VScroll);
            this.m_rtxContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_rtxContent_MouseClick);
            // 
            // FormBlame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 394);
            this.Controls.Add(this.m_txInfo);
            this.Controls.Add(this.m_rtxContent);
            this.Controls.Add(this.m_rtxHistory);
            this.Name = "FormBlame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blame History";
            this.Load += new System.EventHandler(this.FormBlame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Git.UI.CRichTextBoxEx m_rtxContent;
        private System.Windows.Forms.RichTextBox m_rtxHistory;
        private System.Windows.Forms.TextBox m_txInfo;
    }
}