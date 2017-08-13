using Problems.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public static class OldProblems
    {
        public static void FlipBinaryTree(BinaryTreeNode<int> tree)
        {
            if (tree == null || (tree.IsLeaf))
            {
                return;
            }
            var tempNode = tree.LeftChild;
            tree.LeftChild = tree.RightChild;
            tree.RightChild = tempNode;
            FlipBinaryTree(tree.LeftChild);
            FlipBinaryTree(tree.RightChild);
        }

        public static ListNode<T> FindMidNode<T>(ListNode<T> list)
        {
            if (list == null)
                return null;

            var fastPointer = list;
            var slowPointer = list;
            while (fastPointer != null)
            {
                if (fastPointer.Next == null || fastPointer.Next.Next == null)
                {
                    break;
                }
                fastPointer = fastPointer.Next.Next;
                slowPointer = slowPointer.Next;
            }
            return slowPointer;
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

            p1 = list1;
            p2 = list2;
            int n = Math.Abs(len1 - len2);
            for (int i = 0; i < n; i++)
            {
                if (len1 > len2)
                    p1 = p1.Next;
                else
                    p2 = p2.Next;
            }

            while (p1 != p2)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }
            return p1;
        }
    }
}
