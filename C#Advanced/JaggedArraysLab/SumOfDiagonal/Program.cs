using System;
using System.Linq;

namespace SumOfDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int sum = 0;
            for (int rows = 0; rows < size; rows++)
            {
                int[] k = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int cols = 0; cols < size; cols++)
                {
                    matrix[rows, cols] = k[cols];
                    if (rows == cols) sum += matrix[rows, cols];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
