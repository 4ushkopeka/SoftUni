using System;
using System.Linq;

namespace KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char [,] matrix = DefineMatrix(n);
            int destroyedKnights = 0;
            int maxDamage = 1;
            int killRow = 0;
            int killCol = 0;
            while (maxDamage!=0)
            {
                maxDamage = int.MinValue;
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        if (matrix[rows, cols] == 'K')
                        {
                            int damage = 0;
                            for (int i = 0; i < 8; i++)
                            {
                                try
                                {
                                    if (i == 0)
                                    {
                                        if (matrix[rows + 1, cols - 2] == 'K')
                                        {
                                            damage++;
                                        }
                                    }
                                    else if (i == 1)
                                    {
                                        if (matrix[rows + 2, cols - 1] == 'K')
                                        {
                                            damage++;
                                        }
                                    }
                                    else if (i == 2)
                                    {
                                        if (matrix[rows + 2, cols + 1] == 'K')
                                        {
                                            damage++;
                                        }
                                    }
                                    else if (i == 3)
                                    {
                                        if (matrix[rows + 1, cols + 2] == 'K')
                                        {
                                            damage++;
                                        }
                                    }
                                    else if (i == 4)
                                    {
                                        if (matrix[rows - 1, cols + 2] == 'K')
                                        {
                                            damage++;
                                        }
                                    }
                                    else if (i == 5)
                                    {
                                        if (matrix[rows - 2, cols + 1] == 'K')
                                        {
                                            damage++;
                                        }
                                    }
                                    else if (i == 6)
                                    {
                                        if (matrix[rows - 2, cols - 1] == 'K')
                                        {
                                            damage++;
                                        }
                                    }
                                    else
                                    {
                                        if (matrix[rows - 1, cols - 2] == 'K')
                                        {
                                            damage++;
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }
                            if (damage > maxDamage)
                            {
                                maxDamage = damage;
                                killRow = rows;
                                killCol = cols;
                            }
                        }
                        else continue;
                    }
                }
                if (maxDamage!= 0)
                {
                    matrix[killRow, killCol] = '0';
                    destroyedKnights++;
                }
            }
            Console.WriteLine(destroyedKnights);
        }
        static char[,] DefineMatrix(int n)
        {
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string masiv = Console.ReadLine();
                char[] chars = masiv.ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            return matrix;
        }
    }
}
