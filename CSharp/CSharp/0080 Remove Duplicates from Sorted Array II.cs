using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeInCS._0080_Remove_Duplicates_from_Sorted_Array_II
{
	public class Solution
	{
		public int RemoveDuplicates(int[] nums)
		{
			if (nums.Length < 3)
				return nums.Length;

			int j = 0, i = 1;
			int dupCount = 1;
			while (i < nums.Length)
			{
				if (nums[i] == nums[j])
				{
					if (dupCount == 1)
					{
						dupCount++;
						j++;
						nums[j] = nums[i];
					}
				}
				else
				{
					dupCount = 1;
					j++;
					nums[j] = nums[i];
				}
				i++;
			}
			return j + 1;
		}
	}
}
