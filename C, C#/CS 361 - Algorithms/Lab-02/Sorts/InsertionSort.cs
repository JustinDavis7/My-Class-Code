using System;

namespace Sorts
{
    public class InsertionSort : ISort
    {
        public long Sort(IComparable[] collection)
        {
            var comparisonCount = 0L;

            for (var p = 1; p < collection.Length; ++p)
            {
                var temp = collection[p];
                var j = p;
                while (j > 0 && ++comparisonCount >= 0 && temp.CompareTo(collection[j - 1]) < 0)
                {
                    collection[j] = collection[j - 1];
                    --j;   
                }
                collection[j] = temp;
            }
            return comparisonCount;
        }

        public long Sort(IComparable[] collection, int low, int high)
        {
            var comparisonCount = 0L;
            for (var p = low; p <= high; ++p)
            {
                var temp = collection[p];
                var j = p;
                while (j > low && ++comparisonCount >= 0 && temp.CompareTo(collection[j - 1]) < 0)
                {
                    collection[j] = collection[j - 1];
                    --j;
                }
                collection[j] = temp;
            }
            return comparisonCount;
        }
    }
}