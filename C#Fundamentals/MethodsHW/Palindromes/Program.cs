using System;

namespace Palindromes
{
    class Program
    {
        static bool IsPalindrome(int number)
        {
            int temp = number;
            int m;
            int reverser = 0;
            bool result;
            while (temp>0)
            {
                m = temp % 10;
                reverser = (reverser * 10) + m;
                temp /= 10;
            }
            if (reverser == number)
            {
                result = true;
                return result;
            }
            else
            {
                result = false;
                return result;
            }
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                int num = int.Parse(input);
                Console.WriteLine(IsPalindrome(num));
                input = Console.ReadLine();
            }
        }
    }
}
