using System;

namespace LeetCodeInCS._1277_Count_Square_Submatrices_with_All_Ones
{
	/// <summary>
	/// Without DP
	/// </summary>
	public class Solution
	{
		private int res = 0;
		public int CountSquares(int[][] matrix)
		{
			if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0)
				return 0;

			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[0].Length; j++)
				{
					if (matrix[i][j] == 1)
					{
						res++;
						FindExtraSquares(i, j, matrix);
					}
				}
			}
			return res;
		}

		private void FindExtraSquares(int x, int y, int[][] matrix)
		{
			int m = matrix.Length;
			int n = matrix[0].Length;
			int x1 = x;
			int y1 = y;

			while (x1 < m && y1 < n)
			{
				x1++;
				y1++;

				if (x1 < m && y1 < n)
				{
					for (int i = x; i <= x1; i++)
						if (matrix[i][y1] != 1)
							return;

					for (int j = y; j <= y1; j++)
						if (matrix[x1][j] != 1)
							return;
					res++;
				}
			}
		}
	}

	public class Solution2
	{
		public int CountSquares(int[][] matrix)
		{
			if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0)
				return 0;

			int[,] dp = new int[matrix.Length, matrix[0].Length];
			int res = 0;

			for (int i = 0; i < matrix.Length; i++)
			{
				dp[i, 0] = matrix[i][0];
				res += dp[i, 0];
			}

			for (int i = 1; i < matrix[0].Length; i++)
			{
				dp[0, i] = matrix[0][i];
				res += dp[0, i];
			}

			for (int i = 1; i < matrix.Length; i++)
			{
				for (int j = 1; j < matrix[0].Length; j++)
				{
					if (matrix[i][j] == 1)
					{
						dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
						res += dp[i, j];
					}
				}
			}
			return res;
		}
	}
}
