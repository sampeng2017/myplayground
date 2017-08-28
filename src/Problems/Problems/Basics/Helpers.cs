using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Basics
{
    public static class Helpers
    {
        public static int RandomPartition(int[] ary, int p, int r)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            int i = rand.Next(p, r);
            Exchange(ary, r, i);
            return Partition(ary, p, r);
        }
        public static int Partition(int[] ary, int p, int r)
        {
            int x = ary[r];
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (ary[j] < x)
                {
                    i++;
                    Exchange(ary, i, j);
                }
            }
            Exchange(ary, i + 1, r);
            return i + 1;
        }

        public static int Partition2(int[] a, int lo, int hi)
        {
            // Partition into a[lo..i-1], a[i], a[i+1..hi].    
            int i = lo, j = hi + 1;

            // left and right scan indices   
            int v = a[lo];
            while (true)
            {
                // Scan right, scan left, check for scan complete, and exchange.      
                while (a[++i] < v)
                    if (i == hi) break;
                while (v < a[--j])
                    if (j == lo) break;
                if (i >= j) break;
                Exchange(a, i, j);
            }
            Exchange(a, lo, j);
            return j;
        }
        public static void Exchange<T>(T[] ary, int i, int j)
        {
            T tmp = ary[i];
            ary[i] = ary[j];
            ary[j] = tmp;
        }

        public static bool Less<T>(IList<T> ary, int i, int j) where T : IComparable
        {
            return ary[i].CompareTo(ary[j]) < 0;
        }

        public static bool More<T>(IList<T> ary, int i, int j) where T : IComparable
        {
            return ary[i].CompareTo(ary[j]) > 0;
        }

        public static void Shuffle(int[] ary)
        {
            if (ary == null || ary.Length <= 1)
                return;
            var rand = new Random(DateTime.Now.Millisecond);
            for (int i = 1; i < ary.Length; i++)
            {
                int tmp = rand.Next(i, ary.Length - 1);
                Exchange(ary, i - 1, tmp);
            }
        }
    }
}
