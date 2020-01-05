using System.Collections.Generic;

namespace LeetCodeInCS._0454_4Sum_II
{
	public class Solution
	{
		public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
		{
			Dictionary<int, int> recrod = new Dictionary<int, int>();

			for (int i = 0; i < C.Length; i++)
			{
				for (int j = 0; j < D.Length; j++)
				{
					if (recrod.ContainsKey(C[i] + D[j]))
						recrod[C[i] + D[j]] += 1;
					else
						recrod.Add(C[i] + D[j], 1);
				}
			}

			int res = 0;
			for (int i = 0; i < A.Length; i++)
			{
				for (int j = 0; j < B.Length; j++)
				{
					if (recrod.ContainsKey(0 - A[i] - B[j]))
						res += recrod[0 - A[i] - B[j]];
				}
			}
			return res;
		}
	}
}
