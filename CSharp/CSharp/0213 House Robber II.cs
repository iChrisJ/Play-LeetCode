using System;

namespace LeetCodeInCS._0213_House_Robber_II
{
	public class Solution
	{
		public int Rob(int[] nums)
		{
			if (nums.Length == 0)
				return 0;
			if (nums.Length == 1)
				return nums[0];
			if (nums.Length == 2)
				return Math.Max(nums[0], nums[1]);
			return Math.Max(Rob(nums, 0, nums.Length - 2), Rob(nums, 1, nums.Length - 1));
		}

		public int Rob(int[] nums, int start, int end)
		{
			if (end < start)
				return 0;

			int[] dp = new int[end - start + 1];
			dp[0] = nums[start];

			for (int i = 1; i <= end - start; i++)
				dp[i] = Math.Max(dp[i - 1], nums[start + i] + (i >= 2 ? dp[i - 2] : 0));
			return dp[end - start];
		}
	}
}
