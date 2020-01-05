using System;

namespace LeetCodeInCS._0016_3Sum_Closest
{
	public class Solution
	{
		public int ThreeSumClosest(int[] nums, int target)
		{
			if (nums == null || nums.Length < 3)
				throw new ArgumentException("Invalid parameters.");

			Array.Sort(nums);
			int res = nums[0] + nums[1] + nums[nums.Length - 1];

			for (int i = 0; i < nums.Length - 2; i++)
			{
				int l = i + 1, r = nums.Length - 1;
				while (l < r)
				{
					int sum = nums[i] + nums[l] + nums[r];
					if (Math.Abs(sum - target) < Math.Abs(res - target))
						res = sum;

					if (sum < target)
						l++;
					else
						r--;
				}
			}
			return res;
		}
	}
}
