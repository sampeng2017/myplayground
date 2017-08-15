using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Basics;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BasicsTests
    {
        [TestMethod]
        public void SortTest()
        {
            int[] ary = GetRandomArray(100);

            int[] aryCopy = new int[100];
            Array.Copy(ary, aryCopy, 100);
            Sort.InsertionSort(aryCopy);
            IsSorted(aryCopy).Should().Be(true);

            int[] aryCopy2 = new int[100];
            Array.Copy(ary, aryCopy2, 100);
            Sort.MergeSort(aryCopy2);
            aryCopy2.SequenceEqual(aryCopy).Should().BeTrue();

            int[] aryCopy3 = new int[100];
            Array.Copy(ary, aryCopy3, 100);
            Sort.InsertionSort_Recursive(aryCopy3);
            aryCopy3.SequenceEqual(aryCopy).Should().BeTrue();

            int[] aryCopy4 = new int[100];
            Array.Copy(ary, aryCopy4, 100);
            Sort.MergeSort_BottomUp(aryCopy4);
            aryCopy4.SequenceEqual(aryCopy).Should().BeTrue();
        }

        [TestMethod]
        public void FindMaxSubArray()
        {
            int[] ary = new[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };
            var result = Misc.FindMaxSubArray(ary, 0, ary.Length - 1);
            result.Item1.Should().Be(7);
            result.Item2.Should().Be(10);
            result.Item3.Should().Be(43);

            result = Misc.FindMaxSubArray_linear(ary, 0, ary.Length - 1);
            result.Item1.Should().Be(7);
            result.Item2.Should().Be(10);
            result.Item3.Should().Be(43);

            ary = new[] { -3, -25, -3, -16, -23, -7, -5, -22, -4 };
            result = Misc.FindMaxSubArray(ary, 0, ary.Length - 1);
            result.Item1.Should().Be(0);
            result.Item2.Should().Be(0);
            result.Item3.Should().Be(-3);

            ary = new[] { -3, -25, -3, -16, -23, -7, -5, -22, -4 };
            result = Misc.FindMaxSubArray_linear(ary, 0, ary.Length - 1);
            result.Item1.Should().Be(0);
            result.Item2.Should().Be(0);
            result.Item3.Should().Be(-3);
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
