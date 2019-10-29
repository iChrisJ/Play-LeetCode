namespace LeetCodeInCS.Binary_Search
{
	/// <summary>
	/// 如果更快的求一个整数k的N次方. 
	/// 如果两个整数相乘并得到结果的时间复杂度为O(1), 得到整数k的N次方的过程请实现时间复杂度为O(logN)的方法。
	/// </summary>
	class Pow_Solution
	{
		public long Pow(int k, int n)
		{
			long p = (long)n;

			if (p < 0)
			{
				p = -p;
				k = 1 / k;
			}

			long result = 1;
			while (p > 0) // x^13 = x^8 * x^4 * x^1   13 = (1101) in binary
			{
				if (p % 2 == 1)
					result = result * k;
				k = k * k;
				p = p / 2;
			}

			return result;
		}
	}
}
