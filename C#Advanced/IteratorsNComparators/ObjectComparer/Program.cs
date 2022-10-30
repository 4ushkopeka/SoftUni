using System;
using System.Collections.Generic;

namespace ObjectComparer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            HashSet<Person> set = new HashSet<Person>();
            SortedSet<Person> srtset = new SortedSet<Person>();
            for (int i = 0; i < num; i++)
            {
                string command = Console.ReadLine();
                Person pers = new Person(command.Split()[0], int.Parse(command.Split()[1]));
                set.Add(pers);
                srtset.Add(pers);
            }
            Console.WriteLine(srtset.Count);
            Console.WriteLine(set.Count);
        }
    }
}
