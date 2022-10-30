using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool first = false;
            while (true)
            {
                if (secondPlayer.Count == 0 || firstPlayer.Count == 0)
                {
                    if (firstPlayer.Count == 0)
                    {
                        first = true;
                        break;
                    }
                    break;
                }
                else
                {
                    if (firstPlayer[0] > secondPlayer[0])
                    {
                        int temp = firstPlayer[0];
                        int temp1 = secondPlayer[0];
                        firstPlayer.RemoveAt(0);
                        secondPlayer.RemoveAt(0);
                        firstPlayer.Add(temp1);
                        firstPlayer.Add(temp);
                    }
                    else if (firstPlayer[0] < secondPlayer[0])
                    {
                        int temp = firstPlayer[0];
                        int temp1 = secondPlayer[0];
                        firstPlayer.RemoveAt(0);
                        secondPlayer.RemoveAt(0);
                        secondPlayer.Add(temp);
                        secondPlayer.Add(temp1);
                    }
                    else
                    {
                        firstPlayer.RemoveAt(0);
                        secondPlayer.RemoveAt(0);
                    }
                }
            }
            int sum = 0;
            if (first)
            {
                for (int i = 0; i < secondPlayer.Count; i++)
                {
                    sum += secondPlayer[i];
                }
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
            else
            {
                for (int i = 0; i < firstPlayer.Count; i++)
                {
                    sum += firstPlayer[i];
                }
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
        }
    }
}
