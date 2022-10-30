using System;
using System.Linq;

namespace Preobrazuwane
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] sumed = new int[nums.Length-1];
            int c = nums.Length;
            if (c == 1)
            {
                Console.WriteLine(nums[0]);
                return;
            }
            for (int j = 0; j < c-1; j++)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    sumed[i] = nums[i] + nums[i + 1];
                }
                nums = sumed;
            }
            Console.WriteLine(sumed[0]);
        }
    }
}
