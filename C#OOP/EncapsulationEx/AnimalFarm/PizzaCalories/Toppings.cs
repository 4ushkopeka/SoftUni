using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Toppings
    {
        public readonly Dictionary<string, double> toppings = new Dictionary<string, double>() 
        {
            {"meat",1.2 },
            {"veggies",0.8 },
            {"cheese",1.1 },
            {"sauce",0.9 }
        };
        private double grams;
        private string topping;
        public Toppings(string topp, double gram)
        {
            Topping = topp;
            Grams = gram;
        }
        public double Calories => 2 * toppings[Topping.ToLower()] * Grams;
        public string Topping
        {
            get { return topping; }
            private set 
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce") throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                else topping = value;
            }
        }
        public double Grams
        {
            get { return grams; }
            private set 
            {
                if (value < 1 || value > 50) throw new ArgumentException($"{Topping} weight should be in the range [1..50].");
                else grams = value;
            }
        }
    }
}
