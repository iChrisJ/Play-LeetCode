using System.Collections.Generic;

namespace LeetCodeInCS._0219_Contains_Duplicate_II
{
	/// <summary>
	/// Set
	/// </summary>
	public class Solution
	{
		public bool ContainsNearbyDuplicate(int[] nums, int k)
		{
			HashSet<int> set = new HashSet<int>();
			for (int i = 0; i < nums.Length; i++)
			{
				if (i > k)
					set.Remove(nums[i - k - 1]);
				if (!set.Add(nums[i]))
					return true;
			}
			return false;
		}
	}

	/// <summary>
	/// Dictionary
	/// </summary>
	public class Solution2
	{
		public bool ContainsNearbyDuplicate(int[] nums, int k)
		{
			if (nums == null || nums.Length < 2 || k <= 0)
				return false;

			Dictionary<int, int> dict = new Dictionary<int, int>();
			for (int i = 0; i < nums.Length; i++)
			{
				if (dict.ContainsKey(nums[i]))
				{
					if (i - dict[nums[i]] <= k)
						return true;
					else
						dict[nums[i]] = i;
				}
				else
					dict.Add(nums[i], i);
			}
			return false;
		}
	}
}
