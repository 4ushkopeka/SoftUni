using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTech;
        private double grams;
        public readonly Dictionary<string, double> dough = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 },
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };
        public Dough(string flour, string tech, double gram)
        {
            FlourType = flour;
            BakingTech = tech;
            Grams = gram;
        }
        public double Grams
        {
            get { return grams; }
            private set 
            {
                if (value < 1 || value > 200) throw new ArgumentException($"Dough weight should be in the range [1..200].");
                else grams = value;
            }
        }

        public double Calories => 2*Grams*dough[FlourType.ToLower()]*dough[BakingTech.ToLower()];
        public string BakingTech
        {
            get { return bakingTech; }
            private set 
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade") throw new ArgumentException($"Invalid type of dough.");
                else bakingTech = value;
            }
        }

        public string FlourType
        {
            get { return flourType; }
            private set 
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain") throw new ArgumentException($"Invalid type of dough.");
                else flourType = value; 
            }
        }
    }
}
