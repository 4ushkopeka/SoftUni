using System;

namespace SumASub
{
    class Program
    {
        static int Sum(int first, int second)
        {
            int sum = first + second;
            return sum;
        }
        static int Subst(int result, int substrat)
        {
            int final = result - substrat;
            return final;
        }
        static void Main(string[] args)
        {
            int sum1 = int.Parse(Console.ReadLine());
            int sum2 = int.Parse(Console.ReadLine());
            int sub1 = int.Parse(Console.ReadLine());
            Console.WriteLine(Subst(Sum(sum1, sum2), sub1));
        }
    }
}
