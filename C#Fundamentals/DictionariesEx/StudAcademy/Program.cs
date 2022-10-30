using System;
using System.Linq;
using System.Collections.Generic;

namespace StudAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studs = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!studs.ContainsKey(name))
                {
                    studs[name] = new List<double>();
                    studs[name].Add(grade);
                }
                else
                {
                    studs[name].Add(grade);
                }
            }
            foreach (var item in studs)
            {
                double det = studs[item.Key].Average();
                if (det < 4.50) studs.Remove(item.Key);
            }
            studs = studs.OrderByDescending(pair => pair.Value.Average()).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in studs)
            {
                Console.WriteLine($"{item.Key} -> {studs[item.Key].Average():f2}");
            }
        }
    }
}
