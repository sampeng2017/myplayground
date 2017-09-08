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

            int[] twoItems = new int[] { 0, 1 };
            int cnt = 1;
            while (true)
            {
                twoItems[0] = twoItems[0] + twoItems[1];
                cnt++;
                if (cnt == n)
                    break;
                twoItems[1] = twoItems[0] + twoItems[1];
                cnt++;
                if (cnt == n)
                    break;
            }
            return twoItems[1] > twoItems[0] ? twoItems[1] : twoItems[0];
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
                if (ary[i] < ary[i + 1])
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

        // select the value of the i'th samllest element in the ary[p .. r];
        public static int RandomSelectNth(int[] ary, int p, int r, int i)
        {
            int q = Helpers.RandomPartition(ary, p, r);

            // if the pivot mathes, return
            int k = q - p + 1;
            if (k == i)
                return ary[q];
            if (i < k)
                return RandomSelectNth(ary, p, q - 1, i);
            else
                return RandomSelectNth(ary, q + 1, r, i - k);
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

        private static Tuple<int, int, int> FindMaxCrossingSubArray(int[] ary, int low, int mid, int high)
        {
            int leftSum = int.MinValue;
            int rightSum = int.MinValue;
            int leftIndex = low;
            int rightIndex = high;

            int tmpSum = 0;
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
            minVal = 2 * minVal - result;
            return minVal;
        }

        public int GetMin()
        {
            return minVal;
        }
    }
}
