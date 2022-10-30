using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Toppings> toppings = new List<Toppings>();
        private Dough dough;
        public Pizza(string name, Dough d)
        {
            Name = name;
            dough = d;
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value) && value.Length>0 && value.Length<16) name = value;
                else throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
        }
        public int ToppingsCount { get { return toppings.Count; }}
        public double Calories => dough.Calories + CaloriesSum();
        public void AddTopping(Toppings topping)
        {
            if (toppings.Count == 10) throw new ArgumentException($"Number of toppings should be in range [0..10].");
            else toppings.Add(topping); 
        }
        private double CaloriesSum()
        {
            double sum = 0;
            foreach (Toppings topping in toppings) sum += topping.Calories;
            return sum;
        }
    }
}
