
using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();
            while (command!= "Party!")
            {
                var removeDouble = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                var comm = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
                var parameter = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2];
                if (removeDouble == "Remove")
                {
                    List<string> removed = names.Where(Checker(comm, parameter)).ToList();
                    foreach (var item in removed) names.Remove(item);
                }
                else
                {
                    List<string> added = names.Where(Checker(comm, parameter)).ToList();
                    foreach (var item in added) 
                    {
                        int index = names.FindIndex(0, names.Count, x => x == item);
                        names.Insert(index, item);
                    }
                }
                command = Console.ReadLine();
            }
            if (names.Count != 0) Console.WriteLine($"{String.Join(", ", names)} are going to the party!");
            else Console.WriteLine("Nobody is going to the party!");
        }
        static Func<string, bool> Checker(string command, string parameter)
        {
            switch (command)
            {
                case "StartsWith": return x => x.StartsWith(parameter);
                case "EndsWith": return x => x.EndsWith(parameter);
                case "Length": return x => x.Length == int.Parse(parameter);
                default:
                    return null;
            }
        }
    }
}
