using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        AstronautRepository astroRep;
        PlanetRepository planetRep;
        IMission mission;
        int exploresPlanets;
        public Controller()
        {
            astroRep = new AstronautRepository();
            planetRep = new PlanetRepository();
            mission = new Mission();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astr;
            if (type == "Biologist") astr = new Biologist(astronautName);
            else if (type == "Geodesist") astr = new Geodesist(astronautName);
            else if (type == "Meteorologist") astr = new Meteorologist(astronautName);
            else throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            astroRep.Add(astr);
            return string.Format(OutputMessages.AstronautAdded, astr.GetType().Name, astr.Name);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet plan = new Planet(planetName);
            foreach (var item in items) plan.Items.Add(item);
            planetRep.Add(plan);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astrosOnMission = astroRep.Models.Where(x => x.Oxygen>60).ToList();
            if (astrosOnMission.Count == 0) throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            IPlanet pl = planetRep.FindByName(planetName);
            mission.Explore(pl, astrosOnMission);
            exploresPlanets++;
            int dead = astrosOnMission.Count(x => !x.CanBreath);
            return string.Format(OutputMessages.PlanetExplored, pl.Name, dead);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploresPlanets} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var item in astroRep.Models)
            {
                string items = (item.Bag.Items.Count == 0) ? "none" : string.Join(", ", item.Bag.Items);
                sb.AppendLine($"Name: {item.Name}\r\nOxygen: {item.Oxygen}\r\nBag items: {items}");
            }
            return sb.ToString().TrimEnd();   
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astroRep.FindByName(astronautName);
            if (astronaut == null) throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            astroRep.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
