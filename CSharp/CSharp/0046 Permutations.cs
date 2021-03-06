﻿using System.Collections.Generic;

namespace LeetCodeInCS._0046_Permutations
{
	public class Solution
	{
		private IList<IList<int>> res;

		public IList<IList<int>> Permute(int[] nums)
		{
			res = new List<IList<int>>();
			if (nums == null || nums.Length == 0)
				return res;

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
				}
			}
		}
	}
}
