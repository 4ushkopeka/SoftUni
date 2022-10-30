using System;

namespace MiddleChars
{
    class Program
    {
        static string GetMidChar(string text)
        {
            string final = "";
            int leg = text.Length;
            if (leg % 2 != 0)
            {
                final += text[leg / 2];
                return final;
            }
            else
            {
                final += text[leg / 2 - 1];
                final += text[leg / 2];
                return final;
            }
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetMidChar(input));
        }
    }
}
