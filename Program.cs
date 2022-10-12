using ConsoleСSApp;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Group g = new Group(0);
            Group g2 = new Group(7);

            Console.WriteLine(g == g2);
            Console.WriteLine(g.Count);

            g.Add(new Student("Ivan", "Ivanov", new DateTime(1999, 1, 1)));
            g.Add(new Student("Vasya", "Vasyilev", new DateTime(2000, 1, 1)));

            Console.WriteLine(g[1]);

            Person p = new Person("Anton", "Antonov", new DateTime(2004, 9, 11));
            Console.WriteLine(p);
            Aspirant a = new Aspirant("Anton", "Antonov", new DateTime(2004, 9, 11), "Ukrain", "+380667788999", "SoftWare Development");
            Console.WriteLine(a);

            Console.ReadKey();
        }
    }
}
