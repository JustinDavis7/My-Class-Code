using System;
using System.Collections.Generic;

namespace Sorts.Test
{
    public class TestBase
    {
        private static readonly Random Random = new Random(0);
        protected enum OrderType
        {
            Sorted,
            Reversed,
            Random
        }

        protected enum SortType
        {
            InsertionSort,
            SelectionSort,
            MergeSort,
            QuickSort
        }

        protected static readonly long[,] SortedCompares = new long[,]
        {
            {99, 199, 399, 799, 1599},              // Insertion Sort
            {4950, 19900, 79800, 319600, 1279200},  // Selection Sort
            {356, 812, 1824, 4048, 8896},           // Merge Sort
            {488, 1173, 2742, 6279, 14152}          // Quick Sort
        };

        protected static readonly long[,] ReverseSortedCompares =
        {
            {4950, 19900, 79800, 319600, 1279200},
            {4950, 19900, 79800, 319600, 1279200},
            {316, 732, 1664, 3728, 8256},
            {638, 1543, 3748, 8964, 20968}
        };

        protected static readonly long[,] RandomCompares =
        {
            {2679, 10069, 41701, 161392, 648144},
            {4950, 19900, 79800, 319600, 1279200},
            {547, 1275, 2957, 6727, 15028},
            {599, 1454, 3809, 7418, 17189},
        };

        protected static readonly int[] SortSizesValues =
        {
            100, 200, 400, 800, 1600
        };

        protected static readonly Dictionary<int, int> SortSizesDictionary = new Dictionary<int, int>()
        {
            {100, 0},
            {200, 1},
            {400, 2},
            {800, 3},
            {1600, 4}
        };

        protected static IComparable[] MakeData(int size, OrderType orderType)
        {
            var data = new IComparable[size];

            for (var i = 0; i < size; ++i)
            {
                data[i] = orderType switch
                {
                    OrderType.Sorted => i,
                    OrderType.Reversed => size - i,
                    OrderType.Random => Random.Next(size),
                    _ => data[i]
                };
            }

            return data;
        }

        protected bool CheckSort(IComparable[] comparables)
        {
            for (var i = 0; i < comparables.Length - 1; ++i)
            {
                if (comparables[i].CompareTo(comparables[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
