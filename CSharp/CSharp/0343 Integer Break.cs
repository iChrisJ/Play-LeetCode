using System;

namespace LeetCodeInCS._0343_Integer_Break
{
	public class Solution
	{
		public int IntegerBreak(int n)
		{
			if (n == 1)
				return 1;

			return BreakInteger(n);
		}

		private int BreakInteger(int n)
		{
			if (n == 1)
				return 1;

			int res = 0;
			for (int i = 1; i < n; i++)
			{
				res = Math.Max(res, i * (n - i));
				res = Math.Max(res, i * BreakInteger(n - i));
			}
			return res;
		}
	}

	public class Solution2
	{
		private int[] memo;
		public int IntegerBreak(int n)
		{
			if (n == 1)
				return 1;
			memo = new int[n + 1];
			return BreakInteger(n);
		}

		private int BreakInteger(int n)
		{
			if (n == 1)
				memo[1] = 1;

			if (memo[n] != 0)
				return memo[n];

			int res = 0;
			for (int i = 1; i < n; i++)
			{
				res = Math.Max(res, i * (n - i));
				res = Math.Max(res, i * BreakInteger(n - i));
			}
			memo[n] = res;
			return memo[n];
		}
	}

	// Dynamic Programming
	public class Solution3
	{
		public int IntegerBreak(int n)
		{
			if (n <= 0)
				return 0;

			int[] dp = new int[n + 1];
			dp[1] = 1;

			for (int i = 2; i <= n; i++)
				for (int j = 1; j + j <= i; j++)
					dp[i] = Math.Max(dp[i], Math.Max(j * (i - j), j * dp[i - j]));
			return dp[n];
		}
	}
}
