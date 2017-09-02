using Problems.Basics;
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
            AlternateArrayItems(a, 0, a.Length - 1);
        }

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
    }
}
