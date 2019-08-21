using System;

namespace CSharp._0300_Longest_Increasing_Subsequence
{
	public class Solution
	{
		public int LengthOfLIS(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return 0;

			// dp[i]表示在必须以nums[i]这个数结尾的情况下，nums[0..i]中的最大递增子序列的长度
			// dp[i] = max{dp[j] + 1 (0 <= j < i, nums[j] < nums[i])}
			int[] dp = new int[nums.Length];
			dp[0] = 1;
			for (int i = 1; i < nums.Length; i++)
			{
				int max = 0;
				for (int j = 0; j < i; j++)
					max = nums[j] < nums[i] ? Math.Max(max, dp[j]) : max;
				dp[i] = max + 1;
			}

			Array.Sort<int>(dp);
			return dp[dp.Length - 1];
		}
	}
}
