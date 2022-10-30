using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> peeps = new Dictionary<string, int>();
            foreach (var item in names)
            {
                if (!peeps.ContainsKey(item))
                {
                    peeps.Add(item, 0);
                }
            }
            Regex sum = new Regex(@"\d");
            Regex name = new Regex(@"[A-Za-z]");
            string input = Console.ReadLine();
            while (input != "end of race")
            {
                string key = "";
                int tot = 0;
                MatchCollection namess = name.Matches(input);
                MatchCollection sumss = sum.Matches(input);
                foreach (Match item in namess)
                {
                    key+=item.Value;
                }
                if (peeps.ContainsKey(key))
                {
                    foreach (Match item in sumss)
                    {
                        tot += int.Parse(item.Value);
                    }
                    peeps[key] += tot;
                }
                input = Console.ReadLine();
            }
            peeps = peeps.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            int i = 1;
            foreach (var item in peeps)
            {
                string num = "";
                if (i == 1) num = "st";
                else if (i == 2) num = "nd";
                else if (i == 3) num = "rd";
                else break;
                Console.WriteLine($"{i}{num} place: {item.Key}");
                i++;
            }
        }
    }
}
