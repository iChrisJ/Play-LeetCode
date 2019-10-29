using System.Collections.Generic;

namespace LeetCodeInCS._0039_Combination_Sum
{
	public class Solution
	{
		public IList<IList<int>> Result { get; set; }

		public IList<IList<int>> CombinationSum(int[] candidates, int target)
		{
			Result = new List<IList<int>>();
			if (candidates.Length == 0 || target <= 0)
				return Result;
			FindCombinations(candidates, 0, target, new List<int>());
			return Result;
		}

		private void FindCombinations(int[] nums, int start, int target, IList<int> list)
		{
			if (target == 0 && list.Count > 0)
				Result.Add(new List<int>(list));

			for (int i = start; i < nums.Length; i++)
			{
				if (target - nums[i] >= 0)
				{
					list.Add(nums[i]);
					FindCombinations(nums, i, target - nums[i], list);
					list.RemoveAt(list.Count - 1);
				}
			}
		}

		//public static void Main()
		//{
		//	var aa = new Solution().CombinationSum(new int[] { 2, 3, 5 }, 8);
		//}
	}
}
