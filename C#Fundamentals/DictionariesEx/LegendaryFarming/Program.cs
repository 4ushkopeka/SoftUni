using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            Dictionary<string, int> calc = new Dictionary<string, int>();
            calc.Add("shards", 0);
            calc.Add("fragments", 0);
            calc.Add("motes", 0);
            bool endy = true;
            while (true)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    int temp;
                    if (i%2 == 0)
                    {
                        continue;
                    }
                    else
                    {
                        input[i] = input[i].ToLower();
                        if (!calc.ContainsKey(input[i]))
                        {
                            temp = int.Parse(input[i-1]);
                            calc[input[i]] = temp;
                        }
                        else
                        {
                            temp = int.Parse(input[i - 1]);
                            calc[input[i]] += temp;
                            if (End(calc))
                            {
                                endy = false;
                                break;
                            }
                        }
                    }
                }
                if (!endy) break;
                input = Console.ReadLine().Split().ToList();
            }
            Dictionary<string, int> calc1 = calc.Take(3).OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in calc1)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            calc.Remove("motes");
            calc.Remove("fragments");
            calc.Remove("shards");
            calc = calc.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in calc)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        static bool End(Dictionary<string, int> calc)
        {
            if (calc["shards"] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                calc["shards"] -= 250;
                return true;
            }
            else if (calc["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                calc["fragments"] -= 250;
                return true;
            }
            else if (calc["motes"] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                calc["motes"] -= 250;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
