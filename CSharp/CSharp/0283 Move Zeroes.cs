using System;

namespace LeetCodeInCS._0283_Move_Zeroes
{
	/// <summary>
	/// Make a copy of the nums array.
	/// </summary>
	public class Solution
	{
		public void MoveZeroes(int[] nums)
		{
			if (nums == null || nums.Length <= 1)
				return;

			int[] arr = new int[nums.Length];
			Array.Copy(nums, arr, nums.Length);

			int k = 0;
			for (int i = 0; i < nums.Length; i++)
				if (arr[i] != 0)
					nums[k++] = arr[i];

			for (int i = k; i < nums.Length; i++)
				nums[i] = 0;
		}
	}

	/// <summary>
	/// Two Pointer
	/// </summary>
	public class Solution2
	{
		public void MoveZeroes(int[] nums)
		{
			int k = 0; // In numns, [0...k) is non-zero element;
			for (int i = 0; i < nums.Length; i++)
				if (nums[i] != 0)
					nums[k++] = nums[i];

			for (int i = k; i < nums.Length; i++)
				nums[i] = 0;
		}
	}

	/// <summary>
	/// Two Pointer, swap elements.
	/// </summary>
	public class Solution3
	{
		public void MoveZeroes(int[] nums)
		{
			int k = 0; // In numns, [0...k) is non-zero element;
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] != 0)
				{
					if (i != k)
					{
						int temp = nums[i];
						nums[i] = nums[k];
						nums[k] = temp;
					}
					k++;
				}
			}
		}
	}
}
