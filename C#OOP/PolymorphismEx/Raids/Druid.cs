using System;
using System.Collections.Generic;
using System.Text;

namespace Raids
{
    public class Druid : BaseHero
    {
        public Druid(string name, int pow) : base(name, pow)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"Druid - {Name} healed for {Power}");
        }
    }
}
