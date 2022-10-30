using System;
using System.Linq;

namespace MatrixShuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = DefineMatrix(n);
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] vs = command.Split();
                if (vs.Length != 5) Console.WriteLine("Invalid input!");
                else if (command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0] == "swap")
                {
                    int row1 = int.Parse(command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                    int col1 = int.Parse(command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2]);
                    int row2 = int.Parse(command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[3]);
                    int col2 = int.Parse(command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[4]);
                    try
                    {
                        string star = matrix[row1,col1];
                        matrix[row1,col1] = matrix[row2,col2];
                        matrix[row2,col2] = star;
                        PrintMatrix(matrix);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else Console.WriteLine("Invalid input!");
                command = Console.ReadLine();
            }
        }
        static string[,] DefineMatrix(int[] n)
        {
            string[,] matrix = new string[n[0], n[1]];
            for (int row = 0; row < n[0]; row++)
            {
                string[] masiv = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < n[1]; col++)
                {
                    matrix[row, col] = masiv[col];
                }
            }
            return matrix;
        }
        static void PrintMatrix(string[,] printed)
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
