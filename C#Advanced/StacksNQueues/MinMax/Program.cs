using System;
using System.Collections.Generic;

namespace MinMax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue, max = int.MinValue;
            int numOfComms = int.Parse(Console.ReadLine());
            Stack<int> stek = new Stack<int>();
            int[] stekIterate;
            while(numOfComms!=0)
            {
                string comms = Console.ReadLine();
                var command = comms.Split();
                if (command[0] == "1")
                {
                    stek.Push(int.Parse(command[1]));
                }
                else if (command[0] == "2")
                {
                    if (stek.Count != 0)stek.Pop();
                }
                else if (command[0] == "3")
                {
                    stekIterate = stek.ToArray();
                    if (stek.Count != 0)
                    {
                        for (int j = 0; j < stekIterate.Length; j++)
                        {
                            if (stekIterate[j] > max) max = stekIterate[j];
                        }
                        Console.WriteLine(max);
                    }
                }
                else if (command[0] == "4")
                {
                    stekIterate = stek.ToArray();
                    if (stek.Count != 0)
                    {
                        for (int j = 0; j < stekIterate.Length; j++)
                        {
                            if (stekIterate[j] < min) min = stekIterate[j];
                        }
                        Console.WriteLine(min);
                    }
                }
                numOfComms--;
            }
            int[] final = stek.ToArray();
            Console.WriteLine(string.Join(", ", final));
        }
    }
}
