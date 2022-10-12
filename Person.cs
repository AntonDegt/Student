using System;

namespace ConsoleСSApp
{
    class Person
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

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            set
            {
                if (value > new DateTime(1900, 1, 1) && value < (DateTime.Now.AddYears(-16))) dateOfBirth = value;
                else throw new Exception("Date of birth not correct.");
            }
            get
            {
                return dateOfBirth;
            }
        }

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

        public Person(string Name, string Surname, DateTime DateOfBirth, string Address, string PhoneNumber)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.DateOfBirth = DateOfBirth;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
        }
        public Person(string Name, string Surname, DateTime DateOfBirth, string Address)
            : this(Name, Surname, DateOfBirth, Address, "+380998877666") { }
        public Person(string Name, string Surname, DateTime DateOfBirth)
            : this(Name, Surname, DateOfBirth, "Ukraine") { }
        public Person()
            : this("PersonName", "PersonSurname", new DateTime(2000, 1, 1)) { }

        public override string ToString()
        {
            return (string)(Name + " " + Surname + " " + DateOfBirth.ToShortDateString() + " " + Address + " " + PhoneNumber);
        }
    }
}
