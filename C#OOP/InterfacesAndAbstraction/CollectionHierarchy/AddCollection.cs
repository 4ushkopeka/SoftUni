using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : Collection<string>, IAddCollection
    {
        public int Addd(string item)
        {
            this.Add(item);
            return this.IndexOf(item);
        }
    }
}
