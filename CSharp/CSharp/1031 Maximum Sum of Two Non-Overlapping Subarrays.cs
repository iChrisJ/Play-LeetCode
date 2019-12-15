using System;

namespace LeetCodeInCS._1031_Maximum_Sum_of_Two_Non_Overlapping_Subarrays
{
	public class Solution
	{
		public int MaxSumTwoNoOverlap(int[] A, int L, int M)
		{
			if (A == null || A.Length == 0 || (L == 0 && M == 0))
				return 0;

			int maxSum = 0;

			for (int i = 0; i <= A.Length - L; i++)
			{
				int sumL = 0;
				for (int j = i; j < i + L; j++)
					sumL += A[j];

				int sumM = Math.Max(GetMaxSumM(0, i - 1, M, A), GetMaxSumM(i + L, A.Length - 1, M, A));
				maxSum = Math.Max(maxSum, sumL + sumM);
			}
			return maxSum;
		}

		private int GetMaxSumM(int start, int end, int length, int[] arr)
		{
			if (end - start + 1 < length)
				return 0;

			int sum = 0, max = 0;
			for (int i = start; i <= end; i++)
			{
				sum += arr[i];
				if (i - start + 1 > length)
					sum -= arr[i - length];

				max = Math.Max(max, sum);
			}
			return max;
		}
	}

	public class Solution2
	{
		public int MaxSumTwoNoOverlap(int[] A, int L, int M)
		{
			if (A == null || A.Length == 0 || (L == 0 && M == 0))
				return 0;

			for (int i = 1; i < A.Length; i++)
				A[i] += A[i - 1];

			int res = A[L + M - 1], lMax = A[L - 1], mMax = A[M - 1];
			for (int i = L + M; i < A.Length; i++)
			{
				lMax = Math.Max(lMax, A[i - M] - A[i - L - M]);
				mMax = Math.Max(mMax, A[i - L] - A[i - M - L]);
				res = Math.Max(res, Math.Max(lMax + A[i] - A[i - M], mMax + A[i] - A[i - L]));
			}
			return res;
		}
	}
}
