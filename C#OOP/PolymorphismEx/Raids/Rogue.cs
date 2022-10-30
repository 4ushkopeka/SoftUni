using System;
using System.Collections.Generic;
using System.Text;

namespace Raids
{
    public class Rogue : BaseHero
    {
        public Rogue(string name, int pow) : base(name, pow)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"Rogue - {Name} hit for {Power} damage");
        }
    }
}
