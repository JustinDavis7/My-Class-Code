using System;
using System.Linq;

namespace Sorts
{
    public class MergeSort : ISort
    {
        public long Sort(IComparable[] collection)
        {
            var comparisonCount = 0L;
            var newCollection = new IComparable[collection.Length];

            MergeSorter(collection, newCollection, 0, collection.Length - 1, ref comparisonCount);
            return comparisonCount;
        }

        public void MergeSorter(IComparable[] collection, IComparable[] tempCollection, int left, int right, ref long comparisonCount)
        {
            if(left < right)
            {
                var center = (left + right) / 2;
                MergeSorter(collection, tempCollection, left, center, ref comparisonCount);
                MergeSorter(collection, tempCollection, center + 1, right, ref comparisonCount);
                Merge(collection, tempCollection, left, center + 1, right, ref comparisonCount);
            }
        }

        public void Merge(IComparable[] collection, IComparable[] tempCollection, int left, int right, int rightEnd, ref long comparisonCount)
        {
            var leftEnd = right - 1;
            var tempPos = left;
            var numElements = rightEnd - left + 1;

            while(left <= leftEnd && right <= rightEnd)
            {
                ++comparisonCount;
                if(collection[left].CompareTo(collection[right]) < 0)
                {
                    tempCollection[tempPos++] = collection[left++];
                }
                else
                {
                    tempCollection[tempPos++] = collection[right++];
                }
            }

            while(left <= leftEnd)
            {
                tempCollection[tempPos++] = collection[left++];
            }

            while (right <= rightEnd)
            {
                tempCollection[tempPos++] = collection[right++];
            }

            for(var i = 0; i < numElements; ++i)
            {
                collection[rightEnd] = tempCollection[rightEnd];
                --rightEnd;
            }
        }
    }
}