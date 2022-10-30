using System;

namespace MasiviSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split();
            double min = int.MaxValue;
            double max = int.MinValue;
            double counter = 0;
            double sum = 0;
            double[] g = new double[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                counter++;
                g[i] = double.Parse(s[i]);
                sum += g[i];
                if (g[i] < min)
                {
                    min = g[i];
                }
                if (g[i] > max)
                {
                    max = g[i];
                }
            }
            double av = sum / counter;
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {av}");
        }
    }
}
