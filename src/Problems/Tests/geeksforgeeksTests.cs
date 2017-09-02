using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;
using Problems.Basics;
using Problems.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class GeeksforgeeksTests
    {
        [TestMethod]
        [TestCategory("Array")]
        public void KadanesAlgorithm()
        {
            int[] a = new int[] { -1, -2, -3 };
            Geeksforgeeks.KadanesAlgorithm(a).Should().Be(-1);

            a = new int[] { 1, 5, 4 };
            Geeksforgeeks.KadanesAlgorithm(a).Should().Be(10);

            a = new int[] { 1, -3, 0, 7, -6, 5, 3, 4, -1 };
            Geeksforgeeks.KadanesAlgorithm(a).Should().Be(13);
            var validation = Misc.FindMaxSubArray(a, 0, a.Length - 1);
            validation.Item1.Should().Be(3);
            validation.Item2.Should().Be(7);
            validation.Item3.Should().Be(13);
        }

        [TestMethod]
        [TestCategory("Array")]
        public void SubArrayWithGivenSum()
        {
            var a = new int[] { 1, 2, 3, 7, 5 };
            var result = Geeksforgeeks.SubArrayWithGivenSum(a, 12);
            result.Item1.Should().Be(1);
            result.Item2.Should().Be(3);

            a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            result = Geeksforgeeks.SubArrayWithGivenSum(a, 15);
            result.Item1.Should().Be(0);
            result.Item2.Should().Be(4);

            a = new int[] { 5, 3, 7, 11, 1, 4, 12, 18 };
            result = Geeksforgeeks.SubArrayWithGivenSum(a, 16);
            result.Item1.Should().Be(3);
            result.Item2.Should().Be(5);

            a = new int[] { 5, 3, 7, 11, 1, 0, 4, 12, 18 };
            result = Geeksforgeeks.SubArrayWithGivenSum(a, 16);
            result.Item1.Should().Be(3);
            result.Item2.Should().Be(6);
        }

        [TestMethod]
        [TestCategory("String")]
        public void ParenthesisChecker()
        {
            string s = "[()]{}{[()()]()}";
            Geeksforgeeks.ParenthesisChecker(s).Should().BeTrue();
            s = "[()]{}{[()(]()}";
            Geeksforgeeks.ParenthesisChecker(s).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("String")]
        public void PermutationsOfString()
        {
            string s = "a";
            var result = Geeksforgeeks.PermutationsOfString(s).ToArray();
            result.Should().HaveCount(1);
            result.Should().BeEquivalentTo(new string[] { "a" });

            s = "ab";
            result = Geeksforgeeks.PermutationsOfString(s).ToArray();
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(new string[] { "ab", "ba" });

            s = "abc";
            result = Geeksforgeeks.PermutationsOfString(s).ToArray();
            result.Should().HaveCount(6);
            result.Should().BeEquivalentTo(new string[] { "abc", "bac", "bca", "acb", "cab", "cba" });

            s = "abcd";
            result = Geeksforgeeks.PermutationsOfString(s).ToArray();
            result.Should().HaveCount(24);
            result.Should().BeEquivalentTo(new string[] { "abcd", "bacd", "bcad", "bcda", "acbd", "cabd", "cbad", "cbda", "acdb", "cadb", "cdab", "cdba", "abdc", "badc", "bdac", "bdca", "adbc", "dabc", "dbac", "dbca", "adcb", "dacb", "dcab", "dcba" });
            result = Geeksforgeeks.PermutationsOfString2(s).ToArray();
            result.Should().HaveCount(24);
            result.Should().BeEquivalentTo(new string[] { "abcd", "bacd", "bcad", "bcda", "acbd", "cabd", "cbad", "cbda", "acdb", "cadb", "cdab", "cdba", "abdc", "badc", "bdac", "bdca", "adbc", "dabc", "dbac", "dbca", "adcb", "dacb", "dcab", "dcba" });
        }

        [TestMethod]
        [TestCategory("Linked List")]
        public void ReverseLinkedListInGroupsOfGivenSize()
        {
            var list = new ListNode<int> { Value = 1 };
            list.Next = new ListNode<int> { Value = 2 };
            list.Next.Next = new ListNode<int> { Value = 2 };
            list.Next.Next.Next = new ListNode<int> { Value = 4 };
            list.Next.Next.Next.Next = new ListNode<int> { Value = 5 };
            list.Next.Next.Next.Next.Next = new ListNode<int> { Value = 6 };
            list.Next.Next.Next.Next.Next.Next = new ListNode<int> { Value = 7 };
            list.Next.Next.Next.Next.Next.Next.Next = new ListNode<int> { Value = 8 };

            var result = Geeksforgeeks.ReverseLinkedListInGroupsOfGivenSize(list, 4);
            result.Value.Should().Be(4);
            result.Next.Value.Should().Be(2);
            result.Next.Next.Value.Should().Be(2);
            result.Next.Next.Next.Value.Should().Be(1);
            result.Next.Next.Next.Next.Value.Should().Be(8);
            result.Next.Next.Next.Next.Next.Value.Should().Be(7);
            result.Next.Next.Next.Next.Next.Next.Value.Should().Be(6);
            result.Next.Next.Next.Next.Next.Next.Next.Value.Should().Be(5);
            result.Next.Next.Next.Next.Next.Next.Next.Next.Should().BeNull();

            list = new ListNode<int> { Value = 1 };
            list.Next = new ListNode<int> { Value = 2 };
            list.Next.Next = new ListNode<int> { Value = 2 };
            list.Next.Next.Next = new ListNode<int> { Value = 4 };
            list.Next.Next.Next.Next = new ListNode<int> { Value = 5 };
            list.Next.Next.Next.Next.Next = new ListNode<int> { Value = 6 };
            list.Next.Next.Next.Next.Next.Next = new ListNode<int> { Value = 7 };
            list.Next.Next.Next.Next.Next.Next.Next = new ListNode<int> { Value = 8 };

            result = Geeksforgeeks.ReverseLinkedListInGroupsOfGivenSize(list, 3);
            result.Value.Should().Be(2);
            result.Next.Value.Should().Be(2);
            result.Next.Next.Value.Should().Be(1);
            result.Next.Next.Next.Value.Should().Be(6);
            result.Next.Next.Next.Next.Value.Should().Be(5);
            result.Next.Next.Next.Next.Next.Value.Should().Be(4);
            result.Next.Next.Next.Next.Next.Next.Value.Should().Be(8);
            result.Next.Next.Next.Next.Next.Next.Next.Value.Should().Be(7);
            result.Next.Next.Next.Next.Next.Next.Next.Next.Should().BeNull();
        }

        [TestMethod]
        [TestCategory("Stack and Queue")]
        public void NextLargerElement()
        {
            var a = new int[] { 1 };
            var r = Geeksforgeeks.NextLargerElement_O_NSquare(a);
            r.Should().BeEquivalentTo(new int[] { -1 });

            a = new int[] { 1, 3, 2, 4 };
            r = Geeksforgeeks.NextLargerElement_O_NSquare(a);
            r.Should().BeEquivalentTo(new int[] { 3, 4, 4, -1 });

            a = new int[] { 1 };
            r = Geeksforgeeks.NextLargerElement_O_N(a);
            r.Should().BeEquivalentTo(new int[] { -1 });

            a = new int[] { 1, 3, 2, 4 };
            r = Geeksforgeeks.NextLargerElement_O_N(a);
            r.Should().BeEquivalentTo(new int[] { 3, 4, 4, -1 });
        }

        [TestMethod]
        [TestCategory("Tree")]
        public void LeftViewOfBinaryTree()
        {

            //       1
            //    /     \
            //   2        3
            // /   \    /    \
            //4     5   6    7
            // \
            //   8
            BinaryTreeNode<int> root = new BinaryTreeNode<int> { Value = 1 };
            root.LeftChild = new BinaryTreeNode<int> { Value = 2 };
            root.LeftChild.LeftChild = new BinaryTreeNode<int> { Value = 4 };
            root.LeftChild.LeftChild.RightChild = new BinaryTreeNode<int> { Value = 8 };
            root.LeftChild.RightChild = new BinaryTreeNode<int> { Value = 5 };
            root.RightChild = new BinaryTreeNode<int> { Value = 3 };
            root.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 6 };
            root.RightChild.RightChild = new BinaryTreeNode<int> { Value = 7 };

            var result = Geeksforgeeks.LeftViewOfBinaryTree(root);
            result.Should().HaveCount(4);
            result[0].Should().Be(root);
            result[1].Should().Be(root.LeftChild);
            result[2].Should().Be(root.LeftChild.LeftChild);
            result[3].Should().Be(root.LeftChild.LeftChild.RightChild);
        }

        [TestMethod]
        [TestCategory("Tree")]
        public void BottomViewOfBinaryTree()
        {
            //        20
            //      /    \
            //    8       22
            //  /   \        \
            //5      3       25
            //      /   \      
            //    10    14
            var root = new BinaryTreeNode<int> { Value = 20 };
            root.LeftChild = new BinaryTreeNode<int> { Value = 8 };
            root.LeftChild.LeftChild = new BinaryTreeNode<int> { Value = 5 };
            root.LeftChild.RightChild = new BinaryTreeNode<int> { Value = 3 };
            root.LeftChild.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 10 };
            root.LeftChild.RightChild.RightChild = new BinaryTreeNode<int> { Value = 14 };
            root.RightChild = new BinaryTreeNode<int> { Value = 22 };
            root.RightChild.RightChild = new BinaryTreeNode<int> { Value = 25 };

            var result = Geeksforgeeks.BottomViewOfBinaryTree(root);
            result.Select(n => n.Value).ToArray().Should().BeEquivalentTo(new int[] { 5, 10, 3, 14, 25 });
            result = Geeksforgeeks.BottomViewOfBinaryTree2(root);
            result.Select(n => n.Value).ToArray().Should().BeEquivalentTo(new int[] { 5, 10, 3, 14, 25 });

            //        20
            //      /    \
            //    8       22
            //  /   \    /   \
            //5      3  4    25
            //      /  \      
            //    10   14
            root.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 4 };
            result = Geeksforgeeks.BottomViewOfBinaryTree(root);
            result.Select(n => n.Value).ToArray().Should().BeEquivalentTo(new int[] { 5, 10, 4, 14, 25 });
            result = Geeksforgeeks.BottomViewOfBinaryTree2(root);
            result.Select(n => n.Value).ToArray().Should().BeEquivalentTo(new int[] { 5, 10, 4, 14, 25 });
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void FindMedianInStream()
        {
            var inStream = new int[] { 5, 15, 1, 3 };
            var result = Geeksforgeeks.FindMedianInStream(inStream).ToArray();
            result.Should().BeEquivalentTo(new int[] { 5, 10, 5, 4 });
        }

        [TestMethod]
        [TestCategory("Recursive")]
        public void FloodFillAlgorithm()
        {
            int[,] screen = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 0, 0},
                {1, 0, 0, 1, 1, 0, 1, 1},
                {1, 2, 2, 2, 2, 0, 1, 0},
                {1, 1, 1, 2, 2, 0, 1, 0},
                {1, 1, 1, 2, 2, 2, 2, 0},
                {2, 2, 1, 1, 1, 2, 1, 1},
                {1, 2, 1, 1, 1, 2, 2, 1},
            };

            var expectedAfterFill = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 0, 0},
                {1, 0, 0, 1, 1, 0, 1, 1},
                {1, 3, 3, 3, 3, 0, 1, 0},
                {1, 1, 1, 3, 3, 0, 1, 0},
                {1, 1, 1, 3, 3, 3, 3, 0},
                {2, 2, 1, 1, 1, 3, 1, 1},
                {1, 2, 1, 1, 1, 3, 3, 1},
            };
            Geeksforgeeks.FloodFillAlgorithm(screen, 4, 4, 3);
            screen.Should().BeEquivalentTo(expectedAfterFill);
        }

        [TestMethod]
        [TestCategory("Hashing")]
        public void LargestSubarrayLenWithZeroSum()
        {
            var a = new int[] { 15, -2, 2, -8, 1, 7, 10, 23 };
            var result = Geeksforgeeks.LargestSubarrayLenWithZeroSum(a);
            result.Should().Be(5);

            a = new int[] { 15, -3, 1, 2, 13, 2, -7, -10, 5 };
            result = Geeksforgeeks.LargestSubarrayLenWithZeroSum(a);
            result.Should().Be(5);

            a = new int[] { 15, -3, 1, 2, 13, 2, -7, -10, 5, -3 };
            result = Geeksforgeeks.LargestSubarrayLenWithZeroSum(a);
            result.Should().Be(9);

            a = new int[] { -1, 1, -1, 1 };
            result = Geeksforgeeks.LargestSubarrayLenWithZeroSum(a);
            result.Should().Be(4);

            a = new int[] { -1, 1, -1, 1, 5 };
            result = Geeksforgeeks.LargestSubarrayLenWithZeroSum(a);
            result.Should().Be(4);
        }

        [TestMethod]
        [TestCategory("Hashing")]
        public void SwappingPairMakeSumEqual()
        {
            var a1 = new int[] { 4, 1, 2, 1, 1, 2 };
            var a2 = new int[] { 3, 6, 3, 3 };
            var result = Geeksforgeeks.SwappingPairMakeSumEqual(a1, a2);
            result.Item1.Should().Be(1);
            result.Item2.Should().Be(3);

            result = Geeksforgeeks.SwappingPairMakeSumEqual(a2, a1);
            result.Item1.Should().Be(6);
            result.Item2.Should().Be(4);

            a1 = new int[] { 5, 7, 4, 6 };
            a2 = new int[] { 1, 2, 3, 8 };
            result = Geeksforgeeks.SwappingPairMakeSumEqual(a1, a2);
            result.Item1.Should().Be(5);
            result.Item2.Should().Be(1);

            result = Geeksforgeeks.SwappingPairMakeSumEqual(a2, a1);
            result.Item1.Should().Be(1);
            result.Item2.Should().Be(5);
        }

        [TestMethod]
        [TestCategory("Greedy")]
        public void ActivitySelection()
        {
            var activities = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(0, 6),
                new Tuple<int, int>(5, 7),
                new Tuple<int, int>(8, 9),
                new Tuple<int, int>(5, 9),
            };

            var result = Geeksforgeeks.ActivitySelection(activities);
            result.Should().Be(4);
        }

        [TestMethod]
        [TestCategory("Greedy")]
        public void NMeetingsInOneRoom()
        {
            var meetings = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(0, 6),
                new Tuple<int, int>(5, 7),
                new Tuple<int, int>(8, 9),
                new Tuple<int, int>(5, 9),
            };

            var result = Geeksforgeeks.NMeetingsInOneRoom(meetings);
            result.Should().BeEquivalentTo(new int[] { 0, 1, 3, 4 });

            meetings = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(75250, 112960),
                new Tuple<int, int>(50074, 114515),
                new Tuple<int, int>(43659, 81825),
                new Tuple<int, int>(8931, 93424),
                new Tuple<int, int>(11273, 54316),
                new Tuple<int, int>(27545, 35533),
                new Tuple<int, int>(50879, 73383),
                new Tuple<int, int>(77924, 160252)
            };

            result = Geeksforgeeks.NMeetingsInOneRoom(meetings);
            result.Should().BeEquivalentTo(new int[] { 5, 6, 0 });
        }

        [TestMethod]
        [TestCategory("Dynamic Programming")]
        public void LongestIncreasingSubsequence()
        {
            var a = new int[] { 10 };
            var result = Geeksforgeeks.LongestIncreasingSubsequence(a);
            result.Should().Be(1);

            a = new int[] { 10, 9 };
            result = Geeksforgeeks.LongestIncreasingSubsequence(a);
            result.Should().Be(1);

            a = new int[] { 9, 10 };
            result = Geeksforgeeks.LongestIncreasingSubsequence(a);
            result.Should().Be(2);

            a = new int[] { 12, 9, 10 };
            result = Geeksforgeeks.LongestIncreasingSubsequence(a);
            result.Should().Be(2);

            a = new int[] { 10, 22, 9, 33, 21, 50, 41, 60, 80 };
            result = Geeksforgeeks.LongestIncreasingSubsequence(a);
            result.Should().Be(6);
        }

        [TestMethod]
        [TestCategory("Divide and Conquer")]
        public void FindElementAppearsOnceInSortedArray()
        {
            var a = new int[] { 1, 1, 2, 2, 3, 3, 4, 50, 50, 65, 65 };
            var result = Geeksforgeeks.FindElementAppearsOnceInSortedArray_Xor(a);
            result.Should().Be(4);

            a = new int[] { 1, 5, 5, 3, 3, 50, 50, 65, 65 };
            result = Geeksforgeeks.FindElementAppearsOnceInSortedArray_Xor(a);
            result.Should().Be(1);

            a = new int[] { 1, 1, 2, 2, 3, 3, 4, 50, 50, 65, 65 };
            result = Geeksforgeeks.FindElementAppearsOnceInSortedArray_Scan(a);
            result.Should().Be(4);

            a = new int[] { 1, 5, 5, 3, 3, 50, 50, 65, 65 };
            result = Geeksforgeeks.FindElementAppearsOnceInSortedArray_Scan(a);
            result.Should().Be(1);

            a = new int[] { 1, 1, 2, 2, 3, 3, 4, 50, 50, 65, 65 };
            result = Geeksforgeeks.FindElementAppearsOnceInSortedArray_BS(a, 0, a.Length - 1);
            result.Should().Be(4);

            a = new int[] { 1, 5, 5, 3, 3, 50, 50, 65, 65 };
            result = Geeksforgeeks.FindElementAppearsOnceInSortedArray_BS(a, 0, a.Length - 1);
            result.Should().Be(1);
        }

        [TestMethod]
        [TestCategory("Backtracking")]
        public void NQueenProblem()
        {
            var q3 = Geeksforgeeks.NQueenProblem(3);
            q3.Should().HaveCount(0);

            var q4 = Geeksforgeeks.NQueenProblem(4);
            var expected1 = new int[,]
            {
                { 0, 0, 1, 0 },
                { 1, 0, 0, 0 },
                { 0, 0, 0, 1 },
                { 0, 1, 0, 0 }
            };
            var expected2 = new int[,]
            {
                { 0,1,0,0 },
                { 0,0,0,1 },
                { 1,0,0,0 },
                { 0,0,1,0 }
            };
            q4.Should().HaveCount(2);
            q4[0].Should().BeEquivalentTo(expected1);
            q4[1].Should().BeEquivalentTo(expected2);

            var q5 = Geeksforgeeks.NQueenProblem(5);
            q5.Should().HaveCount(5);
        }

        [TestMethod]
        [TestCategory("Bits")]
        public void FindFirstSetBit()
        {
            Geeksforgeeks.FindFirstSetBit(5).Should().Be(1);
            Geeksforgeeks.FindFirstSetBit(12).Should().Be(3);
            Geeksforgeeks.FindFirstSetBit(18).Should().Be(2);
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void ReArrangeChars()
        {
            string s = "geeksforgeeks";
            var result = Geeksforgeeks.ReArrangeChars(s);
            result.Length.Should().Be(s.Length);
            result.Should().Be("egeskeroskefg");

            s = "aaabc";
            result = Geeksforgeeks.ReArrangeChars(s);
            result.Length.Should().Be(s.Length);
            result.Should().Be("abaca");

            s = "aaaabc";
            result = Geeksforgeeks.ReArrangeChars(s);
            result.Should().BeNull();
        }

        [TestMethod]
        public void SelectARandomNodeFromLinkedList()
        {
            var list = new ListNode<int> { Value = 0 };
            var tmp = list;
            int i = 1;
            while (i < 100)
            {
                tmp.Next = new ListNode<int> { Value = i };
                i++;
                tmp = tmp.Next;
            }

            var result = Geeksforgeeks.SelectARandomNodeFromLinkedList(list);
            //not much to validate
            result.Should().NotBeNull();
        }
    }
}
