using System.Collections.Generic;

namespace LeetCodeInCS._0078_Subsets
{
	public class Solution
	{
		public IList<IList<int>> Result { get; set; }

		public IList<IList<int>> Subsets(int[] nums)
		{
			Result = new List<IList<int>>();

			if (nums == null)
				return Result;
			FindSubSets(nums, 0, new List<int>());
			return Result;
		}

		public void FindSubSets(int[] nums, int start, IList<int> list)
		{
			Result.Add(new List<int>(list));

			for (int i = start; i < nums.Length; i++)
			{
				list.Add(nums[i]);
				FindSubSets(nums, i + 1, list);
				list.RemoveAt(list.Count - 1);
			}
		}
	}
}
