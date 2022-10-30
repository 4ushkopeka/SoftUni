using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public double Millilters { get; set; }
        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            Millilters = milliliters;
        }
    }
}
