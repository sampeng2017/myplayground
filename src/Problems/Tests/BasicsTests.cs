using System;
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
            Action<int[]> sort = Sort.InsertionSort;
            sort(ary);
            IsSorted(ary).Should().Be(true);
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
                if (ary[i]< previous)
                {
                    return false;
                }
                previous = ary[i];
            }
            return true;
        }
    }
}
