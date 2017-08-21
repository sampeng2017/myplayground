using System;
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
        public void BinarySearchTreeInsert()
        {
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

            var tmp = new List<BinaryTreeNode<int>>();
            bst.Root.InOrderVisit((n) => tmp.Add(n));
            tmp.Should().BeEquivalentTo(new List<BinaryTreeNode<int>> { node2, node3, node1, node5, node4 });

            bst.Find(25).Should().BeSameAs(node2);
            bst.Find(37).Should().BeSameAs(node3);
            bst.Find(58).Should().BeNull();
        }
    }
}
