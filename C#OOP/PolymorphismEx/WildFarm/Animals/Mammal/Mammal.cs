using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal:Animal
    {
        protected Mammal(string name, double weigh, string region) : base(name, weigh)
        {
            LivingRegion = region;
        }

        public string LivingRegion { get; set; }
    }
}
