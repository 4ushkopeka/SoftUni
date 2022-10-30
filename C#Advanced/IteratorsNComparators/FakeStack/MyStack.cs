using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStack
{
    internal class MyStack<T>:IEnumerable<T>
    {
        Stack<T> stack = new Stack<T>();
        public void Push(T[] arr)
        {
            foreach (var item in arr) stack.Push(item);
        }
        public void Pop()
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("No elements");
                Environment.Exit(1);
            }
            stack.Pop();
        }
        public IEnumerator<T> GetEnumerator()
        {
            T[] arr = stack.ToArray();
            foreach (var item in arr) yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
