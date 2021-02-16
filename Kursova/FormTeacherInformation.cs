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


namespace UniversitySystem
{
    public partial class FormTeacherInformation : Form
    {
        Validation validation = new Validation();
        
        string finalMessage = string.Empty;
        string message = string.Empty;
        string lastID;

        List<Teacher> teachers;

        public Teacher Teacher { get; set; }
        public bool InformationIsUpdated { get; set;}

        public FormTeacherInformation(List<Teacher> teachers)
        {
            InitializeComponent();

            InformationIsUpdated = false;

            this.teachers = teachers;
          
        }
        private void FormTeacherInformation_Load(object sender, EventArgs e)
        {
            textBoxFirstName.Text = Teacher.Name;
            textBoxSurname.Text = Teacher.Surname;
            textBoxLastName.Text = Teacher.LastName;
            textBoxAdress.Text = Teacher.Address;
            textBoxID.Text = Teacher.ID.ToString();
            textBoxPhone.Text = Teacher.PhoneNumber;
            textBoxCabinet.Text = Teacher.CabinetNumber;
            comboBoxDegree.Text = Teacher.Degree;

            lastID = Teacher.ID;
            AddDegreeToComboBox();
        }

      
        private void buttonDone_Click_1(object sender, EventArgs e)
        {
            if (CheckIfDataIsFilled())
            {
                DialogResult = DialogResult.OK;               

                this.Close();
            }            
        }


        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFirstName.Text) && textBoxFirstName.Text != Teacher.Name)
            {
                Teacher.Name = textBoxFirstName.Text;
                InformationIsUpdated = true;
            }
        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSurname.Text) && textBoxSurname.Text != Teacher.Surname)
            {
                Teacher.Surname = textBoxSurname.Text;
                InformationIsUpdated = true;
            }
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLastName.Text) && textBoxLastName.Text != Teacher.LastName)
            {
                Teacher.LastName = textBoxLastName.Text;
                InformationIsUpdated = true;
            }
        }

        private void textBoxAdress_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxAdress.Text) && textBoxAdress.Text != Teacher.Address)
            {
                Teacher.Address = textBoxAdress.Text;
                InformationIsUpdated = true;
            }
        }


        private void textBoxCabinet_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxCabinet.Text) && textBoxCabinet.Text != Teacher.CabinetNumber)
            {
                Teacher.CabinetNumber = textBoxCabinet.Text;
                InformationIsUpdated = true;
            }
        }

        private void comboBoxDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxDegree.Text) && comboBoxDegree.Text != Teacher.Degree)
            {
                Teacher.Degree = comboBoxDegree.Text;
                InformationIsUpdated = true;
            }
        }

        private void FormTeacherInformation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && CheckIfDataIsFilled() && IdValidation() && phoneValidation())
            {                
                    DialogResult = DialogResult.OK;               

                this.Close();                
            }
        }
       

        private void textBoxID_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxID.Text) && textBoxID.Text != Teacher.ID && IdValidation() )
            {
                
                Teacher.ID = textBoxID.Text;
                InformationIsUpdated = true;
            }
        }

        private void textBoxPhone_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPhone.Text) && textBoxPhone.Text != Teacher.ID  && phoneValidation())
            {               
                Teacher.PhoneNumber = textBoxPhone.Text;
                InformationIsUpdated = true;
            }
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
            if (!validation.CheckIfIdIsUnique(textBoxID.Text, teachers.Where(x => x.ID != lastID).ToList()))
            {
                MessageBox.Show("Teacher with this ID already exist \n ");
                textBoxID.Select();
                return false;
            }
            return true;

        }

        private bool phoneValidation()
        {
            if (!validation.ValidateTextBoxLength(textBoxPhone))
            {
                MessageBox.Show("Phone number must be 10 digit number! \n ");
                textBoxPhone.Select();
                return false ;
            }

            if (!validation.CheckIfAllCharsAreDigit(textBoxPhone))
            {
                MessageBox.Show("Phone must contain only digits! \n ");
                textBoxPhone.Select();
                return false;
            }
            return true;
        }
        
        private void comboBoxDegree_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("You can only choose from the list!");
            comboBoxDegree.Text = string.Empty;
        }

        public void AddDegreeToComboBox()
        {

            comboBoxDegree.Items.Add("Assistant");
            comboBoxDegree.Items.Add("Docent");
            comboBoxDegree.Items.Add("Doctor");
            comboBoxDegree.Items.Add("Professor");

        }

        private bool CheckIfDataIsFilled()
        {
            TextBox[] textBoxes = { textBoxFirstName, textBoxSurname, textBoxLastName, textBoxAdress, textBoxID, textBoxPhone, textBoxCabinet };
            ComboBox[] comboBoxes = { comboBoxDegree };

            return validation.CheckIfAllBoxesAreFilled(textBoxes, comboBoxes);

        }
    }
}
