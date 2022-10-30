using System;

namespace arrayHW
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] peeps = new int[wagons];
            int sum = 0;
            for (int i = 0; i < wagons; i++)
            {
                peeps[i] = int.Parse(Console.ReadLine());
                sum += peeps[i];
            }
            for (int i = 0; i < wagons; i++)
            {
                Console.Write(peeps[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
