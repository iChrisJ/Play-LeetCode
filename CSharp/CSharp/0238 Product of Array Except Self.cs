using System;

namespace LeetCodeInCS._0238_Product_of_Array_Except_Self
{
	public class Solution
	{
		public int[] ProductExceptSelf(int[] nums)
		{
			int total = 1;
			int zeroCount = 0;

			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] == 0)
					zeroCount++;
				else
					total *= nums[i];
			}

			if (zeroCount >= 2)
				Array.Fill<int>(nums, 0);
			else if (zeroCount == 1)
			{
				for (int i = 0; i < nums.Length; i++)
					nums[i] = nums[i] == 0 ? total : 0;
			}
			else // zeroCount == 0
			{
				for (int i = 0; i < nums.Length; i++)
					nums[i] = total / nums[i];
			}
			return nums;
		}
	}

	public class Solution2
	{
		public int[] ProductExceptSelf(int[] nums)
		{
			int[] res = new int[nums.Length];

			if (nums == null || nums.Length == 0)
				return res;

			int m = 1;
			for (int i = 0; i < nums.Length; i++)
			{
				res[i] = m;
				m = m * nums[i];
			}

			m = 1;
			for (int i = nums.Length - 1; i >= 0; i--)
			{
				res[i] *= m;
				m = m * nums[i];
			}
			return res;
		}
	}
}
