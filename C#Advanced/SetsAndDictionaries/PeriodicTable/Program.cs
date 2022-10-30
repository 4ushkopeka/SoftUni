using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> s = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int g = 0; g < arr.Length; g++)
                {
                    s.Add(arr[g]);
                }
            }
            foreach (string t in s)
            {
                Console.Write($"{t} ");
            }    
        }
    }
}
