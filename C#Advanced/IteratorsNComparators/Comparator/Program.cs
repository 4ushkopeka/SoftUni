using System;
using System.Collections.Generic;
using System.Linq;

namespace Comparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Comparator comp = new Comparator();
            nums.Sort(comp);
            Console.WriteLine(String.Join(" ", nums));
        }
    }
    internal class Comparator : IComparer<int>
    {

        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 == 0)
            {
                if (x > y) return 1;
                else if (x < y) return -1;
                else return 0;
            }
            else if (x % 2 != 0 && y % 2 != 0)
            {
                if (x > y) return 1;
                else if (x < y) return -1;
                else return 0;
            }
            else
            {
                if (x % 2 == 0) return -2;
                else return 2;
            }
        }
    }
}
