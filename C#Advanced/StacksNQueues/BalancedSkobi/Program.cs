using System;
using System.Collections.Generic;

namespace BalancedSkobi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string skobi = Console.ReadLine();
           Stack<char> stack = new Stack<char>();
            for (int i = 0; i < skobi.Length; i++)
            {
                if (skobi[i] == '{' || skobi[i] == '[' || skobi[i] == '(') stack.Push(skobi[i]);
                else
                {
                    try
                    {
                        if (skobi[i] == ')')
                        {
                            if (stack.Peek() == '(') stack.Pop();
                            else
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }
                        else if (skobi[i] == ']')
                        {
                            if (stack.Peek() == '[') stack.Pop();
                            else
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }
                        else if (skobi[i] == '}')
                        {
                            if (stack.Peek() == '{') stack.Pop();
                            else
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
