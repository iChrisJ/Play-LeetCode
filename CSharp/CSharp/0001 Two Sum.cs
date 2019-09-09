using System.Collections.Generic;

namespace CSharp._0001_Two_Sum
{
	public class Solution
	{
		public int[] TwoSum(int[] nums, int target)
		{
			Dictionary<int, int> dict = new Dictionary<int, int>();

			for (int i = 0; i < nums.Length; i++)
			{
				if (dict.ContainsKey(target - nums[i]))
					return new int[] { (int)dict[target - nums[i]], i };
				else
				{
					if (dict.ContainsKey(nums[i]))
						dict[nums[i]] = i;
					else
						dict.Add(nums[i], i);
				}
			}

			return null;
		}
	}
}
