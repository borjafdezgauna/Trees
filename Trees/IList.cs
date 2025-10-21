using System;
using System.Collections;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public interface IList<T> : IEnumerable
    {
        int Count();

        T Get(int index);

        void Add(T value);

        T Remove(int index);

        void Clear();
    }
}
