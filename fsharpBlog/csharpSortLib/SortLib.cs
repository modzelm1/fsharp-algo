using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpSortLib
{
    public class SortLib
    {

        public static void insert_sort(int[] tab)
        {
            for (int i = 1; i < tab.Length; i++)
            {
                int key = tab[i];
                int j = i - 1;
                while (j > -1 && key < tab[j])
                {
                    tab[j + 1] = tab[j];
                    j--;
                }
                tab[j + 1] = key;
            }
        }

        public static void select_sort(int[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                int minIndex = i;
                int tmpVal = tab[i];
                for (int j = i + 1; j < tab.Length; j++)
                {
                    if (tab[j] < tab[minIndex])
                    {
                        minIndex = j;
                    }
                }
                tab[i] = tab[minIndex];
                tab[minIndex] = tmpVal;
            }
        }

        public static void merge_sort(int firstIndex, int lastIndex, int[] tab)
        {
            if (firstIndex == lastIndex)
                return;

            int midIndex = (firstIndex + lastIndex + 1) / 2;
            merge_sort(firstIndex, midIndex - 1, tab);
            merge_sort(midIndex, lastIndex, tab);
            merge(firstIndex, lastIndex, midIndex, tab);
        }

        public static void merge(int firstIndex, int lastIndex, int midIndex, int[] tab)
        {
            int[] leftSubArray = new int[midIndex - firstIndex + 1];
            int[] rightSubArray = new int[lastIndex - midIndex + 1 + 1];

            for (int i = 0; i < leftSubArray.Length - 1; i++)
                leftSubArray[i] = tab[firstIndex + i];

            for (int i = 0; i < rightSubArray.Length - 1; i++)
                rightSubArray[i] = tab[midIndex + i];

            leftSubArray[leftSubArray.Length - 1] = int.MaxValue;
            rightSubArray[rightSubArray.Length - 1] = int.MaxValue;

            int elLeftIndex = 0;
            int elRightIndex = 0;
            for (int i = firstIndex; i <= lastIndex; i++)
            {
                if (leftSubArray[elLeftIndex] <= rightSubArray[elRightIndex])
                {
                    tab[i] = leftSubArray[elLeftIndex]; elLeftIndex++;
                }
                else
                {
                    tab[i] = rightSubArray[elRightIndex]; elRightIndex++;
                }
            }
        }


    }
}
