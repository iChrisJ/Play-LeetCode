using System;
using System.Collections.Generic;

namespace CSharp._0090_Subsets_II
{
	public class Solution
	{
		public IList<IList<int>> Result { get; set; }
		public IList<IList<int>> SubsetsWithDup(int[] nums)
		{
			Result = new List<IList<int>>();

			if (nums == null)
				return Result;

			Array.Sort<int>(nums);
			FindSubSets(nums, 0, new List<int>());
			return Result;
		}

		public void FindSubSets(int[] nums, int start, IList<int> list)
		{
			Result.Add(new List<int>(list));

			for (int i = start; i < nums.Length; i++)
			{
				if (i > start && nums[i] == nums[i - 1])
					continue;
				list.Add(nums[i]);
				FindSubSets(nums, i + 1, list);
				list.RemoveAt(list.Count - 1);
			}
		}
	}
}
