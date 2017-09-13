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
        [TestCategory("Array")]
        public void SortArrayWithOnlyZeroOneAndTwo()
        {
            int[] a = new int[] { 0, 2, 1, 2, 0 };
            Geeksforgeeks.SortArrayWithOnlyZeroOneAndTwo(a);
            a.Should().BeEquivalentTo(new int[] { 0, 0, 1, 2, 2 });

            a = new int[] { 0, 1, 0 };
            Geeksforgeeks.SortArrayWithOnlyZeroOneAndTwo(a);
            a.Should().BeEquivalentTo(new int[] { 0, 0, 1 });
        }

        [TestMethod]
        [TestCategory("Array")]
        public void EquilibriumPoint()
        {
            var a = new int[] { 1, 3, 5, 2, 2 };
            Geeksforgeeks.EquilibriumPoint(a)
                .Should().Be(2); //index 2 -> 5

            a = new int[] { 1, 3, 2, 5, 4, 2 };
            Geeksforgeeks.EquilibriumPoint(a)
                .Should().Be(3);

            a = new int[] { 1, 3, 2, 5, 2, 4, 2 };
            Geeksforgeeks.EquilibriumPoint(a)
                .Should().Be(-1);

            a = new int[] { 1 };
            Geeksforgeeks.EquilibriumPoint(a)
                .Should().Be(0);

            a = new int[] { 1, 1 };
            Geeksforgeeks.EquilibriumPoint(a)
                .Should().Be(-1);

            a = new int[] { 1, 2, 1 };
            Geeksforgeeks.EquilibriumPoint(a)
                .Should().Be(1);

            a = new int[] { 1, -1, 3, -1, 2, 5, 2, 4, -2 };
            Geeksforgeeks.EquilibriumPoint(a)
                .Should().Be(5);
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

            list = new ListNode<int> { Value = 1 };
            list.Next = new ListNode<int> { Value = 2 };
            list.Next.Next = new ListNode<int> { Value = 2 };
            list.Next.Next.Next = new ListNode<int> { Value = 4 };
            list.Next.Next.Next.Next = new ListNode<int> { Value = 5 };
            list.Next.Next.Next.Next.Next = new ListNode<int> { Value = 6 };
            list.Next.Next.Next.Next.Next.Next = new ListNode<int> { Value = 7 };
            list.Next.Next.Next.Next.Next.Next.Next = new ListNode<int> { Value = 8 };

            result = Geeksforgeeks.ReverseLinkedListInGroupsOfGivenSize(list, 2);
            result.Value.Should().Be(2);
            result.Next.Value.Should().Be(1);
            result.Next.Next.Value.Should().Be(4);
            result.Next.Next.Next.Value.Should().Be(2);
            result.Next.Next.Next.Next.Value.Should().Be(6);
            result.Next.Next.Next.Next.Next.Value.Should().Be(5);
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

            a = new int[] { 1, 4, 2, 1, 3, 5 };
            r = Geeksforgeeks.NextLargerElement_O_NSquare(a);
            r.Should().BeEquivalentTo(new int[] { 4, 5, 3, 3, 5, -1 });

            a = new int[] { 1 };
            r = Geeksforgeeks.NextLargerElement_O_N(a);
            r.Should().BeEquivalentTo(new int[] { -1 });

            a = new int[] { 1, 3, 2, 4 };
            r = Geeksforgeeks.NextLargerElement_O_N(a);
            r.Should().BeEquivalentTo(new int[] { 3, 4, 4, -1 });

            a = new int[] { 1, 4, 2, 1, 3, 5 };
            r = Geeksforgeeks.NextLargerElement_O_N(a);
            r.Should().BeEquivalentTo(new int[] { 4, 5, 3, 3, 5, -1 });
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
            root.Left = new BinaryTreeNode<int> { Value = 2 };
            root.Left.Left = new BinaryTreeNode<int> { Value = 4 };
            root.Left.Left.Right = new BinaryTreeNode<int> { Value = 8 };
            root.Left.Right = new BinaryTreeNode<int> { Value = 5 };
            root.Right = new BinaryTreeNode<int> { Value = 3 };
            root.Right.Left = new BinaryTreeNode<int> { Value = 6 };
            root.Right.Right = new BinaryTreeNode<int> { Value = 7 };

            var result = Geeksforgeeks.LeftViewOfBinaryTree(root);
            result.Should().HaveCount(4);
            result[0].Should().Be(root);
            result[1].Should().Be(root.Left);
            result[2].Should().Be(root.Left.Left);
            result[3].Should().Be(root.Left.Left.Right);
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
            root.Left = new BinaryTreeNode<int> { Value = 8 };
            root.Left.Left = new BinaryTreeNode<int> { Value = 5 };
            root.Left.Right = new BinaryTreeNode<int> { Value = 3 };
            root.Left.Right.Left = new BinaryTreeNode<int> { Value = 10 };
            root.Left.Right.Right = new BinaryTreeNode<int> { Value = 14 };
            root.Right = new BinaryTreeNode<int> { Value = 22 };
            root.Right.Right = new BinaryTreeNode<int> { Value = 25 };

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
            root.Right.Left = new BinaryTreeNode<int> { Value = 4 };
            result = Geeksforgeeks.BottomViewOfBinaryTree(root);
            result.Select(n => n.Value).ToArray().Should().BeEquivalentTo(new int[] { 5, 10, 4, 14, 25 });
            result = Geeksforgeeks.BottomViewOfBinaryTree2(root);
            result.Select(n => n.Value).ToArray().Should().BeEquivalentTo(new int[] { 5, 10, 4, 14, 25 });
        }

        [TestMethod]
        [TestCategory("Tree")]
        public void GetLeafCount()
        {
            //        20
            //      /    \
            //    8       22
            //  /   \        \
            //5      3       25
            //      /   \      
            //    10    14
            var root = new BinaryTreeNode<int> { Value = 20 };
            root.Left = new BinaryTreeNode<int> { Value = 8 };
            root.Left.Left = new BinaryTreeNode<int> { Value = 5 };
            root.Left.Right = new BinaryTreeNode<int> { Value = 3 };
            root.Left.Right.Left = new BinaryTreeNode<int> { Value = 10 };
            root.Left.Right.Right = new BinaryTreeNode<int> { Value = 14 };
            root.Right = new BinaryTreeNode<int> { Value = 22 };
            root.Right.Right = new BinaryTreeNode<int> { Value = 25 };

            root.GetLeafCount().Should().Be(4);
        }

        [TestMethod]
        [TestCategory("Tree")]
        public void ConnectNodesAtSameLevel()
        {
            //    A
            //   / \
            //  B    C
            // / \    \
            //D   E    F

            var nodeA = new BinaryTreeNodeWithNextRightPointer<string> { Value = "A" };
            var nodeB = new BinaryTreeNodeWithNextRightPointer<string> { Value = "B" };
            var nodeC = new BinaryTreeNodeWithNextRightPointer<string> { Value = "C" };
            var nodeD = new BinaryTreeNodeWithNextRightPointer<string> { Value = "D" };
            var nodeE = new BinaryTreeNodeWithNextRightPointer<string> { Value = "E" };
            var nodeF = new BinaryTreeNodeWithNextRightPointer<string> { Value = "F" };

            nodeA.Left = nodeB;
            nodeA.Left.Left = nodeD;
            nodeA.Left.Right = nodeE;
            nodeA.Right = nodeC;
            nodeA.Right.Right = nodeF;

            Geeksforgeeks.ConnectNodesAtSameLevel(nodeA);
            nodeA.NextRight.Should().BeNull();
            nodeB.NextRight.Should().Be(nodeC);
            nodeC.NextRight.Should().BeNull();
            nodeD.NextRight.Should().Be(nodeE);
            nodeE.NextRight.Should().Be(nodeF);
            nodeF.NextRight.Should().BeNull();

            //ConnectNodesAtSameLevel2
            nodeA.NextRight = nodeB.NextRight = nodeC.NextRight = nodeD.NextRight = nodeE.NextRight = nodeF.NextRight = null;
            Geeksforgeeks.ConnectNodesAtSameLevel2(nodeA);
            nodeA.NextRight.Should().BeNull();
            nodeB.NextRight.Should().Be(nodeC);
            nodeC.NextRight.Should().BeNull();
            nodeD.NextRight.Should().Be(nodeE);
            nodeE.NextRight.Should().Be(nodeF);
            nodeF.NextRight.Should().BeNull();
        }

        [TestMethod]
        [TestCategory("Stack and Queue")]
        public void CircularTour()
        {
            var pumps = new Tuple<int, int>[]
            {
                Tuple.Create(4, 6),
                Tuple.Create(6, 5),
                Tuple.Create(7, 3),
                Tuple.Create(4, 5),
            };
            var result = Geeksforgeeks.CircularTour(pumps);
            result.Should().Be(1);

            pumps = new Tuple<int, int>[]
            {
                Tuple.Create(4, 6),
                Tuple.Create(6, 6),
                Tuple.Create(3, 5),
                Tuple.Create(9, 2),
                Tuple.Create(5, 3),
            };
            result = Geeksforgeeks.CircularTour(pumps);
            result.Should().Be(3);

            pumps = new Tuple<int, int>[]
            {
                Tuple.Create(4, 4),
            };
            result = Geeksforgeeks.CircularTour(pumps);
            result.Should().Be(0);

            // no solution
            pumps = new Tuple<int, int>[]
           {
                Tuple.Create(4, 4),
                Tuple.Create(5, 4),
                Tuple.Create(4, 5),
                Tuple.Create(3, 5),
           };
            result = Geeksforgeeks.CircularTour(pumps);
            result.Should().Be(-1);
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
        [TestCategory("Recursive")]
        public void SpecialKeyboard()
        {
            Geeksforgeeks.SpecialKeyboard(3).Should().Be(3);
            Geeksforgeeks.SpecialKeyboard(6).Should().Be(6);
            Geeksforgeeks.SpecialKeyboard(7).Should().Be(9);
            Geeksforgeeks.SpecialKeyboard(8).Should().Be(12);
            Geeksforgeeks.SpecialKeyboard(9).Should().Be(16);
            Geeksforgeeks.SpecialKeyboard(10).Should().Be(20);
            // too slow
            // Geeksforgeeks.SpecialKeyboard(76).Should().Be(1811939328);
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
        [TestCategory("Hashing")]
        public void ArrayIsSubSequenceOfAnother()
        {
            var a = new int[] { 11, 3, 7, 1 };
            var another = new int[] { 11, 1, 13, 21, 3, 7 };
            bool result = Geeksforgeeks.ArrayIsSubSequenceOfAnother(a, another);
            result.Should().BeFalse();

            a = new int[] { 1, 13, 21 };
            another = new int[] { 11, 1, 13, 21, 3, 7 };
            result = Geeksforgeeks.ArrayIsSubSequenceOfAnother(a, another);
            result.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("Greedy")]
        [TestCategory("Recursive")]
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
        [TestCategory("Dynamic Programming")]
        public void IsSubsetSum()
        {
            var set = new int[] { 3, 34, 4, 12, 5, 2 };
            bool result = Geeksforgeeks.IsSubsetSum(set, set.Length, 9);
            result.Should().BeTrue();

            result = Geeksforgeeks.IsSubsetSum(set, set.Length, 10);
            result.Should().BeFalse();

            result = Geeksforgeeks.IsSubsetSum(set, set.Length, 19);
            result.Should().BeTrue();

        }

        [TestMethod]
        [TestCategory("Divide and Conquer")]
        public void FindElementAppearsOnceInSortedArray()
        {
            var funcs = new List<Func<int[], int>>
            {
                Geeksforgeeks.FindElementAppearsOnceInSortedArray_Xor,
                Geeksforgeeks.FindElementAppearsOnceInSortedArray_Scan,
                (ary) => Geeksforgeeks.FindElementAppearsOnceInSortedArray_BS(ary, 0, ary.Length -1)
            };

            var a = new int[] { 1, 1, 2, 2, 3, 3, 4, 50, 50, 65, 65 };
            int result;
            foreach (var func in funcs)
            {
                result = func(a);
                result.Should().Be(4);
            }
            a = new int[] { 1, 5, 5, 3, 3, 50, 50, 65, 65 };
            foreach (var func in funcs)
            {
                result = func(a);
                result.Should().Be(1);
            }
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
        [TestCategory("Bits")]
        public void RightmostDifferentBit()
        {
            Geeksforgeeks.RightmostDifferentBit(9, 11)
                .Should().Be(2);
            Geeksforgeeks.RightmostDifferentBit(52, 4)
                .Should().Be(5);
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

        [TestMethod]
        [TestCategory("Tree")]
        public void CheckBinaryTreeSubTreeOfAnother()
        {
            //  10
            // /  \
            //1    2
            // \
            //  3
            var tree1 = new BinaryTreeNode<int> { Value = 10 };
            tree1.Left = new BinaryTreeNode<int> { Value = 1 };
            tree1.Left.Right = new BinaryTreeNode<int> { Value = 3 };
            tree1.Right = new BinaryTreeNode<int> { Value = 2 };


            //     15
            //    /   \  
            //  10     4
            // /  \     \
            //1    2     6 
            // \
            //  3
            var tree2 = new BinaryTreeNode<int> { Value = 15 };
            tree2.Left = new BinaryTreeNode<int> { Value = 10 };
            tree2.Left.Left = new BinaryTreeNode<int> { Value = 1 };
            tree2.Left.Left.Right = new BinaryTreeNode<int> { Value = 3 };
            tree2.Left.Right = new BinaryTreeNode<int> { Value = 2 };
            tree2.Right = new BinaryTreeNode<int> { Value = 4 };
            tree2.Right.Right = new BinaryTreeNode<int> { Value = 6 };
            var result = Geeksforgeeks.CheckBinaryTreeSubTreeOfAnother(tree1, tree2);
            result.Should().BeTrue();

            tree1.Value = 100;
            result = Geeksforgeeks.CheckBinaryTreeSubTreeOfAnother(tree1, tree2);
            result.Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("Dynamic Programming")]
        public void EditDistance()
        {
            string s1 = "str1";
            string s2 = "str2";
            int result = Geeksforgeeks.EditDistance(s1, s2);
            result.Should().Be(1);

            s1 = "geek";
            s2 = "gesek";
            result = Geeksforgeeks.EditDistance(s1, s2);
            result.Should().Be(1);

            s1 = "gesek";
            s2 = "geek";
            result = Geeksforgeeks.EditDistance(s1, s2);
            result.Should().Be(1);

            s1 = "sunday";
            s2 = "saturday";
            result = Geeksforgeeks.EditDistance(s1, s2);
            result.Should().Be(3);

            s1 = "saturday";
            s2 = "sunday";
            result = Geeksforgeeks.EditDistance(s1, s2);
            result.Should().Be(3);

            s1 = "a";
            s2 = "bc";
            result = Geeksforgeeks.EditDistance(s1, s2);
            result.Should().Be(2);

        }

        [TestMethod]
        [TestCategory("Heap")]
        public void KthLargestElementInStream()
        {
            var stream = new int[] { 10, 20, 11, 70, 50, 40, 100, 5 };
            var result = Geeksforgeeks.KthLargestElementInStream(stream, 3);
            result.ToArray().Should().BeEquivalentTo(new int[] { -1, -1, 10, 11, 20, 40, 50, 50 });
        }

        [TestMethod]
        [TestCategory("Backtracking")]
        public void SolveSudoku()
        {
            var solved = new int[,]
            {
                { 3,1,6,5,7,8,4,9,2},
                { 5,2,9,1,3,4,7,6,8},
                { 4,8,7,6,2,9,5,3,1},
                { 2,6,3,4,1,5,9,8,7},
                { 9,7,4,8,6,3,1,2,5},
                { 8,5,1,7,9,2,6,4,3},
                { 1,3,8,9,4,7,2,5,6},
                { 6,9,2,3,5,1,8,7,4},
                { 7,4,5,2,8,6,3,1,9}
            };

            var test1 = new int[,]
            {
                { 3,1,6,5,7,8,4,9,2},
                { 5,2,9,1,0,4,7,6,8},
                { 4,8,7,6,2,9,5,3,1},
                { 2,6,3,4,1,5,9,8,7},
                { 9,7,4,8,6,3,1,2,5},
                { 8,5,1,7,9,2,6,4,3},
                { 1,3,8,9,4,7,2,5,6},
                { 6,0,2,3,5,1,8,7,4},
                { 7,4,5,2,8,6,3,1,9}
            };

            var result = Geeksforgeeks.SolveSudoku(test1);
            result.Should().BeEquivalentTo(solved);

            test1 = new int[,]
            {
                { 3,1,6,5,7,8,4,9,0},
                { 5,2,9,1,0,4,7,6,8},
                { 4,0,7,6,2,0,5,3,1},
                { 0,6,3,4,1,5,9,8,7},
                { 9,7,4,8,6,3,1,0,5},
                { 8,5,1,7,9,2,6,4,3},
                { 1,3,8,9,4,7,2,5,6},
                { 6,0,2,3,5,1,8,7,4},
                { 7,4,5,0,8,6,0,1,9}
            };

            result = Geeksforgeeks.SolveSudoku(test1);
            result.Should().BeEquivalentTo(solved);

            test1 = new int[,]
            {
                { 3,0,6,5,0,8,4,0,0},
                { 5,2,0,0,0,0,0,0,0},
                { 0,8,7,0,0,0,0,3,1},
                { 0,0,3,0,1,0,0,8,0},
                { 9,0,0,8,6,3,0,0,5},
                { 0,5,0,0,9,0,6,0,0},
                { 1,3,0,0,0,0,2,5,0},
                { 0,0,0,0,0,0,0,7,4},
                { 0,0,5,2,0,6,3,0,0}
            };
            result = Geeksforgeeks.SolveSudoku(test1);
            result.Should().BeEquivalentTo(solved);
        }

        [TestMethod]
        [TestCategory("Array")]
        public void SlidingWindowMaxOfAllSubArraysWithSizeK()
        {
            var a = new int[] { 1, 2, 3, 1, 4, 5, 2, 3, 6 };
            var result = Geeksforgeeks.SlidingWindowMaxOfAllSubArraysWithSizeK(a, 3);
            result.Should().BeEquivalentTo(new int[] { 3, 3, 4, 5, 5, 5, 6 });

            a = new int[] { 8, 5, 10, 7, 9, 4, 15, 12, 90, 13 };
            result = Geeksforgeeks.SlidingWindowMaxOfAllSubArraysWithSizeK(a, 4);
            result.Should().BeEquivalentTo(new int[] { 10, 10, 10, 15, 15, 90, 90 });

            a = new int[] { 3, 2, 1, 1, 1, 5, 2, 3, 6 };
            result = Geeksforgeeks.SlidingWindowMaxOfAllSubArraysWithSizeK(a, 3);
            result.Should().BeEquivalentTo(new int[] { 3, 2, 1, 5, 5, 5, 6 });
        }

        [TestMethod]
        [TestCategory("Tree")]
        public void ConvertBinaryTreeToDoublyLinkedList()
        {
            // -------------
            BinaryTreeNode<int> root = new BinaryTreeNode<int> { Value = 10 };
            root.Left = new BinaryTreeNode<int> { Value = 12 };
            root.Right = new BinaryTreeNode<int> { Value = 15 };

            var tuple = Geeksforgeeks.ConvertBinaryTreeToDoublyLinkedList(root);
            ValidateConvertedDoublyLinkedListFromBinaryTree(tuple.Item1, tuple.Item2, new int[] { 12, 10, 15 });

            // -------------
            root = new BinaryTreeNode<int> { Value = 10 };
            root.Right = new BinaryTreeNode<int> { Value = 15 };

            tuple = Geeksforgeeks.ConvertBinaryTreeToDoublyLinkedList(root);
            ValidateConvertedDoublyLinkedListFromBinaryTree(tuple.Item1, tuple.Item2, new int[] { 10, 15 });

            // -------------
            root = new BinaryTreeNode<int> { Value = 10 };
            root.Left = new BinaryTreeNode<int> { Value = 12 };
            root.Left.Left = new BinaryTreeNode<int> { Value = 25 };
            root.Left.Right = new BinaryTreeNode<int> { Value = 30 };
            root.Right = new BinaryTreeNode<int> { Value = 15 };
            root.Right.Left = new BinaryTreeNode<int> { Value = 36 };

            tuple = Geeksforgeeks.ConvertBinaryTreeToDoublyLinkedList(root);
            ValidateConvertedDoublyLinkedListFromBinaryTree(tuple.Item1, tuple.Item2, new int[] { 25, 12, 30, 10, 36, 15 });
        }

        private void ValidateConvertedDoublyLinkedListFromBinaryTree(
            BinaryTreeNode<int> head,
            BinaryTreeNode<int> tail,
            int[] expectedLeftToRightSeq)
        {
            var tmpCollector = new List<int>();
            var p = head;
            while (p != null)
            {
                tmpCollector.Add(p.Value);
                p = p.Left;
            }
            tmpCollector.ToArray().Should().BeEquivalentTo(expectedLeftToRightSeq);

            tmpCollector.Clear();
            p = tail;
            while (p != null)
            {
                tmpCollector.Add(p.Value);
                p = p.Right;
            }
            tmpCollector.ToArray().Should().BeEquivalentTo(expectedLeftToRightSeq.OrderByDescending(i => i).ToArray());
        }

        [TestMethod]
        [Ignore] // not working
        public void MaxIntegerValue()
        {
            string s = "5120";
            var result = Geeksforgeeks.MaxIntegerValue(s);
            result.Should().Be(8);
        }

        [TestMethod]
        public void BirdAndMaxFruitGathering()
        {
            var trees = new int[] { 2, 1, 3, 5, 0, 1, 4 };
            var result = Geeksforgeeks.BirdAndMaxFruitGathering(trees, 3);
            result.Should().Be(9);

            trees = new int[] { 1, 6, 2, 5, 3, 4 };
            result = Geeksforgeeks.BirdAndMaxFruitGathering(trees, 2);
            result.Should().Be(8);

            trees = new int[] { 1 };
            result = Geeksforgeeks.BirdAndMaxFruitGathering(trees, 2);
            result.Should().Be(1);
        }

        [TestMethod]
        [TestCategory("String")]
        public void RearrangeString()
        {
            string s = "AC2BEW3";
            var result = Geeksforgeeks.RearrangeString(s);
            result.Should().Be("ABCEW5");

            s = "ACCBA10D2EW30";
            result = Geeksforgeeks.RearrangeString(s);
            result.Should().Be("AABCCDEW6");
        }

        [TestMethod]
        [TestCategory("Array")]
        public void LargestSumSubArrayOfSizeAtLeastK()
        {
            var a = new int[] { -4, -2, 1, -3 };
            var result = Geeksforgeeks.LargestSumSubArrayOfSizeAtLeastK(a, 2);
            result.Should().Be(-1);

            a = new int[] { -4, -2, 1, -3 };
            result = Geeksforgeeks.LargestSumSubArrayOfSizeAtLeastK(a, 3);
            result.Should().Be(-4);

            a = new int[] { 1, 1, 1, 1, 1, 1 };
            result = Geeksforgeeks.LargestSumSubArrayOfSizeAtLeastK(a, 2);
            result.Should().Be(6);

            a = new int[] { 5, 7, -9, 3, -4, 2, 1, -8, 9, 10 };
            result = Geeksforgeeks.LargestSumSubArrayOfSizeAtLeastK(a, 5);
            result.Should().Be(16);
        }

        [TestMethod]
        [TestCategory("String")]
        public void IsStringPalindromicIgnoreSpaces()
        {
            Geeksforgeeks.IsStringPalindromicIgnoreSpaces("race car").Should().BeTrue();
            Geeksforgeeks.IsStringPalindromicIgnoreSpaces("a bc cba").Should().BeTrue();
            Geeksforgeeks.IsStringPalindromicIgnoreSpaces("abcaa").Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("Stack and Queue")]
        public void ConvertTernaryExpressionToBinaryTree()
        {
            var expr = "a ? b : c";
            var tree = Geeksforgeeks.ConvertTernaryExpressionToBinaryTree(expr);
            tree.Value.Should().Be('a');
            tree.Left.Value.Should().Be('b');
            tree.Right.Value.Should().Be('c');

            expr = "a?b?c:d:e";
            tree = Geeksforgeeks.ConvertTernaryExpressionToBinaryTree(expr);
            tree.Value.Should().Be('a');
            tree.Left.Value.Should().Be('b');
            tree.Left.Left.Value.Should().Be('c');
            tree.Left.Right.Value.Should().Be('d');
            tree.Right.Value.Should().Be('e');

            expr = "a?b:c?d:e";
            tree = Geeksforgeeks.ConvertTernaryExpressionToBinaryTree(expr);
            tree.Value.Should().Be('a');
            tree.Left.Value.Should().Be('b');
            tree.Left.Left.Value.Should().Be('c');
            tree.Left.Right.Value.Should().Be('d');
            tree.Right.Value.Should().Be('e');

            expr = "1?a?b?c:d:e";
            tree = Geeksforgeeks.ConvertTernaryExpressionToBinaryTree(expr);
            var tmpCollector = new List<char>();
            tree.PreOrderVisit(c => tmpCollector.Add(c.Value));
            tmpCollector.ToArray().Should().BeEquivalentTo(new char[] { '1', 'a', 'b', 'c', 'd', 'e' });
        }

        [TestMethod]
        public void MultiplyTwoStrings()
        {
            string s1 = "32";
            string s2 = "2";
            var result = Geeksforgeeks.MultiplyTwoStrings(s1, s2);
            result.Should().Be("64");

            s1 = "3214";
            s2 = "25678";
            result = Geeksforgeeks.MultiplyTwoStrings(s1, s2);
            result.Should().Be("82529092");
        }
    }
}
