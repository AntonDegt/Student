using System;
using System.Collections.Generic;

namespace ConsoleСSApp
{
    class Group
    {
        private List<Student> Students;
        public int Count { get { return Students.Count; } }

        private string name;
        public string Name 
        { 
            set
            {
                if (value.Length > 2) name = value;
                else throw new Exception("Name isn't correct.");
            }
            get
            {
                return name;
            }
        }

        private string specialization;
        public string Specialization 
        { 
            set
            {
                if (value.Length > 2) specialization = value;
                else throw new Exception("Specialization isn't correct");
            }
            get
            {
                return specialization;
            }
        }

        private int courseNumber;
        public int CourseNumber 
        { 
            set
            {
                if (value > 0 && value <= 4) courseNumber = value;
                else throw new Exception("Course number out of range.");
            }
            get
            {
                return courseNumber;
            }
        }

        public Group(string Name, string Specialization, int CourseNumber)
        {
            this.Name = Name;
            this.Specialization = Specialization;
            this.CourseNumber = CourseNumber;

            Students = new List<Student>();
        }
        public Group(int Count)
            : this("Group", "Spez.", 1)
        {
            Students = new List<Student>();
            for (int i = 0; i < Count; i++)
                Students.Add(new Student("Name" + (i + 1), "Surname" + (i + 1), new DateTime(2000, 01, 01)));
        }
        public Group()
            : this(8) { }
        public Group(Student[] students)
            : this("Group", "Spez.", 1)
        {
            this.Students = new List<Student>();
            foreach (Student student in students)
                this.Students.Add(student);
        }
        public Group(Group group)
            : this("Group", "Spez.", 1)
        {
            this.Students = new List<Student>(group.Students);
        }

        public void Print(bool exams = false)
        {
            Console.WriteLine(Name + " " + Specialization + " " + CourseNumber);
            int i = 1;
            foreach (Student student in Students)
            {
                Console.Write(i + ") ");
                student.Print(exams);
                i++;
            }
            Console.WriteLine();
        }
        public void RandomExamMarks()
        {
            Random random = new Random();
            foreach (Student student in Students)
                student.RandomExamMarks(random);
        }
        public void Add(Student student)
        {
            Students.Add(student);
        }
        public Student GetByNumber(int number)
        {
            return Students[number-1];
        }
        public Student PopByNumber(int number)
        {
            Student student = new Student(Students[number-1]);
            return student;
        }
        public void ExpulsionFailedSession()
        {
            Student[] st = new Student[Students.Count];

            for (int i = 0; i < Students.Count; i++)
                foreach (int mark in Students[i].GetExams())
                    if (mark < 3)
                        st[i] = (Students[i]);
            foreach (Student student in st)
                if (student != null)
                    Students.Remove(student);
        }
        public void ExpulsionLast()
        {
            Student lastStudent = Students[0];
            int lastMarks = 0;
            foreach (int mark in lastStudent.GetExams())
                lastMarks += mark;

            foreach (Student student in Students)
            {
                int marks = 0;
                foreach (int mark in student.GetExams())
                    marks += mark;

                if (marks <= lastMarks)
                {
                    lastStudent = student;
                    lastMarks = marks;
                }
            }

            Students.Remove(lastStudent);
        }
        public override bool Equals(object obj)
        {
            Group g = obj as Group;
            if (g == null)
                return false;
            return g.Count == this.Count;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator== (Group g1, Group g2)
        {
            if (ReferenceEquals(g1, g2)) return true;

            if ((object)g1 == null && (object)g2 != null) return false;
            if ((object)g2 == null && (object)g1 != null) return false;

            return g1.Count == g2.Count;
        }
        public static bool operator!= (Group g1, Group g2)
        {
            return !(g1 == g2);
        }
        private bool IndexInRange(int index)
        {
            if (index < 0 || index > Count) return true;
            return false;
        }
        public Student this[int index]
        {
            set
            {
                if (IndexInRange(index)) Students[index] = value;
                else throw new IndexOutOfRangeException();
            }
            get
            {
                if (IndexInRange(index)) return Students[index];
                else throw new IndexOutOfRangeException();
            }
        }
    }
}
