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
			{
				for (int j = i + 1; j < prices.Length; j++)
				{
					maxValue = Math.Max(maxValue, prices[j] - prices[i]);
				}
			}
			return maxValue;
		}

		// Time Complexity: O(n)
		// Space Complexity: O(1)
		public int MaxProfit2(int[] prices)
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
}
