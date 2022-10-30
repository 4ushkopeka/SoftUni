using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        string model;
        int horsePower;
        double engineDisplacement;
        public FormulaOneCar(string model, int horses, double engineDis)
        {
            Model = model;
            Horsepower = horses;
            EngineDisplacement = engineDis;
        }
        public string Model
        { 
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3) throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                model = value;
            }
        }

        public int Horsepower
        {
            get => horsePower;
            private set
            {
                if (value<900 || value > 1050) throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                horsePower = value;
            }
        }

        public double EngineDisplacement
        {
            get => engineDisplacement;
            private set
            {
                if (value < 1.6 || value > 2.00) throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return EngineDisplacement / Horsepower * laps;
        }
    }
}
