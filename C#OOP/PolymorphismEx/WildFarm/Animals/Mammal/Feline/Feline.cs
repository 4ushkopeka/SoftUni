using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Feline:Mammal
    {
        protected Feline(string name, double weigh, string region, string breed) : base(name, weigh, region)
        {
            Breed = breed;
        }

        public string Breed { get; set; }
    }
}
