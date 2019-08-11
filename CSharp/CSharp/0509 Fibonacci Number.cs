namespace CSharp._0509_Fibonacci_Number
{
	public class Solution
	{
		public int Fib(int N)
		{
			int[] memo = new int[N + 1];
			memo[0] = 0;
			if (N > 0)
				memo[1] = 1;
			for (int i = 2; i <= N; i++)
				memo[i] = memo[i - 1] + memo[i - 2];
			return memo[N];
		}
	}
}
