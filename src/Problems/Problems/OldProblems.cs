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
    }
}
