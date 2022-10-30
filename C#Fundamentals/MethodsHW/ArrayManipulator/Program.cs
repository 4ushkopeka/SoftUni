using System;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Exchange(int [] array, int index)
        {
            if (index > array.Length-1 || index < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }
            int rotates = array.Length - 1 - index;
            while (rotates > 0)
            {
                int temp = array[array.Length - 1];
                for (int i = array.Length - 1; i > 0; i--)
                {
                    array[i] = array[i - 1];
                }
                array[0] = temp;
                rotates--;
            }
        }
        static void Max(int[] array, string type)
        {
            int index = 0;
            int max = int.MinValue;
            if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] >= max)
                    {
                        max = array[i];
                        index = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && array[i] >= max)
                    {
                        max = array[i];
                        index = i;
                    }
                }
            }
            if (max == int.MinValue)
            {
                Console.WriteLine("No matches");
                return;
            }
            Console.WriteLine(index);
        }
        static void Min(int[] array, string type)
        {
            int index = 0;
            int min = int.MaxValue;
            if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] <= min)
                    {
                        min = array[i];
                        index = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && array[i] <= min)
                    {
                        min = array[i];
                        index = i;
                    }
                }
            }
            if (min == int.MaxValue)
            {
                Console.WriteLine("No matches");
                return;
            }
            Console.WriteLine(index);
        }
        static void First(int[] array, int count, string type)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] arka = new int[count];
            int temp = 0;
            Console.Write("[");
            if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && count > 0)
                    {
                        count--;
                        arka[temp] = array[i];
                        temp++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && count > 0)
                    {
                        count--;
                        arka[temp] = array[i];
                        temp++;
                    }
                }
            }
            if (temp == 0)
            {
                Console.Write("]");
            }
            else
            {
                for (int i = 0; i < temp; i++)
                {
                    if (i != temp - 1)
                    {
                        Console.Write(arka[i] + ", ");
                    }
                    else
                    {
                        Console.Write(arka[i] + "]");
                    }
                }
            }
            Console.WriteLine();
        }
        static void Last(int[] array, int count, string type)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] arka = new int[count];
            int temp = 0;
            Console.Write("[");
            if (type == "even")
            {
                for (int i = array.Length-1; i > -1; i--)
                {
                    if (array[i] % 2 == 0 && count > 0)
                    {
                        count--;
                        arka[temp] = array[i];
                        temp++;
                    }
                }
            }
            else
            {
                for (int i = array.Length - 1; i > -1; i--)
                {
                    if (array[i] % 2 != 0 && count > 0)
                    {
                        count--;
                        arka[temp] = array[i];
                        temp++;
                    }
                }
            }
            if (temp == 0)
            {
                Console.Write("]");
            }
            else
            {
                for (int i = 0; i < temp; i++)
                {
                    if (i != temp - 1)
                    {
                        Console.Write(arka[i] + ", ");
                    }
                    else
                    {
                        Console.Write(arka[i] + "]");
                    }
                }
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "end")
            {
                if (commands[0] == "exchange")
                {
                    int index = int.Parse(commands[1]);
                    Exchange(arr, index);
                }
                else if (commands[0] == "max")
                {
                    string type = commands[1];
                    Max(arr, type);
                }
                else if (commands[0] == "min")
                {
                    string type = commands[1];
                    Min(arr, type);
                }
                else if (commands[0] == "first")
                {
                    int index = int.Parse(commands[1]);
                    string type = commands[2];
                    First(arr, index, type);
                }
                else
                {
                    int index = int.Parse(commands[1]);
                    string type = commands[2];
                    Last(arr, index, type);
                }
                commands = Console.ReadLine().Split();
            }
            Console.Write("[");
            Console.Write(string.Join(", ", arr));
            Console.Write("]");
        }
    }
}
