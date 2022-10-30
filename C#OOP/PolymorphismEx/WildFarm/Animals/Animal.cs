using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double FoodEaten { get; set; }
        public Animal(string name, double weigh)
        {
            Name = name;
            Weight = weigh;
        }
        public abstract void ProduceSound();
        public abstract override string ToString();
        public abstract void TryEat(string type, double quan);
    }
}
