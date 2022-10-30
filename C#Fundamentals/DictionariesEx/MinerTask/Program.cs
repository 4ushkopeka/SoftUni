using System;
using System.Collections.Generic;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = 1;
            Dictionary<string, int> counter = new Dictionary<string, int>();
            string temp = "";
            while (input!="stop")
            {
                if (count%2 == 0)
                {
                    counter[temp] += int.Parse(input);
                }
                else
                {
                    if (!counter.ContainsKey(input))
                    {
                        counter[input] = 0;
                    }
                }
                temp = input;
                input = Console.ReadLine();
                count++;
            }
            foreach (var item in counter)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
