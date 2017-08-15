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
    }
}
