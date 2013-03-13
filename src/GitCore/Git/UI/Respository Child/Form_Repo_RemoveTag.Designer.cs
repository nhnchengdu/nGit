namespace Git.UI
{
    partial class Form_Repo_RemoveTag
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
            this.m_cbTagLists = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txSelectedSHA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txMsg = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_txAuthor = new System.Windows.Forms.TextBox();
            this.m_txDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cbTagLists
            // 
            this.m_cbTagLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbTagLists.FormattingEnabled = true;
            this.m_cbTagLists.Items.AddRange(new object[] {
            "Master",
            "New Branch -1"});
            this.m_cbTagLists.Location = new System.Drawing.Point(73, 23);
            this.m_cbTagLists.Name = "m_cbTagLists";
            this.m_cbTagLists.Size = new System.Drawing.Size(454, 20);
            this.m_cbTagLists.TabIndex = 48;
            this.m_cbTagLists.TextChanged += new System.EventHandler(this.m_cbTagLists_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 47;
            this.label2.Text = "Tag Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cbTagLists);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 56);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "This Tag Will be Removed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 63;
            this.label4.Text = "Data:";
            // 
            // m_txSelectedSHA
            // 
            this.m_txSelectedSHA.AcceptsTab = true;
            this.m_txSelectedSHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txSelectedSHA.Enabled = false;
            this.m_txSelectedSHA.Location = new System.Drawing.Point(33, 17);
            this.m_txSelectedSHA.Multiline = true;
            this.m_txSelectedSHA.Name = "m_txSelectedSHA";
            this.m_txSelectedSHA.Size = new System.Drawing.Size(249, 16);
            this.m_txSelectedSHA.TabIndex = 64;
            this.m_txSelectedSHA.Text = "00000000000000000000000000000000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 61;
            this.label3.Text = "Author:";
            // 
            // m_txMsg
            // 
            this.m_txMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txMsg.Enabled = false;
            this.m_txMsg.Location = new System.Drawing.Point(288, 17);
            this.m_txMsg.Multiline = true;
            this.m_txMsg.Name = "m_txMsg";
            this.m_txMsg.Size = new System.Drawing.Size(245, 58);
            this.m_txMsg.TabIndex = 63;
            this.m_txMsg.Text = "this commit is for test...........................";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.m_txSelectedSHA);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.m_txMsg);
            this.groupBox2.Controls.Add(this.m_txAuthor);
            this.groupBox2.Controls.Add(this.m_txDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 82);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target Commit";
            // 
            // m_txAuthor
            // 
            this.m_txAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txAuthor.Enabled = false;
            this.m_txAuthor.Location = new System.Drawing.Point(54, 38);
            this.m_txAuthor.Multiline = true;
            this.m_txAuthor.Name = "m_txAuthor";
            this.m_txAuthor.Size = new System.Drawing.Size(228, 16);
            this.m_txAuthor.TabIndex = 66;
            this.m_txAuthor.Text = "fengzheng";
            // 
            // m_txDate
            // 
            this.m_txDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txDate.Enabled = false;
            this.m_txDate.Location = new System.Drawing.Point(45, 59);
            this.m_txDate.Multiline = true;
            this.m_txDate.Name = "m_txDate";
            this.m_txDate.Size = new System.Drawing.Size(237, 16);
            this.m_txDate.TabIndex = 65;
            this.m_txDate.Text = "2012-04-05";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 62;
            this.label5.Text = "SHA:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 86;
            this.label6.Text = "Operation Resutl";
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(470, 182);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 88;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(16, 177);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(448, 66);
            this.m_txOperRes.TabIndex = 87;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(470, 213);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 89;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // Form_Repo_RemoveTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 247);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Repo_RemoveTag";
            this.Text = "Remove Tag";
            this.Load += new System.EventHandler(this.Form_Repo_RemoveTag_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox m_cbTagLists;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txSelectedSHA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txMsg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox m_txAuthor;
        private System.Windows.Forms.TextBox m_txDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.Button m_btnCancel;


    }
}