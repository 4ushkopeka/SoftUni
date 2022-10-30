using System;
using System.Linq;

namespace CubeSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];
            for (int rows = 0; rows < size[0]; rows++)
            {
                int[] k = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int cols = 0; cols < size[1]; cols++)
                {
                    matrix[rows, cols] = k[cols];
                }
            }
            int sum = int.MinValue;
            int r = 0;
            int c = 0; 
            for (int rows = 0; rows < matrix.GetLength(0)-1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) -1; cols++)
                {
                    int n = matrix[rows, cols] + matrix[rows, cols+1] + matrix[rows + 1, cols] + matrix[rows + 1,cols + 1];
                    if (n > sum)
                    {
                        sum = n;
                        r = rows;
                        c = cols;
                    } 
                }
            }
            Console.WriteLine($"{matrix[r, c]} {matrix[r, c + 1]}");
            Console.WriteLine($"{matrix[r+1, c]} {matrix[r+1, c + 1]}");
            Console.WriteLine(sum);
        }
    }
}
