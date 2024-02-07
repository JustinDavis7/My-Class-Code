using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorts.Test.SortOrderTests
{
    [TestClass]
    public class QuickSortTest : TestBase
    {
        [TestMethod]
        public void QuickSortSortedOrderTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Sorted);

                new QuickSort().Sort(data);

                Assert.IsTrue(CheckSort(data), $"QuickSort with {size} sorted elements is not sorted correctly");
            }
        }

        [TestMethod]
        public void QuickSortReversedSortedOrderTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Reversed);

                new QuickSort().Sort(data);

                Assert.IsTrue(CheckSort(data), $"QuickSort with {size} reversed sorted elements is not sorted correctly");
            }
        }
    }
}
