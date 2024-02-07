using System;

namespace Sorts
{
    public class QuickSort : ISort
    {
        int CutOff = 10;
        public long Sort(IComparable[] collection)
        {
            return QuickSorter(collection, 0, collection.Length - 1);
        }

        public long QuickSorter(IComparable[] collection, int low, int high)
        {
            var comparisonCount = 0L;
            if(low + CutOff > high)
            {
                var insertionSort = new InsertionSort();
                comparisonCount += insertionSort.Sort(collection, low, high);
            }
            else
            {
                var middle = (low + high) / 2;

                if (++comparisonCount >= 0 && collection[middle].CompareTo(collection[low]) < 0)
                    Swap(ref collection[low], ref collection[middle]);

                if (++comparisonCount >= 0 && collection[high].CompareTo(collection[low]) < 0)
                    Swap(ref collection[low], ref collection[high]);

                if (++comparisonCount >= 0 && collection[high].CompareTo(collection[middle]) < 0)
                    Swap(ref collection[middle], ref collection[high]);

                Swap(ref collection[middle], ref collection[high - 1]);
                var pivot = collection[high - 1];
                var i = low;
                var j = high - 1;

                while(true)
                {
                    do
                        ++i;
                    while (++comparisonCount >= 0 && collection[i].CompareTo(pivot) < 0);
                    do
                        --j;
                    while (++comparisonCount >= 0 && pivot.CompareTo(collection[j]) < 0);
                        if (i >= j)
                            break;
                    Swap(ref collection[i], ref collection[j]);
                }
                Swap(ref collection[i], ref collection[high - 1]);

                comparisonCount += QuickSorter(collection, low, i - 1);
                comparisonCount += QuickSorter(collection, i + 1, high);
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