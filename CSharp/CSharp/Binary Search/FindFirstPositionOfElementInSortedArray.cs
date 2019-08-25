namespace CSharp.Binary_Search
{
	/// <summary>
	/// 给定一个有序数组arr, 再给定一个整数num, 请在arr中找到num这个数出现的最左边的位置
	/// </summary>
	class FindFirstPositionOfElementInSortedArray_Solution
	{
		public int FindFirstPositionOfElementInSortedArray(int[] nums, int target)
		{
			if (nums == null || nums.Length == 0 || target < nums[0] || target > nums[nums.Length - 1])
				return -1;

			int l = 0, r = nums.Length - 1;
			int res = -1;
			while (l < r)
			{
				int mid = l + (r - l) / 2;
				if (nums[mid] == target)
				{
					res = mid;
					r = mid - 1;
				}
				else if (nums[mid] > target)
					r = mid - 1;
				else
					l = mid + 1;
			}
			return res;
		}
	}
}
