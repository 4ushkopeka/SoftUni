using System;
using System.Linq;

namespace sglobqwaneNaMasiv
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] jeesus = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leg = jeesus.Length;
            int[] firstHalf = new int[leg/2];
            int[] secondHalf = new int[leg/2];
            int[] sum = new int[leg/2];
            int k = 0;
            if (leg % 4 != 0)
            {
                Console.WriteLine("You have forfeited your life priviliges!");
                return;
            }
            else
            {
                k = leg / 4;
            }
            int row = 0;
            for (int i = k; i < leg-k; i++)
            {
                secondHalf[row] = jeesus[i];
                row++;
            }
            int d = k - 1 ;
            for (int i = 0; i < k; i++)
            {
                firstHalf[d] = jeesus[i];
                d--;
            }
            d = firstHalf.Length-1;
            for (int i = leg - k; i < leg; i++)
            {
                firstHalf[d] = jeesus[i];
                d--;
            }
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = firstHalf[i] + secondHalf[i];
                Console.Write(sum[i] + " ");
            }
        }
    }
}
