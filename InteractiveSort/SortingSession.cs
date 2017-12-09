using InteractiveSort.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveSort
{
    public enum Algorithm { BuiltinListSort };
    public class SortingSession<T>
    {
        public static SortingSession<T> CreateSession(Algorithm algorithm, Func<T, T, Task<int>> comparator, IEnumerable<T> items)
        {
            SortingAlgorithm<T> sortingAlgorithm = null;
            switch (algorithm)
            {
                case Algorithm.BuiltinListSort:
                    sortingAlgorithm = new BuiltinListSortAlgorithm<T>(comparator);
                    break;
            }
            return new SortingSession<T>(sortingAlgorithm, items);
        }

        private SortingAlgorithm<T> algorithm;
        public IEnumerable<T> Items { get; private set; }
        private SortingSession(SortingAlgorithm<T> algorithm, IEnumerable<T> items)
        {
            this.algorithm = algorithm;
            this.Items = items;
        }

        public async Task Sort()
        {
            Items = await algorithm.Sort(Items);
        }
    }
}
