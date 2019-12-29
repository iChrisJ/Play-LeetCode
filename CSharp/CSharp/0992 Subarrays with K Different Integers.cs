using System.Collections.Generic;

namespace LeetCodeInCS._0992_Subarrays_with_K_Different_Integers
{
	// Brute Force
	public class Solution
	{
		public int SubarraysWithKDistinct(int[] A, int K)
		{
			if (A == null || A.Length == 0 || A.Length < K)
				return 0;

			int l = 0, r = 0;
			Dictionary<int, int> dict = new Dictionary<int, int>();
			int res = 0;

			while (l <= A.Length - K)
			{
				while (dict.Count <= K && r < A.Length)
				{
					if (dict.ContainsKey(A[r]))
						dict[A[r]]++;
					else
						dict.Add(A[r], 1);

					if (dict.Count == K)
						res++;
					r++;
				}

				dict = new Dictionary<int, int>();
				l++;
				r = l;
			}
			return res;
		}
	}

	public class Solution2
	{
		public int SubarraysWithKDistinct(int[] A, int K)
		{
			return SubarraysWithAtMostKDistinct(A, K) - SubarraysWithAtMostKDistinct(A, K - 1);
		}

		private int SubarraysWithAtMostKDistinct(int[] A, int k)
		{
			int l = 0, res = 0;
			Dictionary<int, int> dict = new Dictionary<int, int>();

			for (int r = 0; r < A.Length; r++)
			{
				if (!dict.ContainsKey(A[r]))
				{
					dict.Add(A[r], 1);
					k--;
				}
				else
					dict[A[r]]++;

				while (k < 0)
				{
					dict[A[l]]--;
					if (dict[A[l]] == 0)
					{
						dict.Remove(A[l]);
						k++;
					}
					l++;
				}
				res += r - l + 1;
			}
			return res;
		}
	}
}
