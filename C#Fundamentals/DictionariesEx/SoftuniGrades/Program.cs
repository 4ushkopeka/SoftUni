using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftuniGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> studs = new Dictionary<string, int>();
            Dictionary<string, int> counting = new Dictionary<string, int>();
            List<string> commands;
            do
            {
                commands = Console.ReadLine().Split("-").ToList();
                if (commands.Count == 2)
                {
                    string name1 = commands[0];
                    studs.Remove(name1);
                    continue;
                }
                else if (commands.Count == 1)
                {
                    break;
                }
                string name = commands[0];
                string lang = commands[1];
                int grades = int.Parse(commands[2]);
                if (!studs.ContainsKey(name))
                {
                    studs[name] = grades;
                    if (!counting.ContainsKey(lang)) counting[lang] = 1;
                    else counting[lang]++;
                }
                else
                {
                    if (!counting.ContainsKey(lang)) counting[lang] = 1;
                    else counting[lang]++;
                    if (grades > studs[name]) studs[name] = grades;
                    else continue;
                }
            }
            while (commands[0] != "exam finished");
            Console.WriteLine("Results:");
            studs = studs.OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in studs)
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            counting = counting.OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in counting)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
