using System;

namespace LeetCodeInCS.Dynamic_Programming
{
	/// <summary>
	/// 给定一个矩阵grid, 从左上角开始每次只能向右或者向下走，最后到达右下角的位置，
	/// 路径上所有的数字加起来就是路劲和，返回所有的路径种最小的路径和。如果给定的grid
	/// 如下，路径1，3，1，0，6，1，0是所有路径种路径和最小的，所以返回12.
	/// 1 3 5 9
	/// 8 1 3 4
	/// 5 0 6 1
	/// 8 8 4 0
	/// </summary>
	class MinimumPathSum_Solution
	{
		public int MinimumPathSum(int[][] grid)
		{
			if (grid == null || grid.Length == 0 || grid[0].Length == 0)
				return 0;

			int[,] dp = new int[grid.Length, grid[0].Length];

			dp[0, 0] = grid[0][0];
			for (int i = 1; i < grid.Length; i++)
				dp[i, 0] = dp[i - 1, 0] + grid[i][0];

			for (int i = 1; i < grid[0].Length; i++)
				dp[0, i] = dp[0, i - 1] + grid[0][i];

			for (int i = 1; i < grid.Length; i++)
				for (int j = 1; j < grid[0].Length; j++)
					dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
			return dp[grid.Length - 1, grid[0].Length - 1];
		}
	}
}
