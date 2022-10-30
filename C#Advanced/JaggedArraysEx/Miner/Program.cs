
using System;
using System.Linq;

namespace Miner
{
    internal class Program
    {
        public static int totalCoals;
        public static int [] sCoords;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string [,]matrix = DefineMatrix(size);
            int posRow = 0, posCol = 0;
            int totalCoal = 0;
            for (int comm = 0; comm < commands.Length; comm++)
            {
                if (comm == 0)
                {
                    if (commands[comm] == "left")
                    {
                        try
                        {
                            posRow = sCoords[0];
                            posCol = sCoords[1] - 1;
                            if (matrix[posRow, posCol] == "c")
                            {
                                matrix[posRow, posCol] = "*";
                                totalCoals--;
                                totalCoal++;
                                if (totalCoals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({posRow}, {posCol})");
                                    System.Environment.Exit(1);
                                }
                            }
                            else if (matrix[posRow, posCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({posRow}, {posCol})");
                                System.Environment.Exit(1);
                            }
                        }
                        catch (Exception)
                        {
                            posRow = sCoords[0];
                            posCol = sCoords[1];
                            continue;
                        }
                    }
                    else if (commands[comm] == "right")
                    {
                        try
                        {
                            posRow = sCoords[0];
                            posCol = sCoords[1] + 1;
                            if (matrix[posRow, posCol] == "c")
                            {
                                matrix[posRow, posCol] = "*";
                                totalCoals--;
                                totalCoal++;
                                if (totalCoals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({posRow}, {posCol})");
                                    System.Environment.Exit(1);
                                }
                            }
                            else if (matrix[posRow, posCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({posRow}, {posCol})");
                                System.Environment.Exit(1);
                            }
                        }
                        catch (Exception)
                        {
                            
                                posRow = sCoords[0];
                                posCol = sCoords[1];
                                continue;
                            
                        }
                    }
                    else if (commands[comm] == "up")
                    {
                        try
                        {
                            posRow = sCoords[0] - 1;
                            posCol = sCoords[1];
                            if (matrix[posRow, posCol] == "c")
                            {
                                matrix[posRow, posCol] = "*";
                                totalCoals--;
                                totalCoal++;
                                if (totalCoals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({posRow}, {posCol})");
                                    System.Environment.Exit(1);
                                }
                            }
                            else if (matrix[posRow, posCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({posRow}, {posCol})");
                                System.Environment.Exit(1);
                            }
                        }
                        catch (Exception)
                        {
                            
                                posRow = sCoords[0];
                                posCol = sCoords[1];
                                continue;
                        }
                    }
                    else
                    {
                        try
                        {
                            posRow = sCoords[0] + 1;
                            posCol = sCoords[1];
                            if (matrix[posRow, posCol] == "c")
                            {
                                matrix[posRow, posCol] = "*";
                                totalCoals--;
                                totalCoal++;
                                if (totalCoals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({posRow}, {posCol})");
                                    System.Environment.Exit(1);
                                }
                            }
                            else if (matrix[posRow, posCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({posRow}, {posCol})");
                                System.Environment.Exit(1);
                            }
                        }
                        catch (Exception)
                        {
                            posRow = sCoords[0];
                            posCol = sCoords[1];
                            continue;
                        }
                    }
                }
                else
                {
                    if (commands[comm] == "left")
                    {
                        try
                        {
                            posCol --;
                            if (matrix[posRow, posCol] == "c")
                            {
                                matrix[posRow, posCol] = "*";
                                totalCoals--;
                                totalCoal++;
                                if (totalCoals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({posRow}, {posCol})");
                                    System.Environment.Exit(1);
                                }
                            }
                            else if (matrix[posRow, posCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({posRow}, {posCol})");
                                System.Environment.Exit(1);
                            }
                        }
                        catch (Exception)
                        {
                            posCol++;
                            continue;
                        }
                    }
                    else if (commands[comm] == "right")
                    {
                        try
                        {
                            posCol ++;
                            if (matrix[posRow, posCol] == "c")
                            {
                                matrix[posRow, posCol] = "*";
                                totalCoals--;
                                totalCoal++;
                                if (totalCoals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({posRow}, {posCol})");
                                    System.Environment.Exit(1);
                                }
                            }
                            else if (matrix[posRow, posCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({posRow}, {posCol})");
                                System.Environment.Exit(1);
                            }
                        }
                        catch (Exception)
                        {
                            posCol--;
                            continue;
                        }
                    }
                    else if (commands[comm] == "up")
                    {
                        try
                        {
                            posRow --;
                            if (matrix[posRow, posCol] == "c")
                            {
                                matrix[posRow, posCol] = "*";
                                totalCoals--;
                                totalCoal++;
                                if (totalCoals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({posRow}, {posCol})");
                                    System.Environment.Exit(1);
                                }
                            }
                            else if (matrix[posRow, posCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({posRow}, {posCol})");
                                System.Environment.Exit(1);
                            }
                        }
                        catch (Exception)
                        {
                            posRow++;
                            continue;
                        }
                    }
                    else
                    {
                        try
                        {
                            posRow ++;
                            if (matrix[posRow, posCol] == "c")
                            {
                                matrix[posRow, posCol] = "*";
                                totalCoals--;
                                totalCoal++;
                                if (totalCoals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({posRow}, {posCol})");
                                    System.Environment.Exit(1); 
                                }
                            }
                            else if (matrix[posRow, posCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({posRow}, {posCol})");
                                System.Environment.Exit(1);
                            }
                        }
                        catch (Exception)
                        {
                            posRow--;
                            continue;
                        }
                    }
                }
            }
            Console.WriteLine($"{totalCoals} coals left. ({posRow}, {posCol})");
        }
        static string[,] DefineMatrix(int n)
        {
            string[,] matrix = new string[n, n];
            for (int row = 0; row < n; row++)
            {
                string[] masiv = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = masiv[col];
                    if (matrix[row, col] == "c") totalCoals++;
                    else if (matrix[row, col] == "s")
                    {
                        sCoords = new int[2];
                        sCoords[0] = row;
                        sCoords[1] = col;
                    }
                }
            }
            return matrix;
        }
    }
}
