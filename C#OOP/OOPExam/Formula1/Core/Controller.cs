using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        FormulaOneCarRepository carRep;
        PilotRepository pilotRep;
        RaceRepository raceRep;
        public Controller()
        {
            carRep = new FormulaOneCarRepository();
            pilotRep = new PilotRepository();
            raceRep = new RaceRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRep.FindByName(pilotName);
            IFormulaOneCar car = carRep.FindByName(carModel);   
            if (pilot == null || pilot.Car != null) throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            if (car == null) throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            pilot.AddCar(car);
            carRep.Remove(car);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRep.FindByName(raceName);
            IPilot pilot = pilotRep.FindByName(pilotFullName);
            if (race == null) throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            bool exists = false;
            foreach (var item in race.Pilots)
            {
                if (item == pilot) { exists = true; break; }
            }
            if (pilot == null || !pilot.CanRace || exists) throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            race.AddPilot(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement) // possible crash
        {
            IFormulaOneCar car = carRep.FindByName(model);
            if (car == null)
            {
                if (type == nameof(Williams))
                {
                    car = new Williams(model, horsepower, engineDisplacement);
                    carRep.Add(car);
                }
                else if (type == nameof(Ferrari))
                {
                    car = new Ferrari(model, horsepower, engineDisplacement);
                    carRep.Add(car);
                }
                else throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            else throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = pilotRep.FindByName(fullName);
            if (pilot == null)
            {
                pilotRep.Add(new Pilot(fullName));
                return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
            }
            else throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));   
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = raceRep.FindByName(raceName);
            if (race == null) raceRep.Add(new Race(raceName, numberOfLaps));
            else throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            List<IPilot> pilotList = pilotRep.Models.OrderByDescending(x => x.NumberOfWins).ToList();
            foreach (var item in pilotList) sb.AppendLine(item.ToString());
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder build = new StringBuilder();
            foreach (var item in raceRep.Models)
            {
                if (item.TookPlace) build.AppendLine(item.RaceInfo());
            }
            return build.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRep.FindByName(raceName);
            if (race == null) throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            if (race.Pilots.Count < 3) throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            if (race.TookPlace) throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            List<IPilot> racers = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();
            racers[0].WinRace();
            race.TookPlace = true;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {racers[0].FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {racers[1].FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {racers[2].FullName} is third in the {raceName} race.");
            return sb.ToString().TrimEnd();
        }
    }
}
