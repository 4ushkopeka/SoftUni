using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private double cost;
        public Product(string nam, double cos)
        {
            Name = nam;
            Cost = cos;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value)) name = value;
                else throw new ArgumentException("Name cannot be empty");
            }
        }
        public double Cost
        {
            get { return cost; }
            private set
            {
                if (value >= 0) cost = value;
                else throw new ArgumentException("Money cannot be negative");
            }
        }
    }
}
