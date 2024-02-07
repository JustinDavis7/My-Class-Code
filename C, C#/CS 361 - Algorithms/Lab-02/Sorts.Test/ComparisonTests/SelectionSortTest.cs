using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorts.Test.ComparisonTests
{
    [TestClass]
    public class SelectionSortTest : TestBase
    {
        [TestMethod]
        public void SelectionSortSortedComparesTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Sorted);

                var compares = new SelectionSort().Sort(data);

                Assert.AreEqual(SortedCompares[(int)SortType.SelectionSort, SortSizesDictionary[size]], compares);
            }
        }

        [TestMethod]
        public void SelectionSortReverseSortedComparesTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Reversed);

                var compares = new SelectionSort().Sort(data);

                Assert.AreEqual(ReverseSortedCompares[(int)SortType.SelectionSort, SortSizesDictionary[size]], compares);
            }
        }
    }
}
