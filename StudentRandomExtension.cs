using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleСSApp
{
    static class StudentRandomExtension
    {

        public static void RandomExamMarks(this Student st, Random random)
        {
            for (int i = 0; i < st.Exams.Length; i++)
                st.SetExamMark(random.Next(2, 6), i);
        }
        public static void RandomHomeworkMarks(this Student st, Random random)
        {
            for (int i = 0; i < st.Homeworks.Length; i++)
                st.SetHomeworksMark(random.Next(2, 6), i);
        }
    }
}
