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

        [TestMethod]
        public void FindMerge()
        {
            var node1 = new ListNode<int> { Value = 1 };
            var node2 = new ListNode<int> { Value = 2 };
            var node3 = new ListNode<int> { Value = 3 };
            var node4 = new ListNode<int> { Value = 4 };
            var node5 = new ListNode<int> { Value = 5 };
            var node6 = new ListNode<int> { Value = 6 };
            var node7 = new ListNode<int> { Value = 7 };

            var list1 = node1;
            node1.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;

            var list2 = node2;
            node2.Next = node4;

            var mergeNode = OldProblems.FindMerge(list1, list2);
            mergeNode.Should().BeSameAs(node4);

            OldProblems.FindMerge(list2, node7).Should().BeNull();
        }
    }
}
