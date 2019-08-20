using System;

namespace CSharp._0198_House_Robber
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
			{
				res = Math.Max(res, nums[i] + TryRob(nums, i + 2));
			}
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
			if (nums.Length == 0)
				return 0;
			int[] memo = new int[nums.Length];
			Array.Fill<int>(memo, -1);

			memo[nums.Length - 1] = nums[nums.Length - 1];
			for (int i = nums.Length - 2; i >= 0; i--)
				for (int j = i; j < nums.Length; j++)
					memo[i] = Math.Max(memo[i], nums[j] + (j + 2 < nums.Length ? memo[j + 2] : 0));
			return memo[0];
		}

		public int Rob2(int[] nums)
		{
			if (nums.Length == 0)
				return 0;
			int[] memo = new int[nums.Length];
			Array.Fill<int>(memo, -1);

			memo[0] = nums[0];
			for (int i = 1; i < nums.Length; i++)
				memo[i] = Math.Max(memo[i - 1], nums[i] + (i - 2 >= 0 ? memo[i - 2] : 0));
			return memo[nums.Length - 1];
		}
	}
}
