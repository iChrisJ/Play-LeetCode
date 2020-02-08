using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0040_Combination_Sum_II
{
	public class Solution
	{
		private IList<IList<int>> res;
		public IList<IList<int>> CombinationSum2(int[] candidates, int target)
		{
			res = new List<IList<int>>();
			if (candidates == null || candidates.Length == 0 || target <= 0)
				return res;
			Array.Sort<int>(candidates);
			FindCombinations(candidates, target, 0, new List<int>());
			return res;
		}

		private void FindCombinations(int[] candidates, int target, int start, IList<int> c)
		{
			if (target == 0)
			{
				res.Add(new List<int>(c));
				return;
			}

			for (int i = start; i < candidates.Length; i++)
			{
				if (target >= candidates[i])
				{
					c.Add(candidates[i]);
					FindCombinations(candidates, target - candidates[i], i + 1, c);
					c.RemoveAt(c.Count - 1);
					while (i + 1 < candidates.Length && candidates[i] == candidates[i + 1])
						i++;
				}
			}
		}
	}
}
