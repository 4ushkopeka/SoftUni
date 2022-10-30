using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int field = int.Parse(Console.ReadLine());
            if (field == 0) System.Environment.Exit(1);
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] general = new int[field];
            for (int k = 0; k < indexes.Length; k++)
            {
                for (int i = 0; i < field; i++)
                {
                    if (i == indexes[k]) general[i] = 1;
                }
            }
            string[] commands = Console.ReadLine().Split();
            bool checker = true;
            while (commands[0] != "end")
            {
                int index = int.Parse(commands[0]);
                string direction = commands[1];
                int flyLeg = int.Parse(commands[2]);
                int temp = flyLeg;
                if (flyLeg < 0)
                {
                    if (direction == "left")
                    {
                        direction = "right";
                        flyLeg = Math.Abs(flyLeg);
                        temp = Math.Abs(temp);
                    }
                    else
                    {
                        direction = "left";
                        flyLeg = Math.Abs(flyLeg);
                        temp = Math.Abs(temp);
                    }
                }
                if (index > field - 1 || index < 0 || general[index] == 0 || flyLeg == 0)
                {

                }
                else if (direction == "right")
                {
                    if (flyLeg >= field || index + flyLeg >= field)
                    {
                        general[index] = 0;
                    }
                    else if (general[index + flyLeg] == 1)
                    {
                        while (general[index] == 1)
                        {
                            try
                            {
                                flyLeg += temp;
                                general[index] = general[index + flyLeg];
                            }
                            catch (IndexOutOfRangeException)
                            {
                                checker = false;
                                general[index] = 0;
                                break;
                            }
                        }
                        if (checker)
                        {
                            general[index + flyLeg] = 1;
                        }
                    }
                    else
                    {
                        general[index + flyLeg] = 1;
                        general[index] = 0;
                    }
                }
                else
                {
                    if (field - flyLeg < 0 || index - flyLeg < 0)
                    {
                        general[index] = 0;
                    }
                    else if (general[index - flyLeg] == 1)
                    {
                        while (general[index] == 1)
                        {
                            try
                            {
                                flyLeg += temp;
                                general[index] = general[index - flyLeg];
                            }
                            catch (IndexOutOfRangeException)
                            {
                                checker = false;
                                general[index] = 0;
                                break;
                            }
                        }
                        if (checker)
                        {
                            general[index - flyLeg] = 1;
                        }
                    }
                    else
                    {
                        general[index - flyLeg] = 1;
                        general[index] = 0;
                    }
                }
                checker = true;
                commands = Console.ReadLine().Split();
            }
            for (int i = 0; i < field; i++)
            {
                Console.Write(general[i] + " ");
            }
        }
    }
}
