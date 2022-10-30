using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froggy
{
    internal class Lake : IEnumerable<int>
    {
        int[] stones;
        public Lake(int[] st)
        {
            stones = new int[st.Length];
            stones = st;
        }
        public IEnumerator<int> GetEnumerator()
        {
            List<int> odds = new List<int>();
            List<int> evens = new List<int>();
            for (int i = 0; i < stones.Length; i++)
            {
                if (i % 2 == 0) odds.Add(stones[i]);
                else evens.Add(stones[i]);
            }
            evens.Reverse();
            foreach (var item in odds) yield return item;
            foreach (var item in evens) yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 
    }
}
