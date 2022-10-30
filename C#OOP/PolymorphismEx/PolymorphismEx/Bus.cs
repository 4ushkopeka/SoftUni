using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Bus : Driveable
    {
        public Bus(double fuel, double cons, double tank)
        {
            FuelQuantity = fuel;
            FuelConsumptionKm = cons;
            TankCap = tank;
        }
        public override void Drive(double distance)
        {
            if (FuelQuantity - (distance * (FuelConsumptionKm+1.4)) >= 0) { FuelQuantity -= distance * (FuelConsumptionKm+1.4); Console.WriteLine($"Bus travelled {distance} km"); }
            else Console.WriteLine("Bus needs refueling");
        }
        public void DriveEmpty(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumptionKm) >= 0) { FuelQuantity -= distance * FuelConsumptionKm; Console.WriteLine($"Bus travelled {distance} km"); }
            else Console.WriteLine("Bus needs refueling");
        }
        public override void Refuel(double distance)
        {
            base.Refuel(distance);
        }
    }
}
