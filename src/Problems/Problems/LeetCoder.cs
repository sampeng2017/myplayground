using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problems.DataStructures;

namespace Problems
{
    public static class LeetCoder
    {
        // https://leetcode.com/problems/two-sum/description/
        public static Tuple<int, int> TwoSum(int[] ary, int sum)
        {
            // value and first index
            var tmpMap = new Dictionary<int, int>();

            int i1 = 0;
            int i2 = 0;
            for (int i = 0; i < ary.Length; i++)
            {
                int element = ary[i];
                int val;
                if (tmpMap.TryGetValue(sum - element, out val))
                {
                    i1 = val;
                    i2 = i;
                    break;
                }
                if (!tmpMap.ContainsKey(element))
                {
                    tmpMap.Add(element, i);
                }
            }
            return Tuple.Create(i1, i2);
        }

        // https://leetcode.com/problems/add-two-numbers/description/
        public static ListNode<int> AddTowNumbers(ListNode<int> n1, ListNode<int> n2)
        {
            ListNode<int> p1 = n1;
            ListNode<int> p2 = n2;

            ListNode<int> head = null;
            ListNode<int> current = null;
            int carray = 0;

            while (p1 != null || p2 != null || carray > 0)
            {
                int val1 = p1 == null ? 0 : p1.Value;
                int val2 = p2 == null ? 0 : p2.Value;
                int sum = val1 + val2 + carray;
                carray = 0;

                if (sum > 9)
                {
                    sum = sum - 10;
                    carray = 1;
                }
                var newNode = new ListNode<int> { Value = sum };
                if (head == null)
                {
                    head = current = newNode;
                }
                else
                {
                    current.Next = newNode;
                    current = newNode;
                }
                p1 = p1?.Next;
                p2 = p2?.Next;
            }
            return head;
        }

        // helper for AddTowNumbers
        public static ListNode<int> BuildLinkedListFromValue(int val)
        {
            if (val == 0)
            {
                return new ListNode<int> { Value = 0 };
            }

            int numDigits = 0;
            int t = 1;
            while (val / t > 0)
            {
                numDigits++;
                t *= 10;
            }

            int tmpT = numDigits;
            int remaining = val;
            DataStructures.ListNode<int> root = null;
            while (tmpT > 0)
            {
                int p = (int)Math.Pow(10, tmpT - 1);
                int nodeVal = remaining / p;
                remaining = remaining % p;
                var node = new DataStructures.ListNode<int> { Value = nodeVal };
                if (root == null)
                {
                    root = node;
                }
                else
                {
                    node.Next = root;
                    root = node;
                }
                tmpT--;
            }

            return root;
        }

        // helper for AddTowNumbers
        public static int LinkedListToValue(DataStructures.ListNode<int> l)
        {
            DataStructures.ListNode<int> tmp = l;
            int result = 0;
            int t = 0;
            while (tmp != null)
            {
                result += (tmp.Value * (int)Math.Pow(10, t));
                tmp = tmp.Next;
                t++;
            }
            return result;
        }

        //https://leetcode.com/problems/median-of-two-sorted-arrays/description/
        // Given two sorted arrays containing a total of n elements, give an algorithm to find the
        // median of the n elements in O(lg n) time on one processor.

