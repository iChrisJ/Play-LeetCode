using System;

namespace CSharp.Knapsack01
{
	class Solution
	{
		#region Recursive
		public int Knapsack01(int[] w, int[] v, int C)
		{
			int n = w.Length;
			return BestValue(w, v, n - 1, C);
		}

		private int BestValue(int[] w, int[] v, int index, int c)
		{
			if (index >= w.Length || c <= 0)
				return 0;

			int res = BestValue(w, v, index - 1, c);
			if (w[index] <= c)
				res = Math.Max(res, v[index] + BestValue(w, v, index - 1, c - v[index]));
			return res;
		}
		#endregion Recursive
	}

	class Solution2
	{
		#region Memory Search

		private int[,] memo;
		public int Knapsack01(int[] w, int[] v, int C)
		{
			int n = w.Length;
			if (n == 0 || C == 0)
				return 0;

			memo = new int[n, C + 1];
			for (int i = 0; i < memo.GetLength(0); i++)
				for (int j = 0; j < memo.LongLength / memo.GetLength(0); j++)
					memo[i, j] = -1;

			return BestValue(w, v, n - 1, C);
		}

		private int BestValue(int[] w, int[] v, int index, int c)
		{
			if (index >= w.Length || c <= 0)
				return 0;

			if (memo[index, c] != -1)
				return memo[index, c];

			int res = BestValue(w, v, index - 1, c);
			if (w[index] <= c)
				res = Math.Max(res, v[index] + BestValue(w, v, index - 1, c - v[index]));
			memo[index, c] = res;
			return res;
		}
		#endregion Memory Search
	}

	class Solution3
	{
		#region Dynamic Programming

		private int[,] memo;
		public int Knapsack01(int[] w, int[] v, int C)
		{
			int n = w.Length;
			if (n == 0 || C == 0)
				return 0;

			memo = new int[n, C + 1];
			for (int i = 0; i < memo.GetLength(0); i++)
				for (int j = 0; j < memo.LongLength / memo.GetLength(0); j++)
					memo[i, j] = -1;

			for (int j = 0; j <= C; j++)
				memo[0, j] = j >= w[0] ? v[0] : 0;

			for (int i = 1; i < n; i++)
			{
				for (int j = 0; j <= C; j++)
				{
					memo[i, j] = memo[i - 1, j];
					if (w[i] <= j)
						memo[i, j] = Math.Max(memo[i, j], v[i] + memo[i - 1, j - w[i]]);
				}
			}

			return memo[n - 1, C];
		}
		#endregion Dynamic Programming
	}

	// Time Complexity: O(n*C)
	// Space Complexity: O(2*C) = O(C)
	class Solution4
	{
		#region Dynamic Programming Optimization

		private int[,] memo;
		public int Knapsack01(int[] w, int[] v, int C)
		{
			int n = w.Length;
			if (n == 0 || C == 0)
				return 0;

			memo = new int[2, C + 1];
			for (int i = 0; i < memo.GetLength(0); i++)
				for (int j = 0; j < memo.LongLength / memo.GetLength(0); j++)
					memo[i, j] = -1;

			for (int j = 0; j <= C; j++)
				memo[0, j] = j >= w[0] ? v[0] : 0;

			for (int i = 1; i < n; i++)
			{
				for (int j = 0; j <= C; j++)
				{
					memo[i % 2, j] = memo[(i - 1) % 2, j];
					if (w[i] <= j)
						memo[i % 2, j] = Math.Max(memo[i, j], v[i] + memo[(i - 1) % 2, j - w[i]]);
				}
			}

			return memo[(n - 1) % 2, C];
		}
		#endregion Dynamic Programming Optimization
	}

	// Time Complexity: O(n*C)
	// Space Complexity: O(C)
	class Solution5
	{
		#region Dynamic Programming Optimization2

		private int[] memo;
		public int Knapsack01(int[] w, int[] v, int C)
		{
			int n = w.Length;
			if (n == 0 || C == 0)
				return 0;

			memo = new int[C + 1];
			Array.Fill<int>(memo, -1);

			for (int j = 0; j <= C; j++)
				memo[j] = j >= w[0] ? v[0] : 0;

			for (int i = 1; i < n; i++)
				for (int j = C; j >= w[i]; j--)
					memo[j] = Math.Max(memo[j], v[i] + memo[j - w[i]]);

			return memo[C];
		}
		#endregion Dynamic Programming Optimization2
	}
}
