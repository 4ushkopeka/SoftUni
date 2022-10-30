using System;
using System.Collections.Generic;
using System.Linq;

namespace FakeStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> lines = new List<string>();
            MyStack<string> stack = new MyStack<string>();
            while (command!= "END")
            {
                lines.Add(command);
                command = Console.ReadLine();
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in lines)
                {
                    if (item.Split()[0] == "Push") stack.Push(item.Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray());
                    else stack.Pop();
                }
            }
            foreach (var item in stack) Console.WriteLine(item);
        }
    }
}
