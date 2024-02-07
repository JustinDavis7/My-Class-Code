using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorts.Test.SortOrderTests
{
    [TestClass]
    public class SelectionSortTest : TestBase
    {
        [TestMethod]
        public void SelectionSortSortedOrderTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Sorted);

                new SelectionSort().Sort(data);

                Assert.IsTrue(CheckSort(data), $"Selection Sort with {size} sorted elements is not sorted correctly");
            }
        }

        [TestMethod]
        public void SelectionSortReversedSortedOrderTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Reversed);

                new SelectionSort().Sort(data);

                Assert.IsTrue(CheckSort(data), $"Selection Sort with {size} reversed sorted elements is not sorted correctly");
            }
        }

    }
}
