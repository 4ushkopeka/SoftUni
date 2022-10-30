using System;
using System.Linq;

namespace SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = DefineMatrix(n);
            int num = 0;
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    string charche = matrix[row, col];
                    if (matrix[row,col+1] == charche && matrix[row+1, col + 1] == charche && matrix[row + 1, col] == charche)
                    {
                        num++;
                    }
                }
            }
            Console.WriteLine(num);
        }
        public static string[,] DefineMatrix(int[] n)
        {
            string[,] matrix = new string[n[0], n[1]];
            for (int row = 0; row < n[0]; row++)
            {
                string[] masiv = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < n[1]; col++)
                {
                    matrix[row, col] = masiv[col];
                }
            }
            return matrix;
        }
    }
}
