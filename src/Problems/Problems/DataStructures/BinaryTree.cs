using Problems.Basics;
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
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public bool IsLeaf => Left == null && Right == null;

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
            var left = Left == null ? "NIL" : Left.GetStringRepresentation();
            var right = Right == null ? "NIL" : Right.GetStringRepresentation();
            return $"{{{Value}; Left: {left}; Right: {right}}}";
        }

        public int GetLeafCount()
        {
            if (IsLeaf)
                return 1;
            int leafCount = 0;
            if (Left != null)
                leafCount += Left.GetLeafCount();
            if (Right != null)
                leafCount += Right.GetLeafCount();
            return leafCount;
        }

        public void InOrderVisit(Action<BinaryTreeNode<T>> visit)
        {
            Left?.InOrderVisit(visit);
            visit(this);
            Right?.InOrderVisit(visit);
        }

        public void PreOrderVisit(Action<BinaryTreeNode<T>> visit)
        {
            visit(this);
            Left?.PreOrderVisit(visit);
            Right?.PreOrderVisit(visit);
        }

        public void PostOrderVisit(Action<BinaryTreeNode<T>> visit)
        {
            Left?.PostOrderVisit(visit);
            Right?.PostOrderVisit(visit);
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
                // move down the left branch
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                // hit left most
                else
                {
                    current = stack.Pop();
                    if (!visit(current))
                        return;
                    current = current.Right;
                }
            }
        }

        public static void InOrderTraverseNoRecusive2(BinaryTreeNode<T> tree, Action<BinaryTreeNode<T>> visit)
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(tree);

            while (stack.Count == 0)
            {
                var n = stack.Peek();
                if (n != null)
                {
                    stack.Push(n.Left);
                }
                else
                {
                    // remove the null node
                    stack.Pop();

                    n = stack.Pop();
                    visit(n);
                    if (stack.Count > 0)
                        stack.Push(n.Right);
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
                    stack.Push(current.Right);
                    stack.Push(current.Left);
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
            var leftStack = SearchAndReturnPath(root.Left, key);
            if (leftStack != null)
            {
                leftStack.Push(root);
                return leftStack;
            }
            var rightStack = SearchAndReturnPath(root.Right, key);
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
                AreEquivlent(tree1.Left, tree2.Left) &&
                AreEquivlent(tree1.Right, tree2.Right);
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
                while (tmp.Left != null)
                {
                    tmp = tmp.Left;
                }
                return tmp.Value;
            }
        }

        public T MaxValue
        {
            get
            {
                var tmp = root;
                while (tmp.Right != null)
                {
                    tmp = tmp.Right;
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
                if (root.Left == null)
                    return null;
                return Find(root.Left, key);
            }
            else
            {
                if (root.Right == null)
                    return null;
                return Find(root.Right, key);
            }
        }

        private void Insert(BinaryTreeNode<T> root, BinaryTreeNode<T> node)
        {
            bool greater = node.Value.CompareTo(root.Value) >= 0;
            if (greater)
            {
                if (root.Right == null)
                {
                    root.Right = node;
                }
                else
                {
                    Insert(root.Right, node);
                }
            }
            else
            {
                if (root.Left == null)
                {
                    root.Left = node;
                }
                else
                {
                    Insert(root.Left, node);
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

        public static bool IsValidBsf2<T1>(BinaryTreeNode<T1> root, T1 minExclusive, T1 maxExclusive) where T1 : IComparable
        {
            if (root == null)
                return false;

            if (root.IsLeaf)
                return root.Value.CompareTo(minExclusive) > 0 && root.Value.CompareTo(maxExclusive) < 0;

            bool result = true;
            if (root.Left != null)
            {
                result = IsValidBsf2(root.Left, minExclusive, root.Value);
            }

            if (root.Right != null)
            {
                result = result && IsValidBsf2(root.Right, root.Value, maxExclusive);
            }

            return result;
        }

        public static BinaryTreeNode<T> BuildFromSortedArray(T[] sortedArray, int p, int q)
        {
            if (sortedArray == null || sortedArray.Length == 0 || p > q)
                return null;
            int mid = p + (q - p) / 2;
            var node = new BinaryTreeNode<T> { Value = sortedArray[mid] };
            if (p < mid)
            {
                node.Left = BuildFromSortedArray(sortedArray, p, mid - 1);
            }
            if (q > mid)
            {
                node.Right = BuildFromSortedArray(sortedArray, mid + 1, q);
            }

            return node;

        }
    }

    public class BinaryTreeNodeWithNextRightPointer<T>
    {
        public T Value { get; set; }
        public BinaryTreeNodeWithNextRightPointer<T> Left { get; set; }
        public BinaryTreeNodeWithNextRightPointer<T> Right { get; set; }
        public BinaryTreeNodeWithNextRightPointer<T> NextRight { get; set; }
    }
}
