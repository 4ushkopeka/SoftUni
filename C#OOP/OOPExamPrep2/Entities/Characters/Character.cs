using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;
        
        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            BaseArmor = armor;
            Health = BaseHealth;
            Armor = BaseArmor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }
        public Bag Bag { get; set; }
        public double AbilityPoints { get; set; }
        public double Armor
        {
            get { return armor; } // unsure
            set
            {
                if (value < 0) armor = 0;
                else armor = value;
            }
        }

        public double BaseHealth { get; private set; }
        public double BaseArmor { get; private set; }
        public double Health // unsure 
        {
            get { return health; }
            set
            {
                if (value <= 0) { health = 0; IsAlive = false; }
                else if (value > BaseHealth) health = BaseHealth;
                else health = value;
            } 
        }
        public string Name
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                name = value; 
            }
        }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hp) //Perhaps ready
        {
            if (!IsAlive) return;
            if (Armor >= hp) Armor -= hp;
            else
            {
                double temp = Armor;
                Armor-=hp;
                hp -= temp;
                if (Health <= hp) { IsAlive = false; Health = 0; }
                else health -= hp;
            }
        }
        public void UseItem(Item item) 
        {
            this.EnsureAlive();
            this.Bag.GetItem(item.GetType().Name);
            item.AffectCharacter(this);
        }
        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}