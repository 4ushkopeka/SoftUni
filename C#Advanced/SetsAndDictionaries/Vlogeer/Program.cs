using System;
using System.Collections.Generic;
using System.Linq;

namespace Vlogeer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Dictionary<string, SortedSet<string>> vloggers = new Dictionary<string, SortedSet<string>>();
            while (command!="Statistics")
            {
                command = Console.ReadLine();
                var debuggedComand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (debuggedComand.Length == 4)
                {
                    if (!vloggers.ContainsKey(debuggedComand[0])) vloggers[debuggedComand[0]] = new SortedSet<string>();
                    else continue;
                }
                else
                {
                    if (!vloggers.ContainsKey(debuggedComand[0]) || !vloggers.ContainsKey(debuggedComand[2])) continue;
                    else if (debuggedComand[0] == debuggedComand[2]) continue;
                    else vloggers[debuggedComand[2]].Add(debuggedComand[0]);
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            Dictionary<string, int[]> followed = new Dictionary<string, int[]>();
            foreach (var item in vloggers)
            {
                int num = 0;
                foreach (var v in vloggers)
                {
                    if (v.Value.Contains(item.Key)) num++;
                }
                followed[item.Key] = new int[2];
                followed[item.Key][0] = num;//He follows
                followed[item.Key][1] = vloggers[item.Key].Count;//He is followed
            }
            Dictionary<string, int[]> toPrint= followed.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Value[0]).ToDictionary(x => x.Key, x => x.Value);
            followed = followed.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Value[0]).Take(1).ToDictionary(x=>x.Key, x => x.Value);
            string name = "";
            foreach (var item in followed)
            {
                Console.WriteLine($"1. {item.Key} : {item.Value[1]} followers, {item.Value[0]} following");
                name = item.Key;
                List<string> print= vloggers[item.Key].ToList();
                for (int i = 0; i < vloggers[item.Key].Count; i++)
                {
                    Console.WriteLine($"*  {print[i]}");
                }
            }
            int k = 2;
            foreach (var item in toPrint)
            {
                if (item.Key == name) continue;
                else
                {
                    Console.WriteLine($"{k}. {item.Key} : {item.Value[1]} followers, {item.Value[0]} following");
                    k++;
                }
            }
        }
    }
}
