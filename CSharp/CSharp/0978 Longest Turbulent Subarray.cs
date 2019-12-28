using System;

namespace LeetCodeInCS._0978_Longest_Turbulent_Subarray
{
	public class Solution
	{
		public int MaxTurbulenceSize(int[] A)
		{
			if (A.Length <= 1)
				return A.Length;

			int[] dp = new int[A.Length];
			dp[0] = 1;
			dp[1] = A[0] == A[1] ? 1 : 2;
			int max = dp[1];

			for (int i = 2; i < A.Length; i++)
			{
				if ((A[i] > A[i - 1] && A[i - 1] < A[i - 2]) || (A[i] < A[i - 1] && A[i - 1] > A[i - 2]))
					dp[i] = dp[i - 1] + 1;
				else if (A[i] == A[i - 1])
					dp[i] = 1;
				else
					dp[i] = 2;

				max = Math.Max(max, dp[i]);
			}
			return max;
		}
	}
}
