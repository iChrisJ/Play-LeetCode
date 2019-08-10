using System.Collections.Generic;

namespace CSharp._0052_N_Queens_II
{
	// Almost same as the leetcode 51 and easier than it.
	public class Solution
	{
		private bool[] col, dia1, dia2;

		public int Result { get; set; }

		public int TotalNQueens(int n)
		{
			Result = 0;
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
				Result++;
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
	}
}
