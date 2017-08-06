using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.DataStructures;
using Problems;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class LeetCoderTests
    {
        [TestMethod]
        public void CanPlaceFlower()
        {
            int[] testBed1 = new int[] { 1, 0, 0 };
            LeetCoder.CanPlaceFlower(testBed1, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed1, 2).Should().BeFalse();

            int[] testBed2 = new int[] { 1, 0, 0, 0, 1 };
            LeetCoder.CanPlaceFlower(testBed2, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed2, 2).Should().BeFalse();
            LeetCoder.CanPlaceFlower(testBed2, 3).Should().BeFalse();

            int[] testBed3 = new int[] { 0, 0, 0, 0, 0 };
            LeetCoder.CanPlaceFlower(testBed3, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed3, 2).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed3, 3).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed3, 4).Should().BeFalse();

            int[] testBed4 = new int[] { 1, 1, 1, 1, 1 };
            LeetCoder.CanPlaceFlower(testBed4, 1).Should().BeFalse();

            int[] testBed5 = new int[] { 1, 0, 0, 0, 0, 1, 0, 0 };
            LeetCoder.CanPlaceFlower(testBed5, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed5, 2).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed5, 3).Should().BeFalse();

            int[] testBed6 = new int[] { 0 };
            LeetCoder.CanPlaceFlower(testBed6, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed6, 2).Should().BeFalse();

            int[] testBed7 = new int[] { 0, 0, 0, 0, 0, 1, 0, 1 };
            LeetCoder.CanPlaceFlower(testBed7, 1).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed7, 2).Should().BeTrue();
            LeetCoder.CanPlaceFlower(testBed7, 3).Should().BeFalse();
        }
    }
}
