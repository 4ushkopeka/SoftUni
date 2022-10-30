using System;
using System.Collections.Generic;

namespace SongQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] songs = Console.ReadLine().Split(", ");
            Queue<string> songQ = new Queue<string>(songs);
            while (songQ.Count != 0)
            {
                string commands = Console.ReadLine();
                if (commands == "Play")
                {
                    songQ.Dequeue();
                }
                else if (commands == "Show")
                {
                    string [] vs = songQ.ToArray();
                    Console.WriteLine(string.Join(", ", vs)) ;
                }
                else
                {
                    var name = commands.Substring(4);
                    if (songQ.Contains(name))
                    {
                        Console.WriteLine($"{name} is already contained!");
                        continue;
                    }
                    else
                    {
                        songQ.Enqueue(name);
                    }
                    
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
