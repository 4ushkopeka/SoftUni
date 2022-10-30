using System;
using System.Text;

namespace TextProcessingEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            var data = s.Split(", ");
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Length > 2 && data[i].Length < 17)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (char item in data[i])
                    {
                        bool fi = false;
                        if (item == 45 || item == 95) fi = true;
                        else if (item > 47 && item < 58) fi = true;
                        else if (item > 64 && item < 91) fi = true;
                        else if (item > 96 && item < 123) fi = true;
                        if (fi) sb.Append(item);
                        else continue;
                    }
                    if (sb.ToString() == data[i]) Console.WriteLine(sb.ToString());
                }
                else continue;
            }
        }
    }
}
