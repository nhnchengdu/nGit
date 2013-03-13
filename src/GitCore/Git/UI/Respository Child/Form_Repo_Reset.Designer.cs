namespace Git.UI
{
    partial class Form_Repo_Reset
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
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdbIndex = new System.Windows.Forms.RadioButton();
            this.m_rdbHead = new System.Windows.Forms.RadioButton();
            this.m_rdbIndAndHead = new System.Windows.Forms.RadioButton();
            this.m_rdbAll = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txSelectedSHA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txMsg = new System.Windows.Forms.TextBox();
            this.m_txAuthor = new System.Windows.Forms.TextBox();
            this.m_txDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_picWarning = new System.Windows.Forms.PictureBox();
            this.m_labWarning1 = new System.Windows.Forms.Label();
            this.m_txWarning = new System.Windows.Forms.TextBox();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(12, 216);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(481, 66);
            this.m_txOperRes.TabIndex = 55;
            this.m_txOperRes.Text = "Operation Result";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdbIndex);
            this.groupBox1.Controls.Add(this.m_rdbHead);
            this.groupBox1.Controls.Add(this.m_rdbIndAndHead);
            this.groupBox1.Controls.Add(this.m_rdbAll);
            this.groupBox1.Location = new System.Drawing.Point(19, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 45);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reset Mode";
            // 
            // m_rdbIndex
            // 
            this.m_rdbIndex.AutoSize = true;
            this.m_rdbIndex.Location = new System.Drawing.Point(454, 20);
            this.m_rdbIndex.Name = "m_rdbIndex";
            this.m_rdbIndex.Size = new System.Drawing.Size(95, 16);
            this.m_rdbIndex.TabIndex = 53;
            this.m_rdbIndex.Text = "Reset Index ";
            this.m_rdbIndex.UseVisualStyleBackColor = true;
            this.m_rdbIndex.CheckedChanged += new System.EventHandler(this.m_rdbAll_CheckedChanged);
            // 
            // m_rdbHead
            // 
            this.m_rdbHead.AutoSize = true;
            this.m_rdbHead.Location = new System.Drawing.Point(320, 20);
            this.m_rdbHead.Name = "m_rdbHead";
            this.m_rdbHead.Size = new System.Drawing.Size(83, 16);
            this.m_rdbHead.TabIndex = 52;
            this.m_rdbHead.Text = "Reset HEAD";
            this.m_rdbHead.UseVisualStyleBackColor = true;
            this.m_rdbHead.CheckedChanged += new System.EventHandler(this.m_rdbAll_CheckedChanged);
            // 
            // m_rdbIndAndHead
            // 
            this.m_rdbIndAndHead.AutoSize = true;
            this.m_rdbIndAndHead.Location = new System.Drawing.Point(130, 20);
            this.m_rdbIndAndHead.Name = "m_rdbIndAndHead";
            this.m_rdbIndAndHead.Size = new System.Drawing.Size(143, 16);
            this.m_rdbIndAndHead.TabIndex = 51;
            this.m_rdbIndAndHead.Text = "Reset Index and HEAD";
            this.m_rdbIndAndHead.UseVisualStyleBackColor = true;
            this.m_rdbIndAndHead.CheckedChanged += new System.EventHandler(this.m_rdbAll_CheckedChanged);
            // 
            // m_rdbAll
            // 
            this.m_rdbAll.AutoSize = true;
            this.m_rdbAll.Location = new System.Drawing.Point(9, 20);
            this.m_rdbAll.Name = "m_rdbAll";
            this.m_rdbAll.Size = new System.Drawing.Size(77, 16);
            this.m_rdbAll.TabIndex = 50;
            this.m_rdbAll.Text = "Reset All";
            this.m_rdbAll.UseVisualStyleBackColor = true;
            this.m_rdbAll.CheckedChanged += new System.EventHandler(this.m_rdbAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_txSelectedSHA);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.m_txMsg);
            this.groupBox2.Controls.Add(this.m_txAuthor);
            this.groupBox2.Controls.Add(this.m_txDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 147);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reset To the Commit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 63;
            this.label2.Text = "Message:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 63;
            this.label1.Text = "Data:";
            // 
            // m_txSelectedSHA
            // 
            this.m_txSelectedSHA.AcceptsTab = true;
            this.m_txSelectedSHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSelectedSHA.Enabled = false;
            this.m_txSelectedSHA.Location = new System.Drawing.Point(33, 17);
            this.m_txSelectedSHA.Multiline = true;
            this.m_txSelectedSHA.Name = "m_txSelectedSHA";
            this.m_txSelectedSHA.Size = new System.Drawing.Size(267, 16);
            this.m_txSelectedSHA.TabIndex = 64;
            this.m_txSelectedSHA.Text = "00000000000000000000000000000000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 61;
            this.label5.Text = "Author:";
            // 
            // m_txMsg
            // 
            this.m_txMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txMsg.Enabled = false;
            this.m_txMsg.Location = new System.Drawing.Point(9, 94);
            this.m_txMsg.Multiline = true;
            this.m_txMsg.Name = "m_txMsg";
            this.m_txMsg.Size = new System.Drawing.Size(291, 43);
            this.m_txMsg.TabIndex = 63;
            this.m_txMsg.Text = "this commit is for test...........................";
            // 
            // m_txAuthor
            // 
            this.m_txAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txAuthor.Enabled = false;
            this.m_txAuthor.Location = new System.Drawing.Point(54, 36);
            this.m_txAuthor.Multiline = true;
            this.m_txAuthor.Name = "m_txAuthor";
            this.m_txAuthor.Size = new System.Drawing.Size(246, 16);
            this.m_txAuthor.TabIndex = 66;
            this.m_txAuthor.Text = "fengzheng";
            // 
            // m_txDate
            // 
            this.m_txDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txDate.Enabled = false;
            this.m_txDate.Location = new System.Drawing.Point(45, 55);
            this.m_txDate.Multiline = true;
            this.m_txDate.Name = "m_txDate";
            this.m_txDate.Size = new System.Drawing.Size(255, 16);
            this.m_txDate.TabIndex = 65;
            this.m_txDate.Text = "2012-04-05";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "SHA:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_picWarning);
            this.groupBox4.Controls.Add(this.m_labWarning1);
            this.groupBox4.Controls.Add(this.m_txWarning);
            this.groupBox4.Location = new System.Drawing.Point(323, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(281, 147);
            this.groupBox4.TabIndex = 76;
            this.groupBox4.TabStop = false;
            // 
            // m_picWarning
            // 
            this.m_picWarning.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_picWarning.Location = new System.Drawing.Point(6, 10);
            this.m_picWarning.Name = "m_picWarning";
            this.m_picWarning.Size = new System.Drawing.Size(31, 29);
            this.m_picWarning.TabIndex = 4;
            this.m_picWarning.TabStop = false;
            // 
            // m_labWarning1
            // 
            this.m_labWarning1.AutoSize = true;
            this.m_labWarning1.ForeColor = System.Drawing.Color.Black;
            this.m_labWarning1.Location = new System.Drawing.Point(43, 17);
            this.m_labWarning1.Name = "m_labWarning1";
            this.m_labWarning1.Size = new System.Drawing.Size(65, 12);
            this.m_labWarning1.TabIndex = 75;
            this.m_labWarning1.Text = "Warning:  ";
            // 
            // m_txWarning
            // 
            this.m_txWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txWarning.Location = new System.Drawing.Point(6, 45);
            this.m_txWarning.Multiline = true;
            this.m_txWarning.Name = "m_txWarning";
            this.m_txWarning.Size = new System.Drawing.Size(268, 92);
            this.m_txWarning.TabIndex = 63;
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(514, 218);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 85;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(514, 249);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 86;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // Form_Repo_Reset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 286);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Repo_Reset";
            this.Text = "Reset Commit";
            this.Load += new System.EventHandler(this.Form_Repo_Reset_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picWarning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton m_rdbHead;
        private System.Windows.Forms.RadioButton m_rdbIndAndHead;
        private System.Windows.Forms.RadioButton m_rdbAll;
        private System.Windows.Forms.RadioButton m_rdbIndex;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox m_picWarning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txSelectedSHA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_txMsg;
        private System.Windows.Forms.TextBox m_txAuthor;
        private System.Windows.Forms.TextBox m_txDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label m_labWarning1;
        private System.Windows.Forms.TextBox m_txWarning;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.Button m_btnCancel;
    }
}