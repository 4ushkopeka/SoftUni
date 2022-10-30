using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var item in astronauts)
            {
                while (item.CanBreath && planet.Items.Any())
                {
                    string itemm = planet.Items.FirstOrDefault();
                    item.Bag.Items.Add(itemm);
                    item.Breath();
                    planet.Items.Remove(itemm);
                }
                if (!planet.Items.Any()) break;
            }
        }
    }
}
