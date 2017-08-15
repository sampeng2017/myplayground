using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.DataStructures;
using Problems;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class OldProblemsTests
    {
        [TestMethod]
        public void FlipBinaryTree()
        {
            OldProblems.FlipBinaryTree(null);

            BinaryTreeNode<int> root = new BinaryTreeNode<int> { Value = 1 };
            OldProblems.FlipBinaryTree(root);

            root.LeftChild = new BinaryTreeNode<int> { Value = 2 };
            root.LeftChild.LeftChild = new BinaryTreeNode<int> { Value = 4 };
            root.LeftChild.RightChild = new BinaryTreeNode<int> { Value = 5 };

            root.RightChild = new BinaryTreeNode<int> { Value = 3 };
            root.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 6 };
            root.RightChild.RightChild = new BinaryTreeNode<int> { Value = 7 };
            root.RightChild.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 8 };

            root.ToString().Should().Be("{1; Left: {2; Left: {4(leaf)}; Right: {5(leaf)}}; Right: {3; Left: {6(leaf)}; Right: {7; Left: {8(leaf)}; Right: NIL}}}");
            OldProblems.FlipBinaryTree(root);
            root.ToString().Should().Be("{1; Left: {3; Left: {7; Left: NIL; Right: {8(leaf)}}; Right: {6(leaf)}}; Right: {2; Left: {5(leaf)}; Right: {4(leaf)}}}");
        }

        [TestMethod]
        public void FindInSorted2DArray()
        {
            int[,] twoDAry = new int[,]
            {
                {1, 2, 4, 5, 6 },
                {3, 7, 8, 9, 11 },
                {13, 15, 16, 20, 28},
                {14, 17, 18, 21, 32},
            };
            var result = OldProblems.FindInSorted2DArray_Zigzag(twoDAry, 9);
            result.Should().NotBeNull();
            result.Item1.Should().Be(1);
            result.Item2.Should().Be(3);

            result = OldProblems.FindInSorted2DArray_Zigzag(twoDAry, 27);
            result.Should().BeNull();
        }
    }
}
