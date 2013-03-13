namespace Git.UI
{
    partial class TestForm3
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
            this.m_RemoteControl = new Git.UI.CRemoteControl();
            this.SuspendLayout();
            // 
            // m_RemoteControl
            // 
            this.m_RemoteControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_RemoteControl.BackColor = System.Drawing.SystemColors.Control;
            this.m_RemoteControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_RemoteControl.Location = new System.Drawing.Point(4, 4);
            this.m_RemoteControl.Name = "m_RemoteControl";
            this.m_RemoteControl.Size = new System.Drawing.Size(863, 585);
            this.m_RemoteControl.TabIndex = 0;
            // 
            // TestForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 591);
            this.Controls.Add(this.m_RemoteControl);
            this.Name = "TestForm3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Remote Repository";
            this.ResumeLayout(false);

        }

        #endregion

        private CRemoteControl m_RemoteControl;

    }
}