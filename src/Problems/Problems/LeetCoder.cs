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
                    newComobs.Add(sideLeft);
                    newComobs.Add(sideRight);
                }
            }
            return newComobs.ToArray();
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
    }
}
