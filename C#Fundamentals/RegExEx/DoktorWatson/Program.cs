using System;
using System.Text.RegularExpressions;

namespace DoktorWatson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string date  = Console.ReadLine();
            Regex regex = new Regex(@"^(?<day>[1-9]\d?)-(?<month>[A-Z][a-z]{2})-(?<year>[1-9]\d{3})");
            Match match = regex.Match(date);
            Console.WriteLine(match.Groups.Count);
            Console.WriteLine($"Matched text: {match.Groups["day"]}");
            
        }
    }
}
