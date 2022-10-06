using System;
using System.Collections.Generic;

namespace ConsoleСSApp
{
    class MarkOutOfRange : ApplicationException
    {
        public MarkOutOfRange(int mark, string markType)
            : base("Mark " + markType + " - " + mark.ToString() + " out of range")
        { }
    }

    class Student
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public int subjectCount = 5;
        private int[] Offsets;
        private int[] TermPapers;
        private int[] Exams;

        public Student(string Name, string Surname, DateTime DateOfBirth, string Address, string PhoneNumber)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.DateOfBirth = DateOfBirth;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;

            Offsets = new int[subjectCount];
            TermPapers = new int[subjectCount];
            Exams = new int[subjectCount];
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
            subjectCount = st.subjectCount;
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
        public void SetOffsetMark(int mark, int subjectNumber)
        {
            if (0 < mark || mark > 5) throw new MarkOutOfRange(mark, "offset");
            Offsets[subjectCount] = mark;
        }
        public void SetOffsetMark(int[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
                SetOffsetMark(marks[i], i);
        }
        public void SetTermPaperMark(int mark, int subjectNumber)
        {
            if (0 < mark || mark > 5) throw new MarkOutOfRange(mark, "term paper");
            TermPapers[subjectCount] = mark;
        }
        public void SetTermPaperMark(int[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
                SetTermPaperMark(marks[i], i);
        }
        public void SetExamMark(int mark, int subjectNumber)
        {
            if (0 < mark || mark > 5) throw new MarkOutOfRange(mark, "exam");
            Exams[subjectCount] = mark;
        }
        public void SetExamMark(int[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
                SetExamMark(marks[i], i);
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
