using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];
            for (int rows = 0; rows < size[0]; rows++)
            {
                int[] k = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int cols = 0; cols < size[1]; cols++)
                {
                    matrix[rows, cols] = k[cols];
                }
            }
            List<int> list = new List<int>();
            for (int cols = 0; cols < size[1]; cols++)
            {
                int sum = 0;
                for (int rows = 0; rows < size[0]; rows++)
                {
                    sum += matrix[rows, cols];
                }
                list.Add(sum);
            }
            foreach (int row in list)
            {
                Console.WriteLine(row);
            }
        }
    }
}
