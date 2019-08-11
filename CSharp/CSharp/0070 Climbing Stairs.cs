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

		// Dynamic programming
		public int ClimbStairs2(int n)
		{
			memo = new int[n + 1];
			memo[0] = 1;
			memo[1] = 1;
			for (int i = 2; i <= n; i++)
				memo[i] = memo[i - 1] + memo[i - 2];
			return memo[n];
		}
	}
}
