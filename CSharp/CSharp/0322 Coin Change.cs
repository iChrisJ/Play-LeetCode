using System;

namespace LeetCodeInCS._0322_Coin_Change
{
	public class Solution
	{
		public int CoinChange(int[] coins, int amount)
		{
			if (amount < 0)
				throw new Exception("Incorrect parameters.");
			if (amount == 0)
				return 0;
			if (coins == null || coins.Length == 0)
				return -1;

			int[] dp = new int[amount + 1];
			Array.Fill<int>(dp, amount + 1, 1, dp.Length - 1);

			for (int i = 1; i <= amount; i++)
			{
				for (int j = 0; j < coins.Length; j++)
				{
					if (coins[j] <= i)
						dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
				}
			}
			return dp[amount] > amount ? -1 : dp[amount];
		}
	}
}
