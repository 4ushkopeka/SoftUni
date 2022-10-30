using System;
using System.Linq;

namespace zigityzagity
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[] duo = new int[input];
            int[] trio = new int[input];
            int counter = 0;
            for (int i = 0; i < input; i++)
            {
                int first = int.Parse(Console.ReadLine());
                duo[i] = first;
                while (first>0)
                {
                    counter++;
                    first /= 10;
                }
                Console.SetCursorPosition(counter + 1, i + 1);
                int second = int.Parse(Console.ReadLine());
                trio[i] = second;
                counter = 0;
            }
            for (int i = 0; i < input; i++)
            {
                if (i == 0)
                {
                    Console.Write(duo[i] + " " + trio[i+1] + " ");
                    i++;
                    continue;
                }
                Console.Write(duo[i] + " " + trio[i+1]);
                i++;
            }
            Console.WriteLine();
            for (int i = 0; i < input; i++)
            {
                if (i == 0)
                {
                    Console.Write(trio[i] + " " + duo[i + 1] + " ");
                    i++;
                    continue;
                }
                Console.Write(trio[i] + " " + duo[i + 1]);
                i++;
            }
        }
    }
}
