using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.FSharp.Collections;

//test used for testing sorting times
//not very standard unit test
namespace csharpSortLib.Test
{
    [TestClass]
    public class UnitTest1
    {
        FSharpList<int> fsharpListToSort = SortingHelperModule.getTestList(100, Int32.MaxValue);
        List<int> listToSort = TestHelper.GetRandomListToSort(100);

        [TestInitialize]
        public void TestInit()
        {
            var tmp = fsharpListToSort.Length;
            tmp = listToSort.Count;
        }

        [TestMethod]
        public void BuildinSortTest()
        {
            var tmp = listToSort.ToArray();
            Array.Sort(tmp);
        }

        [TestMethod]
        public void CsharpSelectSortTest()
        {
            var tmp = listToSort.ToArray();
            SortLib.select_sort(tmp);
        }

        [TestMethod]
        public void CsharpInsertSortTest()
        {
            var tmp = listToSort.ToArray();
            SortLib.insert_sort(tmp);
        }

        [TestMethod]
        public void CsharpMergeSortTest()
        {
            var tmp = listToSort.ToArray();
            SortLib.merge_sort(0, tmp.Length-1, tmp);
        }

        [TestMethod]
        public void FsharpSelectSortTest()
        {
            var tmp = SortingModule.selectsort(fsharpListToSort);
        }

        [TestMethod]
        public void FsharpSelectSortFoldTest()
        {
            var tmp = SortingModule.selectsortFold(fsharpListToSort);
        }

        [TestMethod]
        public void FsharpInsertSortTest()
        {
            var tmp = SortingModule.insertsort(fsharpListToSort);
        }

        [TestMethod]
        public void FsharpInsertSortFoldTest()
        {
            var tmp = SortingModule.insertsortFold(fsharpListToSort);
        }

        [TestMethod]
        public void FsharpMergeSortSortTest()
        {
            var tmp = SortingModule.mergeSort(fsharpListToSort);
        }
    }
}
