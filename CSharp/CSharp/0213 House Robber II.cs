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
			if (end == start)
				return nums[start];
			int[] memo = new int[end - start + 1];
			memo[0] = nums[start];

			for (int i = start + 1; i <= end; i++)
				memo[i - start] = Math.Max(memo[i - start - 1], nums[i] + (i - 2 >= start ? memo[i - start - 2] : 0));
			return memo[end - start];
		}

		//public static void Main()
		//{
		//	var res = new Solution().Rob(new int[] { 2, 7, 9, 3, 1 });
		//}
	}
}
