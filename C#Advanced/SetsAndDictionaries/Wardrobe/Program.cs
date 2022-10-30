using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> dic = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string colour = input.Split(" -> ")[0];
                string cl = input.Split(" -> ")[1];
                string[] items = cl.Split(',');
                if (!dic.ContainsKey(colour))
                {
                    dic[colour] = new Dictionary<string, int>();
                    for (int g = 0; g < items.Length; g++)
                    {
                        if (!dic[colour].ContainsKey(items[g]))
                        {
                            dic[colour][items[g]] = 1;
                        }
                        else
                        {
                            dic[colour][items[g]]++;
                        }
                    }
                }
                else
                {
                    for (int g = 0; g < items.Length; g++)
                    {
                        if (!dic[colour].ContainsKey(items[g]))
                        {
                            dic[colour][items[g]] = 1;
                        }
                        else
                        {
                            dic[colour][items[g]]++;
                        }
                    }
                }
            }
            string search = Console.ReadLine();
            string color = search.Split()[0];
            string cloth = search.Split()[1];
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} clothes: ");
                foreach (var pcloth in item.Value)
                {
                    if (item.Key == color && pcloth.Key == cloth)
                    {
                        Console.WriteLine($"* {pcloth.Key} - {pcloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {pcloth.Key} - {pcloth.Value}");
                    }
                }
            }
        }
    }
}
