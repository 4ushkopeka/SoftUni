using System;

namespace VowelsCount
{
    class Program
    {
        static int VowelCount(string input)
        {
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'A')
                {
                    counter++;
                }
                else if (input[i] == 'o' || input[i] == 'O')
                {
                    counter++;
                }
                else if (input[i] == 'u' || input[i] == 'U')
                {
                    counter++;
                }
                else if (input[i] == 'e' || input[i] == 'E')
                {
                    counter++;
                }
                else if (input[i] == 'i' || input[i] == 'I')
                {
                    counter++;
                }
            }
            return counter;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(VowelCount(input));
        }
    }
}
