using System.Collections.Generic;
using System.Text;

namespace LeetCodeInCS._0051_N_Queens
{
	public class Solution
	{
		private bool[] col, dial, back_dial;
		private IList<IList<string>> res;

		public IList<IList<string>> SolveNQueens(int n)
		{
			res = new List<IList<string>>();
			if (n <= 0)
				return res;

			col = new bool[n];
			dial = new bool[2 * n - 1];
			back_dial = new bool[2 * n - 1];
			PutQueen(n, 0, new List<int>());
			return res;
		}

		/// <summary>
		/// Backtracking to find available postion for queens.
		/// </summary>
		/// <param name="n">The number of queens.</param>
		/// <param name="x">The line to put queen.</param>
		/// <param name="row">The column of queen in each row.</param>
		private void PutQueen(int n, int x, IList<int> row)
		{
			if (x == n)
			{
				res.Add(GenerateBoard(n, row));
				return;
			}

			for (int y = 0; y < n; y++)
			{
				if (!col[y] && !dial[x + y] && !back_dial[x - y + n - 1])
				{
					row.Add(y);
					col[y] = true;
					dial[x + y] = true;
					back_dial[x - y + n - 1] = true;

					PutQueen(n, x + 1, row);

					back_dial[x - y + n - 1] = false;
					dial[x + y] = false;
					col[y] = false;
					row.RemoveAt(row.Count - 1);
				}
			}
		}

		private IList<string> GenerateBoard(int n, IList<int> row)
		{
			IList<string> board = new List<string>(n);
			for (int i = 0; i < n; i++)
			{
				StringBuilder line = new StringBuilder(n);
				for (int j = 0; j < n; j++)
					line.Append(row[i] == j ? 'Q' : '.');
				board.Add(line.ToString());
			}
			return board;
		}
	}
}
