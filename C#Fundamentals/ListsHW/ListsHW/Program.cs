using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsHW
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int max = int.Parse(Console.ReadLine());
            string [] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                if (command.Length == 2)
                {
                    int addition = int.Parse(command[1]);
                    input.Add(addition);
                }
                else
                {
                    int addition = int.Parse(command[0]);
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] + addition <= max)
                        {
                            input[i] += addition;
                            break;
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
