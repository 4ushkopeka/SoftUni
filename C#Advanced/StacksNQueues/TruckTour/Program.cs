
using System;
using System.Collections.Generic;

namespace TruckTour
{
    internal class Program
    {
        static void Main()
        {
            int numOfStations = int.Parse(Console.ReadLine());
            Queue<int> gas = new Queue<int>();  
            Queue<int> kilometers = new Queue<int>();
            for (int i = 0; i < numOfStations; i++)
            {
                string comms = Console.ReadLine();
                gas.Enqueue(int.Parse(comms.Split()[0]));
                kilometers.Enqueue(int.Parse(comms.Split()[1]));
            }
            int spins = 0;
            int [] defGas = gas.ToArray();
            int[] defKil = kilometers.ToArray();
            int g = numOfStations;
            while (true)
            {
                int gass = gas.Peek();
                int kilos = kilometers.Peek();
                while (true)
                {
                    if (gass - kilos >= 0)
                    {
                        gas.Dequeue();
                        kilometers.Dequeue();
                        numOfStations--;
                        if (numOfStations == 0)
                        {
                            Console.WriteLine(spins);
                            return;
                        }
                        gass += gas.Peek() - kilos;
                        kilos = kilometers.Peek();
                    }
                    else
                    {
                        numOfStations = g;
                        spins++;
                        break;
                    }
                }
                if (gas.Count == 0) break;
                gas = new Queue<int>(defGas);
                int rep = gas.Dequeue();
                gas.Enqueue(rep);
                defGas = gas.ToArray();
                kilometers = new Queue<int>(defKil);
                int rep1 = kilometers.Dequeue();
                kilometers.Enqueue(rep1);
                defKil = kilometers.ToArray();
            }
        }
    }
}
