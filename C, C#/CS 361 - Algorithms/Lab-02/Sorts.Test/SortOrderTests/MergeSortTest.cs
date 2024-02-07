using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorts.Test.SortOrderTests
{
    [TestClass]
    public class MergeSortTest : TestBase
    {
        [TestMethod]
        public void MergeSortSortedOrderTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Sorted);

                new MergeSort().Sort(data);

                Assert.IsTrue(CheckSort(data), $"MergeSort with {size} sorted elements is not sorted correctly");
            }
        }

        [TestMethod]
        public void MergeSortReverseSortedOrderTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Reversed);

                new MergeSort().Sort(data);

                Assert.IsTrue(CheckSort(data), $"MergeSort with {size} reversed sorted elements is not sorted correctly");
            }
        }
    }
}
