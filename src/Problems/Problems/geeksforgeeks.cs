using Problems.Basics;
using Problems.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public static class Geeksforgeeks
    {
        // http://practice.geeksforgeeks.org/problems/kadanes-algorithm/0
        public static int KadanesAlgorithm(int[] a)
        {
            if (a == null || a.Length == 0)
                throw new InvalidOperationException();

            if (a.Length == 1)
                return a[0];

            int maxEnd = a[0];
            int maxSoFar = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                int x = a[i];
                maxEnd = Math.Max(x, maxEnd + x);
                maxSoFar = Math.Max(maxEnd, maxSoFar);
            }
            return maxSoFar;
        }

        // http://practice.geeksforgeeks.org/problems/parenthesis-checker/0
        public static bool ParenthesisChecker(string s)
        {
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                if (ParenthesisHelper.IsOpenParenthesis(c))
                {
                    stack.Push(c);
                }
                else if (ParenthesisHelper.IsCloseParenthesis(c))
                {
                    if (stack.Count == 0)
                        return false;
                    var t = stack.Pop();
                    if (!ParenthesisHelper.ParenthesisMatch(t, c))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }

        // http://practice.geeksforgeeks.org/problems/next-larger-element/0
        public static int[] NextLargerElement_O_NSquare(int[] a)
        {
            if (a == null || a.Length == 0)
                return a;

            var result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                int key = a[i];
                result[i] = -1;

                int j = i + 1;
                for (; j < a.Length; j++)
                {
                    if (a[j] > key)
                    {
                        result[i] = a[j];
                        break;
                    }
                }
            }

            return result;
        }

        public static int[] NextLargerElement_O_N(int[] a)
        {
            if (a == null || a.Length == 0)
                return a;

            var result = new int[a.Length];

            var stack = new Stack<Tuple<int, int>>();

            int j = 1;
            stack.Push(Tuple.Create(a[0], 0));
            while (j < a.Length)
            {
                if (stack.Peek().Item1 < a[j])
                {
                    while (stack.Count > 0 && stack.Peek().Item1 < a[j])
                    {
                        var tmp = stack.Pop();
                        result[tmp.Item2] = a[j];
                    }
                }
                stack.Push(Tuple.Create(a[j], j));
                j++;
            }
            while (stack.Count > 0)
            {
                var tmp = stack.Pop();
                result[tmp.Item2] = -1;
            }
            return result;
        }

        // http://practice.geeksforgeeks.org/problems/left-view-of-binary-tree/1
        public static IList<BinaryTreeNode<int>> LeftViewOfBinaryTree(BinaryTreeNode<int> root)
        {
            if (root == null)
                return null;

            var result = new List<BinaryTreeNode<int>> { root };
            if (root.LeftChild != null)
            {
                var leftNodes = LeftViewOfBinaryTree(root.LeftChild);
                result.AddRange(leftNodes);
            }
            else if (root.RightChild != null)
            {
                var rightNodes = LeftViewOfBinaryTree(root.RightChild);
                result.AddRange(rightNodes);
            }

            return result;
        }

        // http://practice.geeksforgeeks.org/problems/find-median-in-a-stream/0
        public static IEnumerable<int> FindMedianInStream(IEnumerable<int> streamIn)
        {
            var heapSmall = new Heap<int>(maxHeap: true);
            var heapBig = new Heap<int>(maxHeap: false);
            foreach (int val in streamIn)
            {
                if (heapSmall.IsEmpty)
                {
                    heapSmall.Insert(val);
                    yield return val;
                }
                else
                {
                    if (val > heapSmall.PeekNext())
                    {
                        heapBig.Insert(val);
                    }
                    else
                    {
                        heapSmall.Insert(val);
                    }
                    //balance the heaps
                    if (heapSmall.Count - heapBig.Count > 1)
                    {
                        heapBig.Insert(heapSmall.GetNext());
                    }
                    else if (heapBig.Count - heapSmall.Count > 1)
                    {
                        heapSmall.Insert(heapBig.GetNext());
                    }

                    if (heapBig.Count == heapSmall.Count)
                    {
                        yield return (heapBig.PeekNext() + heapSmall.PeekNext()) / 2;
                    }
                    else if (heapBig.Count == heapSmall.Count + 1)
                    {
                        yield return heapBig.PeekNext();
                    }
                    else
                    {
                        yield return heapSmall.PeekNext();
                    }
                }
            }
        }

        // http://practice.geeksforgeeks.org/problems/flood-fill-algorithm/0
        public static void FloodFillAlgorithm(int[,] screen, int row, int col, int color)
        {
            if (row > screen.GetLength(0) - 1
                || col > screen.GetLength(1) - 1)
                return;

            var cellColor = screen[row, col];
            if (cellColor == color)
                return;
            FloodFillAlgorithm(screen, row, col, color, cellColor);
        }

        private static void FloodFillAlgorithm(int[,] screen, int row, int col, int color, int originalColor)
        {
            if (row > screen.GetLength(0) - 1
                || col > screen.GetLength(1) - 1)
                return;

            var cellColor = screen[row, col];
            if (originalColor != cellColor)
                return;

            screen[row, col] = color;
            FloodFillAlgorithm(screen, row - 1, col, color, originalColor);
            FloodFillAlgorithm(screen, row + 1, col, color, originalColor);
            FloodFillAlgorithm(screen, row, col - 1, color, originalColor);
            FloodFillAlgorithm(screen, row, col + 1, color, originalColor);
        }

        // http://practice.geeksforgeeks.org/problems/largest-subarray-with-0-sum/1
        public static int LargestSubarrayLenWithZeroSum(int[] a)
        {
            var memo = new Dictionary<int, List<int>>();
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
                if (memo.ContainsKey(sum))
                {
                    memo[sum].Add(i);
                }
                else
                {
                    memo.Add(sum, new List<int>() { i });
                }
            }
            var subStringInfo = memo.Values
                .Where(l => l.Count > 1)
                .OrderByDescending(l => l.Last() - l.First()).FirstOrDefault();
            if (subStringInfo == null)
            {
                return 0;
            }
            return subStringInfo.Last() - subStringInfo.First();
        }

        private class ParenthesisHelper
        {
            const char p1Open = '{';
            const char p1Close = '}';
            const char p2Open = '(';
            const char p2Close = ')';
            const char p3Open = '[';
            const char p3Close = ']';

            public static bool IsOpenParenthesis(char c)
            {
                return c == p1Open || c == p2Open || c == p3Open;
            }

            public static bool IsCloseParenthesis(char c)
            {
                return c == p1Close || c == p2Close || c == p3Close;
            }

            public static bool ParenthesisMatch(char open, char close)
            {
                return (open == p1Open && close == p1Close) ||
                    (open == p2Open && close == p2Close) ||
                    (open == p3Open && close == p3Close);
            }
        }
    }
}
