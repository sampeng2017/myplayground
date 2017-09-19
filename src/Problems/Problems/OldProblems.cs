using Problems.Basics;
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
            var tempNode = tree.Left;
            tree.Left = tree.Right;
            tree.Right = tempNode;
            FlipBinaryTree(tree.Left);
            FlipBinaryTree(tree.Right);
        }

        public static Tuple<int, int> FindInSorted2DArray(int[,] ary, int val)
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
            root.Left = leftSubTree;
            root.Right = rightSubTree;
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

            BinaryTreeNode<int> result = null;
            while (path1.Count > 0 && path2.Count > 0)
            {
                var p1 = path1.Pop();
                var p2 = path2.Pop();
                if (!ReferenceEquals(p1, p2))
                {
                    break;
                }
                result = p1;
            }
            return result;
        }

        public static int FindNthSmallestInArray(int[] array, int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }
            if (array.Length < n)
                return -1;

            var minHeap = new Heap<int>(array, maxHeap: false);
            for (int i = 0; i < n - 1; i++)
            {
                minHeap.TakeNext();
            }
            return minHeap.TakeNext();
        }

        public static int FindNthSmallestInArray_DivideConquer(int[] array, int n, int p, int q)
        {
            return Misc.RandomSelectNth(array, p, q, n);
        }

        public static int Partition(int[] a, int p, int q)
        {
            if (p == q)
                return p;

            var rand = new Random();
            var r = rand.Next(0, a.Length);
            Helpers.Exchange(a, r, a.Length - 1);
            int pivot = a[q];
            int i = p;
            int j = q - 1;

            while (true)
            {
                while (a[i] < pivot)
                {
                    i++;
                    if (i >= q)
                        break;
                }

                while (a[j] > pivot)
                {
                    j--;
                    if (j <= p)
                        break;
                }
                if (i >= j)
                    break;

                Helpers.Exchange(a, i, j);
            }
            Helpers.Exchange(a, i, q);
            return i;
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

            for (int i = 1; i < n; i++)
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

        public static int BinarySearch(int v, int[] a, int p, int q)
        {
            if (q < p)
                return -1;
            if (p == q)
                return p;

            int mid = p + (q - p + 1) / 2;

            if (a[mid] == v)
                return mid;
            else if (v < a[mid])
                return BinarySearch(v, a, p, mid - 1);
            else
                return BinarySearch(v, a, mid + 1, q);
        }
    }
}
