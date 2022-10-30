using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        CarRepository cars;
        RacerRepository racers;
        IMap map;
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            Car car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
                cars.Add(car);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
                cars.Add(car);
            }
            else throw new ArgumentException(ExceptionMessages.InvalidCarType);
            return $"Successfully added car {car.Make} {car.Model} ({car.VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            Racer car;
            ICar carr;
            if (type == "ProfessionalRacer")
            {
                carr = cars.Models.FirstOrDefault(x => x.VIN == carVIN);
                if (carr == null || carr == default) throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
                car = new ProfessionalRacer(username, carr);
                racers.Add(car);
            }
            else if (type == "StreetRacer")
            {
                carr = cars.Models.FirstOrDefault(x => x.VIN == carVIN);
                if(carr == null || carr == default) throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
                car = new StreetRacer(username, carr);
                racers.Add(car);
            }
            else throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.Models.FirstOrDefault(x => x.Username == racerOneUsername);
            IRacer racerTwo = racers.Models.FirstOrDefault(x => x.Username == racerTwoUsername);
            if (racerOne == null || racerOne == default) throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            if (racerTwo == null || racerTwo == default) throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var result = racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username).ToList();
            StringBuilder rezultat = new StringBuilder();
            foreach (var item in result) rezultat.AppendLine($"{item.GetType().Name}: {item.Username}\r\n--Driving behavior: {item.RacingBehavior}\r\n--Driving experience: {item.DrivingExperience}\r\n--Car: {item.Car.Make} {item.Car.Model} ({item.Car.VIN})");
            return rezultat.ToString().TrimEnd();
        }
    }
}
