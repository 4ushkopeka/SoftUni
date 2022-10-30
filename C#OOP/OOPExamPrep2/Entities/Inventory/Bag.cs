using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        
        List<Item> items = new List<Item>();
        public Bag(int cap)
        {
            Capacity = cap;
        }
        public int Capacity { get; set; } = 100;

        public int Load => Items.Select(x => x.Weight).Sum();

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity) throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            else items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item bag;
            Item bag1;
            if (items.Count == 0) throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            else
            {
                bag = items.FirstOrDefault(x => x.GetType().Name == name);
                bag1 = bag;
                if (bag != null && bag != default) return bag1;  
                else throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            
        }
    }
}
