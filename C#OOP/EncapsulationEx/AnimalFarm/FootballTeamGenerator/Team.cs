using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> players = new Dictionary<string, Player>();
        public Team(string name)
        {
            Name = name;
        }
        public double Rating => CalcRating();
        public string Name
        {
            get { return name; }
            private set 
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value)) name = value;
                else throw new ArgumentException("A name should not be empty.");
            }
        }
        public void AddPlayer(Player pl)
        {
            players.Add(pl.Name, pl);
        }
        public void RemovePlayer(Player pl)
        {
            players.Remove(pl.Name);
        }
        private double CalcRating()
        {
            double sum = 0;
            if (players.Count == 0) return 0;
            else { foreach (var item in players) sum += item.Value.Stats; return sum / players.Count; }
        }
    }
}
