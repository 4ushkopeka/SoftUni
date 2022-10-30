using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weigh, string region) : base(name, weigh, region)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return $"Dog [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        public override void TryEat(string type, double quan)
        {
            if (type == "Meat")
            {
                FoodEaten = quan;
                Weight += quan * 0.40;
            }
            else Console.WriteLine($"Dog does not eat {type}!");
        }
    }
}
