using System;

namespace LeetCodeInCS._0279_Perfect_Squares
{
	public class Solution
	{
		/// Recursive
		public int NumSquares(int n)
		{
			if (n <= 0)
				return 0;
			return CalcNumSquares(n);
		}

		private int CalcNumSquares(int n)
		{
			if (n == 1)
				return 1;

			int res = n;
			for (int i = 1; i * i <= n; i++)
				res = Math.Min(res, 1 + CalcNumSquares(n - i * i));
			return res;
		}
	}

	public class Solution2
	{
		/// Momery Search
		private int[] memo;
		public int NumSquares(int n)
		{
			if (n <= 0)
				return 0;
			memo = new int[n + 1];

			return CalcNumSquares(n);
		}

		private int CalcNumSquares(int n)
		{
			if (n == 1)
				return 1;

			if (memo[n] != 0)
				return memo[n];

			int res = n;
			for (int i = 1; i * i <= n; i++)
				res = Math.Min(res, 1 + CalcNumSquares(n - i * i));
			memo[n] = res;
			return res;
		}
	}

	/// Dynamic Programming
	/// Time Complexity: O(n)
	/// Space Complexity: O(n)
	public class Solution3
	{
		public int NumSquares(int n)
		{
			if (n <= 0)
				return 0;
			int[] memo = new int[n + 1];

			for (int i = 0; i <= n; i++)
				memo[i] = i;

			for (int i = 1; i <= n; i++)
				for (int j = 1; j * j <= i; j++)
					memo[i] = Math.Min(memo[i], 1 + memo[i - j * j]);

			return memo[n];
		}
	}
}
