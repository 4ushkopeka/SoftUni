using System;

namespace NxNmatrix
{
    class Program
    {
        static void PrintMatrix(int num)
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            PrintMatrix(input);
        }
    }
}
