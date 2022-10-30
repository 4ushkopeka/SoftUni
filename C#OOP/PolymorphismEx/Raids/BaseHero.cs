using System;
using System.Collections.Generic;
using System.Text;

namespace Raids
{
    public abstract class BaseHero
    {
        public BaseHero(string name, int pow)
        {
            Name = name;
            Power = pow;
        }
        public string Name { get; private set; }
        public int Power { get; private set; }
        public abstract void CastAbility();
    }
}
