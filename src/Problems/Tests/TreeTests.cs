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
    }
}
