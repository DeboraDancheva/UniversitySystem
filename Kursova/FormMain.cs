using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversitySystem
{
    public partial class FormMain : Form
    {

        FormListTeachers formLT;
        FormStudentList formSL;

        public FormMain()
        {
            InitializeComponent();
            formLT = new FormListTeachers(this);
            formSL = new FormStudentList(this);
        }
       

        private void buttonViewStudentList_Click(object sender, EventArgs e)
        {

            formSL.Show();
            this.Hide();

        }

        private void buttonViewTeacherList_Click(object sender, EventArgs e)
        {
            formLT.Show();
            this.Hide();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}