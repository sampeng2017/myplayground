using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Basics
{
    public static class Misc
    {
        public static int Fibonacci_DP1(int n)
        {
            var memo = new Dictionary<int, int>();
            return Fibonacci_DP1(n, memo);
        }

        public static int Fibonacci_DP1(int n, Dictionary<int, int> memo)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;

            int v;
            if (memo.TryGetValue(n, out v))
            {
                return v;
            }
            v = Fibonacci_DP1(n - 1, memo) + Fibonacci_DP1(n - 2, memo);
            memo.Add(n, v);
            return v;
        }
        public static int Fibonacci_DP2(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;

            var memo = new Dictionary<int, int>() { { 1, 1 }, { 2, 1 } };
            for (int i = 3; i <= n; i++)
            {
                int f = memo[i - 2] + memo[i - 1];
                memo[i] = f;
            }
            return memo[n];
        }

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

        // TODO: this is wrong
        public static Tuple<int, int, int> FindMaxSubArray_linear(int[] ary, int low, int high)
        {
            int maxSum = int.MinValue;
            int maxLeft = low;
            int maxRight = low;
            int leftIndex = low;
            int rightIndex = high;

            int tmpSum = 0;
            for (int i = low; i <= high; i++)
            {
                int key = ary[i];
                tmpSum += key;
                if (tmpSum > maxSum)
                {
                    maxSum = tmpSum;
                    maxRight = i;
                }
                else
                {

                }
                if (tmpSum == 0)
                {
                    leftIndex = rightIndex = i;
                }
                tmpSum += ary[i];
                if (tmpSum > maxSum)
                {
                    maxSum = tmpSum;
                    rightIndex = i;
                }
                else
                {
                    tmpSum = 0;
                }
            }
            return Tuple.Create(leftIndex, rightIndex, maxSum);
        }

        public static Tuple<int, int> FindMinAndMax(int[] ary)
        {
            if (ary.Length == 1)
                return Tuple.Create(ary[0], ary[0]);

            int min = ary[0];
            int max = min;

            bool isEven = ary.Length % 2 == 0;
            if (isEven)
            {
                if (ary[0] < ary[1])
                {
                    max = ary[1];
                }
                else
                {
                    max = ary[0];
                    min = ary[1];
                }
            }

            int i = isEven ? 2 : 1;
            for (; i < ary.Length; i = i + 2)
            {
                int bigger; 
                int smaller;
                if (ary[i] < ary[i+1])
                {
                    bigger = ary[i + 1];
                    smaller = ary[i];
                }
                else
                {
                    smaller = ary[i + 1];
                    bigger = ary[i];
                }

                if (smaller < min)
                    min = smaller;
                if (bigger > max)
                    max = bigger;
            }

            return Tuple.Create(min, max);
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
