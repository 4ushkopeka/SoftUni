using System;
using System.Linq;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            Dictionary<string, string> parking = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                List<string> commands = Console.ReadLine().Split().ToList();
                if (commands.Count == 3)
                {
                    if (!parking.ContainsKey(commands[1]))
                    {
                        Console.WriteLine($"{commands[1]} registered {commands[2]} successfully");
                        parking[commands[1]] = commands[2];
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parking[commands[1]]}");
                    }
                }
                else
                {
                    if (!parking.ContainsKey(commands[1]))
                    {
                        Console.WriteLine($"ERROR: user {commands[1]} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{commands[1]} unregistered successfully");
                        parking.Remove(commands[1]);
                    }
                }
            }
            foreach (var item in parking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
