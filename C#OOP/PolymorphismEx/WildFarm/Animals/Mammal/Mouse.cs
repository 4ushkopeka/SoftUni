using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weigh, string region) : base(name, weigh, region)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return $"Mouse [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        public override void TryEat(string type, double quan)
        {
            if (type == "Fruit" || type == "Vegetable")
            {
                FoodEaten = quan;
                Weight += quan * 0.10;
            }
            else Console.WriteLine($"Mouse does not eat {type}!");
        }
    }
}
