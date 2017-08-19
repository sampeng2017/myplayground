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

        public static void Exchange<T>(T[] ary, int i, int j)
        {
            T tmp = ary[i];
            ary[i] = ary[j];
            ary[j] = tmp;
        }

    }
}
