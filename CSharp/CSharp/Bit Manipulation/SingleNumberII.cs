namespace CSharp.Bit_Manipulation
{
	/// <summary>
	/// 给定一个整型数组arr，其中有两个数出现了奇数次，其他的数都出现了偶数次，打印这两个数。
	/// 要求时间复杂度为O(N)，额外空间复杂度为O(1)
	/// 
	/// 分析：
	/// 1. 整数n与0的异或结果为n
	/// 2. 整数n与自己异或结果为0
	/// eo = 0，假设arr中a和b出现了奇数次，剩下的数都出现了偶数次。
	/// eo与arr中所有的数异或完成后，eo=a^b. 因为a和b为不同的数，所以eo不为0
	/// eo = ... ... ... ... 1 ... ... ... ...
	///                      |
	///                32位整数第k位
	/// 说明a和b的第k位，一定不一样。
	/// 设置新整数eo'=0
	/// eo'与arr中第k位为1的那些整数进行异或。异或完成后，eo'为a或b中的一个
	/// 另一个数等于eo'^eo
	/// </summary>
	class SingleNumberII
	{
		public int[] SingleNumber(int[] nums)
		{
			int eo = 0;
			foreach (int num in nums)
				eo ^= num;

			int i = 0;
			for (; i < 32; i++)
			{
				if ((eo >> i & 1) == 1)
					break;
			}

			int eo_ = 0;
			foreach (int num in nums)
			{
				if ((num >> i & 1) == 1)
					eo_ ^= num;
			}
			return new int[2] { eo_, eo_ ^ eo };
		}
	}
}
