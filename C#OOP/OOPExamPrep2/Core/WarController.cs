using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		List<Character> party = new List<Character>();
		List<Item> itemPool = new List<Item>();
		public WarController()
		{
		}

		public string JoinParty(string[] args)
		{
			if (args[0] != "Warrior" && args[0] != "Priest") throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, args[0]));
            else
            {
				Character d;
                if (args[0] == "Warrior") d = new Warrior(args[1]);
                else d = new Priest(args[1]);
				party.Add(d);
            }
			return string.Format(SuccessMessages.JoinParty, args[1]);
		}

		public string AddItemToPool(string[] args)
		{
			if (args[0] != "HealthPotion" && args[0] != "FirePotion") throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, args[0]));
			else
			{
				Item d;
				if (args[0] == "HealthPotion") d = new HealthPotion();
				else d = new FirePotion();
				itemPool.Add(d);
			}
			return string.Format(SuccessMessages.AddItemToPool, args[0]);
		}

		public string PickUpItem(string[] args)
		{
			Item temp;
			Character c = party.FirstOrDefault(x => x.Name == args[0]);
			if (c == null || c == default) throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, args[0]));
		    if (itemPool.Count == 0) throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			else 
			{ 
				temp = itemPool.Last();
				c.Bag.AddItem(itemPool.Last()); 
				itemPool.Remove(itemPool.Last()); 
			}
			return string.Format(SuccessMessages.PickUpItem,c.Name, temp.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			Character player = party.FirstOrDefault(x => x.Name == args[0]);
			if (player == null || player == default) throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, args[0]));
			Item item = player.Bag.GetItem(args[1]);
			player.UseItem(item);
			return string.Format(SuccessMessages.UsedItem, args[0], args[1]);
		}

		public string GetStats()
		{
			StringBuilder result = new StringBuilder();
			List<Character> placeholder = party.OrderBy(x => !x.IsAlive).ThenByDescending(x => x.Health).ToList();
			foreach (var item in placeholder) 
            {
				string life;
				if (item.IsAlive) life = "Alive";
				else life = "Dead";
				result.AppendLine($"{item.Name} - HP: {item.Health}/{item.BaseHealth}, AP: {item.Armor}/{item.BaseArmor}, Status: {life}");
			}
			return result.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			Character attacker = party.FirstOrDefault(x => x.Name == args[0]);
			Character receiver = party.FirstOrDefault(x => x.Name == args[1]);
			if (attacker == null || attacker == default) throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, args[0]));
			if (receiver == null || receiver == default) throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, args[1]));
			if (attacker.GetType().Name == "Priest") throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, args[0]));
			Warrior brute = attacker as Warrior;
			brute.Attack(receiver);
			string result =  $"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";
			if (receiver.Health == 0) return result + $"\n{receiver.Name} is dead!";
			else return result;
		}

		public string Heal(string[] args)
		{
			Character healer = party.FirstOrDefault(x => x.Name == args[0]);
			Character receiver = party.FirstOrDefault(x => x.Name == args[1]);
			if (healer == null || healer == default) throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, args[0]));
			if (receiver == null || receiver == default) throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, args[1]));
			if (healer.GetType().Name == "Warrior") throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, args[0]));
			Priest realHealer = healer as Priest;
			realHealer.Heal(receiver);
			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
