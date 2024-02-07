using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorts.Test.SortOrderTests
{
    [TestClass]
    public class InsertionSortTest : TestBase
    {
        [TestMethod]
        public void InsertionSortSortedOrderTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Sorted);

                new InsertionSort().Sort(data);

                Assert.IsTrue(CheckSort(data), $"InsertionSort with {size} sorted elements is not sorted correctly");
            }
        }

        [TestMethod]
        public void InsertionSortSmallOrderTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = new IComparable[] { 5, 3, 9, 0, 2 };

                new InsertionSort().Sort(data);

                Assert.IsTrue(CheckSort(data), $"InsertionSort with {size} reversed sorted elements is not sorted correctly");
            }
        }

        [TestMethod]
        public void InsertionSortReversedSortedOrderTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Reversed);

                new InsertionSort().Sort(data);

                Assert.IsTrue(CheckSort(data), $"InsertionSort with {size} reversed sorted elements is not sorted correctly");
            }
        }
    }
}
