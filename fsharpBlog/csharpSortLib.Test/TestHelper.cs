using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpSortLib.Test
{
    class TestHelper
    {
        public static int[] GetRandomArrayToSort(int length)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var result = new int[length];
            for(int i = 0; i < length; i++)
                result[i] = rnd.Next(Int32.MaxValue);
            return result;
        }

        public static List<int> GetRandomListToSort(int length)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var result = new List<int>();
            for (int i = 0; i < length; i++)
                result.Add(rnd.Next(Int32.MaxValue));
            return result;
        }
    }
}
