using System;

namespace CSharp._0070_Climbing_Stairs
{
	public class Solution
	{
		private int[] memo;
		public int ClimbStairs(int n)
		{
			memo = new int[n + 1];
			Array.Fill<int>(memo, -1);
			return CalcWays(n);
		}

		private int CalcWays(int n)
		{
			if (n == 0 || n == 1)
				return 1;
			if (memo[n] == -1)
				memo[n] = CalcWays(n - 1) + CalcWays(n - 2);
			return memo[n];
		}

		// Recursive
		private int CalcWays2(int n)
		{
			if (n == 0 || n == 1)
				return 1;
			return CalcWays2(n - 1) + CalcWays2(n - 2);
		}
	}

	public class Solution2
	{
		// Dynamic programming
		public int ClimbStairs(int n)
		{
			int[] memo = new int[n + 1];
			memo[0] = 1;
			memo[1] = 1;
			for (int i = 2; i <= n; i++)
				memo[i] = memo[i - 1] + memo[i - 2];
			return memo[n];
		}

		public int ClimbStairs2(int n)
		{
			if (n == 1 || n == 2)
				return n;

			int[] memo = new int[3];
			memo[1] = 1;
			memo[2] = 2;

			for (int i = 3; i <= n; i++)
				memo[i % 3] = memo[(i - 1) % 3] + memo[(i - 2) % 3];
			return memo[n % 3];
		}
	}
}
