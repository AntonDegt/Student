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

    class Student : Person
    {

        private int subjectCount;
        public int SubjectCount
        {
            set
            {
                if (value >= 0) subjectCount = value;
            }
            get
            {
                return subjectCount;
            }
        }


        private int[] Homeworks;
        private int[] TermPapers;
        private int[] Exams;

        public Student(string Name, string Surname, DateTime DateOfBirth, string Address, string PhoneNumber, int SubjectCount)
            : base(Name, Surname, DateOfBirth, Address, PhoneNumber)
        {
            Homeworks = new int[SubjectCount];
            TermPapers = new int[SubjectCount];
            Exams = new int[SubjectCount];
        }
        public Student(string Name, string Surname, DateTime DateOfBirth, string Address, string PhoneNumber)
            : this(Name, Surname, DateOfBirth, Address, PhoneNumber, 5) { }
        public Student(string Name, string Surname, DateTime DateOfBirth, string Address)
            : this(Name, Surname, DateOfBirth, Address, "+380998877666") { }
        public Student(string Name, string Surname, DateTime DateOfBirth)
            : this(Name, Surname, DateOfBirth, "Ukraine") { }
        public Student(Student st)
            : base(st.Name, st.Surname, st.DateOfBirth, st.Address, st.PhoneNumber)
        {
            SubjectCount = st.SubjectCount;
            Homeworks = new int[st.Homeworks.Length]; for (int i = 0; i < st.Homeworks.Length; i++) Homeworks[i] = st.Homeworks[i];
            TermPapers = new int[st.TermPapers.Length]; for (int i = 0; i < st.TermPapers.Length; i++) TermPapers[i] = st.TermPapers[i];
            Exams = new int[st.Exams.Length]; for (int i = 0; i < st.Exams.Length; i++) Exams[i] = st.Exams[i];
        }

        public float AverageHomework ()
        {
            float sum = 0;
            foreach (int item in Homeworks)
                sum += (float)item;
            sum /= SubjectCount;
            return sum;
        }
        public void PrintEx()
        {
            Console.Write("Offset: ");
            for(int i = 0; i < Homeworks.Length; i++)
                Console.Write(Homeworks[i]);

            Console.Write("TermPapers: ");
            for (int i = 0; i < TermPapers.Length; i++)
                Console.Write(TermPapers[i]);

            Console.Write("Exams: ");
            for (int i = 0; i < Exams.Length; i++)
                Console.Write(Exams[i]);
        }
        public void SetOffsetMark(int mark, int subjectNumber)
        {
            if (mark < 0 || mark > 5) throw new MarkOutOfRange(mark, "offset");
            Homeworks[subjectNumber] = mark;
        }
        public void SetOffsetMark(int[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
                SetOffsetMark(marks[i], i);
        }
        public void SetTermPaperMark(int mark, int subjectNumber)
        {
            if (mark < 0 || mark > 5) throw new MarkOutOfRange(mark, "term paper");
            TermPapers[subjectNumber] = mark;
        }
        public void SetTermPaperMark(int[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
                SetTermPaperMark(marks[i], i);
        }
        public void SetExamMark(int mark, int subjectNumber)
        {
            if (mark < 0 || mark > 5) throw new MarkOutOfRange(mark, "exam");
            Exams[subjectNumber] = mark;
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

        public override string ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            Student s = obj as Student;
            if (s == null)
                return false;
            return s.AverageHomework() == this.AverageHomework();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator> (Student s1, Student s2)
        {
            if (s1 != null && s2 != null) return s1.AverageHomework() > s2.AverageHomework();
            else if (s1 != null && s2 == null) return true;
            else return false;
        }
        public static bool operator< (Student s2, Student s1)
        {
            if (s2 != null && s1 != null) return s2.AverageHomework() > s1.AverageHomework();
            else if (s2 != null && s1 == null) return true;
            else return false;
        }
        public static bool operator ==(Student s1, Student s2)
        {
            if (ReferenceEquals(s1, s2)) return true;

            if ((object)s1 == null && (object)s2 != null) return false;
            if ((object)s2 == null && (object)s1 != null) return false;

            return s1.AverageHomework() == s2.AverageHomework();
        }
        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
    }
}
