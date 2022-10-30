using System;
using System.Linq;

namespace ArrayBombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = DefineMatrix(n);
            char [] charArray = new char[] { ',', ' '};
            int [] BombCoords = Console.ReadLine().Split(charArray).Select(int.Parse).ToArray();
            int [][] bombs = new int[BombCoords.Length/2][];
            int g = 0;
            for (int i = 0; i < BombCoords.Length-1; i+=2)//bombCoords get loaded in a jagged array
            {
                bombs[g] = new int[] { BombCoords[i], BombCoords[i+1]};
                g++;
            }
            for (int bombrows = 0; bombrows < bombs.Length; bombrows++)
            {
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        if (rows == bombs[bombrows][0] && cols == bombs[bombrows][1] && matrix[rows, cols] > 0)
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                try
                                {
                                    if (i == 0)
                                    {
                                        if (matrix[rows - 1, cols] > 0)
                                        {
                                            matrix[rows - 1, cols] -= matrix[rows, cols];
                                        }
                                    }
                                    else if (i == 1)
                                    {
                                        if (matrix[rows - 1, cols + 1] > 0)
                                        {
                                            matrix[rows - 1, cols + 1] -= matrix[rows, cols];
                                        }
                                    }
                                    else if (i == 2)
                                    {
                                        if (matrix[rows, cols + 1] > 0)
                                        {
                                            matrix[rows, cols + 1] -= matrix[rows, cols];
                                        }
                                    }
                                    else if (i == 3)
                                    {
                                        if (matrix[rows + 1, cols + 1] > 0)
                                        {
                                            matrix[rows + 1, cols + 1] -= matrix[rows, cols];
                                        }
                                    }
                                    else if (i == 4)
                                    {
                                        if (matrix[rows + 1, cols] > 0)
                                        {
                                            matrix[rows + 1, cols] -= matrix[rows, cols];
                                        }
                                    }
                                    else if (i == 5)
                                    {
                                        if (matrix[rows + 1, cols - 1] > 0)
                                        {
                                            matrix[rows + 1, cols - 1] -= matrix[rows, cols];
                                        }
                                    }
                                    else if (i == 6)
                                    {
                                        if (matrix[rows, cols - 1] > 0)
                                        {
                                            matrix[rows, cols - 1] -= matrix[rows, cols];
                                        }
                                    }
                                    else
                                    {
                                        if (matrix[rows - 1, cols - 1] > 0)
                                        {
                                            matrix[rows - 1, cols - 1] -= matrix[rows, cols];
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }
                            matrix[rows,cols] = 0;
                        }
                        else continue;
                    }
                }
            }
            SummedMatrix(matrix);
        }
        static void SummedMatrix(int[,] printed)
        {
            int sum = 0;
            int survivedCells = 0;
            for (int row = 0; row < printed.GetLength(0); row++)
            {
                for (int col = 0; col < printed.GetLength(1); col++)
                {
                    if (printed[row, col] > 0)
                    {
                        sum += printed[row, col];
                        survivedCells++;
                    }
                }
            }
            Console.WriteLine($"Alive cells: {survivedCells}");
            Console.WriteLine($"Sum: {sum}");
            PrintMatrix(printed);
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
        static int[,] DefineMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] masiv = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = masiv[col];
                }
            }
            return matrix;
        }
    }
}
