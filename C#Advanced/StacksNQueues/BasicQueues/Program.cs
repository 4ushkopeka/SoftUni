using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] stackNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> stack = new Queue<int>(stackNums);
            for (int i = 0; i < nums[1]; i++)
            {
                stack.Dequeue();
            }
            if (stack.Contains(nums[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
