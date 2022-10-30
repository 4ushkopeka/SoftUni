using System;
using System.Linq;

namespace equalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumLeft = 0;
            int sumRight = 0;
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                {
                    sumLeft = 0;
                }
                else
                {
                    for (int k = 0; k < i; k++)
                    {
                        sumLeft += arr[k];
                    }
                }
                for (int ji = i+1; ji < arr.Length; ji++)
                {
                    if (counter == arr.Length-1)
                    {
                        sumRight = 0;
                    }
                    else
                    {
                        for (int k = arr.Length-1; k >= ji ; k--)
                        {
                            sumRight += arr[k];
                        }
                        break;
                    }
                }
                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    return;
                }
                sumRight = 0;
                sumLeft = 0;
                counter++;
            }
            Console.WriteLine("no");
        }
    }
}
