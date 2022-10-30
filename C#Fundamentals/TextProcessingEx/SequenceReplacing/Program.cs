using System;
using System.Text;

namespace SequenceReplacing
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            StringBuilder res = new StringBuilder();
            StringBuilder s1 = new StringBuilder();
            s1.Append(s);
            for (int i = 0; i < s1.Length-1; i++)
            {
                if (s1[i] == s1[i+1])
                {
                    s1.Remove(i,1);
                    i--;
                }
            }
            Console.WriteLine(s1);
        }
    }
}
