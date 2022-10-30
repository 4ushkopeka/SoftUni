using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    internal class Person:IComparable<Person>
    {
        private int age;
        private string name;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public override int GetHashCode()
        {
            return this.name.GetHashCode() + this.age.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Person p = obj as Person;
            return this.name == p.Name && this.age == p.Age;
        }
        public int CompareTo(Person other)
        {
            int result = this.name.CompareTo(other.Name);
            if (result == 0) result = this.age.CompareTo(other.Age);
            return result;
        }
    }
}
