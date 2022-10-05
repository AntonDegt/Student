using ConsoleСSApp;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group = new Group(10);

            group.RandomExamMarks();
            group.Print(true);
            group.ExpulsionLast();
            group.Print(true);
            group.ExpulsionFailedSession();
            group.Print(true);

            Console.ReadKey();
        }
    }
}
