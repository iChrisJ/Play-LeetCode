namespace LeetCodeInCS._0995_Minimum_Number_of_K_Consecutive_Bit_Flips
{
	/// <summary>
	/// Brute Force
	/// Time Limit Exceeded
	/// </summary>
	public class Solution
	{
		public int MinKBitFlips(int[] A, int K)
		{
			if (A == null || A.Length == 0 || K == 0)
				return -1;

			int res = 0;

			for (int i = 0; i < A.Length; i++)
			{
				if (A[i] == 0)
				{
					if (i <= A.Length - K)
					{
						for (int j = i; j < i + K; j++)
							A[j] ^= 1;
						res++;
					}
					else
						return -1;
				}
			}
			return res;
		}
	}

	public class Solution2
	{
		public int MinKBitFlips(int[] A, int K)
		{
			if (A == null || A.Length == 0 || K == 0)
				return -1;

			int[] flipped = new int[A.Length];
			int flip = 0;
			int res = 0;

			for (int i = 0; i < A.Length; i++)
			{
				if (i >= K)
					flip ^= flipped[i - K];
				if ((A[i] ^ flip) == 0)
				{
					if (i + K > A.Length)
						return -1;
					res++;
					flip ^= 1;
					flipped[i] = 1;
				}
			}
			return res;
		}
	}
}
