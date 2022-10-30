using System;
using System.Linq;

namespace SYmbolFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int rows = 0; rows < size; rows++)
            {
                string off = Console.ReadLine();
                char[] k = off.ToCharArray();
                for (int cols = 0; cols < size; cols++)
                {
                    matrix[rows, cols] = k[cols];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    if (matrix[rows, cols] == symbol)
                    {
                        Console.WriteLine($"({rows}, {cols})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
