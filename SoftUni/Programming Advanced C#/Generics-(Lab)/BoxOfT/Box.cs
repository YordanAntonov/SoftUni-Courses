using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box <T>
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T element)
        {
            list.Insert(0, element);
        }

        public T Remove()
        {
            T elementToRemove = list[0];
            list.RemoveAt(0);
            return elementToRemove;
        }

        public int Count { get { return list.Count; } }
    }
}
