using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Box<T>
        where T : IComparable
    {
        
        Stack<T> list = new Stack<T>();
        List<T> items = new List<T>();  
        public override string ToString()
        {
            return $"{list.Peek().GetType()}: {list.Pop()}";
        }
        public void Add(T item)
        {
            items.Add(item);
        }
        public void Swap(int i1, int i2)
        {
            T temp = items[i1];
            items[i1] = items[i2];
            items[i2] = temp;
            items.Reverse();
            list = new Stack<T>(items);
        }
        public int Comapre(T comp)
        {
            int total = 0;
            foreach (T item in items)
            {
                if (item.CompareTo(comp) >0 ) total++;
            }
            return total;
        }
    }
}
