using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorts.Test.ComparisonTests
{
    [TestClass]
    public class QuickSortTest : TestBase
    {
        [TestMethod]
        public void QuickSortSortedComparesTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Sorted);

                var compares = new QuickSort().Sort(data);

                Assert.AreEqual(SortedCompares[(int)SortType.QuickSort, SortSizesDictionary[size]], compares);
            }
        }

        [TestMethod]
        public void QuickSortReverseSortedComparesTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Reversed);

                var compares = new QuickSort().Sort(data);

                Assert.AreEqual(ReverseSortedCompares[(int)SortType.QuickSort, SortSizesDictionary[size]], compares);
            }
        }
    }
}
