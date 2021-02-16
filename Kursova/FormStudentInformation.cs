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
using System.Xml;
using XmlOperations;

namespace UniversitySystem
{
    public partial class FormStudentInformation : Form
    {

        Validation validation = new Validation();
        Xml xmlOperations = new Xml();
        List<Faculty> Faculties;
        List<Student> students;
        string lastID;
        string lastFacNum;
      
        string message = string.Empty;

        public bool InformationIsUpdated { get; set; }

        public Student Student { get; set; }

        public FormStudentInformation(List<Faculty> faculties, List<Student> Students)
        {
            InitializeComponent();

            Faculties = faculties;
            students = Students;

            InformationIsUpdated = false;
        }

        private void FormStudentInformation_Load(object sender, EventArgs e)
        {
            textBoxFirstName.Text = Student.Name;
            textBoxSurname.Text = Student.Surname;
            textBoxLastName.Text = Student.LastName;
            textBoxAdress.Text = Student.Address;
            textBoxID.Text = Student.ID;
            textBoxFacultyNum.Text = Student.FacultyNum;
            comboBoxFaculty.Text = Student.Faculty.Name;
            comboBoxSpecialty.Text = Student.Specialty.Name;

            AddFacultyToComboBox(comboBoxFaculty);
            AddSpecialtiesToComboBox(comboBoxFaculty, comboBoxSpecialty);

            lastFacNum = Student.FacultyNum;
            lastID = Student.ID;
        }


        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (CheckIfDataIsFilled())
            {
                this.DialogResult = DialogResult.OK;
                if(InformationIsUpdated==true)
                xmlOperations.EditStudentXML(this.Student, lastID);
                this.Close();
            }
        }

        private void buttonViewGrade_Click(object sender, EventArgs e)
        {
            if (CheckIfDataIsFilled())
            {
                xmlOperations.EditStudentXML(this.Student, lastID);
                FormGrades newFormGrades = new FormGrades(Student);
                this.Hide();
                if (newFormGrades.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }

        private void comboBoxFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSpecialty.Items.Clear();
            comboBoxSpecialty.Text = string.Empty;
            AddSpecialtiesToComboBox(comboBoxFaculty, comboBoxSpecialty);

            if (!string.IsNullOrEmpty(comboBoxFaculty.Text) && comboBoxFaculty.Text != Student.Faculty.Name)
            {
                Student.Faculty = Faculties.FirstOrDefault(x => x.Name == comboBoxFaculty.Text);
                InformationIsUpdated = true;
                Student.Grades.Clear();
            }

        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFirstName.Text) && textBoxFirstName.Text != Student.Name)
            {
                InformationIsUpdated = true;
                Student.Name = textBoxFirstName.Text;
            }

        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSurname.Text) && textBoxSurname.Text != Student.Surname)
            {
                InformationIsUpdated = true;
                Student.Surname = textBoxSurname.Text;
            }

        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLastName.Text) && textBoxLastName.Text != Student.LastName)
            {
                InformationIsUpdated = true;
                Student.LastName = textBoxLastName.Text;
            }

        }

        private void textBoxAdress_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxAdress.Text) && textBoxAdress.Text != Student.Address)
            {
                Student.Address = textBoxAdress.Text;
                InformationIsUpdated = true;
            }
        }


        private void comboBoxSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxSpecialty.Text) && comboBoxSpecialty.Text != Student.Specialty.Name)
            {
                Student.Specialty = Student.Faculty.Specialties.FirstOrDefault(x => x.Name == comboBoxSpecialty.Text);
                InformationIsUpdated = true;
                Student.Grades.Clear();
            }
        }

        private void FormStudentInformation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && CheckIfDataIsFilled() && IdValidation() && facultyNumValidation())
            {
                this.DialogResult = DialogResult.OK;
                xmlOperations.EditStudentXML(this.Student, lastID);
                this.Close();
            }
        }

        private void comboBoxFaculty_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("You can only choose from the list!");
            comboBoxFaculty.Text = string.Empty;
        }

        private void comboBoxSpecialty_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("You can only choose from the list!");
            comboBoxSpecialty.Text = string.Empty;
        }             

        private void textBoxID_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxID.Text) && IdValidation())
            {
                Student.ID = textBoxID.Text;
                InformationIsUpdated = true;
            }
        }

        private void textBoxFacultyNum_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFacultyNum.Text) && facultyNumValidation())
            {
                Student.FacultyNum = textBoxFacultyNum.Text;
                InformationIsUpdated = true;
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
            if (!validation.CheckIfFacultyNumIsUnique(textBoxFacultyNum.Text, students.Where(x => x.FacultyNum != lastFacNum).ToList()))
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
            if (!validation.CheckIfIdIsUnique(textBoxID.Text, students.Where(x => x.ID != lastID).ToList()))
            {
                MessageBox.Show("Student with this ID already exist \n ");
                textBoxID.Select();
                return false;
            }
            return true;
        }

        public void AddSpecialtiesToComboBox(ComboBox comboFaculty, ComboBox comboSpecialty)
        {
            Faculty currFaculty = Faculties.
                                   FirstOrDefault(x => x.Name == comboFaculty.Text);

            foreach (var specialty in currFaculty.Specialties)
            {
                comboSpecialty.Items.Add(specialty.Name);
            }
        }

        public void AddFacultyToComboBox(ComboBox comboFaculty)
        {

            foreach (var faculty in Faculties)
            {
                comboFaculty.Items.Add(faculty.Name);
            }
        }

        private bool CheckIfDataIsFilled()
        {
            TextBox[] textBoxes = { textBoxAdress, textBoxFacultyNum, textBoxFirstName, textBoxID, textBoxLastName, textBoxSurname };
            ComboBox[] comboBoxes = { comboBoxFaculty, comboBoxSpecialty };

            return validation.CheckIfAllBoxesAreFilled(textBoxes, comboBoxes);
        }
    }

}
