using System;
using System.Linq;

namespace JaggedArrayMod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int rows = 0; rows < size; rows++)
            {
                int[] k = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int cols = 0; cols < size; cols++)
                {
                    matrix[rows, cols] = k[cols];
                }
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                var com = command.Split(' ');
                int r = int.Parse(com[1]);
                int c = int.Parse(com[2]);
                int d = int.Parse(com[3]);
                if (com[0] == "Add")
                {
                    matrix[r, c] += d;
                }
                else
                {
                    matrix[r, c] -= d;

                }
                command = Console.ReadLine();
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
