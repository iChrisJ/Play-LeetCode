using System.Collections.Generic;

namespace LeetCodeInCS._0216_Combination_Sum_III
{
	public class Solution
	{
		private IList<IList<int>> res;

		public IList<IList<int>> CombinationSum3(int k, int n)
		{
			res = new List<IList<int>>();
			if (k <= 0 || k > 9 || n <= 0 || n > 45)
				return res;
			FindCombinations(k, n, 1, new List<int>());
			return res;
		}

		private void FindCombinations(int k, int target, int start, IList<int> c)
		{
			if (c.Count == k)
			{
				if (target == 0)
					res.Add(new List<int>(c));
				return;
			}

			for (int i = start; i <= 9 - (k - c.Count) + 1; i++)
			{
				if (target >= i)
				{
					c.Add(i);
					FindCombinations(k, target - i, i + 1, c);
					c.RemoveAt(c.Count - 1);
				}
			}
		}
	}
}
