using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using XmlOperations;
using Models;

namespace UniversitySystem
{
    public partial class FormStudentList : Form
    {
        FormMain parentForm;

        private List<Student> studentList = new List<Student>();
        List<Faculty> Faculties;
        Xml xmlOperations = new Xml();

        public FormStudentList(FormMain fm)
        {
            InitializeComponent();

            parentForm = fm;


        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddStudent newForm = new FormAddStudent(Faculties, studentList);
            Student newStudent = new Student();
            newForm.Student = newStudent;

            this.Hide();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();

                studentList.Add(newStudent);

                newStudent.AddPersonToListView(listViewStudentList, newStudent);
                xmlOperations.AddStudentToXML(newStudent);

                //if (listViewStudentList.Items.Count > 0)
                //{
                //    listViewStudentList.FullRowSelect = true;

                //    listViewStudentList.Select();
                //}
            }
            else if (newForm.DialogResult == DialogResult.Cancel)
                this.Show();

        }


        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveStudent();
        }

        protected void AddStudentsToLV(List<Student> students)
        {
            foreach (var student in students)
            {
                student.AddPersonToListView(listViewStudentList, student);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void listViewStudentList_DoubleClick_1(object sender, EventArgs e)
        {
            FormStudentInformation FormStudentInfo = new FormStudentInformation(Faculties,studentList);
            int selectedIndex = listViewStudentList.SelectedIndices[0];
                        Student selectedStudent = studentList
                .FirstOrDefault(t => t.FacultyNum == listViewStudentList.Items[selectedIndex].SubItems[1].Text);

            //string lastID = selectedStudent.ID;

            int index = studentList.IndexOf(selectedStudent);

            FormStudentInfo.Student = selectedStudent;

            this.Hide();
            if (FormStudentInfo.ShowDialog() == DialogResult.OK)
            {
                if (FormStudentInfo.InformationIsUpdated == true)
                {
                    studentList[index] = selectedStudent;


                    listViewStudentList.Items[selectedIndex].Text = selectedStudent.BasicInfo()[0];
                    listViewStudentList.Items[selectedIndex].Font = new System.Drawing.Font("Century Gothic", 12, System.Drawing.FontStyle.Bold);

                    listViewStudentList.Items[selectedIndex].SubItems[1].Text = selectedStudent.BasicInfo()[1];
                    listViewStudentList.Items[selectedIndex].SubItems[1].Font = new System.Drawing.Font("Century Gothic", 12, System.Drawing.FontStyle.Bold);
                    
                }
                this.Show();
            }
        }

        private void FormStudentList_Load(object sender, EventArgs e)
        {

            studentList.AddRange(xmlOperations.FillStudentListFromXml());
            Faculties = xmlOperations.GetFacultyList();
            AddStudentsToLV(studentList);

            if (listViewStudentList.Items.Count > 0)
            {
                listViewStudentList.FullRowSelect = true;

                listViewStudentList.Select();
            }
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string input = textBoxSearch.Text;


            if (!String.IsNullOrEmpty(input))
                AddStudentsToLV(input.FilterStudentList(studentList, listViewStudentList));
            else
            {
                listViewStudentList.Items.Clear();
                AddStudentsToLV(studentList);
            }
        }

        private void FormStudentList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveStudent();
            }

        }

        private void RemoveStudent()
        {
            foreach (var item in listViewStudentList.SelectedItems)
            {
                int selectedIndex = listViewStudentList.SelectedIndices[0];

                var selectedStudent = studentList.
                    FirstOrDefault(
                    student => student.FacultyNum == listViewStudentList.
                    Items[selectedIndex].
                    SubItems[1].Text);

                studentList.Remove(selectedStudent);

                listViewStudentList.Items[selectedIndex].Remove();

                xmlOperations.RemoveStudentFromXML(selectedStudent);
            }
        }
    }
}

