using System;

namespace LeetCodeInCS._0309_Best_Time_to_Buy_and_Sell_Stock_with_Cooldown
{
	public class Solution
	{
		public int MaxProfit(int[] prices)
		{

			int dp_i_0 = 0, dp_i_1 = int.MinValue;
			int dp_pre_0 = 0; // 代表 dp[i-2][0]
			for (int i = 0; i < prices.Length; i++)
			{
				int tmp = dp_i_0;
				dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
				dp_i_1 = Math.Max(dp_i_1, dp_pre_0 - prices[i]);
				dp_pre_0 = tmp;
			}
			return dp_i_0;
		}
	}
}
