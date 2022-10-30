using System;
using System.Linq;

namespace Marioo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());  
            char[][] castle = new char[n][];
            int[] princessCoords = new int[2];
            int[] marioCoords = new int[2];
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                castle[i] = new char[row.Length];
                char[] vs = row.ToCharArray();
                for (int g = 0; g < vs.Length; g++)
                {
                    if (vs[g] == 'P')
                    {
                        princessCoords[0] = i;
                        princessCoords[1] = g;
                    }
                    else if (vs[g] == 'M')
                    {
                        marioCoords[0] = i;
                        marioCoords[1] = g;
                    }
                }
                castle[i] = vs;
            }
            while (lives > 0)
            {
                string spawnNMove = Console.ReadLine();
                var move = spawnNMove.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                var BowserRow = int.Parse(spawnNMove.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                var BowserCol = int.Parse(spawnNMove.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2]);
                castle[BowserRow][BowserCol] = 'B';
                try
                {
                    lives--;
                    if (move == "W")
                    {
                        if (castle[marioCoords[0]-1][marioCoords[1]] == 'B')
                        {
                            if (lives - 2 <= 0)
                            {
                                Console.WriteLine($"Mario died at {marioCoords[0] - 1};{marioCoords[1]}.");
                                castle[marioCoords[0]][marioCoords[1]] = '-';
                                castle[marioCoords[0]-1][marioCoords[1]] = 'X';
                                PrintMatrix(castle);
                            }
                            else
                            {
                                lives-=2;
                                castle[marioCoords[0]][marioCoords[1]] = '-';
                                marioCoords[0] = marioCoords[0] - 1;
                                castle[marioCoords[0]][marioCoords[1]] = 'M';
                            }
                        }
                        else if (castle[marioCoords[0] - 1][marioCoords[1]] == 'P')
                        {
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            castle[marioCoords[0]][marioCoords[1]] = '-';
                            castle[princessCoords[0]][princessCoords[1]] = '-';
                            PrintMatrix(castle);
                        }
                        else
                        {
                            castle[marioCoords[0]][marioCoords[1]] = '-';
                            marioCoords[0] = marioCoords[0] - 1;
                            castle[marioCoords[0]][marioCoords[1]] = 'M';
                        }
                    }
                    else if (move =="S")
                    {
                        if (castle[marioCoords[0] + 1][marioCoords[1]] == 'B')
                        {
                            if (lives - 2 <= 0)
                            {
                                Console.WriteLine($"Mario died at {marioCoords[0] + 1};{marioCoords[1]}.");
                                castle[marioCoords[0]][marioCoords[1]] = '-';
                                castle[marioCoords[0] + 1][marioCoords[1]] = 'X';
                                PrintMatrix(castle);
                            }
                            else
                            {
                                lives -= 2;
                                castle[marioCoords[0]][marioCoords[1]] = '-';
                                marioCoords[0] = marioCoords[0] + 1;
                                castle[marioCoords[0]][marioCoords[1]] = 'M';
                            }
                        }
                        else if (castle[marioCoords[0] + 1][marioCoords[1]] == 'P')
                        {
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            castle[marioCoords[0]][marioCoords[1]] = '-';
                            castle[princessCoords[0]][princessCoords[1]] = '-';
                            PrintMatrix(castle);
                        }
                        else
                        {
                            castle[marioCoords[0]][marioCoords[1]] = '-';
                            marioCoords[0] = marioCoords[0] + 1;
                            castle[marioCoords[0]][marioCoords[1]] = 'M';
                        }
                    }
                    else if (move == "A")
                    {
                        if (castle[marioCoords[0]][marioCoords[1]-1] == 'B')
                        {
                            if (lives - 2 <= 0)
                            {
                                Console.WriteLine($"Mario died at {marioCoords[0]};{marioCoords[1]-1}.");
                                castle[marioCoords[0]][marioCoords[1]] = '-';
                                castle[marioCoords[0]][marioCoords[1]-1] = 'X';
                                PrintMatrix(castle);
                            }
                            else
                            {
                                lives -= 2;
                                castle[marioCoords[0]][marioCoords[1]] = '-';
                                marioCoords[1] = marioCoords[1] - 1;
                                castle[marioCoords[0]][marioCoords[1]] = 'M';
                            }
                        }
                        else if (castle[marioCoords[0]][marioCoords[1]-1] == 'P')
                        {
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            castle[marioCoords[0]][marioCoords[1]] = '-';
                            castle[princessCoords[0]][princessCoords[1]] = '-';
                            PrintMatrix(castle);
                        }
                        else
                        {
                            castle[marioCoords[0]][marioCoords[1]] = '-';
                            marioCoords[1] = marioCoords[1] - 1;
                            castle[marioCoords[0]][marioCoords[1]] = 'M';
                        }
                    }
                    else if (move == "D")
                    {
                        if (castle[marioCoords[0]][marioCoords[1] + 1] == 'B')
                        {
                            if (lives - 2 <= 0)
                            {
                                Console.WriteLine($"Mario died at {marioCoords[0]};{marioCoords[1] + 1}.");
                                castle[marioCoords[0]][marioCoords[1]] = '-';
                                castle[marioCoords[0]][marioCoords[1] + 1] = 'X';
                                PrintMatrix(castle);
                            }
                            else
                            {
                                lives -= 2;
                                castle[marioCoords[0]][marioCoords[1]] = '-';
                                marioCoords[1] = marioCoords[1] + 1;
                                castle[marioCoords[0]][marioCoords[1]] = 'M';
                            }
                        }
                        else if (castle[marioCoords[0]][marioCoords[1]+1] == 'P')
                        {
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            castle[marioCoords[0]][marioCoords[1]] = '-';
                            castle[princessCoords[0]][princessCoords[1]] = '-';
                            PrintMatrix(castle);
                        }
                        else
                        {
                            castle[marioCoords[0]][marioCoords[1]] = '-';
                            marioCoords[1] = marioCoords[1] + 1;
                            castle[marioCoords[0]][marioCoords[1]] = 'M';
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            Console.WriteLine($"Mario died at {marioCoords[0]};{marioCoords[1]}.");
            castle[marioCoords[0]][marioCoords[1]] = 'X';
            PrintMatrix(castle);
        }

        private static void PrintMatrix(char [][] cas)
        {
            for (int i = 0; i < cas.GetLength(0); i++)
            {
                Console.WriteLine(String.Join("", cas[i]));
            }
            System.Environment.Exit(1);
        }
    }
}
