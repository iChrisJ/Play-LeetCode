using System.Collections.Generic;

namespace LeetCodeInCS._0077_Combinations
{
	public class Solution
	{
		private IList<IList<int>> res;

		public IList<IList<int>> Combine(int n, int k)
		{
			res = new List<IList<int>>();
			if (n <= 0 || k <= 0 || k > n)
				return res;
			Combine(n, k, 1, new List<int>());
			return res;
		}

		private void Combine(int n, int k, int start, IList<int> c)
		{
			if (c.Count == k)
			{
				res.Add(new List<int>(c));
				return;
			}

			for (int i = start; i <= n - (k - c.Count) + 1; i++)
			{
				c.Add(i);
				Combine(n, k, i + 1, c);
				c.RemoveAt(c.Count - 1);
			}
		}
	}
}
