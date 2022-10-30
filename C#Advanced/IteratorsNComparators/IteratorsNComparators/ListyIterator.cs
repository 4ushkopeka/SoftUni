using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsNComparators
{
    internal class ListyIterator<T>:IEnumerable<T>
    {
        List<T> list = new List<T>();
        int index = 0;
        public ListyIterator(List<T> list)
        {
            this.list = list;
        }
        public bool Move()
        {
            if (index + 1 == list.Count) return false;
            index++;
            return true;
        }
        public bool HasNext()
        {
            if (index + 1 == list.Count) return false;
            return true;
        }
        public void Print()
        {
            if (list.Count == 0) throw new ArgumentException("Invalid Operation!");
            else Console.WriteLine(list[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list) yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
