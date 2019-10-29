using System;

namespace LeetCodeInCS.Dynamic_Programming
{
	/// <summary>
	/// 一个背包有一定的承重C，有N件物品，每件都有自己的价值，记录在数组v中，
	/// 也都有自己的重量，记录在数组w中，每件物品只能选择要装入背包还是不装入背包，
	/// 要求在不超过背包承重的前提下，选出物品的总价值最大。
	/// </summary>
	class Knapsack01_Solution
	{
		public int Knapsack01(int[] v, int[] w, int C)
		{
			if (v == null || w == null || v.Length == 0 || w.Length == 0 || v.Length != w.Length || C <= 0)
				return 0;

			/// 假设物品编号从1到n，一件一件物品考虑是否加入背包。假设dp[x][y]表示前x件物品，不超过重量y的时候的最大价值。枚举一下第x件物品的情况：
			/// 情况一：如果选择第x件物品，则前x-1件物品得到的重量不能超过y-w[x]
			/// 情况二：如果不选第x件物品，则前x-1件物品得到的重量不能超过y
			/// 所以，dp[x][y]可能等于dp[x-1][y]，也就是不取第x件物品的时，价值和之前一样。
			/// 也可能是dp[x-1][y-w[x]]+v[x]，也就是决定拿第x件物品的情况，当然会获得物品的价值。
			/// 两种可能性中，应该选择价值最大的那个。dp[x][y] = max{dp[x-1][y], dp[x-1][y-w[x]]+[x]}.
			/// 对于dp矩阵来说，行数是物品的数量N,列数是背包的容量C+1，从左到右，再从上到下依次计算所有的dp值即可。

			int[,] dp = new int[v.Length, C + 1];

			for (int i = 1; i <= C; i++)
				dp[0, i] = w[0] <= C ? v[0] : 0;

			for (int i = 1; i < v.Length; i++)
			{
				for (int j = 1; j <= C; j++)
					dp[i, j] = Math.Max(dp[i - 1, j], j - w[i] >= 0 ? dp[i - 1, j - w[i]] + v[i] : 0);
			}

			return dp[v.Length - 1, C];
		}
	}
}
