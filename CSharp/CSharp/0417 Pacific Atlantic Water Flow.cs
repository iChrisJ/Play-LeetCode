using System.Collections.Generic;

namespace LeetCodeInCS._0417_Pacific_Atlantic_Water_Flow
{
	public class Solution
	{
		private int[,] d = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
		public IList<IList<int>> PacificAtlantic(int[][] matrix)
		{
			IList<IList<int>> res = new List<IList<int>>();
			if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0)
				return res;

			int m = matrix.Length;
			int n = matrix[0].Length;

			bool[,] po = new bool[m, n];
			bool[,] ao = new bool[m, n];
			for (int i = 0; i < m; i++)
			{
				DFS(matrix, i, 0, po);
				DFS(matrix, i, n - 1, ao);
			}

			for (int i = 0; i < n; i++)
			{
				DFS(matrix, 0, i, po);
				DFS(matrix, m - 1, i, ao);
			}

			for (int i = 0; i < m; i++)
				for (int j = 0; j < n; j++)
					if (po[i, j] && ao[i, j])
						res.Add(new List<int> { i, j });

			return res;
		}

		private void DFS(int[][] matrix, int x, int y, bool[,] flowable)
		{
			flowable[x, y] = true;
			int m = matrix.Length;
			int n = matrix[0].Length;
			for (int i = 0; i < 4; i++)
			{
				int newx = x + d[i, 0];
				int newy = y + d[i, 1];

				if (!(newx >= 0 && newx < m && newy >= 0 && newy < n) || matrix[x][y] > matrix[newx][newy] || flowable[newx, newy])
					continue;
				DFS(matrix, newx, newy, flowable);
			}
		}
	}
}
