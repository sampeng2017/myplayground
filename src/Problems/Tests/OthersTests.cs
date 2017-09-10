using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Basics;
using Problems.DataStructures;
using Problems;
using static Problems.Others;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        [TestCategory("Dynamic Programming")]
        public void GetNumberOfStationsCanBeRemoved()
        {
            var stations = new List<GasStation>
            {
                new GasStation(5, 5),
                new GasStation(20, 10),
                new GasStation(40, 10)
            };
            int r = GasStationProblem.GetNumberOfStationsCanBeRemoved(40, stations);
            r.Should().Be(0);

            stations = new List<GasStation>
            {
                new GasStation(5, 5),
                new GasStation(11, 8),
                new GasStation(20, 10),
                new GasStation(40, 10),
                new GasStation(30, 3),
            };
            r = GasStationProblem.GetNumberOfStationsCanBeRemoved(40, stations);
            r.Should().Be(2);

            stations = new List<GasStation>
            {
                new GasStation(0, 10),
                new GasStation(10, 10),
                new GasStation(20, 10),
                new GasStation(30, 10),
                new GasStation(40, 10),
            };
            r = GasStationProblem.GetNumberOfStationsCanBeRemoved(40, stations);
            r.Should().Be(3);

            stations = new List<GasStation>
            {
                new GasStation(10, 10),
                new GasStation(18, 10),
                new GasStation(25, 10)
            };
            r = GasStationProblem.GetNumberOfStationsCanBeRemoved(40, stations);
            r.Should().Be(-1);

            stations = new List<GasStation>
            {
                new GasStation(10, 10),
                new GasStation(18, 10),
                new GasStation(25, 15),
                new GasStation(25, 15)
            };
            r = GasStationProblem.GetNumberOfStationsCanBeRemoved(40, stations);
            r.Should().Be(2);
        }

        [TestMethod]
        [TestCategory("Greedy")]
        public void GetNumberOfStationsCanBeRemoved_Greedy()
        {
            var stations = new List<GasStation>
            {
                new GasStation(5, 5),
                new GasStation(20, 10),
                new GasStation(40, 10)
            };
            int r = GasStationProblem.GetNumberOfStationsCanBeRemoved_Greedy(40, stations);
            r.Should().Be(0);

            stations = new List<GasStation>
            {
                new GasStation(5, 5),
                new GasStation(11, 8),
                new GasStation(20, 10),
                new GasStation(40, 10),
                new GasStation(30, 3),
            };
            r = GasStationProblem.GetNumberOfStationsCanBeRemoved_Greedy(40, stations);
            r.Should().Be(2);

            stations = new List<GasStation>
            {
                new GasStation(0, 10),
                new GasStation(10, 10),
                new GasStation(20, 10),
                new GasStation(30, 10),
                new GasStation(40, 10),
            };
            r = GasStationProblem.GetNumberOfStationsCanBeRemoved_Greedy(40, stations);
            r.Should().Be(3);

            stations = new List<GasStation>
            {
                new GasStation(10, 10),
                new GasStation(18, 10),
                new GasStation(25, 10)
            };
            r = GasStationProblem.GetNumberOfStationsCanBeRemoved_Greedy(40, stations);
            r.Should().Be(-1);

            stations = new List<GasStation>
            {
                new GasStation(10, 10),
                new GasStation(18, 10),
                new GasStation(25, 15),
                new GasStation(25, 15)
            };
            r = GasStationProblem.GetNumberOfStationsCanBeRemoved_Greedy(40, stations);
            r.Should().Be(2);
        }

        [TestMethod]
        public void GasStation_AllConvered()
        {
            var stations = new GasStation[]
            {
                new GasStation(5, 5),
                new GasStation(20, 10),
                new GasStation(40, 10)
            };
            Array.Sort(stations);
            GasStationProblem.AllCovered(40, stations).Should().Be(true);

            stations = new GasStation[]
            {
                new GasStation(5, 5),
                new GasStation(11, 8),
                new GasStation(20, 10),
                new GasStation(40, 10),
                new GasStation(30, 3),
            };
            Array.Sort(stations);
            GasStationProblem.AllCovered(40, stations).Should().Be(true);

            stations = new GasStation[]
            {
                new GasStation(10, 10),
                new GasStation(18, 10),
                new GasStation(25, 10)
            };
            Array.Sort(stations);
            GasStationProblem.AllCovered(40, stations).Should().Be(false);

            stations = new GasStation[]
            {
                new GasStation(0, 10),
                new GasStation(10, 10),
                new GasStation(20, 10),
                new GasStation(30, 10),
                new GasStation(40, 10),
            };
            Array.Sort(stations);
            GasStationProblem.AllCovered(40, stations).Should().Be(true);
        }

        [TestMethod]
        public void FerryQuestion_MinTime()
        {
            int[] arriveAts = new int[] { 10 };
            List<int[]> trace = new List<int[]>();
            int minTime = Others.FerryQuestion_MinTime(2, 10, arriveAts, 0, trace);
            minTime.Should().Be(20);

            arriveAts = new int[] { 10, 20 };
            trace.Clear();
            minTime = Others.FerryQuestion_MinTime(2, 10, arriveAts, 0, trace);
            minTime.Should().Be(30);

            arriveAts = new int[] { 10, 30, 40 };
            trace.Clear();
            minTime = Others.FerryQuestion_MinTime(2, 10, arriveAts, 0, trace);
            minTime.Should().Be(50);

            arriveAts = new int[] { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            trace.Clear();
            minTime = Others.FerryQuestion_MinTime(2, 10, arriveAts, 0, trace);
            minTime.Should().Be(100);

            arriveAts = new int[] { 5, 15, 35, 40, 40, 70, 75 };
            trace.Clear();
            minTime = Others.FerryQuestion_MinTime(2, 10, arriveAts, 0, trace);
            minTime.Should().Be(85);
        }

        [TestMethod]
        public void ReservoirSampling_SelectNumberofRandomItems()
        {
            var largeInput = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                largeInput.Add(i);
            }
            var result = Others.ReservoirSampling_SelectNumberofRandomItems(largeInput, 10);
            //not much to validate
            result.Should().HaveCount(10);
        }

        [TestMethod]
        [TestCategory("Array")]
        public void AlternateArrayItems()
        {
            var a = new int[] { 1, 2, 11, 12 };
            ProblemFromBooks.AlternateArrayItems(a);
            a.Should().BeEquivalentTo(new int[] { 1, 11, 2, 12 });

            a = new int[] { 1, 2, 3, 4, 11, 12, 13, 14 };
            ProblemFromBooks.AlternateArrayItems(a);
            a.Should().BeEquivalentTo(new int[] { 1, 11, 2, 12, 3, 13, 4, 14 });

            a = new int[] { 1, 11 };
            ProblemFromBooks.AlternateArrayItems(a);
            a.Should().BeEquivalentTo(new int[] { 1, 11 });

            a = new int[] { 1, 2, 3, 4, 5, 11, 12, 13, 14, 15 };
            ProblemFromBooks.AlternateArrayItems(a);
            a.Should().BeEquivalentTo(new int[] { 1, 11, 2, 12, 3, 13, 4, 14, 5, 15 });
        }

        [TestMethod]
        public void RandomSampling()
        {
            var result = Others.RandomSampling(100, 5);
            result.Distinct().ToArray().Should().HaveCount(5);
            result.Any(r => r > 100).Should().BeFalse();
        }

        [TestMethod]
        public void StackWithMin()
        {
            var stackWithMin = new StackWithMin();
            stackWithMin.Push(20);
            stackWithMin.GetMin().Should().Be(20);

            stackWithMin.Push(30);
            stackWithMin.Push(15);
            stackWithMin.GetMin().Should().Be(15);

            stackWithMin.Pop();
            stackWithMin.GetMin().Should().Be(20);
        }

        [TestMethod]
        public void GenerateSubsets()
        {
            int[] s = new int[] { 1 };
            var result = ProblemFromBooks.GenerateSubsets(s);
            result.Should().HaveCount(1);

            s = new int[] { 1, 2 };
            result = ProblemFromBooks.GenerateSubsets(s);
            result.Should().HaveCount(3);

            s = new int[] { 1, 2, 3 };
            result = ProblemFromBooks.GenerateSubsets(s);
            result.Should().HaveCount(7);
            result[0].Should().BeEquivalentTo(new int[] { 1 });
            result[1].Should().BeEquivalentTo(new int[] { 2 });
            result[2].Should().BeEquivalentTo(new int[] { 3 });
            result[3].Should().BeEquivalentTo(new int[] { 2, 3 });
            result[4].Should().BeEquivalentTo(new int[] { 1, 2 });
            result[5].Should().BeEquivalentTo(new int[] { 1, 3 });
            result[6].Should().BeEquivalentTo(new int[] { 1, 2, 3 });

            s = new int[] { 1, 2, 3, 4 };
            result = ProblemFromBooks.GenerateSubsets(s);
            result.Should().HaveCount(15);
        }

        [TestMethod]
        public void IsNumberPowerOfTwo()
        {
            ProblemFromBooks.IsNumberPowerOfTwo(2).Should().BeTrue();
            ProblemFromBooks.IsNumberPowerOfTwo(4).Should().BeTrue();
            ProblemFromBooks.IsNumberPowerOfTwo(8).Should().BeTrue();
            ProblemFromBooks.IsNumberPowerOfTwo(256).Should().BeTrue();
            ProblemFromBooks.IsNumberPowerOfTwo(12).Should().BeFalse();
        }

        [TestMethod]
        public void CountAllNegativeNumbersInSorted2DArray()
        {
            var a = new int[,]
            {
                {-3,-2,-1, 1 },
                {-2, 2, 3, 4 },
                { 4, 5, 7, 8 }
            };
            Others.CountAllNegativeNumbersInSorted2DArray(a).Should().Be(4);
        }
    }
}
