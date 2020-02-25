using System;

namespace LeetCodeInCS._0198_House_Robber
{
	/// <summary>
	/// Memory Search
	/// </summary>
	public class Solution
	{
		private int[] memo;
		public int Rob(int[] nums)
		{
			memo = new int[nums.Length];
			Array.Fill<int>(memo, -1);
			return TryRob(nums, 0);
		}

		private int TryRob(int[] nums, int index)
		{
			if (index >= nums.Length)
				return 0;
			if (memo[index] != -1)
				return memo[index];

			int res = 0;
			for (int i = index; i < nums.Length; i++)
				res = Math.Max(res, nums[i] + TryRob(nums, i + 2));

			memo[index] = res;
			return res;
		}
	}

	/// <summary>
	/// Dynamic Programming
	/// </summary>
	public class Solution2
	{
		public int Rob(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return 0;

			int[] dp = new int[nums.Length];
			dp[0] = nums[0];

			for (int i = 1; i < nums.Length; i++)
				dp[i] = Math.Max(dp[i - 1], nums[i] + (i - 2 >= 0 ? dp[i - 2] : 0));
			return dp[nums.Length - 1];
		}
	}
}
