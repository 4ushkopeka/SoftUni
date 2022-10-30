using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] d = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> dishes = new Queue<int>();
            int max = d.Max();
            for (int i = 0; i < d.Length; i++)
            {
                dishes.Enqueue(d[i]);
            }
            Console.WriteLine(max);
            while (true)
            {
                if (dishes.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    break;
                }
                if (foodQuantity - dishes.Peek() >= 0)
                {
                    foodQuantity -= dishes.Dequeue();
                }
                else
                {
                        int[] res = dishes.ToArray();
                        Console.Write("Orders left: ");
                        Console.WriteLine(string.Join(" ", res));
                        break;
                }
            }
        }
    }
}
