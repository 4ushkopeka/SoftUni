using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : Collection<string>, IMyList
    {
        public int Used => 100;

        public string Removee()
        {
            string temp = this[0];
            this.RemoveAt(0);
            return temp;
        }

        public int Addd(string sth)
        {
            this.Insert(0, sth);
            return 0;
        }
    }
}
