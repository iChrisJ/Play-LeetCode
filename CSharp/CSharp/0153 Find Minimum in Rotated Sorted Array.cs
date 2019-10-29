using System;

namespace LeetCodeInCS._0153_Find_Minimum_in_Rotated_Sorted_Array
{
	public class Solution
	{
		public int FindMin(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return -1;

			int l = 0, r = nums.Length - 1;
			while (l < r)
			{
				int mid = l + (r - l) / 2;
				if (nums[mid] < nums[l]) // if nums[l] > nums[mid] < nums[r], go to nums[l..mid]
					r = mid;
				else if (nums[mid] > nums[r]) // if nums[l] < nums[mid] > nums[r], go to nums[mid+1..r]
					l = mid + 1;
				else // if nums[l] == nums[mid] or nums[r] == nums[mid], choose min(nums[l], nums[r])
					return Math.Min(nums[l], nums[r]);
			}
			return Math.Min(nums[l], nums[r]);
		}
	}
}
