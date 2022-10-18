using ConsoleСSApp;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] st = new Student[] {
                new Student("Aaa", "Gggg", new DateTime(2001, 1, 19)),
                new Student("Bbbb", "Xxxx", new DateTime(2000, 2, 15)),
                new Student("Cccc", "Hhhh", new DateTime(2000, 2, 3))};

            Random r = new Random();
            for (int i = 0; i < 3; i++)
                st[i].RandomHomeworkMarks(r);

            Array.Sort(st, new Student.NameComparer());
            for (int i = 0; i < 3; i++)
                Console.WriteLine(st[i]);
            Console.WriteLine();

            Array.Sort(st, new Student.SurnameComparer());
            for (int i = 0; i < 3; i++)
                Console.WriteLine(st[i]);
            Console.WriteLine();

            Array.Sort(st, new Student.DateOfBirthCompare());
            for (int i = 0; i < 3; i++)
                Console.WriteLine(st[i]);
            Console.WriteLine();

            // Aaa Gggg 19.01.2001 Ukraine + 380998877666
            // Bbbb Xxxx 15.02.2000 Ukraine + 380998877666
            // Cccc Hhhh 03.02.2000 Ukraine + 380998877666

            // Aaa Gggg 19.01.2001 Ukraine + 380998877666
            // Cccc Hhhh 03.02.2000 Ukraine + 380998877666
            // Bbbb Xxxx 15.02.2000 Ukraine + 380998877666

            // Cccc Hhhh 03.02.2000 Ukraine + 380998877666
            // Bbbb Xxxx 15.02.2000 Ukraine + 380998877666
            // Aaa Gggg 19.01.2001 Ukraine + 380998877666




            Group gr = new Group(st);
            foreach (var item in gr)
                Console.WriteLine(item);

            // Cccc Hhhh 03.02.2000 Ukraine + 380998877666
            // Bbbb Xxxx 15.02.2000 Ukraine + 380998877666
            // Aaa Gggg 19.01.2001 Ukraine + 380998877666


            Console.ReadKey();
        }
    }
}
