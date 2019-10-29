using System;

namespace LeetCodeInCS._1143_Longest_Common_Subsequence
{
	public class Solution
	{
		public int LongestCommonSubsequence(string text1, string text2)
		{
			if (text1 == null || text2 == null || text1.Length == 0 || text2.Length == 0)
				return 0;

			int[,] dp = new int[text1.Length, text2.Length];

			dp[0, 0] = text1[0] == text2[0] ? 1 : 0;
			for (int i = 1; i < text1.Length; i++)
				dp[i, 0] = text1[i] == text2[0] ? 1 : dp[i - 1, 0];

			for (int i = 1; i < text2.Length; i++)
				dp[0, i] = text2[i] == text1[0] ? 1 : dp[0, i - 1];

			for (int i = 1; i < text1.Length; i++)
			{
				for (int j = 1; j < text2.Length; j++)
				{
					dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
					if (text1[i] == text2[j])
						dp[i, j] = Math.Max(dp[i - 1, j - 1] + 1, dp[i, j]);
				}
			}
			return dp[text1.Length - 1, text2.Length - 1];
		}
	}
}
