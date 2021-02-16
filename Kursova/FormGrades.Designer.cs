namespace UniversitySystem
{
    partial class FormGrades
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
            this.listViewGrades = new System.Windows.Forms.ListView();
            this.columnSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGrade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxFacultyNum = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // listViewGrades
            // 
            this.listViewGrades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.listViewGrades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewGrades.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSubject,
            this.columnGrade});
            this.listViewGrades.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.listViewGrades.ForeColor = System.Drawing.Color.SeaShell;
            this.listViewGrades.FullRowSelect = true;
            this.listViewGrades.GridLines = true;
            this.listViewGrades.HideSelection = false;
            this.listViewGrades.Location = new System.Drawing.Point(27, 172);
            this.listViewGrades.Name = "listViewGrades";
            this.listViewGrades.Size = new System.Drawing.Size(856, 260);
            this.listViewGrades.TabIndex = 0;
            this.listViewGrades.UseCompatibleStateImageBehavior = false;
            this.listViewGrades.View = System.Windows.Forms.View.Details;
            this.listViewGrades.DoubleClick += new System.EventHandler(this.listViewGrades_DoubleClick_1);
            // 
            // columnSubject
            // 
            this.columnSubject.Text = "Subject";
            this.columnSubject.Width = 345;
            // 
            // columnGrade
            // 
            this.columnGrade.Text = "Grade";
            this.columnGrade.Width = 350;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(418, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Faculty Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(12, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold);
            this.textBoxName.ForeColor = System.Drawing.Color.SeaShell;
            this.textBoxName.Location = new System.Drawing.Point(100, 120);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(286, 29);
            this.textBoxName.TabIndex = 3;
            // 
            // textBoxFacultyNum
            // 
            this.textBoxFacultyNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.textBoxFacultyNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFacultyNum.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold);
            this.textBoxFacultyNum.ForeColor = System.Drawing.Color.SeaShell;
            this.textBoxFacultyNum.Location = new System.Drawing.Point(585, 120);
            this.textBoxFacultyNum.Name = "textBoxFacultyNum";
            this.textBoxFacultyNum.ReadOnly = true;
            this.textBoxFacultyNum.Size = new System.Drawing.Size(298, 29);
            this.textBoxFacultyNum.TabIndex = 4;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.buttonBack.ForeColor = System.Drawing.Color.SeaShell;
            this.buttonBack.Location = new System.Drawing.Point(778, 465);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(114, 32);
            this.buttonBack.TabIndex = 5;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 66);
            this.panel1.TabIndex = 6;
            // 
            // FormGrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(918, 509);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.textBoxFacultyNum);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewGrades);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGrades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGrades";
            this.Load += new System.EventHandler(this.FormGrades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewGrades;
        private System.Windows.Forms.ColumnHeader columnGrade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxFacultyNum;
        protected System.Windows.Forms.ColumnHeader columnSubject;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panel1;
    }
}