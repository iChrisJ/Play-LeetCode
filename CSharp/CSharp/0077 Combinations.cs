using System.Collections.Generic;

namespace CSharp._0077_Combinations
{
	public class Solution
	{
		public IList<IList<int>> Result { get; private set; }
		public IList<IList<int>> Combine(int n, int k)
		{
			Result = new List<IList<int>>();

			if (n <= 0 || k <= 0 || k > n)
				return Result;

			GenerateCombination(n, k, 1, new List<int>());
			return Result;
		}

		private void GenerateCombination(int n, int k, int start, List<int> list)
		{
			if (k == list.Count)
			{
				Result.Add(new List<int>(list));
				return;
			}

			for (int i = start; i <= n - (k - list.Count) + 1; i++)
			{
				list.Add(start);
				GenerateCombination(n, k, start + 1, list);
				list.RemoveAt(list.Count - 1);
			}
		}
	}
}
