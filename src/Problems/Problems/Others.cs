﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public static class Others
    {
        public static int CountThePath(bool[,] board)
        {
            var memo = new Dictionary<Tuple<int, int>, int>();
            return CountThePath(board, 0, 0, memo);
        }

        private static int CountThePath(bool[,] board, int row, int col, Dictionary<Tuple<int, int>, int> memo)
        {
            if (row == board.GetLength(0) ||
                col == board.GetLength(1) ||
                !board[row, col])
                return 0;
            if (row == board.GetLength(0) - 1 && col == board.GetLength(1) - 1)
                return 1;
            var key = Tuple.Create(row, col);
            if (memo.ContainsKey(key))
                return memo[key];
            var result = CountThePath(board, row + 1, col, memo) + CountThePath(board, row, col + 1, memo);
            memo.Add(key, result);
            return result;
        }

        /*
        G gas stations are authorized to operate over a road of length L. Each gas station is able to sell fuel
        over a specific area of influence, defined as the closed interval [x − r, x + r], where x is the station’s
        location on the road (0 ≤ x ≤ L) and r is its radius of coverage (0 < r ≤ L). The points covered by a
        gas station are those within its radius of coverage.
        It is clear that the areas of influence may interfere, causing disputes among the corresponding gas
        stations. It seems to be better to close some stations, trying to minimize such interferences without
        reducing the service availability along the road.
        The owners have agreed to close some gas stations in order to avoid as many disputes as possible.
        You have been hired to write a program to determine the maximum number of gas stations that may
        be closed, so that every point on the road is in the area of influence of some remaining station. By the
        way, if some point on the road is not covered by any gas station, you must acknowledge the situation
        and inform about it.
        Input
        The input consists of several test cases. The first line of each test case contains two integer numbers
        L and G (separated by a blank), representing the length of the road and the number of gas stations,
        respectively (1 ≤ L ≤ 108
        , 1 ≤ G ≤ 104
        ). Each one of the next G lines contains two integer numbers
        xi and ri (separated by a blank) where xi
        is the location and ri
        is the radius of coverage of the i-th
        gas station (0 ≤ xi ≤ L, 0 < ri ≤ L). The last test case is followed by a line containing two zeros.
        Output
        For each test case, print a line with the maximum number of gas stations that can be eliminated, so
        that every point on the road belongs to the area of influence of some not closed station. If some point
        on the road is not covered by any of the initial G gas stations, print ‘-1’ as the answer for such a case.
        Sample Input
        40 3
        5 5
        20 10
        40 10

        40 5
        5 5
        11 8
        20 10
        30 3
        40 10

        40 5
        0 10
        10 10
        20 10
        30 10
        40 10

        40 3
        10 10
        18 10
        25 10

        40 3
        10 10
        18 10
        25 15
        0 0
        Sample Output
        0
        2
        3
        -1
         * */
        public static class GasStationProblem
        {
            public static int GetNumberOfStationsCanBeRemoved(int l, List<GasStation> stations)
            {
                if (stations == null) return -1;

                stations.Sort();
                return GetNumberOfStationsCanBeRemoved(l, stations, new Dictionary<string, int>());
            }

            private  static int GetNumberOfStationsCanBeRemoved(int l, List<GasStation> stations, Dictionary<string, int> solutionMemo)
            {
                int cnt;
                string symbol = ToSymbolString(stations);
                if (solutionMemo.TryGetValue(symbol, out cnt))
                {
                    return cnt;
                }

                if (!AllCovered(l, stations))
                    return -1;

                cnt = 0;
                for (int i = 0; i < stations.Count; i++)
                {
                    var current = stations[i];
                    var withOutCurrent = stations.Where(s => !ReferenceEquals(s, current)).ToArray();

                    int tmpCnt = 0;
                    if (AllCovered(l, withOutCurrent))
                    {
                        tmpCnt = 1 + GetNumberOfStationsCanBeRemoved(l, withOutCurrent.ToList(), solutionMemo);
                        cnt = Math.Max(cnt, tmpCnt);
                    }
                }
                solutionMemo.Add(symbol, cnt);
                return cnt;
            }

            // Assume stations sorted by RangeLow 
            public static bool AllCovered(int l, IList<GasStation> stations)
            {
                if (stations.Count == 0)
                    return false;

                int start = stations.First().CoverageStart;
                if (start != 0)
                    return false;

                int currentCoverage = stations.First().CoverageEnd;
                foreach (var s in stations.Skip(1))
                {
                    if (currentCoverage < s.CoverageStart)
                        return false;


                    if (currentCoverage <= s.CoverageEnd)
                        currentCoverage = s.CoverageEnd;
                }
                return currentCoverage >= l;
            }
        }

        private static string ToSymbolString(IList<GasStation> stations)
        {
            return string.Join(";", stations.Select((s) => s.GetSymbolString()).ToArray());
        }
        public class GasStation : IComparable<GasStation>
        {
            public GasStation(int location, int ridius)
            {
                Location = location;
                Ridius = ridius;
            }

            public int Location { get; }
            public int Ridius { get; }
            public int Coverage => Ridius * 2;
            public int CoverageStart => Location - Ridius < 0 ? 0 : Location - Ridius;
            public int CoverageEnd => Location + Ridius;

            public bool OverlappedWith(GasStation other)
            {
                return CoverageStart <= other.CoverageEnd ||
                    CoverageEnd >= other.CoverageStart;
            }
            public int CompareTo(GasStation other)
            {
                if (other == null) return 1;
                // order by coverage starting location
                return CoverageStart.CompareTo(other.CoverageStart);
            }

            public string GetSymbolString()
            {
                return $"{CoverageStart}-{CoverageEnd}";
            }
        }

        /*
         Before bridges were common, ferries were used to transport cars across rivers. 
         River ferries, unlike their larger cousins, run on a guide line and are powered by the river’s current. 
         Cars drive onto the ferry from one end, the ferry crosses the river, and the cars exit from the other end of the ferry. 
         There is a ferry across the river that can take n cars across the river in t minutes and return in t minutes. 
         m cars arrive at the ferry terminal by a given schedule. What is the earliest time that all the cars can be transported across the river? 
         What is the minimum number of trips that the operator must make to deliver all cars by that time?
         Input: The ﬁrst line of input contains c, the number of test cases. 
         Each test case begins with n, t, m. m lines follow, each giving the arrival time for a car (in minutes since the beginning of the day). 
         The operator can run the ferry whenever he or she wishes, but can take only the cars that have arrived up to that time.
         Output: For each test case, output a single line with two integers: the time, in minutes since the beginning of the day, 
         when the last car is delivered to the other side of the river, and the minimum number of trips made by the ferry to carry the cars within that time. 
         You may assume that 0 < n,t,m < 1440. The arrival times for each test case are in non-decreasing order.
            Sample Input
            2 
            2 10 10 
            0 
            10 
            20 
            30 
            40 
            50 
            60 
            70 
            80 
            90 
            2 10 3 
            10 
            30 
            40
            Sample Output
            100 5 
            50 2
         * */
    }
}
