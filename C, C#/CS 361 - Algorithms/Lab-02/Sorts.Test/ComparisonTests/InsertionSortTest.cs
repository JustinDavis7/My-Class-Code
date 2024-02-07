using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorts.Test.ComparisonTests
{
    [TestClass]
    public class InsertionSortTest : TestBase
    {
        [TestMethod]
        public void InsertionSortSortedComparesTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Sorted);

                var compares = new InsertionSort().Sort(data);

                Assert.AreEqual(SortedCompares[(int)SortType.InsertionSort, SortSizesDictionary[size]], compares);
            }
        }

        [TestMethod]
        public void InsertionSortReverseSortedComparesTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Reversed);

                var compares = new InsertionSort().Sort(data);

                Assert.AreEqual(ReverseSortedCompares[(int)SortType.InsertionSort, SortSizesDictionary[size]], compares);
            }
        }
    }
}
