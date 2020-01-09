using System;
using System.Collections.Generic;

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
			int[] dp = new int[n + 1];

			for (int i = 1; i <= n; i++)
			{
				dp[i] = i;
				for (int j = 1; j * j <= i; j++)
					dp[i] = Math.Min(dp[i], 1 + dp[i - j * j]);
			}

			return dp[n];
		}
	}

	/// BFS
	/// Time Complexity: O(nlgn)
	/// Space Complexity: O(n)
	public class Solution4
	{
		public int NumSquares(int n)
		{
			Queue<int> queue = new Queue<int>();
			HashSet<int> set = new HashSet<int>();
			queue.Enqueue(n);
			set.Add(n);

			int ans = 0;

			while (queue.Count != 0)
			{
				ans++;
				int len = queue.Count;
				while ((len--) > 0)
				{
					int frnt = queue.Dequeue();
					for (int i = 1; i * i <= n; i++)
					{
						int res = frnt - i * i;
						if (res == 0)
							return ans;

						if (set.Add(res))
							queue.Enqueue(res);
					}
				}
			}
			return n;
		}
	}
}
