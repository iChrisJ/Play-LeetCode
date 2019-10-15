namespace CSharp._0832_Flipping_an_Image
{
	public class Solution
	{
		public int[][] FlipAndInvertImage(int[][] A)
		{
			if (A == null || A.Length == 0)
				return A;

			for (int i = 0; i < A.Length; i++)
			{
				for (int j = 0; j < A[0].Length / 2; j++)
				{
					int t = A[i][j];
					A[i][j] = A[i][A[0].Length - 1 - j];
					A[i][A.Length - 1 - j] = t;
				}

				for (int j = 0; j < A[0].Length; j++)
					A[i][j] ^= 1;
			}
			return A;
		}
	}
}
