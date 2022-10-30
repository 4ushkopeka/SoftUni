using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] field = new char[size[0], size[1]];
            string snake = Console.ReadLine();
            Queue<char> queue = new Queue<char>(snake.ToCharArray());
            for (int rows = 0; rows < field.GetLength(0); rows++)
            {
                if (rows%2 == 0)
                {
                    for (int cols = 0; cols < field.GetLength(1); cols++) 
                    {
                        char c = queue.Peek();
                        field[rows, cols] = queue.Dequeue();
                        queue.Enqueue(c);
                    }
                }
                else
                {
                    for (int cols = field.GetLength(1) - 1; cols >= 0; cols--)
                    {
                        char c = queue.Peek();
                        field[rows, cols] = queue.Dequeue();
                        queue.Enqueue(c);
                    }
                }
            }
            PrintMatrix(field);
        }
        static void PrintMatrix(char[,] printed)
        {
            for (int row = 0; row < printed.GetLength(0); row++)
            {
                for (int col = 0; col < printed.GetLength(1); col++)
                {
                    Console.Write($"{printed[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
