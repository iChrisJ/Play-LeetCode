namespace CSharp.Dynamic_Programming
{
	/// <summary>
	/// 有n级台阶，一个人每次上一级或两级，问有多少种走完n级台阶的方法
	/// </summary>
	class Fibonacci_Solution
	{
		public int Fibonacci(int n)
		{
			if (n < 1)
				return 0;

			if (n == 1 || n == 2)
				return n;
			return Fibonacci(n - 1) + Fibonacci(n - 2);
		}
	}

	class Fibonacci_Solution2
	{
		public int Fibonacci(int n)
		{
			if (n < 1)
				return 0;

			int[] memo = new int[n + 1];
			memo[1] = 1;
			memo[2] = 2;

			for (int i = 3; i <= n; i++)
				memo[i] = memo[i - 1] + memo[i - 2];

			return memo[n];
		}
	}
}
