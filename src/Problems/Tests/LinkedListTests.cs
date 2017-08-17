using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Basics;
using Problems.DataStructures;

namespace Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void FindMidNode()
        {
            var linkedList = new ListNode<int> { Value = 1 };
            linkedList.Next = new ListNode<int> { Value = 2 };
            linkedList.Next.Next = new ListNode<int> { Value = 3 };
            var node = LinkedList.FindMidNode(linkedList);
            node.Value.Should().Be(2);

            linkedList.Next.Next.Next = new ListNode<int> { Value = 4 };
            node = LinkedList.FindMidNode(linkedList);
            node.Value.Should().Be(2);

            linkedList.Next.Next.Next.Next = new ListNode<int> { Value = 5 };
            node = LinkedList.FindMidNode(linkedList);
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

            var mergeNode = LinkedList.FindMerge(list1, list2);
            mergeNode.Should().BeSameAs(node4);

            LinkedList.FindMerge(list2, node7).Should().BeNull();
        }

        [TestMethod]
        public void ReverseLinkedList()
        {
            var linkedList = new ListNode<int> { Value = 1 };
            linkedList.Next = new ListNode<int> { Value = 2 };
            linkedList.Next.Next = new ListNode<int> { Value = 3 };
            linkedList.Next.Next.Next = new ListNode<int> { Value = 4 };

            Func<ListNode<int>, ListNode<int>> func1 = LinkedList.Reverse_Recursive;
            Func<ListNode<int>, ListNode<int>> func2 = LinkedList.Reverse_NonRecursive;

            var reversed1 = func1(linkedList);
            reversed1.Value.Should().Be(4);
            reversed1.Next.Value.Should().Be(3);
            reversed1.Next.Next.Value.Should().Be(2);
            reversed1.Next.Next.Next.Value.Should().Be(1);
            reversed1.Next.Next.Next.Next.Should().BeNull();

            var reversed2 = func2(reversed1);
            reversed2.Value.Should().Be(1);
            reversed2.Next.Value.Should().Be(2);
            reversed2.Next.Next.Value.Should().Be(3);
            reversed2.Next.Next.Next.Value.Should().Be(4);
            reversed2.Next.Next.Next.Next.Should().BeNull();
        }

        [TestMethod]
        public void AlternateLists()
        {
            var linkedList1 = new ListNode<int> { Value = 1 };
            linkedList1.Next = new ListNode<int> { Value = 2 };
            linkedList1.Next.Next = new ListNode<int> { Value = 3 };

            var linkedList2 = new ListNode<int> { Value = 101 };
            linkedList2.Next = new ListNode<int> { Value = 102 };
            linkedList2.Next.Next = new ListNode<int> { Value = 103 };
            linkedList2.Next.Next.Next = new ListNode<int> { Value = 104 };

            LinkedList.AlternateLists(linkedList1, linkedList2);

            linkedList1.Value.Should().Be(1);
            linkedList1.Next.Value.Should().Be(101);
            linkedList1.Next.Next.Value.Should().Be(2);
            linkedList1.Next.Next.Next.Value.Should().Be(102);
            linkedList1.Next.Next.Next.Next.Value.Should().Be(3);
            linkedList1.Next.Next.Next.Next.Next.Value.Should().Be(103);
            linkedList1.Next.Next.Next.Next.Next.Next.Value.Should().Be(104);
            linkedList1.Next.Next.Next.Next.Next.Next.Next.Should().BeNull();
        }

        [TestMethod]
        public void FindStartingNodeOfLoop()
        {
            var node1 = new ListNode<int> { Value = 1 };
            var node2 = new ListNode<int> { Value = 2 };
            var node3 = new ListNode<int> { Value = 3 };
            var node4 = new ListNode<int> { Value = 4 };
            var node5 = new ListNode<int> { Value = 5 };
            var node6 = new ListNode<int> { Value = 6 };
            var node7 = new ListNode<int> { Value = 7 };

            LinkedList.FindStartingNodeOfLoop<int>(null).Should().BeNull();
            LinkedList.FindStartingNodeOfLoop(node1).Should().BeNull();

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;
            LinkedList.FindStartingNodeOfLoop(node1).Should().BeNull();

            node7.Next = node1;
            LinkedList.FindStartingNodeOfLoop(node1).Should().BeSameAs(node1);
            node7.Next = node2;
            LinkedList.FindStartingNodeOfLoop(node1).Should().BeSameAs(node2);
            node7.Next = node3;
            LinkedList.FindStartingNodeOfLoop(node1).Should().BeSameAs(node3);
            node7.Next = node4;
            LinkedList.FindStartingNodeOfLoop(node1).Should().BeSameAs(node4);
            node7.Next = node5;
            LinkedList.FindStartingNodeOfLoop(node1).Should().BeSameAs(node5);
            node7.Next = node6;
            LinkedList.FindStartingNodeOfLoop(node1).Should().BeSameAs(node6);
            node7.Next = node7;
            LinkedList.FindStartingNodeOfLoop(node1).Should().BeSameAs(node7);
        }

        [TestMethod]
        public void MergeTwoSortedLinkedLis()
        {
            var node11 = new ListNode<int> { Value = 5 };
            var node12 = new ListNode<int> { Value = 9 };
            var node13 = new ListNode<int> { Value = 15 };
            var node14 = new ListNode<int> { Value = 16 };
            var node15 = new ListNode<int> { Value = 21 };
            var node16 = new ListNode<int> { Value = 33 };
            var node17 = new ListNode<int> { Value = 90 };
            node11.Next = node12;
            node12.Next = node13;
            node13.Next = node14;
            node14.Next = node15;
            node15.Next = node16;
            node16.Next = node17;

            var node21 = new ListNode<int> { Value = 3 };
            var node22 = new ListNode<int> { Value = 19 };
            var node23 = new ListNode<int> { Value = 26 };
            var node24 = new ListNode<int> { Value = 33 };
            var node25 = new ListNode<int> { Value = 95 };
            node21.Next = node22;
            node22.Next = node23;
            node23.Next = node24;
            node24.Next = node25;

            var merged = LinkedList.MergeTwoSortedLinkedList(node11, node21);
            merged.Value.Should().Be(3);
            merged.Next.Value.Should().Be(5);
            merged.Next.Next.Value.Should().Be(9);
            merged.Next.Next.Next.Value.Should().Be(15);
            merged.Next.Next.Next.Next.Value.Should().Be(16);
            merged.Next.Next.Next.Next.Next.Value.Should().Be(19);
            merged.Next.Next.Next.Next.Next.Next.Value.Should().Be(21);
            merged.Next.Next.Next.Next.Next.Next.Next.Value.Should().Be(26);
            merged.Next.Next.Next.Next.Next.Next.Next.Next.Value.Should().Be(33);
            merged.Next.Next.Next.Next.Next.Next.Next.Next.Next.Value.Should().Be(33);
            merged.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Value.Should().Be(90);
            merged.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Value.Should().Be(95);
            merged.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Should().BeNull();
        }

        [TestMethod]
        public void MergeSortLinkedLis()
        {
            var node11 = new ListNode<int> { Value = 9 };
            var node12 = new ListNode<int> { Value = 5 };
            var node13 = new ListNode<int> { Value = 90};
            var node14 = new ListNode<int> { Value = 16 };
            var node15 = new ListNode<int> { Value = 33 };
            var node16 = new ListNode<int> { Value = 21 };
            var node17 = new ListNode<int> { Value = 15 };
            node11.Next = node12;
            node12.Next = node13;
            node13.Next = node14;
            node14.Next = node15;
            node15.Next = node16;
            node16.Next = node17;

            var merged = LinkedList.MergeSort(node11);
            merged.Value.Should().Be(5);
            merged.Next.Value.Should().Be(9);
            merged.Next.Next.Value.Should().Be(15);
            merged.Next.Next.Next.Value.Should().Be(16);
            merged.Next.Next.Next.Next.Value.Should().Be(21);
            merged.Next.Next.Next.Next.Next.Value.Should().Be(33);
            merged.Next.Next.Next.Next.Next.Next.Value.Should().Be(90);
        }
    }
}
