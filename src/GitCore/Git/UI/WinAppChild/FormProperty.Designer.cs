namespace GitCore.Git.UI
{
    partial class FormProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProperty));
            this.label1 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.m_grougConfigureSSH = new System.Windows.Forms.GroupBox();
            this.m_btnSSHConfig = new System.Windows.Forms.Button();
            this.m_grougConfigureSSH.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.AllowDrop = true;
            resources.ApplyResources(this.propertyGrid1, "propertyGrid1");
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.UseCompatibleTextRendering = true;
            this.propertyGrid1.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.propertyGrid1_SelectedGridItemChanged);
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // m_grougConfigureSSH
            // 
            this.m_grougConfigureSSH.Controls.Add(this.m_btnSSHConfig);
            resources.ApplyResources(this.m_grougConfigureSSH, "m_grougConfigureSSH");
            this.m_grougConfigureSSH.Name = "m_grougConfigureSSH";
            this.m_grougConfigureSSH.TabStop = false;
            // 
            // m_btnSSHConfig
            // 
            resources.ApplyResources(this.m_btnSSHConfig, "m_btnSSHConfig");
            this.m_btnSSHConfig.Name = "m_btnSSHConfig";
            this.m_btnSSHConfig.UseVisualStyleBackColor = true;
            this.m_btnSSHConfig.Click += new System.EventHandler(this.m_btnSSHConfig_Click);
            // 
            // FormProperty
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_grougConfigureSSH);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProperty";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormProperty_Load);
            this.m_grougConfigureSSH.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.GroupBox m_grougConfigureSSH;
        private System.Windows.Forms.Button m_btnSSHConfig;
    }
}