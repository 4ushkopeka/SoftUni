using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : Collection<string>, IAddRemoveCollection
    {
        public string Removee()
        {
            string tem = this[this.Count - 1];
            this.RemoveAt(this.Count - 1);
            return tem;
        }

        public int Addd(string sth)
        {
            this.Insert(0, sth);
            return 0;
        }
    }
}
