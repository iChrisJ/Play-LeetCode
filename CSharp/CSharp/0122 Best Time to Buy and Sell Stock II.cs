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
}
