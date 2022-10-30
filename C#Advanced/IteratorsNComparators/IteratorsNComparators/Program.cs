using System;
using System.Linq;

namespace IteratorsNComparators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            ListyIterator<string> listy = null;
            while (command!= "END")
            {
                try
                {
                    var splitted = command.Split();
                    if (splitted[0] == "Create") listy = new ListyIterator<string>(command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList());
                    else if (splitted[0] == "Print") listy.Print();
                    else if (splitted[0] == "Move") Console.WriteLine(listy.Move());
                    else if (splitted[0] == "PrintAll") Console.WriteLine(String.Join(" ", listy));
                    else if (splitted[0] == "HasNext") Console.WriteLine(listy.HasNext());
                }
                catch (Exception wx)
                {
                    Console.WriteLine(wx.Message);
                }
                finally { command = Console.ReadLine(); }
            }
        }
    }
}
