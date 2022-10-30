using System;

namespace PolymorphismEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string carr = Console.ReadLine();
            
            string truckk = Console.ReadLine();
            string buss = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            Driveable car = new Car(double.Parse(carr.Split()[1]), double.Parse(carr.Split()[2]), double.Parse(carr.Split()[3]));
            Driveable truck = new Truck(double.Parse(truckk.Split()[1]), double.Parse(truckk.Split()[2]), double.Parse(truckk.Split()[2]));
            Bus bus = new Bus(double.Parse(buss.Split()[1]), double.Parse(buss.Split()[2]), double.Parse(buss.Split()[2]));
            if (double.Parse(carr.Split()[1]) > double.Parse(carr.Split()[3])) car = new Car(0, double.Parse(carr.Split()[2]), double.Parse(carr.Split()[3]));
            else if (double.Parse(truckk.Split()[1]) > double.Parse(truckk.Split()[3])) truck = new Truck(0, double.Parse(carr.Split()[2]), double.Parse(carr.Split()[3]));
            else if (double.Parse(buss.Split()[1]) > double.Parse(buss.Split()[3])) bus = new Bus(0, double.Parse(carr.Split()[2]), double.Parse(carr.Split()[3]));
            for (int i = 0; i < num; i++)
            {
                string command = Console.ReadLine();
                if (command.Split()[0] == "Drive")
                {
                    if (command.Split()[1] == "Car") car.Drive(double.Parse(command.Split()[2]));
                    else if (command.Split()[1] == "Truck") truck.Drive(double.Parse(command.Split()[2]));
                    else bus.Drive(double.Parse(command.Split()[2]));
                }
                else if (command.Split()[0] == "Refuel")
                {
                    if (command.Split()[1] == "Car") car.Refuel(double.Parse(command.Split()[2]));
                    else if (command.Split()[1] == "Truck") truck.Refuel(double.Parse(command.Split()[2]));
                    else bus.Refuel(double.Parse(command.Split()[2]));
                }
                else bus.DriveEmpty(double.Parse(command.Split()[2]));
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
