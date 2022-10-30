using System;
using System.Collections.Generic;

namespace DictionariesEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> count = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    continue;
                }
                else if (!count.ContainsKey(input[i]))
                {
                    count[input[i]] = 0;
                }
                count[input[i]]++;
            }
            foreach (var item in count)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
