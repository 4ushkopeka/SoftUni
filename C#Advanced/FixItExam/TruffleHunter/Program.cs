using System;
using System.Linq;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = DefineMatrix(size);
            string command = Console.ReadLine();
            int blackTrufsCollected = 0, whiteTrufsCollected = 0, summerTrufsCollected = 0;
            int eatenTrufs = 0;
            while (command != "Stop the hunt")
            {
                var commandToBeExecuted = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commandToBeExecuted[0] == "Collect")
                {
                    int row = int.Parse(commandToBeExecuted[1]);
                    int col = int.Parse(commandToBeExecuted[2]);
                    if (matrix[row,col] == "B")
                    {
                        blackTrufsCollected++;
                        matrix[row, col] = "-";
                    }
                    else if (matrix[row,col] == "S")
                    {
                        summerTrufsCollected++;
                        matrix[row, col] = "-";
                    }
                    else if (matrix[row,col] == "W")
                    {
                        whiteTrufsCollected++;
                        matrix[row, col] = "-";
                    }
                }
                else
                {
                    int row = int.Parse(commandToBeExecuted[1]);
                    int col = int.Parse(commandToBeExecuted[2]);
                    string direction = commandToBeExecuted[3];
                    try
                    {
                        if (direction == "up")
                        {
                            for (int rows = row; ; rows-=2)
                            {
                                if (matrix[rows, col] != "-")
                                {
                                    matrix[rows, col] = "-";
                                    eatenTrufs++;
                                }
                            }
                        }
                        else if (direction =="down")
                        {
                            for (int rows = row; ; rows += 2)
                            {
                                if (matrix[rows, col] != "-")
                                {
                                    matrix[rows, col] = "-";
                                    eatenTrufs++;
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int cols = col; ; cols -= 2)
                            {
                                if (matrix[row, cols] != "-")
                                {
                                    matrix[row, cols] = "-";
                                    eatenTrufs++;
                                }
                            }
                        }
                        else
                        {
                            for (int cols = col; ; cols += 2)
                            {
                                if (matrix[row, cols] != "-")
                                {
                                    matrix[row, cols] = "-";
                                    eatenTrufs++;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {blackTrufsCollected} black, {summerTrufsCollected} summer, and {whiteTrufsCollected} white truffles.\nThe wild boar has eaten {eatenTrufs} truffles.");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++) Console.Write(matrix[row, col] + " ");
                Console.WriteLine();
            }
        }

        public static string[,] DefineMatrix(int n)
        {
            string[,] matrix = new string[n, n];
            for (int row = 0; row < n; row++)
            {
                string[] masiv = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < n; col++) matrix[row, col] = masiv[col];
            }
            return matrix;
        }
    }
}
