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
			double res = 1;

			while (n > 0)
			{
				if (n == 1)
					res *= x;
				x *= x;
				n = n / 2;
			}

			return res;
		}

		private double Calc(double x, int n)
		{
			if (n == 1)
				return x;
			double res = Calc(x, n / 2);
			return res * res;
		}


		//static void Main()
		//{
		//	new Solution().MyPow(2, 10);
		//}
	}
}
