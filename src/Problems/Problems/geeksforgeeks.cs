using Problems.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public static class Geeksforgeeks
    {
        // http://practice.geeksforgeeks.org/problems/kadanes-algorithm/0
        public static int KadanesAlgorithm(int[] a)
        {
            if (a == null || a.Length == 0)
                throw new InvalidOperationException();

            if (a.Length == 1)
                return a[0];

            int maxEnd = a[0];
            int maxSoFar = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                int x = a[i];
                maxEnd = Math.Max(x, maxEnd + x);
                maxSoFar = Math.Max(maxEnd, maxSoFar);
            }
            return maxSoFar;
        }

        // http://practice.geeksforgeeks.org/problems/parenthesis-checker/0
        public static bool ParenthesisChecker(string s)
        {
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                if (ParenthesisHelper.IsOpenParenthesis(c))
                {
                    stack.Push(c);
                }
                else if (ParenthesisHelper.IsCloseParenthesis(c))
                {
                    if (stack.Count == 0)
                        return false;
                    var t = stack.Pop();
                    if (!ParenthesisHelper.ParenthesisMatch(t, c))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }

        // http://practice.geeksforgeeks.org/problems/next-larger-element/0
        public static int[] NextLargerElement(int[] a)
        {
            if (a == null || a.Length == 0)
                return a;

            var result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                int key = a[i];
                result[i] = -1;

                int j = i + 1;
                for (; j < a.Length; j++)
                {
                    if (a[j] > key)
                    {
                        result[i] = a[j];
                        break;
                    }
                }
            }

            return result;
        }

        private class ParenthesisHelper
        {
            const char p1Open = '{';
            const char p1Close = '}';
            const char p2Open = '(';
            const char p2Close = ')';
            const char p3Open = '[';
            const char p3Close = ']';

            public static bool IsOpenParenthesis(char c)
            {
                return c == p1Open || c == p2Open || c == p3Open;
            }

            public static bool IsCloseParenthesis(char c)
            {
                return c == p1Close || c == p2Close || c == p3Close;
            }

            public static bool ParenthesisMatch(char open, char close)
            {
                return (open == p1Open && close == p1Close) ||
                    (open == p2Open && close == p2Close) ||
                    (open == p3Open && close == p3Close);
            }
        }
    }
}
