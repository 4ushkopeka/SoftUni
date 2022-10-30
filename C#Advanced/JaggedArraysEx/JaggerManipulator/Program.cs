using System;
using System.Linq;

namespace JaggerManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            decimal[][] jagger = new decimal[r][];
            for (int i = 0; i < r; i++)
            {
                jagger[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            }
            for (int i = 0;i < r-1; i++)
            {
                if (jagger[i].Length == jagger[i+1].Length)
                {
                    for (int rows = i; rows <= i+1; rows++)
                    {
                        for (int cols = 0; cols < jagger[rows].Length; cols++)
                        {
                            jagger[rows][cols] *= 2;
                        }
                    }
                }
                else
                {
                    for (int rows = i; rows <= i + 1; rows++)
                    {
                        for (int cols = 0; cols < jagger[rows].Length; cols++)
                        {
                            jagger[rows][cols] /= 2;
                        }
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                var coma = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (coma[0] == "Add")
                {
                    try
                    {
                        long row = long.Parse(coma[1]);
                        long col = long.Parse(coma[2]);
                        decimal val = decimal.Parse(coma[3]);
                        jagger[row][col] += val;
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                else
                {
                    try
                    {
                        long row = long.Parse(coma[1]);
                        long col = long.Parse(coma[2]);
                        decimal val = decimal.Parse(coma[3]);
                        jagger[row][col] -= val;
                    }
                    catch (Exception)
                    {

                    }
                }
                command = Console.ReadLine();
            }
            PrintMatrix(jagger);
        }
        static void PrintMatrix(decimal[][] printed)
        {
            for (int row = 0; row < printed.GetLength(0); row++)
            {
                for (int col = 0; col < printed[row].Length; col++)
                {
                    Console.Write($"{printed[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
