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
    }
}
