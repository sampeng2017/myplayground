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

        public static int Fibonacci_NoRecursive(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;

            int a1 = 1;
            int a2 = 1;
            int cnt = 2;
            while (cnt < n)
            {
                int sum = a1 + a2;
                a1 = a2;
                a2 = sum;
                cnt++;
            }
            return a2;
        }

        public static Tuple<int, int, int> FindMaxSubArray(int[] a, int l, int h)
        {
            if (l == h)
                return Tuple.Create(l, h, a[l]);

            int mid = (l + h) / 2;
            var leftResult = FindMaxSubArray(a, l, mid);
            var rightResult = FindMaxSubArray(a, mid + 1, h);
            var crossingResult = FindMaxCrossingSubArray(a, l, mid, h);
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

        private static Tuple<int, int, int> FindMaxCrossingSubArray(int[] a, int l, int m, int h)
        {
            int leftSum = int.MinValue;
            int rightSum = int.MinValue;
            int leftIndex = l;
            int rightIndex = h;

            int tmpSum = 0;
            for (int i = m; i >= l; i--)
            {
                tmpSum += a[i];
                if (tmpSum > leftSum)
                {
                    leftSum = tmpSum;
                    leftIndex = i;
                }
            }

            tmpSum = 0;
            for (int i = m + 1; i <= h; i++)
            {
                tmpSum += a[i];
                if (tmpSum > rightSum)
                {
                    rightSum = tmpSum;
                    rightIndex = i;
                }
            }

            return Tuple.Create(leftIndex, rightIndex, leftSum + rightSum);
        }


        public static Tuple<int, int, int> FindMaxSubArray_Liner(int[] a)
        {
            int maxsum = int.MinValue;
            int sum = 0;
            int maxStart = 0;
            int maxEnd = 0;
            int currentStart = 0;
            int currentEnd = 0;

            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
                currentEnd = i;

                if (maxsum < sum)
                {
                    maxsum = sum;
                    maxStart = currentStart;
                    maxEnd = currentEnd;
                }

                if (sum < 0)
                {
                    currentStart = i + 1;
                    sum = 0;
                }
            }
            return Tuple.Create(maxStart, maxEnd, maxsum);
        }

        public static int FindMaxSubArray_Liner2(int[] a)
        {
            int maxsum = 0;
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
                if (maxsum < sum)
                {
                    maxsum = sum;
                }
                else if (sum < 0)
                {
                    sum = 0;
                }
            }

            return maxsum;
        }

        public static Tuple<int, int> FindMinAndMax(int[] ary)
        {
            if (ary.Length == 1)
                return Tuple.Create(ary[0], ary[0]);

            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < ary.Length; i++)
            {
                int val = ary[i];
                if (val > max)
                    max = val;
                else if (val < min)
                    min = val;
            }
            return Tuple.Create(min, max);
        }

        // select the value of the i'th samllest element in the ary[p .. r];
        public static int RandomSelectNth(int[] ary, int p, int r, int i)
        {
            if (r - p + 1 < i)
                return -1;

            int q = Helpers.RandomPartition(ary, p, r);

            // if the pivot mathes, return
            int k = q - p + 1;
            if (k == i)
                return ary[q];
            if (i < k)
                return RandomSelectNth(ary, p, q - 1, i);
            else
                return RandomSelectNth(ary, q + 1, r, i - k); // i - k !!
        }

        public static int RandomSelectNthNoRecurisive(int[] ary, int i)
        {
            // not sure why have to do this
            i = i - 1;

            Helpers.Shuffle(ary);
            int l = 0;
            int h = ary.Length - 1;
            while (h > l)
            {
                int q = Helpers.Partition(ary, l, h);

                if (q == i)
                    return ary[q];
                if (q > i)
                    h = q - 1;
                else
                    l = q + 1;
            }
            return ary[i];
        }

        // Euclid’s algorithm
        public static int Gcd(int n1, int n2)
        {
            if (n2 == 0)
                return n1;
            int a = n1 > n2 ? n1 : n2;
            int b = a == n1 ? n2 : n1;
            return Gcd(b, a % b);
        }
    }

    // this works only with numbers.
    // for non-number valued stack, use a separate stack to track min value
    public class StackWithMin
    {
        private int minVal;
        private Stack<int> stack = new Stack<int>();
        public void Push(int val)
        {
            var valToPush = val;
            if (stack.Count == 0)
            {
                minVal = val;
            }
            else
            {
                if (minVal > val)
                {
                    // valToPush will be for sure less than minVal:
                    // minVal > val
                    // 2* minVal > 2*val
                    // minVal > 2* val - minVal
                    valToPush = 2 * val - minVal;
                    minVal = val;
                }
            }
            stack.Push(valToPush);
        }

        public int Pop()
        {
            var result = stack.Pop();
            if (result >= minVal)
            {
                return result;
            }
            // in case that result is less than min value
            // the the [result] was pushed using 2 * [realValue] - [old minValue]
            // the [realValue] was stored in minVal field
            // so we need to recaculate minVal by:
            var actualValue = minVal;
            minVal = 2 * minVal - result;
            return actualValue;
        }

        public int GetMin()
        {
            return minVal;
        }
    }
}
