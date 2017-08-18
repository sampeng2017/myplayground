using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Basics;
using Problems.DataStructures;
using Problems;

namespace Tests
{
    [TestClass]
    public class OthersTests
    {
        [TestMethod]
        public void CountThePath()
        {
            bool[,] board = new bool[,]
            {
                {true, true, true, true, true },
                {true, false, true, true, false },
                {true, true, false, true, true },
                {true, true, true, true, true },
                {true, false, true, false, true },
            };

            int paths = Others.CountThePath(board);
            paths.Should().Be(6);
        }
    }
}
