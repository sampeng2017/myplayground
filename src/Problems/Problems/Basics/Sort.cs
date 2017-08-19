using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Basics
{
    public static class Sort
    {
        public static void InsertionSort(int[] ary)
        {
            if (ary == null || ary.Length == 1)
                return;

            for (int i = 1; i < ary.Length; i++)
            {
                int key = ary[i];
                int j = i - 1;
                while (j >= 0 && ary[j] > key)
                {
                    ary[j + 1] = ary[j];
                    j--;
                }
                ary[j + 1] = key;
            }
        }

        public static void InsertionSort_Recursive(int[] ary)
        {
            InsertionSort_Recursive(ary, 0, ary.Length - 1);
        }

        private static void InsertionSort_Recursive(int[] ary, int low, int high)
        {
            if (low >= high)
                return;
            InsertionSort_Recursive(ary, low, high - 1);

            int key = ary[high];
            int j = high - 1;
            while (j >= low && ary[j] > key)
            {
                ary[j + 1] = ary[j];
                j--;
            }
            ary[j + 1] = key;
        }

        public static void MergeSort(int[] ary)
        {
            MergeSort(ary, 0, ary.Length - 1);
        }

        private static void MergeSort(int[] ary, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                MergeSort(ary, p, q);
                MergeSort(ary, q + 1, r);
                Merge(ary, p, q, r);
            }
        }

        private static void Merge(int[] ary, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] left = new int[n1 + 1];
            left[n1] = int.MaxValue; // sentinel

            int[] right = new int[n2 + 1];
            right[n2] = int.MaxValue;

            for (int ii = 0; ii < n1; ii++)
            {
                left[ii] = ary[p + ii];
            }
            for (int ii = 0; ii < n2; ii++)
            {
                right[ii] = ary[q + ii + 1];
            }

            int i = 0;
            int j = 0;
            for (int k = p; k <= r; k++)
            {
                if (left[i] <= right[j])
                {
                    ary[k] = left[i];
                    i++;
                }
                else
                {
                    ary[k] = right[j];
                    j++;
                }
            }
        }

        public static void MergeSort_BottomUp(int[] ary)
        {
            int aryLength = ary.Length;
            for (int subArySize = 1; subArySize < aryLength; subArySize = subArySize * 2)
            {
                for (int subAryIndex = 0; subAryIndex < aryLength - subArySize; subAryIndex += subArySize * 2)
                {
                    Merge(ary, subAryIndex, subAryIndex + subArySize - 1, Math.Min(subAryIndex + subArySize * 2 - 1, aryLength - 1));
                }
            }
        }

        // TODO: re-do without using the MaxHeap class
        public static void HeapSort(int[] ary)
        {
            var maxHelp = new MaxHeap<int>();
            for (int i = 0; i < ary.Length; i++)
            {
                maxHelp.Insert(ary[i]);
            }
            for (int i = ary.Length - 1; i >= 0; i--)
            {
                ary[i] = maxHelp.GetMax();
            }
        }

        public static void QuickSort(int[] ary)
        {
            QuickSort(ary, 0, ary.Length - 1);
        }

        private static void QuickSort(int[] ary, int p, int r)
        {
            if (p < r)
            {
                int q = Helpers.RandomPartition(ary, p, r);
                QuickSort(ary, p, q - 1);
                QuickSort(ary, q + 1, r);
            }
        }
    }
}
