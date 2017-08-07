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
        public static IntLinkedListNode AddTowNumbers(IntLinkedListNode n1, IntLinkedListNode n2)
        {
            IntLinkedListNode p1 = n1;
            IntLinkedListNode p2 = n2;
            IntLinkedListNode result = null;
            IntLinkedListNode resultRail = null;
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
                var newNode = new IntLinkedListNode { Value = sum };
                if (result == null)
                {
                    result = resultRail = newNode;
                }
                else
                {
                    resultRail.Next = newNode;
                    resultRail = newNode;
                }
                p1 = (IntLinkedListNode)p1?.Next;
                p2 = (IntLinkedListNode)p2?.Next;
            }
            return result;
        }

        // helper for AddTowNumbers
        public static IntLinkedListNode BuildLinkedListFromValue(int val)
        {
            if (val == 0)
            {
                return new IntLinkedListNode { Value = 0 };
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
            IntLinkedListNode root = null;
            while (tmpT > 0)
            {
                int p = (int)Math.Pow(10, tmpT - 1);
                int nodeVal = remaining / p;
                remaining = remaining % p;
                var node = new IntLinkedListNode { Value = nodeVal };
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
        public static int LinkedListToValue(IntLinkedListNode l)
        {
            IntLinkedListNode tmp = l;
            int result = 0;
            int t = 0;
            while (tmp != null)
            {
                result += (tmp.Value * (int)Math.Pow(10, t));
                tmp = (IntLinkedListNode)tmp.Next;
                t++;
            }
            return result;
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
    }
}
