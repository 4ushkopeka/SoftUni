using System;
using System.Collections.Generic;

namespace houseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int inputLines = int.Parse(Console.ReadLine());
            string[] commands;
            while (inputLines != 0)
            {
                commands = Console.ReadLine().Split();
                if (commands.Length == 3)
                {
                    if (list.Contains(commands[0]))
                    {
                        Console.WriteLine($"{commands[0]} is already in the list!");
                    }
                    else
                    {
                        list.Add(commands[0]);
                    }
                }
                else
                {
                    if (list.Contains(commands[0]))
                    {
                        list.Remove(commands[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{commands[0]} is not in the list!");
                    }
                }
                inputLines--;
            }
            Console.WriteLine(string.Join("\n", list));
        }
    }
}
