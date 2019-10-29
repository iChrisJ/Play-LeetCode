using System.Collections.Generic;

namespace LeetCodeInCS._0219_Contains_Duplicate_II
{
	public class Solution
	{
		public bool ContainsNearbyDuplicate(int[] nums, int k)
		{
			HashSet<int> record = new HashSet<int>();
			int i = 0;
			for (; i < k + 1 && i < nums.Length; i++)
			{
				if (record.Contains(nums[i]))
					return true;
				else
					record.Add(nums[i]);
			}

			while (i < nums.Length)
			{
				record.Remove(nums[i - k - 1]);
				if (record.Contains(nums[i]))
					return true;
				record.Add(nums[i]);
				i++;
			}
			return false;
		}
	}

}
