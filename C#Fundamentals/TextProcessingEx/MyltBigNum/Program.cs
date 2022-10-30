using System;
using System.Numerics;

namespace MyltBigNum
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger a = new BigInteger();
            a = BigInteger.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(a*b);
        }
    }
}
