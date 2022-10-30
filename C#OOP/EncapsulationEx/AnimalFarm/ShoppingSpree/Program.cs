using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, Person> peeps = new Dictionary<string, Person>();    
                Dictionary<string, Product> prods = new Dictionary<string, Product>();    
                char[] sep = new char[] {';', '=' };
                string[] namesNMoney = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] productsNCost = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 0; i < namesNMoney.Length; i+=2)
                {
                    Person pers = new Person(namesNMoney[i], double.Parse(namesNMoney[i+1]));
                    peeps.Add(pers.Name,pers);
                }
                for (int i = 0; i < productsNCost.Length; i += 2)
                {
                    Product pers = new Product(productsNCost[i], double.Parse(productsNCost[i + 1]));
                    prods.Add(pers.Name, pers);
                }
                string coms = Console.ReadLine();
                while (coms != "END")
                {
                    var splitted = coms.Split();
                    peeps[splitted[0]].GetProduct(prods[splitted[1]]);
                    coms = Console.ReadLine();
                }
                foreach (var item in peeps) Console.WriteLine($"{item.Key} - {item.Value.Enumerate()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
