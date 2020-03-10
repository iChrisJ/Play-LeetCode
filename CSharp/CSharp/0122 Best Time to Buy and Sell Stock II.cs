using System;

namespace LeetCodeInCS._0122_Best_Time_to_Buy_and_Sell_Stock_II
{
	public class Solution
	{
		// Time Complexity: O(n)
		// Space Complexity: O(1)
		public int MaxProfit(int[] prices)
		{
			int res = 0;
			if (prices.Length == 0)
				return res;
			int nowMin = prices[0];
			foreach (int price in prices)
			{
				if (price > nowMin)
					res += price - nowMin;
				nowMin = price;
			}
			return res;
		}
	}

	// Dynamic Programming
	// Time Complexity: O(n)
	// Space Complexity: O(n*2)
	public class Solution2
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
				dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
				dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
			}
			return dp[prices.Length - 1, 0];
		}
	}

	// Dynamic Programming
	// Time Complexity: O(n)
	// Space Complexity: O(1)
	public class Solution3
	{
		public int MaxProfit(int[] prices)
		{
			if (prices == null || prices.Length == 0)
				return 0;

			int dp_0 = 0;
			int dp_1 = -prices[0];

			for (int i = 1; i < prices.Length; i++)
			{
				dp_0 = Math.Max(dp_0, dp_1 + prices[i]);
				dp_1 = Math.Max(dp_1, dp_0 - prices[i]);
			}
			return dp_0;
		}
	}
}
