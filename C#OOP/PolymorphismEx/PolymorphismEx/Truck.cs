using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Truck : Driveable
    {
        public Truck(double fuel, double cons, double tank)
        {
            FuelQuantity = fuel;
            FuelConsumptionKm = cons + 1.6;
            TankCap = tank;
        }
        public override void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumptionKm) >= 0) {FuelQuantity -= distance * FuelConsumptionKm; Console.WriteLine($"Truck travelled {distance} km"); }
            else Console.WriteLine("Truck needs refueling");
        }
        public override void Refuel(double fuel)
        {
            if (fuel > TankCap) Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            else if (fuel < 1) Console.WriteLine("Fuel must be a positive number");
            else FuelQuantity += fuel*0.95;
        }
    }
}
