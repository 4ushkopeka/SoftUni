using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string com = Console.ReadLine();
            List <Animal> animals = new List <Animal>();
            List<List<string>> eats = new List <List<string>>();
            while (com != "End")
            {
                string eaa = Console.ReadLine();
                eats.Add (new List<string>() {eaa.Split()[0], eaa.Split()[1] });
                var split = com.Split(' ');
                if (split[0] == "Cat") animals.Add(new Cat(split[1], double.Parse(split[2]), split[3], split[4]));
                else if (split[0] == "Tiger") animals.Add(new Tiger(split[1], double.Parse(split[2]), split[3], split[4]));
                else if (split[0] == "Mouse") animals.Add(new Mouse(split[1], double.Parse(split[2]), split[3]));
                else if (split[0] == "Dog") animals.Add(new Dog(split[1], double.Parse(split[2]), split[3]));
                else if (split[0] == "Hen") animals.Add(new Hen(split[1], double.Parse(split[2]), double.Parse(split[3])));
                else if (split[0] == "Owl") animals.Add(new Owl(split[1], double.Parse(split[2]), double.Parse(split[3])));
                com = Console.ReadLine();
            }
            for (int i = 0; i < animals.Count; i++)
            {
                animals[i].ProduceSound();
                animals[i].TryEat(eats[i][0], double.Parse(eats[i][1]));
            }
            foreach (var item in animals) Console.WriteLine(item.ToString());
        }
    }
}
