using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksNQueues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] stackNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(stackNums);
            for (int i = 0; i < nums[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(nums[2]))
            {
                Console.WriteLine("true");
            }
            else if(stack.Count == 0)
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
