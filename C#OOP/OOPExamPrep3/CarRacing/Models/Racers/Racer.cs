using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehaviour;
        private int drivingExp;
        private ICar car;
        public Racer(string username, string racingBehaviour, int drivingExp, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehaviour;
            DrivingExperience = drivingExp;
            Car = car;
        }
        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                username = value;
            }
        }

        public string RacingBehavior
        {
            get => racingBehaviour;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                racingBehaviour = value;
            }
        }

        public int DrivingExperience
        {
            get => drivingExp;
            private set
            {
                if (value<0 || value > 100) throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                drivingExp = value;
            }
        }

        public ICar Car
        {
            get => car;
            private set
            {
                if (value == null) throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                car = value;
            }
        }

        public bool IsAvailable()
        {
            if (this.Car.FuelAvailable >= this.Car.FuelConsumptionPerRace) return true;
            else return false;
        }

        public void Race()
        {
            this.Car.Drive();
            if (this is StreetRacer) this.drivingExp += 5;
            else this.drivingExp += 10;
        }
    }
}
