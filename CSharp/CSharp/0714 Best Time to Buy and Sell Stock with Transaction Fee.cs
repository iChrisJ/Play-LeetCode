using System;

namespace LeetCodeInCS._0714_Best_Time_to_Buy_and_Sell_Stock_with_Transaction_Fee
{
	public class Solution
	{
		public int MaxProfit(int[] prices, int fee)
		{
			int dp_i_0 = 0, dp_i_1 = int.MinValue;
			for (int i = 0; i < prices.Length; i++)
			{
				//int tmp = dp_i_0;
				dp_i_1 = Math.Max(dp_i_1, dp_i_0 - prices[i] - fee);
				dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
			}

			return dp_i_0;
		}
	}
}
