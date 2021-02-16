using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student : Person
    {
        private string facultyNum;
        private Faculty faculty;
        private Specialty specialty;
        private List<Grade> grades;

        public string FacultyNum
        {
            get
            {
                return facultyNum;
            }
            set
            {
                if (facultyNum == value)
                    return;

                facultyNum = value;
            }
        }

        public Faculty Faculty
        {
            get
            {
                return faculty;
            }
            set
            {
                if (faculty == value)
                    return;

                faculty = value;
            }
        }

        public Specialty Specialty
        {
            get
            {
                return specialty;
            }
            set
            {
                if (specialty == value)
                    return;

                specialty = value;
            }
        }

        public List<Grade> Grades
        {
            get
            {
                if (grades == null)
                    grades = new List<Grade>();

                return grades;
            }
            set
            {
                if (grades == value)
                    return;

                grades = value;
            }
        }

        public override string[] BasicInfo()
        {
            string[] info = { getName(), FacultyNum };
            return info;
        }
    }
}
