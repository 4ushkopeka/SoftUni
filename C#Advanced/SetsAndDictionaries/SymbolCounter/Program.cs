using System;
using System.Collections.Generic;

namespace SymbolCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();  
            SortedDictionary<char, int> dictionary = new SortedDictionary<char,int>();
            char[] chars = input.ToCharArray();
            foreach (char c in chars)
            {
                if (!dictionary.ContainsKey(c))
                {
                    dictionary[c] = 1;
                }
                else
                {
                    dictionary[c] += 1;
                }
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
