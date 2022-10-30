using System;
using System.Collections.Generic;

namespace Racers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> koli = new Dictionary<string, Car>();
            string comm;
            for (int i = 0; i < n; i++)
            {
                comm = Console.ReadLine();
                Car car = new Car(double.Parse(comm.Split()[1]), double.Parse(comm.Split()[2]));
                koli.Add(comm.Split()[0], car);
            }
            comm = Console.ReadLine();
            while (comm != "End")
            {
                string model = comm.Split()[1];
                double km = double.Parse(comm.Split()[2]);
                Car.CalcPossibleMove(koli[model], km);
                comm = Console.ReadLine();
            }
            foreach (var item in koli) Console.WriteLine($"{item.Key} {item.Value.FuelAmount:f2} {item.Value.TravelledDistance}");
        }
    }
}
