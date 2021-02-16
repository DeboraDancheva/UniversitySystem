using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversitySystem
{
    public static class StringExtensions
    {
        public static List<Student> FilterStudentList(this string input, List<Student> students , ListView lv )
        {
            input = input.ToLower();
           
                lv.Items.Clear();
                List<Student> newList;

                if (input.All(char.IsDigit))
                  return  newList = students.Where(student => student.FacultyNum.StartsWith(input)).ToList();
                else
                  return  newList = students.Where(student => student.BasicInfo()[0].ToLower().StartsWith(input)).ToList();
        }

        public static List<Teacher> FilterTeacherList(this string input, List<Teacher> teachers, ListView lv)
        {
            input = input.ToLower();

            lv.Items.Clear();
            List<Teacher> newList;
            if (input.All(char.IsDigit))
              return  newList = teachers.Where(teacher => teacher.ID.ToString().StartsWith(input)).ToList();
            else
              return  newList = teachers.Where(teacher => teacher.BasicInfo()[0].ToLower().StartsWith(input)).ToList();
        }

        
    }
}
