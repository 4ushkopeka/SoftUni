
using System;
using System.Linq;

namespace Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string command = Console.ReadLine();
            Tuple<string, string, string> tup = new Tuple<string, string, string>(string.Join(" ", command.Split(" ").Take(2)), command.Split()[2], string.Join(" ", command.Split(" ", 4).TakeLast(1)));
            Console.WriteLine($"{tup.Item1} -> {tup.Item2} -> {tup.Item3}");
            command = Console.ReadLine();
            tup = new Tuple<string, string, string>(command.Split(" ")[0], command.Split()[1], command.Split()[2]);
            if (tup.Item3 == "drunk") Console.WriteLine($"{tup.Item1} -> {tup.Item2} -> True");
            else Console.WriteLine($"{tup.Item1} -> {tup.Item2} -> False");
            command = Console.ReadLine();
            Tuple<string, double, string> tup1 = new Tuple<string, double, string>(command.Split(" ")[0], double.Parse(command.Split()[1]), command.Split()[2]);
            Console.WriteLine($"{tup1.Item1} -> {tup1.Item2} -> {tup1.Item3}");
        }
    }
}
