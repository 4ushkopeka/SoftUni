using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<int, bool> min = x => x == list.Min();
            list = list.Where(min).ToList();
            Console.WriteLine(list[0]);
            
        }
    }
}
