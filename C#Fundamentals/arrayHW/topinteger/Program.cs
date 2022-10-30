using System;
using System.Linq;

namespace topinteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] res = new int[arr.Length];
            int counter = 0;
            int placeholder = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int temp = i; temp < arr.Length-1;temp++)
                {
                    if (arr[i] > arr[temp + 1])
                    {
                        counter++;
                    }
                }
                if (counter == arr.Length - 1 - i)
                {
                    res[placeholder] = arr[i];
                    placeholder++;
                }
                counter = 0;
            }
            for (int i = 0; i < placeholder; i++)
            {
                Console.Write(res[i] + " ");
            }
        }
    }
}
