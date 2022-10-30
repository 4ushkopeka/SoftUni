using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperands
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers= Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] commands;
            do
            {
                commands = Console.ReadLine().Split();
                if (commands[0] == "Add")
                {
                    int num = int.Parse(commands[1]);
                    integers.Add(num);
                }
                else if (commands[0] == "Insert")
                {
                    int num = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);
                    if (index > integers.Count - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    integers.Insert(index, num);
                }
                else if (commands[0] == "Remove")
                {
                    int index = int.Parse(commands[1]);
                    if (index > integers.Count - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    integers.RemoveAt(index);
                }
                else if (commands[0] == "Shift")
                {
                    int count = int.Parse(commands[2]);
                    if (commands[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int temp = integers[0];
                            integers.RemoveAt(0);
                            integers.Add(temp);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int temp = integers[integers.Count - 1];
                            integers.RemoveAt(integers.Count - 1);
                            integers.Insert(0, temp);
                        }
                    }
                }
            }
            while (commands[0] != "End");
            Console.WriteLine(string.Join(" ", integers));
        }
    }
}
