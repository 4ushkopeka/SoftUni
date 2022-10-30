using System;

namespace FactorialDivision
{
    class Program
    {
        static double FactorialFirst(double fisrt)
        {
            double temp = fisrt;
            while (fisrt>1)
            {
                fisrt--;
                temp *= fisrt;
            }
            return temp;
        }
        static double FactorialSecond(double second)
        {
            double temp = second;
            while (second > 1)
            {
                second--;
                temp *= second;
            }
            return temp;
        }
        static double Result(double fact1, double fact2)
        {
            double result = fact1 / fact2;
            return result;
        }
        static void Main(string[] args)
        {
            double firstNum = int.Parse(Console.ReadLine());
            double secondNum = int.Parse(Console.ReadLine());
            double result = (Result(FactorialFirst(firstNum), (FactorialSecond(secondNum))));
            Console.WriteLine($"{result:f2}");
        }
    }
}
