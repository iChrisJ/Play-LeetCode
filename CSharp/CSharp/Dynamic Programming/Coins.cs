namespace LeetCodeInCS.Dynamic_Programming
{
	/// <summary>
	/// 给定数组arr, arr中所有的值都是正数且不重复。每个值代表一种面值的货币，
	/// 每个面值的货币可以使用任意张，再给定一个正数aim代表要找的钱数，
	/// 求换钱有多少种方法
	/// </summary>
	public class Coins_Solution
	{
		//Violent Search
		public int Coins(int[] arr, int aim)
		{
			if (arr == null || arr.Length == 0 || aim < 0)
				return 0;
			return Process(arr, 0, aim);

		}

		//Process(arr, index, aim),它的含义是如果用arr[index..N-1]这些面值的钱数组成aim，返回总的方法数
		private int Process(int[] arr, int index, int aim)
		{
			int res = 0;
			if (index == arr.Length)
				res = aim == 0 ? 1 : 0;
			else
			{
				for (int i = 0; arr[index] * i <= aim; i++)
					res += Process(arr, index + 1, aim - arr[index] * i);
			}
			return res;
		}
	}

	public class Coins_Solution2
	{
		//Memory Search
		private int[,] map;
		public int Coins(int[] arr, int aim)
		{
			if (arr == null || arr.Length == 0 || aim < 0)
				return 0;

			map = new int[arr.Length + 1, aim + 1];

			for (int i = 0; i < arr.Length + 1; i++)
				for (int j = 0; j < aim + 1; j++)
					map[i, j] = -1;

			return Process(arr, 0, aim);
		}

		//Process(arr, index, aim),它的含义是如果用arr[index..N-1]这些面值的钱数组成aim，返回总的方法数
		private int Process(int[] arr, int index, int aim)
		{
			int res = 0;
			if (index == arr.Length)
				res = aim == 0 ? 1 : 0;
			else
			{
				for (int i = 0; arr[index] * i <= aim; i++)
				{
					if (map[index - 1, aim - arr[index] * i] != -1)
						res += map[index - 1, aim - arr[index] * i];
					else
						res += Process(arr, index + 1, aim - arr[index] * i);
				}
			}
			map[index, aim] = res;
			return res;
		}
	}

	public class Coins_Solution3
	{
		//Dynamic Programming

		// dp[i][j]的含义是使用arr[0..i]货币情况下，组成钱数j的方法数
		private int[,] dp;
		public int Coins(int[] arr, int aim)
		{
			if (arr == null || arr.Length == 0 || aim < 0)
				return 0;

			dp = new int[arr.Length, aim + 1];

			for (int i = 0; i < arr.Length; i++)
				dp[i, 0] = 1;
			for (int i = 1; i < aim + 1; i++)
				dp[0, arr[0] * i] = 1;

			for (int i = 1; i < arr.Length; i++)
			{
				for (int j = 1; j <= aim; j++)
				{
					int num = 0;
					for (int k = 0; j - arr[i] * k >= 0; k++)
						num += dp[i - 1, j - arr[i] * k];
					dp[i, j] = num;
				}
			}
			return dp[arr.Length - 1, aim];
		}

		/**
		 * dp 优化版本，
		 */
		public int Coins2(int[] arr, int aim)
		{
			if (arr == null || arr.Length == 0 || aim < 0)
				return 0;

			dp = new int[arr.Length, aim + 1];
			for (int i = 0; i < arr.Length; i++)
				dp[i, 0] = 1;

			for (int j = 1; arr[0] * j <= aim; j++)
				dp[0, arr[0] * j] = 1;

			for (int i = 1; i < arr.Length; i++)
			{
				for (int j = 1; j <= aim; j++)
				{
					dp[i, j] = dp[i - 1, j];
					dp[i, j] += j - arr[i] >= 0 ? dp[i, j - arr[i]] : 0;  //优化的点
				}
			}
			return dp[arr.Length - 1, aim];
		}

		public int Coins3(int[] arr, int aim)
		{
			if (arr == null || arr.Length == 0 || aim < 0)
				return 0;
			int[] dp = new int[aim + 1];
			for (int j = 0; arr[0] * j <= aim; j++)
				dp[arr[0] * j] = 1;

			for (int i = 1; i < arr.Length; i++)
				for (int j = 1; j <= aim; j++)
					dp[j] += j - arr[i] >= 0 ? dp[j - arr[i]] : 0;
			return dp[aim];
		}
	}
}
