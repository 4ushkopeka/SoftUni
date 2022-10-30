using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Car : Driveable
    {
        public Car(double fuel, double cons, double tank)
        {
            FuelQuantity = fuel;
            FuelConsumptionKm = cons+ 0.9;
            TankCap = tank;
        }
        public override void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumptionKm) >= 0) { FuelQuantity -= distance * FuelConsumptionKm; Console.WriteLine($"Car travelled {distance} km"); }
            else Console.WriteLine("Car needs refueling");
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
        }
    }
}
