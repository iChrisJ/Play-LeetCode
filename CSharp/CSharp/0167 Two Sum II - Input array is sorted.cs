using System;

namespace LeetCodeInCS._0167_Two_Sum_II___Input_array_is_sorted
{
	/// <summary>
	/// Binary Search
	/// </summary>
	public class Solution
	{
		public int[] TwoSum(int[] numbers, int target)
		{
			for (int i = 0; i < numbers.Length - 1 && 2 * numbers[i] <= target; i++)
			{
				int other = FindNum(numbers, i, numbers.Length - 1, target - numbers[i]);
				if (other != -1)
					return new int[2] { i + 1, other + 1 };
			}
			throw new ArgumentException("Invalid arguments.");
		}

		private int FindNum(int[] nums, int l, int r, int v)
		{
			if (l < r)
				return -1;

			int mid = l + (r - l) / 2;

			if (nums[mid] == v)
				return mid;
			else if (nums[mid] > v)
				return FindNum(nums, l, mid - 1, v);
			else
				return FindNum(nums, mid + 1, r, v);
		}
	}

	/// <summary>
	/// Two points
	/// </summary>
	public class Solution2
	{
		public int[] TwoSum(int[] numbers, int target)
		{
			int i = 0, j = numbers.Length - 1;

			while (i < j)
			{
				int gap = numbers[i] + numbers[j] - target;
				if (gap == 0)
					return new int[2] { i + 1, j + 1 };
				else if (gap > 0)
					j--;
				else
					i++;
			}
			throw new ArgumentException("Invalid arguments.");
		}
	}
}
