using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            string [] commands = Console.ReadLine().Split();
            while (commands[0] != "end")
            {
                if (commands[0] == "Delete")
                {
                    int pos = int.Parse(commands[1]);
                    input.Remove(pos);
                }
                else
                {
                    int item = int.Parse(commands[1]);
                    int pos = int.Parse(commands[2]);
                    input.Insert(pos, item);
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
