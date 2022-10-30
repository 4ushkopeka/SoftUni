using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] legs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();
            int[] huge = new int[legs[0] + legs[1]];

            for (int i = 0; i < legs[0]; i++)
            {
                int add = int.Parse(Console.ReadLine());
                set1.Add(add);
                huge[i] = add;
            }
            for (int i = 0; i < legs[1]; i++)
            {
                int add = int.Parse(Console.ReadLine());
                set2.Add(add);
                huge[i + legs[0]] = add;
            }
            for (int i = 0; i < huge.Length; i++)
            {
                if (set1.Contains(huge[i]) && !set2.Contains(huge[i]))set1.Remove(huge[i]);
            }
            foreach (var item in set1)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
