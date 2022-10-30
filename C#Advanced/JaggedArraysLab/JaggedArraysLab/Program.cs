

using System;
using System.Linq;

namespace JaggedArraysLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0],size[1]];
            int sum = 0;
            for (int rows = 0; rows < size[0]; rows++)
            {
                int[] k = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int cols = 0; cols < size[1]; cols++)
                {
                    matrix[rows,cols] = k[cols];
                    sum += matrix[rows, cols];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
