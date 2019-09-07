namespace CSharp.Bit_Manipulation
{
	/// <summary>
	/// 给定一个整型数组arr，其中只有一个数出现了奇数次，其他的数都出现了偶数次，请打印这个数。
	/// 要求时间复杂度为O(N)，额外空间复杂度为O(1)
	/// </summary>
	class SingleNumberI
	{
		public int SingleNumber(int[] nums)
		{
			int res = 0;
			foreach (int num in nums)
				res ^= num;
			return res;
		}
	}
}
