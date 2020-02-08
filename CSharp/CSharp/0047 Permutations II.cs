using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0047_Permutations_II
{
	public class Solution
	{
		private IList<IList<int>> res;

		public IList<IList<int>> PermuteUnique(int[] nums)
		{
			res = new List<IList<int>>();
			if (nums == null || nums.Length == 0)
				return res;
			Array.Sort<int>(nums);
			bool[] used = new bool[nums.Length];
			Permute(nums, new List<int>(), used);
			return res;
		}

		private void Permute(int[] nums, IList<int> p, bool[] used)
		{
			if (p.Count == nums.Length)
			{
				res.Add(new List<int>(p));
				return;
			}

			for (int i = 0; i < nums.Length; i++)
			{
				if (!used[i])
				{
					used[i] = true;
					p.Add(nums[i]);
					Permute(nums, p, used);
					used[i] = false;
					p.RemoveAt(p.Count - 1);
					// Move index to the last position of the dup num.
					while (i + 1 < nums.Length && nums[i] == nums[i + 1])
						i++;
				}
			}
		}
	}
}
