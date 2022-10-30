using System;

namespace MethodsHW
{
    class Program
    {
        static int PrintSmallestNum(int a, int b, int c)
        {
            if (a<b && a<c)
            {
                return a;
            }
            else if (b<a && b<c)
            {
                return b;
            }
            else
            {
                return c;
            }
        }
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            Console.WriteLine(PrintSmallestNum(num1, num2, num3));
        }
    }
}
