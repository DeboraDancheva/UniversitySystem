using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlOperations
{
    public class Xml
    {
        private string path;
        private string pathFaculties;
        public Xml()
        {
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            pathFaculties = Path.Combine(projectPath, @"Faculties.xml");
            
            path = Path.Combine(projectPath, "peoplee.xml");

        }
        protected XmlDocument GetPeopleXmlDocument()
        {
            XmlDocument xmlDoc = new XmlDocument();

            if (!File.Exists(path))
            {
                File.Create(path).Close();
                InitializateXml();
            }


            xmlDoc.Load(path);
            return xmlDoc;
        }

        protected XmlDocument GetFacultiesXmlDocument()
        {
            XmlDocument xmlDoc = new XmlDocument();

            if (!File.Exists(pathFaculties))
                File.Create(pathFaculties);

            xmlDoc.Load(pathFaculties);
            return xmlDoc;
        }

        //public XmlNodeList GetStudentsNodesFromXML()
        //{
        //    XmlDocument xmlDoc = GetXmlDocument();

        //    var studentsNodes = xmlDoc.SelectNodes("People//Person//Student");
        //    return studentsNodes;
        //}
        public void InitializateXml()
        {
            using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartElement("People");

                writer.WriteStartElement("Students");
                //writer.WriteStartElement("Student");
                //writer.WriteEndElement();//student
                writer.WriteEndElement();//students

                writer.WriteStartElement("Teachers");
                //writer.WriteStartElement("Teacher");
                //writer.WriteEndElement();//teacher
                writer.WriteEndElement();//teachers


                writer.WriteEndElement();//people

            }
        }


        public void RemoveStudentFromXML(Person person)
        {
            XmlDocument xmlDoc = GetPeopleXmlDocument();


            foreach (XmlNode xmlNode in xmlDoc.SelectNodes("People//Students/Student"))
            {
                if (xmlNode.SelectSingleNode("ID").InnerText == person.ID.ToString())
                    xmlNode.ParentNode.RemoveChild(xmlNode);

            }
            xmlDoc.Save(path);
        }

        public void AddStudentToXML(Student student)
        {
            XmlDocument xmlDoc = GetPeopleXmlDocument();
           

            XmlElement newStudent = xmlDoc.CreateElement("Student");


            XmlNode Name = xmlDoc.CreateElement("Name");
            Name.InnerText = student.Name;
            newStudent.AppendChild(Name);

            XmlNode Surname = xmlDoc.CreateElement("Surname");
            Surname.InnerText = student.Surname;
            newStudent.AppendChild(Surname);

            XmlNode Lastname = xmlDoc.CreateElement("LastName");
            Lastname.InnerText = student.LastName;
            newStudent.AppendChild(Lastname);

            XmlNode Address = xmlDoc.CreateElement("Address");
            Address.InnerText = student.Address;
            newStudent.AppendChild(Address);

            XmlNode ID = xmlDoc.CreateElement("ID");
            ID.InnerText = student.ID.ToString();
            newStudent.AppendChild(ID);

            XmlNode FacultyNumber = xmlDoc.CreateElement("FacultyNumber");
            FacultyNumber.InnerText = student.FacultyNum;
            newStudent.AppendChild(FacultyNumber);

            XmlNode Faculty = xmlDoc.CreateElement("Faculty");
            Faculty.InnerText = student.Faculty.Name;
            newStudent.AppendChild(Faculty);

            XmlNode Specialty = xmlDoc.CreateElement("Specialty");
            Specialty.InnerText = student.Specialty.Name;
            newStudent.AppendChild(Specialty);


            XmlElement newGradeList = xmlDoc.CreateElement("Grades");

            foreach (var subject in student.Specialty.Subjects)
            {
                XmlElement Grade = xmlDoc.CreateElement("Grade");

                XmlNode Value = xmlDoc.CreateElement("Value");
                Value.InnerText = string.Empty;
                Grade.AppendChild(Value);

                XmlNode subjectID = xmlDoc.CreateElement("SubjectID");
                subjectID.InnerText = subject.ID.ToString();
                Grade.AppendChild(subjectID);

                newGradeList.AppendChild(Grade);
            }

            newStudent.AppendChild(newGradeList);

            xmlDoc.SelectSingleNode("People/Students").AppendChild(newStudent);
            xmlDoc.Save(path);
        }

        public List<Student> FillStudentListFromXml()
        {
            XmlDocument xmlDoc = GetPeopleXmlDocument();
            List<Student> studentList = new List<Student>();

            foreach (XmlNode node in xmlDoc.SelectNodes("People/Students/Student"))
            {
                Student currStudent = new Student();
                currStudent.Name = node.SelectSingleNode("Name").InnerText;
                currStudent.Surname = node.SelectSingleNode("Surname").InnerText;
                currStudent.LastName = node.SelectSingleNode("LastName").InnerText;
                currStudent.Address = node.SelectSingleNode("Address").InnerText;
                currStudent.ID = node.SelectSingleNode("ID").InnerText;
                currStudent.FacultyNum = node.SelectSingleNode("FacultyNumber").InnerText;

                string facultyName = (node.SelectSingleNode("Faculty").InnerText);
                currStudent.Faculty = GetFacultyList().FirstOrDefault(faculty => faculty.Name == facultyName);

                string specialtyName = (node.SelectSingleNode("Specialty").InnerText);
                currStudent.Specialty = currStudent.Faculty.Specialties.FirstOrDefault(specialty => specialty.Name == specialtyName);

                if (node.SelectSingleNode("Grades").HasChildNodes)
                {

                    foreach (XmlNode grade in node.SelectSingleNode("Grades"))
                    {
                        if (!(grade.SelectSingleNode("Value").InnerText == string.Empty))
                        {
                            Grade newGrade = new Grade();
                            newGrade.Value = Convert.ToInt32(grade.SelectSingleNode("Value").InnerText);
                            newGrade.SubjectID = Convert.ToInt32(grade.SelectSingleNode("SubjectID").InnerText);
                            currStudent.Grades.Add(newGrade);
                        }
                    }
                }

                studentList.Add(currStudent);
            }

            return studentList;
        }

      
        public List<Faculty> GetFacultyList()
        {
            XmlDocument xmlDoc = GetFacultiesXmlDocument();
            List<Faculty> Faculties = new List<Faculty>();

            foreach (XmlNode nodeFaculty in xmlDoc.SelectNodes("Faculties/Faculty"))
            {
                Faculty newFaculty = new Faculty();

                newFaculty.Name = nodeFaculty.SelectSingleNode("Name").InnerText;

                foreach (XmlNode nodeSpecialty in nodeFaculty.SelectNodes("Specialties/Specialty"))
                {
                    Specialty newSpecialty = new Specialty();
                    newSpecialty.Name = nodeSpecialty.SelectSingleNode("Name").InnerText;
                    foreach (XmlNode nodeSubject in nodeSpecialty.SelectNodes("Subjects/Subject"))
                    {
                        Subject newSubject = new Subject();
                        newSubject.Name = nodeSubject.SelectSingleNode("Name").InnerText;
                        newSubject.ID = Convert.ToInt32(nodeSubject.SelectSingleNode("ID").InnerText);
                        newSpecialty.Subjects.Add(newSubject);

                    }
                    newSpecialty.Subjects.OrderByDescending(x => x.Name);
                    newFaculty.Specialties.Add(newSpecialty);
                }
                newFaculty.Specialties.OrderByDescending(x => x.Name);
                Faculties.Add(newFaculty);
            }
            Faculties.OrderByDescending(x => x.Name);
            return Faculties;
        }

        public void AddGradeToXml(Student student, Grade grade)
        {
            XmlDocument xmlDoc = GetPeopleXmlDocument();
            foreach (XmlNode node in xmlDoc.SelectNodes("People/Students/Student"))
            {
                if (node.SelectSingleNode("ID").InnerText == student.ID.ToString())
                {

                    foreach (XmlNode xNode in node.SelectSingleNode("Grades"))
                    {
                        if (xNode.SelectSingleNode("SubjectID").InnerText == grade.SubjectID.ToString())
                        {
                            xNode.SelectSingleNode("Value").InnerText = grade.Value.ToString();
                            xmlDoc.Save(path);
                            return;
                        }

                    }
                }
            }
        }

        public void EditStudentXML(Student student, string lastID)
        {
            int counter = 0;
            XmlDocument xmlDoc = GetPeopleXmlDocument();

            foreach (XmlNode xmlNode in xmlDoc.SelectNodes("People/Students/Student"))
            {
                if (xmlNode.SelectSingleNode("ID").InnerText == lastID)

                {
                    xmlNode.SelectSingleNode("Name").InnerText = student.Name;
                    xmlNode.SelectSingleNode("Surname").InnerText = student.Surname;
                    xmlNode.SelectSingleNode("LastName").InnerText = student.LastName;
                    xmlNode.SelectSingleNode("Address").InnerText = student.Address;
                    xmlNode.SelectSingleNode("ID").InnerText = student.ID.ToString();
                    xmlNode.SelectSingleNode("FacultyNumber").InnerText = student.FacultyNum;
                    xmlNode.SelectSingleNode("Faculty").InnerText = student.Faculty.Name;
                    xmlNode.SelectSingleNode("Specialty").InnerText = student.Specialty.Name;

                    if (student.Grades.Count == 0)
                    {
                        foreach (XmlNode node in xmlNode.SelectSingleNode("Grades"))
                        {


                            node.SelectSingleNode("SubjectID").InnerText = student.Specialty.Subjects[counter].ID.ToString();

                            //if (student
                            //    .Grades
                            //    .FirstOrDefault(x => x.SubjectID.ToString() == node.SelectSingleNode("SubjectID").InnerText).Value.ToString() != string.Empty)

                            //    node.SelectSingleNode("Value").InnerText = student
                            //                                               .Grades
                            //                                              .FirstOrDefault(x => x.SubjectID.ToString() == node.SelectSingleNode("SubjectID").InnerText).Value.ToString();

                            //else
                            node.SelectSingleNode("Value").InnerText = string.Empty;

                            counter++;

                        }
                    }
                    else
                    {

                    }

                }
            }
            xmlDoc.Save(path);
        }

        //teacher



        public List<Teacher> FillTeacherListFromXml()
        {
            XmlDocument xmlDoc = GetPeopleXmlDocument();
            List<Teacher> teacherList = new List<Teacher>();

            foreach (XmlNode node in xmlDoc.SelectNodes("People/Teachers/Teacher"))
            {
                Teacher currTeacher = new Teacher();
                currTeacher.Name = node.SelectSingleNode("Name").InnerText;
                currTeacher.Surname = node.SelectSingleNode("Surname").InnerText;
                currTeacher.LastName = node.SelectSingleNode("LastName").InnerText;
                currTeacher.Address = node.SelectSingleNode("Address").InnerText;
                currTeacher.ID = node.SelectSingleNode("ID").InnerText;
                currTeacher.PhoneNumber = node.SelectSingleNode("PhoneNumber").InnerText;
                currTeacher.CabinetNumber = node.SelectSingleNode("CabinetNumber").InnerText;
                currTeacher.Degree = node.SelectSingleNode("Degree").InnerText;

                teacherList.Add(currTeacher);
            }

            return teacherList;
        }

        public void AddTeacherToXml(Teacher teacher)
        {
            XmlDocument xmlDoc = GetPeopleXmlDocument();

            
            XmlNode newTeacher = xmlDoc.CreateElement("Teacher");
           

            XmlNode Name = xmlDoc.CreateElement("Name");
            Name.InnerText = teacher.Name;
            newTeacher.AppendChild(Name);

            XmlNode Surname = xmlDoc.CreateElement("Surname");
            Surname.InnerText = teacher.Surname;
            newTeacher.AppendChild(Surname);

            XmlNode Lastname = xmlDoc.CreateElement("LastName");
            Lastname.InnerText = teacher.LastName;
            newTeacher.AppendChild(Lastname);

            XmlNode Address = xmlDoc.CreateElement("Address");
            Address.InnerText = teacher.Address;
            newTeacher.AppendChild(Address);

            XmlNode ID = xmlDoc.CreateElement("ID");
            ID.InnerText = teacher.ID.ToString();
            newTeacher.AppendChild(ID);

            XmlNode FacultyNumber = xmlDoc.CreateElement("PhoneNumber");
            FacultyNumber.InnerText = teacher.PhoneNumber;
            newTeacher.AppendChild(FacultyNumber);

            XmlNode Faculty = xmlDoc.CreateElement("CabinetNumber");
            Faculty.InnerText = teacher.CabinetNumber;
            newTeacher.AppendChild(Faculty);

            XmlNode Specialty = xmlDoc.CreateElement("Degree");
            Specialty.InnerText = teacher.Degree;
            newTeacher.AppendChild(Specialty);


            xmlDoc.SelectSingleNode("People/Teachers").AppendChild(newTeacher);
            
            xmlDoc.Save(path);
        }

        public void RemoveTeacherFromXML(Teacher teacher)
        {
            XmlDocument xmlDoc = GetPeopleXmlDocument();

            foreach (XmlNode xmlNode in xmlDoc.SelectNodes("People/Teachers/Teacher"))
            {
                if (xmlNode.SelectSingleNode("ID").InnerText == teacher.ID)
                    xmlNode.ParentNode.RemoveChild(xmlNode);

            }
            xmlDoc.Save(path);
        }

        public void EditTeacherXML(Teacher teacher)
        {
            XmlDocument xmlDoc = GetPeopleXmlDocument();

            foreach (XmlNode xmlNode in xmlDoc.SelectNodes("People/Teachers/Teacher"))
            {
                if (xmlNode.SelectSingleNode("ID").InnerText == teacher.ID)

                {
                    xmlNode.SelectSingleNode("Name").InnerText = teacher.Name;
                    xmlNode.SelectSingleNode("Surname").InnerText = teacher.Surname;
                    xmlNode.SelectSingleNode("LastName").InnerText = teacher.LastName;
                    xmlNode.SelectSingleNode("Address").InnerText = teacher.Address;
                    xmlNode.SelectSingleNode("ID").InnerText = teacher.ID;
                    xmlNode.SelectSingleNode("CabinetNumber").InnerText = teacher.CabinetNumber;
                    xmlNode.SelectSingleNode("PhoneNumber").InnerText = teacher.PhoneNumber;
                    xmlNode.SelectSingleNode("Degree").InnerText = teacher.Degree;
                }
            }
            xmlDoc.Save(path);
        }              
    }
}
