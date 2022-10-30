using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        string name;
        int laps;
        public Race(string name, int laps)
        {
            RaceName = name;
            NumberOfLaps = laps;
            Pilots = new List<IPilot>();
        }
        public string RaceName
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5) throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                name = value;
            }
        }

        public int NumberOfLaps
        {
            get => laps;
            private set
            {
                if (value<1) throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                laps = value;
            }
        }

        public bool TookPlace { get; set; } = false;

        public ICollection<IPilot> Pilots { get; }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The {RaceName} race has:");
            result.AppendLine($"Participants: {Pilots.Count}");
            result.AppendLine($"Number of laps: {NumberOfLaps}");
            string happened = (TookPlace) ? "Yes" : "No";
            result.AppendLine($"Took place: {happened}");
            return result.ToString().TrimEnd();
        }
    }
}
