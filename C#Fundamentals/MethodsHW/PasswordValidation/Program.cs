using System;
using System.Text.RegularExpressions;

namespace PasswordValidation
{
    class Program
    {
        static string IsValid(string input)
        {
            string final = "";
            bool correct = false;
            if (Length(input, correct) == false)
            {
                final += "Password must be between 6 and 10 characters\n";
            }
            if (CharCheck(input, correct) == false)
            {
                final += "Password must consist only of letters and digits\n";
            }
            if (NumCheck(input, correct) == false)
            {
                final += "Password must have at least 2 digits\n";
            }
            if (final == "")
            {
                final = "Password is valid";
                return final;
            }
            else
            {
                return final;
            }
        }
        static bool Length(string inpt, bool output)
        {
            if (inpt.Length < 6 || inpt.Length > 10)
            {
                return output;
            }
            else
            {
                output = true;
                return output;
            }
        }
        static bool CharCheck(string inpt, bool output)
        {
            var regexItem = new Regex("^[a-zA-Z0-9]*$");
            if (regexItem.IsMatch(inpt))
            {
                output = true;
                return output;
            }
            else
            {
                return output;
            }
        }
        static bool NumCheck(string inpt, bool output)
        {
            int counter = 0;
            int num;
            for (int i = 0; i < inpt.Length; i++)
            {
                num = inpt[i];
                if (num >= 48 && num <=57) counter++;
            }
            if (counter>=2)
            {
                output = true;
                return output;
            }
            else
            {
                return output;
            }
        }
        static void Main()
        {
            string password = Console.ReadLine();
            Console.WriteLine(IsValid(password));
        }
    }
}
