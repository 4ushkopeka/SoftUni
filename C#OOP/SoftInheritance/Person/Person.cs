using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        public string name;
        public int age;
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
