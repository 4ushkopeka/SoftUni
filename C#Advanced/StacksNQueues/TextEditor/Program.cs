using System;
using System.Collections.Generic;
using System.Text;

namespace TextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operandNum = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            StringBuilder result = new StringBuilder("");
            stack.Push("");
            for (int i = 0; i < operandNum; i++)
            {
                string comm = Console.ReadLine();
                var comms = comm.Split();
                if (comms[0] == "1")
                {
                    result.Append(comms[1]);
                    stack.Push(result.ToString());
                }
                else if (comms[0] == "2")
                {
                    result.Remove(result.Length-int.Parse(comms[1]), int.Parse(comms[1]));
                    stack.Push(result.ToString());
                }
                else if (comms[0] == "3")
                {
                    Console.WriteLine($"{result[int.Parse(comms[1])-1]}");
                }
                else
                {
                    if (stack.Count != 1)
                    {
                        stack.Pop();
                        result = new StringBuilder(stack.Peek());
                    }
                }
            }
        }
    }
}
