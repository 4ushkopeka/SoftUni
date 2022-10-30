using System;
using System.Linq;

namespace ZawurtaneNaMasivi
{
    class Program
    {
        public static void Main()
        {
            int[] jeesus = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leg = jeesus.Length;
            int i = 0;
            int[] sums = new int[leg];
            int k = int.Parse(Console.ReadLine());
            while (k>0)
            {
                int temp = jeesus[leg - 1];
                for (i = leg-1; i > 0; i--)
                {
                    jeesus[i] = jeesus[i - 1];
                }
                jeesus[i] = temp;
                k--;
                for (int z = 0; z < leg; z++)
                {
                    sums[z] += jeesus[z];
                }
            }
            for (int j = 0; j < leg; j++)
            {
                Console.Write(sums[j] + " ");
            }
        }
    }
}
