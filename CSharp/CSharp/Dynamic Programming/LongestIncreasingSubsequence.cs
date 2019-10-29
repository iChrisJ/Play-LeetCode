using System;

namespace LeetCodeInCS.Dynamic_Programming
{
	/// <summary>
	/// 给定数组arr, 返回arr的最长递增子序列长度。
	/// 比如arr=[2,1,5,3,6,4,8,9,7], 最长递增子序列为[1,3,4,8,9],
	/// 所以返回这个子序列的长度5.
	/// </summary>
	class LongestIncreasingSubsequence_Solution
	{
		public int LongestIncreasingSubsequence(int[] arr)
		{
			if (arr == null || arr.Length == 0)
				return 0;

			// dp[i]表示在必须以arr[i]这个数结尾的情况下，arr[0..i]中的最大递增子序列的长度
			// dp[i] = max{dp[j] + 1 (0 <= j < i, arr[j] < arr[i])}
			int[] dp = new int[arr.Length];
			dp[0] = 1;
			for (int i = 1; i < arr.Length; i++)
			{
				int max = 0;
				for (int j = 0; j < i; j++)
					max = arr[j] < arr[i] ? Math.Max(max, dp[j]) : max;
				dp[i] = max + 1;
			}

			Array.Sort<int>(dp);
			return dp[dp.Length - 1];
		}
	}
}
