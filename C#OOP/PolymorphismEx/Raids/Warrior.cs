using System;
using System.Collections.Generic;
using System.Text;

namespace Raids
{
    public class Warrior : BaseHero
    {
        public Warrior(string name, int pow) : base(name, pow)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"Warrior - {Name} hit for {Power} damage");

        }
    }
}
