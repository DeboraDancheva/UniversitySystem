using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Subject
    {
        private string name;
        private int id;

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

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                if (id == value)
                    return;

                id = value;
            }
        }
    }
}
