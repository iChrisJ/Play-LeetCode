using System;
using System.Collections.Generic;

namespace CSharp._0040_Combination_Sum_II
{
	public class Solution
	{
		public IList<IList<int>> Result { get; set; }

		public IList<IList<int>> CombinationSum2(int[] candidates, int target)
		{
			Result = new List<IList<int>>();
			if (candidates.Length == 0 || target <= 0)
				return Result;
			Array.Sort<int>(candidates);
			FindCombinations(candidates, 0, target, new List<int>());
			return Result;
		}

		private void FindCombinations(int[] nums, int start, int target, IList<int> list)
		{
			if (target == 0 && list.Count > 0)
			{
				Result.Add(new List<int>(list));
				return;
			}

			for (int i = start; i < nums.Length; i++)
			{
				if (i > start && nums[i] == nums[i - 1])
					continue;
				if (target - nums[i] >= 0)
				{
					list.Add(nums[i]);
					FindCombinations(nums, i + 1, target - nums[i], list);
					list.RemoveAt(list.Count - 1);
				}
			}
		}

		//public static void Main()
		//{
		//	var aa = new Solution().CombinationSum2(new int[] { 5, 3, 2, 4, 2, 5, 2, 4, 3 }, 8);
		//}
	}
}
