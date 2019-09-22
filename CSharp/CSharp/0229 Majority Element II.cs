using System.Collections.Generic;

namespace CSharp._0229_Majority_Element_II
{
	public class Solution
	{
		public IList<int> MajorityElement(int[] nums)
		{
			IList<int> res = new List<int>();
			if (nums == null || nums.Length == 0)
				return res;

			if (nums.Length == 1)
			{
				res.Add(nums[0]);
				return res;
			}

			int first = nums[0], second = nums[0];
			int firstCount = 1, secondCount = 1;

			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] == first)
					firstCount++;
				else if (nums[i] == second)
					secondCount++;
				else if (firstCount == 0)
				{
					first = nums[i];
					firstCount = 1;
				}
				else if (secondCount == 0)
				{
					second = nums[i];
					secondCount = 1;
				}
				else
				{
					firstCount--;
					secondCount--;
				}
			}

			firstCount = secondCount = 0;

			foreach (int num in nums)
			{
				if (num == first)
					firstCount += 1;
				else if (num == second)
					secondCount += 1;
			}

			if (firstCount > nums.Length / 3)
				res.Add(first);
			if (secondCount > nums.Length / 3)
				res.Add(second);

			return res;
		}
	}
}