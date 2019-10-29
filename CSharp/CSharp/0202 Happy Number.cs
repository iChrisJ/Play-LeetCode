using System.Collections.Generic;

namespace LeetCodeInCS._0202_Happy_Number
{
	public class Solution
	{
		public bool IsHappy(int n)
		{
			Dictionary<int, int> dic = new Dictionary<int, int>();
			while (n != 1)
			{
				n = Sum(n);
				if (n == 1)
					return true;

				if (dic.ContainsKey(n))
					return false;
				else
					dic.Add(n, 1);
			}
			return true;
		}

		private int Sum(int n)
		{
			int sum = 0;
			while (n > 0)
			{
				sum = sum + (n % 10) * (n % 10);
				n = n / 10;
			}
			return sum;
		}
	}
}
