using System;

namespace PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stepen = int.Parse(Console.ReadLine());
            long[][] pascal = new long[stepen+2][];
            pascal[0] = new long[1] { 1};
            pascal[1] = new long[2] { 1, 1};
            for (int row = 2; row < stepen+1; row++)
            {
                pascal[row] = new long[row+1];
                for (int col = 0; col < row+1; col++)
                {
                    if (col == 0 || col == row) pascal[row][col] = 1;
                    else pascal[row][col] = pascal[row - 1][col] + pascal[row - 1][col - 1];
                }
            }
            for (int row = 0; row < stepen; row++)
            {
                for (int i = 0; i < row+1; i++)
                {
                    Console.Write($"{pascal[row][i]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
