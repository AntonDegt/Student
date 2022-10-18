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

    class Student : Person, IComparable
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

        private int[] homeworks;
        public int[] Homeworks
        {
            get
            {
                return homeworks;
            }
        }
        private int[] termPapers;
        public int[] TermPapers
        {
            get
            {
                return termPapers;
            }
        }
        private int[] exams;
        public int[] Exams
        {
            get
            {
                return exams;
            }
        }

        public Student(string Name, string Surname, DateTime DateOfBirth, string Address, string PhoneNumber, int SubjectCount)
            : base(Name, Surname, DateOfBirth, Address, PhoneNumber)
        {
            homeworks = new int[SubjectCount];
            termPapers = new int[SubjectCount];
            exams = new int[SubjectCount];
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
            homeworks = new int[st.homeworks.Length]; for (int i = 0; i < st.homeworks.Length; i++) homeworks[i] = st.homeworks[i];
            termPapers = new int[st.termPapers.Length]; for (int i = 0; i < st.termPapers.Length; i++) termPapers[i] = st.termPapers[i];
            exams = new int[st.exams.Length]; for (int i = 0; i < st.exams.Length; i++) exams[i] = st.exams[i];
        }

        public float AverageHomework ()
        {
            float sum = 0;
            foreach (int item in homeworks)
                sum += (float)item;
            sum /= SubjectCount;
            return sum;
        }
        public void PrintEx()
        {
            Console.Write("Offset: ");
            for(int i = 0; i < homeworks.Length; i++)
                Console.Write(homeworks[i]);

            Console.Write("TermPapers: ");
            for (int i = 0; i < termPapers.Length; i++)
                Console.Write(termPapers[i]);

            Console.Write("Exams: ");
            for (int i = 0; i < exams.Length; i++)
                Console.Write(exams[i]);
        }
        public void SetHomeworksMark(int mark, int subjectNumber)
        {
            if (mark < 0 || mark > 5) throw new MarkOutOfRange(mark, "offset");
            homeworks[subjectNumber] = mark;
        }
        public void SetHomeworksMark(int[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
                SetHomeworksMark(marks[i], i);
        }
        public void SetTermPaperMark(int mark, int subjectNumber)
        {
            if (mark < 0 || mark > 5) throw new MarkOutOfRange(mark, "term paper");
            termPapers[subjectNumber] = mark;
        }
        public void SetTermPaperMark(int[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
                SetTermPaperMark(marks[i], i);
        }
        public void SetExamMark(int mark, int subjectNumber)
        {
            if (mark < 0 || mark > 5) throw new MarkOutOfRange(mark, "exam");
            exams[subjectNumber] = mark;
        }
        public void SetExamMark(int[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
                SetExamMark(marks[i], i);
        }
        public void RandomExamMarks(Random random)
        {
            for(int i = 0; i < exams.Length; i++)
                exams[i] = random.Next(2, 6);
        }
        public int[] GetExams()
        {
            return exams;
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
        public new object Clone()
        {
            Student clone = new Student(Name, Surname, DateOfBirth, Address, PhoneNumber, SubjectCount);

            SetExamMark(exams);
            SetHomeworksMark(homeworks);
            SetTermPaperMark(termPapers);

            return clone;
        }
        public int CompareTo(object obj)
        {
            Student st = (Student)obj;
            float av = this.AverageHomework();
            float av2 = st.AverageHomework();

            if (av > av2) return 1;
            else if (av < av2) return -1;
            else return 0;
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
