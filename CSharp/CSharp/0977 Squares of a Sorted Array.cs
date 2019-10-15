namespace CSharp._0977_Squares_of_a_Sorted_Array
{
	public class Solution
	{
		public int[] SortedSquares(int[] A)
		{
			if (A == null || A.Length == 0)
				return A;

			int l = 0, r = A.Length - 1;
			int[] res = new int[A.Length];
			int k = res.Length - 1;

			while (l <= r)
			{
				if (A[l] * A[l] <= A[r] * A[r])
				{
					res[k] = A[r] * A[r];
					r--;
				}
				else
				{
					res[k] = A[l] * A[l];
					l++;
				}
				k--;
			}

			return res;
		}
	}
}
