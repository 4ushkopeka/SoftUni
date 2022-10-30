using System;
using System.Collections.Generic;
using System.Text;

namespace Raids
{
    public class Paladin : BaseHero
    {
        public Paladin(string name, int pow) : base(name, pow)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"Paladin - {Name} healed for {Power}");
        }
    }
}
