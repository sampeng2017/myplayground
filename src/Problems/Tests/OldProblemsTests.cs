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
        public void FindMidNode()
        {
            var linkedList = new ListNode<int> { Value = 1 };
            linkedList.Next = new ListNode<int> { Value = 2 };
            linkedList.Next.Next = new ListNode<int> { Value = 3 };
            var node = OldProblems.FindMidNode(linkedList);
            node.Value.Should().Be(2);

            linkedList.Next.Next.Next = new ListNode<int> { Value = 4 };
            node = OldProblems.FindMidNode(linkedList);
            node.Value.Should().Be(2);

            linkedList.Next.Next.Next.Next = new ListNode<int> { Value = 5 };
            node = OldProblems.FindMidNode(linkedList);
            node.Value.Should().Be(3);
        }
    }
}
