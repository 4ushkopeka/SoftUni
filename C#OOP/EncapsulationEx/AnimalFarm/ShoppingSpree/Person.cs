using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private double money;
        private string name;
        private List<Product> bagOfProducts;
        public string Name 
        {
            get {return name; }
            private set 
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value)) name = value;
                else throw new ArgumentException("Name cannot be empty"); 
            } 
        }
        public double Money
        {
            get { return money; }
            private set
            {
                if (value>=0) money = value;
                else throw new ArgumentException("Money cannot be negative");
            }
        }
        public Person(string nam, double mon)
        {
            Name = nam;
            Money = mon;
            bagOfProducts = new List<Product>();
        }
        public void GetProduct(Product pro)
        {
            if (money-pro.Cost >= 0)
            {
                bagOfProducts.Add(pro);
                money-= pro.Cost;
                Console.WriteLine($"{Name} bought {pro.Name}");
            }
            else Console.WriteLine($"{Name} can't afford {pro.Name}");
        }
        public string Enumerate()
        {
            if (bagOfProducts.Count == 0) return "Nothing bought";
            else
            {
                List<string> list = new List<string>();
                foreach (Product pro in bagOfProducts) list.Add(pro.Name);
                return string.Join(", ", list);
            }
        }
    }
}
