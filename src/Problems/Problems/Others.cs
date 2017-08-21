using System;
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
    }
}
