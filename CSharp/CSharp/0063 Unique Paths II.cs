namespace LeetCodeInCS._0063_Unique_Paths_II
{
	public class Solution
	{
		/// Dynamic Programming
		/// Time Complexity: O(m*n)
		/// Space Complexity: O(1)
		public int UniquePathsWithObstacles(int[][] obstacleGrid)
		{
			if (obstacleGrid == null || obstacleGrid.Length == 0 || obstacleGrid[0][0] == 1)
				return 0;

			int m = obstacleGrid.Length;
			int n = obstacleGrid[0].Length;

			int[,] dp = new int[m, n];

			dp[0, 0] = 1;
			for (int i = 1; i < m; i++)
				dp[i, 0] = obstacleGrid[i][0] == 1 ? 0 : dp[i - 1, 0];

			for (int i = 1; i < n; i++)
				dp[0, i] = obstacleGrid[0][i] == 1 ? 0 : dp[0, i - 1];

			for (int i = 1; i < m; i++)
				for (int j = 1; j < n; j++)
					dp[i, j] = obstacleGrid[i][j] == 1 ? 0 : dp[i - 1, j] + dp[i, j - 1];
			return dp[m - 1, n - 1];
		}
	}
}
