using System;

namespace TopNum
{
    class Program
    {
        static void NumberGenerator(int end)
        {
            for (int i = 1; i <= end; i++)
            {
                if (OddChecker(i) && SumChecker(i))
                {
                    Console.WriteLine(i);
                }
                else
                {
                    continue;
                }
            }
        }
        static bool OddChecker(int input)
        {
            int m;
            int count = 0;
            bool result = false;
            while (input > 0)
            {
                m = input % 10;
                if (m % 2 != 0)
                {
                    count++;
                    if (count>=1)
                    {
                        result = true;
                        return result;
                    }
                }
                input /= 10;
            }
            return result;
        }
        static bool SumChecker(int input)
        {
            int m;
            int sum = 0;
            bool result = false;
            while (input > 0)
            {
                m = input % 10;
                sum += m;
                input /= 10;
            }
            if (sum % 8 == 0)
            {
                result = true;
                return result;
            }
            else
            {
                return result;
            }
        }
        static void Main(string[] args)
        {
            int final = int.Parse(Console.ReadLine());
            NumberGenerator(final);
        }
    }
}
