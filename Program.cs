using ConsoleСSApp;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group = new Group(10);
            Group gr2 = new Group(7);

            Console.WriteLine(group == gr2);
            Console.WriteLine(group.Count);

            Console.ReadKey();
        }
    }
}
