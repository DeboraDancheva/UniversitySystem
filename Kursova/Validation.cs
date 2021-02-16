using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace UniversitySystem
{
    public class Validation
    {
        public bool ValidateTextBoxLength(TextBox textBox)
        {
            if (textBox.TextLength != 10)
                return false;

            return true;
        }

        public bool CheckIfAllCharsAreDigit(TextBox textBox)
        {
            if (!(textBox.Text.All(char.IsDigit)))
            {
                return false;
            }
            return true;
        }

        public bool CheckIfAllBoxesAreFilled(TextBox[] textBoxes, ComboBox[] comboBoxes)
        {
            bool textBoxesChecked = true;
            bool comboBoxesChecked = true;

            foreach (var box in textBoxes)
            {
                if (box.Text == string.Empty)
                {
                    textBoxesChecked = false;
                    break;
                }
            }

            foreach (var box in comboBoxes)
            {
                if (box.Text == string.Empty)
                {
                    comboBoxesChecked = false;
                    break;
                }
            }

            if (textBoxesChecked && comboBoxesChecked)
                return true;
            else
            {
                MessageBox.Show(" You need to fill all the information! ");
                return false;
            }
        }
        public bool CheckIfIdIsUnique(string id, List<Student> students)
        {
            if (students.Any(p => p.ID == id))
                return false;

            return true;
        }
        public bool CheckIfIdIsUnique(string id, List<Teacher> teachers)
        {
            if (teachers.Any(p => p.ID == id))
                return false;

            return true;
        }
        public bool CheckIfFacultyNumIsUnique(string facultyNum, List<Student> students)
        {
            if (students.Any(st => st.FacultyNum == facultyNum))
                return false;

            return true;
        }
       
    }
}
