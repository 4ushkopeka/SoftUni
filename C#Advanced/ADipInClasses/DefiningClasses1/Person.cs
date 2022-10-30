using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Person
    {
        string name;
        int age;
        static List<Person> list = new List<Person>();
        public Person()
        {
            Name = "No Name";
            Age = 1;
        }
        public Person(int age):this()
        {
            Age = age;
        }
        public Person(string name, int age) : this(age)
        {
            Name = name;
        }
        public int Age { get { return age; } set { age = value; } }
        public string Name { get { return name; } set { name = value; } }
        public void AddMember(Person member)
        {
            list.Add(member);
        }
        public static void GetOldestPerson()
        {
            list = list.OrderBy(x => x.Name).ToList();
            
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].age > 30)
                {
                    Console.WriteLine($"{list[i].name} - {list[i].age}");
                }
            }
        }
    }
}
