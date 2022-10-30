using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        List<Animal> animals;
        private string name;
        private int capacity;
        public Zoo(string name, int cap)
        {
            animals = new List<Animal>();
            Name = name;
            capacity = cap;
        }
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public IReadOnlyCollection<Animal> Animals => animals.AsReadOnly();
        public string AddAnimal(Animal animal)
        {
            if (Capacity == Animals.Count) return $"The zoo is full.";
            else if (string.IsNullOrWhiteSpace(animal.Species)) return "Invalid animal species.";
            else if (animal.Diet.ToLower() != "carnivore" && animal.Diet.ToLower() != "herbivore") return "Invalid animal diet.";
            else
            {
                animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
        }
        public int RemoveAnimals(string species)
        {
            int removed = animals.Count(x => x.Species == species);
            animals = animals.Where(x => x.Species != species).ToList();
            return removed;
        }
        public List<Animal> GetAnimalsByDiet(string diet) => animals.Where((x) => x.Diet == diet).ToList();
        public Animal GetAnimalByWeight(double weight) => animals.FirstOrDefault(x => x.Weight == weight);
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = animals.Count(x => x.Length >= minimumLength && x.Length <= maximumLength);
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
