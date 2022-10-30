using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] date1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            DateTime dateTime = new DateTime(date1[0], date1[1], date1[2]);
            int[] date2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            DateTime dateTime1 = new DateTime(date2[0], date2[1], date2[2]);
            Console.WriteLine(DateModifier.CalcDiff(dateTime, dateTime1)); 
        }
    }
}
