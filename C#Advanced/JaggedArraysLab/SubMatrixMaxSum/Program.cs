using System;
using System.Linq;

namespace SubMatrixMaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];
            int subRows = 3;
            int subCols = 3;
            for (int rows = 0; rows < size[0]; rows++)
            {
                int[] k = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int cols = 0; cols < size[1]; cols++) matrix[rows, cols] = k[cols];
            }
            int sum = int.MinValue;
            int r = 0;
            int c = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - subRows +1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - subCols + 1; cols++)
                {
                    int k = 0;
                    for (int i = 0; i < subRows; i++)
                    {
                        for (int j = 0; j < subCols; j++) k += matrix[rows + i, cols + j];
                        if (k > sum)
                        {
                            sum = k;
                            r = rows;
                            c = cols;
                        }
                    }
                }
            }
            Console.WriteLine($"Sum = {sum}");
            for (int row = 0; row < subRows; row++)
            {
                for (int col = 0; col < subCols; col++)
                {
                    Console.Write(matrix[r + row, c + col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
