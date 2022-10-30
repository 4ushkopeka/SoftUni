using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weigh, string region, string breed) : base(name, weigh, region, breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override string ToString()
        {
            return $"Tiger [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        public override void TryEat(string type, double quan)
        {
            if (type == "Meat")
            {
                FoodEaten = quan;
                Weight += quan;
            }
            else Console.WriteLine($"Tiger does not eat {type}!");
        }
    }
}
