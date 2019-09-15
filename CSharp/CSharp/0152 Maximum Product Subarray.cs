using System;

namespace CSharp._0152_Maximum_Product_Subarray
{
	public class Solution
	{
		public int MaxProduct(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return 0;

			int[,] dp = new int[nums.Length, 2];

			dp[0, 0] = nums[0];
			dp[0, 1] = nums[0];
			int res = nums[0];

			for (int i = 1; i < nums.Length; i++)
			{
				dp[i, 0] = Math.Max(dp[i - 1, 0] * nums[i], Math.Max(dp[i - 1, 1] * nums[i], nums[i]));
				dp[i, 1] = Math.Min(dp[i - 1, 0] * nums[i], Math.Min(dp[i - 1, 1] * nums[i], nums[i]));
				res = Math.Max(res, dp[i, 0]);
			}
			return res;
		}
	}

	public class Solution2
	{
		public int MaxProduct(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return 0;

			int[,] dp = new int[2, 2];

			dp[0, 0] = nums[0];
			dp[0, 1] = nums[0];
			int res = nums[0];

			for (int i = 1; i < nums.Length; i++)
			{
				int x = i % 2, y = (i - 1) % 2;
				dp[x, 0] = Math.Max(dp[y, 0] * nums[i], Math.Max(dp[y, 1] * nums[i], nums[i]));
				dp[x, 1] = Math.Min(dp[y, 0] * nums[i], Math.Min(dp[y, 1] * nums[i], nums[i]));
				res = Math.Max(res, dp[x, 0]);
			}
			return res;
		}
	}
}
