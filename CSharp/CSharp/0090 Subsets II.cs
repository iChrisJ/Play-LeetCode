using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0090_Subsets_II
{
	public class Solution
	{
		private IList<IList<int>> res;
		public IList<IList<int>> SubsetsWithDup(int[] nums)
		{
			res = new List<IList<int>>();
			if (nums == null || nums.Length == 0)
				return res;
			Array.Sort<int>(nums);
			FindSubset(nums, 0, new List<int>());
			return res;
		}

		private void FindSubset(int[] nums, int start, IList<int> subset)
		{
			res.Add(new List<int>(subset));
			for (int i = start; i < nums.Length; i++)
			{
				subset.Add(nums[i]);
				FindSubset(nums, i + 1, subset);
				subset.RemoveAt(subset.Count - 1);
				while (i + 1 < nums.Length && nums[i] == nums[i + 1])
					i++;
			}
		}
	}
}
