using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string VIN, int horsepower) : base(make, model, VIN, horsepower, 65, 7.5)
        {
        }
    }
}
