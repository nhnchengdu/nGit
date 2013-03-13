namespace Git.UI
{
    partial class Form_Repo_Filter
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
            this.m_dateEnd = new System.Windows.Forms.DateTimePicker();
            this.m_dateStart = new System.Windows.Forms.DateTimePicker();
            this.m_txAuthor = new System.Windows.Forms.TextBox();
            this.BranchFilter = new System.Windows.Forms.TextBox();
            this.BranchFilterCheck = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LimitCheck = new System.Windows.Forms.CheckBox();
            this.IgnoreCase = new System.Windows.Forms.CheckBox();
            this.MessageCheck = new System.Windows.Forms.CheckBox();
            this.m_checkBr = new System.Windows.Forms.CheckBox();
            this.m_checkAuthor = new System.Windows.Forms.CheckBox();
            this.m_checkDate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_txMessage = new System.Windows.Forms.TextBox();
            this.m_checkMsg = new System.Windows.Forms.CheckBox();
            this.m_cobBranchList = new Git.UI.CCheckComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dateEnd
            // 
            this.m_dateEnd.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_dateEnd.Location = new System.Drawing.Point(235, 176);
            this.m_dateEnd.Name = "m_dateEnd";
            this.m_dateEnd.Size = new System.Drawing.Size(223, 21);
            this.m_dateEnd.TabIndex = 23;
            // 
            // m_dateStart
            // 
            this.m_dateStart.Location = new System.Drawing.Point(12, 176);
            this.m_dateStart.Name = "m_dateStart";
            this.m_dateStart.Size = new System.Drawing.Size(194, 21);
            this.m_dateStart.TabIndex = 22;
            // 
            // m_txAuthor
            // 
            this.m_txAuthor.Location = new System.Drawing.Point(12, 125);
            this.m_txAuthor.Name = "m_txAuthor";
            this.m_txAuthor.Size = new System.Drawing.Size(446, 21);
            this.m_txAuthor.TabIndex = 27;
            // 
            // BranchFilter
            // 
            this.BranchFilter.Location = new System.Drawing.Point(209, 203);
            this.BranchFilter.Name = "BranchFilter";
            this.BranchFilter.Size = new System.Drawing.Size(241, 21);
            this.BranchFilter.TabIndex = 32;
            // 
            // BranchFilterCheck
            // 
            this.BranchFilterCheck.AutoSize = true;
            this.BranchFilterCheck.Location = new System.Drawing.Point(187, 203);
            this.BranchFilterCheck.Name = "BranchFilterCheck";
            this.BranchFilterCheck.Size = new System.Drawing.Size(15, 14);
            this.BranchFilterCheck.TabIndex = 34;
            this.BranchFilterCheck.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 395F));
            this.tableLayoutPanel1.Controls.Add(this.LimitCheck, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.IgnoreCase, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LimitCheck
            // 
            this.LimitCheck.AutoSize = true;
            this.LimitCheck.Location = new System.Drawing.Point(187, 123);
            this.LimitCheck.Name = "LimitCheck";
            this.LimitCheck.Size = new System.Drawing.Size(15, 14);
            this.LimitCheck.TabIndex = 27;
            this.LimitCheck.UseVisualStyleBackColor = true;
            // 
            // IgnoreCase
            // 
            this.IgnoreCase.AutoSize = true;
            this.IgnoreCase.Checked = true;
            this.IgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IgnoreCase.Location = new System.Drawing.Point(187, 103);
            this.IgnoreCase.Name = "IgnoreCase";
            this.IgnoreCase.Size = new System.Drawing.Size(15, 14);
            this.IgnoreCase.TabIndex = 26;
            this.IgnoreCase.UseVisualStyleBackColor = true;
            // 
            // MessageCheck
            // 
            this.MessageCheck.AutoSize = true;
            this.MessageCheck.Location = new System.Drawing.Point(187, 103);
            this.MessageCheck.Name = "MessageCheck";
            this.MessageCheck.Size = new System.Drawing.Size(15, 14);
            this.MessageCheck.TabIndex = 25;
            this.MessageCheck.UseVisualStyleBackColor = true;
            // 
            // m_checkBr
            // 
            this.m_checkBr.AutoSize = true;
            this.m_checkBr.Location = new System.Drawing.Point(12, 8);
            this.m_checkBr.Name = "m_checkBr";
            this.m_checkBr.Size = new System.Drawing.Size(60, 16);
            this.m_checkBr.TabIndex = 37;
            this.m_checkBr.Text = "Branch";
            this.m_checkBr.UseVisualStyleBackColor = true;
            this.m_checkBr.CheckedChanged += new System.EventHandler(this.m_checkBr_CheckedChanged);
            // 
            // m_checkAuthor
            // 
            this.m_checkAuthor.AutoSize = true;
            this.m_checkAuthor.Location = new System.Drawing.Point(12, 107);
            this.m_checkAuthor.Name = "m_checkAuthor";
            this.m_checkAuthor.Size = new System.Drawing.Size(60, 16);
            this.m_checkAuthor.TabIndex = 37;
            this.m_checkAuthor.Text = "Author";
            this.m_checkAuthor.UseVisualStyleBackColor = true;
            this.m_checkAuthor.CheckedChanged += new System.EventHandler(this.m_checAuthor_CheckedChanged);
            // 
            // m_checkDate
            // 
            this.m_checkDate.AutoSize = true;
            this.m_checkDate.Location = new System.Drawing.Point(12, 157);
            this.m_checkDate.Name = "m_checkDate";
            this.m_checkDate.Size = new System.Drawing.Size(48, 16);
            this.m_checkDate.TabIndex = 37;
            this.m_checkDate.Text = "Date";
            this.m_checkDate.UseVisualStyleBackColor = true;
            this.m_checkDate.CheckedChanged += new System.EventHandler(this.m_checDate_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "~~";
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnOk.Location = new System.Drawing.Point(387, 204);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 25);
            this.m_btnOk.TabIndex = 43;
            this.m_btnOk.Text = "OK";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnCancel.Location = new System.Drawing.Point(302, 204);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 43;
            this.m_btnCancel.Text = "Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_txMessage
            // 
            this.m_txMessage.Location = new System.Drawing.Point(12, 73);
            this.m_txMessage.Name = "m_txMessage";
            this.m_txMessage.Size = new System.Drawing.Size(446, 21);
            this.m_txMessage.TabIndex = 39;
            // 
            // m_checkMsg
            // 
            this.m_checkMsg.AutoSize = true;
            this.m_checkMsg.Location = new System.Drawing.Point(12, 56);
            this.m_checkMsg.Name = "m_checkMsg";
            this.m_checkMsg.Size = new System.Drawing.Size(66, 16);
            this.m_checkMsg.TabIndex = 37;
            this.m_checkMsg.Text = "Message";
            this.m_checkMsg.UseVisualStyleBackColor = true;
            this.m_checkMsg.CheckedChanged += new System.EventHandler(this.m_checkMsg_CheckedChanged);
            // 
            // m_cobBranchList
            // 
            this.m_cobBranchList.FormattingEnabled = true;
            this.m_cobBranchList.IntegralHeight = false;
            this.m_cobBranchList.Location = new System.Drawing.Point(12, 28);
            this.m_cobBranchList.m_IsMultiSelect = false;
            this.m_cobBranchList.Name = "m_cobBranchList";
            this.m_cobBranchList.Size = new System.Drawing.Size(446, 20);
            this.m_cobBranchList.TabIndex = 41;

            // 
            // Form_Repo_Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 241);
            this.Controls.Add(this.m_checkDate);
            this.Controls.Add(this.m_checkAuthor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_checkMsg);
            this.Controls.Add(this.m_dateStart);
            this.Controls.Add(this.m_txAuthor);
            this.Controls.Add(this.m_dateEnd);
            this.Controls.Add(this.m_cobBranchList);
            this.Controls.Add(this.m_checkBr);
            this.Controls.Add(this.m_txMessage);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Repo_Filter";
            this.Text = "Filter Setting";
            this.Load += new System.EventHandler(this.Form_Repo_Filter_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker m_dateEnd;
        private System.Windows.Forms.DateTimePicker m_dateStart;
        private System.Windows.Forms.TextBox m_txAuthor;
        private System.Windows.Forms.TextBox BranchFilter;
        private System.Windows.Forms.CheckBox BranchFilterCheck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox LimitCheck;
        private System.Windows.Forms.CheckBox IgnoreCase;
        private System.Windows.Forms.CheckBox MessageCheck;
        private System.Windows.Forms.CheckBox m_checkBr;
        private Git.UI.CCheckComboBox m_cobBranchList;
        private System.Windows.Forms.CheckBox m_checkAuthor;
        private System.Windows.Forms.CheckBox m_checkDate;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txMessage;
        private System.Windows.Forms.CheckBox m_checkMsg;


    }
}