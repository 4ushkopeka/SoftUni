namespace Zoo
{
    public class Animal
    {
        private string species;
        private string diet;
        private double weight;
        private double length;
        public Animal(string spes, string diet, double weigh, double leg)
        {
            Species = spes;
            Diet = diet;
            Weight = weigh;
            Length = leg;
        }
        public double Length
        {
            get { return length; }
            private set { length = value; }
        }

        public double Weight
        {
            get { return weight; }
            private set { weight = value; }
        }

        public string Diet
        {
            get { return diet; }
            private set { diet = value; }
        }

        public string Species
        {
            get { return species; }
            private set { species = value; }
        }
        public override string ToString()
        {
            return $"The {species} is a {diet} and weighs {weight} kg.";
        }
    }
}
