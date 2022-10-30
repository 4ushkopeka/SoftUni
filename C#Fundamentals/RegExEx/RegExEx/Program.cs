using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegExEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pat = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";
            Dictionary<string, double> dict = new Dictionary<string, double>();
            while (input != "Purchase")
            {
                Match meth = Regex.Match(input, pat, RegexOptions.IgnoreCase);
                if (meth.Success)
                {
                    if (!dict.ContainsKey(meth.Groups["name"].Value))
                    {
                        dict[meth.Groups["name"].Value] = double.Parse(meth.Groups["price"].Value)*double.Parse(meth.Groups["quantity"].Value);
                    }
                    else
                    {
                        dict[meth.Groups["name"].Value] += double.Parse(meth.Groups["price"].Value) * double.Parse(meth.Groups["quantity"].Value);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            double sum = 0;
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key);
                sum += item.Value;
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
