using Problems.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DataStructures
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> LeftChild { get; set; }
        public BinaryTreeNode<T> RightChild { get; set; }

        public bool IsLeaf => LeftChild == null && RightChild == null;

        public override string ToString()
        {
            if (IsLeaf)
            {
                return $"{{{Value}(leaf)}}";
            }
            var left = LeftChild == null ? "NIL" : LeftChild.ToString();
            var right = RightChild == null ? "NIL" : RightChild.ToString();
            return $"{{{Value}; Left: {left}; Right: {right}}}";
        }

        public void InOrderVisit(Action<BinaryTreeNode<T>> visit)
        {
            LeftChild?.InOrderVisit(visit);
            visit(this);
            RightChild?.InOrderVisit(visit);
        }

        public static void InOrderVisitNoRecursion(BinaryTreeNode<T> tree, Action<BinaryTreeNode<T>> visit)
        {
            BinaryTreeNode<T> current = tree;
            var stack = new Stack<BinaryTreeNode<T>>();
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.LeftChild;
                }
                else
                {
                    current = stack.Pop();
                    visit(current);
                    current = current.RightChild;
                }
            }
        }
    }

    public class BinarySearchTree<T> where T : IComparable
    {
        private BinaryTreeNode<T> root;

        public BinaryTreeNode<T> Root => root;
        public void Insert(BinaryTreeNode<T> node)
        {
            if (root == null)
            {
                root = node;
                return;
            }
            Insert(root, node);
        }

        public BinaryTreeNode<T> Find(T key)
        {
            if (root == null) return null;
            return Find(root, key);
        }

        public BinaryTreeNode<T> Find(BinaryTreeNode<T> root, T key)
        {
            int compare = key.CompareTo(root.Value);
            if (compare == 0)
                return root;
            if (compare < 0)
            {
                if (root.LeftChild == null)
                    return null;
                return Find(root.LeftChild, key);
            }
            else
            {
                if (root.RightChild == null)
                    return null;
                return Find(root.RightChild, key);
            }
        }

        private void Insert(BinaryTreeNode<T> root, BinaryTreeNode<T> node)
        {
            bool greater = node.Value.CompareTo(root.Value) >= 0;
            if (greater)
            {
                if (root.RightChild == null)
                {
                    root.RightChild = node;
                }
                else
                {
                    Insert(root.RightChild, node);
                }
            }
            else
            {
                if (root.LeftChild == null)
                {
                    root.LeftChild = node;
                }
                else
                {
                    Insert(root.LeftChild, node);
                }
            }
        }
    }

}
