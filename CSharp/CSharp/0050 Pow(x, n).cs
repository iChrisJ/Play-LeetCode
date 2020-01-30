namespace LeetCodeInCS._0050_Pow_x__n_
{
	public class Solution
	{
		public double MyPow(double x, int n)
		{
			if (n < 0)
			{
				x = 1 / x;
				n = -n;
			}
			return Calc(x, n);
		}

		private double Calc(double x, int n)
		{
			if (n == 0)
				return 1.0;

			double half = Calc(x, n / 2);
			double res = half * half;
			return n % 2 == 0 ? res : res * x;
		}
	}

	public class Solution2
	{
		public double MyPow(double x, int n)
		{
			long N = n;
			if (N < 0)
			{
				x = 1 / x;
				N = -N;
			}

			double ans = 1.0;
			double cur_production = x;
			for (long i = N; i > 0; i /= 2)
			{
				if (i % 2 == 1)
					ans *= cur_production;
				cur_production = cur_production * cur_production;
			}
			return ans;
		}
	}
}
