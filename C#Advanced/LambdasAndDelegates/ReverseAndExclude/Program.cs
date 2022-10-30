using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lim = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int chosen = int.Parse(Console.ReadLine());
            lim.Reverse();
            Func<int, bool> filter = x => x%chosen != 0;    
            lim = lim.Where(filter).ToList();
            lim.ForEach(x => Console.Write(x + " "));
        }
    }
}
