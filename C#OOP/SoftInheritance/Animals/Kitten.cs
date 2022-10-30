using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Kitten : Cat
    {
        public Kitten(string name, int age) : base(name, age)
        {
            Gender = "female";
        }
        public Kitten(string name, int age, string gender) : base(name, age, gender)
        {
            Gender = "female";
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
