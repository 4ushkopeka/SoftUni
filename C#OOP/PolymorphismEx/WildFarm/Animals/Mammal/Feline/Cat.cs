using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weigh, string region, string breed) : base(name, weigh, region, breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }

        public override string ToString()
        {
            return $"Cat [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        public override void TryEat(string type, double quan)
        {
            if (type == "Meat" || type == "Vegetable")
            {
                FoodEaten = quan;
                Weight += quan * 0.30;
            }
            else Console.WriteLine($"Cat does not eat {type}!");
        }
    }
}
