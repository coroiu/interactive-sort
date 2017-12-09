using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveSort.Algorithms
{
    abstract class SortingAlgorithm<T>
    {
        private Func<T, T, Task<int>> comparator;
        protected SortingAlgorithm(Func<T, T, Task<int>> comparator)
        {
            this.comparator = comparator;
        }

        protected Task<int> Compare(T arg1, T arg2)
        {
            return comparator(arg1, arg2);
        }

        abstract public Task<IEnumerable<T>> Sort(IEnumerable<T> list);
    }
}
