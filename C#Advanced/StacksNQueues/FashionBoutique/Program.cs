

using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> poruchka = new Stack<int>(clothes);
            int cap = int.Parse(Console.ReadLine());
            int racks = 0;
            while (true)
            {
                int sum = 0;
                while (sum<cap)
                {
                    if (poruchka.Count == 0) break;
                    else if (poruchka.Peek() + sum > cap) break;
                    else sum+=poruchka.Pop();
                }
                if (sum != 0)
                {
                    racks++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
