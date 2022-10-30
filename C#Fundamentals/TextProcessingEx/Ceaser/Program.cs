using System;
using System.Text;

namespace Ceaser
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string result = "";
            foreach (char item in s) result += (char)(item + 3);
            Console.WriteLine(result);
        }
    }
}
