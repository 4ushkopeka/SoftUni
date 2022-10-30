using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual void Drive(double kilometers)
        {
            if (Fuel >= kilometers*FuelConsumption)
            {
                Fuel -= kilometers * FuelConsumption;
            }
        }
        public Vehicle(int horsepower, double fuel)
        {
            Fuel = fuel;
            HorsePower = horsepower;
        }
    }
}
