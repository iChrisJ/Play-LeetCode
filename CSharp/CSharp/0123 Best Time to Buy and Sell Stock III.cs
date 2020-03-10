using System;

namespace LeetCodeInCS._0123_Best_Time_to_Buy_and_Sell_Stock_III
{
	public class Solution
	{
		public int MaxProfit(int[] prices)
		{
			int dp_i10 = 0, dp_i11 = int.MinValue;
			int dp_i20 = 0, dp_i21 = int.MinValue;

			foreach (int price in prices)
			{
				dp_i20 = Math.Max(dp_i20, dp_i21 + price);
				dp_i21 = Math.Max(dp_i21, dp_i10 - price);
				dp_i10 = Math.Max(dp_i10, dp_i11 + price);
				dp_i11 = Math.Max(dp_i11, -price);
			}
			return dp_i20;
		}
	}
}
