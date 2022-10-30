using System;

namespace oburmatChar
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] duh = Console.ReadLine().Split();
            for (int i = duh.Length - 1; i >= 0; i--)
            {
                Console.Write(duh[i] + " ");
            }
        }
    }
}
