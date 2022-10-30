using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] buls = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(buls);
            int[] lok = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(lok);
            int intelecc = int.Parse(Console.ReadLine());
            int barrel = barrelSize;
            int bulPrice = 0;
            while (true)
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    bullets.Pop();
                    locks.Dequeue();
                    barrel--;
                    bulPrice += price;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    bulPrice += price;
                    barrel--;
                }
                if (barrel == 0 && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    barrel = barrelSize;
                }
                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelecc - bulPrice}");
                    return;
                }
                else if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }
            }
        }
    }
}
