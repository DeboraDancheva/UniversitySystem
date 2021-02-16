using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Grade
    {
        private int value;
        private int subjectID;

        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (this.value == value)
                    return;

                this.value = value;

            }
        }

        public int SubjectID
        {
            get
            {
                return subjectID;
            }
            set
            {
                if (subjectID == value)
                    return;

                subjectID = value;

            }
        }
    }
}
