using System;
using Problems.DataStructures;

namespace Problems.Basics
{
    public static class LinkedList
    {
        public static ListNode<T> FindMidNode<T>(ListNode<T> list)
        {
            if (list == null)
                return null;

            var pFast = list;
            var pSlow = list;
            while (pFast != null)
            {
                if (pFast.Next == null || pFast.Next.Next == null)
                {
                    break;
                }
                pFast = pFast.Next.Next;
                pSlow = pSlow.Next;
            }
            return pSlow;
        }

        public static ListNode<T> FindMerge<T>(ListNode<T> list1, ListNode<T> list2)
        {
            if (list1 == null || list2 == null)
                return null;
            int len1 = 0;
            int len2 = 0;
            ListNode<T> p1 = list1;
            ListNode<T> p2 = list2;

            while (p1 != null)
            {
                len1++;
                p1 = p1.Next;
            }
            while (p2 != null)
            {
                len2++;
                p2 = p2.Next;
            }
            if (p1 != p2)
                return null;

            var longList = len1 > len2 ? list1 : list2;
            var shortList = longList == list1 ? list2 : list1;
            for (int i = 0; i < Math.Abs(len1 - len2); i++)
            {
                longList = longList.Next;
            }
            while (longList != shortList)
            {
                longList = longList.Next;
                shortList = shortList.Next;
            }
            return longList;
        }

        public static ListNode<T> Reverse_Recursive<T>(ListNode<T> linkedList)
        {
            return Reverse_Recursive(linkedList, null);
        }

        private static ListNode<T> Reverse_Recursive<T>(ListNode<T> linkedList, ListNode<T> previous)
        {
            if (linkedList == null)
                return previous;

            var tmpNode = linkedList.Next;
            linkedList.Next = previous;
            return Reverse_Recursive(tmpNode, linkedList);
        }

        public static ListNode<T> Reverse_NonRecursive<T>(ListNode<T> linkedList)
        {
            ListNode<T> previous = null;
            while (linkedList != null)
            {
                ListNode<T> tmp = linkedList.Next;
                linkedList.Next = previous;
                previous = linkedList;
                linkedList = tmp;
            }

            return previous;
        }

        public static void AlternateLists<T>(ListNode<T> list1, ListNode<T> list2)
        {
            var p1 = list1;
            var p2 = list2;

            while (p1 != null && p2 != null)
            {
                var tmpP1 = p1.Next;
                var tmpp2 = p2.Next;

                p1.Next = p2;
                if (tmpP1 != null)
                {
                    p2.Next = tmpP1;
                }

                p1 = tmpP1;
                p2 = tmpp2;
            }
        }

        public static ListNode<T> AlternateLists_Recursive<T>(ListNode<T> l1, ListNode<T> l2)
        {
            if (l1 == null && l2 == null)
                return null;
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            var tmp1 = l1.Next;
            var tmp2 = l2.Next;

            l1.Next = l2;
            l2.Next = AlternateLists_Recursive(tmp1, tmp2);

            return l1;
        }

        public static ListNode<T> FindStartingNodeOfLoop<T>(ListNode<T> list1)
        {
            if (list1 == null || list1.Next == null)
                return null;

            var slowP = list1.Next;
            var fastP = list1.Next.Next;

            int cnt = 1;
            while (slowP != fastP)
            {
                slowP = slowP.Next;
                fastP = fastP?.Next?.Next;
                if (fastP == null)
                {
                    break;
                }
                cnt++;
            }
            if (fastP == null)
                return null;

            int cnt2 = 1;
            var tmp = slowP.Next;
            while (tmp != slowP)
            {
                tmp = tmp.Next;
                cnt2++;
            }

            ListNode<T> p1 = list1;
            ListNode<T> p2 = slowP;
            if (cnt > cnt2)
            {
                p1 = p1.GetNthNode(cnt - cnt2);
            }
            else
            {
                p2 = p2.GetNthNode(cnt2 - cnt);
            }

            while (p1 != p2)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }
            return p1;
        }

        public static ListNode<int> MergeTwoSortedLinkedList(ListNode<int> l1, ListNode<int> l2)
        {
            if (l1 == null && l2 == null)
                return null;
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            var p1 = l1;
            var p2 = l2;
            var head = p1.Value < p2.Value ? p1 : p2;

            var p = new ListNode<int> { Next = head, Value = int.MinValue };
            while (p1 != null && p2 != null)
            {
                if (p1.Value < p2.Value)
                {
                    p.Next = p1;
                    p1 = p1.Next;
                }
                else
                {
                    p.Next = p2;
                    p2 = p2.Next;
                }

                p = p.Next;
            }

            p.Next = p1 ?? p2;

            return head;
        }

        public static ListNode<int> MergeSort(ListNode<int> list)
        {
            if (list == null || list.Next == null)
                return list;
            var splited = SplitFromHalf(list);
            var left = MergeSort(splited.Item1);
            var right = MergeSort(splited.Item2);
            return MergeTwoSortedLinkedList(left, right);
        }

        private static Tuple<ListNode<int>, ListNode<int>> SplitFromHalf(ListNode<int> list)
        {
            if (list == null)
                return null;
            if (list.Next == null)
                return new Tuple<ListNode<int>, ListNode<int>>(list, null);

            ListNode<int> slow = list;
            ListNode<int> fast = list.Next;
            while (fast != null)
            {
                fast = fast.Next;
                if (fast != null)
                {
                    slow = slow.Next;
                    fast = fast.Next;
                }
            }
            var rightHead = slow.Next;
            slow.Next = null;
            return Tuple.Create(list, rightHead);
        }
    }
}
