using System;

namespace CollectionHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string command = Console.ReadLine();
                int numRem = int.Parse(Console.ReadLine());
                AddCollection coll = new AddCollection();
                AddRemoveCollection vs = new AddRemoveCollection();
                MyList listche = new MyList();
                var split = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] addd = new string[split.Length];
                string[] addRem = new string[split.Length];
                string[] MyAdd = new string[split.Length];
                string[] REMREM = new string[numRem];
                string[] MyRem = new string[numRem];
                for (int i = 0; i < split.Length; i++)
                {
                    addd[i] = coll.Addd(split[i]).ToString();
                }
                for (int i = 0; i < split.Length; i++)
                {
                   addRem[i] = vs.Addd(split[i]).ToString();
                }
                for (int i = 0; i < split.Length; i++)
                {
                    MyAdd[i] = listche.Addd(split[i]).ToString();
                }
                for (int i = 0; i < numRem; i++)
                {
                    REMREM[i] = vs.Removee();
                }
                for (int i = 0; i < numRem; i++)
                {
                    MyRem[i] = listche.Removee();
                }
                Console.WriteLine(string.Join(" ", addd));
                Console.WriteLine(string.Join(" ", addRem));
                Console.WriteLine(string.Join(" ", MyAdd));
                Console.WriteLine(string.Join(" ", REMREM));
                Console.WriteLine(string.Join(" ", MyRem));
            }
            catch (Exception)
            {
            }
        }
    }
}
