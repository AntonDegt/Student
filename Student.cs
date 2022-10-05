using System;
using System.Collections.Generic;

namespace ConsoleСSApp
{
    class Student
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        private int[] Offsets = new int[5];
        private int[] TermPapers = new int[5];
        private int[] Exams = new int[5];

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
        public Student(Student st)
        {
            Name = st.Name;
            Surname = st.Surname;
            DateOfBirth = st.DateOfBirth;
            Address = st.Address;
            PhoneNumber = st.PhoneNumber;
            Offsets = new int[st.Offsets.Length]; for (int i = 0; i < st.Offsets.Length; i++) Offsets[i] = st.Offsets[i];
            TermPapers = new int[st.TermPapers.Length]; for (int i = 0; i < st.TermPapers.Length; i++) TermPapers[i] = st.TermPapers[i];
            Exams = new int[st.Exams.Length]; for (int i = 0; i < st.Exams.Length; i++) Exams[i] = st.Exams[i];
        }

        public void Print(bool exams = false)
        {
            Console.Write(Name + " " + Surname + " " + DateOfBirth.ToShortDateString() + " " + Address + " " + PhoneNumber);
            if (exams)
                for (int i = 0; i < Exams.Length; i++)
                    Console.Write(Exams[i] + " ");
            Console.WriteLine();
        }
        public void PrintEx()
        {
            Console.Write("Offset: ");
            for(int i = 0; i < Offsets.Length; i++)
                Console.Write(Offsets[i]);

            Console.Write("TermPapers: ");
            for (int i = 0; i < TermPapers.Length; i++)
                Console.Write(TermPapers[i]);

            Console.Write("Exams: ");
            for (int i = 0; i < Exams.Length; i++)
                Console.Write(Exams[i]);
        }
        public void RandomExamMarks(Random random)
        {
            for(int i = 0; i < Exams.Length; i++)
                Exams[i] = random.Next(2, 6);
        }
        public int[] GetExams()
        {
            return Exams;
        }
    }
}
