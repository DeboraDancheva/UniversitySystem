using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Faculty
    {
        private string name;
        private List<Specialty> specialties;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name == value)
                    return;

                name = value;
            }
        }

        public List<Specialty> Specialties
        {
            get
            {
                if (specialties == null)
                    specialties = new List<Specialty>();

                return specialties;

            }
            set
            {
                if (specialties == value)
                    return;

                specialties = value;
            }
        }
    }
}
