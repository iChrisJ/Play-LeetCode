using System.Collections.Generic;

namespace CSharp._0216_Combination_Sum_III
{
	public class Solution
	{
		public IList<IList<int>> Result { get; set; }

		public IList<IList<int>> CombinationSum3(int k, int n)
		{
			Result = new List<IList<int>>();
			if (k <= 0 || n <= 0)
				return Result;
			FindCombinations(k, 1, n, new List<int>());
			return Result;
		}

		private void FindCombinations(int k, int start, int target, IList<int> list)
		{
			if (target == 0 && k == 0)
			{
				Result.Add(new List<int>(list));
				return;
			}

			for (int i = start; i <= 9; i++)
			{
				if (k > 0 && target >= i)
				{
					list.Add(i);
					FindCombinations(k - 1, i + 1, target - i, list);
					list.RemoveAt(list.Count - 1);
				}
			}
		}

		//public static void Main()
		//{
		//	var aa = new Solution().CombinationSum3(3, 9);
		//}
	}
}
