using System.Collections.Generic;

namespace LeetCodeInCS._0217_Contains_Duplicate
{
	public class Solution
	{
		public bool ContainsDuplicate(int[] nums)
		{
			if (nums == null || nums.Length < 2)
				return false;

			HashSet<int> set = new HashSet<int>();
			foreach (int item in nums)
				if (!set.Add(item))
					return true;
			return false;
		}
	}
}
