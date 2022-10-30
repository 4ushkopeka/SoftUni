using System;

namespace PathReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            char[] separators = new char[] { '\\', '.' };
            var fi = s.Split(separators);
            Console.WriteLine($"File name: {fi[fi.Length-2]}");
            Console.WriteLine($"File extension: {fi[fi.Length - 1]}");
        }
    }
}
