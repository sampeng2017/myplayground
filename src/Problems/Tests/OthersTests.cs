using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Basics;
using Problems.DataStructures;
using Problems;
using static Problems.Others;
using System.Collections.Generic;

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
    }
}
