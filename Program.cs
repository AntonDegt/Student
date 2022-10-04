using ConsoleСSApp;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Aaa", "Bbb", new DateTime(2004, 09, 11), "Uk");
            student.Print();

            Console.ReadKey();
        }
    }
}
