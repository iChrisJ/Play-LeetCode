using System;

namespace CSharp._0209_Minimum_Size_Subarray_Sum
{
	public class Solution
	{
		public int MinSubArrayLen(int s, int[] nums)
		{
			int i = 0, j = -1;
			int sum = 0;
			int res = nums.Length + 1;
			while (i < nums.Length)
			{
				if (j + 1 < nums.Length && sum < s)
				{
					j++;
					sum += nums[j];
				}
				else
				{
					sum -= nums[j];
					i++;
				}

				if (sum >= s)
					res = Math.Min(res, j - i + 1);
			}
			return res == nums.Length + 1 ? 0 : res;
		}
	}
}
