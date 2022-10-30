using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && racerTwo.IsAvailable()) return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable()) return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable()) return $"Race cannot be completed because both racers are not available!";
            else
            {
                racerOne.Race();
                racerTwo.Race();
                double behave = (racerOne.RacingBehavior == "strict") ? 1.2 : 1.1;
                double behave1 = (racerTwo.RacingBehavior == "strict") ? 1.2 : 1.1;
                double chance1 = racerOne.Car.HorsePower*racerOne.DrivingExperience*behave;
                double chance2 = racerTwo.Car.HorsePower*racerTwo.DrivingExperience*behave1;
                if (chance1 > chance2) return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
                else return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
            }
        }
    }
}
