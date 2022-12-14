using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleСSApp
{
    
    class Group : ICloneable, IComparable, IEnumerable
    {
        private Student[] students;
        public Student[] Students
        {
            get { return students; }
        }
        public int Count { get { return students.Length; } }

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

            students = null;
        }
        public Group(int Count)
            : this("Group", "Spez.", 1)
        {
            students = new Student[Count];
            for (int i = 0; i < Count; i++)
                students[i] = new Student("Name" + (i + 1), "Surname" + (i + 1), new DateTime(2000, 01, 01));
        }
        public Group()
            : this(8) { }
        public Group(Student[] students)
            : this("Group", "Spez.", 1)
        {
            this.students = new Student[students.Length];
            for (int i = 0; i < students.Length; i++)
                this.students[i] = students[i];
        }
        public Group(Group group)
            : this("Group", "Spez.", 1)
        {
            this.students = new Student[group.Count];
            for (int i = 0; i < group.Count; i++)
                this.students[i] = group.students[i];
        }

        public override string ToString()
        {
            string st = Name + " " + Specialization + " " + CourseNumber;

            int i = 1;
            foreach (Student student in students)
            {
                st += i + ") " + student + '\n';
                i++;
            }
            st += '\n';
            return st;
        }
        public void Add(Student student)
        {
            Student[] t = students;
            students = new Student[t.Length + 1];
            for (int i = 0; i < t.Length; i++)
                students[i] = t[i];
            students[t.Length] = student;
        }
        public Student GetByNumber(int number)
        {
            return students[number-1];
        }
        public Student PopByNumber(int number)
        {
            Student student = new Student(students[number-1]);
            return student;
        }
        public void ExpulsionFailedSession()
        {
            Student[] st = new Student[Count];
            int count = 0;

            for (int i = 0; i < Count; i++)
                foreach (int mark in students[i].Exams)
                    if (mark > 3)
                    {
                        st[i] = students[i];
                        count++;
                    }
            students = new Student[count];
            int j = 0;
            for (int i = 0; i < st.Length; i++)
                if (st[i] != null)
                {
                    students[j] = st[i];
                    j++;
                }
        }
        public void ExpulsionLast()
        {
            Student lastStudent = students[0];
            int lastMarks = 0;
            foreach (int mark in lastStudent.Exams)
                lastMarks += mark;

            foreach (Student student in students)
            {
                int marks = 0;
                foreach (int mark in student.Exams)
                    marks += mark;

                if (marks <= lastMarks)
                {
                    lastStudent = student;
                    lastMarks = marks;
                }
            }

            Student[] t = students;
            students = new Student[t.Length - 2];

            int j = 0;
            for (int i = 0; i < t.Length; i++)
                if (t[i] != lastStudent)
                {
                    students[j] = t[i];
                    j++;
                }
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
        public object Clone()
        {
            return new Group(this);
        }
        public int CompareTo(object obj)
        {
            Group gr = (Group)obj;

            if (this.Count > gr.Count) return 1;
            else if (this.Count < gr.Count) return -1;
            else return 0;
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
            if (index < 0 || index > Count) return false;
            return true;
        }
        public Student this[int index]
        {
            set
            {
                if (IndexInRange(index)) students[index] = value;
                else throw new IndexOutOfRangeException();
            }
            get
            {
                if (IndexInRange(index)) return students[index];
                else throw new IndexOutOfRangeException();
            }
        }
        public class CountCompare : IComparer<Group>
        {
            public int Compare(Group x, Group y)
            {
                return x.CompareTo(y);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GroupEnumerator(students);
        }
    }
}
