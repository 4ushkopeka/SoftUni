using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizza = Console.ReadLine();
                string dough = Console.ReadLine();
                Pizza piz = new Pizza(pizza.Split()[1], new Dough(dough.Split()[1], dough.Split()[2], double.Parse(dough.Split()[3])));
                string toppings = Console.ReadLine();
                while (toppings != "END")
                {
                    piz.AddTopping(new Toppings(toppings.Split()[1], double.Parse(toppings.Split()[2])));
                    toppings = Console.ReadLine();
                }
                Console.WriteLine($"{piz.Name} - {piz.Calories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
