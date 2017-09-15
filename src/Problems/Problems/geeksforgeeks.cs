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
        public static Tuple<int, int> SubArrayWithGivenSum(int[] a, int s)
        {
            var map = new Dictionary<int, int>();
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
                map[sum] = i;
            }

            sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int d = s + sum;

                if (map.ContainsKey(d))
                {
                    return Tuple.Create(i, map[d]);
                }
                sum += a[i];
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

        // http://practice.geeksforgeeks.org/problems/sort-an-array-of-0s-1s-and-2s/0
        public static void SortArrayWithOnlyZeroOneAndTwo(int[] a)
        {
            // use count sort
            int[] cntAry = new int[3];
            foreach (var v in a)
            {
                cntAry[v]++;
            }

            int cpyStart = 0;
            for (int i = 0; i < cntAry.Length; i++)
            {
                int cnt = cntAry[i];
                for (int j = cpyStart; j < cpyStart + cnt; j++)
                {
                    a[j] = i;
                }
                cpyStart += cnt;
            }
        }

        // http://practice.geeksforgeeks.org/problems/equilibrium-point/0
        // return the index of Equilibrium Point of array
        public static int EquilibriumPoint(int[] a)
        {
            int l = 0;
            int h = a.Length - 1;
            int sumLow = 0;
            int sumHigh = 0;
            while (l < h)
            {
                if (sumLow == sumHigh)
                {
                    sumLow += a[l];
                    sumHigh += a[h];
                    l++;
                    h--;
                }
                else if (sumLow > sumHigh)
                {
                    sumHigh += a[h];
                    h--;
                }
                else
                {
                    sumLow += a[l];
                    l++;
                }
            }

            return sumHigh == sumLow && l == h ? l : -1;
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
                char firstChar = s[0];
                foreach (var item in PermutationsOfString(s.Substring(1)))
                {
                    var b = new StringBuilder(item);
                    for (int i = 0; i < item.Length; i++)
                    {
                        b.Insert(i, firstChar);
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

        // http://practice.geeksforgeeks.org/problems/longest-palindrome-in-a-string/0
        public static string LongestPalindromeSubString(string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            var memo = new Dictionary<string, bool>();
            return LongestPalindromeSubString(s, memo);
        }

        private static string LongestPalindromeSubString(string s, Dictionary<string, bool> memo)
        {
            if (IsPalindromeString(s, memo))
                return s;
            var s1 = LongestPalindromeSubString(s.Substring(1), memo);
            var s2 = LongestPalindromeSubString(s.Substring(0, s.Length - 1), memo);
            return s1.Length > s2.Length ? s1 : s2;
        }

        private static bool IsPalindromeString(string s, Dictionary<string, bool> memo)
        {
            if (s.Length <= 1)
                return true;

            bool yesNo;
            if (memo.TryGetValue(s, out yesNo))
            {
                return yesNo;
            }

            if (s[0] == s[s.Length - 1])
            {
                yesNo = IsPalindromeString(s.Substring(1, s.Length - 2), memo);
            }
            else
            {
                yesNo = false;
            }
            memo.Add(s, yesNo);
            return yesNo;
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

                for (int j = i + 1; j < a.Length; j++)
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

            var stack = new Stack<ItemInfo>();

            int j = 1;
            stack.Push(new ItemInfo { Value = a[0], Index = 0 });
            while (j < a.Length)
            {
                if (stack.Peek().Value < a[j])
                {
                    while (stack.Count > 0 && stack.Peek().Value < a[j])
                    {
                        var tmp = stack.Pop();
                        result[tmp.Index] = a[j];
                    }
                }
                stack.Push(new ItemInfo { Value = a[j], Index = j });
                j++;
            }
            while (stack.Count > 0)
            {
                var tmp = stack.Pop();
                result[tmp.Index] = -1;
            }
            return result;
        }

        private struct ItemInfo
        {
            public int Value { get; set; }
            public int Index { get; set; }
        }

        // http://practice.geeksforgeeks.org/problems/circular-tour/1
        // pumps: item1 = gas volumn, item2 = distance to next pump, in unit of gas
        public static int CircularTour(Tuple<int, int>[] pumps)
        {
            // gasDiff: a list of tuples where Item1 = (gas - distance) and Item2 = original index in array
            var gasDiff = pumps.Select((t, i) => Tuple.Create(t.Item1 - t.Item2, i)).ToArray();
            var sourceQueue = new Queue<Tuple<int, int>>(gasDiff);
            var calQueue = new Queue<Tuple<int, int>>();

            int currentGas = 0;

            while (sourceQueue.Count > 0)
            {
                var p = sourceQueue.Dequeue();
                calQueue.Enqueue(p);
                currentGas += p.Item1;

                if (currentGas < 0)
                {
                    while (calQueue.Count > 0)
                    {
                        var d = calQueue.Dequeue();
                        sourceQueue.Enqueue(d);

                        currentGas = currentGas - d.Item1;
                        if (currentGas >= 0)
                            break;
                    }
                    if (calQueue.Count == 0)
                    {
                        currentGas = 0;
                        if (sourceQueue.Peek() == gasDiff[0])
                            return -1;
                    }
                }
            }
            return calQueue.Dequeue().Item2;
        }

        // http://www.geeksforgeeks.org/connect-nodes-at-same-level/
        public static void ConnectNodesAtSameLevel(BinaryTreeNodeWithNextRightPointer<string> tree)
        {
            if (tree == null)
                return;
            var queue = new Queue<Tuple<BinaryTreeNodeWithNextRightPointer<string>, int>>();
            queue.Enqueue(Tuple.Create(tree, 0));

            BinaryTreeNodeWithNextRightPointer<string> lastVisitedNode = null;
            int lastVisitedLevel = 0;
            while (queue.Count > 0)
            {
                var tuple = queue.Dequeue();
                var node = tuple.Item1;
                var l = tuple.Item2;

                if (lastVisitedNode != null && lastVisitedLevel == l)
                {
                    lastVisitedNode.NextRight = node;
                }

                if (node.Left != null)
                    queue.Enqueue(Tuple.Create(node.Left, l + 1));
                if (node.Right != null)
                    queue.Enqueue(Tuple.Create(node.Right, l + 1));
                lastVisitedNode = node;
                lastVisitedLevel = l;
            }
        }

        public static void ConnectNodesAtSameLevel2(BinaryTreeNodeWithNextRightPointer<string> tree)
        {
            var q = new Queue<BinaryTreeNodeWithNextRightPointer<string>>();
            q.Enqueue(tree);

            // null marker to represent end of current level
            q.Enqueue(null);

            // Do Level order of tree using NULL markers
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                if (p != null)
                {
                    // next element in queue represents next 
                    // node at current Level 
                    p.NextRight = q.Peek();

                    // push left and right children of current
                    // node
                    if (p.Left != null)
                        q.Enqueue(p.Left);
                    if (p.Right != null)
                        q.Enqueue(p.Right);
                }

                // if queue is not empty, push NULL to mark 
                // nodes at this level are visited
                else if (q.Count > 0)
                    q.Enqueue(null);
            }
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
            // head is now the tail of reversed group
            head.Next = ReverseLinkedListInGroupsOfGivenSize(remamining, group);

            return newHead;
        }

        // http://practice.geeksforgeeks.org/problems/left-view-of-binary-tree/1
        public static IList<BinaryTreeNode<int>> LeftViewOfBinaryTree(BinaryTreeNode<int> root)
        {
            if (root == null)
                return null;

            var result = new List<BinaryTreeNode<int>> { root };
            if (root.Left != null)
            {
                var leftNodes = LeftViewOfBinaryTree(root.Left);
                result.AddRange(leftNodes);
            }
            else if (root.Right != null)
            {
                var rightNodes = LeftViewOfBinaryTree(root.Right);
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
                        heapBig.Insert(heapSmall.TakeNext());
                    }
                    else if (heapBig.Count - heapSmall.Count > 1)
                    {
                        heapSmall.Insert(heapBig.TakeNext());
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

        // TODO: refactor
        // http://practice.geeksforgeeks.org/problems/kth-largest-element-in-a-stream/0
        public static IEnumerable<int> KthLargestElementInStream(IEnumerable<int> stream, int k)
        {
            var minHeap = new Heap<int>(maxHeap: false);
            var result = new List<int>();
            int i = 0;
            var enumerator = stream.GetEnumerator();
            while (i < k && enumerator.MoveNext())
            {
                if (i < k - 1)
                {
                    result.Add(-1);
                }
                var val = enumerator.Current;
                minHeap.Insert(enumerator.Current);
                i++;
            }

            while (enumerator.MoveNext())
            {
                var tmp = minHeap.PeekNext();
                result.Add(tmp);
                var val = enumerator.Current;

                if (val > tmp)
                {
                    minHeap.TakeNext();
                    minHeap.Insert(val);
                }
            }
            while (minHeap.Count > k - 1)
            {
                result.Add(minHeap.TakeNext());
            }
            return result;
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

        // http://practice.geeksforgeeks.org/problems/array-subset-of-another-array/0
        // assume elements in both array are unique
        // this is acctually not the original question
        public static bool ArrayIsSubSequenceOfAnother(int[] ary, int[] another)
        {
            if (ary == null || another == null || ary.Length > another.Length)
                return false;
            int subLen = ary.Length;
            int subSum = ary.Sum();
            int i = 0;
            int j = subLen;
            int tmpSum = 0;
            while (i + subLen < another.Length)
            {
                if (i == 0)
                    tmpSum = another.Skip(i).Take(subLen).Sum();
                else
                {
                    tmpSum = tmpSum + another[i + subLen - 1] - another[i - 1];
                }
                if (tmpSum == subSum)
                    return true;
                i++;
            }
            return false;
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

        //http://practice.geeksforgeeks.org/problems/n-meetings-in-one-room/0
        public static int[] NMeetingsInOneRoom(IList<Tuple<int, int>> meetings)
        {
            var selections = new List<Tuple<int, int>>();
            var orderedMeetings = meetings.OrderBy(m => m.Item2).ToList();
            NMeetingsInOneRoom(orderedMeetings, 0, selections);
            var indexes = new List<int>();
            foreach (var m in selections)
            {
                indexes.Add(meetings.IndexOf(m));
            }
            return indexes.ToArray();
        }

        private static void NMeetingsInOneRoom(IList<Tuple<int, int>> orderedMeetings, int startTime, IList<Tuple<int, int>> selections)
        {
            var nextMeeting = orderedMeetings.FirstOrDefault(a => a.Item1 >= startTime);

            if (nextMeeting == null)
                return;
            selections.Add(nextMeeting);
            orderedMeetings.Remove(nextMeeting);
            NMeetingsInOneRoom(orderedMeetings, nextMeeting.Item2, selections);
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
            var visitedNodes = new SortedDictionary<int, Tuple<BinaryTreeNode<int>, int>>();
            StampTreeNodeDistanceAndHeight(root, 0, 0, visitedNodes);

            return visitedNodes.Select(t => t.Value.Item1).ToList();
        }

        private static void StampTreeNodeDistanceAndHeight(BinaryTreeNode<int> tree, int distance, int height, IDictionary<int, Tuple<BinaryTreeNode<int>, int>> container)
        {
            if (tree == null)
                return;

            StampTreeNodeDistanceAndHeight(tree.Left, distance - 1, height + 1, container);
            StampTreeNodeDistanceAndHeight(tree.Right, distance + 1, height + 1, container);
            if (!container.ContainsKey(distance) || container[distance].Item2 <= height)
                container[distance] = Tuple.Create(tree, height);
        }

        public static IList<BinaryTreeNode<int>> BottomViewOfBinaryTree2(BinaryTreeNode<int> root)
        {
            if (root == null)
                return null;
            var container = new SortedDictionary<int, BinaryTreeNode<int>>();
            var queue = new Queue<Tuple<BinaryTreeNode<int>, int>>();
            queue.Enqueue(Tuple.Create(root, 0));
            while (queue.Count > 0)
            {
                var tuple = queue.Dequeue();
                var node = tuple.Item1;
                var distance = tuple.Item2;
                container[distance] = node;
                if (node.Left != null)
                {
                    queue.Enqueue(Tuple.Create(node.Left, distance - 1));
                }
                if (node.Right != null)
                {
                    queue.Enqueue(Tuple.Create(node.Right, distance + 1));
                }
            }
            return container.Select(t => t.Value).ToList();
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

        //http://practice.geeksforgeeks.org/problems/rightmost-different-bit/0
        public static int RightmostDifferentBit(int i1, int i2)
        {
            int t1 = i1;
            int t2 = i2;
            int cnt = 1;

            // if one of t1 or t2 is 0, we should continue the loop
            // until the first non-zero is hit for the bigger number
            while (t1 > 0 || t2 > 0)
            {
                if (t1 % 2 != t2 % 2)
                {
                    break;
                }
                t1 = t1 / 2;
                t2 = t2 / 2;
                cnt++;
            }
            return cnt;
        }

        // http://practice.geeksforgeeks.org/problems/rearrange-characters/0
        public static string ReArrangeChars(string s)
        {
            var maxHeap = new Heap<CharWithFrquency>();
            var a = s.ToCharArray();
            var countMap = new Dictionary<char, int>();

            bool hasDuplicate = false;
            foreach (var c in a)
            {
                if (!countMap.ContainsKey(c))
                    countMap.Add(c, 1);
                else
                {
                    countMap[c]++;
                    hasDuplicate = true;
                }
            }
            if (!hasDuplicate)
                return s;

            foreach (var kvp in countMap)
            {
                maxHeap.Insert(new CharWithFrquency { Char = kvp.Key, Frquency = kvp.Value });
            }

            var strBuilder = new StringBuilder();
            var prev = new CharWithFrquency { Char = '$', Frquency = -1 };
            while (!maxHeap.IsEmpty)
            {
                var next = maxHeap.TakeNext();

                strBuilder.Append(next.Char);
                next.Frquency--;
                if (prev.Frquency > 0)
                {
                    maxHeap.Insert(prev);
                }
                prev = next;
            }
            if (prev.Frquency > 0)
                return null;
            return strBuilder.ToString();
        }

        // http://www.geeksforgeeks.org/find-a-pair-swapping-which-makes-sum-of-two-arrays-same/
        public static Tuple<int, int> SwappingPairMakeSumEqual(int[] a1, int[] a2)
        {
            int sum1 = a1.Sum();
            int sum2 = a2.Sum();
            if ((sum1 - sum2) % 2 != 0)
                return null;

            int delta = (sum1 - sum2) / 2;

            // if the diff is not even number, there is no solution swaping numbers from two arrays.
            if (delta % 2 != 0)
                return null;
            var hashSet = new HashSet<int>(a1.Distinct());
            foreach (int i in a2)
            {
                int key = i + delta;

                if (hashSet.Contains(key))
                {
                    return Tuple.Create(key, i);
                }
            }
            return null;
        }

        // http://www.geeksforgeeks.org/select-a-random-node-from-a-singly-linked-list/
        // Reservoir Sampling
        public static ListNode<int> SelectARandomNodeFromLinkedList(ListNode<int> head)
        {
            if (head == null) return null;

            var selection = head;
            var rand = new Random();
            int i = 1;
            var tmp = head;
            while (tmp != null)
            {
                int j = rand.Next(1 + i);
                if (j == 0)
                {
                    selection = tmp;
                }
                tmp = tmp.Next;
                i++;
            }
            return selection;
        }

        // http://www.geeksforgeeks.org/check-binary-tree-subtree-another-binary-tree-set-2/
        // reference LeetCoder.FindDuplicateSubTrees
        // TODO: use in-order + preOrder sequence to implement
        public static bool CheckBinaryTreeSubTreeOfAnother(BinaryTreeNode<int> t1, BinaryTreeNode<int> t2)
        {
            if (t1 == null || t2 == null)
                return false;
            var map1 = new Dictionary<BinaryTreeNode<int>, string>();
            var map2 = new Dictionary<BinaryTreeNode<int>, string>();

            LeetCoder.GenerateNodeTokens(t1, map1);
            LeetCoder.GenerateNodeTokens(t2, map2);

            var hashSet1 = new HashSet<string>(map1.Values);
            var hashSet2 = new HashSet<string>(map2.Values);
            return hashSet1.Contains(map2[t2]) ||
                hashSet2.Contains(map1[t1]);
        }

        // http://practice.geeksforgeeks.org/problems/edit-distance/0
        public static int EditDistance(string s1, string s2)
        {
            var memo = new int[s1.Length + 1, s2.Length + 1];
            return EditDistance(s1, s2, s1.Length, s2.Length, memo);
        }

        private static int EditDistance(string s1, string s2, int m, int n, int[,] memo)
        {
            int result;
            if (memo[m, n] > 0)
            {
                return memo[m, n];
            }

            if (m == 0)
            {
                return n;
            }
            if (n == 0)
            {
                return m;
            }

            char c1 = s1[m - 1];
            char c2 = s2[n - 1];

            if (c1 == c2)
            {
                result = EditDistance(s1, s2, m - 1, n - 1, memo);
            }
            else
            {
                // insert c1
                int cnt1 = EditDistance(s1, s2, m, n - 1, memo);
                // remove c1
                int cnt2 = EditDistance(s1, s2, m - 1, n, memo);
                // replace
                int cnt3 = EditDistance(s1, s2, m - 1, n - 1, memo);
                result = 1 + Math.Min(cnt1, Math.Min(cnt2, cnt3));
            }
            memo[m, n] = result;
            return result;
        }

        private static string EditDistance_MakeKeys(string s1, string s2)
        {
            // assuming ~ not in text, otherwise find a non print-able char
            return $"{s1}~{s2}";
        }

        //http://practice.geeksforgeeks.org/problems/solve-the-sudoku/0
        public static int[,] SolveSudoku(int[,] sudoku)
        {
            var s = new Sudoku(sudoku);
            if (s.Solve())
                return s.Numbers;
            return null;
        }

        // http://practice.geeksforgeeks.org/problems/special-keyboard/0
        public static long SpecialKeyboard(int keyCount)
        {
            return CharCountWithSpecialKeyboard(keyCount, 0, 0, new Dictionary<Tuple<int, int, int>, long>());
        }

        private static long CharCountWithSpecialKeyboard(int keyCount,
            int charOnScreen,
            int charInBuffer,
            Dictionary<Tuple<int, int, int>, long> memo)
        {
            if (keyCount == 0)
                return charOnScreen;

            var key = Tuple.Create(keyCount, charOnScreen, charInBuffer);
            long result;
            if (memo.TryGetValue(key, out result))
                return result;

            // type A only if nothing in buffer
            long cnt1 = charInBuffer > 0 ?
                0 :
                CharCountWithSpecialKeyboard(keyCount - 1, charOnScreen + 1, charInBuffer, memo);

            // ctrl A + C + V
            long cnt2 = keyCount > 3 && charOnScreen > 0 ?
                CharCountWithSpecialKeyboard(keyCount - 3, charOnScreen * 2, charOnScreen, memo) :
                0;
            // ctrl V
            long cnt3 = charInBuffer > 0 ?
                CharCountWithSpecialKeyboard(keyCount - 1, charOnScreen + charInBuffer, charInBuffer, memo)
                : 0;

            result = Math.Max(cnt3, Math.Max(cnt2, cnt1));
            memo.Add(key, result);
            return result;
        }

        // http://www.geeksforgeeks.org/dynamic-programming-subset-sum-problem/
        public static bool IsSubsetSum(int[] a, int n, int sum)
        {
            if (n > 0 && sum == 0)
                return true;
            if (n == 0)
                return false;

            var key = Tuple.Create(n, sum);
            bool result;

            result = IsSubsetSum(a, n - 1, sum);
            if (!result)
            {
                result = IsSubsetSum(a, n - 1, sum - a[n - 1]);
            }
            return result;
        }

        // TODO: understand this
        //http://www.geeksforgeeks.org/sliding-window-maximum-maximum-of-all-subarrays-of-size-k/
        public static int[] SlidingWindowMaxOfAllSubArraysWithSizeK(int[] a, int k)
        {
            if (a == null || k <= 0 || a.Length < k)
                throw new ArgumentException();

            var dequeue = new LinkedList<int>();
            var result = new List<int>();

            int i = 0;
            for (; i < k; i++)
            {
                while (dequeue.Count > 0 && a[i] > a[dequeue.Last.Value])
                {
                    dequeue.RemoveLast();
                }
                dequeue.AddLast(i);
            }

            // Process rest of the elements, i.e., from arr[k] to arr[n-1]
            for (; i < a.Length; i++)
            {
                // The element at the front of the queue is the largest element of
                // previous window
                result.Add(a[dequeue.First.Value]);

                // Remove the elements which are out of this window
                while ((dequeue.Count > 0) && dequeue.First.Value <= i - k)
                    dequeue.RemoveFirst();

                // Remove all elements smaller than the currently
                // being added element (remove useless elements)
                while ((dequeue.Count > 0) && a[i] >= a[dequeue.Last.Value])
                    dequeue.RemoveLast();

                dequeue.AddLast(i);
            }
            result.Add(a[dequeue.First.Value]);
            return result.ToArray();
        }

        // http://www.geeksforgeeks.org/convert-a-given-binary-tree-to-doubly-linked-list-set-4/
        public static Tuple<BinaryTreeNode<T>, BinaryTreeNode<T>> ConvertBinaryTreeToDoublyLinkedList<T>(BinaryTreeNode<T> treeNode) where T : IComparable
        {
            if (treeNode.IsLeaf)
                return Tuple.Create(treeNode, treeNode);

            Tuple<BinaryTreeNode<T>, BinaryTreeNode<T>> leftResult = null;
            if (treeNode.Left != null)
            {
                leftResult = ConvertBinaryTreeToDoublyLinkedList(treeNode.Left);
            }

            Tuple<BinaryTreeNode<T>, BinaryTreeNode<T>> rightResult = null;
            if (treeNode.Right != null)
            {
                rightResult = ConvertBinaryTreeToDoublyLinkedList(treeNode.Right);
            }
            BinaryTreeNode<T> head = treeNode;
            BinaryTreeNode<T> tail = treeNode;

            treeNode.Right = leftResult?.Item2;
            if (leftResult != null)
            {
                leftResult.Item2.Left = treeNode;
                head = leftResult.Item1;
            }

            treeNode.Left = rightResult?.Item1;
            if (rightResult != null)
            {
                rightResult.Item1.Right = treeNode;
                tail = rightResult.Item2;
            }

            return Tuple.Create(head, tail);
        }

        #region facebook
        // http://practice.geeksforgeeks.org/problems/maximum-integer-value/0
        public static long MaxIntegerValue(string s)
        {
            int[] digitArray = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                digitArray[i] = s[i] - '0';
            }

            return MaxIntegerValue(digitArray, 0, digitArray.Length - 1);
        }

        private static long MaxIntegerValue(int[] a, int p, int q)
        {
            if (p > q)
                throw new InvalidOperationException();

            if (p == q)
                return a[p];

            long resultWithPlus = a[q] + MaxIntegerValue(a, p, q - 1);
            long resultWithMultiply = a[q] * MaxIntegerValue(a, p, q - 1);

            return Math.Max(resultWithPlus, resultWithMultiply);
        }

        // http://practice.geeksforgeeks.org/problems/bird-and-maximum-fruit-gathering/0
        public static int BirdAndMaxFruitGathering(int[] trees, int time)
        {
            if (trees.Length < time)
                return trees.Sum();

            int maxSum = 0;
            int sum = 0;

            for (int i = 0; i < time; i++)
            {
                sum += trees[i];
            }

            maxSum = sum;
            for (int j = time; j < trees.Length + time; j++)
            {
                // this is imporatnat
                int newItemIndex = j % trees.Length;
                int takeAwayItemIndex = j - time;

                sum = sum + trees[newItemIndex] - trees[takeAwayItemIndex];
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
            return maxSum;
        }

        public static int BirdAndMaxFruitGathering_LinkedList(int[] trees, int time)
        {
            if (trees == null || trees.Length == 0 || time == 0)
                return 0;

            // build a loop linked list (tail -> head)
            var head = new ListNode<int> { Value = trees[0] };
            var previous = head;
            for (int i = 1; i < trees.Length; i++)
            {
                previous.Next = new ListNode<int> { Value = trees[i] };
                previous = previous.Next;
            }
            previous.Next = head;

            //collect fruits from first node
            var resultFromFirst = BirdAndMaxFruitGathering_Collect(head, time);

            // single tree scenario
            if (resultFromFirst.Item2 == head)
                return resultFromFirst.Item1;

            int max = resultFromFirst.Item1;
            int previousResult = resultFromFirst.Item1;
            var previousHead = head;
            var previousTail = resultFromFirst.Item2;

            while (previousHead.Next != head)
            {
                int tmpResult = previousResult - previousHead.Value + previousTail.Next.Value;
                max = Math.Max(max, tmpResult);
                previousResult = tmpResult;

                previousHead = previousHead.Next;
                previousTail = previousTail.Next;
            }
            return max;
        }

        // pick each tree until time is running out or looped back to head, return total fruits and 
        // the last tree visited.
        private static Tuple<int, ListNode<int>> BirdAndMaxFruitGathering_Collect(ListNode<int> head, int time)
        {
            var p = head;

            int total = p.Value;
            time = time - 1;
            while (p.Next != head && time > 0)
            {
                p = p.Next;
                total += p.Value;
                time -= 1;
            }
            return Tuple.Create(total, p);
        }

        // http://practice.geeksforgeeks.org/problems/rearrange-a-string/0
        public static string RearrangeString(string s)
        {
            int sum = 0;
            var charCounter = new int['Z' - 'A' + 1];

            // Count sort
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    sum += c - '0';
                }
                else
                {
                    charCounter[c - 'A']++;
                }
            }

            var strBuilder = new StringBuilder();
            for (int i = 0; i < charCounter.Length; i++)
            {
                int cnt = charCounter[i];
                if (cnt > 0)
                {
                    var c = (char)(i + 'A');
                    strBuilder.Append(c, cnt);
                }
            }
            strBuilder.Append(sum.ToString());
            return strBuilder.ToString();
        }

        //http://practice.geeksforgeeks.org/problems/largest-sum-subarray-of-size-at-least-k/0
        public static int LargestSumSubArrayOfSizeAtLeastK(int[] a, int k)
        {
            // maxSum[i] is going to store maximum sum
            // till index i such that a[i] is part of the
            // sum.
            int n = a.Length;
            var maxSum = new int[n];
            maxSum[0] = a[0];

            // We use Kadane's algorithm to fill maxSum[]
            // Below code is taken from method 3 of
            // http://www.geeksforgeeks.org/largest-sum-contiguous-subarray/
            int curr_max = a[0];
            for (int i = 1; i < n; i++)
            {
                curr_max = Math.Max(a[i], curr_max + a[i]);
                maxSum[i] = curr_max;
            }

            // Sum of first k elements
            int sum = 0;
            for (int i = 0; i < k; i++)
                sum += a[i];

            // Use the concept of sliding window
            int result = sum;
            for (int i = k; i < n; i++)
            {
                // Compute sum of k elements ending
                // with a[i].
                sum = sum + a[i] - a[i - k];

                // Update result if required
                result = Math.Max(result, sum);

                // Include maximum sum till [i-k] also
                // if it increases overall max.
                result = Math.Max(result, sum + maxSum[i - k]);
            }
            return result;
        }

        // http://practice.geeksforgeeks.org/problems/string-palindromic-ignoring-spaces/0
        public static bool IsStringPalindromicIgnoreSpaces(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return true;
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                if (char.IsWhiteSpace(s[i]))
                {
                    i++;
                }
                else if (char.IsWhiteSpace(s[j]))
                {
                    j--;
                }
                else
                {
                    if (s[i] != s[j])
                        return false;
                    i++;
                    j--;
                }
            }
            return true;
        }

        // http://practice.geeksforgeeks.org/problems/convert-ternary-expression-to-binary-tree/1
        public static BinaryTreeNode<char> ConvertTernaryExpressionToBinaryTree(string ternaryExpr)
        {
            // TODO not working. need to use operator precendence
            if (string.IsNullOrEmpty(ternaryExpr))
                return null;

            var operatorStack = new Stack<char>();
            var operandStack = new Stack<BinaryTreeNode<char>>();

            BinaryTreeNode<char> root = null;
            foreach (char c in ternaryExpr.Where(v => !char.IsWhiteSpace(v)))
            {
                if (c == '?' || c == ':')
                {
                    operatorStack.Push(c);
                }
                else
                {
                    var node = new BinaryTreeNode<char> { Value = c };
                    if (operatorStack.Count == 0)
                    {
                        operandStack.Push(node);
                    }
                    else
                    {
                        if (operatorStack.Peek() == '?')
                        {
                            operandStack.Push(node);
                        }
                        else
                        {
                            var tmpOp = operatorStack.Pop();
                            var leftNode = operandStack.Pop();
                            tmpOp = operatorStack.Pop();
                            root = operandStack.Pop();
                            root.Left = leftNode;
                            root.Right = node;
                            operandStack.Push(root);
                        }
                    }
                }
            }

            return root;
        }

        // http://practice.geeksforgeeks.org/problems/multiply-two-strings/1
        public static string MultiplyTwoStrings(string s1, string s2)
        {
            var num1 = s1.Select(c => (byte)(c - '0')).ToArray();
            var num2 = s2.Select(c => (byte)(c - '0')).ToArray();

            var result = MultiplyTwoNumbers(num1, num2);

            var builder = new StringBuilder();

            for (int i = result.Length - 1; i >= 0; i--)
            {
                var n = result[i];
                if (i == result.Length - 1 && n == 0)
                    continue;
                builder.Append(n);
            }
            return builder.ToString();
        }

        public static int[] MultiplyTwoNumbers(byte[] num1, byte[] num2)
        {
            int[] result = new int[num1.Length + num2.Length];

            // Below two indexes are used to find positions
            // in result. 
            int i1 = 0;
            int i2 = 0;

            // Go from right to left in num1
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int carry = 0;
                int n1 = num1[i];

                // To shift position to left after every
                // multiplication of a digit in num2
                i2 = 0;

                // Go from right to left in num2             
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    // Take current digit of second number
                    int n2 = num2[j];

                    // Multiply with current digit of first number
                    // and add result to previously stored result
                    // at current position. 
                    int sum = n1 * n2 + result[i1 + i2] + carry;

                    // Carry for next iteration
                    carry = sum / 10;

                    // Store result
                    result[i1 + i2] = sum % 10;

                    i2++;
                }
                // store carry in next cell
                if (carry > 0)
                    result[i1 + i2] += carry;

                // To shift position to left after every
                // multiplication of a digit in num1.
                i1++;
            }
            return result;
        }

        #endregion
        private class Sudoku
        {
            private int[,] sudoku;
            private int[,] solved;
            public Sudoku(int[,] sudoku)
            {
                if (sudoku == null || sudoku.GetLength(0) != 9 || sudoku.GetLength(1) != 9)
                    throw new ArgumentException();

                this.sudoku = sudoku;
                this.solved = new int[9, 9];
                Array.Copy(sudoku, solved, sudoku.Length);
            }

            public int[,] Numbers => solved;

            public bool Solve()
            {
                return Solve(this.solved);
            }

            private static bool Solve(int[,] sudoku)
            {
                int nextRow = -1;
                int nextCol = -1;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (sudoku[i, j] == 0)
                        {
                            nextRow = i;
                            nextCol = j;
                            break;
                        }
                    }
                }
                if (nextRow == -1)
                    return true;

                var candidates = FindSolutionCandidates(sudoku, nextRow, nextCol);
                foreach (var c in candidates)
                {
                    sudoku[nextRow, nextCol] = c;
                    if (Solve(sudoku))
                    {
                        break;
                    }
                    sudoku[nextRow, nextCol] = 0;
                }

                return sudoku[nextRow, nextCol] != 0;
            }

            private static IList<int> FindSolutionCandidates(int[,] sudoku, int row, int col)
            {
                var candidates = new int[10];
                for (int i = 0; i < 9; i++)
                {
                    if (sudoku[row, i] != 0)
                        candidates[sudoku[row, i]] = 1;
                }
                for (int i = 0; i < 9; i++)
                {
                    if (sudoku[i, col] != 0)
                        candidates[sudoku[i, col]] = 1;
                }

                int smallSqureRow = (row / 3) * 3;
                int smallSqureCol = (col / 3) * 3;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (sudoku[smallSqureRow + i, smallSqureCol + j] != 0)
                            candidates[sudoku[smallSqureRow + i, smallSqureCol + j]] = 1;
                    }
                }

                var result = new List<int>();
                for (int i = 1; i < 10; i++)
                {
                    if (candidates[i] == 0)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }

            private static bool CanSetValue(int[,] sudoku, int row, int col, int val)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (sudoku[row, i] == val)
                        return false;
                }
                for (int i = 0; i < 9; i++)
                {
                    if (sudoku[i, col] == val)
                        return false;
                }
                int smallSqureRow = (row / 3) * 3;
                int smallSqureCol = (col / 3) * 3;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (sudoku[smallSqureRow + i, smallSqureCol + j] == val)
                            return false;
                    }
                }

                return true;
            }
        }

        private class CharWithFrquency : IComparable
        {
            public char Char { get; set; }
            public int Frquency { get; set; }

            public int CompareTo(object obj)
            {
                var casted = obj as CharWithFrquency;
                if (casted == null) return -1;
                return this.Frquency.CompareTo(casted.Frquency);
            }
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
