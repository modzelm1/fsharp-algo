using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SelectSortTestCsharp
{
    public static class Extensions
    {
        public static Tuple<List<T>, List<T>> PartitionList<T>(this List<T> list, Func<T, bool> f)
        {
            Tuple<List<T>, List<T>> result = new Tuple<List<T>, List<T>>(new List<T>(), new List<T>());
            foreach (var item in list)
                if (f(item))
                    result.Item1.Add(item);
                else
                    result.Item2.Add(item);
            return result;
        }
    }

    class Program
    {
        public static double RestartStopWatch(Stopwatch sw)
        {
            sw.Stop();
            var result = sw.Elapsed.TotalMilliseconds;
            sw.Reset();
            return result;
        }

        public static void ReportTime(int l, double t)
        {
            Console.WriteLine("{0} elements sorted in {1}", l, t);
        }

        public static List<int> GetRandomListToSort(int length, int max)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var result = new List<int>();
            for (int i = 0; i < length; i++)
                result.Add(rnd.Next(max));
            return result;
        }

        public static void PerformTest(Stopwatch sw, List<int> l, Func<List<int>, List<int>> sf)
        {
            sw.Start();
            sf(l);
            var te = RestartStopWatch(sw);
            ReportTime(l.Count, te);
        }

        public static List<int> SelectSortFast(List<int> tab)
        {
            if (tab.Count < 1) return tab;
            var min = tab.Min();
            var parTup = tab.PartitionList(x => x == min);
            return parTup.Item1.Concat(SelectSortFast(parTup.Item2)).ToList();
        }

        public static List<int> SelectSortSlow(List<int> tab)
        {
            if (tab.Count < 1) return tab;
            var parTup = tab.PartitionList(x => x == tab.Min());
            return parTup.Item1.Concat(SelectSortSlow(parTup.Item2)).ToList();
        }

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var listToSort1 = GetRandomListToSort(100, 10000);
            var listToSort2 = GetRandomListToSort(1000, 10000);
            var listToSort3 = GetRandomListToSort(10000, 10000);

            SelectSortFast(listToSort1);
            SelectSortSlow(listToSort1);
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            stopWatch.Stop();
            stopWatch.Reset();

            Console.WriteLine("Starting SelectSortFast");
            PerformTest(stopWatch, listToSort1, SelectSortFast);
            PerformTest(stopWatch, listToSort2, SelectSortFast);
            PerformTest(stopWatch, listToSort3, SelectSortFast);
            Console.WriteLine("SelectSortFast done");
            Console.WriteLine();
            Console.WriteLine("Starting SelectSortSlow");
            PerformTest(stopWatch, listToSort1, SelectSortSlow);
            PerformTest(stopWatch, listToSort2, SelectSortSlow);
            PerformTest(stopWatch, listToSort3, SelectSortSlow);
            Console.WriteLine("SelectSortSlow done");
        }
    }
}
