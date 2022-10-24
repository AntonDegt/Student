using System;
using System.Collections.Generic;

namespace ConsoleСSApp
{
    class Person : ICloneable
    {
        private string name;
        public string Name
        {
            set
            {
                if (value.Length > 1) name = value;
                else throw new Exception("Name is short.");
            }
            get
            {
                return name;
            }
        }

        private string surname;
        public string Surname
        {
            set
            {
                if (value.Length > 1) surname = value;
            }
            get
            {
                return surname;
            }
        }

        private Date dateOfBirth;
        public Date DateOfBirth { set; get; }

        private string address;
        public string Address
        {
            set
            {
                if (value.Length > 5) address = value;
                else throw new Exception("Address isn`t correct.");
            }
            get
            {
                return address;
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            set
            {
                if (value.Length >= 8) phoneNumber = value;
            }
            get
            {
                return phoneNumber;
            }
        }

        public Person(string Name, string Surname, Date DateOfBirth, string Address, string PhoneNumber)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.DateOfBirth = DateOfBirth;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
        }
        public Person(string Name, string Surname, Date DateOfBirth, string Address)
            : this(Name, Surname, DateOfBirth, Address, "+380998877666") { }
        public Person(string Name, string Surname, Date DateOfBirth)
            : this(Name, Surname, DateOfBirth, "Ukraine") { }
        public Person()
            : this("PersonName", "PersonSurname", new Date(2000, 1, 1)) { }

        public override string ToString()
        {
            return (string)(Name + " " + Surname + " " + DateOfBirth + " " + Address + " " + PhoneNumber);
        }

        public object Clone()
        {
            return new Person(Name, Surname, DateOfBirth, Address, PhoneNumber);
        }


        public class NameComparer : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
        public class SurnameComparer : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.Surname.CompareTo(y.Surname);
            }
        }

        public class DateOfBirthCompare : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.DateOfBirth.CompareTo(y.DateOfBirth);
            }
        }
    }
}
