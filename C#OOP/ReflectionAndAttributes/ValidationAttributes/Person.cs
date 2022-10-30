using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    internal class Person
    {
        private int age;
        private string fullName;
        public Person(string name, int age)
        {
            FullName = name;
            Age = age;
        }
        [MyRequired]
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        [MyRange(12, 90)]
        public int Age
        {
            get { return age; }
            set 
            {
                age = value; 
            }
        }

    }
}
