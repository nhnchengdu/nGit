
namespace Git.UI
{
    partial class FormStash
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_checkKeepClean = new System.Windows.Forms.CheckBox();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_txCommitMsg = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_btnRestore = new System.Windows.Forms.Button();
            this.m_btnReset = new System.Windows.Forms.Button();
            this.m_btnClear = new System.Windows.Forms.Button();
            this.m_clbStashList = new System.Windows.Forms.CheckedListBox();
            this.m_txSHowInfo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_checkKeepClean);
            this.groupBox1.Controls.Add(this.m_btnSave);
            this.groupBox1.Controls.Add(this.m_txCommitMsg);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 106);
            this.groupBox1.TabIndex = 105;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Current All Works";
            // 
            // m_checkKeepClean
            // 
            this.m_checkKeepClean.AutoSize = true;
            this.m_checkKeepClean.Location = new System.Drawing.Point(6, 82);
            this.m_checkKeepClean.Name = "m_checkKeepClean";
            this.m_checkKeepClean.Size = new System.Drawing.Size(192, 16);
            this.m_checkKeepClean.TabIndex = 95;
            this.m_checkKeepClean.Text = "Clean Working and Index Area";
            this.m_checkKeepClean.UseVisualStyleBackColor = true;
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnSave.Location = new System.Drawing.Point(403, 78);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(75, 25);
            this.m_btnSave.TabIndex = 94;
            this.m_btnSave.Text = "Save";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_txCommitMsg
            // 
            this.m_txCommitMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txCommitMsg.Location = new System.Drawing.Point(6, 20);
            this.m_txCommitMsg.Multiline = true;
            this.m_txCommitMsg.Name = "m_txCommitMsg";
            this.m_txCommitMsg.Size = new System.Drawing.Size(472, 56);
            this.m_txCommitMsg.TabIndex = 64;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_btnRestore);
            this.groupBox2.Controls.Add(this.m_btnReset);
            this.groupBox2.Controls.Add(this.m_btnClear);
            this.groupBox2.Controls.Add(this.m_clbStashList);
            this.groupBox2.Controls.Add(this.m_txSHowInfo);
            this.groupBox2.Location = new System.Drawing.Point(6, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(492, 200);
            this.groupBox2.TabIndex = 105;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restore History Copy";
            // 
            // m_btnRestore
            // 
            this.m_btnRestore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRestore.Location = new System.Drawing.Point(407, 174);
            this.m_btnRestore.Name = "m_btnRestore";
            this.m_btnRestore.Size = new System.Drawing.Size(75, 25);
            this.m_btnRestore.TabIndex = 94;
            this.m_btnRestore.Text = "Retore";
            this.m_btnRestore.UseVisualStyleBackColor = true;
            this.m_btnRestore.Click += new System.EventHandler(this.m_btnRestore_Click);
            // 
            // m_btnReset
            // 
            this.m_btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnReset.Location = new System.Drawing.Point(6, 174);
            this.m_btnReset.Name = "m_btnReset";
            this.m_btnReset.Size = new System.Drawing.Size(173, 25);
            this.m_btnReset.TabIndex = 94;
            this.m_btnReset.Text = "Reset to Cleaning Working";
            this.m_btnReset.UseVisualStyleBackColor = true;
            this.m_btnReset.Click += new System.EventHandler(this.m_btnReset_Click);
            // 
            // m_btnClear
            // 
            this.m_btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnClear.Location = new System.Drawing.Point(326, 174);
            this.m_btnClear.Name = "m_btnClear";
            this.m_btnClear.Size = new System.Drawing.Size(75, 25);
            this.m_btnClear.TabIndex = 94;
            this.m_btnClear.Text = "Clear";
            this.m_btnClear.UseVisualStyleBackColor = true;
            this.m_btnClear.Click += new System.EventHandler(this.m_btnClean_Click);
            // 
            // m_clbStashList
            // 
            this.m_clbStashList.FormattingEnabled = true;
            this.m_clbStashList.Location = new System.Drawing.Point(6, 20);
            this.m_clbStashList.Name = "m_clbStashList";
            this.m_clbStashList.Size = new System.Drawing.Size(476, 100);
            this.m_clbStashList.TabIndex = 65;
            this.m_clbStashList.SelectedIndexChanged += new System.EventHandler(this.m_clbStashList_SelectedIndexChanged);
            this.m_clbStashList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.m_clbStashList_ItemCheck);
            // 
            // m_txSHowInfo
            // 
            this.m_txSHowInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSHowInfo.Enabled = false;
            this.m_txSHowInfo.Location = new System.Drawing.Point(6, 121);
            this.m_txSHowInfo.Multiline = true;
            this.m_txSHowInfo.Name = "m_txSHowInfo";
            this.m_txSHowInfo.Size = new System.Drawing.Size(476, 48);
            this.m_txSHowInfo.TabIndex = 64;
            // 
            // FormStash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 323);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Stash";
            this.Load += new System.EventHandler(this.FormStash_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox m_txCommitMsg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox m_txSHowInfo;
        private System.Windows.Forms.CheckedListBox m_clbStashList;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnRestore;
        private System.Windows.Forms.Button m_btnClear;
        private System.Windows.Forms.CheckBox m_checkKeepClean;
        private System.Windows.Forms.Button m_btnReset;
    }
}