using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> adons = Console.ReadLine().Split(" -> ").ToList();
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            while (adons[0] != "End")
            {
                if (!companies.ContainsKey(adons[0]))
                {
                    companies[adons[0]] = new List<string>();
                    companies[adons[0]].Add(adons[1]);
                }
                else
                {
                    if (companies[adons[0]].Contains(adons[1]))
                    {
                        continue;
                    }
                    else
                    {
                        companies[adons[0]].Add(adons[1]);
                    }
                }
                adons = Console.ReadLine().Split(" -> ").ToList();
            }
            companies = companies.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in companies)
            {
                Console.WriteLine($"{item.Key}\n-- {string.Join("\n-- ", companies[item.Key])}");
            }
        }
    }
}
