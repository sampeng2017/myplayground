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
        [TestCategory("String")]
        public void ParenthesisChecker()
        {
            string s = "[()]{}{[()()]()}";
            Geeksforgeeks.ParenthesisChecker(s).Should().BeTrue();
            s = "[()]{}{[()(]()}";
            Geeksforgeeks.ParenthesisChecker(s).Should().BeFalse();
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
    }
}
