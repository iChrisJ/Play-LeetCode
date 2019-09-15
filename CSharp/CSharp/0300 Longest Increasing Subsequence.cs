using System;
using System.Collections.Generic;

namespace CSharp._0300_Longest_Increasing_Subsequence
{
	public class Solution
	{
		public int LengthOfLIS(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return 0;

			// dp[i]表示在必须以nums[i]这个数结尾的情况下，nums[0..i]中的最大递增子序列的长度
			// dp[i] = max{dp[j] + 1 (0 <= j < i, nums[j] < nums[i])}
			int[] dp = new int[nums.Length];
			Array.Fill<int>(dp, 1);
			int res = 1;
			for (int i = 1; i < nums.Length; i++)
			{
				for (int j = 0; j < i; j++)
					if (nums[j] < nums[i])
						dp[i] = Math.Max(dp[j] + 1, dp[i]);
				res = Math.Max(res, dp[i]);
			}
			return res;
		}
	}
	public class Solution2
	{
		public int LengthOfLIS(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return 0;

			List<int> res = new List<int>();

			for (int i = 0; i < nums.Length; i++)
			{
				int index = GetLowerBound(res, nums[i]);
				if (index == res.Count)
					res.Add(nums[i]);
				else
					res[index] = nums[i];
			}
			return res.Count;
		}

		/// Binary search, return the index if find the element; 
		/// Otherwise return the index of the first element which is larger than the num;
		/// If no larger element, return the count of list.
		private int GetLowerBound(IList<int> list, int num)
		{
			int l = 0, r = list.Count - 1;
			while (l <= r)
			{
				int mid = l + (r - l) / 2;
				if (list[mid] == num)
					return mid;
				else if (list[mid] > num)
					r = mid - 1;
				else
					l = mid + 1;
			}
			return l;
		}
	}
}
