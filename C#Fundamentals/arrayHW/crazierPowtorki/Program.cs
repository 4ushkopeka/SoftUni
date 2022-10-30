using System;
using System.Linq;

namespace crazierPowtorki
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 0;
            int chislo = 1;
            int realcount = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                counter = 1;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        counter++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                if (counter > realcount)
                {
                    chislo = arr[i];
                    realcount = counter;
                }
            }
            for (int i = 0; i < realcount; i++)
            {
                Console.Write(chislo + " ");
            }
        }
    }
}
