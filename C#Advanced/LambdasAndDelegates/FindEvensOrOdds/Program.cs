using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lim = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> list = new List<int>();
            for (int i = 0; i <= lim[1] - lim[0]; i++) list.Add(i + lim[0]);
            string command = Console.ReadLine();
            list = list.Where(OddOrEven(command)).ToList();
            Console.WriteLine(string.Join(" ", list)); 
        }
        static Func<int, bool> OddOrEven(string typr)
        {
            switch (typr)
            {
                case "odd": return x=> x%2 != 0;
                case "even": return x => x%2 == 0;
                default:
                    return null ;
            }
        }
    }
}
