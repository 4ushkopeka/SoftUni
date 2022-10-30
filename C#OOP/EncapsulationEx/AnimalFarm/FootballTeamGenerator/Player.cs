using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value < 1 || value > 100) throw new ArgumentException($"Shooting should be between 0 and 100.");
                else shooting = value;
            }
        }
        private int Passing
        {
            get { return passing; }
            set
            {
                if (value < 1 || value > 100) throw new ArgumentException($"Passing should be between 0 and 100.");
                else passing = value;
            }
        }
        private int Dribble
        {
            get { return dribble; }
            set
            {
                if (value < 1 || value > 100) throw new ArgumentException($"Dribble should be between 0 and 100.");
                else dribble = value;
            }
        }
        private int Sprint
        {
            get { return sprint; }
            set
            {
                if (value < 1 || value > 100) throw new ArgumentException($"Sprint should be between 0 and 100.");
                else sprint = value;
            }
        }
        private int Endurance
        {
            get { return endurance; }
             set 
            {
                if (value < 1 || value > 100) throw new ArgumentException($"Endurance should be between 0 and 100.");
                else endurance = value;
            }
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value)) name = value;
                else throw new ArgumentException("A name should not be empty.");
            }
        }
        public double Stats => (double)(Endurance + Sprint + Dribble + Passing + Shooting) / 5;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }
    }
}
