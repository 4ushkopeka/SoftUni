using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double leg = double.Parse(Console.ReadLine());
            List<string> list = Console.ReadLine().Split().ToList();
            Func<string, int> calc = x => 
            {
                int sum = 0;
                for (int i = 0; i < x.Length; i++) sum += x[i];
                return sum;
            };
            Func<string, Func<string, int>, bool> calc2 = (x, calc) => calc(x) >= leg;
            list = list.Where(x => calc2(x, calc)).Take(1).ToList();
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
