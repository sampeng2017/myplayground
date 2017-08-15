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

        public static void MergeSort(int[] ary)
        {
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
            for (int k = p; k < r; k++)
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
    }
}
