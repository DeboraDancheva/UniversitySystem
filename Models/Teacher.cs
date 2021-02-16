using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Teacher :Person
    {
        private string phoneNumber;
        private string cabinetNumber;
        private string degree;

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                if (phoneNumber == value)
                    return;

                phoneNumber = value;
            }
        }

        public string CabinetNumber
        {
            get
            {
                return cabinetNumber;
            }
            set
            {
                if (cabinetNumber == value)
                    return;

                cabinetNumber = value;
            }
        }

        public string Degree
        {
            get
            {
                return degree;
            }
            set
            {
                if (degree == value)
                    return;

                degree = value;
            }
        }
        private string Degreeabbreviation(string degree)
        {
            switch (degree)
            {
                case "Professor":
                    return "Prof.";
                case "Assistant":
                    return "As.";
                case "Docent":
                    return "Doc.";
                case "Doctor":
                    return "D-r.";
                default:
                    return string.Empty;
            }
        }
        protected override string getName()
        {
            return Degreeabbreviation(degree) + " " + base.getName();
        }
    }
}
