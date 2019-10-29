using System;

namespace LeetCodeInCS._0189_Rotate_Array
{
	public class Solution
	{
		/// Time Complexity: O(n)
		/// Space Complexity: O(n)
		public void Rotate(int[] nums, int k)
		{
			if (nums == null || nums.Length == 0)
				return;

			k = k % nums.Length;
			int[] temp = new int[nums.Length];
			Array.Copy(nums, temp, nums.Length);

			for (int i = 0; i < nums.Length; i++)
				nums[(i + k) % nums.Length] = temp[i];
		}
	}

	public class Solution2
	{
		/// Time Complexity: O(n)
		/// Space Complexity: O(1)
		public void Rotate(int[] nums, int k)
		{
			if (nums == null || nums.Length == 0)
				return;

			k = k % nums.Length;
			int moveCount = 0;

			for (int start = 0; moveCount < nums.Length; start++)
			{
				int cur = start;
				int prev = nums[start];

				do
				{
					cur = (cur + k) % nums.Length;
					int temp = nums[cur];
					nums[cur] = prev;
					prev = temp;
					moveCount++;
				} while (start != cur);
			}
		}
	}
}
