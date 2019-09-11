using System;
using System.Collections.Generic;

namespace CSharp._0169_Majority_Element
{
	public class Solution
	{
		// 元素对撞
		public int MajorityElement(int[] nums)
		{
			int candidate = nums[0];
			int count = 1;
			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] == candidate)
					count++;
				else if (count > 0)
					count--;
				else
				{
					candidate = nums[i];
					count = 1;
				}
			}
			return candidate;
		}
	}

	public class Solution2
	{
		// Sort the list, return the mid element
		public int MajorityElement(int[] nums)
		{
			Array.Sort<int>(nums);
			return nums[nums.Length / 2];
		}
	}

	public class Solution3
	{
		// Use Map to count.
		public int MajorityElement(int[] nums)
		{
			Dictionary<int, int> map = new Dictionary<int, int>();
			for (int i = 0; i < nums.Length; i++)
			{
				if (map.ContainsKey(nums[i]))
					map[nums[i]]++;
				else
					map.Add(nums[i], 1);
				if (map[nums[i]] > nums.Length / 2)
					return nums[i];
			}
			return -1;
		}
	}
}
