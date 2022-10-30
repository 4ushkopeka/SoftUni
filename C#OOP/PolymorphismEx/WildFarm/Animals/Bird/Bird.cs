using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird:Animal
    {
        protected Bird(string name, double weigh, double wings) : base(name, weigh)
        {
            WingSize = wings;
        }

        public double WingSize { get; set; }
    }
}
