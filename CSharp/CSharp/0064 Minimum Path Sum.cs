using System;

namespace LeetCodeInCS._0064_Minimum_Path_Sum
{
	public class Solution
	{
		public int MinPathSum(int[][] grid)
		{
			if (grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length == 0)
				return 0;

			for (int i = 0; i < grid.Length; i++)
				for (int j = 0; j < grid[0].Length; j++)
				{
					if (i == 0 && j == 0)
						continue;
					else if (i == 0)
						grid[i][j] += grid[i][j - 1];
					else if (j == 0)
						grid[i][j] += grid[i - 1][j];
					else
						grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
				}

			return grid[grid.Length - 1][grid[0].Length - 1];
		}
	}
}
