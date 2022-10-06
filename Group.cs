using System;
using System.Collections.Generic;

namespace ConsoleСSApp
{
    class Group
    {
        private List<Student> Students;
        public int Count { get { return Students.Count; } }
        public string Name { set; get; }
        public string Specialization { set; get; }
        public int CourseNumber { set; get; }

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
    }
}
