using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, age)
        {
            Gender = "male";
        }
        public Tomcat(string name, int age, string gender) : base(name, age, gender)
        {
            Gender = "male";
        }
        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
