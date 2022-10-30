using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedExamPrep2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hat = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] scarf = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> hats = new Stack<int>(hat);
            Queue<int> scarfs = new Queue<int>(scarf);
            List<int> sets = new List<int>();
            int maxSet = int.MinValue;
            while (hats.Count != 0 && scarfs.Count != 0)
            {
                if (hats.Peek() == scarfs.Peek())
                {
                    scarfs.Dequeue();
                    int[] hts = hats.ToArray();
                    hts[0]++;
                    hats = new Stack<int>(hts.Reverse());
                }
                else if (hats.Peek() > scarfs.Peek())
                {
                    if (hats.Peek() + scarfs.Peek() > maxSet) maxSet = scarfs.Peek() + hats.Peek();
                    sets.Add(scarfs.Peek() + hats.Peek());
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else
                {
                    hats.Pop();
                    continue;
                }
            }
            Console.WriteLine($"The most expensive set is: {maxSet}");
            Console.WriteLine(String.Join(" ", sets));
        }
    }
}
