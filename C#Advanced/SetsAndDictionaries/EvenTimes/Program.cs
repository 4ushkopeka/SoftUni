using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] r = new int[n];
            for (int i = 0; i < n; i++)
            {
                r[i] = int.Parse(Console.ReadLine());
            }
            int num = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                for (int g = 0; g < n; g++)
                {
                    if (r[i] == r[g]) num++;
                }
                if (!map.ContainsKey(r[i]))
                {
                    map[r[i]] = num;
                }
                num = 0;
            }
            foreach (var item in map)
            {
                if (item.Value%2==0)
                {
                    Console.WriteLine($"{item.Key}");
                    return;
                }
            }
        }
    }
}
