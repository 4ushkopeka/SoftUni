using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> studentAdd = Console.ReadLine().Split(" : ").ToList();
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            while (studentAdd[0] != "end")
            {
                if (!courses.ContainsKey(studentAdd[0]))
                {
                    courses[studentAdd[0]] = new List<string>();
                    courses[studentAdd[0]].Add(studentAdd[1]);
                }
                else
                {
                    courses[studentAdd[0]].Add(studentAdd[1]);
                    courses[studentAdd[0]] = courses[studentAdd[0]].OrderBy(pair => pair).ToList();
                }
                studentAdd = Console.ReadLine().Split(" : ").ToList();
            }
            courses = courses.OrderByDescending(pair => pair.Value.Count).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {courses[item.Key].Count}\n-- {string.Join("\n-- ", courses[item.Key])}");
            }
        }
    }
}
