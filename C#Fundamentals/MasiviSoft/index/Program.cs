using System;

namespace index
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char hektor = input[i];
                switch (hektor)
                {
                    case 'a': Console.WriteLine($"a -> 0");break;
                    case 'b': Console.WriteLine($"b -> 1");break;
                    case 'c': Console.WriteLine($"c -> 2");break;
                    case 'd': Console.WriteLine($"d -> 3");break;
                    case 'e': Console.WriteLine($"e -> 4");break;
                    case 'f': Console.WriteLine($"f -> 5");break;
                    case 'g': Console.WriteLine($"g -> 6");break;
                    case 'h': Console.WriteLine($"h -> 7");break;
                    case 'i': Console.WriteLine($"i -> 8");break;
                    case 'j': Console.WriteLine($"j -> 9");break;
                    case 'k': Console.WriteLine($"k -> 10");break;
                    case 'l': Console.WriteLine($"l -> 11");break;
                    case 'm': Console.WriteLine($"m -> 12");break;
                    case 'n': Console.WriteLine($"n -> 13");break;
                    case 'o': Console.WriteLine($"o -> 14");break;
                    case 'p': Console.WriteLine($"p -> 15");break;
                    case 'q': Console.WriteLine($"q -> 16");break;
                    case 'r': Console.WriteLine($"r -> 17");break;
                    case 's': Console.WriteLine($"s -> 18");break;
                    case 't': Console.WriteLine($"t -> 19");break;
                    case 'u': Console.WriteLine($"u -> 20");break;
                    case 'v': Console.WriteLine($"v -> 21");break;
                    case 'w': Console.WriteLine($"w -> 22");break;
                    case 'x': Console.WriteLine($"x -> 23");break;
                    case 'y': Console.WriteLine($"y -> 24");break;
                    case 'z': Console.WriteLine($"z -> 25");break;
                }
            }
        }
    }
}
