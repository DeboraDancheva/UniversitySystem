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
    public partial class FormAddTeacher : Form
    {

        public Validation validation = new Validation();
        Xml xmlOperations = new Xml();
        List<Teacher> teachers;

        public FormAddTeacher(List<Teacher> teachers)
        {
            InitializeComponent();
            this.teachers = teachers;
        }

        public Teacher Teacher { get; set; }

        private void buttonDone_Click(object sender, EventArgs e)
        {
           
            if (CheckIfDataIsFilled())
            {
                SaveData();
                DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void FormAddTeacher_Load(object sender, EventArgs e)
        {
            AddDegreeToComboBox();
            comboBoxDegree.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }       

        private void textBoxID_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxID.Text))
            {
                if (!validation.ValidateTextBoxLength(textBoxID))
                {
                    MessageBox.Show("ID number must be 10 digit number! \n ");
                    textBoxID.Select();
                    return;
                }
                if (!validation.CheckIfAllCharsAreDigit(textBoxID))
                {
                    MessageBox.Show("ID must contain only digits! \n ");
                    textBoxID.Select();
                    return;
                }
                if (!validation.CheckIfIdIsUnique(textBoxID.Text, teachers))
                {
                    MessageBox.Show("Teacher with this ID already exist \n ");
                    textBoxID.Select();
                    return;
                }           
               
            }
        }

        private void textBoxPhone_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPhone.Text))
            {
                if (!validation.ValidateTextBoxLength(textBoxPhone))
                {
                    MessageBox.Show("Phone number must be 10 digit number! \n ");
                    textBoxPhone.Select();
                    return;
                }

                if (!validation.CheckIfAllCharsAreDigit(textBoxPhone))
                {
                    MessageBox.Show("Phone must contain only digits! \n ");
                    textBoxPhone.Select();
                    return;
                }                       
            }
        }      

        private void comboBoxDegree_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("You can only choose from the list!");
            comboBoxDegree.Text = string.Empty;
        }

        private bool CheckIfDataIsFilled()
        {
            TextBox[] textBoxes = { textBoxFirstName, textBoxSurname, textBoxLastName, textBoxAdress, textBoxID, textBoxPhone, textBoxCabinet };
            ComboBox[] comboBoxes = { comboBoxDegree };

            return validation.CheckIfAllBoxesAreFilled(textBoxes, comboBoxes);
        }

        public void AddDegreeToComboBox()
        {

            comboBoxDegree.Items.Add("Assistant");
            comboBoxDegree.Items.Add("Docent");
            comboBoxDegree.Items.Add("Doctor");
            comboBoxDegree.Items.Add("Professor");

        }
        private void SaveData()
        {

            Teacher.Name = textBoxFirstName.Text;
            Teacher.Surname = textBoxSurname.Text;
            Teacher.LastName = textBoxLastName.Text;
            Teacher.Address = textBoxAdress.Text;
            Teacher.ID = textBoxID.Text;
            Teacher.PhoneNumber = textBoxPhone.Text;
            Teacher.CabinetNumber = textBoxCabinet.Text;
            Teacher.Degree = comboBoxDegree.Text;

        }
        private void FormAddTeacher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && CheckIfDataIsFilled())
            {
                SaveData();
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
