using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleСSApp
{
    class Student
    {
        public string Name 
        { 
            get { return Name; }
            set { if (value.Length >= 2) Name = value; }
        }
        public string Surname
        {
            get { return Surname; }
            set { if (value.Length >= 2) Surname = value; }
        }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public List<int> Offsets;
        public List<int> TermPapers;
        public List<int> Exam;

        public Student(string Name, string Surname, DateTime DateOfBirth, string Address, string PhoneNumber)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.DateOfBirth = DateOfBirth;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
        }
        public Student(string Name, string Surname, DateTime DateOfBirth, string Address)
            : this(Name, Surname, DateOfBirth, Address, "") { }
        public Student(string Name, string Surname, DateTime DateOfBirth)
            : this(Name, Surname, DateOfBirth, "", "") { }

        public void Print()
        {
            Console.WriteLine(Name + " " + Surname + " " + DateOfBirth + " " + Address + " " + PhoneNumber);
        }
    }
}
