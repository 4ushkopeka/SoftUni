using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        public SuperCar(string make, string model, string VIN, int horsepower) : base(make, model, VIN, horsepower, 80, 10)
        {
        }
    }
}
