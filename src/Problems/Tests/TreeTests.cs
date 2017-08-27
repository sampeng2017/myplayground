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
    public class TreeTests
    {
        [TestMethod]
        public void InOrderVisit()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int> { Value = 1 };
            root.LeftChild = new BinaryTreeNode<int> { Value = 2 };
            root.LeftChild.LeftChild = new BinaryTreeNode<int> { Value = 4 };
            root.LeftChild.RightChild = new BinaryTreeNode<int> { Value = 5 };

            root.RightChild = new BinaryTreeNode<int> { Value = 3 };
            root.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 6 };
            root.RightChild.RightChild = new BinaryTreeNode<int> { Value = 7 };
            root.RightChild.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 8 };

            var list = new List<BinaryTreeNode<int>>();
            root.InOrderVisit(n => list.Add(n));
            list[0].Should().BeSameAs(root.LeftChild.LeftChild);
            list[1].Should().BeSameAs(root.LeftChild);
            list[2].Should().BeSameAs(root.LeftChild.RightChild);
            list[3].Should().BeSameAs(root);
            list[4].Should().BeSameAs(root.RightChild.LeftChild);
            list[5].Should().BeSameAs(root.RightChild);
            list[6].Should().BeSameAs(root.RightChild.RightChild.LeftChild);
            list[7].Should().BeSameAs(root.RightChild.RightChild);

            list.Clear();
            BinaryTreeNode<int>.InOrderVisitNoRecursion(root, n => list.Add(n));
            list[0].Should().BeSameAs(root.LeftChild.LeftChild);
            list[1].Should().BeSameAs(root.LeftChild);
            list[2].Should().BeSameAs(root.LeftChild.RightChild);
            list[3].Should().BeSameAs(root);
            list[4].Should().BeSameAs(root.RightChild.LeftChild);
            list[5].Should().BeSameAs(root.RightChild);
            list[6].Should().BeSameAs(root.RightChild.RightChild.LeftChild);
            list[7].Should().BeSameAs(root.RightChild.RightChild);
        }

        [TestMethod]
        public void PreOrderVisit()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int> { Value = 1 };
            root.LeftChild = new BinaryTreeNode<int> { Value = 2 };
            root.LeftChild.LeftChild = new BinaryTreeNode<int> { Value = 4 };
            root.LeftChild.RightChild = new BinaryTreeNode<int> { Value = 5 };

            root.RightChild = new BinaryTreeNode<int> { Value = 3 };
            root.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 6 };
            root.RightChild.RightChild = new BinaryTreeNode<int> { Value = 7 };
            root.RightChild.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 8 };

            var list = new List<int>();
            root.PreOrderVisit(n => list.Add(n.Value));
            list[0].Should().Be(1);
            list[1].Should().Be(2);
            list[2].Should().Be(4);
            list[3].Should().Be(5);
            list[4].Should().Be(3);
            list[5].Should().Be(6);
            list[6].Should().Be(7);
            list[7].Should().Be(8);

            list.Clear();
            BinaryTreeNode<int>.PreOrderVisitNoRecursion(root, n => list.Add(n.Value));
            list[0].Should().Be(1);
            list[1].Should().Be(2);
            list[2].Should().Be(4);
            list[3].Should().Be(5);
            list[4].Should().Be(3);
            list[5].Should().Be(6);
            list[6].Should().Be(7);
            list[7].Should().Be(8);
        }

        [TestMethod]
        public void BinarySearchTree()
        {
            var tmpNode1 = new BinaryTreeNode<int> { Value = 5 };
            var tmpNode2 = new BinaryTreeNode<int> { Value = 1 };
            tmpNode1.RightChild = tmpNode2;
            BinarySearchTree<int>.IsValidBsf(tmpNode1).Should().BeFalse();

            var bst = new BinarySearchTree<int>();
            var node1 = new BinaryTreeNode<int> { Value = 40 };
            var node2 = new BinaryTreeNode<int> { Value = 25 };
            var node3 = new BinaryTreeNode<int> { Value = 37 };
            var node4 = new BinaryTreeNode<int> { Value = 72 };
            var node5 = new BinaryTreeNode<int> { Value = 43 };
            bst.Insert(node1);
            bst.Insert(node2);
            bst.Insert(node3);
            bst.Insert(node4);
            bst.Insert(node5);
            BinarySearchTree<int>.IsValidBsf(node1).Should().BeTrue();
            bst.MaxValue.Should().Be(72);
            bst.MinValue.Should().Be(25);

            var tmp = new List<BinaryTreeNode<int>>();
            bst.Root.InOrderVisit((n) => tmp.Add(n));
            tmp.Should().BeEquivalentTo(new List<BinaryTreeNode<int>> { node2, node3, node1, node5, node4 });

            bst.Find(25).Should().BeSameAs(node2);
            bst.Find(37).Should().BeSameAs(node3);
            bst.Find(58).Should().BeNull();
        }

        [TestMethod]
        public void BuildTreeFromInOrderAndPreOrderTraverse()
        {
            char[] preOrder = new char[] { 'A', 'B', 'D', 'H', 'E', 'C', 'F', 'G' };
            char[] inOrder = new char[] { 'H', 'D', 'B', 'E', 'A', 'F', 'C', 'G' };
            var tree = OldProblems.BuildTreeFromInOrderAndPreOrderTraverse(preOrder, inOrder);

            var collector1 = new List<char>();
            tree.PreOrderVisit(n => collector1.Add(n.Value));
            var collector2 = new List<char>();
            tree.InOrderVisit(n => collector2.Add(n.Value));

            collector1.ToArray().Should().BeEquivalentTo(preOrder);
            collector2.ToArray().Should().BeEquivalentTo(inOrder);


            preOrder = new char[] { 'A', 'B', 'D', 'F', 'G', 'C', 'E', 'H' };
            inOrder = new char[] { 'B', 'F', 'D', 'G', 'A', 'C', 'H', 'E' };
            tree = OldProblems.BuildTreeFromInOrderAndPreOrderTraverse(preOrder, inOrder);

            collector1 = new List<char>();
            tree.PreOrderVisit(n => collector1.Add(n.Value));
            collector2 = new List<char>();
            tree.InOrderVisit(n => collector2.Add(n.Value));

            collector1.ToArray().Should().BeEquivalentTo(preOrder);
            collector2.ToArray().Should().BeEquivalentTo(inOrder);

            preOrder = new char[] { 'A', 'B', 'C'};
            inOrder = new char[] { 'B', 'C', 'A' };
            tree = OldProblems.BuildTreeFromInOrderAndPreOrderTraverse(preOrder, inOrder);

            collector1 = new List<char>();
            tree.PreOrderVisit(n => collector1.Add(n.Value));
            collector2 = new List<char>();
            tree.InOrderVisit(n => collector2.Add(n.Value));

            collector1.ToArray().Should().BeEquivalentTo(preOrder);
            collector2.ToArray().Should().BeEquivalentTo(inOrder);
        }

        [TestMethod]
        public void SearchAndReturnPath()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int> { Value = 1 };
            root.LeftChild = new BinaryTreeNode<int> { Value = 2 };
            root.LeftChild.LeftChild = new BinaryTreeNode<int> { Value = 4 };
            root.LeftChild.RightChild = new BinaryTreeNode<int> { Value = 5 };
            root.RightChild = new BinaryTreeNode<int> { Value = 3 };
            root.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 6 };
            root.RightChild.RightChild = new BinaryTreeNode<int> { Value = 7 };
            root.RightChild.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 8 };

            var path = root.SearchAndReturnPath(6);
            path.Should().NotBeNull();
            path.Select(n => n.Value).ToArray().Should().BeEquivalentTo(new int[] { 1, 3, 6 });

            path = root.SearchAndReturnPath(8);
            path.Should().NotBeNull();
            path.Select(n => n.Value).ToArray().Should().BeEquivalentTo(new int[] { 1, 3, 7, 8 });

            path = root.SearchAndReturnPath(12);
            path.Should().BeNull();
        }

        [TestMethod]
        public void FindLowestCommonAncestor()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int> { Value = 1 };
            root.LeftChild = new BinaryTreeNode<int> { Value = 2 };
            root.LeftChild.LeftChild = new BinaryTreeNode<int> { Value = 4 };
            root.LeftChild.RightChild = new BinaryTreeNode<int> { Value = 5 };
            root.RightChild = new BinaryTreeNode<int> { Value = 3 };
            root.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 6 };
            root.RightChild.RightChild = new BinaryTreeNode<int> { Value = 7 };
            root.RightChild.RightChild.LeftChild = new BinaryTreeNode<int> { Value = 8 };

            var result = OldProblems.FindLowestCommonAncestor(root, 6, 8);
            result.Should().BeSameAs(root.RightChild);
        }
    }
}
