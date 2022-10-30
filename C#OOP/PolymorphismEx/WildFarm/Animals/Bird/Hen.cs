using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weigh, double wings) : base(name, weigh, wings)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }

        public override string ToString()
        {
            return $"Hen [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }

        public override void TryEat(string type, double quan)
        {
            Weight += quan * 0.35;
            FoodEaten = quan;
        }
    }
}
