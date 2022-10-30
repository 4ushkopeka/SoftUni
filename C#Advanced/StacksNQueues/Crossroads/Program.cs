

using System;
using System.Collections.Generic;

namespace Crossroads
{
    internal class Program
    {
        static void Main()
        {
            int gree1 = int.Parse(Console.ReadLine());
            int reee = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<char[]> cars = new Queue<char[]>();
            int gree = gree1;
            int total = 0;
            while (command != "END")
            {
                if (command == "green")
                {
                    while (gree > 0)
                    {
                        if (cars.Count == 0) break;
                        if (gree - cars.Peek().Length >= 0)
                        {
                            total++;
                            gree -= cars.Dequeue().Length;
                        }
                        else if(gree > 0 && gree + reee - cars.Peek().Length>=0)
                        {
                            cars.Dequeue();
                            gree = 0;
                            total++;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{string.Join("", cars.Peek())} was hit at {cars.Peek()[gree + reee]}.");
                            return;
                        }
                    }
                    gree = gree1;
                }
                else cars.Enqueue(command.ToCharArray());
                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{total} total cars passed the crossroads.");
        }
    }
}
