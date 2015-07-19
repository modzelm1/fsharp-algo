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

        //[TestMethod]
        //public void aTestSelectSortFsharp()
        //{
        //    var stopWatch = System.Diagnostics.Stopwatch.StartNew();
        //    stopWatch.Stop();
        //    stopWatch.Reset();

        //    var ats1 = SortingHelperModule.getTestList(1000, Int32.MaxValue);
        //    var ats2 = SortingHelperModule.getTestList(10000, Int32.MaxValue);
        //    var ats3 = SortingHelperModule.getTestList(100000, Int32.MaxValue);


        //    stopWatch.Start();
        //    var r1 = SortingModule.selectsort(ats1);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    stopWatch.Start();
        //    var r2 = SortingModule.selectsort(ats2);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    //stopWatch.Start();
        //    //var r3 = SortingModule.selectsort(ats3);
        //    //stopWatch.Stop();
        //    //Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    //stopWatch.Reset();
        //}

        //[TestMethod]
        //public void bTestSelectSortFoldFsharp()
        //{
        //    var stopWatch = System.Diagnostics.Stopwatch.StartNew();
        //    stopWatch.Stop();
        //    stopWatch.Reset();

        //    var ats1 = SortingHelperModule.getTestList(1000, Int32.MaxValue);
        //    var ats2 = SortingHelperModule.getTestList(10000, Int32.MaxValue);

        //    stopWatch.Start();
        //    var r1 = SortingModule.selectsortFold(ats1);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    stopWatch.Start();
        //    var r2 = SortingModule.selectsortFold(ats2);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();
        //}

        //[TestMethod]
        //public void cTestInsertSortFsharp()
        //{
        //    var stopWatch = System.Diagnostics.Stopwatch.StartNew();
        //    stopWatch.Stop();
        //    stopWatch.Reset();

        //    var ats1 = SortingHelperModule.getTestList(1000, Int32.MaxValue);
        //    var ats2 = SortingHelperModule.getTestList(10000, Int32.MaxValue);
        //    var ats3 = SortingHelperModule.getTestList(100000, Int32.MaxValue);


        //    stopWatch.Start();
        //    var r1 = SortingModule.insertsort(ats1);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    stopWatch.Start();
        //    var r2 = SortingModule.insertsort(ats2);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    //stopWatch.Start();
        //    //var r3 = SortingModule.insertsort(ats3);
        //    //stopWatch.Stop();
        //    //Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    //stopWatch.Reset();
        //}

        //[TestMethod]
        //public void dTestInsertSortFoldFsharp()
        //{
        //    var stopWatch = System.Diagnostics.Stopwatch.StartNew();
        //    stopWatch.Stop();
        //    stopWatch.Reset();

        //    var ats1 = SortingHelperModule.getTestList(1000, Int32.MaxValue);
        //    var ats2 = SortingHelperModule.getTestList(10000, Int32.MaxValue);
        //    var ats3 = SortingHelperModule.getTestList(100000, Int32.MaxValue);


        //    stopWatch.Start();
        //    var r1 = SortingModule.selectsortFold(ats1);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    stopWatch.Start();
        //    var r2 = SortingModule.selectsortFold(ats2);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();
        //}

        //[TestMethod]
        //public void eTestSelectSort()
        //{
        //    var stopWatch = System.Diagnostics.Stopwatch.StartNew();
        //    stopWatch.Stop();
        //    stopWatch.Reset();

        //    var ats1 = listToSort1.ToArray();
        //    var ats2 = listToSort2.ToArray();
        //    var ats3 = listToSort3.ToArray();

        //    stopWatch.Start();
        //    SortLib.select_sort(ats1);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    stopWatch.Start();
        //    SortLib.select_sort(ats2);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    //stopWatch.Start();
        //    //SortLib.select_sort(ats3);
        //    //stopWatch.Stop();
        //    //Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    //stopWatch.Reset();
        //}

        //[TestMethod]
        //public void fTestInsertSort()
        //{
        //    var stopWatch = System.Diagnostics.Stopwatch.StartNew();
        //    stopWatch.Stop();
        //    stopWatch.Reset();

        //    var ats1 = listToSort1.ToArray();
        //    var ats2 = listToSort2.ToArray();
        //    var ats3 = listToSort3.ToArray();

        //    stopWatch.Start();
        //    SortLib.insert_sort(ats1);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    stopWatch.Start();
        //    SortLib.insert_sort(ats2);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    //stopWatch.Start();
        //    //SortLib.insert_sort(ats3);
        //    //stopWatch.Stop();
        //    //Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    //stopWatch.Reset();
        //}

        //[TestMethod]
        //public void gTestMergeSort()
        //{
        //    var stopWatch = System.Diagnostics.Stopwatch.StartNew();
        //    stopWatch.Stop();
        //    stopWatch.Reset();

        //    var ats1 = listToSort1.ToArray();
        //    var ats2 = listToSort2.ToArray();
        //    var ats3 = listToSort3.ToArray();

        //    stopWatch.Start();
        //    SortLib.merge_sort(0, 999, ats1);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    stopWatch.Start();
        //    SortLib.merge_sort(0, 9999, ats2);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    //stopWatch.Start();
        //    //SortLib.merge_sort(0, 99999, ats3);
        //    //stopWatch.Stop();
        //    //Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    //stopWatch.Reset();
        //}

        //[TestMethod]
        //public void hTestDotNetSort()
        //{
        //    var stopWatch = System.Diagnostics.Stopwatch.StartNew();
        //    stopWatch.Stop();
        //    stopWatch.Reset();

        //    var ats1 = listToSort1.ToArray();
        //    var ats2 = listToSort2.ToArray();
        //    var ats3 = listToSort3.ToArray();

        //    stopWatch.Start();
        //    Array.Sort(ats1);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    stopWatch.Start();
        //    Array.Sort(ats2);
        //    stopWatch.Stop();
        //    Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    stopWatch.Reset();

        //    //stopWatch.Start();
        //    //Array.Sort(ats3);
        //    //stopWatch.Stop();
        //    //Debug.WriteLine("Time elapsed: " + stopWatch.Elapsed);
        //    //stopWatch.Reset();
        //}
    }
}
