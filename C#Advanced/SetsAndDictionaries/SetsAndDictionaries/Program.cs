using System;
using System.Collections.Generic;

namespace SetsAndDictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> s = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                s.Add(Console.ReadLine());
            }
            foreach (string t in s)
            {
                Console.WriteLine(t);
            }
        }
    }
}
