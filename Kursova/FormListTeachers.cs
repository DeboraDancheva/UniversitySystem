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
    public partial class FormListTeachers : Form
    {
        FormMain parentForm;
        Xml XmlOperations = new Xml();
        Validation validation = new Validation();
        List<Teacher> listTeachers = new List<Teacher>();

        //public List<Teacher> ListTeacher { get; set; } = new List<Teacher>();

        public FormListTeachers(FormMain fM)
        {
            InitializeComponent();

            parentForm = fM;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddTeacher newForm = new FormAddTeacher(listTeachers);
            Teacher newTeacher = new Teacher();
            newForm.Teacher = newTeacher;
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();

                if (validation.CheckIfIdIsUnique(newTeacher.ID,listTeachers))
                {
                    listTeachers.Add(newTeacher);

                    newTeacher.AddPersonToListView(listViewTeachersList, newTeacher);

                    XmlOperations.AddTeacherToXml(newTeacher);

                    if (listViewTeachersList.Items.Count > 0)
                    {
                        listViewTeachersList.FullRowSelect = true;

                        listViewTeachersList.Select();
                    }
                }
            }
            else
            {
                this.Show();
            }
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string input = textBoxSearch.Text;

            if (!String.IsNullOrEmpty(input))
                AddTeachersListToListView(input.FilterTeacherList(listTeachers, listViewTeachersList));
            else
            {
                listViewTeachersList.Items.Clear();
                AddTeachersListToListView(listTeachers);
            }
        }

        private void listViewTeachersList_DoubleClick_1(object sender, EventArgs e)
        {
            FormTeacherInformation formTeacherInfo = new FormTeacherInformation(listTeachers);
            int selectedIndex = listViewTeachersList.SelectedIndices[0];

            Teacher selectedTeacher = listTeachers.
                FirstOrDefault(t => t.ID == listViewTeachersList.Items[selectedIndex].SubItems[1].Text);

            int index = listTeachers.IndexOf(selectedTeacher);

            formTeacherInfo.Teacher = selectedTeacher;

            if (formTeacherInfo.ShowDialog() == DialogResult.OK)
            {
                if (formTeacherInfo.InformationIsUpdated == true)
                {
                    listTeachers[index] = selectedTeacher;

                    listViewTeachersList.Items[selectedIndex].Text = selectedTeacher.BasicInfo()[0];
                    listViewTeachersList.Items[selectedIndex].Font = new System.Drawing.Font("Century Gothic", 12, System.Drawing.FontStyle.Bold);
                    listViewTeachersList.Items[selectedIndex].SubItems[1].Text = selectedTeacher.BasicInfo()[1];
                    listViewTeachersList.Items[selectedIndex].SubItems[1].Font = new System.Drawing.Font("Century Gothic", 12, System.Drawing.FontStyle.Bold);
                    XmlOperations.EditTeacherXML(selectedTeacher);
                }
                this.Show();
            }
        }

        private void FormListTeachers_Load(object sender, EventArgs e)
        {

            listTeachers.AddRange(XmlOperations.FillTeacherListFromXml());
            AddTeachersListToListView(listTeachers);

            if (listViewTeachersList.Items.Count > 0)
            {
                listViewTeachersList.FullRowSelect = true;
                listViewTeachersList.Select();
            }
        }

        private void FormListTeachers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveTeacher();
            }         
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveTeacher();
        }

        private void RemoveTeacher()
        {
            foreach (var item in listViewTeachersList.SelectedItems)
            {
                int selectedIndex = listViewTeachersList.SelectedIndices[0];

                var selectedTeacher = listTeachers.
                    FirstOrDefault(t => t.ID.ToString() == listViewTeachersList.Items[selectedIndex].SubItems[1].Text);

                listTeachers.Remove(selectedTeacher);

                listViewTeachersList.Items[selectedIndex].Remove();

                XmlOperations.RemoveTeacherFromXML(selectedTeacher);
            }
        }

        private void AddTeachersListToListView(List<Teacher> teachers)
        {
            foreach (var teacher in teachers)
            {
                teacher.AddPersonToListView(listViewTeachersList, teacher);
            }
        }
    }
}
