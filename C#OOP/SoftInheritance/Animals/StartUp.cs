using System.Collections.Generic;
using System;
namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command = Console.ReadLine();
            while (command != "Beast!")
            {
                string data = Console.ReadLine();
                var check = data.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (check.Length != 3 && check[1] != "Kitten" && check[1] != "Tomcat") { Console.WriteLine("Invalid input!"); }
                else if (check[1] != "Kitten" || check[1] != "Tomcat")
                {
                    if (check.Length != 3 && check.Length != 2) Console.WriteLine("Invalid input!");
                }
                else if (int.Parse(check[1])<0) { Console.WriteLine("Invalid input!"); }
                else
                {
                    switch (command)
                    {
                        case "Dog": Dog dog = new Dog(data.Split()[0], int.Parse(data.Split()[1]), data.Split()[2]); animals.Add(dog); break;
                        case "Cat": Cat dog1 = new Cat(data.Split()[0], int.Parse(data.Split()[1]), data.Split()[2]); animals.Add(dog1); break;
                        case "Frog": Frog dog2 = new Frog(data.Split()[0], int.Parse(data.Split()[1]), data.Split()[2]); animals.Add(dog2); break;
                        case "Tomcat": Tomcat dog3 = new Tomcat(data.Split()[0], int.Parse(data.Split()[1])); animals.Add(dog3); break;
                        case "Kitten": Kitten dog4 = new Kitten(data.Split()[0], int.Parse(data.Split()[1])); animals.Add(dog4); break;
                        default:
                            break;
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var item in animals)
            {
                Console.WriteLine($"{item.GetType().ToString().Split(".")[1]}");
                Console.WriteLine($"{item.Name} {item.Age} {item.Gender}");
                Console.WriteLine($"{item.ProduceSound()}");
            }
        }
    }
}
