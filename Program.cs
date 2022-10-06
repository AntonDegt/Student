using ConsoleСSApp;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group = new Group(10);

            Student s = group.GetByNumber(1);
            s.SetExamMark(new int[] { 4, 3, 4, 5, 5 });
            s.Print(true);

            try
            {
                s.SetExamMark(new int[] { -1, 3, 4, 5, 5 });
                s.Print(true);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}
