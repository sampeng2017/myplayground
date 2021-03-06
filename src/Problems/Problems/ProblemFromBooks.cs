﻿using Problems.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public static class ProblemFromBooks
    {
        // Suppose we have an array a1, a2, ..., an, b1, b2, ..., bn. 
        //Implement an algorithm to change this array to a1, b1, a2, b2, ..., an, bn.
        public static void AlternateArrayItems(int[] a)
        {
            if (a == null || a.Length == 0 || a.Length % 2 != 0)
                throw new InvalidOperationException();
            if (a.Length == 2)
                return;

            if ((a.Length / 2) % 2 != 0)
            {
                // move a[n -1] to a[2n - 2]:
                // 1) a1, a2, a3, b1, b2, b3
                // 2) a1, a2, b1, b2, a3, b3
                // 3) then call AlternateArrayItems(a, 0, a.Length - 3)
                int i = a.Length / 2 - 1;
                while (i < a.Length - 1)
                {
                    Helpers.Exchange(a, i, ++i);
                }
                AlternateArrayItems(a, 0, a.Length - 3);
            }
            else
            {
                AlternateArrayItems(a, 0, a.Length - 1);
            }
        }

        // a1, a2, a3, a4, b1, b2, b3, b4
        // a1, a2, b1, b2, a3, a4, b3, b4
        // then recursive call two sub sets
        private static void AlternateArrayItems(int[] a, int p, int q)
        {
            if (q - p <= 1)
                return;

            int len = q - p + 1;
            if (len % 2 != 0)
                throw new InvalidOperationException();

            int d = len / 4;
            int l = p + d;
            int h = q - d;
            while (l + d <= h)
            {
                Helpers.Exchange(a, l, l + d);
                l++;
            }
            AlternateArrayItems(a, p, p + len / 2 - 1);
            AlternateArrayItems(a, p + len / 2, q);
        }

        public static void ALternateArrayItems2(string[] a)
        {
            if (a == null || a.Length % 2 != 0)
                throw new ArgumentException();

            var a1 = new string[a.Length / 2];
            var a2 = new string[a.Length / 2];
            Array.Copy(a, 0, a1, 0, a.Length / 2);
            Array.Copy(a, a.Length / 2, a2, 0, a.Length / 2);

            for (int i = 0; i < a1.Length; i++)
            {
                a[2 * i] = a1[i];
                a[2 * i + 1] = a2[i];
            }
        }
        public static IList<IList<int>> GenerateSubsets(IList<int> s)
        {
            Helpers.Ensure(s);

            var result = new List<IList<int>>();
            if (s.Count == 0)
            {
                return result;
            }
            result.Add(new List<int> { s[0] });

            if (s.Count > 1)
            {
                var tmpList = new List<int>(s);
                tmpList.RemoveAt(0);

                var subResults = GenerateSubsets(tmpList);
                result.AddRange(subResults);
                foreach (var r in subResults)
                {
                    var newR = new List<int>();
                    newR.Add(s[0]);
                    newR.AddRange(r);
                    result.Add(newR);
                }
            }

            return result;
        }

        // Imagine what happens when you subtract 1 from a string of bits.You read from left to right,
        // turning each 0 to a 1 until you hit a 1, at which point that bit is flipped:
        // 1000100100 -> (subtract 1) -> 1000100011
        // Thus, every bit, up through the first 1, is flipped.If there’s exactly one 1 in the number, then
        // every bit(other than the leading zeros) will be flipped.Thus, n & (n-1) == 0 if there’s exactly
        // one 1. If there’s exactly one 1, then it must be a power of two.
        public static bool IsNumberPowerOfTwo(int n)
        {
            return (n & (n - 1)) == 0;
        }
    }
}
