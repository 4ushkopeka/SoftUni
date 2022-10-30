using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();    
            Dictionary<string, Player> players = new Dictionary<string, Player>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                try
                {
                    var splitted = command.Split(";");
                    if (splitted[0].ToLower() == "team") teams[splitted[1]] = new Team(splitted[1]);
                    else if (splitted[0].ToLower() == "add")
                    {
                        if (!teams.ContainsKey(splitted[1])) Console.WriteLine($"Team {splitted[1]} does not exist.");
                        else
                        {
                            Player pl = new Player(splitted[2], int.Parse(splitted[3]), int.Parse(splitted[4]), int.Parse(splitted[5]), int.Parse(splitted[6]), int.Parse(splitted[7]));
                            teams[splitted[1]].AddPlayer(pl);
                            players.Add(pl.Name, pl);
                        }
                    }
                    else if (splitted[0].ToLower() == "rating")
                    {
                        if (!teams.ContainsKey(splitted[1])) Console.WriteLine($"Team {splitted[1]} does not exist.");
                        else Console.WriteLine($"{splitted[1]} - {Math.Round(teams[splitted[1]].Rating)}");
                    }
                    else
                    {
                        if (!players.ContainsKey(splitted[2])) Console.WriteLine($"Player {splitted[2]} is not in {splitted[1]} team.");
                        else teams[splitted[1]].RemovePlayer(players[splitted[2]]);
                    }
                    command = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    command = Console.ReadLine();
                }
            }
        }
    }
}
