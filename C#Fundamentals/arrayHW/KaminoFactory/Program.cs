using System;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array.Copy(DNA, final, leg);
            int leg = int.Parse(Console.ReadLine());
            int[] DNA = new int[leg];
            int[] final = new int[leg];
            int realcount = 1;
            int sum1 = 0;
            int i2 = 0;
            int index = 0;
            int row = 1;
            string[] dna = Console.ReadLine().Split("!");
            bool grump = false;
            bool format = false;
            int dl = 0;
            while (dna[0] != "Clone them")
            {
                if (dna.Length == leg) grump = false;
                i2++;
                int sum = 0;
                for (int i = 0; i < leg; i++) //parsing the info
                {
                    try
                    {
                        DNA[i] = int.Parse(dna[i]);
                        sum += DNA[i];
                    }
                    catch (FormatException)
                    {
                        format = true;
                        dna = Console.ReadLine().Split("!");
                        break;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        grump = true;
                        dl = dna.Length;
                        break;
                    }
                }
                if (format)
                {
                    format = false;
                    continue;
                }
                for (int i = 0; i < leg; i++) //checking for subsequences
                {
                    if (DNA[i] == 0) continue; //zeros are excluded
                    int counter = 1;
                    for (int j = i + 1; j < leg; j++)
                    {
                        if (DNA[i] == DNA[j]) //getting continuity
                        {
                            counter++;
                            continue;
                        }
                        else break;
                    }
                    if (counter > realcount) //checkings for better DNA
                    {
                        realcount = counter;
                        index = i;
                        Array.Copy(DNA, final, leg);
                        sum1 = sum;
                        row = i2;
                    }
                    else if (counter == realcount && index > i)
                    {
                        Array.Copy(DNA, final, leg);
                        sum1 = sum;
                        index = i;
                        row = i2;
                    }
                    else if (counter == realcount && sum1 < sum)
                    {
                        Array.Copy(DNA, final, leg);
                        sum1 = sum;
                        index = i;
                        row = i2;
                    }
                }
                dna = Console.ReadLine().Split("!"); //repeats
            }
            if (grump)
            {
                return;
            }
            else
            {
                Console.WriteLine($"Best DNA sample {row} with sum: {sum1}."); //result
                for (int i = 0; i < leg; i++)
                    Console.Write(final[i] + " ");
            }
        }
    }
}