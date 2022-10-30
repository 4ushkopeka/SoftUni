using System;
using System.Collections.Generic;
using System.Linq;
namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            Dictionary<string, SortedSet<string>> forceSide = new Dictionary<string, SortedSet<string>>();
            while (input != "Lumpawaroo")
            {
                input = Console.ReadLine();
                if (input.Contains('|'))
                {
                    string [] command = input.Split(" | ").ToArray();
                    if (!forceSide.ContainsKey(command[0]))
                    {
                        forceSide[command[0]] = new SortedSet<string>();
                        if (!UserExists(forceSide, command[1])) forceSide[command[0]].Add(command[1]);
                    }
                    else
                    {
                        if (!UserExists(forceSide, command[1])) forceSide[command[0]].Add(command[1]);
                    }
                }
                else if (input.Contains("->"))
                {
                    string[] command = input.Split(" -> ").ToArray();
                    if (UserExists(forceSide, command[0]))
                    {
                        string side = UserInForceSide(forceSide, command[0]);
                        forceSide[side].Remove(command[0]);
                        if (!forceSide.ContainsKey(command[1]))
                        {
                            forceSide[command[1]] = new SortedSet<string>();
                            forceSide[command[1]].Add(command[0]);
                        }
                        else forceSide[command[1]].Add(command[0]);
                    }
                    else
                    {
                        if (!forceSide.ContainsKey(command[1]))
                        {
                            forceSide[command[1]] = new SortedSet<string>();
                            forceSide[command[1]].Add(command[0]);
                        }
                        else forceSide[command[1]].Add(command[0]);
                    }
                    Console.WriteLine($"{command[0]} joins the {command[1]} side!");
                }
            }
            forceSide = forceSide.OrderByDescending(pair => pair.Value.Count).ThenBy(pair => pair.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in forceSide)
            {
                if (forceSide[item.Key].Count != 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {forceSide[item.Key].Count}");
                    foreach (var person in forceSide[item.Key])
                    {
                        Console.WriteLine($"! {person}");
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        static bool UserExists(Dictionary<string, SortedSet<string>> side, string user)
        {
            foreach (var item in side)
            {
                if (item.Value.Contains(user)) return true;
            }
            return false;
        }
        static string UserInForceSide(Dictionary<string, SortedSet<string>> side, string user)
        {
            foreach (var item in side)
            {
                if (item.Value.Contains(user)) return item.Key;
            }
            return null;
        }
    }
}