        // The basic idea is that if you are given two arrays A and B and know
        // the length of each, you can check whether an element A[i] is the median in constant
        // time.Suppose that the median is A[i]. Since the array is sorted, it is greater than
        // exactly i − 1 values in array A. Then if it is the median, it is also greater than exactly
        // j = [∨n/2] − (i − 1) elements in B. It requires constant time to check if B[j]
        // <= A[i] <= B[j + 1]. If A[i] is not the median, then depending on whether A[i] is greater
        // or less than B[j] and B[j + 1], you know that A[i] is either greater than or less than
        // the median.Thus you can binary search for A[i] in O(lg n) worst-case time.
        public static int FindMediaOfTwoSortedArraies(int[] a, int[] b)
        {
            int n = a.Length + b.Length;

            if (a.Length > b.Length)
            {
                return FindMediaOfTwoSortedArraies(b, a, b.Length - 1, n / 2);
            }
            return FindMediaOfTwoSortedArraies(a, b, a.Length - 1, n / 2);
        }
        private static int FindMediaOfTwoSortedArraies(int[] a, int[] b, int left, int right)
        {
            int m = b.Length - 1;
            int n = a.Length + b.Length;

            int i = (left + right) / 2;
            int j = n / 2 - i;

            if ((j == 1 || a[i] > b[j]) && (j == m || a[i] <= b[j - 1]))
            {
                return a[i];
            }
            else if ((j == 1 || a[i] > b[j]) && (j != m && a[i] > b[j - 1]))
            {
                //median <a[i]
                return FindMediaOfTwoSortedArraies(a, b, left, i - 1);
            }
            else
            {
                //median >a[i]
                return FindMediaOfTwoSortedArraies(a, b, i + 1, right);
            }

        }

        private static Tuple<int, int> GetMedianIndex(int[] ary, int p, int q)
        {
            if (p == q)
                return new Tuple<int, int>(p, q);

            int length = p - q + 1;
            int mediaIndex = p + length / 2;
            if (length % 2 == 0)
            {
                return Tuple.Create(mediaIndex, mediaIndex);
            }
            else
            {
                return Tuple.Create(mediaIndex - 1, mediaIndex);
            }
        }
        private static int GetMedian(int[] ary, int i1, int i2)
        {
            return ary[(i1 + i2) / 2];
        }

        // https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
        public static string LongestSubstrWithoutRepeatingChars(string s)
        {
            var tmpMap = new Dictionary<char, int>();
            int longestStrLowIndex = 0;
            int loggestStrLength = 0;
            int curLowIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int tmpLoc;

                if (tmpMap.TryGetValue(s[i], out tmpLoc))
                {
                    if ((i - curLowIndex) > loggestStrLength)
                    {
                        longestStrLowIndex = curLowIndex;
                        loggestStrLength = i - curLowIndex;
                    }

                    curLowIndex = Math.Max(tmpLoc + 1, curLowIndex);
                }
                else
                {
                    if (i == s.Length - 1 && (i - curLowIndex + 1 > loggestStrLength))
                    {
                        longestStrLowIndex = curLowIndex;
                        loggestStrLength = i - curLowIndex + 1;
                    }
                }
                tmpMap[s[i]] = i;
            }

            return s.Substring(longestStrLowIndex, loggestStrLength);
        }

        public static int LongestSubstrLenWithoutRepeatingChars(string s)
        {
            var tmpMap = new Dictionary<char, int>();
            int max = 0;
            int curLowIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int tmpLoc;

                if (tmpMap.TryGetValue(s[i], out tmpLoc))
                {
                    curLowIndex = Math.Max(tmpLoc + 1, curLowIndex);
                }
                tmpMap[s[i]] = i;
                max = Math.Max(max, i - curLowIndex + 1);
            }

