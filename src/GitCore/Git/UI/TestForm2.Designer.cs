namespace Git.UI
{
    partial class TestForm2
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
            this.m_LocalControl = new Git.UI.CLocalOperCotrol();
            this.SuspendLayout();
            // 
            // m_LocalControl
            // 
            this.m_LocalControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_LocalControl.Location = new System.Drawing.Point(2, -7);
            this.m_LocalControl.Name = "m_LocalControl";
            this.m_LocalControl.Size = new System.Drawing.Size(880, 656);
            this.m_LocalControl.TabIndex = 0;
            // 
            // TestForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 644);
            this.Controls.Add(this.m_LocalControl);
            this.Name = "TestForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Local Working Area";
            this.ResumeLayout(false);

        }

        #endregion

        private CLocalOperCotrol m_LocalControl;

    }
}