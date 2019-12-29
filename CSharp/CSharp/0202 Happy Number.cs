using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0202_Happy_Number
{
	public class Solution
	{
		public bool IsHappy(int n)
		{
			if (n <= 0)
				throw new ArgumentException("Invalid Parameter.");

			HashSet<int> set = new HashSet<int>();
			while (n > 0)
			{
				int sum = 0;
				while (n > 0)
				{
					sum += (n % 10) * (n % 10);
					n = n / 10;
				}

				if (sum == 1)
					return true;

				if (set.Contains(sum))
					return false;

				set.Add(sum);
				n = sum;
			}
			return false;
		}
	}
}
