using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace UniversitySystem
{
    public class FillFacultesSpecialtiesSubjects
    {

        public List<Faculty> Faculties { get; set; } = new List<Faculty>();

        public FillFacultesSpecialtiesSubjects()
        {
            
        }

      

        public void AddSpecialtiesToComboBox(ComboBox comboFaculty, ComboBox comboSpecialty)
        {
            Faculty currFaculty = Faculties.
                                   FirstOrDefault(faculty => faculty.Name == comboFaculty.Text);

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
      
    }
}
