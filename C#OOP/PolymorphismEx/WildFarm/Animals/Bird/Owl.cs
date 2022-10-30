using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    internal class Owl : Bird
    {
        public Owl(string name, double weigh, double wings) : base(name, weigh, wings)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override string ToString()
        {
            return $"Owl [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }

        public override void TryEat(string type, double quan)
        {
            if (type == "Meat")
            {
                FoodEaten = quan;
                Weight += quan*0.25;
            }
            else Console.WriteLine($"Owl does not eat {type}!");
        }
    }
}
