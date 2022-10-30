using System;
using System.Linq;

namespace JaggedArraysEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int [,] matrix = DefineMatrix(n);
            int m = 0, s = 0;
            int remover = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        m += matrix[row, col];
                    }
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == matrix.GetLength(1)-1)
                    {
                       s += matrix[row, col - remover];
                    }
                }
                remover++;
            }
            Console.WriteLine($"{Math.Abs(m - s)}");
        }
        static int[,] DefineMatrix(int n)
        {
            int[,] matrix = new int[n,n];
            for (int row = 0; row < n; row++)
            {
                int[] masiv = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = masiv[col];
                }
            }
            return matrix;
        }
        static void PrintMatrix(int[,] printed)
        {
            for (int row = 0; row < printed.GetLength(0); row++)
            {
                for (int col = 0; col < printed.GetLength(1); col++)
                {
                    Console.Write($"{printed[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
