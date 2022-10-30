using System;
using System.Collections.Generic;
using System.Linq;

namespace BottlesNCups
{
    internal class Program
    {
        static void Main()
        {
            int[] c = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(b);
            Queue<int> cups = new Queue<int>(c);
            int wastedWater = 0;
            while (cups.Count != 0 && bottles.Count != 0)
            {
                if (cups.Peek() <= bottles.Peek())
                {
                    wastedWater += bottles.Pop() - cups.Dequeue();
                    if (cups.Count == 0) continue;
                    else if (bottles.Count == 0) continue;
                }
                else
                {
                    int destroyed = 0;
                    while (destroyed<cups.Peek())
                    {
                        destroyed+=bottles.Pop();
                        if (bottles.Count == 0) continue;
                    }
                    wastedWater += destroyed - cups.Dequeue();
                    if (cups.Count == 0) continue;
                }
            }
            if (bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
