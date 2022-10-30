using System;
using System.Collections.Generic;
using System.Text;

namespace Racers
{
    public class Car
    {
        public Car(double fuel, double cons)
        {
            FuelAmount = fuel;
            FuelConsumptionPerKilometer = cons;
        }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }
        public static void CalcPossibleMove(Car cv, double raz)
        {
            if (cv.FuelAmount >= cv.FuelConsumptionPerKilometer*raz)
            {
                cv.FuelAmount -= cv.FuelConsumptionPerKilometer * raz;
                cv.TravelledDistance += raz;
            }
            else Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
