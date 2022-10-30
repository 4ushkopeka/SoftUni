using System;
using System.Collections.Generic;
using System.Linq;

namespace Raids
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            for (int i = 0; heroes.Count < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                if (type == "Druid") heroes.Add(new Druid(name, 80));
                else if (type == "Paladin") heroes.Add(new Paladin(name, 100));
                else if (type == "Warrior") heroes.Add(new Warrior(name, 100));
                else if (type == "Rogue") heroes.Add(new Rogue(name, 80));
                else Console.WriteLine("Invalid hero!");
            }
            int bossPower = int.Parse(Console.ReadLine());
            int sum = 0;
            foreach (var item in heroes) { item.CastAbility(); sum += item.Power; }
            if (sum >= bossPower) Console.WriteLine("Victory!");
            else Console.WriteLine("Defeat...");
        }
    }
}
