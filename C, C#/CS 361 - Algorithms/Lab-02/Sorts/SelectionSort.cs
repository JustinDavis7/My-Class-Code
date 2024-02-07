using System;

namespace Sorts
{
    public class SelectionSort : ISort
    {
        public long Sort(IComparable[] collection)
        {
            var comparisonCount = 0L;

            for (var i = 0; i < collection.Length - 1; ++i)
            {
                var min = i;
                for (var j = i + 1; j < collection.Length; ++j)
                {
                    comparisonCount++;
                    if (collection[j].CompareTo(collection[min]) < 0)
                        min = j;
                }
                Swap(ref collection[min], ref collection[i]);
            }
            return comparisonCount;
        }

        public void Swap(ref IComparable item1, ref IComparable item2)
        {
            var temp = item1;
            item1 = item2;
            item2 = temp;
        }
    }
}