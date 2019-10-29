using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeInCS.Binary_Search
{
	/// <summary>
	/// 给定一个有序数组arr, 其中不含有重复元素, 请找到满足arr[i]==i条件的最左的位置. 如果所有位置上的数都不满足条件, 返回-1.
	/// </summary>
	class FindFirstSpecifiedElement_Solution
	{
		public int FindFirstSpecifiedElement(int[] nums)
		{
			if (nums == null || nums.Length == 0 || nums[0] > nums.Length - 1 || nums[nums.Length - 1] < 0)
				return -1;
			int l = 0, r = nums.Length - 1;
			int res = -1;
			while (l <= r)
			{
				int mid = l + (r - l) / 2;
				if (nums[mid] == mid)
				{
					res = mid;
					r = mid - 1;
				}
				else if (nums[mid] > mid)
					r = mid - 1;
				else
					l = mid + 1;
			}
			return res;
		}
	}
}
