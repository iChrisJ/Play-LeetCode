using System.Collections.Generic;

namespace LeetCodeInCS._0239_Sliding_Window_Maximum
{
	public class Solution
	{
		public int[] MaxSlidingWindow(int[] nums, int k)
		{
			if (k == 0)
				return new int[0];

			int[] res = new int[nums.Length - k + 1];
			int l = 0, r = 0;
			int curMaxInd = 0;
			int start = 0;

			while (r < nums.Length)
			{
				curMaxInd = nums[curMaxInd] < nums[r] ? r : curMaxInd;
				r++;

				if (l > curMaxInd)
				{
					curMaxInd = l;
					for (int i = l + 1; i < r; i++)
						curMaxInd = nums[curMaxInd] < nums[i] ? i : curMaxInd;
				}

				if (r - l == k)
				{
					res[start++] = nums[curMaxInd];
					l++;
				}
			}
			return res;
		}
	}

	public class Solution2
	{
		public int[] MaxSlidingWindow(int[] nums, int k)
		{
			if (nums == null || nums.Length * k == 0)
				return new int[0];

			int[] res = new int[nums.Length - k + 1];
			LinkedList<int> deque = new LinkedList<int>();

			for (int i = 0; i < k; i++)
			{
				CleanUp_Deque(nums, deque, i, k);
				deque.AddLast(i);
			}

			res[0] = nums[deque.First.Value];

			for (int i = k; i < nums.Length; i++)
			{
				CleanUp_Deque(nums, deque, i, k);
				deque.AddLast(i);
				res[i - k + 1] = nums[deque.First.Value];
			}
			return res;
		}

		private void CleanUp_Deque(int[] nums, LinkedList<int> deque, int i, int k)
		{
			if (deque.Count > 0 && deque.First.Value == i - k)
				deque.RemoveFirst();

			while (deque.Count > 0 && nums[i] >= nums[deque.Last.Value])
				deque.RemoveLast();
		}
	}
}
