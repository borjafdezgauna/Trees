using System;

namespace EDA
{
    public interface IList<T> : System.Collections.IEnumerable
    {
        int Count();

        T Get(int index);

        void Add(T value);

        T Remove(int index);

        void Clear();
    }
}
