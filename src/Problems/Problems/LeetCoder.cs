﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problems.DataStructures;
using Problems.Basics;

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

        public static string ZigZagConversion2(string s, int l)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                if (i != l / 2)
                {
                    for (int j = i; j < s.Length; j = j + l + 1)
                    {
                        builder.Append(s[j]);
                    }
                }
                else // the middle row
                {
                    if (l % 2 == 1)
                    {
                        for (int j = i; j < s.Length; j = j + l / 2 + 1)
                        {
                            builder.Append(s[j]);
                        }
                    }
                    else
                    {
                        int j = i;
                        int n = 0;
                        while (j < s.Length)
                        {
                            builder.Append(s[j]);
                            j = j + l / 2;
                            if (n % 2 == 1)
                                j = j + 1;
                            n++;
                        }
                    }
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

        public static IList<IList<int>> CombinationSum2(int[] numbers, int sum)
        {
            var preparedNumbers = CombinationSum_PrepareNumbers(numbers, sum);
            var rawResults = GetCombinationSum2(preparedNumbers, sum);
            var map = new Dictionary<string, IList<int>>();
            foreach (var l in rawResults)
            {
                map[string.Join(",", l.ToArray())] = l;
            }
            return map.Values.ToList();
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

        static IList<IList<int>> GetCombinationSum2(IList<int> a2, int sum)
        {

            var result = new List<IList<int>>();
            if (a2.Count == 0 || sum < 0)
                return result;

            if (a2[0] == sum)
            {
                result.Add(new List<int> { a2[0] });
                return result;
            }


            // a[0] is part of the set

            var r1 = GetCombinationSum2(a2.Skip(1).ToList(), sum - a2[0]);
            foreach (var list in r1)
            {
                list.Insert(0, a2[0]);
            }

            // a[0] is not part of the set
            var r2 = GetCombinationSum2(a2.Skip(1).ToList(), sum);

            return r1.Union(r2).ToList();
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
            if (string.IsNullOrEmpty(word))
                return false;

            bool found = false;
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
            return found;
        }

        // https://leetcode.com/problems/flatten-binary-tree-to-linked-list/description/
        public static BinaryTreeNode<T> FlattenBinaryTreeToLinkedList<T>(BinaryTreeNode<T> root) where T : IComparable
        {
            if (root == null)
                return null;

            var left = root.Left;
            var right = root.Right;
            root.Left = null;
            root.Right = left;

            BinaryTreeNode<T> leftTail = root;
            BinaryTreeNode<T> rightTail = root;
            if (left != null)
            {
                leftTail = FlattenBinaryTreeToLinkedList(left);
            }

            if (right != null)
            {
                rightTail = FlattenBinaryTreeToLinkedList(right);
                leftTail.Right = right;
            }

            return rightTail;
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

        //https://leetcode.com/problems/house-robber/description/
        public static int HouseRobber(IList<int> houseValues)
        {
            if (houseValues == null || houseValues.Count == 0)
                return 0;
            if (houseValues.Count == 1)
                return houseValues[0];

            int sum1 = houseValues[0] + HouseRobber(houseValues.Skip(2).ToList());
            int sum2 = houseValues[1] + HouseRobber(houseValues.Skip(3).ToList());
            return Math.Max(sum1, sum2);
        }

        //https://leetcode.com/problems/move-zeroes/description/
        public static void MoveZeros(int[] a)
        {
            if (a == null || a.Length == 0)
                return;

            // Shift non-zero values as far forward as possible
            // Fill remaining space with zeros
            int insertPos = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int n = a[i];
                if (n != 0)
                {
                    a[insertPos] = n;
                    insertPos++;
                }
            }

            while (insertPos < a.Length)
            {
                a[insertPos++] = 0;
            }
        }

        // https://leetcode.com/problems/group-anagrams/description/
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null)
                return null;
            var result = new List<IList<string>>();
            var map = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            foreach (var str in strs)
            {
                char[] charAry = str.ToCharArray();
                Array.Sort(charAry);
                string key = new string(charAry);
                List<string> group = null;
                if (!map.TryGetValue(key, out group))
                {
                    group = new List<string>();
                    map.Add(key, group);
                }
                group.Add(str);
            }
            foreach (var kvp in map)
            {
                result.Add(kvp.Value);
            }

            return result;
        }

        public static IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            if (strs == null)
                return null;
            var result = new List<IList<string>>();
            var map = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                string key = BuildAnagramKey(str);
                List<string> group = null;
                if (!map.TryGetValue(key, out group))
                {
                    group = new List<string>();
                    map.Add(key, group);
                }
                group.Add(str);
            }
            foreach (var kvp in map)
            {
                result.Add(kvp.Value);
            }

            return result;
        }

        private static string BuildAnagramKey(string s)
        {
            int[] charCounts = new int[26];
            foreach (var c in s.ToLowerInvariant())
            {
                int idx = c - 'a';
                charCounts[idx]++;
            }
            var keyBuilder = new StringBuilder();
            for (int i = 0; i < charCounts.Length; i++)
            {
                if (charCounts[i] != 0)
                {
                    keyBuilder.Append((char)i);
                    keyBuilder.Append(charCounts[i]);
                    keyBuilder.Append('_');
                }
            }
            return keyBuilder.ToString();
        }

        //https://leetcode.com/problems/word-search-ii/description/
        public static string[] WordSearch2(char[,] a, IList<string> dictionary)
        {
            var triedNode = TriesNode.CreateRootNode();
            foreach (var w in dictionary)
            {
                triedNode.AddWord(w.ToArray());
            }

            var result = new List<string>();
            int[,] memo = new int[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    TriesNode found = WordSearch2(i, j, triedNode, a, memo);
                    if (found != null)
                    {
                        result.Add(LeafTriedNodeToString(found));
                    }
                }
            }
            return result.ToArray();
        }

        private static TriesNode WordSearch2(int startRow, int startCol, TriesNode trie, char[,] a, int[,] memo)
        {
            char c = a[startRow, startCol];
            TriesNode next = trie.FindNextChar(c);
            if (next == null)
                return null;
            memo[startRow, startCol] = 1;
            if (next.ValidWordAtHere)
            {
                return next;
            }

            TriesNode found = null;
            if (startCol > 0 && memo[startRow, startCol - 1] == 0)
            {
                found = WordSearch2(startRow, startCol - 1, next, a, memo);
                if (found != null)
                    return found;
            }
            if (startRow > 0 && memo[startRow - 1, startCol] == 0)
            {
                found = WordSearch2(startRow - 1, startCol, next, a, memo);
                if (found != null)
                    return found;
            }
            if (startCol < a.GetLength(1) - 1 && memo[startRow, startCol + 1] == 0)
            {
                found = WordSearch2(startRow, startCol + 1, next, a, memo);
                if (found != null)
                    return found;
            }
            if (startRow < a.GetLength(0) - 1 && memo[startRow + 1, startCol] == 0)
            {
                found = WordSearch2(startRow + 1, startCol, next, a, memo);
                if (found != null)
                    return found;
            }

            memo[startRow, startCol] = 0;
            return null;
        }

        private static string LeafTriedNodeToString(TriesNode node)
        {
            var builder = new StringBuilder();
            var stack = new Stack<char>();
            var tmp = node;
            while (!TriesNode.IsRoot(tmp))
            {
                stack.Push(tmp.Value);
                tmp = tmp.Parent;
            }
            while (stack.Count > 0)
            {
                builder.Append(stack.Pop());
            }
            return builder.ToString();
        }

        // TODO
        //https://leetcode.com/problems/partition-to-k-equal-sum-subsets/description/
        public static bool CanPartitionKSubsets(int[] nums, int k)
        {


            return false;
        }

        // https://leetcode.com/problems/next-closest-time/description/
        public static string NextClosestTime(string time)
        {
            if (string.IsNullOrWhiteSpace(time) || time.Length != 5)
                throw new ArgumentException(nameof(time));

            int[] digits = new int[4]
            {
                int.Parse(time[0].ToString()),
                int.Parse(time[1].ToString()),
                int.Parse(time[3].ToString()),
                int.Parse(time[4].ToString()),
            };
            int inputHour = digits[0] * 10 + digits[1];
            int inputMin = digits[2] * 10 + digits[3];
            DateTime input = new DateTime(1900, 1, 1, inputHour, inputMin, 0);

            Func<int, int, bool> validHour = (i1, i2) => i1 * 10 + i2 <= 23;
            Func<int, int, bool> validMinute = (i1, i2) => i1 * 10 + i2 <= 59;

            int[] r = new int[4];
            var closestTime = DateTime.MaxValue;
            for (int i = 0; i < digits.Length; i++)
            {
                for (int j = 0; j < digits.Length; j++)
                {
                    if (!validHour(digits[i], digits[j]))
                        continue;

                    int newHour = digits[i] * 10 + digits[j];

                    for (int i1 = 0; i1 < digits.Length; i1++)
                    {
                        for (int j1 = 0; j1 < digits.Length; j1++)
                        {
                            // skip the input order
                            if (i == 0 && j == 1 && i1 == 2 && j1 == 3)
                                continue;

                            if (!validMinute(digits[i1], digits[j1]))
                                continue;
                            int newMin = digits[i1] * 10 + digits[j1];

                            var newDt = new DateTime(1900, 1, 1, newHour, newMin, 0);
                            if (newDt < input)
                            {
                                newDt = newDt.AddDays(1);
                            }
                            if (closestTime > newDt)
                            {
                                closestTime = newDt;
                                r[0] = digits[i];
                                r[1] = digits[j];
                                r[2] = digits[i1];
                                r[3] = digits[j1];
                            }
                        }
                    }
                }
            }

            return $"{r[0]}{r[1]}:{r[2]}{r[3]}";

            return null;
        }

        // https://leetcode.com/problems/swap-nodes-in-pairs/description/
        public static ListNode<int> SwapPairs(ListNode<int> list)
        {
            if (list == null)
                return null;
            if (list.Next == null)
                return list;
            var next = list.Next;
            var nextNext = list.Next.Next;

            next.Next = list;
            list.Next = SwapPairs(nextNext);
            return next;
        }

        // https://leetcode.com/problems/number-of-islands/description/
        public static int NumIslands(char[,] grid)
        {
            var n = grid.GetLength(0);
            var m = grid.GetLength(1);
            var memo = new bool[n, m];
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    bool b = NumIslands_Traverse(grid, memo, i, j);
                    if (b)
                        cnt++;
                }
            }
            return cnt;
        }

        private static bool NumIslands_Traverse(char[,] grid, bool[,] memo, int i, int j)
        {
            if (i >= grid.GetLength(0) || j < 0 || j >= grid.GetLength(1))
                return false;

            if (grid[i, j] != '1' || memo[i, j])
                return false;

            memo[i, j] = true;
            NumIslands_Traverse(grid, memo, i, j - 1);
            NumIslands_Traverse(grid, memo, i, j + 1);
            NumIslands_Traverse(grid, memo, i + 1, j);
            return true;
        }

        // https://leetcode.com/problems/ugly-number-ii/description/
        public static IEnumerable<int> NthUglyNumber(int n)
        {
            var vals = new List<int>() { };

            int iMax = (int)(Math.Log(n, 2)) + 1;
            int jMax = (int)(Math.Log(n, 3)) + 1;
            int kMax = (int)(Math.Log(n, 5)) + 1;
            for (int k = 0; k <= kMax; k++)
            {
                for (int j = 0; j <= jMax; j++)
                {
                    for (int i = 0; i <= iMax; i++)
                    {
                        int v = (int)(Math.Pow(5, k) * Math.Pow(3, j) * Math.Pow(2, i));
                        vals.Add(v);
                    }
                }
            }
            vals.Sort();
            return vals.Take(n);
        }

        public static IEnumerable<int> NthUglyNumber2(int n)
        {
            if (n == 1)
                yield return 1;
            yield return 1;
            int num = 2;
            int cnt = 1;
            while (cnt < n)
            {
                int tmp = num;
                num++;

                while (tmp % 5 == 0)
                {
                    tmp = tmp / 5;
                }
                if (tmp != 1)
                {
                    while (tmp % 3 == 0)
                    {
                        tmp = tmp / 3;
                    }
                    if (tmp != 1)
                    {
                        while (tmp % 2 == 0)
                        {
                            tmp = tmp / 2;
                        }
                        if (tmp != 1)
                        {
                            continue;
                        }
                    }
                }
                yield return num - 1;
                cnt++;
            }

            yield break;
        }
    }
}
