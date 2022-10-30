using System;
using System.Linq;

namespace Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lake lak = new Lake(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Console.WriteLine(String.Join(", ", lak));
        }
    }
}
