using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        List<ICar> cars = new List<ICar>();   
        public IReadOnlyCollection<ICar> Models => cars.AsReadOnly();
        public void Add(ICar model)
        {
            if (model == null) throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            cars.Add(model);
        }

        public ICar FindBy(string property)
        {
            ICar car = cars.FirstOrDefault(x => x.VIN == property);
            if (car == null || car == default) return null;
            else return car;
        }
        public bool Remove(ICar model)
        {
            return cars.Remove(model);
        }
    }
}