            return max;
        }

        //https://leetcode.com/problems/reverse-integer/description/
        public static int ReverseInteger(int val)
        {
            int result = 0;
            int sign = val < 0 ? -1 : 1;
            val = Math.Abs(val);
            while (val > 0)
            {
                if (result != 0 && int.MaxValue / result < 10)
                    return -1;

                int d = val % 10;
                result = result * 10 + d;
                val = val / 10;
            }
            return result * sign;
        }

        // use stack
        public static int ReverseInteger2(int n)
        {
            if (n == int.MinValue)
                return -1;

            if (n == 0)
                return n;

            bool isNegative = n < 0;

            int tmp = Math.Abs(n);
            var stack = new Stack<int>();

            while (tmp > 0)
            {
                int d = tmp % 10;
                stack.Push(d);
                tmp = tmp / 10;
            }

            int p = 1;
            int result = 0;
            while (stack.Count > 0)
            {
                if (result != 0 && int.MaxValue / result < 10)
                    return -1;

                result += stack.Pop() * p;
                p *= 10;
            }


            return isNegative ? -1 * result : result;
        }


        //https://leetcode.com/problems/rotate-list/description/
        public static ListNode<int> RotateList(ListNode<int> list, int k)
        {
            if (k == 0 || list == null || list.Next == null)
                return list;

            var p = list;
            int length = 1;
            while (p.Next != null)
            {
                length++;
                p = p.Next;
            }
            int actualStep = k % length;
            if (actualStep == 0)
                return list;

            // make it a loop
            p.Next = list;
            p = list;

            // move to length - k - 1, the new tail
            for (int i = 0; i < length - k - 1; i++)
            {
                p = p.Next;
            }

            var newHead = p.Next;
            p.Next = null;
            return newHead;
        }

        //https://leetcode.com/problems/generate-parentheses/description/
        public static string[] GenerateParentheses(int num)
        {
            if (num <= 0) return null;

            const string pair = "()";

            if (num == 1)
            {
                return new string[] { pair };
            }
            string[] subHolder = GenerateParentheses(num - 1);
            var newComobs = new List<string>();
            foreach (var subStr in subHolder)
            {
                newComobs.Add("(" + subStr + ")");
                string sideLeft = pair + subStr;
                string sideRight = subStr + pair;
                newComobs.Add(sideLeft);
                if (!string.Equals(sideLeft, sideRight))
                {
                    newComobs.Add(sideRight);
                }
            }
            return newComobs.ToArray();
        }

        //https://leetcode.com/problems/search-for-a-range/description/
        public static Tuple<int, int> SearchForRange(int[] sortedAry, int key)
        {
            int l = SearchForLeftIndex(sortedAry, key);
            if (l == -1)
                return Tuple.Create(-1, -1);
            int r = SearchForRightIndex(sortedAry, key);
            return Tuple.Create(l, r);
        }

        private static int SearchForLeftIndex(int[] sortedAry, int key)
        {
            int hi = sortedAry.Length - 1;
            while (hi >= 0)
            {
                int s = BinarySearch(sortedAry, 0, hi, key);
                if (s == -1 || s == 0 || sortedAry[s - 1] < key)
                {
                    return s;
                }
                hi = s - 1;
            }
            return -1;
        }

        private static int SearchForRightIndex(int[] sortedAry, int key)
        {
            int lo = 0;
            while (lo < sortedAry.Length)
            {
                int s = BinarySearch(sortedAry, lo, sortedAry.Length - 1, key);
                if (s == -1 || s == sortedAry.Length - 1 || sortedAry[s + 1] > key)
                {
                    return s;
                }
                lo = s + 1;
            }
            return -1;
        }

        private static int BinarySearch(int[] sortedAry, int lo, int hi, int key)
        {
            if (lo > hi)
                return -1;
            int mid = lo + (hi - lo) / 2;
            int midKey = sortedAry[mid];
            if (midKey == key)
                return mid;
            if (midKey > key)
                return BinarySearch(sortedAry, lo, mid - 1, key);
            return BinarySearch(sortedAry, mid + 1, hi, key);
        }

        // https://leetcode.com/problems/can-place-flowers/description/
        public static bool CanPlaceFlower(int[] flowerBed, int n)
        {
            // set init val to 1 because the previous value of flowerBed[0] is considered as 0
            int cntConsecutiveZero = 1;
            int slotCount = 0;
            for (int i = 0; i < flowerBed.Length; i++)
            {
                if (flowerBed[i] == 1)
                {
                    cntConsecutiveZero = 0;
                    continue;
                }
                cntConsecutiveZero++;
                if (cntConsecutiveZero == 3)
                {
                    cntConsecutiveZero = 1;
                    slotCount++;
                    if (slotCount == n)
                    {
                        break;
                    }
                }

                if (i == flowerBed.Length - 1 && cntConsecutiveZero == 2)
                {
                    slotCount++;
                }
            }

            return slotCount == n;
        }

        // https://leetcode.com/problems/zigzag-conversion/description/
        public static string ZigZagConversion(string s, int rows)
        {
            var holder = new List<char>[rows];
            for (int i = 0; i < rows; i++)
            {
                holder[i] = new List<char>();
            }
            for (int i = 0; i < s.Length; i++)
            {
                int t = i % (rows + 1);
                int rowIndex = t;
                if (t == rows)
                {
                    rowIndex = rows / 2;
                }
                holder[rowIndex].Add(s[i]);
            }

            var builder = new StringBuilder();
            foreach (var l in holder)
            {
                foreach (var c in l)
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }

        // https://leetcode.com/problems/combination-sum/description/
        public static IList<IList<int>> CombinationSum(int[] numbers, int sum)
        {
            var preparedNumbers = CombinationSum_PrepareNumbers(numbers, sum);
            var comboResults = GetCombinationSum(preparedNumbers, sum);
            return comboResults;
        }

        //TODO: can it uses memo to improve perf?
        static IList<IList<int>> GetCombinationSum(IList<int> numbers, int sum)
        {
            var result = new List<IList<int>>();
            if (numbers.Count == 0)
                return result;

            int lastTested = -1;
            for (int i = 0; i < numbers.Count; i++)
            {
                int val = numbers[i];
                if (val != lastTested)
                {
                    lastTested = val;
                }
                else
                {
                    continue;
                }
                int remain = sum - val;
                if (remain < 0)
                    break;

                if (remain == 0)
                {
                    var combo = new List<int> { val };
                    result.Add(combo);
                    break;
                }

                var subResult = GetCombinationSum(numbers.Skip(i + 1).ToList(), remain);
                foreach (var r in subResult)
                {
                    var combo = new List<int> { val };
                    combo.AddRange(r);
                    result.Add(combo);
                }
            }
            return result;
        }

        private static IList<int> CombinationSum_PrepareNumbers(int[] numbers, int sum)
        {
            var nums = new List<int>(numbers);
            nums.Sort();

            var numCopy = new List<int>(nums);
            int idx = 0;
            for (int i = 0; i < numCopy.Count; i++)
            {
                var val = numCopy[i];
                if (val > sum)
                {
                    nums.RemoveRange(idx, numCopy.Count - i);
                    break;
                }
                int tmp = sum / numCopy[i];
                nums.InsertRange(idx, Enumerable.Repeat(val, tmp - 1));
                idx += tmp;
            }
            return nums;
        }

        //https://leetcode.com/problems/path-sum/description/
        public static bool PathSum1(BinaryTreeNode<int> tree, int sum)
        {
            if (tree == null)
                return false;

            if (tree.IsLeaf)
                return tree.Value == sum;

            return PathSum1(tree.Left, sum - tree.Value) ||
                PathSum1(tree.Right, sum - tree.Value);
        }

        //https://leetcode.com/problems/path-sum-ii/description/
        public static IList<Stack<BinaryTreeNode<int>>> PathSum2(BinaryTreeNode<int> tree, int sum)
        {
            if (tree == null)
                return null;

            IList<Stack<BinaryTreeNode<int>>> stacks;
            if (tree.IsLeaf && tree.Value == sum)
            {
                stacks = new List<Stack<BinaryTreeNode<int>>>();
                stacks.Add(new Stack<BinaryTreeNode<int>>());
                stacks[0].Push(tree);
                return stacks;
            }

            var stacks1 = PathSum2(tree.Left, sum - tree.Value);
            var stacks2 = PathSum2(tree.Right, sum - tree.Value);

            IList<Stack<BinaryTreeNode<int>>> result = null;
            if (stacks1 != null)
            {
                result = stacks1;
            }
            if (stacks2 != null)
            {
                result = result == null ? stacks2 : result.Union(stacks2).ToList();
            }

            if (result != null)
            {
                foreach (var s in result)
                {
                    s.Push(tree);
                }
            }

            return result;
        }

        //https://leetcode.com/problems/word-break/description/
        public static bool WordBreak(IList<string> dictionary, string word)
        {
            return WordBreak(dictionary, word, new Dictionary<string, bool>());
        }

        private static bool WordBreak(IList<string> dictionary, string word, Dictionary<string, bool> memo)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            bool found;
            if (memo.TryGetValue(word, out found))
            {
                return found;
            }

            found = false;
            if (dictionary.Contains(word))
            {
                found = true;
            }
            else
            {
                for (int i = 0; i < word.Length; i++)
                {
                    string subStr = word.Substring(0, i + 1);
                    string remaining = word.Substring(i + 1);

                    if (dictionary.Contains(subStr))
                    {
                        found = WordBreak(dictionary, remaining);
                        break;
                    }
                }
            }
            memo.Add(word, found);
            return found;
        }

        // https://leetcode.com/problems/flatten-binary-tree-to-linked-list/description/
        public static void FlattenBinaryTreeToLinkedList<T>(BinaryTreeNode<T> tree) where T : IComparable
        {
            if (tree == null)
                return;
            var tmp = tree;
            var tmpRightChild = tree.Right;
            if (tree.Left != null)
            {
                FlattenBinaryTreeToLinkedList(tree.Left);
                tree.Right = tree.Left;
                tmp = tree.Left;
                while (tmp.Right != null)
                {
                    tmp = tmp.Right;
                }
                tree.Left = null;
            }

            if (tmpRightChild != null)
            {
                FlattenBinaryTreeToLinkedList(tmpRightChild);
                tmp.Right = tmpRightChild;
            }
        }

        // https://leetcode.com/problems/product-of-array-except-self/description/
        public static int[] ProductOfArrayExceptSelf(int[] a)
        {
            int n = a.Length;
            var result = new int[a.Length];
            result[0] = 1;

            for (int i = 1; i < n; i++)
            {
                result[i] = result[i - 1] * a[i - 1];
            }
            int right = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] = right * result[i];
                right = a[i] * right;
            }
            return result;
        }

        public static int[] ProductOfArrayExceptSelf2(int[] a)
        {
            int n = a.Length;
            var r1 = new int[n];

            r1[0] = 1;
            for (int i = 1; i < n; i++)
            {
                r1[i] = r1[i - 1] * a[i - 1];
            }

            var r2 = new int[n];
            r2[n - 1] = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                r2[i] = r2[i + 1] * a[i + 1];
            }
            for (int i = 0; i < n; i++)
            {
                r1[i] *= r2[i];
            }
            return r1;
        }

        // TODO: optimize
        //https://leetcode.com/problems/find-duplicate-subtrees/description/
        public static IList<BinaryTreeNode<int>> FindDuplicateSubTrees(BinaryTreeNode<int> tree)
        {
            var memo = new Dictionary<BinaryTreeNode<int>, string>();
            GenerateNodeTokens(tree, memo);
            Dictionary<string, bool> tokens = new Dictionary<string, bool>();
            var result = new List<BinaryTreeNode<int>>();
            foreach (var kvp in memo)
            {
                bool hasRead;
                if (tokens.TryGetValue(kvp.Value, out hasRead))
                {
                    if (!hasRead)
                    {
                        result.Add(kvp.Key);
                        tokens[kvp.Value] = true;
                    }
                }
                else
                {
                    tokens.Add(kvp.Value, false);
                }
            }
            return result;
        }

        internal static void GenerateNodeTokens(BinaryTreeNode<int> tree, Dictionary<BinaryTreeNode<int>, string> memo)
        {
            tree.PostOrderVisit(n =>
            {
                string token = $"({n.Value}";
                if (n.Left != null)
                {
                    token += memo[n.Left];
                }
                if (n.Right != null)
                {
                    token += memo[n.Right];
                }
                token += ")";
                memo.Add(n, token);
            });
        }
    }
}
