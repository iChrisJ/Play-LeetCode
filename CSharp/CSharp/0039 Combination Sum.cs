using System.Collections.Generic;

namespace LeetCodeInCS._0039_Combination_Sum
{
	public class Solution
	{
		private IList<IList<int>> res;
		public IList<IList<int>> CombinationSum(int[] candidates, int target)
		{
			res = new List<IList<int>>();
			if (candidates == null || candidates.Length == 0 || target <= 0)
				return res;
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
					FindCombinations(candidates, target - candidates[i], i, c);
					c.RemoveAt(c.Count - 1);
				}
			}
		}
	}
}
