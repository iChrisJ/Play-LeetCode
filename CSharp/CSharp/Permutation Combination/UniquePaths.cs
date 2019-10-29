namespace LeetCodeInCS.Permutation_Combination
{
	/// <summary>
	/// 在6×9的方格中，以左上角为起点，右下角为终点，每次只能向下走或者向右走，请问一共有多少种不同的走法。
	/// 解法：一共走13步，其中必然有5步向下，剩下的8步向右
	/// </summary>
	class Unique_Paths
	{
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
	}
}
