using System;
using System.Collections.Generic;
using System.Linq;

namespace CompVirus
{
    class Program
    {
        static void Merge(int start, int end, List<string> def)
        {
            if (start < 0)
            {
                start = 0;
            }
            else if (start > def.Count-1)
            {
                return;
            }
            if (end<0)
            {
                return;
            }
            else if (end>def.Count-1)
            {
                end = def.Count - 1;
            }
            for (int i = start; i < end; i++)
            {
                def[start] += def[i+1];
            }
            for (int i = start; i < end; i++)
            {
                try
                {
                    if (i==start)
                    {
                        def.RemoveAt(i + 1);
                    }
                    else
                    {
                        def.RemoveAt(i);
                    }
                }
                catch (Exception)
                {
                    def.RemoveAt(def.Count - 1);
                }
            }
        }
        static void Divide(int index, int part, List<string> def)
        {
            string temp = def[index];
            List<char> temporary = new List<char>(temp.Length);
            for (int i = 0; i < temp.Length; i++)
            {
                temporary.Add(temp[i]);
            }
            if (temp.Length%part==0)
            {
                int leg = temp.Length / part;
                def[index] = "";
                int count = 0;
                for (int i = 0; i < part; i++)
                {
                    bool check = true;
                    string tempy = "";
                    for (int j = 0; j < leg; j++)
                    {
                        
                        if (i==0)
                        {
                            def[index] += temporary[count];
                            count++;
                            check = false;
                        }
                        else
                        {
                            tempy += temporary[count];
                            count++;
                        }
                    }
                    if (check) def.Insert(index + i, tempy);
                }
            }
            else
            {
                int leg = temp.Length / part;
                int pr = temp.Length % part;
                def[index] = "";
                int count = 0;
                for (int i = 0; i < part; i++)
                {
                    bool check = true;
                    string tempy = "";
                    if (i+1 == part)
                    {
                        for (int k = 0; k < leg+pr; k++)
                        {
                            tempy += temporary[count];
                            count++;
                        }
                        def.Insert(index + i, tempy);
                    }
                    else
                    {
                        for (int j = 0; j < leg; j++)
                        {

                            if (i == 0)
                            {
                                def[index] += temporary[count];
                                count++;
                                check = false;
                            }
                            else
                            {
                                tempy += temporary[count];
                                count++;
                            }
                        }
                        if (check) def.Insert(index + i, tempy);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            List<string> sth = Console.ReadLine().Split().ToList();
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "3:1")
            {
                if (commands[0] == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    Merge(startIndex, endIndex, sth);
                }
                else
                {
                    int index = int.Parse(commands[1]);
                    int partitions = int.Parse(commands[2]);
                    Divide(index, partitions, sth);
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", sth));
        }
    }
}
