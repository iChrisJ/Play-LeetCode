using System.Collections.Generic;

namespace CSharp._0046_Permutations
{
	public class Solution
	{

		public IList<IList<int>> Result { get; private set; }
		public bool[] Used { get; private set; }

		public IList<IList<int>> Permute(int[] nums)
		{
			Result = new List<IList<int>>();

			if (nums.Length == 0)
				return Result;

			Used = new bool[nums.Length];
			GeneratePermutation(nums, 0, new List<int>());
			return Result;
		}

		private void GeneratePermutation(int[] nums, int index, IList<int> p)
		{
			if (index == nums.Length)
			{
				Result.Add(new List<int>(p));
				return;
			}

			for (int i = 0; i < nums.Length; i++)
			{
				if (!Used[i])
				{
					p.Add(nums[i]);
					Used[i] = true;
					GeneratePermutation(nums, index + 1, p);
					p.RemoveAt(index);
					Used[i] = false;
				}
			}
		}

		public static void Main(string[] args)
		{
			int[] aa = { 1, 2, 3 };
			var aaa = new Solution().Permute(aa);
		}
	}
}
