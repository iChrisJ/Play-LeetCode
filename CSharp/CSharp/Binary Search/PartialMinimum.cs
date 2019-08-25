namespace CSharp.Binary_Search
{
	/// <summary>
	/// 给定一个无序数组arr, 已知任意相邻的两个元素, 值都不重复. 请返回任意一个局部最小的位置. 
	// 所谓局部最小的位置是指, 如果arr[0]<arr[1], 那么位置0就是一个局部最小的位置. 如果arr[n-1](也就是arr最右的数)小于arr[N－2], 那么位置N－1也是局部最小的位置. 
	// 如果位置i既不是最左位置也不是最右位置. 那么只要满足arr[i]同时小于它左右两侧的值即(arr[i-1]和arr[i+1]), 那么位置i也是一个局部最小的位置
	/// </summary>
	class PartialMinimum_Solution
	{
		public int PartialMinimum(int[] arr)
		{
			if (arr == null || arr.Length == 0)
				return -1;
			if (arr.Length == 1)
				return 0;

			if (arr[0] < arr[1])
				return 0;
			if (arr[arr.Length - 1] < arr[arr.Length - 2])
				return arr.Length - 1;

			int l = 0, r = arr.Length - 1;
			while (l < r)
			{
				int mid = l + (r - l) / 2;
				if (arr[mid] < arr[mid - 1] && arr[mid] < arr[mid + 1])
					return mid;
				else if (arr[mid] >= arr[mid - 1])
					r = mid;
				else if (arr[mid] >= arr[mid + 1])
					l = mid;
			}
			return -1;
		}
	}
}
