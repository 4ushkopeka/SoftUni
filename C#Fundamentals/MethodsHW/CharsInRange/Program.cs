using System;

namespace CharsInRange
{
    class Program
    {
        static void SymbolsInRange(char one, char two)
        {
            char temp = one;
            if (two > one)
            {
                one = two;
                two = temp;
            }
            while (one>two+1)
            {
                two++;
                Console.Write(two + " ");
            }
        }
        static void Main(string[] args)
        {
            char input1 = char.Parse(Console.ReadLine());
            char input2 = char.Parse(Console.ReadLine());
            SymbolsInRange(input1, input2);

        }
    }
}
