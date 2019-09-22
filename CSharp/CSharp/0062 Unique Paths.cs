namespace CSharp._0062_Unique_Paths
{
	public class Solution
	{
		/// Memory Search
		/// Time Complexity: O(m * n)
		/// Space Complexity: O(m * n)
		public int UniquePaths(int m, int n)
		{
			int[,] dp = new int[m, n];
			return DFS(m - 1, n - 1, dp);
		}

		private int DFS(int x, int y, int[,] dp)
		{
			if (x == 0 || y == 0)
				return 1;

			if (dp[x, y] != 0)
				return dp[x, y];

			dp[x, y] = DFS(x - 1, y, dp) + DFS(x, y - 1, dp);
			return dp[x, y];
		}
	}

	public class Solution2
	{
		/// Dynamic Programming
		/// Time Complexity: O(m * n)
		/// Space Complexity: O(m * n)
		public int UniquePaths(int m, int n)
		{
			int[,] dp = new int[m, n];
			for (int i = 0; i < m; i++)
				dp[i, 0] = 1;

			for (int i = 0; i < n; i++)
				dp[0, i] = 1;

			for (int i = 1; i < m; i++)
				for (int j = 1; j < n; j++)
					dp[i, j] = dp[i - 1, j] + dp[i, j - 1];

			return dp[m - 1, n - 1];
		}

		/// Dynamic Programming
		/// Time Complexity: O(m * n)
		/// Space Complexity: O(m)
		public int UniquePaths2(int m, int n)
		{
			int[] dp = new int[m];
			for (int i = 0; i < m; i++)
				dp[i] = 1;
			for (int i = 1; i < n; i++)
				for (int j = 1; j < m; j++)
					dp[j] = dp[j - 1] + dp[j];
			return dp[m - 1];
		}
	}
}
