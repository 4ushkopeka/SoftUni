using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfFunc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 1; i <= end; i++) list.Add(i);
            List<int> ividers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<int, bool> fuu = x => 
            {
                for (int i = 0; i < ividers.Count; i++)
                {
                    if (x % ividers[i] != 0) return false;
                } 
                return true;
            };
            list = list.Where(fuu).ToList();
            Console.WriteLine(String.Join(" ", list));
        }

    }
}
