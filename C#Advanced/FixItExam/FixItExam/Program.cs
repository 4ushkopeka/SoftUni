using System;
using System.Collections.Generic;
using System.Linq;

namespace FixItExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mealsInp = Console.ReadLine().Split(' ').ToArray();
            int[] calsPerDayInp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<string> meals = new Queue<string>(mealsInp);
            Queue<int> mealsValues = new Queue<int>();
            foreach (var item in mealsInp) mealsValues.Enqueue(GetMealValue(item.ToLower()));
            Stack<int> cals = new Stack<int>(calsPerDayInp);
            int numOfMeals = 0;
            while (meals.Count != 0 && cals.Count!= 0)
            {
                if (mealsValues.Peek()<cals.Peek())
                {
                    meals.Dequeue();
                    int temp = cals.Peek() - mealsValues.Peek();
                    mealsValues.Dequeue();
                    cals.Pop();
                    cals.Push(temp);
                    numOfMeals++;
                }
                else if (mealsValues.Peek() == cals.Peek())
                {
                    cals.Pop();
                    meals.Dequeue();
                    mealsValues.Dequeue();
                    numOfMeals++;
                }
                else
                {
                    int temp = mealsValues.Peek() - cals.Pop();
                    int[] toBeChanged = mealsValues.ToArray();
                    toBeChanged[0] = temp;
                    mealsValues = new Queue<int>(toBeChanged);
                    if (cals.Count == 0)
                    {
                        meals.Dequeue();
                        numOfMeals++;
                    }
                }
            }
            if (meals.Count == 0) Console.WriteLine($"John had {numOfMeals} meals.\nFor the next few days, he can eat {string.Join(", ", cals)} calories.");
            else Console.WriteLine($"John ate enough, he had {numOfMeals} meals.\nMeals left: {string.Join(", ", meals)}.");
        }

        private static int GetMealValue(string meal)
        {
            switch (meal)
            {
                case "salad": return 350;
                case "soup": return 490;
                case "pasta": return 680;
                case "steak": return 790;
                default:
                    return 0;
            }
        }
    }
}
