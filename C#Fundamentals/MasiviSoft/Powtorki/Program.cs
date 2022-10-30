using System;

namespace Powtorki
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split();
            int[] num = new int[s.Length];
            int realcount = 0;
            int chislo = 0;
            for (int i = 0; i < s.Length; i++)
            {
                num[i] = int.Parse(s[i]);
            }
            for (int i = 0; i < s.Length; i++)
            {
                int counter = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    if (num[i] == num[j])
                    {
                        counter++;
                    }
                    else if (counter > realcount)
                    {
                        chislo = num[i];
                        realcount = counter;
                    }
                }
            }
            Console.WriteLine(chislo);
        }
    }
}
