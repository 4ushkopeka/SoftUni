using System;
using System.Collections.Generic;
using System.Linq;

namespace bombers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int [] bomberNPower = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int temp = bomberNPower[1];
            bool correction;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == bomberNPower[0])
                {
                    while (bomberNPower[1] != 0)
                    {
                        correction = true;
                        try
                        {
                            nums.RemoveAt(i - bomberNPower[1]);
                            i--;
                            correction = false;
                            nums.RemoveAt(i + bomberNPower[1]);
                            bomberNPower[1]--;
                        }
                        catch (Exception)
                        {
                            if (correction)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    nums.RemoveAt(j);
                                    i--;
                                }
                                try
                                {
                                    while (bomberNPower[1] != 0)
                                    {
                                        nums.RemoveAt(i + bomberNPower[1]);
                                        bomberNPower[1]--;
                                    }
                                }
                                catch (Exception)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                bomberNPower[1]--;
                            }
                            continue;
                        }
                    }
                    bomberNPower[1] = temp;
                }
            }
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == bomberNPower[0])
                {
                    nums.RemoveAt(i);
                    i--;
                    continue;
                }
                sum += nums[i];
            }
            Console.WriteLine(sum);
        }
    }
}
