namespace UniversitySystem
{
    partial class FormMain
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonViewStudentList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonViewTeacherList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.SeaShell;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.ForeColor = System.Drawing.Color.LightCoral;
            this.buttonClose.Location = new System.Drawing.Point(170, 620);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(122, 37);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonViewStudentList
            // 
            this.buttonViewStudentList.BackColor = System.Drawing.Color.SeaShell;
            this.buttonViewStudentList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonViewStudentList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewStudentList.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonViewStudentList.ForeColor = System.Drawing.Color.LightCoral;
            this.buttonViewStudentList.Location = new System.Drawing.Point(116, 341);
            this.buttonViewStudentList.Name = "buttonViewStudentList";
            this.buttonViewStudentList.Size = new System.Drawing.Size(233, 47);
            this.buttonViewStudentList.TabIndex = 1;
            this.buttonViewStudentList.Text = "View Students List";
            this.buttonViewStudentList.UseVisualStyleBackColor = false;
            this.buttonViewStudentList.Click += new System.EventHandler(this.buttonViewStudentList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Script MT Bold", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaShell;
            this.label1.Location = new System.Drawing.Point(59, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 96);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome";
            // 
            // buttonViewTeacherList
            // 
            this.buttonViewTeacherList.BackColor = System.Drawing.Color.SeaShell;
            this.buttonViewTeacherList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonViewTeacherList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewTeacherList.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonViewTeacherList.ForeColor = System.Drawing.Color.LightCoral;
            this.buttonViewTeacherList.Location = new System.Drawing.Point(116, 417);
            this.buttonViewTeacherList.Name = "buttonViewTeacherList";
            this.buttonViewTeacherList.Size = new System.Drawing.Size(233, 47);
            this.buttonViewTeacherList.TabIndex = 3;
            this.buttonViewTeacherList.Text = "View Teachers List";
            this.buttonViewTeacherList.UseVisualStyleBackColor = false;
            this.buttonViewTeacherList.Click += new System.EventHandler(this.buttonViewTeacherList_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.SeaShell;
            this.label2.Location = new System.Drawing.Point(164, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 70);
            this.label2.TabIndex = 4;
            this.label2.Text = "To University System\r\n\r\n";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(456, 669);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonViewTeacherList);
            this.Controls.Add(this.buttonViewStudentList);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonViewStudentList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonViewTeacherList;
        private System.Windows.Forms.Label label2;
    }
}

