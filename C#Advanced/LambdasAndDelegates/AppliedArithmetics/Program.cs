
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lim = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string comms = Console.ReadLine(); ;
            while (comms != "end")
            {
                if (comms == "print") Console.WriteLine(string.Join(" ", lim));
                else lim = lim.Select(Arithmecy(comms)).ToList();
                comms = Console.ReadLine();
            }
        }
        static Func<int, int> Arithmecy(string type)
        {
            switch (type)
            {
                case "add": return x => x + 1;
                case "multiply": return x => x*2;
                case "subtract": return x => x - 1;
                default:
                    return null;
            }
        }
    }
}
