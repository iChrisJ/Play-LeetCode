using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0220_Contains_Duplicate_III
{
	public class Solution
	{
		/// LeetCode: Time Limit Exceeded
		public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
		{
			if (nums == null || nums.Length <= 1 || k <= 0 || t < 0)
				return false;

			for (int i = 1; i < nums.Length; i++)
			{
				for (int j = i - k < 0 ? 0 : i - k; j < i; j++)
				{
					if (Math.Abs((long)nums[j] - (long)nums[i]) < t)
						return true;
				}
			}
			return false;
		}
	}

	public class Solution2
	{
		public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
		{
			if (nums == null || nums.Length <= 1 || k <= 0 || t < 0)
				return false;

			SortedSet<long> set = new SortedSet<long>();
			for (int i = 0; i < nums.Length; i++)
			{
				if (i > k)
					set.Remove(nums[i - k - 1]);

				if (set.GetViewBetween((long)nums[i] - t, (long)nums[i] + t).Count > 0)
					return true;
				set.Add(nums[i]);
			}
			return false;
		}
	}
}
