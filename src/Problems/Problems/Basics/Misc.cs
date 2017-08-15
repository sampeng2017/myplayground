﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Basics
{
    public static class Misc
    {
        public static Tuple<int, int, int> FindMaxSubArray(int[] ary, int low, int high)
        {
            if (low == high)
                return Tuple.Create(low, high, ary[low]);

            int mid = (low + high) / 2;
            var leftResult = FindMaxSubArray(ary, low, mid);
            var rightResult = FindMaxSubArray(ary, mid + 1, high);
            var crossingResult = FindMaxCrossingSubArray(ary, low, mid, high);
            if (leftResult.Item3 >= rightResult.Item3 && leftResult.Item3 >= crossingResult.Item3)
            {
                return leftResult;
            }
            if (rightResult.Item3 >= leftResult.Item3 && rightResult.Item3 >= crossingResult.Item3)
            {
                return rightResult;
            }
            return crossingResult;
        }

        private static Tuple<int, int, int> FindMaxCrossingSubArray(int[] ary, int low, int mid, int high)
        {
            int leftSum = int.MinValue;
            int rightSum = int.MinValue;
            int tmpSum = 0;
            int leftIndex = low;
            int rightIndex = high;

            for (int i = mid; i >= low; i--)
            {
                tmpSum += ary[i];
                if (tmpSum > leftSum)
                {
                    leftSum = tmpSum;
                    leftIndex = i;
                }
            }
            tmpSum = 0;
            for (int i = mid + 1; i <= high; i++)
            {
                tmpSum += ary[i];
                if (tmpSum > rightSum)
                {
                    rightSum = tmpSum;
                    rightIndex = i;
                }
            }

            return Tuple.Create(leftIndex, rightIndex, leftSum + rightSum);
        }
    }
}
