﻿using Problems.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DataStructures
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> LeftChild { get; set; }
        public BinaryTreeNode<T> RightChild { get; set; }

        public bool IsLeaf => LeftChild == null && RightChild == null;

        public override string ToString()
        {
            return Value?.ToString();
        }

        public string GetStringRepresentation()
        {
            if (IsLeaf)
            {
                return $"{{{Value}(leaf)}}";
            }
            var left = LeftChild == null ? "NIL" : LeftChild.GetStringRepresentation();
            var right = RightChild == null ? "NIL" : RightChild.GetStringRepresentation();
            return $"{{{Value}; Left: {left}; Right: {right}}}";
        }

        public int GetLeafCount()
        {
            if (IsLeaf)
                return 1;
            int leafCount = 0;
            if (LeftChild != null)
                leafCount += LeftChild.GetLeafCount();
            if (RightChild != null)
                leafCount += RightChild.GetLeafCount();
            return leafCount;
        }

        public void InOrderVisit(Action<BinaryTreeNode<T>> visit)
        {
            LeftChild?.InOrderVisit(visit);
            visit(this);
            RightChild?.InOrderVisit(visit);
        }

        public void PreOrderVisit(Action<BinaryTreeNode<T>> visit)
        {
            visit(this);
            LeftChild?.PreOrderVisit(visit);
            RightChild?.PreOrderVisit(visit);
        }

        public void PostOrderVisit(Action<BinaryTreeNode<T>> visit)
        {
            LeftChild?.PostOrderVisit(visit);
            RightChild?.PostOrderVisit(visit);
            visit(this);
        }

        public static void InOrderVisitNoRecursion(BinaryTreeNode<T> tree, Action<BinaryTreeNode<T>> visit)
        {
            InOrderVisitNoRecursion(tree, (n) => { visit(n); return true; });
        }

        internal static void InOrderVisitNoRecursion(BinaryTreeNode<T> tree, Func<BinaryTreeNode<T>, bool> visit)
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
                    if (!visit(current))
                        return;
                    current = current.RightChild;
                }
            }
        }

        public static void PreOrderVisitNoRecursion(BinaryTreeNode<T> tree, Action<BinaryTreeNode<T>> visit)
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(tree);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current != null)
                {
                    visit(current);
                    stack.Push(current.RightChild);
                    stack.Push(current.LeftChild);
                    current = current.LeftChild;
                }
            }
        }

        public Stack<BinaryTreeNode<T>> SearchAndReturnPath(T key)
        {
            return SearchAndReturnPath(this, key);
        }

        private static Stack<BinaryTreeNode<T>> SearchAndReturnPath(BinaryTreeNode<T> root, T key)
        {
            if (root == null)
                return null;

            if (root.Value.CompareTo(key) == 0)
            {
                var stack = new Stack<BinaryTreeNode<T>>();
                stack.Push(root);
                return stack;
            }
            var leftStack = SearchAndReturnPath(root.LeftChild, key);
            if (leftStack != null)
            {
                leftStack.Push(root);
                return leftStack;
            }
            var rightStack = SearchAndReturnPath(root.RightChild, key);
            if (rightStack != null)
            {
                rightStack.Push(root);
                return rightStack;
            }
            return null;
        }

        public static bool AreEquivlent(BinaryTreeNode<T> tree1, BinaryTreeNode<T> tree2)
        {
            if (tree1 == null && tree2 == null)
                return true;
            if (tree1 == null || tree2 == null)
                return false;

            return tree1.Value.CompareTo(tree2.Value) == 0 &&
                AreEquivlent(tree1.LeftChild, tree2.LeftChild) &&
                AreEquivlent(tree1.RightChild, tree2.RightChild);
        }
    }

    public class BinarySearchTree<T> where T : IComparable
    {
        private BinaryTreeNode<T> root;

        public BinaryTreeNode<T> Root => root;

        public T MinValue
        {
            get
            {
                var tmp = root;
                while (tmp.LeftChild != null)
                {
                    tmp = tmp.LeftChild;
                }
                return tmp.Value;
            }
        }

        public T MaxValue
        {
            get
            {
                var tmp = root;
                while (tmp.RightChild != null)
                {
                    tmp = tmp.RightChild;
                }
                return tmp.Value;
            }
        }
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

        private BinaryTreeNode<T> Find(BinaryTreeNode<T> root, T key)
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

        public static bool IsValidBsf(BinaryTreeNode<T> bsf)
        {
            if (bsf == null) return false;

            T previousValue = default(T);
            bool valueInitiated = false;
            bool isValid = true;
            BinaryTreeNode<T>.InOrderVisitNoRecursion(bsf,
                (n) =>
                {
                    var result = true;
                    if (valueInitiated)
                    {
                        if (n.Value.CompareTo(previousValue) < 0)
                            result = isValid = false;
                    }
                    else
                    {
                        previousValue = n.Value;
                        valueInitiated = true;
                    }
                    return result;
                });
            return isValid;
        }

        public static BinaryTreeNode<T> BuildFromSortedArray(T[] sortedArray, int p, int q)
        {
            if (sortedArray == null || sortedArray.Length == 0 || p > q)
                return null;
            int mid = p + (q - p) / 2;
            var node = new BinaryTreeNode<T> { Value = sortedArray[mid] };
            if (p < mid)
            {
                node.LeftChild = BuildFromSortedArray(sortedArray, p, mid - 1);
            }
            if (q > mid)
            {
                node.RightChild = BuildFromSortedArray(sortedArray, mid + 1, q);
            }

            return node;

        }
    }

}
