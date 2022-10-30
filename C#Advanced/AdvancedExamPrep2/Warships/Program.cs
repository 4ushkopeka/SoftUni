using System;
using System.Linq;

namespace Warships
{
    internal class Program
    {
        public static int p1des = 0;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string coords = Console.ReadLine();
            string[] splittedCoords = coords.Split(',', StringSplitOptions.RemoveEmptyEntries);
            int[][] attackCoords = new int[splittedCoords.Length][];
            for (int i = 0; i < splittedCoords.Length; i++)
            {
                int[] ar = splittedCoords[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                attackCoords[i] = new int[2];
                attackCoords[i] = ar;
            }
            char[,] ships = DefineMatrix(n);
            for (int i = 0; i < attackCoords.Length; i++)
            {
                try
                {
                    int x = attackCoords[i][0];
                    int y = attackCoords[i][1];
                    if (ships[x, y] == '#') ships = Bomb(x, y, ships);
                    else if (ships[x, y] == '<') { ships[x, y] = 'X'; p1des++; }
                    else if (ships[x, y] == '>') { ships[x, y] = 'X'; p1des++; }
                }
                catch (Exception) { continue; }
            }
            int p1s = 0;
            int p2s = 0;
            for (int i = 0; i < ships.GetLength(0); i++)
            {
                for (int g = 0; g < ships.GetLength(1); g++)
                {
                    if (ships[i, g] == '<') p1s++;
                    else if (ships[i, g] == '>') p2s++;
                }
            }
            if (p2s != 0 && p1s != 0) Console.WriteLine($"It's a draw! Player One has {p1s} ships left. Player Two has { p2s} ships left.");
            else if (p1s == 0) Console.WriteLine($"Player Two has won the game! { p1des} ships have been sunk in the battle.");
            else Console.WriteLine($"Player One has won the game! { p1des} ships have been sunk in the battle.");
        }

        private static char[,] Bomb(int x, int y, char[,] matrix)
        {
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    if (i == 0)
                    {
                        if (matrix[x - 1, y] == '<') { matrix[x - 1, y] = 'X'; p1des++; }
                        else if (matrix[x - 1, y] == '>') { matrix[x - 1, y] = 'X'; p1des++; }
                    }
                    else if (i == 1)
                    {
                        if (matrix[x - 1, y + 1] == '<') { matrix[x - 1, y + 1] = 'X'; p1des++; }
                        else if (matrix[x - 1, y + 1] == '>') { matrix[x - 1, y + 1] = 'X'; p1des++; }
                    }
                    else if (i == 2)
                    {
                        if (matrix[x, y + 1] == '<') { matrix[x, y + 1] = 'X'; p1des++; }
                        else if (matrix[x, y + 1] == '>') { matrix[x, y + 1] = 'X'; p1des++; }
                    }
                    else if (i == 3)
                    {
                        if (matrix[x + 1, y + 1] == '<') { matrix[x + 1, y + 1] = 'X'; p1des++; }
                        else if (matrix[x + 1, y + 1] == '>') { matrix[x + 1, y + 1] = 'X'; p1des++; }
                    }
                    else if (i == 4)
                    {
                        if (matrix[x + 1, y] == '<') { matrix[x + 1, y] = 'X'; p1des++; }
                        else if (matrix[x + 1, y] == '>') { matrix[x + 1, y] = 'X'; p1des++; }
                    }
                    else if (i == 5)
                    {
                        if (matrix[x + 1, y - 1] == '<') { matrix[x + 1, y - 1] = 'X'; p1des++; }
                        else if (matrix[x + 1, y - 1] == '>') { matrix[x + 1, y - 1] = 'X'; p1des++; }
                    }
                    else if (i == 6)
                    {
                        if (matrix[x, y - 1] == '<') { matrix[x, y - 1] = 'X'; p1des++; }
                        else if (matrix[x, y - 1] == '>') { matrix[x, y - 1] = 'X'; p1des++; }
                    }
                    else if (i == 7)
                    {
                        if (matrix[x - 1, y - 1] == '<') { matrix[x - 1, y - 1] = 'X'; p1des++; }
                        else if (matrix[x - 1, y - 1] == '>') { matrix[x - 1, y - 1] = 'X'; p1des++; }
                    }
                }
                catch (Exception) { continue; }
            }
            return matrix;
        }
        static char[,] DefineMatrix(int n)
        {
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string g = Console.ReadLine();
                char[] masiv = g.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++) matrix[row, col] = masiv[col];
            }
            return matrix;
        }
    }
}
