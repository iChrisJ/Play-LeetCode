using System.Collections.Generic;
using System.Text;

namespace CSharp._0051_N_Queens
{
	public class Solution
	{
		private bool[] col, dia1, dia2;

		public IList<IList<string>> Result { get; set; }

		public IList<IList<string>> SolveNQueens(int n)
		{
			Result = new List<IList<string>>();
			col = new bool[n];
			dia1 = new bool[2 * n - 1];
			dia2 = new bool[2 * n - 1];
			PutQueen(n, 0, new List<int>());
			return Result;
		}

		private void PutQueen(int n, int index, IList<int> row)
		{
			if (index == n)
			{
				Result.Add(GenerateBoard(n, row));
				return;
			}

			for (int i = 0; i < n; i++)
			{
				if (!col[i] && !dia1[index + i] && !dia2[index - i + n - 1])
				{
					row.Add(i);
					col[i] = true;
					dia1[index + i] = true;
					dia2[index - i + n - 1] = true;
					PutQueen(n, index + 1, row);
					col[i] = false;
					dia1[index + i] = false;
					dia2[index - i + n - 1] = false;
					row.RemoveAt(row.Count - 1);
				}
			}
		}

		private IList<string> GenerateBoard(int n, IList<int> row)
		{
			IList<string> board = new List<string>(n);
			for (int i = 0; i < n; i++)
			{
				StringBuilder sb = new StringBuilder(n);
				for (int j = 0; j < n; j++)
					sb.Append(row[i] == j ? 'Q' : '.');
				board.Add(sb.ToString());
			}
			return board;
		}
	}
}
