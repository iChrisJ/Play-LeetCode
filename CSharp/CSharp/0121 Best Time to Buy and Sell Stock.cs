using System;

namespace LeetCodeInCS._0121_Best_Time_to_Buy_and_Sell_Stock
{
	public class Solution
	{
		// Time Complexity: O(n^2)
		// Space Complexity: O(1)
		public int MaxProfit(int[] prices)
		{
			int maxValue = 0;
			for (int i = 0; i < prices.Length - 1; i++)
				for (int j = i + 1; j < prices.Length; j++)
					maxValue = Math.Max(maxValue, prices[j] - prices[i]);
			return maxValue;
		}
	}

	public class Solution2
	{
		// Time Complexity: O(n)
		// Space Complexity: O(1)
		public int MaxProfit(int[] prices)
		{
			int maxValue = 0;
			int minPrice = int.MaxValue;
			foreach (int price in prices)
			{
				minPrice = Math.Min(minPrice, price);
				maxValue = Math.Max(maxValue, price - minPrice);
			}
			return maxValue;
		}
	}

	// DP
	public class Solution3
	{
		public int MaxProfit(int[] prices)
		{
			if (prices == null || prices.Length == 0)
				return 0;

			int[,] dp = new int[prices.Length, 2];
			dp[0, 0] = 0;
			dp[0, 1] = -prices[0];

			for (int i = 1; i < prices.Length; i++)
			{
				// No stock bought yet.
				dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
				// Have bought one stack.
				dp[i, 1] = Math.Max(-prices[i], dp[i - 1, 1]);
			}
			return dp[prices.Length - 1, 0];
		}
	}
}
