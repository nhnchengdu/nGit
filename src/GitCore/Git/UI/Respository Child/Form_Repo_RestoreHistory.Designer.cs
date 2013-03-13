namespace Git.UI
{
    partial class Form_Repo_RestoreHistory
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
            this.m_lvReflog = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txCurrenBranch = new System.Windows.Forms.TextBox();
            this.m_rdbHead = new System.Windows.Forms.RadioButton();
            this.m_rdbIndAndHead = new System.Windows.Forms.RadioButton();
            this.m_rdbAll = new System.Windows.Forms.RadioButton();
            this.m_cobBranchLists = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnRun = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_txOperRes = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lvReflog
            // 
            this.m_lvReflog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.m_lvReflog.FullRowSelect = true;
            this.m_lvReflog.GridLines = true;
            this.m_lvReflog.Location = new System.Drawing.Point(3, 95);
            this.m_lvReflog.MultiSelect = false;
            this.m_lvReflog.Name = "m_lvReflog";
            this.m_lvReflog.Size = new System.Drawing.Size(556, 199);
            this.m_lvReflog.TabIndex = 7;
            this.m_lvReflog.UseCompatibleStateImageBehavior = false;
            this.m_lvReflog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "HASH";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Order";
            this.columnHeader2.Width = 79;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 74;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Commit Log";
            this.columnHeader4.Width = 303;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_txCurrenBranch);
            this.groupBox1.Controls.Add(this.m_rdbHead);
            this.groupBox1.Controls.Add(this.m_rdbIndAndHead);
            this.groupBox1.Controls.Add(this.m_rdbAll);
            this.groupBox1.Controls.Add(this.m_cobBranchLists);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 77);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Branch Will be Restored";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 72;
            this.label1.Text = "Current Branch:";
            // 
            // m_txCurrenBranch
            // 
            this.m_txCurrenBranch.BackColor = System.Drawing.Color.Gainsboro;
            this.m_txCurrenBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txCurrenBranch.Enabled = false;
            this.m_txCurrenBranch.Location = new System.Drawing.Point(110, 14);
            this.m_txCurrenBranch.Multiline = true;
            this.m_txCurrenBranch.Name = "m_txCurrenBranch";
            this.m_txCurrenBranch.Size = new System.Drawing.Size(266, 17);
            this.m_txCurrenBranch.TabIndex = 73;
            // 
            // m_rdbHead
            // 
            this.m_rdbHead.AutoSize = true;
            this.m_rdbHead.Checked = true;
            this.m_rdbHead.Location = new System.Drawing.Point(401, 55);
            this.m_rdbHead.Name = "m_rdbHead";
            this.m_rdbHead.Size = new System.Drawing.Size(83, 16);
            this.m_rdbHead.TabIndex = 71;
            this.m_rdbHead.TabStop = true;
            this.m_rdbHead.Text = "Reset HEAD";
            this.m_rdbHead.UseVisualStyleBackColor = true;
            // 
            // m_rdbIndAndHead
            // 
            this.m_rdbIndAndHead.AutoSize = true;
            this.m_rdbIndAndHead.Location = new System.Drawing.Point(401, 35);
            this.m_rdbIndAndHead.Name = "m_rdbIndAndHead";
            this.m_rdbIndAndHead.Size = new System.Drawing.Size(143, 16);
            this.m_rdbIndAndHead.TabIndex = 70;
            this.m_rdbIndAndHead.Text = "Reset Index and HEAD";
            this.m_rdbIndAndHead.UseVisualStyleBackColor = true;
            // 
            // m_rdbAll
            // 
            this.m_rdbAll.AutoSize = true;
            this.m_rdbAll.Location = new System.Drawing.Point(401, 15);
            this.m_rdbAll.Name = "m_rdbAll";
            this.m_rdbAll.Size = new System.Drawing.Size(77, 16);
            this.m_rdbAll.TabIndex = 69;
            this.m_rdbAll.Text = "Reset All";
            this.m_rdbAll.UseVisualStyleBackColor = true;
            // 
            // m_cobBranchLists
            // 
            this.m_cobBranchLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobBranchLists.FormattingEnabled = true;
            this.m_cobBranchLists.Items.AddRange(new object[] {
            "Master",
            "New Branch -1"});
            this.m_cobBranchLists.Location = new System.Drawing.Point(91, 46);
            this.m_cobBranchLists.Name = "m_cobBranchLists";
            this.m_cobBranchLists.Size = new System.Drawing.Size(285, 20);
            this.m_cobBranchLists.TabIndex = 68;
            this.m_cobBranchLists.TextChanged += new System.EventHandler(this.m_cobBranchLists_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 47;
            this.label2.Text = "Branch Name:";
            // 
            // m_btnRun
            // 
            this.m_btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnRun.Location = new System.Drawing.Point(472, 307);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(75, 25);
            this.m_btnRun.TabIndex = 69;
            this.m_btnRun.Text = "Run";
            this.m_btnRun.UseVisualStyleBackColor = true;
            this.m_btnRun.Click += new System.EventHandler(this.m_btnRun_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(471, 338);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 70;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_txOperRes
            // 
            this.m_txOperRes.AllowDrop = true;
            this.m_txOperRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txOperRes.Location = new System.Drawing.Point(12, 302);
            this.m_txOperRes.Multiline = true;
            this.m_txOperRes.Name = "m_txOperRes";
            this.m_txOperRes.Size = new System.Drawing.Size(448, 66);
            this.m_txOperRes.TabIndex = 68;
            this.m_txOperRes.Text = "Operation Result";
            // 
            // Form_Repo_RestoreHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 372);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_txOperRes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_lvReflog);
            this.Name = "Form_Repo_RestoreHistory";
            this.Text = "Restore History";
            this.Load += new System.EventHandler(this.Form_Repo_RestoreHistory_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView m_lvReflog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_btnRun;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.TextBox m_txOperRes;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox m_cobBranchLists;
        private System.Windows.Forms.RadioButton m_rdbHead;
        private System.Windows.Forms.RadioButton m_rdbIndAndHead;
        private System.Windows.Forms.RadioButton m_rdbAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txCurrenBranch;
    }
}