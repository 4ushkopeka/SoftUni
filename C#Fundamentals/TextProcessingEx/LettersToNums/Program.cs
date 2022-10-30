using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace LettersToNums
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> lowerCase = new Dictionary<char, int>() 
            {
                {'a', 1 },           
                {'b', 2 },                
                {'c', 3 },                
                {'d', 4 },                
                {'e', 5 },                                  
                {'f', 6 },                                  
                {'g', 7 },                                  
                {'h', 8 },                                  
                {'i', 9 },                                  
                {'j', 10 },               
                {'k', 11 },               
                {'l', 12 },               
                {'m', 13 },               
                {'n', 14 },               
                {'o', 15 },               
                {'p', 16 },               
                {'q', 17 },               
                {'r', 18 },               
                {'s', 19 },               
                {'t', 20 },               
                {'u', 21 },               
                {'v', 22 },               
                {'w', 23 },               
                {'x', 24 },               
                {'y', 25 },               
                {'z', 26 },               
            };
            Dictionary<char, int> upperCase = new Dictionary<char, int>()
            {
                {'A', 1 },
                {'B', 2 },
                {'C', 3 },
                {'D', 4 },
                {'E', 5 },
                {'F', 6 },
                {'G', 7 },
                {'H', 8 },
                {'I', 9 },
                {'J', 10 },
                {'K', 11 },
                {'L', 12 },
                {'M', 13 },
                {'N', 14 },
                {'O', 15 },
                {'P', 16 },
                {'Q', 17 },
                {'R', 18 },
                {'S', 19 },
                {'T', 20 },
                {'U', 21 },
                {'V', 22 },
                {'W', 23 },
                {'X', 24 },
                {'Y', 25 },
                {'Z', 26 },
            };
            string input = Console.ReadLine();
            string[] realInp = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double totalSum = 0;
            for (int i = 0; i < realInp.Length; i++)
            {
                double sum = 0;
                string word = realInp[i];
                char firstL = word[0];
                double number = double.Parse(word.Substring(1,word.Length-2));
                char secondL = word[word.Length - 1];
                if (lowerCase.ContainsKey(firstL)) sum += number * lowerCase[firstL];
                else if(upperCase.ContainsKey(firstL)) sum += number / upperCase[firstL];
                if (lowerCase.ContainsKey(secondL)) sum += lowerCase[secondL];
                else if (upperCase.ContainsKey(secondL)) sum -= upperCase[secondL];
                totalSum += sum;
            }
            Console.WriteLine(totalSum.ToString("F2"));
        }
    }
}
