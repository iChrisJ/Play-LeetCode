using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp._0905_Sort_Array_By_Parity
{
	public class Solution
	{
		public int[] SortArrayByParity(int[] A)
		{
			if (A == null)
				return null;

			int l = 0, r = A.Length - 1;

			while (l < r)
			{
				while (l < A.Length && A[l] % 2 == 0)
					l++;
				while (r >= 0 && A[r] % 2 == 1)
					r--;

				if (l == A.Length || r < 0 || l >= r)
					break;

				int t = A[l];
				A[l] = A[r];
				A[r] = t;
			}

			return A;
		}
	}
}
