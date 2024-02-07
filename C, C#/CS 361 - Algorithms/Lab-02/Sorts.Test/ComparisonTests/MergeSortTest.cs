using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorts.Test.ComparisonTests
{
    [TestClass]
    public class MergeSortTest : TestBase
    {
        [TestMethod]
        public void MergeSortSortedComparesTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Sorted);

                var compares = new MergeSort().Sort(data);

                Assert.AreEqual(SortedCompares[(int)SortType.MergeSort, SortSizesDictionary[size]], compares);
            }
        }

        [TestMethod]
        public void MergeSortReverseSortedComparesTest()
        {
            foreach (var size in SortSizesValues)
            {
                var data = MakeData(size, OrderType.Reversed);

                var compares = new MergeSort().Sort(data);

                Assert.AreEqual(ReverseSortedCompares[(int)SortType.MergeSort, SortSizesDictionary[size]], compares);
            }
        }
    }
}
