using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();
            Dictionary<string, Func<string, bool>> filters = new Dictionary<string, Func<string, bool>>();  
            while (command != "Print")
            {
                var removeDouble = command.Split(";", StringSplitOptions.RemoveEmptyEntries)[0];
                var comm = command.Split(";", StringSplitOptions.RemoveEmptyEntries)[1];
                var parameter = command.Split(";", StringSplitOptions.RemoveEmptyEntries)[2];
                if (removeDouble == "Remove filter") filters.Remove(comm + parameter);
                else
                {
                    Func<string, bool> addDouble = Checker(comm, parameter);
                    filters.Add(comm+parameter, addDouble);
                }
                command = Console.ReadLine();
            }
            foreach (var item in filters) names = names.Where(filters[item.Key]).ToList();
            Console.WriteLine(String.Join(" ", names));
        }
        static Func<string, bool> Checker(string command, string parameter)
        {
            switch (command)
            {
                case "Starts with": return x => !x.StartsWith(parameter);
                case "Ends with": return x => !x.EndsWith(parameter);
                case "Length": return x => x.Length != int.Parse(parameter);
                case "Contains": return x => !x.Contains(parameter);
                default:
                    return null;
            }
        }

    }
}
