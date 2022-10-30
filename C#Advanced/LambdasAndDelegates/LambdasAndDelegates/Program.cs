
using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdasAndDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<string> action = x => Console.WriteLine(x);
            names.ForEach(action);
        }
    }
}
