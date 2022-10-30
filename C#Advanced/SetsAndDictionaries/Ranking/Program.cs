using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Dictionary<string, string> contestInfo = new Dictionary<string, string>();   
            Dictionary<string, Dictionary<string, double>> userInfo = new Dictionary<string, Dictionary<string, double>>();
            while (command != "end of submissions")
            {
                command = Console.ReadLine();
                if (command.Contains(':'))
                {
                    string contest = command.Split(":")[0];
                    string password = command.Split(":", StringSplitOptions.RemoveEmptyEntries)[1];//controversial
                    if (!contestInfo.ContainsKey(contest)) contestInfo[contest] = password;
                }
                else if (command.Contains("=>"))
                {
                    string contest = command.Split("=>", StringSplitOptions.RemoveEmptyEntries)[0];
                    string password = command.Split("=>", StringSplitOptions.RemoveEmptyEntries)[1];
                    string username = command.Split("=>", StringSplitOptions.RemoveEmptyEntries)[2];
                    double points = double.Parse(command.Split("=>", StringSplitOptions.RemoveEmptyEntries)[3]);
                    if (!contestInfo.ContainsKey(contest)) continue;
                    else
                    {
                        if (contestInfo[contest] != password) continue;
                        else
                        {
                            if (!userInfo.ContainsKey(username))
                            {
                                userInfo[username] = new Dictionary<string, double>();
                                userInfo[username][contest] = points;
                            }
                            else
                            {
                                if (!userInfo[username].ContainsKey(contest)) userInfo[username][contest] = points;
                                else
                                {
                                    if (userInfo[username][contest] < points) userInfo[username][contest] = points;
                                }
                            }
                        }
                    }
                }
                else continue;
            }
            Dictionary<string, Dictionary<string, double>> best = userInfo.OrderByDescending(x => x.Value.Values.Sum()).Take(1).ToDictionary(x => x.Key, x => x.Value);
            userInfo = userInfo.OrderBy(x => x.Key).ThenByDescending(x => x.Value.Values.Sum()).ToDictionary(x=> x.Key, x => x.Value);
            foreach (var item in best)
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value.Values.Sum()} points.");
            }
            Console.WriteLine("Ranking: ");
            foreach (var item in userInfo)
            {
                Console.WriteLine(item.Key);
                Dictionary<string, double> result = userInfo[item.Key].OrderByDescending(k => k.Value).ToDictionary(k => k.Key, k => k.Value);
                foreach (var stud in result)
                {
                    Console.WriteLine($"#  {stud.Key} -> {stud.Value}");
                }
            }
        }
    }
}
