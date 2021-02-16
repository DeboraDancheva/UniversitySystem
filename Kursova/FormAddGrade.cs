using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace UniversitySystem
{
    public partial class FormAddGrade : Form
    {
        public Grade Grade { get; set; }

        public FormAddGrade()
        {
            InitializeComponent();
            
          
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            int value = 0;
            try
            {
                 value = Convert.ToInt32(textBoxGrade.Text);
            }
            catch
            {
                MessageBox.Show("Grade's value must be an integer!");
                textBoxGrade.Select();
                return;
            }

            if(value<2 || value>6)
            {
                MessageBox.Show("Grade's value must be between 2 and 6!");
                textBoxGrade.Select();
                return;
            }

            Grade.Value = value;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
