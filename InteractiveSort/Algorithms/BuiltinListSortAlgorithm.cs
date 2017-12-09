using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InteractiveSort.Algorithms
{
    class BuiltinListSortAlgorithm<T> : SortingAlgorithm<T>
    {
        internal BuiltinListSortAlgorithm(Func<T, T, Task<int>> comparator) : base(comparator)
        {
        }

        protected int SyncCompare(T arg1, T arg2)
        {
            var compareTask = Compare(arg1, arg2);
            compareTask.Wait();
            return compareTask.Result;
        }

        public override Task<IEnumerable<T>> Sort(IEnumerable<T> items)
        {
            var task = new Task<IEnumerable<T>>(() =>
            {
                var list = new List<T>(items);
                list.Sort(SyncCompare);
                return list;
            });
            task.Start();
            return task;
        }
    }
}
