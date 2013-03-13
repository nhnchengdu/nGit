namespace Git.UI
{
    partial class Form_Repo_AddBranch
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
            this.m_txTagName = new System.Windows.Forms.TextBox();
            this.m_picWarning = new System.Windows.Forms.PictureBox();
            this.m_checkCheckOut = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txSelectedSHA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txMsg = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_txAuthor = new System.Windows.Forms.TextBox();
            this.m_txDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_labWarning1 = new System.Windows.Forms.Label();
            this.m_labWarning2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picWarning)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.m_txTagName);
            this.groupBox1.Controls.Add(this.m_checkCheckOut);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 55);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            // 
            // m_txTagName
            // 
            this.m_txTagName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txTagName.Location = new System.Drawing.Point(82, 21);
            this.m_txTagName.Name = "m_txTagName";
            this.m_txTagName.Size = new System.Drawing.Size(203, 21);
            this.m_txTagName.TabIndex = 66;
            this.m_txTagName.Text = "New Branch --01";
            // 
            // m_picWarning
            // 
            this.m_picWarning.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_picWarning.Location = new System.Drawing.Point(6, 10);
            this.m_picWarning.Name = "m_picWarning";
            this.m_picWarning.Size = new System.Drawing.Size(31, 29);
            this.m_picWarning.TabIndex = 4;
            this.m_picWarning.TabStop = false;
            this.m_picWarning.Visible = false;
            // 
            // m_checkCheckOut
            // 
            this.m_checkCheckOut.AutoSize = true;
            this.m_checkCheckOut.Location = new System.Drawing.Point(10, 2);
            this.m_checkCheckOut.Name = "m_checkCheckOut";
            this.m_checkCheckOut.Size = new System.Drawing.Size(144, 16);
            this.m_checkCheckOut.TabIndex = 58;
            this.m_checkCheckOut.Text = "Create and Check out";
            this.m_checkCheckOut.UseVisualStyleBackColor = true;
            this.m_checkCheckOut.CheckedChanged += new System.EventHandler(this.m_checkCheckOut_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 47;
            this.label2.Text = "Branch Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 59);
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
            this.m_txSelectedSHA.Size = new System.Drawing.Size(249, 16);
            this.m_txSelectedSHA.TabIndex = 64;
            this.m_txSelectedSHA.Text = "00000000000000000000000000000000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 61;
            this.label5.Text = "Author:";
            // 
            // m_txMsg
            // 
            this.m_txMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txMsg.Enabled = false;
            this.m_txMsg.Location = new System.Drawing.Point(288, 17);
            this.m_txMsg.Multiline = true;
            this.m_txMsg.Name = "m_txMsg";
            this.m_txMsg.Size = new System.Drawing.Size(254, 58);
            this.m_txMsg.TabIndex = 63;
            this.m_txMsg.Text = "this commit is for test...........................";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_txSelectedSHA);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.m_txMsg);
            this.groupBox2.Controls.Add(this.m_txAuthor);
            this.groupBox2.Controls.Add(this.m_txDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 82);
            this.groupBox2.TabIndex = 68;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "SHA:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 71;
            this.label7.Text = "Operation Resutl";
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(481, 171);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 73;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(6, 165);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(454, 66);
            this.m_txOperRes.TabIndex = 72;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(481, 202);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 74;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_labWarning1
            // 
            this.m_labWarning1.AutoSize = true;
            this.m_labWarning1.ForeColor = System.Drawing.Color.Red;
            this.m_labWarning1.Location = new System.Drawing.Point(41, 9);
            this.m_labWarning1.Name = "m_labWarning1";
            this.m_labWarning1.Size = new System.Drawing.Size(167, 12);
            this.m_labWarning1.TabIndex = 75;
            this.m_labWarning1.Text = "Warning:the change maybe be";
            this.m_labWarning1.Visible = false;
            // 
            // m_labWarning2
            // 
            this.m_labWarning2.AutoSize = true;
            this.m_labWarning2.ForeColor = System.Drawing.Color.Red;
            this.m_labWarning2.Location = new System.Drawing.Point(41, 25);
            this.m_labWarning2.Name = "m_labWarning2";
            this.m_labWarning2.Size = new System.Drawing.Size(221, 12);
            this.m_labWarning2.TabIndex = 75;
            this.m_labWarning2.Text = "losed in woking tree and index area.";
            this.m_labWarning2.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_picWarning);
            this.groupBox3.Controls.Add(this.m_labWarning2);
            this.groupBox3.Controls.Add(this.m_labWarning1);
            this.groupBox3.Location = new System.Drawing.Point(288, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 48);
            this.groupBox3.TabIndex = 76;
            this.groupBox3.TabStop = false;
            // 
            // Form_Repo_AddBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 238);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Repo_AddBranch";
            this.Text = "Add Branch";
            this.Load += new System.EventHandler(this.Form_Repo_AddBranch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picWarning)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox m_checkCheckOut;
        private System.Windows.Forms.PictureBox m_picWarning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txSelectedSHA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_txMsg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox m_txAuthor;
        private System.Windows.Forms.TextBox m_txDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox m_txTagName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Label m_labWarning2;
        private System.Windows.Forms.Label m_labWarning1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}