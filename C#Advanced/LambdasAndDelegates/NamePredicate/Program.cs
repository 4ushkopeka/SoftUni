using System;
using System.Collections.Generic;
using System.Linq;

namespace NamePredicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int leg = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            names = names.Where(x => x.Length<=leg).ToList();
            names.ForEach(x => Console.WriteLine(x));
        }
    }
}
