using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Basics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BasicsTests
    {
        [TestMethod]
        public void Fibonacci()
        {
            var funcs = new List<Func<int, int>>
            {
                Misc.Fibonacci_DP1,
                Misc.Fibonacci_DP2,
                Misc.Fibonacci_NoRecursive
            };

            foreach (var func in funcs)
            {
                func(0).Should().Be(0);
                func(1).Should().Be(1);
                func(2).Should().Be(1);
                func(3).Should().Be(2);
                func(4).Should().Be(3);
                func(5).Should().Be(5);
                func(10).Should().Be(55);
            }
        }

        [TestMethod]
        public void SortTest()
        {
            var sorts = new List<Action<int[]>>
            {
                Sort.InsertionSort,
                Sort.InsertionSort_Recursive,
                Sort.MergeSort,
                Sort.MergeSort_BottomUp,
                Sort.HeapSort,
                Sort.QuickSort,
                (a) => Sort.TailRecursiveQuickSort(a, 0, a.Length - 1)
            };
            int[] ary = GetRandomArray(100);
            foreach (var sort in sorts)
            {
                int[] aryCopy = new int[100];
                Array.Copy(ary, aryCopy, 100);
                sort(aryCopy);
                Helpers.IsSorted(aryCopy).Should().Be(true);
            }
        }

        [TestMethod]
        [TestCategory("Divide and Conquer")]
        public void FindMaxSubArray()
        {
            int[] ary = new[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };
            var result = Misc.FindMaxSubArray(ary, 0, ary.Length - 1);
            result.Item1.Should().Be(7);
            result.Item2.Should().Be(10);
            result.Item3.Should().Be(43);

            ary = new[] { -3, -25, -3, -16, -23, -7, -5, -22, -4 };
            result = Misc.FindMaxSubArray(ary, 0, ary.Length - 1);
            result.Item1.Should().Be(0);
            result.Item2.Should().Be(0);
            result.Item3.Should().Be(-3);
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void MaxHeap()
        {
            var heap = new Heap<int>();
            heap.Insert(8);
            heap.Insert(3);
            heap.Insert(201);
            heap.Insert(27);
            heap.Insert(1);
            heap.Insert(101);
            heap.Insert(231);

            heap.TakeNext().Should().Be(231);
            heap.TakeNext().Should().Be(201);
            heap.TakeNext().Should().Be(101);
            heap.Insert(26);
            heap.TakeNext().Should().Be(27);
            heap.TakeNext().Should().Be(26);
            heap.TakeNext().Should().Be(8);
            heap.TakeNext().Should().Be(3);
            heap.TakeNext().Should().Be(1);

            Action f = () => heap.TakeNext();
            f.ShouldThrow<InvalidOperationException>();

            heap = new Heap<int>(new int[] { 8, 3, 201, 27, 1, 101, 26, 231 });
            heap.TakeNext().Should().Be(231);
            heap.TakeNext().Should().Be(201);
            heap.TakeNext().Should().Be(101);
            heap.TakeNext().Should().Be(27);
            heap.TakeNext().Should().Be(26);
            heap.TakeNext().Should().Be(8);
            heap.TakeNext().Should().Be(3);
            heap.TakeNext().Should().Be(1);
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void MinHeap()
        {
            var heap = new Heap<int>(maxHeap: false);
            heap.Insert(8);
            heap.Insert(3);
            heap.Insert(201);
            heap.Insert(27);
            heap.Insert(1);
            heap.Insert(101);
            heap.Insert(231);
            heap.Insert(26);

            heap.TakeNext().Should().Be(1);
            heap.TakeNext().Should().Be(3);
            heap.TakeNext().Should().Be(8);
            heap.TakeNext().Should().Be(26);
            heap.TakeNext().Should().Be(27);
            heap.TakeNext().Should().Be(101);
            heap.TakeNext().Should().Be(201);
            heap.TakeNext().Should().Be(231);

            Action f = () => heap.TakeNext();
            f.ShouldThrow<InvalidOperationException>();

            heap = new Heap<int>(new int[] { 8, 3, 201, 27, 1, 101, 26, 231 }, maxHeap: false);
            heap.TakeNext().Should().Be(1);
            heap.TakeNext().Should().Be(3);
            heap.TakeNext().Should().Be(8);
            heap.TakeNext().Should().Be(26);
            heap.TakeNext().Should().Be(27);
            heap.TakeNext().Should().Be(101);
            heap.TakeNext().Should().Be(201);
            heap.TakeNext().Should().Be(231);
        }

        [TestMethod]
        public void FindMinAndMax()
        {
            int[] a = new int[] { 34, 2, 9, 45, 8, 27, 5, 11 };
            var minAndMax = Misc.FindMinAndMax(a);
            minAndMax.Item1.Should().Be(2);
            minAndMax.Item2.Should().Be(45);

            a = new int[] { 34, 2, 9, 45, 8, 27, 5, 11, 7 };
            minAndMax = Misc.FindMinAndMax(a);
            minAndMax.Item1.Should().Be(2);
            minAndMax.Item2.Should().Be(45);

            a = new int[] { 34 };
            minAndMax = Misc.FindMinAndMax(a);
            minAndMax.Item1.Should().Be(34);
            minAndMax.Item2.Should().Be(34);
        }

        [TestMethod]
        public void RandomSelectNth()
        {
            int[] a = new int[] { 34, 2, 9, 45, 8, 27, 5, 11 };
            Misc.RandomSelectNth(a, 0, a.Length - 1, 3).Should().Be(8);
            Misc.RandomSelectNth(a, 0, a.Length - 1, 5).Should().Be(11);
            Misc.RandomSelectNthNoRecurisive(a, 3).Should().Be(8);
            Misc.RandomSelectNthNoRecurisive(a, 5).Should().Be(11);

            a = new int[] { 34, 2, 9, 45, 8, 27, 5, 11, 7 };
            Misc.RandomSelectNth(a, 0, a.Length - 1, 3).Should().Be(7);
            Misc.RandomSelectNth(a, 0, a.Length - 1, 5).Should().Be(9);
            Misc.RandomSelectNthNoRecurisive(a, 3).Should().Be(7);
            Misc.RandomSelectNthNoRecurisive(a, 5).Should().Be(9);
        }

        private int[] GetRandomArray(int cnt)
        {
            var ary = new int[cnt];
            var rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < cnt; i++)
            {
                ary[i] = rand.Next();
            }
            return ary;
        }

        [TestMethod]
        public void Gcd()
        {
            Misc.Gcd(21, 14).Should().Be(7);
            Misc.Gcd(3, 0).Should().Be(3);
            Misc.Gcd(7, 13).Should().Be(1);
        }
    }
}
