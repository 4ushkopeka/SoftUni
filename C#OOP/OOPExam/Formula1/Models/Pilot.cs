using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        string fullName;
        IFormulaOneCar car;
        int wins = 0;
        public Pilot(string name)
        {
            FullName = name;
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5) throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => car;
            private set
            {
                if (value == null) throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCarForPilot));
                car = value;
            }
        }

        public int NumberOfWins => wins;
        [DefaultValue(false)]
        public bool CanRace { get; private set; }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            wins++;
        }
        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
