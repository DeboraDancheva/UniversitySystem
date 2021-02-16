using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Specialty
    {
        private List<Subject> subjects;
        private string name;



        public List<Subject> Subjects
        {
            get
            {
                if (subjects == null)
                    subjects = new List<Subject>();

                return subjects;
            }
            set
            {
                if (subjects == value)
                    return;

                subjects = value;
            }
        }

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
    }
}
