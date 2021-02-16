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
    public partial class FormGrades : Form
    {
        FillFacultesSpecialtiesSubjects newFill = new FillFacultesSpecialtiesSubjects();
        Xml xmlOperations = new Xml();
        ListViewItem avrSuccess;
        double averageSucces = 0;     
        
        public FormGrades(Student st)
        {
            Student = st;
            InitializeComponent();           
        } 

        public Student Student { get; set; }

        private void FormGrades_Load(object sender, EventArgs e)
        {
            textBoxName.Text = Student.Name;
            textBoxFacultyNum.Text = Student.FacultyNum;
            int lastIndex = listViewGrades.Items.Count - 1;

            textBoxName.ReadOnly = true;
            textBoxFacultyNum.ReadOnly = true;

            FillListView();

            if (listViewGrades.Items.Count > 0)
            {
                listViewGrades.FullRowSelect = true;

                listViewGrades.Select();
            }         
        }
       
        protected void FillListView()
        {
            foreach (var subject in Student.Specialty.Subjects)
            {
                string[] row = new string[2];
                Grade currGrade = Student.Grades.FirstOrDefault(grade => grade.SubjectID == subject.ID);

                row[0] = subject.Name;

                if (currGrade != null)
                    row[1] = currGrade.Value.ToString();

                else
                    row[1] = "-";

                var listViewItem = new ListViewItem(row);
                listViewGrades.Items.Add(listViewItem);
                listViewItem.Font = new System.Drawing.Font("Century Gothic", 12, System.Drawing.FontStyle.Bold);
            }

            string[] lastRow = { "Average success:", "-" };

            if (Student.Grades.Count > 0)
            {
                averageSucces = Math.Round(Student.Grades.Select(x => x.Value).ToList().Average(), 2);
                lastRow[1] = averageSucces.ToString();
            }
            avrSuccess = new ListViewItem(lastRow);
            listViewGrades.Items.Add(avrSuccess);
            avrSuccess.Font = new System.Drawing.Font("Century Gothic", 12, System.Drawing.FontStyle.Bold);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listViewGrades_DoubleClick_1(object sender, EventArgs e)
        {
            Grade newGrade = new Grade();
            FormAddGrade addGradeForm = new FormAddGrade();
            int selectedIndex = listViewGrades.SelectedIndices[0];
            int lastIndex = listViewGrades.Items.Count - 1;

            Subject selectedSubject = Student.
                                      Specialty.
                                      Subjects.
                                      FirstOrDefault(subject => subject.Name == listViewGrades.Items[selectedIndex].Text);

            addGradeForm.Grade = newGrade;

            if (selectedIndex != lastIndex)
            {              
                if (addGradeForm.ShowDialog() == DialogResult.OK)
                {
                    newGrade.SubjectID = selectedSubject.ID;

                    if (!(Student.Grades.FirstOrDefault(x => x.SubjectID == newGrade.SubjectID) == null))
                        Student.Grades.FirstOrDefault(x => x.SubjectID == newGrade.SubjectID).Value = newGrade.Value;
                    else
                        Student.Grades.Add(newGrade);

                    listViewGrades.SelectedItems[0].SubItems[1].Text = newGrade.Value.ToString();
                    xmlOperations.AddGradeToXml(Student, newGrade);
                }
                this.Show();
                averageSucces = Math.Round((Student.Grades.Select(x => x.Value).Average()), 2);
                listViewGrades.Items[avrSuccess.Index].SubItems[1].Text = averageSucces.ToString();
            }
        }
    }
}
