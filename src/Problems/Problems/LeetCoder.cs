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
        public static ListNode<int> AddTowNumbers(ListNode<int> n1, DataStructures.ListNode<int> n2)
        {
            ListNode<int> p1 = n1;
            ListNode<int> p2 = n2;
            ListNode<int> result = null;
            ListNode<int> resultRail = null;
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
                var newNode = new DataStructures.ListNode<int> { Value = sum };
                if (result == null)
                {
                    result = resultRail = newNode;
                }
                else
                {
                    resultRail.Next = newNode;
                    resultRail = newNode;
                }
                p1 = p1?.Next;
                p2 = p2?.Next;
            }
            return result;
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

        // TODO
        //https://leetcode.com/problems/median-of-two-sorted-arrays/description/
        public static int FindMediaOfTwoSortedArraies_SameSize(int[] ary1, int[] ary2)
        {
            throw new NotImplementedException();
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
            int reversed = 0;
            int sign = val < 0 ? -1 : 1;
            val = Math.Abs(val);
            while (val > 0)
            {
                if (reversed != 0 && int.MaxValue / reversed < 10)
                    return -1;

                reversed = reversed * 10 + val % 10;
                val = val / 10;
            }
            return reversed * sign;
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
            else if (sum == tree.Value)
                return false;

            bool subResut = false;
            if (tree.LeftChild != null)
                subResut = PathSum1(tree.LeftChild, sum - tree.Value);
            if (!subResut && tree.RightChild != null)
                subResut = PathSum1(tree.RightChild, sum - tree.Value);
            return subResut;
        }

        //https://leetcode.com/problems/path-sum-ii/description/
        public static IList<IList<int>> PathSum2(BinaryTreeNode<int> tree, int sum)
        {
            if (tree == null)
                return null;

            if (tree.IsLeaf)
            {
                if (tree.Value == sum)
                {
                    return new List<IList<int>> { new List<int> { tree.Value } };
                }
                else
                    return null;
            }
            else if (sum == tree.Value)
                return null;

            IList<IList<int>> subResult1 = null;
            IList<IList<int>> subResult2 = null;
            if (tree.LeftChild != null)
            {
                subResult1 = PathSum2(tree.LeftChild, sum - tree.Value);
                if (subResult1 != null)
                {
                    foreach (var tmp in subResult1)
                    {
                        tmp.Insert(0, tree.Value);
                    }
                }
            }
            if (tree.RightChild != null)
            {
                subResult2 = PathSum2(tree.RightChild, sum - tree.Value);
                if (subResult2 != null)
                {
                    foreach (var tmp in subResult2)
                    {
                        tmp.Insert(0, tree.Value);
                    }
                }
            }

            if (subResult1 != null && subResult2 != null)
                return subResult1.Union(subResult2).ToList();
            else if (subResult1 != null)
                return subResult1;
            else if (subResult2 != null)
                return subResult2;
            return null;
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
    }
}
