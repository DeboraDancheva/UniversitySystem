using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlOperations;

namespace UniversitySystem
{
    public partial class FormAddStudent : Form
    {
        Validation validation = new Validation();
        Xml XmlOperations = new Xml();
        List<Faculty> Faculties;
        List<Student> students;

        public FormAddStudent(List<Faculty> faculties, List<Student> studentsList)
        {
            InitializeComponent();
            Faculties = faculties;
            students = studentsList;
        }

        public Student Student { get; set; }

        private void buttonDone_Click(object sender, EventArgs e)
        {          
            if (CheckIfDataIsFilled())
            {
                SaveData();
                DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        private void FormAddStudent_Load(object sender, EventArgs e)
        {
            AddFacultyToComboBox(comboBoxFaculty);
        }

        private void comboBoxFaculty_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBoxSpecialty.Items.Clear();
            comboBoxSpecialty.Text = string.Empty;
            AddSpecialtiesToComboBox(comboBoxFaculty, comboBoxSpecialty);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxSpecialty_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("You can only choose from the list!");
            comboBoxSpecialty.Text = string.Empty;
        }

        private void comboBoxFaculty_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("You can only choose from the list!");
            comboBoxFaculty.Text = string.Empty;
        }      

        private void textBoxID_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxID.Text))
            {
                IdValidation();
            }
        }

        private void textBoxFacultyNum_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFacultyNum.Text))
            {
                facultyNumValidation();
            }
        }
      
        private void FormAddStudent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && CheckIfDataIsFilled())
            {
                SaveData();
                DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private bool facultyNumValidation()
        {
            if (!validation.ValidateTextBoxLength(textBoxFacultyNum))
            {
                MessageBox.Show("Faculty number must be 10 digit number! \n ");
                textBoxFacultyNum.Select();
                return false;
            }

            if (!validation.CheckIfAllCharsAreDigit(textBoxFacultyNum))
            {
                MessageBox.Show("Faculty must contain only digits! \n ");
                textBoxFacultyNum.Select();
                return false;
            }
            if (!validation.CheckIfFacultyNumIsUnique(textBoxFacultyNum.Text, students))
            {
                MessageBox.Show("Student with this faculty number already exist");
                textBoxFacultyNum.Select();
                return false;
            }
            return true;
        }

        private bool IdValidation()
        {
            if (!validation.ValidateTextBoxLength(textBoxID))
            {
                MessageBox.Show("ID number must be 10 digit number! \n ");
                textBoxID.Select();
                return false;
            }

            if (!validation.CheckIfAllCharsAreDigit(textBoxID))
            {
                MessageBox.Show("ID must contain only digits! \n ");
                textBoxID.Select();
                return false;
            }
            if (!validation.CheckIfIdIsUnique(textBoxID.Text, students))
            {
                MessageBox.Show("Student with this ID already exist \n ");
                textBoxID.Select();
                return false;
            }
            return true;
        }

        private void SaveData()
        {
            if (IdValidation() && facultyNumValidation())
            {
                Student.Name = textBoxFirstName.Text;
                Student.Surname = textBoxSurname.Text;
                Student.LastName = textBoxLastName.Text;
                Student.Address = textBoxAdress.Text;
                Student.ID = textBoxID.Text;
                Student.FacultyNum = textBoxFacultyNum.Text;

                Student.Faculty = Faculties.
                    FirstOrDefault(faculty => faculty.Name == comboBoxFaculty.Text);

                Student.Specialty = Student.Faculty.Specialties.
                    FirstOrDefault(specialty => specialty.Name == comboBoxSpecialty.Text);
            }
        }

        private bool CheckIfDataIsFilled()
        {
            TextBox[] textBoxes = { textBoxAdress, textBoxFacultyNum, textBoxFirstName, textBoxID, textBoxLastName, textBoxSurname };
            ComboBox[] comboBoxes = { comboBoxFaculty, comboBoxSpecialty };

            return validation.CheckIfAllBoxesAreFilled(textBoxes, comboBoxes);

        }

        private void AddSpecialtiesToComboBox(ComboBox comboFaculty, ComboBox comboSpecialty)
        {
            Faculty currFaculty = Faculties.
                                   FirstOrDefault(faculty => faculty.Name == comboFaculty.Text);

            foreach (var specialty in currFaculty.Specialties)
            {
                comboSpecialty.Items.Add(specialty.Name);
            }
        }

        private void AddFacultyToComboBox(ComboBox comboFaculty)
        {
            foreach (var faculty in Faculties)
            {
                comboFaculty.Items.Add(faculty.Name);
            }
        }
    }
}
