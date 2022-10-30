using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Appender(List<string> inp, List<int> res)
        {
            int count = 0;
            for (int i = inp.Count-1; i > -1; i--)
            {
                try
                {
                    res.Add(int.Parse(inp[i]));
                    count++;
                    inp.RemoveAt(inp.Count - 1);
                }
                catch (Exception)
                {
                    inp.RemoveAt(inp.Count - 1);
                    break;
                }
            }
            int index = 0;
            int g = count / 2;
            for (int i = res.Count-count; g>0; i++)
            {
                int temp = res[i];
                res[i] = res[res.Count - index - 1];
                res[res.Count - index - 1] = temp;
                index++;
                g--;
            }
        }
        static void Main(string[] args)
        {
            List<int> result = new List<int>();
            List<string> input = Console.ReadLine().Split().ToList();
            int br = 1;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == "|")
                {
                    br++;
                }
            }
            while (br != 0)
            {
                Appender(input, result);
                br--;
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
