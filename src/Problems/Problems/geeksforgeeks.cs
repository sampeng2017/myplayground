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

        // http://practice.geeksforgeeks.org/problems/subarray-with-given-sum/0
        public static Tuple<int, int> SubArrayWithGivenSum(int[] a, int sum)
        {
            var memo = new Dictionary<int, int>() { { 0, -1 } };
            var list = new List<Tuple<int, int>> { new Tuple<int, int>(0, -1) };
            int s = 0;
            for (int i = 0; i < a.Length; i++)
            {
                s += a[i];
                memo[s] = i;
                list.Add(Tuple.Create(s, i));
            }
            foreach (var tuple in list)
            {
                var lookUp = tuple.Item1 + sum;
                if (memo.ContainsKey(lookUp))
                {
                    return Tuple.Create(tuple.Item2 + 1, memo[lookUp]);
                }
            }
            return null;
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

        // http://practice.geeksforgeeks.org/problems/permutations-of-a-given-string/0
        public static IEnumerable<string> PermutationsOfString(string s)
        {
            if (s == null || s.Length == 0) return Enumerable.Empty<string>();

            var result = new List<string>();
            if (s.Length == 1)
            {
                result.Add(s);
            }
            else
            {
                string firstChar = s.Substring(0, 1);
                foreach (var item in PermutationsOfString(s.Substring(1)))
                {
                    var b = new StringBuilder(item);
                    for (int i = 0; i < item.Length; i++)
                    {
                        b.Insert(i, s[0]);
                        result.Add(b.ToString());
                        b.Remove(i, 1);
                    }

                    result.Add(b.Append(firstChar).ToString());
                }
            }
            return result;
        }

        public static IEnumerable<string> PermutationsOfString2(string s)
        {
            var result = new List<string>();
            PermutationsOfString2(s, 0, s.Length - 1, result);
            return result;
        }

        private static void PermutationsOfString2(string s, int l, int r, List<string> results)
        {
            if (l == r)
            {
                results.Add(s);
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    string str = SwapCharInString(s, l, i);
                    PermutationsOfString2(str, l + 1, r, results);
                    SwapCharInString(str, l, i); //backtrack
                }
            }
        }

        private static string SwapCharInString(string s, int p1, int p2)
        {
            var a = s.ToCharArray();
            char tmp = a[p1];
            a[p1] = a[p2];
            a[p2] = tmp;
            return new string(a);
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

        // http://practice.geeksforgeeks.org/problems/reverse-a-linked-list-in-groups-of-given-size/1
        public static ListNode<T> ReverseLinkedListInGroupsOfGivenSize<T>(ListNode<T> head, int group)
        {
            if (head == null)
                return null;

            var tmp = head;
            for (int i = 1; i < group && tmp.Next != null; i++)
            {
                tmp = tmp.Next;
            }

            var remamining = tmp.Next;
            tmp.Next = null;
            var newHead = LinkedList.Reverse_NonRecursive(head);
            // head is already the tail of reversed group
            head.Next = ReverseLinkedListInGroupsOfGivenSize(remamining, group);

            return newHead;
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
            memo.Add(0, new List<int> { -1 });
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

        // http://practice.geeksforgeeks.org/problems/activity-selection/0
        public static int ActivitySelection(IList<Tuple<int, int>> activities)
        {
            var orderedActivities = activities.OrderBy(a => a.Item2).ToList();
            return ActivitySelection(orderedActivities, 0);
        }

        private static int ActivitySelection(IList<Tuple<int, int>> orderedActivities, int startTime)
        {
            var nextActivity = orderedActivities.FirstOrDefault(a => a.Item1 >= startTime);
            if (nextActivity == null)
                return 0;
            orderedActivities.Remove(nextActivity);
            return 1 + ActivitySelection(orderedActivities, nextActivity.Item2);
        }


        // TODO: understand and re-write this
        //http://practice.geeksforgeeks.org/problems/longest-increasing-subsequence/0
        public static int LongestIncreasingSubsequence(int[] a)
        {
            int max = 1;
            LongestIncreasingSubsequence(a, a.Length, ref max);
            return max;
        }

        private static int LongestIncreasingSubsequence(int[] a, int n, ref int maxRef)
        {
            if (n == 1)
                return 1;

            // 'max_ending_here' is length of LIS ending with arr[n-1]
            int res, max_ending_here = 1;

            /* Recursively get all LIS ending with arr[0], arr[1] ...
               arr[n-2]. If   arr[i-1] is smaller than arr[n-1], and
               max ending with arr[n-1] needs to be updated, then
               update it */
            for (int i = 1; i < n; i++)
            {
                res = LongestIncreasingSubsequence(a, i, ref maxRef);
                if (a[i - 1] < a[n - 1] && res + 1 > max_ending_here)
                    max_ending_here = res + 1;
            }

            // Compare max_ending_here with the overall max. And
            // update the overall max if needed
            if (maxRef < max_ending_here)
                maxRef = max_ending_here;

            // Return length of LIS ending with arr[n-1]
            return max_ending_here;
        }

        //http://practice.geeksforgeeks.org/problems/find-the-element-that-appears-once-in-sorted-array/0
        public static int FindElementAppearsOnceInSortedArray_Xor(int[] a)
        {
            int result = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                result = result ^ a[i];
            }
            return result;
        }

        public static int FindElementAppearsOnceInSortedArray_Scan(int[] a)
        {
            int i = 1;
            for (; i < a.Length - 1; i = i + 2)
            {
                if (a[i] != a[i - 1])
                    break;
            }
            return a[i - 1];
        }

        public static int FindElementAppearsOnceInSortedArray_BS(int[] a, int p, int q)
        {
            if (q == p)
                return a[q];

            int m = p + (q - p) / 2;
            if (a[m] != a[m - 1] && a[m] != a[m + 1])
                return a[m];

            bool subTreeIsEven = m % 2 == 0;
            if (subTreeIsEven)
            {
                if (a[m] == a[m - 1])
                {
                    return FindElementAppearsOnceInSortedArray_BS(a, p, m);
                }
                else
                {
                    return FindElementAppearsOnceInSortedArray_BS(a, m, q);
                }
            }
            else
            {
                if (a[m] != a[m - 1])
                {
                    return FindElementAppearsOnceInSortedArray_BS(a, p, m - 1);
                }
                else
                {
                    return FindElementAppearsOnceInSortedArray_BS(a, m + 1, q);
                }
            }
        }

        // http://practice.geeksforgeeks.org/problems/bottom-view-of-binary-tree/1
        public static IList<BinaryTreeNode<int>> BottomViewOfBinaryTree(BinaryTreeNode<int> root)
        {
            var visitedNodes = new List<Tuple<int, int, BinaryTreeNode<int>>>();
            StampTreeNodeDistanceAndHeight(root, 0, 0, visitedNodes);


            return visitedNodes.OrderBy(t => t.Item1).Select(t => t.Item3).ToList();
        }

        private static void StampTreeNodeDistanceAndHeight(BinaryTreeNode<int> tree, int distance, int height, List<Tuple<int, int, BinaryTreeNode<int>>> container)
        {
            if (tree == null)
                return;
            StampTreeNodeDistanceAndHeight(tree.LeftChild, distance - 1, height + 1, container);
            StampTreeNodeDistanceAndHeight(tree.RightChild, distance + 1, height + 1, container);

            //var sameDistanceUpperLayer = container.Where(t => t.Item1 == distance && t.Item2 < height).ToArray();
            //foreach (var toRemove in sameDistanceUpperLayer)
            //{
            //    container.Remove(toRemove);
            //}
            if (!container.Any(t => t.Item1 == distance))
            {
                container.Add(Tuple.Create(distance, height, tree));
            }
        }

        // http://practice.geeksforgeeks.org/problems/n-queen-problem/0
        public static IList<int[,]> NQueenProblem(int n)
        {
            var result = new List<int[,]>();

            int startRow = 0;
            while (startRow < n)
            {
                var board = new int[n, n];
                int row;
                bool done = PlaceQueens(board, 0, n, startRow, out row);
                if (!done)
                {
                    break;
                }
                result.Add(board);
                startRow = row + 1;
            }
            return result;
        }

        private static bool PlaceQueens(int[,] board, int queen, int n, int startRow, out int placedRow)
        {
            placedRow = -1;
            // will place the Queens one at a time, for column wise
            if (queen == n)
                //if we are here that means we have solved the problem
                return true;
            for (int row = startRow; row < n; row++)
            {
                // check if queen can be placed row,col
                if (CanPlace(board, row, queen))
                {
                    board[row, queen] = 1;

                    int tmp;
                    if (PlaceQueens(board, queen + 1, n, 0, out tmp))
                    {
                        placedRow = row;
                        return true;
                    }

                    //if we are here that means above placement didn't work
                    //BACKTRACK
                    board[row, queen] = 0;
                }
            }
            return false;
        }

        private static bool CanPlace(int[,] matrix, int row, int column)
        {
            // since we are filling one column at a time,
            // we will check if no queen is placed in that particular row
            for (int i = 0; i < column; i++)
            {
                if (matrix[row, i] == 1)
                {
                    return false;
                }
            }

            // we are filling one column at a time,so we need to check the upper and
            // diagonal as well
            // check upper diagonal
            for (int i = row, j = column; i >= 0 && j >= 0; i--, j--)
            {
                if (matrix[i, j] == 1)
                {
                    return false;
                }
            }

            // check lower diagonal
            for (int i = row, j = column; i < matrix.GetLength(0) && j >= 0; i++, j--)
            {
                if (matrix[i, j] == 1)
                {
                    return false;
                }
            }

            // if we are here that means we are safe to place Queen at row,column
            return true;

        }

        // http://practice.geeksforgeeks.org/problems/find-first-set-bit/0
        public static int FindFirstSetBit(int n)
        {
            int tmp = n;
            int cnt = 1;
            while (tmp % 2 == 0)
            {
                tmp = tmp / 2;
                cnt++;
            }
            return cnt;
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
