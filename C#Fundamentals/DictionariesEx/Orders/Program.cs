using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> basket = new Dictionary<string, List<double>>();
            List<string> input = Console.ReadLine().Split().ToList();
            while (input[0] != "buy")
            {
                if (!basket.ContainsKey(input[0]))
                {
                    basket[input[0]] = new List<double>();
                    basket[input[0]].Add(double.Parse(input[1]));
                    basket[input[0]].Add(double.Parse(input[2]));
                }
                else
                {
                    basket[input[0]][0] = double.Parse(input[1]);
                    basket[input[0]][1] += double.Parse(input[2]);
                }
                input = Console.ReadLine().Split().ToList();
            }
            foreach (var item in basket)
            {
                Console.WriteLine($"{item.Key} -> {basket[item.Key][0]* basket[item.Key][1]:f2}");
            }
        }
    }
}
