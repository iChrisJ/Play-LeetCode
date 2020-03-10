using System;

namespace LeetCodeInCS._0188_Best_Time_to_Buy_and_Sell_Stock_IV
{
	public class Solution
	{
		public int MaxProfit(int k, int[] prices)
		{
			if (prices == null || prices.Length == 0)
				return 0;

			if (k >= prices.Length / 2)
			{
				int dp_0 = 0;
				int dp_1 = -prices[0];

				for (int i = 1; i < prices.Length; i++)
				{
					dp_0 = Math.Max(dp_0, dp_1 + prices[i]);
					dp_1 = Math.Max(dp_1, dp_0 - prices[i]);
				}
				return dp_0;
			}

			int[,] dp = new int[k + 1, 2];

			for (int i = 1; i <= k; i++)
			{
				dp[i, 0] = int.MinValue;
				dp[i, 1] = int.MinValue;
			}

			for (int i = 0; i < prices.Length; i++)
				for (int j = 1; j <= k; j++)
				{
					dp[j, 1] = Math.Max(dp[j, 1], dp[j - 1, 0] - prices[i]);
					dp[j, 0] = Math.Max(dp[j, 0], dp[j, 1] + prices[i]);
				}

			return dp[k, 0];
		}
	}
}
