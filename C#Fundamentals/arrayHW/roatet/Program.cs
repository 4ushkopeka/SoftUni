using System;
using System.Linq;

namespace roatet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotates = int.Parse(Console.ReadLine());
            while (rotates>0)
            {
                int temp = arr[arr.Length - 1];
                for (int i = arr.Length - 1; i > 0 ; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[0] = temp;
                rotates--;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
