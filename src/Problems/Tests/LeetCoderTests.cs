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
        public void TwoSum()
        {
            var testAry1 = new int[] { 2, 7, 11, 15};
            var result = LeetCoder.TwoSum(testAry1, 9);
            result.Item1.Should().Be(0);
            result.Item2.Should().Be(1);

            result = LeetCoder.TwoSum(testAry1, 22);
            result.Item1.Should().Be(1);
            result.Item2.Should().Be(3);

            var testAry2 = new int[] { -2, 7, -11, 0, 15, 8, 7, 27, -3};
            result = LeetCoder.TwoSum(testAry2, 15);
            result.Item1.Should().Be(3);
            result.Item2.Should().Be(4);

            result = LeetCoder.TwoSum(testAry2, 23);
            result.Item1.Should().Be(4);
            result.Item2.Should().Be(5);

            result = LeetCoder.TwoSum(testAry2, 4);
            result.Item1.Should().Be(2);
            result.Item2.Should().Be(4);
        }

        [TestMethod]
        public void AddTowNumbers()
        {
            ListNode<int> l1 = LeetCoder.BuildLinkedListFromValue(342);
            LeetCoder.LinkedListToValue(l1).Should().Be(342);

            ListNode<int> l2 = LeetCoder.BuildLinkedListFromValue(465);
            LeetCoder.LinkedListToValue(l2).Should().Be(465);

            ListNode<int> l = LeetCoder.AddTowNumbers(l1, l2);
            LeetCoder.LinkedListToValue(l).Should().Be(807);

            l1 = LeetCoder.BuildLinkedListFromValue(10);
            l2 = LeetCoder.BuildLinkedListFromValue(2);
            l = LeetCoder.AddTowNumbers(l1, l2);
            LeetCoder.LinkedListToValue(l).Should().Be(12);

            l1 = LeetCoder.BuildLinkedListFromValue(3271);
            l2 = LeetCoder.BuildLinkedListFromValue(50369);
            l = LeetCoder.AddTowNumbers(l1, l2);
            LeetCoder.LinkedListToValue(l).Should().Be(53640);

            l1 = LeetCoder.BuildLinkedListFromValue(87);
            l2 = LeetCoder.BuildLinkedListFromValue(969);
            l = LeetCoder.AddTowNumbers(l1, l2);
            LeetCoder.LinkedListToValue(l).Should().Be(1056);
        }

        [TestMethod]
        public void LongestSubstrWithoutRepeatingChars()
        {
            var r = LeetCoder.LongestSubstrWithoutRepeatingChars("b");
            r.Should().Be("b");

            r = LeetCoder.LongestSubstrWithoutRepeatingChars("abcde");
            r.Should().Be("abcde");

            r = LeetCoder.LongestSubstrWithoutRepeatingChars("abcabc");
            r.Should().Be("abc");

            r = LeetCoder.LongestSubstrWithoutRepeatingChars("abcada");
            r.Should().Be("bcad");

            r = LeetCoder.LongestSubstrWithoutRepeatingChars("abcada12z2dj");
            r.Should().Be("da12z");

            r = LeetCoder.LongestSubstrWithoutRepeatingChars("1123157a238jkg5392109742312ad");
            r.Should().Be("157a238jkg");
        }

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
