using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.DataStructures;
using Problems;
using FluentAssertions;
using Problems.Basics;

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
