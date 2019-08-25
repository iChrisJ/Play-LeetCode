namespace CSharp.Binary_Search
{
	/// <summary>
	/// 给定一个有序循环数组arr, 返回arr中的最小值. 
	/// 有序循环数组是指, 有序数组左边任意长度的部分放到右边去, 右边的部分拿到左边来.
	/// 比如数组[1, 2, 3, 3, 4], 是有序循环数组, [4, 1, 2, 3, 3]也是。
	/// </summary>
	class FindMinimumInRotatedSortedArray_Solution
	{
		public int FindMinimumInRotatedSortedArray(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return -1;
			if (nums[0] < nums[nums.Length - 1])
				return nums[0];

			int l = 0, r = nums.Length - 1;
			int res = nums[0];
			while (l <= r)
			{
				int mid = l + (r - l) / 2;
				if (nums[mid] < nums[l])
					r = mid;
				else if (nums[mid] > nums[r])
					l = mid + 1;
				else // nums[mid] >= nums[l] && nums[mid] <= nums[r]
				{
					res = nums[l];
					for (int i = l + 1; i <= r; i++)
					{
						if (res > nums[i])
							res = nums[i];
					}
					return res;
				}
			}
			return res;
		}
	}
}
