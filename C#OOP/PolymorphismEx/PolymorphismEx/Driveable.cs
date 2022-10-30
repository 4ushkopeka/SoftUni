using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public abstract class Driveable
    {
        public double TankCap { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumptionKm { get; set; }
        public abstract void Drive(double distance);
        public virtual void Refuel(double distance)
        {
            if (distance > TankCap) Console.WriteLine($"Cannot fit {distance} fuel in the tank");
            else if (distance < 1) Console.WriteLine("Fuel must be a positive number");
            else FuelQuantity += distance;
        }
    }
}
