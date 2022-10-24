using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleСSApp
{
    static class GroupRandomExtension
    {
        public static void RandomExamMarks(this Group gr)
        {
            Random random = new Random();
            for (int i = 0; i < gr.Students.Length; i++)
                gr.GetByNumber(i).RandomExamMarks(random);
        }
        public static void RandomHomeworkMarks(this Group gr)
        {
            Random random = new Random();
            for (int i = 0; i < gr.Students.Length; i++)
                gr.GetByNumber(i).RandomHomeworkMarks(random);
        }
    }
}
