﻿using Problems.Basics;
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

        public static Tuple<int, int> FindInSorted2DArray_Zigzag(int[,] ary, int val)
        {
            int h = ary.GetLength(0);
            int w = ary.GetLength(1);

            int i = h - 1;
            int j = 0;
            while (i >= 0 && j < w)
            {
                var key = ary[i, j];
                if (key == val)
                    return Tuple.Create(i, j);
                if (key > val)
                {
                    i--;
                }
                else
                {
                    j++;
                }
            }
            return null;
        }

        // TODO
        public static Tuple<int, int> FindInSorted2DArray_Binary(int[,] ary, int val)
        {
            return null;
        }

        public static BinaryTreeNode<char> BuildTreeFromInOrderAndPreOrderTraverse(IList<char> preOrder, IList<char> inOrder)
        {
            if (preOrder == null || inOrder == null || preOrder.Count != inOrder.Count)
                throw new InvalidOperationException();

            if (preOrder.Count == 0)
                return null;

            var rootValue = preOrder[0];
            var root = new BinaryTreeNode<char> { Value = rootValue };
            int rootIndexInInOrder = inOrder.IndexOf(rootValue);

            IList<char> leftChildrenInOrder = inOrder.Take(rootIndexInInOrder).ToList();
            IList<char> rightChildrenInOrder = inOrder.Skip(rootIndexInInOrder + 1).ToList();
            IList<char> leftChildrenPreOrder = preOrder.Skip(1).Take(leftChildrenInOrder.Count).ToList();
            IList<char> rightChildrenPreOrder = inOrder.Skip(1).Skip(leftChildrenPreOrder.Count).ToList();

            var leftSubTree = BuildTreeFromInOrderAndPreOrderTraverse(leftChildrenPreOrder, leftChildrenInOrder);
            var rightSubTree = BuildTreeFromInOrderAndPreOrderTraverse(rightChildrenPreOrder, rightChildrenInOrder);
            root.LeftChild = leftSubTree;
            root.RightChild = rightSubTree;
            return root;
        }

        public static BinaryTreeNode<int> FindLowestCommonAncestor(BinaryTreeNode<int> root, int key1, int key2)
        {
            var path1 = root.SearchAndReturnPath(key1);
            if (path1 == null)
                return null;

            var path2 = root.SearchAndReturnPath(key2);
            if (path2 == null)
                return null;

            int j = 0;
            while (j < path1.Count && j < path2.Count)
            {
                if (!ReferenceEquals(path1[j], path2[j]))
                {
                    j--;
                    break;
                }
                j++;
            }
            return path1[j];
        }

        public static int FindNthSmallestInArray(int[] array, int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }

            var maxHeap = new Heap<int>(maxHeap: true);
            int i = 0;
            for (; i < n && i < array.Length; i++)
            {
                maxHeap.Insert(array[i]);
            }

            if (i < n)
                return -1;
            for (; i < array.Length; i++)
            {
                if (array[i] < maxHeap.PeekNext())
                {
                    maxHeap.TakeNext();
                    maxHeap.Insert(array[i]);
                }
            }
            return maxHeap.PeekNext();
        }

        /*
        The rotation can be performed in layers, where you perform a cyclic swap on the edges on each layer. 
        In the first for loop, we rotate the first layer (outermost edges). 
        We rotate the edges by doing a four-way swap first on the corners, then on the element clockwise from the edges, 
        then on the element three steps away.
        * */
        public static void RotateMatrix(int[,] m)
        {
            if (m == null || m.GetLength(0) != m.GetLength(1))
                throw new ArgumentException();
            int n = m.GetLength(0);
            for (int layer = 0; layer < n / 2; ++layer)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; ++i)
                {
                    int offset = i - first;
                    int top = m[first, i]; // save top
                    // left -> top
                    m[first, i] = m[last - offset, first];

                    // bottom -> left
                    m[last - offset, first] = m[last, last - offset];

                    // right -> bottom
                    m[last, last - offset] = m[i, last];

                    // top -> right
                    m[i, last] = top; // right <- saved top
                }
            }
        }

        // find the nth to last element of a singly linked list
        public static ListNode<T> FindNthToLastNode<T>(ListNode<T> head, int n)
        {
            if (head == null || n < 1)
                return null;

            var p1 = head;
            var p2 = head;
            for (int i = 0; i < n -1 ; i++)
            {
                if (p2 == null)
                    return null;
                p2 = p2.Next;
            }
            while (p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }
            return p1;
        }
    }
}
