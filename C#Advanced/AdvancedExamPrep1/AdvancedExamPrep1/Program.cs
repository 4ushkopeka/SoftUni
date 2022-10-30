using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedExamPrep1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            Stack<int> orcs = new Stack<int>();
            int[] pls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> plates = new Queue<int>(pls);
            int completeWaves = 0;
            while (waves != 0)
            {
                int[] orc = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (plates.Count != 0)
                {
                    completeWaves++;
                    orcs = new Stack<int>(orc);
                    if (completeWaves % 3 == 0) plates.Enqueue(int.Parse(Console.ReadLine()));
                    while (orcs.Count > 0 && plates.Count > 0)
                    {
                        if (orcs.Peek() < plates.Peek())
                        {
                            int[] plated = plates.ToArray();
                            plated[0] -= orcs.Pop();
                            plates = new Queue<int>(plated);
                        }
                        else if (orcs.Peek() > plates.Peek())
                        {
                            int[] rcd = orcs.Reverse().ToArray();
                            rcd[rcd.Length-1] -= plates.Dequeue();
                            orcs = new Stack<int>(rcd);
                        }
                        else
                        {
                            orcs.Pop();
                            plates.Dequeue();
                        }
                    }
                }
                waves--;
            }
            if (plates.Count == 0)
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
