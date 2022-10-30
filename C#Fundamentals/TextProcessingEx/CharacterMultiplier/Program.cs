using System;
using System.Text;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder firstW = new StringBuilder();
            StringBuilder secondW = new StringBuilder();
            firstW.Append(Console.ReadLine());
            int index = firstW.ToString().IndexOf(' ');
            var data = firstW.ToString().Split(" ");
            secondW.Append(data[1]);
            firstW.Remove(index,firstW.Length-index);
            if (firstW.Length == secondW.Length) Multiplier(firstW, secondW, secondW.Length, 0);
            else if(firstW.Length - secondW.Length > 0)
            {
                int sum = 0;
                for (int i = secondW.Length; i < firstW.Length; i++)
                {
                    sum += firstW[i];
                }
                Multiplier(firstW, secondW, secondW.Length, sum);
            }
            else
            {
                int sum = 0;
                for (int i = firstW.Length; i < secondW.Length; i++)
                {
                    sum += secondW[i];
                }
                Multiplier(firstW, secondW, firstW.Length, sum);
            }
        }
        static void Multiplier(StringBuilder f, StringBuilder s, int leg ,int addition)
        {
            int sum = 0;
            for (int i = 0; i < leg; i++)
            {
                sum += f[i] * s[i];
            }
            if (addition == 0) Console.WriteLine(sum);
            else if (Math.Max(f.Length, s.Length) == f.Length)
            {
                sum += addition;
                Console.WriteLine(sum);
            }
            else
            {
                sum += addition;
                Console.WriteLine(sum);
            }
        }
    }
}
