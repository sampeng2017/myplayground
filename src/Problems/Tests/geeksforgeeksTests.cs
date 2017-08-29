using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;
using Problems.Basics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class GeeksforgeeksTests
    {
        [TestMethod]
        [TestCategory("Array")]
        public void KadanesAlgorithm()
        {
            int[] a = new int[] { -1, -2, -3 };
            Geeksforgeeks.KadanesAlgorithm(a).Should().Be(-1);

            a = new int[] { 1, 5, 4 };
            Geeksforgeeks.KadanesAlgorithm(a).Should().Be(10);

            a = new int[] { 1, -3, 0, 7, -6, 5, 3, 4, -1 };
            Geeksforgeeks.KadanesAlgorithm(a).Should().Be(13);
            var validation = Misc.FindMaxSubArray(a, 0, a.Length - 1);
            validation.Item1.Should().Be(3);
            validation.Item2.Should().Be(7);
            validation.Item3.Should().Be(13);
        }

        [TestMethod]
        [TestCategory("String")]
        public void ParenthesisChecker()
        {
            string s = "[()]{}{[()()]()}";
            Geeksforgeeks.ParenthesisChecker(s).Should().BeTrue();
            s = "[()]{}{[()(]()}";
            Geeksforgeeks.ParenthesisChecker(s).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("Stack and Queue")]
        public void NextLargerElement()
        {
            var a = new int[] { 1 };
            var r = Geeksforgeeks.NextLargerElement(a);
            r.Should().BeEquivalentTo(new int[] { -1 });

            a = new int[] { 1, 3, 2, 4 };
            r = Geeksforgeeks.NextLargerElement(a);
            r.Should().BeEquivalentTo(new int[] { 3, 4, 4, -1 });

            a = new int[] { 1 };
            r = Geeksforgeeks.NextLargerElement2(a);
            r.Should().BeEquivalentTo(new int[] { -1 });

            a = new int[] { 1, 3, 2, 4 };
            r = Geeksforgeeks.NextLargerElement2(a);
            r.Should().BeEquivalentTo(new int[] { 3, 4, 4, -1 });
        }
    }
}
