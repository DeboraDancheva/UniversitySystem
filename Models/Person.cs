using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Models
{
    public class Person
    {
        private string id;
        private string name;
        private string surname;
        private string lastName;
        private string address;

        public string ID
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

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (surname == value)
                    return;

                surname = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (lastName == value)
                    return;

                lastName = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (address == value)
                    return;

                address = value;
            }
        }

        public virtual string[] BasicInfo()
        {
            string[] info = { getName(), ID.ToString() };
            return info;
        }

        protected virtual string getName()
        {
            return Name + " " + LastName;
        }

        public void AddPersonToListView(ListView Lv, Person person)
        {
            var listViewItem = new ListViewItem(person.BasicInfo());
            Lv.Items.Add(listViewItem);
            listViewItem.Font = new System.Drawing.Font("Century Gothic", 12, System.Drawing.FontStyle.Bold);

        }
    }
}
