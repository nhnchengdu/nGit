
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Git.Manager;
using Git.Core.Commands;

namespace Git.UI
{
    partial class FormDelete
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
            System.Windows.Forms.Button m_btnDelete;
            System.Windows.Forms.RadioButton m_radioKeepWorkingTree;
            this.btnCancel = new System.Windows.Forms.Button();
            this.m_clbFilelist = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_radioDeleteWorkingTree = new System.Windows.Forms.RadioButton();
            m_btnDelete = new System.Windows.Forms.Button();
            m_radioKeepWorkingTree = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnDelete
            // 
            m_btnDelete.Location = new System.Drawing.Point(451, 12);
            m_btnDelete.Name = "m_btnDelete";
            m_btnDelete.Size = new System.Drawing.Size(83, 24);
            m_btnDelete.TabIndex = 2;
            m_btnDelete.Text = "Delete";
            m_btnDelete.UseVisualStyleBackColor = true;
            m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
            // 
            // m_radioKeepWorkingTree
            // 
            m_radioKeepWorkingTree.AutoSize = true;
            m_radioKeepWorkingTree.Checked = true;
            m_radioKeepWorkingTree.Location = new System.Drawing.Point(12, 20);
            m_radioKeepWorkingTree.Name = "m_radioKeepWorkingTree";
            m_radioKeepWorkingTree.Size = new System.Drawing.Size(161, 16);
            m_radioKeepWorkingTree.TabIndex = 0;
            m_radioKeepWorkingTree.TabStop = true;
            m_radioKeepWorkingTree.Text = "Keep Working Tree Files";
            m_radioKeepWorkingTree.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(358, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_clbFilelist
            // 
            this.m_clbFilelist.FormattingEnabled = true;
            this.m_clbFilelist.Location = new System.Drawing.Point(10, 41);
            this.m_clbFilelist.Name = "m_clbFilelist";
            this.m_clbFilelist.Size = new System.Drawing.Size(522, 196);
            this.m_clbFilelist.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(m_btnDelete);
            this.groupBox1.Controls.Add(this.m_clbFilelist);
            this.groupBox1.Controls.Add(this.m_radioDeleteWorkingTree);
            this.groupBox1.Controls.Add(m_radioKeepWorkingTree);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 249);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delete files from solution";
            // 
            // m_radioDeleteWorkingTree
            // 
            this.m_radioDeleteWorkingTree.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_radioDeleteWorkingTree.AutoSize = true;
            this.m_radioDeleteWorkingTree.Location = new System.Drawing.Point(179, 20);
            this.m_radioDeleteWorkingTree.Name = "m_radioDeleteWorkingTree";
            this.m_radioDeleteWorkingTree.Size = new System.Drawing.Size(173, 16);
            this.m_radioDeleteWorkingTree.TabIndex = 0;
            this.m_radioDeleteWorkingTree.Text = "Delete Working Tree Files";
            this.m_radioDeleteWorkingTree.UseVisualStyleBackColor = true;
            // 
            // FormDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 244);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDelete";
            this.Text = "Delete";
            this.Load += new System.EventHandler(this.FormDelete_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnCancel;
        private CheckedListBox m_clbFilelist;
        private GroupBox groupBox1;
        private RadioButton m_radioDeleteWorkingTree;
    }
}