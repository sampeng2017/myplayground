using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.DataStructures;
using Problems;
using FluentAssertions;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class LeetCoderTests
    {
        [TestMethod]
        public void TwoSum()
        {
            var testAry1 = new int[] { 2, 7, 11, 15 };
            var result = LeetCoder.TwoSum(testAry1, 9);
            result.Item1.Should().Be(0);
            result.Item2.Should().Be(1);

            result = LeetCoder.TwoSum(testAry1, 22);
            result.Item1.Should().Be(1);
            result.Item2.Should().Be(3);

            var testAry2 = new int[] { -2, 7, -11, 0, 15, 8, 7, 27, -3 };
            result = LeetCoder.TwoSum(testAry2, 15);
            result.Item1.Should().Be(3);
            result.Item2.Should().Be(4);

            result = LeetCoder.TwoSum(testAry2, 23);
            result.Item1.Should().Be(4);
            result.Item2.Should().Be(5);

            result = LeetCoder.TwoSum(testAry2, 4);
            result.Item1.Should().Be(2);
            result.Item2.Should().Be(4);
        }

        [TestMethod]
        public void AddTowNumbers()
        {
            ListNode<int> l1 = LeetCoder.BuildLinkedListFromValue(342);
            LeetCoder.LinkedListToValue(l1).Should().Be(342);

            ListNode<int> l2 = LeetCoder.BuildLinkedListFromValue(465);
            LeetCoder.LinkedListToValue(l2).Should().Be(465);

            ListNode<int> l = LeetCoder.AddTowNumbers(l1, l2);
            LeetCoder.LinkedListToValue(l).Should().Be(807);

            l1 = LeetCoder.BuildLinkedListFromValue(10);
            l2 = LeetCoder.BuildLinkedListFromValue(2);
            l = LeetCoder.AddTowNumbers(l1, l2);
            LeetCoder.LinkedListToValue(l).Should().Be(12);

            l1 = LeetCoder.BuildLinkedListFromValue(3271);
            l2 = LeetCoder.BuildLinkedListFromValue(50369);
            l = LeetCoder.AddTowNumbers(l1, l2);
            LeetCoder.LinkedListToValue(l).Should().Be(53640);

            l1 = LeetCoder.BuildLinkedListFromValue(87);
            l2 = LeetCoder.BuildLinkedListFromValue(969);
            l = LeetCoder.AddTowNumbers(l1, l2);
            LeetCoder.LinkedListToValue(l).Should().Be(1056);
        }

        [TestMethod]
        public void LongestSubstrWithoutRepeatingChars()
        {
            var r = LeetCoder.LongestSubstrWithoutRepeatingChars("b");
            r.Should().Be("b");

            r = LeetCoder.LongestSubstrWithoutRepeatingChars("abcde");
            r.Should().Be("abcde");

            r = LeetCoder.LongestSubstrWithoutRepeatingChars("abcabc");
            r.Should().Be("abc");

            r = LeetCoder.LongestSubstrWithoutRepeatingChars("abcada");
            r.Should().Be("bcad");

            r = LeetCoder.LongestSubstrWithoutRepeatingChars("abcada12z2dj");
            r.Should().Be("da12z");

            r = LeetCoder.LongestSubstrWithoutRepeatingChars("1123157a238jkg5392109742312ad");
            r.Should().Be("157a238jkg");
        }

        [TestMethod]
        public void LongestSubstrLenWithoutRepeatingChars()
        {
            Func<string, int> func = LeetCoder.LongestSubstrLenWithoutRepeatingChars;

            var r = func("b");
            r.Should().Be(1);

            r = func("abcde");
            r.Should().Be(5);

            r = func("abcabc");
            r.Should().Be(3);

            r = func("abcada");
            r.Should().Be(4);

            r = func("abcada12z2dj");
            r.Should().Be(5);

            r = func("1123157a238jkg5392109742312ad");
            r.Should().Be(10);
        }

        [TestMethod]
        public void ZigZagConversion()
        {
            var converted = LeetCoder.ZigZagConversion("PAYPALISHIRING", 3);
            converted.Should().Be("PAHNAPLSIIGYIR");
        }

        [TestMethod]
        public void ReverseInteger()
        {
            LeetCoder.ReverseInteger(0).Should().Be(0);
            LeetCoder.ReverseInteger(1).Should().Be(1);
            LeetCoder.ReverseInteger(-2).Should().Be(-2);
            LeetCoder.ReverseInteger(123).Should().Be(321);
            LeetCoder.ReverseInteger(-12345).Should().Be(-54321);
            LeetCoder.ReverseInteger(int.MaxValue).Should().Be(-1);
        }

        [TestMethod]
        public void GenerateParentheses()
        {
            LeetCoder.GenerateParentheses(0).Should().BeNull();

            var result = LeetCoder.GenerateParentheses(1);
            result.Should().HaveCount(1);
            result[0].Should().Be("()");

            result = LeetCoder.GenerateParentheses(2);
            result.Should().HaveCount(2);
            result[0].Should().Be("(())");
            result[1].Should().Be("()()");

            result = LeetCoder.GenerateParentheses(3);
            result.Should().HaveCount(5);
            result[0].Should().Be("((()))");
            result[1].Should().Be("()(())");
            result[2].Should().Be("(())()");
            result[3].Should().Be("(()())");
            result[4].Should().Be("()()()");

            result = LeetCoder.GenerateParentheses(4);
            result.Should().HaveCount(14);
            result[0].Should().Be("(((())))");
            result[1].Should().Be("()((()))");
            result[2].Should().Be("((()))()");

            result[3].Should().Be("(()(()))");
            result[4].Should().Be("()()(())");
            result[5].Should().Be("()(())()");

            result[6].Should().Be("((())())");
            result[7].Should().Be("()(())()");
            result[8].Should().Be("(())()()");

            result[9].Should().Be("((()()))");
            result[10].Should().Be("()(()())");
            result[11].Should().Be("(()())()");

            result[12].Should().Be("(()()())");
            result[13].Should().Be("()()()()");
        }

        [TestMethod]
        public void SearchForRange()
        {
            int[] ary = new int[] { 5, 7, 7, 8, 8, 10 };
            var result = LeetCoder.SearchForRange(ary, 8);
            result.Item1.Should().Be(3);
            result.Item2.Should().Be(4);

            result = LeetCoder.SearchForRange(ary, 7);
            result.Item1.Should().Be(1);
            result.Item2.Should().Be(2);

            result = LeetCoder.SearchForRange(ary, 5);
            result.Item1.Should().Be(0);
            result.Item2.Should().Be(0);

            result = LeetCoder.SearchForRange(ary, 11);
            result.Item1.Should().Be(-1);
            result.Item2.Should().Be(-1);
        }

        [TestMethod]
        public void RotateLinkedList()
        {
            var node11 = new ListNode<int> { Value = 1 };
            var node12 = new ListNode<int> { Value = 2 };
            node11.Next = node12;
            var rotated = LeetCoder.RotateList(node11, 20);
            rotated.Value.Should().Be(1);
            rotated.Next.Value.Should().Be(2);
            rotated.Next.Next.Should().BeNull();

            var node13 = new ListNode<int> { Value = 3 };
            var node14 = new ListNode<int> { Value = 4 };
            var node15 = new ListNode<int> { Value = 5 };
            node12.Next = node13;
            node13.Next = node14;
            node14.Next = node15;

            rotated = LeetCoder.RotateList(node11, 2);
            rotated.Value.Should().Be(4);
            rotated.Next.Value.Should().Be(5);
            rotated.Next.Next.Value.Should().Be(1);
            rotated.Next.Next.Next.Value.Should().Be(2);
            rotated.Next.Next.Next.Next.Value.Should().Be(3);
            rotated.Next.Next.Next.Next.Next.Should().BeNull();

            rotated = LeetCoder.RotateList(rotated, 3);
            rotated.Value.Should().Be(1);
            rotated.Next.Value.Should().Be(2);
            rotated.Next.Next.Value.Should().Be(3);
            rotated.Next.Next.Next.Value.Should().Be(4);
            rotated.Next.Next.Next.Next.Value.Should().Be(5);
            rotated.Next.Next.Next.Next.Next.Should().BeNull();

            rotated = LeetCoder.RotateList(rotated, 16);
            rotated.Value.Should().Be(2);
            rotated.Next.Value.Should().Be(3);
            rotated.Next.Next.Value.Should().Be(4);
            rotated.Next.Next.Next.Value.Should().Be(5);
            rotated.Next.Next.Next.Next.Value.Should().Be(1);
            rotated.Next.Next.Next.Next.Next.Should().BeNull();

        }

        [TestMethod]
        public void CanPlaceFlower()
        {
            int[] testBed1 = new int[] { 1, 0, 0 };
            LeetCoder.CanPlaceFlower(testBed1, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed1, 2).Should().BeFalse();

            int[] testBed2 = new int[] { 1, 0, 0, 0, 1 };
            LeetCoder.CanPlaceFlower(testBed2, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed2, 2).Should().BeFalse();
            LeetCoder.CanPlaceFlower(testBed2, 3).Should().BeFalse();

            int[] testBed3 = new int[] { 0, 0, 0, 0, 0 };
            LeetCoder.CanPlaceFlower(testBed3, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed3, 2).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed3, 3).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed3, 4).Should().BeFalse();

            int[] testBed4 = new int[] { 1, 1, 1, 1, 1 };
            LeetCoder.CanPlaceFlower(testBed4, 1).Should().BeFalse();

            int[] testBed5 = new int[] { 1, 0, 0, 0, 0, 1, 0, 0 };
            LeetCoder.CanPlaceFlower(testBed5, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed5, 2).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed5, 3).Should().BeFalse();

            int[] testBed6 = new int[] { 0 };
            LeetCoder.CanPlaceFlower(testBed6, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed6, 2).Should().BeFalse();

            int[] testBed7 = new int[] { 0, 0, 0, 0, 0, 1, 0, 1 };
            LeetCoder.CanPlaceFlower(testBed7, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed7, 2).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed7, 3).Should().BeFalse();
        }

        [TestMethod]
        public void CombinationSum()
        {
            var numbers = new int[] { 2, 3, 6, 7, 9 };
            var result = LeetCoder.CombinationSum(numbers, 7);
            result.Should().HaveCount(2);
            result[0].Should().BeEquivalentTo(new List<int> { 2, 2, 3 });
            result[1].Should().BeEquivalentTo(new List<int> { 7 });

            numbers = new int[] { 6, 7, 9, 12, 25, 31 };
            result = LeetCoder.CombinationSum(numbers, 48);
            result.Should().HaveCount(15);
        }

        [TestMethod]
        public void PathSum1()
        {
            //              5
            //             / \
            //            4   8
            //           /   / \
            //          11  13  4
            //         /  \      \
            //        7    2      1
            var root = new BinaryTreeNode<int> { Value = 5 };
            var node1 = new BinaryTreeNode<int> { Value = 4 };
            var node2 = new BinaryTreeNode<int> { Value = 8 };
            var node3 = new BinaryTreeNode<int> { Value = 11 };
            var node4 = new BinaryTreeNode<int> { Value = 13 };
            var node5 = new BinaryTreeNode<int> { Value = 4 };
            var node6 = new BinaryTreeNode<int> { Value = 7 };
            var node7 = new BinaryTreeNode<int> { Value = 2 };
            var node8 = new BinaryTreeNode<int> { Value = 1 };
            root.LeftChild = node1;
            root.RightChild = node2;
            node1.LeftChild = node3;
            node2.LeftChild = node4;
            node2.RightChild = node5;
            node3.LeftChild = node6;
            node3.RightChild = node7;
            node5.RightChild = node8;

            var result = LeetCoder.PathSum1(root, 22);
            result.Should().BeTrue();

            node3.Value += 1;
            result = LeetCoder.PathSum1(root, 22);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void PathSum2()
        {
            //              5
            //             / \
            //            4   8
            //           /   / \
            //          11  13  4
            //         /  \      \
            //        7    2      1
            var root = new BinaryTreeNode<int> { Value = 5 };
            var node1 = new BinaryTreeNode<int> { Value = 4 };
            var node2 = new BinaryTreeNode<int> { Value = 8 };
            var node3 = new BinaryTreeNode<int> { Value = 11 };
            var node4 = new BinaryTreeNode<int> { Value = 13 };
            var node5 = new BinaryTreeNode<int> { Value = 4 };
            var node6 = new BinaryTreeNode<int> { Value = 7 };
            var node7 = new BinaryTreeNode<int> { Value = 2 };
            var node8 = new BinaryTreeNode<int> { Value = 1 };
            root.LeftChild = node1;
            root.RightChild = node2;
            node1.LeftChild = node3;
            node2.LeftChild = node4;
            node2.RightChild = node5;
            node3.LeftChild = node6;
            node3.RightChild = node7;
            node5.RightChild = node8;

            var result = LeetCoder.PathSum2(root, 22);
            result.Should().HaveCount(1);
            result[0].Should().BeEquivalentTo(new List<int> { 5, 4, 11, 2 });

            node3.Value += 1;
            result = LeetCoder.PathSum2(root, 22);
            result.Should().BeNull();
            node3.Value -= 1;

            node5.LeftChild = new BinaryTreeNode<int> { Value = 5 };
            //              5
            //             / \
            //            4   8
            //           /   / \
            //          11  13  4
            //         /  \    / \
            //        7    2  5   1
            result = LeetCoder.PathSum2(root, 22);
            result.Should().HaveCount(2);
            result[0].Should().BeEquivalentTo(new List<int> { 5, 4, 11, 2 });
            result[1].Should().BeEquivalentTo(new List<int> { 5, 8, 4, 5 });
        }

        [TestMethod]
        public void WordBreak()
        {
            var dictionary = new List<string> { "leet", "code"};

            var result = LeetCoder.WordBreak(dictionary, "leet");
            result.Should().BeTrue();

            result = LeetCoder.WordBreak(dictionary, "leetcode");
            result.Should().BeTrue();

            result = LeetCoder.WordBreak(dictionary, "leetcodeblar");
            result.Should().BeFalse();

            dictionary.Add("work");
            dictionary.Add("book");
            result = LeetCoder.WordBreak(dictionary, "codeworkbook");
            result.Should().BeTrue();
            result = LeetCoder.WordBreak(dictionary, "workbookcode");
            result.Should().BeTrue();
            result = LeetCoder.WordBreak(dictionary, "workbookcodeleet");
            result.Should().BeTrue();
            result = LeetCoder.WordBreak(dictionary, "workbookandcode");
            result.Should().BeFalse();

        }

        [TestMethod]
        public void FlattenBinaryTreeToLinkedList()
        {
            //         1
            //        / \
            //       2   5
            //      / \   \
            //     3   4   6
            var treeRoot = new BinaryTreeNode<int> { Value = 1 };
            treeRoot.LeftChild = new BinaryTreeNode<int> { Value = 2 };
            treeRoot.LeftChild.LeftChild = new BinaryTreeNode<int> { Value = 3 };
            treeRoot.LeftChild.RightChild = new BinaryTreeNode<int> { Value = 4 };
            treeRoot.RightChild = new BinaryTreeNode<int> { Value = 5 };
            treeRoot.RightChild.RightChild = new BinaryTreeNode<int> { Value = 6 };

            ListNode<int> listHead = LeetCoder.FlattenBinaryTreeToLinkedList(treeRoot);
            listHead.Value.Should().Be(1);
            listHead.Next.Value.Should().Be(2);
            listHead.Next.Next.Value.Should().Be(3);
            listHead.Next.Next.Next.Value.Should().Be(4);
            listHead.Next.Next.Next.Next.Value.Should().Be(5);
            listHead.Next.Next.Next.Next.Next.Value.Should().Be(6);
            listHead.Next.Next.Next.Next.Next.Next.Should().BeNull();
        }
    }
}
