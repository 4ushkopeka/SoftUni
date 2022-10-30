using System;
using System.Numerics;
using System.Text;

namespace NewBombers
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            StringBuilder res = new StringBuilder();
            res.Append(s);
            int bomb = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '>')
                {
                    string ef = s[i + 1].ToString();
                    bomb += int.Parse(ef);
                }
            }
            int firstIndex = s.IndexOf(">");
            int strength = 0;
            int t = 0;
            var data = s.Split(">");
            for (int i = firstIndex; bomb>0; i++)
            {
                try
                {
                    if (res[i] == '>')
                    {
                        string ef = res[i + 1].ToString();
                        strength = int.Parse(ef);
                        t++;
                        continue;
                    }
                    else if(strength!=0)
                    {
                        if (strength == 1)
                        {
                            res.Remove(i, strength);
                            bomb -= strength;
                            strength = 0;
                            i--;
                        }
                        else
                        {
                            StringBuilder saviour = new StringBuilder();
                            saviour.Append(data[t]);
                            if (saviour.Length>strength)
                            {
                                res.Remove(i, strength);
                                bomb -= strength;
                                strength = 0;
                            }
                            else
                            {
                                t++;
                                res.Remove(i, saviour.Length);
                                strength -= saviour.Length;
                                bomb -= saviour.Length;
                                string ef = data[t];
                                string f = ef[0].ToString();
                                strength += int.Parse(f);
                            }
                        }          
                    }
                    else continue;
                }
                catch (Exception)
                {
                    break;
                }
            }
            Console.WriteLine(res);
        }
    }
}
