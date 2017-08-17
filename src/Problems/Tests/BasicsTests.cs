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
                Misc.Fibonacci_DP2
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
                Sort.MergeSort_BottomUp
            };
            int[] ary = GetRandomArray(100);
            foreach (var sort in sorts)
            {
                int[] aryCopy = new int[100];
                Array.Copy(ary, aryCopy, 100);
                sort(aryCopy);
                IsSorted(aryCopy).Should().Be(true);
            }
        }

        [TestMethod]
        public void FindMaxSubArray()
        {
            int[] ary = new[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };
            var result = Misc.FindMaxSubArray(ary, 0, ary.Length - 1);
            result.Item1.Should().Be(7);
            result.Item2.Should().Be(10);
            result.Item3.Should().Be(43);

            //result = Misc.FindMaxSubArray_linear(ary, 0, ary.Length - 1);
            //result.Item1.Should().Be(7);
            //result.Item2.Should().Be(10);
            //result.Item3.Should().Be(43);

            ary = new[] { -3, -25, -3, -16, -23, -7, -5, -22, -4 };
            result = Misc.FindMaxSubArray(ary, 0, ary.Length - 1);
            result.Item1.Should().Be(0);
            result.Item2.Should().Be(0);
            result.Item3.Should().Be(-3);

            //ary = new[] { -3, -25, -3, -16, -23, -7, -5, -22, -4 };
            //result = Misc.FindMaxSubArray_linear(ary, 0, ary.Length - 1);
            //result.Item1.Should().Be(0);
            //result.Item2.Should().Be(0);
            //result.Item3.Should().Be(-3);
        }

        [TestMethod]
        public void MaxHeap()
        {
            var heap = new MaxHeap<int>();
            heap.Insert(8);
            heap.Insert(3);
            heap.Insert(27);
            heap.Insert(1);
            heap.Insert(101);

            heap.GetMax().Should().Be(101);
            heap.Insert(26);
            heap.GetMax().Should().Be(27);
            heap.GetMax().Should().Be(26);
            heap.GetMax().Should().Be(8);
            heap.GetMax().Should().Be(3);
            heap.GetMax().Should().Be(1);

            Action f = () => heap.GetMax();
            f.ShouldThrow<InvalidOperationException>();
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

        private bool IsSorted(int[] ary)
        {
            int previous = int.MinValue;
            for (int i = 0; i < ary.Length; i++)
            {
                if (ary[i] < previous)
                {
                    return false;
                }
                previous = ary[i];
            }
            return true;
        }
    }
}
